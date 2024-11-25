using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace TheatreAppCurs
{
    public class Theatres
    {
        private string name;
        private string director;
        private string address;
        private int numDirection;
        private int id;

        public Theatres(int id) 
        {
            this.id = id;
        }

        public Theatres(string name, string director, string adress, int numDirection)
        {
            this.name = name;
            this.director = director;
            this.address = adress;
            this.numDirection = numDirection;
        }

        public string getName()
        {
            return name;
        }

        public string getDirector()
        {
            return director;
        }
        public string getAdress()
        {
            return address;
        }
        public int getNumDirection()
        {
            return numDirection;
        }
        public int getNumDirection(string conString)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = QuaryTheatres.quaryGetNumDirection;
                command.Parameters.AddWithValue("@ID", getID());

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

        public int getID()
        {
            return id;
        }

        public void InsertTheatre(string conString)
        {

            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = QuaryTheatres.quaryInsertTheatre;

                command.Parameters.AddWithValue("@Name", getName());
                command.Parameters.AddWithValue("@Director", getDirector());
                command.Parameters.AddWithValue("@Address", getAdress());
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

        public void UpdateTheatre(string conString, int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = QuaryTheatres.quaryUpdateTheatre;
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Name", getName());
                command.Parameters.AddWithValue("@Director", getDirector());
                command.Parameters.AddWithValue("@Address", getAdress());
                command.Parameters.AddWithValue("@NumDirection", getNumDirection());
                command.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
        public void DeleteTheatre(string conString)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();



                SqlCommand command = connection.CreateCommand();
                command.CommandText = QuaryTheatres.quaryDeleteTheatre;
                command.Parameters.AddWithValue("@ID", getID());
                command.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }





        public class QuaryTheatres
        {
            public static string quarySelectAllTheatresForCombo = "select * from Theatres";
            public static string quarySelectAllTheatres = "select Theatres.ID, Theatres.Name, Theatres.Director, Theatres.Address, Direction.Name AS Direction from Theatres inner join Direction on Theatres.NumDirection = Direction.NumDirection";
            public static string quaryDeleteTheatre = "delete from Theatres where(ID = @ID)";
            public static string quaryUpdateTheatre = "update Theatres set Name = @Name, Director = @Director, Address = @Address, NumDirection = @NumDirection where ID = @ID" ;
            public static string quaryInsertTheatre = "insert into Theatres(Name, Director, Address, NumDirection) values(@Name, @Director, @Address, @NumDirection)";
            public static string quaryGetNumDirection = "select NumDirection from Theatres where ID = @ID";
        }

    }
}
