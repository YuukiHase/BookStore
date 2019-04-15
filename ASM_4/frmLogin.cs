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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string password = txtPassword.Text;

            EmployeeDAO dao = new EmployeeDAO();
            EmployeeDTO dto = dao.CheckLogin(userName, password);
            if (dto != null && dto.EmpRole == false)
            {
                frmChangeAccount changeAccountForm = new frmChangeAccount(dto, this);
                this.Hide();
                changeAccountForm.Show();
                changeAccountForm.FormClosed += Main_Closed;
            }
            else if (dto != null && dto.EmpRole == true)
            {
                frmMaintainBooks booksForm = new frmMaintainBooks(this);
                this.Hide();
                booksForm.Show();
                booksForm.FormClosed += Main_Closed;
            }
        }

        private void Main_Closed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
