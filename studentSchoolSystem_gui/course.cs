using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace studentSchoolSystem_gui
{
    public partial class course : Form
    {
        public course()
        {
            InitializeComponent();
        }

        private void studentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.studentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.databaseDataSet1);

        }

        private void course_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet1.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.databaseDataSet1.student);

        }

        private void searchToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.studentTableAdapter.Search(this.databaseDataSet1.student, nameToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idTextBox.Text);
            int selectedIndex = comboBox1.SelectedIndex;

            StudentClass std = new StudentClass();
            std.saveCourseRegistration(id, selectedIndex);

        }
    }
}
