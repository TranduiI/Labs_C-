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
    public partial class Form8 : Form
    {
        private SqlConnection sqlConnection = new SqlConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataTable perfs = new DataTable();
        private DataTable numTick = new DataTable();

        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=""C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\DEKANOVA.MDF"";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            sqlConnection.Open();

            string getPerfsStr = $"SELECT NumPerf, Name FROM Perfomance";

            SqlCommand getPerfs = new SqlCommand(getPerfsStr, sqlConnection);

            adapter.SelectCommand = getPerfs;
            adapter.Fill(perfs);

            comboBox1.DataSource = perfs;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "NumPerf";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string price = textBox1.Text;
            string quantity = textBox2.Text;
            string numPerf = comboBox1.SelectedValue.ToString();

            string cNumStr = $"SELECT TOP 1 NumPerf FROM Perfomance ORDER BY NumPerf DESC";
            SqlCommand cDT = new SqlCommand(cNumStr, sqlConnection);
            adapter.SelectCommand = cDT;
            adapter.Fill(numTick);

            int numT = Convert.ToInt32(numTick.Rows[0][0].ToString()) + 1;

            string insC = $"insert into Tickets (NumTicket, NumPerf, Price, Quantity) values ('{numT}', '{numPerf}', '{price}', '{quantity}')";
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
