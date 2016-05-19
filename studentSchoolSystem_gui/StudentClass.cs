using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace studentSchoolSystem_gui
{
    
    class StudentClass
    {
        private string courseName;
        private double fees;
        private string dbcon = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\School\BIF\Year3\Sem1\dotNET\classwork\studentSchoolSystem_gui\studentSchoolSystem_gui\Database.mdf;Integrated Security=True";
        
        //create insert function for Reg students
        internal void saveRegisterdStudent(string names, string telno ){

            using( SqlConnection sc = new SqlConnection(dbcon)){
                SqlCommand com = new SqlCommand("INSERT INTO [student](names, telNo) VALUES(@name, @telno)", sc);
                sc.Open();
                com.Parameters.AddWithValue("@name", names);
                com.Parameters.AddWithValue("@telno", telno);
                com.ExecuteNonQuery();
                sc.Close();
            }

        }

        //create insert function for course registration.
        internal void saveCourseRegistration( int id, int courseIndex) {
            

            if (courseIndex == 0)
            {
                this.courseName = "BIF";
                this.fees = 200000.00;

                

            } else if (courseIndex == 1)
            {
                this.courseName = "BTC";
                this.fees = 250000.00;

            }
            else if (courseIndex == 2)
            {
                this.courseName = "BBIT";
                this.fees = 260000.30;

            }

            //quary to find match in db
            using (SqlConnection sc = new SqlConnection(dbcon))
            {
                
                SqlCommand ck = new SqlCommand("SELECT Count(*) FROM [course] where id = '"+id+"'", sc);
                
                sc.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(ck);
                da.Fill(ds);
                sc.Close();
                
                bool pressent = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                if (!pressent)
                {
                    MessageBox.Show("Nigga is in the table");
                }
                else
                {
                    SqlCommand sub = new SqlCommand("INSERT INTO [course] (student_id, course) VALUES(@student, @course)", sc);
                    sc.Open();
                    sub.Parameters.AddWithValue("student", id);
                    sub.Parameters.AddWithValue("course", this.courseName);
                    sub.ExecuteNonQuery();
                    sc.Close();

                    SqlCommand fin = new SqlCommand("INSERT INTO [finance] (student_id, money_owed, school_fees) VALUES(@student, @owed, @fees)", sc);
                    sc.Open();
                    fin.Parameters.AddWithValue("student", id);
                    fin.Parameters.AddWithValue("owed", this.fees);
                    fin.Parameters.AddWithValue("fees", this.fees);
                    fin.ExecuteNonQuery();
                    sc.Close();
                }
            }
            //MessageBox.Show("Course " + this.courseName + " fees = " + this.fees);
        }

        //create function for fee payments
        internal void paySchoolFees(int id, double money){
            using(SqlConnection sc = new SqlConnection(dbcon)){
                //get the current money owed
                SqlCommand getBal = new SqlCommand("SELECT money_owed FROM [finance] WHERE student_id = '" + id+ "'", sc);
                sc.Open();
                string balString = getBal.ExecuteScalar().ToString();
                double bal = Convert.ToDouble(balString);
                sc.Close();
                //find new balance
                bal = bal - money;
                //update the money owed in the table
                SqlCommand pay = new SqlCommand("UPDATE [finance] SET (money_owed = @bal) WHERE student = @student", sc);
                sc.Open();
                pay.Parameters.AddWithValue("bal", bal);
                pay.Parameters.AddWithValue("student", id);
                pay.ExecuteNonQuery();
                sc.Close();
            }
        }

        //create function for  student exams.


    }
}
