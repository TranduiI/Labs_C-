using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace TheatreApp
{
    public partial class Form4 : Form
    {
        private SqlConnection sqlConnection = new SqlConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataTable dataTable1 = new DataTable();

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=""C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\DEKANOVA.MDF"";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            sqlConnection.Open();

            string artDir = textBox1.Text;
            string vac = dateTimePicker1.Text;


            string[] prevalA = vac.Split(' ');  // dd/MM/yyyy HH:mm:s
            string vacVal = prevalA[0];
            DateTime resVac = DateTime.ParseExact(Convert.ToDateTime(vacVal).ToString("yyyy.MM.dd"), "yyyy.MM.dd", CultureInfo.InvariantCulture);

            string cNumStr = $"SELECT TOP 1 NumArtDir FROM ArtDir ORDER BY NumArtDir DESC";
            SqlCommand cDT = new SqlCommand(cNumStr, sqlConnection);
            adapter.SelectCommand = cDT;
            adapter.Fill(dataTable1);

            int numADir = Convert.ToInt32(dataTable1.Rows[0][0].ToString()) + 1;

            string insC = $"insert into ArtDir (NumArtDir, ArtDirector, VacationDate) values ('{numADir}','{artDir}','{resVac.ToString("yyyy.MM.dd")}')";
            try
            {
                SqlCommand insCM = new SqlCommand(insC, sqlConnection);
                insCM.ExecuteNonQuery();

                MessageBox.Show("Успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            sqlConnection.Close();
            Close();


        }
    }
}
