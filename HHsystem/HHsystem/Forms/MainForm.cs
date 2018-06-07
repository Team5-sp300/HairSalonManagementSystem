using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HHsystem
{
    public partial class MainForm : Form
    {
        MySqlDataAdapter adapter;

        public MainForm()
        {
            InitializeComponent();
            FillDataGridView();
        }


        public void populatetable()
        {
            DataTable table = new DataTable();
            adapter.Fill(table);
            bindingSource.DataSource = table;
            dataGridView1.DataSource = bindingSource;
        }

        public void FillDataGridView()
        {
            try
            {
                MySqlConnection conn;
                string command = "SELECT * FROM booking";
                conn = new MySqlConnection("Server=localhost; database=HairSalonDB; UID=root; password=root");
                conn.Open();

                dataGridView1.AutoGenerateColumns = true;

                MySqlCommand cmd = new MySqlCommand(command, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter
                {
                    SelectCommand = cmd
                };

                DataTable table = new DataTable();

                adapter.Fill(table);

                bindingSource.DataSource = table;
                dataGridView1.DataSource = bindingSource;

    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
    }
}
