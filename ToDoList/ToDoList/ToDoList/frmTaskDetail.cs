using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class frmTaskDetail : Form
    {
        string title, desc;
        DateTime date;
        public frmTaskDetail(string pTitle,DateTime pDate,string pDesc)
        {
            InitializeComponent();
            title = pTitle;
            date = pDate;
            desc = pDesc;
        }

        private void frmTaskDetail_Load(object sender, EventArgs e)
        {
            lblTitle.Text = title;
            lblDate.Text = date.ToShortDateString();
            txtDescription.Text = desc; 
        }
    }
}
