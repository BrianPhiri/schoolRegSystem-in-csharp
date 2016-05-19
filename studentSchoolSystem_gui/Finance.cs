using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace studentSchoolSystem_gui
{
    public partial class Finance : Form
    {
        public Finance()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void submit_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\School\BIF\Year3\Sem1\dotNET\classwork\studentSchoolSystem_gui\studentSchoolSystem_gui\Database.mdf;Integrated Security=True"))
            {/*
                SqlCommand sc = new SqlCommand("INSERT INTO [testtable] (dataInput) values(@dataInput)", conn);
                conn.Open();
                sc.Parameters.AddWithValue("@dataInput", textBox1.Text);
                sc.ExecuteNonQuery();
                conn.Close(); */
            }
        }

        private void financeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.financeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.databaseDataSet2);

        }

        private void financeBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.financeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.databaseDataSet2);

        }

        private void Finance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet2.finance' table. You can move, or remove it, as needed.
            this.financeTableAdapter.Fill(this.databaseDataSet2.finance);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(student_idTextBox.Text);
            double amount = Convert.ToDouble(textBox1.Text);
            StudentClass std = new StudentClass();
            std.paySchoolFees(id, amount);
        }
    }
}
