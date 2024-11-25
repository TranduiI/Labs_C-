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

namespace TheatreApp
{
    public partial class Form6 : Form
    {
        private SqlConnection sqlConnection = new SqlConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataTable artDirs = new DataTable();
        private DataTable dirs = new DataTable();
        private DataTable numGroup = new DataTable();


        public Form6()
        {
            InitializeComponent();
        }

        

        private void Form6_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=""C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\DEKANOVA.MDF"";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            sqlConnection.Open();

            string getArtDirStr = $"SELECT NumArtDir, ArtDirector FROM ArtDir";
            string getDirStr = $"SELECT NumDirection, Direction FROM Direction";

            SqlCommand getArtDir = new SqlCommand(getArtDirStr, sqlConnection);
            SqlCommand getDir = new SqlCommand(getDirStr, sqlConnection);

            adapter.SelectCommand = getArtDir;
            adapter.Fill(artDirs);

            adapter.SelectCommand = getDir;
            adapter.Fill(dirs);

            comboBox1.DataSource = dirs;
            comboBox1.DisplayMember = "Direction";
            comboBox1.ValueMember = "NumDirection";

            comboBox2.DataSource = artDirs;
            comboBox2.DisplayMember = "ArtDirector";
            comboBox2.ValueMember = "NumArtDir";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string numDir = comboBox1.SelectedValue.ToString();
            string artDir = comboBox2.SelectedValue.ToString();

            string cNumStr = $"SELECT TOP 1 NumGroup FROM Groups ORDER BY NumGroup DESC";
            SqlCommand cDT = new SqlCommand(cNumStr, sqlConnection);
            adapter.SelectCommand = cDT;
            adapter.Fill(numGroup);

            int numGr = Convert.ToInt32(numGroup.Rows[0][0].ToString()) + 1;

            string insC = $"insert into Groups (NumGroup, Name, NumDirection, NumArtDir) values ('{numGr}','{name}', '{numDir}', '{artDir}')";
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
