using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TheatreApp
{
    public partial class Form2 : Form
    {

        private SqlConnection sqlConnection = new SqlConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private string currTable;
        private DataTable dataTable = new DataTable();

        public Form2()
        {
            InitializeComponent();
        }

       

        private void Form2_Load(object sender, EventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
        {
            FillDataGrid("ArtDir");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FillDataGrid("Direction");
        }
        private void button9_Click(object sender, EventArgs e)
        {
            FillDataGrid("Groups");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FillDataGrid("Understudies");
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

                for (int i = 1;i<dataGridView1.Columns.Count;i++)
                {
                    DataTable dataTable1 = new DataTable();
                    string cDTStr = $"SELECT SQL_VARIANT_PROPERTY({dataGridView1.Columns[i].HeaderCell.Value.ToString()}, 'BaseType') FROM {currTable}";
                    SqlCommand cDT = new SqlCommand(cDTStr, sqlConnection);
                    adapter.SelectCommand = cDT;
                    adapter.Fill(dataTable1);
                    if(dataTable1.Rows[0][0].ToString() == "date")
                    {
                        //MessageBox.Show("Вошел в дату");
                        for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                        {
                            
                            string prevalue = dataGridView1[i, j].Value.ToString();
                            string[] prevalA = prevalue.Split(' ');  // dd/MM/yyyy HH:mm:s
                            string value = prevalA[0];
                            DateTime res = DateTime.ParseExact(Convert.ToDateTime(value).ToString("yyyy.MM.dd"), "yyyy.MM.dd", CultureInfo.InvariantCulture);
                            //MessageBox.Show(res.ToString("yyyy.MM.dd"));
                            string cUStr = $"UPDATE {currTable} SET {dataGridView1.Columns[i].HeaderCell.Value.ToString()} = '{res.ToString("yyyy.MM.dd")}' WHERE {dataGridView1.Columns[0].HeaderCell.Value.ToString()} = '{dataGridView1[0, j].Value.ToString()}'";
                            SqlCommand upCm = new SqlCommand(cUStr, sqlConnection);
                            upCm.ExecuteNonQuery();

                        }
                        //MessageBox.Show(dataGridView1.Columns[i].HeaderCell.Value.ToString() + " изменен");
                    }

                    else if (dataTable1.Rows[0][0].ToString() == "numeric")
                    {
                        //MessageBox.Show("Вошел в Цену");
                        for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                        {
                            string num = dataGridView1[i, j].Value.ToString();
                            num = num.Replace(",", ".");
                            string cUStr = $"UPDATE {currTable} SET {dataGridView1.Columns[i].HeaderCell.Value.ToString()} = {num} WHERE {dataGridView1.Columns[0].HeaderCell.Value.ToString()} = '{dataGridView1[0, j].Value.ToString()}'";
                            SqlCommand upCm = new SqlCommand(cUStr, sqlConnection);
                            upCm.ExecuteNonQuery();

                        }
                        //MessageBox.Show(dataGridView1.Columns[i].HeaderCell.Value.ToString() + " изменен");
                    }


                    else
                    {
                        //MessageBox.Show("Вошел в обычный");
                        for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                        {

                            string cUStr = $"UPDATE {currTable} SET {dataGridView1.Columns[i].HeaderCell.Value.ToString()} = '{dataGridView1[i, j].Value.ToString()}' WHERE {dataGridView1.Columns[0].HeaderCell.Value.ToString()} = '{dataGridView1[0, j].Value.ToString()}'";
                            SqlCommand upCm = new SqlCommand(cUStr, sqlConnection);
                            upCm.ExecuteNonQuery();

                        }
                        //MessageBox.Show(dataGridView1.Columns[i].HeaderCell.Value.ToString() + " изменен");
                    }
                }
                
                //MessageBox.Show("Update successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            switch (currTable)
            {
                case "Actors":
                    Form3 NewActor = new Form3();
                    NewActor.Show();
                    break;
                case "ArtDir":
                    Form4 NewArtDir = new Form4();
                    NewArtDir.Show();
                    break;
                case "Direction":
                    Form5 NewDir = new Form5();
                    NewDir.Show();
                    break;
                case "Groups":
                    Form6 NewGroup = new Form6();
                    NewGroup.Show();
                    break;
                case "Perfomance":
                    Form7 NewPerf = new Form7();
                    NewPerf.Show();
                    break;
                case "Tickets":
                    Form8 NewTicket = new Form8();
                    NewTicket.Show();
                    break;
                case "Understudies":
                    Form9 NewUnderSt = new Form9();
                    NewUnderSt.Show();
                    break;
                case "Theatre":
                    MessageBox.Show("В эту таблицу нельзя добавлять записи!");
                    break;
                default:
                    MessageBox.Show("Ничего не выбрано!");
                    break;



            }
        }
    }
}
