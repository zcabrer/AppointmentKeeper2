using AppointmentKeeper2.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AppointmentKeeper2.Forms
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();

            pkrType.DataSource = AppAdd.populateType();
            pkrType.SelectedIndex = -1;
            pkrMonth.DataSource = populateMonth();
            pkrMonth.DisplayMember = "MonthName";
            pkrMonth.ValueMember = "MonthNumber";
            pkrMonth.SelectedIndex = -1;
            pkrUser.DataSource = Datatools.userTable();
            pkrUser.DisplayMember = "userName";
            pkrUser.ValueMember = "userId";
            pkrUser.SelectedIndex = -1;
            report3();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            this.Hide();
            main.Show();
        }
        private void ReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm main = new MainForm();
            this.Hide();
            main.Show();
        }
        private void pkrType_DropDownClosed(object sender, EventArgs e)
        {
            if (pkrMonth.SelectedIndex != -1)
            {
                typeByMonth();
            }
        }
        private void pkrMonth_DropDownClosed(object sender, EventArgs e)
        {
            if (pkrType.SelectedIndex != -1)
            {
                typeByMonth();
            }
        }
        private void pkrUser_DropDownClosed(object sender, EventArgs e)
        {
            if (pkrUser.SelectedIndex != -1)
            {
                int value = Convert.ToInt32(pkrUser.SelectedValue);
                DataTable dt = Datatools.appointmentTableByUser(value);
                dgvUserReport.DataSource = dt;
            }
        }


        public class Months
        {
            public int MonthNumber { get; set; }
            public string MonthName { get; set; }

            public Months(int number, string name)
            {
                MonthNumber = number;
                MonthName = name;
            }
        }
        public static List<Months> populateMonth()
        {
            List<Months> months = new List<Months>();
            months.Add(new Months(01, "January"));
            months.Add(new Months(02, "February"));
            months.Add(new Months(03, "March"));
            months.Add(new Months(04, "April"));
            months.Add(new Months(05, "May"));
            months.Add(new Months(06, "June"));
            months.Add(new Months(07, "July"));
            months.Add(new Months(08, "August"));
            months.Add(new Months(09, "September"));
            months.Add(new Months(10, "October"));
            months.Add(new Months(11, "November"));
            months.Add(new Months(12, "December"));
            return months;
        }
        private void typeByMonth()
        {
            int count;

            try
            {
                Datatools.conn.Open();

                string query = "SELECT COUNT(*) FROM appointment WHERE type = @type AND MONTH(start) = @month;";
                MySqlCommand cmd = new MySqlCommand(query, Datatools.conn);
                cmd.Parameters.AddWithValue("@month", pkrMonth.SelectedValue);
                cmd.Parameters.AddWithValue("@type", pkrType.Text);
                Object obj = cmd.ExecuteScalar();
                count = Convert.ToInt32(obj.ToString());

                if (count > 0)
                {
                    lblResult1.Text = count.ToString();
                }
                else
                {
                    lblResult1.Text = "No appointments for this Month";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report\n\n" + ex);
            }
            finally
            {
                Datatools.conn.Close();
            }
        }
        private void report3()
        {
            int count;

            try
            {
                Datatools.conn.Open();

                string query = "SELECT COUNT(*) FROM appointment;";
                MySqlCommand cmd = new MySqlCommand(query, Datatools.conn);
                Object obj = cmd.ExecuteScalar();
                count = Convert.ToInt32(obj.ToString());

                if (count > 0)
                {
                    labelResult2.Text = count.ToString();
                }
                else
                {
                    labelResult2.Text = "No appointments";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating total appointments report\n\n" + ex);
            }
            finally
            {
                Datatools.conn.Close();
            }
        }


    }
}
