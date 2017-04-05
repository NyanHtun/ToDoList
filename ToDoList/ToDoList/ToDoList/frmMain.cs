using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ToDoList
{
    public partial class frmMain : Form
    {
        DataBase db = new DataBase();
        string status = "new";
        int selectedId;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            loadTasks();
        }

        private void loadTasks()
        {
            string proc = "GET_Tasks_001";
            DataTable tbl = db.getDataTable(proc, true);
            
            dgvToDo.DataSource = tbl;
            dgvToDo.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (status == "new")
            {
                string title = txtTitle.Text;
                DateTime date = dtpDate.Value;
                string desc = txtDesc.Text;

                string proc = "INS_Tasks_001";
                SqlParameter p01 = new SqlParameter("title", title);
                SqlParameter p02 = new SqlParameter("date", date);
                SqlParameter p03 = new SqlParameter("description", desc);

                db.executeCommand(proc, true, p01, p02, p03);

                loadTasks();
            }
            else
            {
                string proc = "upd_Tasks_001";
                SqlParameter p00 = new SqlParameter("id", selectedId);
                SqlParameter p01 = new SqlParameter("title", txtTitle.Text);
                SqlParameter p02 = new SqlParameter("date", dtpDate.Value);
                SqlParameter p03 = new SqlParameter("description", txtDesc.Text);

                db.executeCommand(proc, true, p00, p01, p02, p03);

                loadTasks();
                status = "new";
                btnSubmit.Text = "Add";
                dgvToDo.Enabled = true;
                txtTitle.Clear();
                txtDesc.Clear();
            }

            


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            status = "upd";
            btnSubmit.Text = "Save";
            dgvToDo.Enabled = false;
            selectedId = Convert.ToInt32(dgvToDo.SelectedRows[0].Cells[0].Value);
            string title = dgvToDo.SelectedRows[0].Cells[1].Value.ToString();
            DateTime date = DateTime.Parse(dgvToDo.SelectedRows[0].Cells[2].Value.ToString());
            string desc = dgvToDo.SelectedRows[0].Cells[3].Value.ToString();

            txtTitle.Text = title;
            txtDesc.Text = desc;
            dtpDate.Value = date;


            
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgvToDo.Enabled = true;
            btnSubmit.Text = "Add";
            txtDesc.Clear();
            txtTitle.Clear();
        }

        private void btnMarkDone_Click(object sender, EventArgs e)
        {
            string proc;
            if (Convert.ToBoolean(dgvToDo.SelectedRows[0].Cells[4].Value) == true)
            {
                proc = "upd_Tasks_003";
            }
            else
            {
                proc = "upd_Tasks_002";
            }

            
            SqlParameter p00 = new SqlParameter("id", Convert.ToInt32(dgvToDo.SelectedRows[0].Cells[0].Value));


            db.executeCommand(proc, true, p00);

            loadTasks();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvToDo.SelectedRows[0].Cells[0].Value);
            string proc = "DEL_Tasks_001";
            SqlParameter p00 = new SqlParameter("id", id);
            db.executeCommand(proc, true, p00);

            loadTasks();

        }

        private void dgvToDo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (rowIndex != -1)
            {
                string title = dgvToDo.Rows[rowIndex].Cells[1].Value.ToString();
                DateTime date = DateTime.Parse(dgvToDo.Rows[rowIndex].Cells[2].Value.ToString());
                string desc = dgvToDo.Rows[rowIndex].Cells[3].Value.ToString();

                frmTaskDetail frmTaskDetail = new frmTaskDetail(title, date, desc);
                frmTaskDetail.ShowDialog();
            }

        }
    }
}
