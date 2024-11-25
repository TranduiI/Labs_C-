using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TheatreAppCurs.Perf;
using System.Windows.Forms;

namespace TheatreAppCurs
{
    public class Search
    {
        int actTetr;
        string artDirSecName;
        DateTime date;
        bool withTheatre;
        
        public Search(int actTetr)
        {
            this.actTetr = actTetr;
        }
        public Search(string artDirSecName)
        {
            this.artDirSecName = "%"+artDirSecName+"%";
        }
        public Search(DateTime date)
        {
            this.date = date;
        }

        public Search(DateTime date, bool withTheatre)
        {
            this.date = date;
            this.withTheatre = withTheatre;
        }

        

        public void SelectPerfByActor(string conString, DataGridView dgv)
        {
            try
            {
                
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();

                command.CommandText = QuarySearch.PerfByActor;

                command.Parameters.AddWithValue("@IDActor", actTetr);
                MessageBox.Show(command.CommandText.ToString());
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgv.DataSource = dt;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                connection.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(new DateTime(2020, 7, 15).ToString("yyyy.MM.dd").Substring(0, 10));
                MessageBox.Show(ex.Message);
            }
        }
        public void SelectPerfByTheatre(string conString, DataGridView dgv)
        {
            try
            {

                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();

                command.CommandText = QuarySearch.PerfByTheatre;

                command.Parameters.AddWithValue("@IDTheatre", actTetr);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgv.DataSource = dt;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                connection.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(new DateTime(2020, 7, 15).ToString("yyyy.MM.dd").Substring(0, 10));
                MessageBox.Show(ex.Message);
            }
        }
        public void SelectPerfByArtDirSecName(string conString, DataGridView dgv)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();

                command.CommandText = QuarySearch.PerfByArtDirSecName;

                command.Parameters.AddWithValue("@AD", artDirSecName);
                MessageBox.Show(artDirSecName);
                MessageBox.Show(command.CommandText.ToString());
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgv.DataSource = dt;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void SelectPerfByDate(string conString, DataGridView dgv)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();

                if (withTheatre)
                {
                    command.CommandText = QuarySearch.PerfByDateWithTheatre;
                }
                else
                {
                    command.CommandText = QuarySearch.PerfByDateNoTheatre;
                }
                

                command.Parameters.AddWithValue("@Date", date.ToString("yyyy.MM.dd").Substring(0, 10));
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgv.DataSource = dt;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void SelectPerfByTicketPrice(string conString, DataGridView dgv)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                SqlCommand command = connection.CreateCommand();

                command.CommandText = QuarySearch.PerfByTicketPrice;

                command.Parameters.AddWithValue("@Date", date.ToString("yyyy.MM.dd").Substring(0, 10));
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgv.DataSource = dt;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        public class QuarySearch
        {
            public static string PerfByActor = "Select Perf.Name from Actors inner join ActorPerf on Actors.IDActor = ActorPerf.IDActor inner join Perf on ActorPerf.NumPerf = Perf.NumPerf where Actors.IDActor = @IDActor";
            public static string PerfByTheatre = "Select Perf.Name from Theatres inner join Direction on Theatres.NumDirection = Direction.NumDirection inner join Perf on Direction.NumDirection = Perf.NumDirection where Theatres.ID = @IDTheatre";
            public static string PerfByArtDirSecName = "Select Perf.Name from ArtDir inner join Perf on ArtDir.IDArtDir = Perf.IDArtDir where ArtDir.Name LIKE @AD";
            public static string PerfByDateNoTheatre = "Select distinct Perf.Name from Tickets inner join Perf on Tickets.NumPerf = Perf.NumPerf where Tickets.Date = @Date";
            public static string PerfByDateWithTheatre = "Select distinct Perf.Name, Theatres.Name from Tickets inner join Perf on Tickets.NumPerf = Perf.NumPerf inner join Theatres on Perf.NumDirection = Theatres.NumDirection where Tickets.Date = @Date";
            public static string PerfByTicketPrice = "select top 1 Perf.Name, Tickets.Price from Tickets inner join Perf on Tickets.NumPerf = Perf.NumPerf where Tickets.Date = @Date order by Price";
        }
    }
}
