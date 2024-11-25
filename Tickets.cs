using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace TheatreAppCurs
{
    public class Tickets
    {
        private int count;
        private float price;
        private int numPerf;
        private int id;
        private DateTime date;

        public Tickets(int id) 
        {
            this.id = id;
        }

        public Tickets(int count, float price, int numPerf, DateTime date)
        {
            this.count = count;
            this.price = price;
            this.numPerf = numPerf;
            this.date = date;
        }

        public int getCount()
        {
            return count;
        }

        public float getPrice()
        {
            return price;
        }
        public int getNumPerf()
        {
            return numPerf;
        }

        public int getNumPerf(string conString)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = QuaryTickets.quaryGetNumPerf;
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
        public DateTime getDate()
        {
            return date;
        }

        public void InsertTicket(string conString)
        {

            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = QuaryTickets.quaryInsertTicket;

                command.Parameters.AddWithValue("@Count", getCount());
                command.Parameters.AddWithValue("@Price", getPrice());
                command.Parameters.AddWithValue("@NumPerf", getNumPerf());
                command.Parameters.AddWithValue("@Date", date.ToString("yyyy.MM.dd").Substring(0, 10));
                command.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(new DateTime(2020, 7, 15).ToString("yyyy.MM.dd").Substring(0, 10));
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateTicket(string conString, int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = QuaryTickets.quaryUpdateTicket;
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Count", getCount());
                command.Parameters.AddWithValue("@Price", getPrice());
                command.Parameters.AddWithValue("@NumPerf", getNumPerf());
                command.Parameters.AddWithValue("@Date", date.ToString("yyyy.MM.dd").Substring(0, 10));
                command.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
        public void DeleteTicket(string conString)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();



                SqlCommand command = connection.CreateCommand();
                command.CommandText = QuaryTickets.quaryDeleteTicket;
                command.Parameters.AddWithValue("@ID", getID());
                command.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        public class QuaryTickets
        {
            public static string quarySelectAllTickets = "select Tickets.ID, Tickets.Count, Tickets.Price, Perf.Name, Tickets.Date from Tickets inner join Perf on Tickets.NumPerf = Perf.NumPerf";
            public static string quaryUpdateTicket = "update Tickets set Count = @Count, Price = @Price, NumPerf = @NumPerf, Date = @Date where ID = @ID";
            public static string quaryInsertTicket = "insert into Tickets(Count, Price, NumPerf, Date) values(@Count, @Price, @NumPerf, @Date)";
            public static string quaryDeleteTicket = "delete from Tickets where ID = @ID";
            public static string quaryGetNumPerf = "select NumPerf from Tickets where ID = @ID";
            /*
            public static string quarySelectAllPerfs = "select * from Perf";
            public static string quaryDeletePerf = "delete from Perf where(NumPerf = @NumPerf)";
            public static string quaryDeletePerfChk = "select NumPerf from ActorPerf where NumPerf = @NumPerf UNION ALL select NumPerf from Tickets where NumPerf = @NumPerf";
            public static string quaryInsertPerf = "insert into Perf(NumPerf, IDArtDir, NumDirection, Name, Date) values((SELECT MAX(NumPerf) FROM Perf)+1, @IDArtDir, @NumDirection, @Name, @Date)";
            public static string quaryUpdatePerf = "update Perf set IDArtDir = @IDArtDir, NumDirection = @NumDirection, Name = @Name, Date = @Date where NumPerf = @NumPerf";

            */
        }
    }
}
