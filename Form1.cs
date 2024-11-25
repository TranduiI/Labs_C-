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
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = new SqlConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private string currTable;
        private DataTable dataTable = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=""C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\DEKANOVA.MDF"";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            sqlConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillDataGrid("Actors");
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            FillDataGrid("Theatre");
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FillDataGrid("Perfomance");
            

        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            FillDataGrid("Tickets");
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Form0 form0 = new Form0();
            sqlConnection.Close();
            this.Hide();
            form0.Show();
        }

        private void FillDataGrid(string BDTable)
        {
            if (dataTable != null)
            {
                dataTable.Clear();
                dataGridView1.Columns.Clear();
            }
            string cStr = $"SELECT * FROM {BDTable}";
            SqlCommand command = new SqlCommand(cStr, sqlConnection);
            adapter.SelectCommand = command;

            dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            currTable = BDTable;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string cUStr = $"UPDATE {currTable}";
                SqlCommand upCm = new SqlCommand(cUStr,sqlConnection);
                adapter.UpdateCommand = upCm;
                adapter.Update(dataTable);
                MessageBox.Show("Update successful");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Update failed");
            }
            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
