﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace hopitalapp
{
    public partial class managdoctors : Form
    {
        SqlConnection conn = new SqlConnection("server=DESKTOP-A99GI3M\\SQLEXPRESS;Database=ho;Connection Timeout=30;Integrated Security=true");

        public managdoctors()
        {
            InitializeComponent();
            SqlDataAdapter ad = new SqlDataAdapter("select * from doctor",conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from doctor where id='" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)+"'",conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("delet succefuly");
            SqlDataAdapter ad = new SqlDataAdapter("select * from doctor", conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            editdoctor f = new editdoctor();
            f.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            f.textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            f.textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            f.textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            f.textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();



            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /**  EXPORT EXCEL   */

            dataGridView1.SelectAll();
            DataObject copydata = dataGridView1.GetClipboardContent();
            if (copydata != null) Clipboard.SetDataObject(copydata);
            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            xlapp.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook xlWbook;
            Microsoft.Office.Interop.Excel.Worksheet xlsheet;
            object miseddata = System.Reflection.Missing.Value;
            xlWbook = xlapp.Workbooks.Add(miseddata);

            xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWbook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlsheet.Cells[1, 1];
            xlr.Select();

            xlsheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
