using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace TheatreApp
{
    public partial class Form0 : Form
    {
        private SqlConnection sqlConnection = null;


        DataTable dataTable = null;

        public Form0()
        {
            InitializeComponent();
        }

        private void Form0_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=""C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\DEKANOVA.MDF"";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            sqlConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var pass = textBox2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string cStr = $"SELECT * FROM Users WHERE login = '{login}' AND pass = '{pass}'";

            SqlCommand command = new SqlCommand(cStr, sqlConnection);
            //command.Parameters.Add("@uL", SqlDbType.VarChar).Value = login;

            adapter.SelectCommand = command;
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                
                if (dataTable.Rows[0][2].ToString() == "True")
                {

                    MessageBox.Show("Вы Админ");
                    Form2 form2 = new Form2();
                    sqlConnection.Close();
                    this.Hide();
                    form2.Show();

                }
                else
                {
                    MessageBox.Show("Вы Пользователь");
                    Form1 form1 = new Form1();
                    sqlConnection.Close();
                    this.Hide();
                    form1.Show();
                }

            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!");
                textBox1.Focus();
            }

        }

        

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void Form0_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
