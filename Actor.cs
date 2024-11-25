using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TheatreAppCurs
{
    public class Actor
    {
        
        private string name;
        private DateTime vacDate;
        private int id;

        public Actor(int id) {
            this.id = id;
        }

        public Actor( string name, DateTime vacDate){
            
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

        public void InsertActor(string conString)
        {

            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();
                
                SqlCommand command = connection.CreateCommand();
                command.CommandText = QuaryActor.quaryInsertActor;

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


        public void UpdateActor(string conString, int index)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();



                SqlCommand command = connection.CreateCommand();
                command.CommandText = QuaryActor.quaryUpdateActor;

                command.Parameters.AddWithValue("@IDActor", index);
                command.Parameters.AddWithValue("@Name", getName());
                command.Parameters.AddWithValue("@VacationDate", getVacDate().ToString("yyyy.MM.dd").Substring(0, 10));
                command.ExecuteScalar();
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        public void DeleteActor(string conString)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                SqlCommand commandChk = connection.CreateCommand();

                commandChk.CommandText = QuaryActor.quaryDeleteActorChk;
                commandChk.Parameters.AddWithValue("@IDActor", id);
                SqlDataAdapter adapter = new SqlDataAdapter(commandChk);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                adapter.Dispose();

                if (dt.Rows.Count == 0)
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = QuaryActor.quaryDeleteActor;
                    command.Parameters.AddWithValue("@IDActor", id);
                    command.ExecuteScalar();
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Сначала необходимо удалить назначения на представления (" + dt.Rows.Count + ")!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            
        }
        public void GetPerfs(string conString, ListBox lb)
        {
            //lb.DataSource = null;
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = QuaryActor.quaryGetPerf;



                command.Parameters.AddWithValue("@IDActor", id);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                adapter.Dispose();

                lb.DataSource = dt;
                lb.ValueMember = "NumPerf";
                lb.DisplayMember = "Name";

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            

            

        }
        public void DeleteFromPerf(string conString, int perfIndex)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = QuaryActor.quaryDeleteFromPerf;
                command.Parameters.AddWithValue("@NumPerf", perfIndex);
                command.Parameters.AddWithValue("@IDActor", id);


                command.ExecuteScalar();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
        public void InsertIntoPerf(string conString, int perfIndex)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();
                SqlCommand commandChk = connection.CreateCommand();

                commandChk.CommandText = QuaryActor.quaryInsertIntoPerfCheck;
                commandChk.Parameters.AddWithValue("@IDActor", id);
                commandChk.Parameters.AddWithValue("@NumPerf", perfIndex);
                SqlDataAdapter adapter = new SqlDataAdapter(commandChk);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                adapter.Dispose();
                if (dt.Rows.Count == 0)
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = QuaryActor.quaryInsertIntoPerf;
                    command.Parameters.AddWithValue("@NumPerf", perfIndex);
                    command.Parameters.AddWithValue("@IDActor", id);
                    command.ExecuteScalar();
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Уже учавствует!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            
            
            

        }

        public class QuaryActor
        {
            public static string quarySelectAllActorForCombo = "select * from Actors";
            public static string quarySelectAllActor = "SELECT Actors.IDActor, Actors.Name, Actors.VacationDate, COALESCE((STRING_AGG(TRIM(Perf.Name), ', ')), 'Не выступает') AS Perfomances FROM Actors LEFT JOIN ActorPerf ON Actors.IDActor = ActorPerf.IDActor left join Perf ON Perf.NumPerf = ActorPerf.NumPerf GROUP BY Actors.IDActor, Actors.Name, Actors.VacationDate";
            public static string quaryInsertActor = "insert into Actors(IDActor, Name, VacationDate) values((SELECT MAX(IDActor) FROM Actors)+1, @Name, @VacationDate)";
            public static string quaryDeleteActor = "delete from Actors where(IDActor = @IDActor)";
            public static string quaryFindActors = "select * from Actors where";
            public static string quaryUpdateActor = "update Actors set Name = @Name, VacationDate = @VacationDate where IDActor = @IDActor";
            public static string quaryGetPerf = "Select Perf.Name, Perf.NumPerf from Perf inner join ActorPerf on Perf.NumPerf = ActorPerf.NumPerf where ActorPerf.IDActor = @IDActor";
            public static string quaryDeleteFromPerf = "delete from ActorPerf where NumPerf = @NumPerf And IDActor = @IDActor";
            public static string quaryInsertIntoPerf = "INSERT into ActorPerf values (@NumPerf, @IDActor)";
            public static string quaryInsertIntoPerfCheck = "select NumPerf from ActorPerf where IDActor = @IDActor AND NumPerf = @NumPerf";
            public static string quaryDeleteActorChk = "select NumPerf from ActorPerf where IDActor = @IDActor";
        }
        
    }
}
