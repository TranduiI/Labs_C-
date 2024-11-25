using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace TheatreAppCurs
{
    public class Directions
    {
        private int numDirection;
        private string name;
        
        public Directions(int numDirection) 
        {
            this.numDirection = numDirection; 
        }

        public Directions(string name) 
        {
            this.name = name; 
        }

        public int getNumDirection()
        {
            return numDirection;
        }
        public string getName() 
        {
            return name;
        }

        public void InsertDirection(string conString)
        {

            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = QuaryDirections.quaryInsertDirection;
                command.Parameters.AddWithValue("@Name", getName());
                command.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(new DateTime(2020, 7, 15).ToString("yyyy.MM.dd").Substring(0, 10));
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateDirection(string conString, int numDir)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();



                SqlCommand command = connection.CreateCommand();
                command.CommandText = QuaryDirections.quaryUpdateDirection;
                command.Parameters.AddWithValue("@NumDirection", numDir);
                command.Parameters.AddWithValue("@Name", getName());
                command.ExecuteScalar();
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        public void DeleteDirection(string conString)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                SqlCommand commandChk = connection.CreateCommand();

                commandChk.CommandText = QuaryDirections.quaryDeleteDirectionChk;
                commandChk.Parameters.AddWithValue("@NumDirection", getNumDirection());
                SqlDataAdapter adapter = new SqlDataAdapter(commandChk);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                adapter.Dispose();

                if (dt.Rows.Count == 0)
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = QuaryDirections.quaryDeleteDirection;
                    command.Parameters.AddWithValue("@NumDirection", getNumDirection());
                    command.ExecuteScalar();
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Сначала необходимо удалить связанные высутплеия и театры (" + dt.Rows.Count + ")!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            
        }



        public class QuaryDirections
        {
            public static string quarySelectAllDirWithID = "select NumDirection as ID, Name from Direction";
            public static string quarySelectAllDirections = "select * from Direction";
            public static string quaryInsertDirection = "insert into Direction(NumDirection, Name) values ((SELECT MAX(NumDirection) FROM Direction)+1, @Name)";
            public static string quaryUpdateDirection = "update Direction set Name = @Name where NumDirection = @NumDirection";
            public static string quaryDeleteDirection = "delete from Direction where NumDirection = @NumDirection";
            public static string quaryDeleteDirectionChk = "select NumDirection from Perf where NumDirection = @NumDirection UNION ALL select NumDirection from Theatres where NumDirection = @NumDirection";
        }
    }
}
