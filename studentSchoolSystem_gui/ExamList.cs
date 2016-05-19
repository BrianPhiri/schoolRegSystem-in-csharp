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
    public partial class ExamList : Form
    {
        public ExamList()
        {
            InitializeComponent();
        }

        private void ExamList_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\School\BIF\Year3\Sem1\dotNET\classwork\studentSchoolSystem_gui\studentSchoolSystem_gui\Database.mdf;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT student.id, student.names, course.course from [student] JOIN [finance] ON student.id = finance.student_id JOIN [course] ON student.id = course.student_id WHERE finance.money_owed = 1", con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        using (DataTable dt = new DataTable())
                        {

                            sda.Fill(dt);

                            dataGridView1.DataSource = dt;

                        }

                    }
                }
            }
        }
    }
}
