using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TheatreAppCurs
{
    internal class ArtDir
    {
        private string name;
        private DateTime vacDate;
        private int id;
        public ArtDir(int id)
        {
            this.id = id;
        }

        public ArtDir(string name, DateTime vacDate)
        {

            this.name = name;
            this.vacDate = vacDate.Date;
        }
        public string getName()
        {
            return name;
        }

        public DateTime getVacDate()
        {
            return vacDate;
        }

        public void InsertArtDir(string conString)
        {

            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = QuaryArtDir.quaryInsertArtDir;

                command.Parameters.AddWithValue("@Name", getName());
                command.Parameters.AddWithValue("@VacationDate", getVacDate().ToString("yyyy.MM.dd").Substring(0, 10));
                command.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(new DateTime(2020, 7, 15).ToString("yyyy.MM.dd").Substring(0, 10));
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateArtDir(string conString, int index)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();



                SqlCommand command = connection.CreateCommand();
                command.CommandText = QuaryArtDir.quaryUpdateArtDir;

                command.Parameters.AddWithValue("@IDArtDir", index);
                command.Parameters.AddWithValue("@Name", getName());
                command.Parameters.AddWithValue("@VacationDate", getVacDate().ToString("yyyy.MM.dd").Substring(0, 10));
                command.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        public void DeleteArtDir(string conString)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                SqlCommand checkCommand = connection.CreateCommand();
                checkCommand.CommandText = QuaryArtDir.quaryDeleteArtDirCheck;
                checkCommand.Parameters.AddWithValue("@IDArtDir", id);
                SqlDataAdapter adapter = new SqlDataAdapter(checkCommand);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                adapter.Dispose();

                if (dt.Rows.Count == 0)
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = QuaryArtDir.quaryDeleteArtDir;
                    command.Parameters.AddWithValue("@IDArtDir", id);
                    command.ExecuteScalar();
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Невозможно удалить,\n" +
                        " один из Спектаклей назначен на данного режисера!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            
        }

        public class QuaryArtDir
        {
            public static string quarySelectAllArtDir = "SELECT * from ArtDir";
            public static string quaryInsertArtDir = "insert into ArtDir(IDArtDir, Name, VacationDate) values((SELECT MAX(IDArtDir) FROM ArtDir)+1, @Name, @VacationDate)";
            public static string quaryDeleteArtDir = "delete from ArtDir where(IDArtDir = @IDArtDir)";
            public static string quaryUpdateArtDir = "update ArtDir set Name = @Name, VacationDate = @VacationDate where IDArtDir = @IDArtDir";
            public static string quaryDeleteArtDirCheck = "select Name from Perf where IDArtDir = @IDArtDir";
            
        }

    }
}
