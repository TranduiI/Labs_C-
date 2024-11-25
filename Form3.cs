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
    public partial class Form3 : Form
    {
        private SqlConnection sqlConnection = new SqlConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataTable numGroup = new DataTable();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=""C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\DEKANOVA.MDF"";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            sqlConnection.Open();

            string getNumGroupStr = $"SELECT NumGroup, Name FROM Groups";
            

            SqlCommand getNumGroup = new SqlCommand(getNumGroupStr, sqlConnection);
            

            adapter.SelectCommand = getNumGroup;
            adapter.Fill(numGroup);

            

            comboBox1.DataSource = numGroup;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "NumGroup";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            string numContr = textBox1.Text;
            string numGroupVal = comboBox1.SelectedValue.ToString();
            string actor = textBox3.Text;
            string height = textBox4.Text;
            string weight = textBox5.Text;
            string vac = dateTimePicker1.Text;

            
            string[] prevalA = vac.Split(' ');  // dd/MM/yyyy HH:mm:s
            string vacVal = prevalA[0];
            DateTime resVac = DateTime.ParseExact(Convert.ToDateTime(vacVal).ToString("yyyy.MM.dd"), "yyyy.MM.dd", CultureInfo.InvariantCulture);




            string insC = $"insert into Actors (NumContract, NumGroup, Actor, Height, Weight, VacationDate) values ('{numContr}','{numGroupVal}','{actor}','{height}','{weight}','{resVac.ToString("yyyy.MM.dd")}')";
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
