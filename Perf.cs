using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TheatreAppCurs
{
    public class Perf
    {
        private int artDirector;
        private int numDirection;
        private string name;
        
        private int numPerf;
        public Perf(int numPerf)
        {
            this.numPerf = numPerf;
        }

        public Perf(int numDirection, string name)
        {
            this.numDirection = numDirection;
            this.name = name;
            
        }

        public Perf(int artDirector, int numDirection, string name)
        {
            this.artDirector = artDirector;
            this.numDirection = numDirection;
            this.name = name;
            
        }

        public string getName()
        {
            return name;
        }

        
        public int getAtrDir()
        {
            return artDirector;
        }
        public int getNumPerf()
        {
            return numPerf;
        }
        public int getNumDirection()
        {
            return numDirection;
        }

        public void InsertPerf(string conString)
        {

            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = QuaryPerf.quaryInsertPerf;

                command.Parameters.AddWithValue("@Name", getName());
                
                command.Parameters.AddWithValue("@IDArtDir", getAtrDir());
                command.Parameters.AddWithValue("@NumDirection", getNumDirection());
                command.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(new DateTime(2020, 7, 15).ToString("yyyy.MM.dd").Substring(0, 10));
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdatePerf(string conString, int numPerf)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();



                SqlCommand command = connection.CreateCommand();
                command.CommandText = QuaryPerf.quaryUpdatePerf;

                command.Parameters.AddWithValue("@NumPerf", numPerf);
                command.Parameters.AddWithValue("@IDArtDir", getAtrDir());
                command.Parameters.AddWithValue("@NumDirection", getNumDirection());
                command.Parameters.AddWithValue("@Name", getName());
                

                command.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
        public void DeletePerf(string conString)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                SqlCommand commandChk = connection.CreateCommand();

                commandChk.CommandText = QuaryPerf.quaryDeletePerfChk;
                commandChk.Parameters.AddWithValue("@NumPerf", numPerf);
                SqlDataAdapter adapter = new SqlDataAdapter(commandChk);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                adapter.Dispose();

                if (dt.Rows.Count == 0)
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = QuaryPerf.quaryDeletePerf;
                    command.Parameters.AddWithValue("@NumPerf", numPerf);
                    command.ExecuteScalar();
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Сначала необходимо удалить назначения \n актеров и билеты на спекталь (" + dt.Rows.Count + ")!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            
        }

        public int getNumDirection(string conString)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = QuaryPerf.quaryGetDirectionForID;
                command.Parameters.AddWithValue("@NumPerf", numPerf);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                adapter.Dispose();
                int i = Int32.Parse(dt.Rows[0][0].ToString());

                connection.Close();
                return i;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
           

            
        }
        public int getArtDir(string conString)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = QuaryPerf.quaryGetArtDirForID;
                command.Parameters.AddWithValue("@NumPerf", numPerf);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                adapter.Dispose();

                int i = Int32.Parse(dt.Rows[0][0].ToString());

                connection.Close();
                return i;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            
        }


        public class QuaryPerf
        {
            public static string quarySelectAllForCombo = "select * from Perf";
            public static string quarySelectAllPerfs = "select Perf.NumPerf AS ID, ArtDir.Name AS ArtDir, Direction.Name AS Direction, Perf.Name from Perf inner join ArtDir on Perf.IDArtDir = ArtDir.IDArtDir inner join Direction on Perf.NumDirection = Direction.NumDirection";
            public static string quaryDeletePerf = "delete from Perf where(NumPerf = @NumPerf)";
            public static string quaryDeletePerfChk = "select NumPerf from ActorPerf where NumPerf = @NumPerf UNION ALL select NumPerf from Tickets where NumPerf = @NumPerf";
            public static string quaryInsertPerf = "insert into Perf(NumPerf, IDArtDir, NumDirection, Name) values((SELECT MAX(NumPerf) FROM Perf)+1, @IDArtDir, @NumDirection, @Name)";
            public static string quaryUpdatePerf = "update Perf set IDArtDir = @IDArtDir, NumDirection = @NumDirection, Name = @Name where NumPerf = @NumPerf";
            public static string quaryGetDirectionForID = "select NumDirection from Perf where NumPerf = @NumPerf";
            public static string quaryGetArtDirForID = "select IDArtDir from Perf where NumPerf = @NumPerf";



        }
    }
}
