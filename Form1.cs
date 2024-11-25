using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace TheatreAppCurs
{

    public partial class Form1 : Form
    {
        public string currenTable;
        private string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Dekanova.mdf"";Integrated Security=True;Connect Timeout=30";
        public Form1()
        {
            InitializeComponent();
            currenTable = "actor";
            LoadCombo(Perf.QuaryPerf.quarySelectAllForCombo, "NumPerf", "Name", comboBox1);
            LoadData(Actor.QuaryActor.quarySelectAllActor, dataGridView1);
            
        }

        public void LoadData(string q, DataGridView dgv)
        {
            try
            {
                SqlConnection myCon = new SqlConnection(conString);
                myCon.Open();
                SqlCommand cmd = new SqlCommand(q, myCon);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgv.DataSource = dt;
                this.ActiveControl = dgv;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (dgv.Rows.Count > 0)
                {
                    dgv.Rows[0].Selected = true;
                }
                myCon.Close();
                ChoseSelectedGBox(currenTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadCombo(string q, string value, string display, ComboBox box)
        {
            try
            {
                SqlConnection myCon = new SqlConnection(conString);
                myCon.Open();
                SqlCommand cmd = new SqlCommand(q, myCon);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                box.DataSource = dt;
                box.DisplayMember = display;
                box.ValueMember = value;
                myCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    switch (currenTable)
                    {
                        case "actor":
                            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                            new Actor(Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())).GetPerfs(conString, listBox1);
                            break;
                        case "artdir":
                            textBox3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                            textBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                            dateTimePicker2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                            break;
                        case "perf":
                            Perf pf = new Perf(Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                            textBox5.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                            textBox6.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                            comboBox2.SelectedValue = pf.getNumDirection(conString);
                            comboBox3.SelectedValue = pf.getArtDir(conString);
                            break;
                        case "tickets":
                            textBox14.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                            textBox15.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                            textBox16.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                            comboBox5.SelectedValue = new Tickets(Int32.Parse(textBox14.Text)).getNumPerf(conString);
                            dateTimePicker5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                            break;
                        case "theatres":
                            textBox9.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                            textBox10.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                            textBox11.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                            textBox12.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

                            comboBox4.SelectedValue = new Theatres(Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())).getNumDirection(conString);
                            
                            break;
                        case "directions":
                            textBox7.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                            textBox8.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                            break;
                        default:
                            
                            break;
                    }
                }
            }
        }
        private void OpenActor_Click(object sender, EventArgs e)
        {
            currenTable = "actor";
            dataGridView1.DataSource = null;
            LoadCombo(Perf.QuaryPerf.quarySelectAllForCombo, "NumPerf", "Name", comboBox1);
            LoadData(Actor.QuaryActor.quarySelectAllActor, dataGridView1);
            
        }
        public void ActorAddBut_Click(object sender, EventArgs e)
        {          
            new Actor(textBox2.Text, dateTimePicker1.Value).InsertActor(conString);
            dataGridView1.DataSource = null;
            LoadData(Actor.QuaryActor.quarySelectAllActor, dataGridView1);
        }  

        public void ActorSaveBut_Click(object sender, EventArgs e)
        {
            new Actor(textBox2.Text, dateTimePicker1.Value).UpdateActor(conString, Int32.Parse(textBox1.Text));
            dataGridView1.DataSource = null;
            LoadData(Actor.QuaryActor.quarySelectAllActor, dataGridView1);
        }

        public void ActorDeleteBut_Click(object sender, EventArgs e)
        {
            new Actor(Int32.Parse(textBox1.Text)).DeleteActor(conString );
            dataGridView1.DataSource = null;
            LoadData(Actor.QuaryActor.quarySelectAllActor, dataGridView1);
        }

        public void DeleteActorFromPerf_Click(object sender, EventArgs e)
        {
            Actor actor = new Actor(Int32.Parse(textBox1.Text));
            actor.DeleteFromPerf(conString, Int32.Parse(listBox1.SelectedValue.ToString()));
            actor.GetPerfs(conString, listBox1);
            dataGridView1.DataSource = null;
            LoadData(Actor.QuaryActor.quarySelectAllActor, dataGridView1);
        }

        private void AddPerfToActor_Click(object sender, EventArgs e)
        {
            
            Actor actor = new Actor(Int32.Parse(textBox1.Text));             
            actor.InsertIntoPerf(conString, Int32.Parse(comboBox1.SelectedValue.ToString()));
            actor.GetPerfs(conString, listBox1);
            dataGridView1.DataSource = null;
            LoadData(Actor.QuaryActor.quarySelectAllActor, dataGridView1);
            
        }
        
        private void OpenArtDir_Click(object sender, EventArgs e)
        {
            currenTable = "artdir";
            dataGridView1.DataSource = null;
            LoadData(ArtDir.QuaryArtDir.quarySelectAllArtDir, dataGridView1);

        }


        private void AddArtDirBut_Click(object sender, EventArgs e)
        {
            new ArtDir(textBox4.Text, dateTimePicker2.Value).InsertArtDir(conString);
            dataGridView1.DataSource = null;
            LoadData(ArtDir.QuaryArtDir.quarySelectAllArtDir, dataGridView1);
        }

        private void ArtDirSaveBut_Click(object sender, EventArgs e)
        {
            new ArtDir(textBox4.Text, dateTimePicker2.Value).UpdateArtDir(conString, Int32.Parse(textBox3.Text));
            dataGridView1.DataSource = null;
            LoadData(ArtDir.QuaryArtDir.quarySelectAllArtDir, dataGridView1);
        }

        private void ArtDirDeleteBut_Click(object sender, EventArgs e)
        {
            new ArtDir(Int32.Parse(textBox3.Text)).DeleteArtDir(conString);
            dataGridView1.DataSource = null;
            LoadData(ArtDir.QuaryArtDir.quarySelectAllArtDir, dataGridView1);
            
        }

        private void OpenPerf_Click(object sender, EventArgs e)
        {
            currenTable = "perf";
            dataGridView1.DataSource = null;
            LoadCombo(Directions.QuaryDirections.quarySelectAllDirections, "NumDirection", "Name", comboBox2);
            LoadCombo(ArtDir.QuaryArtDir.quarySelectAllArtDir, "IDArtDir", "Name", comboBox3);
            LoadData(Perf.QuaryPerf.quarySelectAllPerfs, dataGridView1);
            

        }

        private void PerfAddBut_Click(object sender, EventArgs e)
        {
            new Perf(Int32.Parse(comboBox3.SelectedValue.ToString()), Int32.Parse(comboBox2.SelectedValue.ToString()), textBox6.Text).InsertPerf(conString);
            dataGridView1.DataSource = null;
            LoadData(Perf.QuaryPerf.quarySelectAllPerfs, dataGridView1);
        }

        private void PerfSaveBut_Click(object sender, EventArgs e)
        {
            new Perf(Int32.Parse(comboBox3.SelectedValue.ToString()), Int32.Parse(comboBox2.SelectedValue.ToString()), textBox6.Text).UpdatePerf(conString, Int32.Parse(textBox5.Text));
            dataGridView1.DataSource = null;
            LoadData(Perf.QuaryPerf.quarySelectAllPerfs, dataGridView1);

        }

        private void PerfDelBut_Click(object sender, EventArgs e)
        {
            new Perf(Int32.Parse(textBox5.Text)).DeletePerf(conString);
            dataGridView1.DataSource = null;
            LoadData(Perf.QuaryPerf.quarySelectAllPerfs, dataGridView1);

        }
        private void OpenDirections_Click(object sender, EventArgs e)
        {
            currenTable = "directions";
            dataGridView1.DataSource = null;
            
            LoadData(Directions.QuaryDirections.quarySelectAllDirWithID, dataGridView1);
        }

        private void DirectionAddBut_Click(object sender, EventArgs e)
        {
            new Directions(textBox8.Text).InsertDirection(conString);
            dataGridView1.DataSource = null;
            LoadData(Directions.QuaryDirections.quarySelectAllDirections, dataGridView1);

        }

        private void DirectionSaveBut_Click(object sender, EventArgs e)
        {
            new Directions(textBox8.Text).UpdateDirection(conString, Int32.Parse(textBox7.Text));
            dataGridView1.DataSource = null;
            LoadData(Directions.QuaryDirections.quarySelectAllDirections, dataGridView1);

        }

        private void DirectionDel_Click(object sender, EventArgs e)
        {
            new Directions(Int32.Parse(textBox7.Text)).DeleteDirection(conString);
            dataGridView1.DataSource = null;
            LoadData(Directions.QuaryDirections.quarySelectAllDirections, dataGridView1);
        }


        private void OpenTheatres_Click(object sender, EventArgs e)
        {
            currenTable = "theatres";
            dataGridView1.DataSource = null;
            LoadCombo(Directions.QuaryDirections.quarySelectAllDirections, "NumDirection", "Name", comboBox4);
            LoadData(Theatres.QuaryTheatres.quarySelectAllTheatres, dataGridView1);
            


        }
        private void TheatreAddBut_Click(object sender, EventArgs e)
        {
            new Theatres(textBox10.Text, textBox11.Text, textBox12.Text, Int32.Parse(comboBox4.SelectedValue.ToString())).InsertTheatre(conString);
            dataGridView1.DataSource = null;
            LoadData(Theatres.QuaryTheatres.quarySelectAllTheatres, dataGridView1);

        }
        private void TheatreSaveBut_Click(object sender, EventArgs e)
        {
            new Theatres(textBox10.Text, textBox11.Text, textBox12.Text, Int32.Parse(comboBox4.SelectedValue.ToString())).UpdateTheatre(conString, Int32.Parse(textBox9.Text));
            dataGridView1.DataSource = null;
            LoadData(Theatres.QuaryTheatres.quarySelectAllTheatres, dataGridView1);
        }

        private void TheatreDelBut_Click(object sender, EventArgs e)
        {
            new Theatres(Int32.Parse(textBox9.Text)).DeleteTheatre(conString);
            dataGridView1.DataSource = null;
            LoadData(Theatres.QuaryTheatres.quarySelectAllTheatres, dataGridView1);
        }



        private void OpenTickets_Click(object sender, EventArgs e)
        {
            currenTable = "tickets";
            dataGridView1.DataSource = null;
            LoadCombo(Perf.QuaryPerf.quarySelectAllForCombo, "NumPerf", "Name", comboBox5);
            LoadData(Tickets.QuaryTickets.quarySelectAllTickets, dataGridView1);


        }
        private void TicketAddBut_Click(object sender, EventArgs e)
        {
            new Tickets(Int32.Parse(textBox15.Text), float.Parse(textBox16.Text), Int32.Parse(comboBox5.SelectedValue.ToString()), dateTimePicker5.Value).InsertTicket(conString);
            dataGridView1.DataSource = null;
            LoadData(Tickets.QuaryTickets.quarySelectAllTickets, dataGridView1);
        }
        private void TicketSaveBut_Click(object sender, EventArgs e)
        {
            new Tickets(Int32.Parse(textBox15.Text), float.Parse(textBox16.Text), Int32.Parse(comboBox5.SelectedValue.ToString()), dateTimePicker5.Value).UpdateTicket(conString, Int32.Parse(textBox14.Text));
            dataGridView1.DataSource = null;
            LoadData(Tickets.QuaryTickets.quarySelectAllTickets, dataGridView1);
        }

        private void TicketDelBut_Click(object sender, EventArgs e)
        {
            new Tickets(Int32.Parse(textBox14.Text)).DeleteTicket(conString);
            dataGridView1.DataSource = null;
            LoadData(Tickets.QuaryTickets.quarySelectAllTickets, dataGridView1);
        }

        private void Search_Click(object sender, EventArgs e)
        {
            currenTable = "search";
            dataGridView1.DataSource = null;
            ChoseSelectedGBox(currenTable);
        }

        private void SearchBut_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            switch (comboBox6.SelectedIndex)
            {

                case 0:
                    new Search(Int32.Parse(comboBox7.SelectedValue.ToString())).SelectPerfByActor(conString, dataGridView1);
                    break;
                case 1:
                    new Search(Int32.Parse(comboBox7.SelectedValue.ToString())).SelectPerfByTheatre(conString, dataGridView1);
                    break;
                case 2:
                    new Search(textBox13.Text.ToString()).SelectPerfByArtDirSecName(conString, dataGridView1);

                    break;
                case 3:
                    new Search(dateTimePicker4.Value, checkBox1.Checked).SelectPerfByDate(conString, dataGridView1);
                    break;
                case 4:
                    new Search(dateTimePicker4.Value).SelectPerfByTicketPrice(conString, dataGridView1);
                    break;

            }
        }

        private void ChoseSelectedGBox(string curTable)
        {
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            groupBox5.Hide();
            groupBox6.Hide();
            groupBox7.Hide();

            switch (curTable)
            {
                case "actor":
                    groupBox1.Show();
                    break;
                case "artdir":
                    groupBox2.Show();
                    break;
                case "perf":
                    groupBox3.Show();
                    break;
                case "directions":
                    groupBox4.Show();
                    break;
                case "theatres":
                    groupBox5.Show();
                    break;
                case "tickets":
                    groupBox6.Show();
                    break;
                case "search":
                    groupBox7.Show();
                    break;

                default:
                    MessageBox.Show("Не выбрана таблица");
                    break;
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox7.Enabled = false;
            dateTimePicker4.Enabled = false;
            textBox13.Enabled = false;
            checkBox1.Enabled = false;

            switch (comboBox6.SelectedIndex)
            {
                case 0:
                    LoadCombo(Actor.QuaryActor.quarySelectAllActorForCombo, "IDActor", "Name", comboBox7);
                    comboBox7.Enabled = true;
                    break;
                case 1:
                    LoadCombo(Theatres.QuaryTheatres.quarySelectAllTheatresForCombo, "ID", "Name", comboBox7);
                    comboBox7.Enabled = true;
                    break;
                case 2:
                    textBox13.Enabled = true;
                    break;
                case 3:
                    dateTimePicker4.Enabled = true;
                    checkBox1.Enabled = true;
                    break;
                case 4:
                    dateTimePicker4.Enabled = true;
                    break;
            }
        }

        
    }
}
