using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        BindingSource customersBindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            // Add columns to the DataGridView
            dgvData.Columns.Add("Id", "Id");
            dgvData.Columns.Add("Name", "Name");

            // add button in datagridview c#
            // Add a button column
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Action";
            buttonColumn.Text = "Delete";
            buttonColumn.UseColumnTextForButtonValue = true; // Set to true to use Text property for the button
            dgvData.Columns.Add(buttonColumn);

            // Sample data
            dgvData.Rows.Add(1, "John");
            dgvData.Rows.Add(2, "Alice");
            dgvData.Rows.Add(3, "Bob");
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check deleted rows
            if (dgvData.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Are you sure want to delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    customersBindingSource.RemoveCurrent();
            }

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            // Subscribe to the CellClick event
            dgvData.CellClick += dgvData_CellClick;
            //Init data
            customersBindingSource.Add(new Customers() { CustomerID = "1", CustomerName = "Maria Anders", Email = "maria@gmail.com", Address = "Obere Str. 57" });
            customersBindingSource.Add(new Customers() { CustomerID = "2", CustomerName = "Ana Trujillo", Email = "ana171@gmail.com", Address = "Avada. de la Cons" });
            customersBindingSource.Add(new Customers() { CustomerID = "3", CustomerName = "Thomas Hardy", Email = "thomad@gmail.com", Address = "120 Hanover Sq." });
            customersBindingSource.Add(new Customers() { CustomerID = "4", CustomerName = "Elizabeth Liconln", Email = "elizabeth@gmail.com", Address = "23 Tsawassen" });
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is a button cell and its column index is the button column
            if (e.ColumnIndex == dgvData.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                // You can perform actions based on the row clicked
                MessageBox.Show($"Button clicked in row {e.RowIndex}");
            }
        }

        private void dgvData_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_ChangeUICues(object sender, UICuesEventArgs e)
        {
            //123
        }
    }

    public class Customers
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}

