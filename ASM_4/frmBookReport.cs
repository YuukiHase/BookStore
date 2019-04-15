using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM_4
{
    public partial class frmBookReport : Form
    {
        DataTable dtBook;

        public frmBookReport()
        {
            InitializeComponent();
        }

        public frmBookReport(DataTable dataTable) : this()
        {
            dtBook = dataTable;
        }

        private void frmBookReport_Load(object sender, EventArgs e)
        {
            bsBooks.DataSource = dtBook;
            dgvBooks.DataSource = bsBooks;
            bsBooks.Sort = "BookPrice DESC";
        }
    }
}
