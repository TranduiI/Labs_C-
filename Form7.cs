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
    public partial class Form7 : Form
    {
        private SqlConnection sqlConnection = new SqlConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataTable artDirs = new DataTable();
        private DataTable numPerf = new DataTable();

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=""C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\DEKANOVA.MDF"";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            sqlConnection.Open();

            string getArtDirStr = $"SELECT NumArtDir, ArtDirector FROM ArtDir";

            SqlCommand getArtDir = new SqlCommand(getArtDirStr, sqlConnection);

            adapter.SelectCommand = getArtDir;
            adapter.Fill(artDirs);

            comboBox1.DataSource = artDirs;
            comboBox1.DisplayMember = "ArtDirector";
            comboBox1.ValueMember = "NumArtDir";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string artDir = comboBox1.SelectedValue.ToString();
            string city = textBox2.Text;

            string cNumStr = $"SELECT TOP 1 NumPerf FROM Perfomance ORDER BY NumPerf DESC";
            SqlCommand cDT = new SqlCommand(cNumStr, sqlConnection);
            adapter.SelectCommand = cDT;
            adapter.Fill(numPerf);

            int numPr = Convert.ToInt32(numPerf.Rows[0][0].ToString()) + 1;

            string perfDate = dateTimePicker1.Text;


            string[] prevalA = perfDate.Split(' ');  // dd/MM/yyyy HH:mm:s
            string perfDateVal = prevalA[0];
            DateTime resPerfDate = DateTime.ParseExact(Convert.ToDateTime(perfDateVal).ToString("yyyy.MM.dd"), "yyyy.MM.dd", CultureInfo.InvariantCulture);

            string insC = $"insert into Perfomance (NumPerf, Name, PerfDate, Cities, NumArtDir) values ('{numPr}', '{name}', '{resPerfDate.ToString("yyyy.MM.dd")}', '{city}', '{artDir}')";
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
