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
    public partial class frmMaintainBooks : Form
    {
        Form LoginForm;

        BookDAO dao = new BookDAO();

        DataTable dtBook;

        public frmMaintainBooks()
        {
            InitializeComponent();
        }

        public frmMaintainBooks(Form loginForm) : this()
        {
            LoginForm = loginForm;
        }

        private void frmMaintainBooks_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dtBook = dao.getBooks();
            dtBook.PrimaryKey = new DataColumn[] { dtBook.Columns["BookID"] };
            bsBooks.DataSource = dtBook;

            txtBookID.DataBindings.Clear();
            txtBookName.DataBindings.Clear();
            txtBookPrice.DataBindings.Clear();

            txtBookID.DataBindings.Add("Text", bsBooks, "BookID");
            txtBookName.DataBindings.Add("Text", bsBooks, "BookName");
            txtBookPrice.DataBindings.Add("Text", bsBooks, "BookPrice");

            dgvBookList.DataSource = bsBooks;
            bnBookList.BindingSource = bsBooks;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (dtBook.Rows.Count > 0)
            {
                id = int.Parse(dtBook.Compute("MAX(BookID)", "").ToString()) + 1;
            }
            string bookName = txtBookName.Text;
            float bookPrice = float.Parse(txtBookPrice.Text);
            Book book = new Book
            {
                BookID = id,
                BookName = bookName,
                BookPrice = bookPrice,
            };
            bool r = dao.addNewBook(book);
            string s = (r == true ? "successful." : "fail.");
            MessageBox.Show("Add " + s);
            dtBook.Rows.Add(book.BookID, book.BookName, book.BookPrice);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBookID.Text);
            string bookName = txtBookName.Text;
            float bookPrice = float.Parse(txtBookPrice.Text);

            Book book = new Book
            {
                BookID = id,
                BookName = bookName,
                BookPrice = bookPrice,
            };

            bool r = dao.updateBook(book);
            string s = (r == true ? "successful." : "fail.");
            MessageBox.Show("Update " + s);
            DataRow row = dtBook.Rows.Find(book.BookID);
            row["BookName"] = book.BookName;
            row["BookPrice"] = book.BookPrice;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBookID.Text);
            bool r = dao.deleteBook(id);
            string s = (r == true ? "successful" : "fail");
            MessageBox.Show("Delete " + s);
            DataRow row = dtBook.Rows.Find(id);
            dtBook.Rows.Remove(row);
        }

        private void txtTitleFilter_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dtBook.DefaultView;
            string filter = "BookName like '%" + txtNameFilter.Text + "%'";
            dv.RowFilter = filter;
            //Hien thi len label
            lbTotalQuantity.Text = "Total Price:" +
                            dtBook.Compute("SUM(BookPrice)", filter);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmBookReport report = new frmBookReport(dtBook);
            report.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm.Show();
            this.Dispose();
        }
    }
}
