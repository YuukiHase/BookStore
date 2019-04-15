using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore;

namespace ASM_4
{
    public partial class frmChangeAccount : Form
    {
        public EmployeeDTO Employee { get; set; }
        Form LoginForm;

        public frmChangeAccount()
        {
            InitializeComponent();
        }

        public frmChangeAccount(EmployeeDTO employee, Form loginForm) : this()
        {
            Employee = employee;
            LoginForm = loginForm;
            InitData();
        }

        private void InitData()
        {
            txtUsername.Text = Employee.EmpID;
            txtRole.Text = Employee.EmpRole.ToString();
        }

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            EmployeeDAO dao = new EmployeeDAO();
            CheckMD5 md5 = new CheckMD5();
            if (txtPassword.Text.Length < 2 || txtPassword.Text.Length > 15)
            {
                MessageBox.Show("Password require 2 - 15 characters.");
            }
            else
            {
                bool r = dao.ChagePassword(Employee.EmpID, md5.CreateMD5(txtPassword.Text));
                if (r == true)
                {
                    MessageBox.Show("Save successful.");
                }
                else
                {
                    MessageBox.Show("Save fail.");
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm.Show();
            this.Dispose();
        }
    }
}
