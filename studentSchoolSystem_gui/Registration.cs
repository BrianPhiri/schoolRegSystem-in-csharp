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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = namesTextBox.Text;
            string telno = telNoTextBox.Text;
            StudentClass stc = new StudentClass();
            stc.saveRegisterdStudent( name , telno);
        }

        private void studentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.studentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.databaseDataSet1);

        }

        private void Registration_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet1.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.databaseDataSet1.student);

        }
    }
}
