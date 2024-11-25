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
    public partial class Form9 : Form
    {
        private SqlConnection sqlConnection = new SqlConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataTable artDirs = new DataTable();

        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=""C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\DEKANOVA.MDF"";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            sqlConnection.Open();

            string getArtDirStr = $"SELECT NumContract, Actor FROM Actors";

            SqlCommand getArtDir = new SqlCommand(getArtDirStr, sqlConnection);

            adapter.SelectCommand = getArtDir;
            adapter.Fill(artDirs);

            comboBox1.DataSource = artDirs;
            comboBox1.DisplayMember = "Actor";
            comboBox1.ValueMember = "NumContract";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            string numContr = comboBox1.SelectedValue.ToString();
            string underStudy = textBox2.Text;
            string height = textBox3.Text;
            string weight = textBox4.Text;

            string insC = $"insert into Understudies (NumContract, Understudy, Height, Weight) values ('{numContr}', '{underStudy}', '{height}', '{weight}')";

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
