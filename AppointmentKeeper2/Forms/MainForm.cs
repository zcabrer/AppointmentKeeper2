using AppointmentKeeper2.Forms;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            buildCustomerTable();
            buildAppointmentTable();
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportForm report = new ReportForm();
            this.Hide();
            report.Show();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnAppAdd_Click(object sender, EventArgs e)
        {
            AppAdd add = new AppAdd();
            this.Hide();
            add.Show();
        }
        private void btnCustAdd_Click(object sender, EventArgs e)
        {
            CustAdd add = new CustAdd();
            this.Hide();
            add.Show();
        }

        private void btnCustDelete_Click(object sender, EventArgs e)
        {
            int customerId = Convert.ToInt32(dgvCustomers.Rows[dgvCustomers.CurrentCell.RowIndex].Cells[0].Value);

            if (customerId > 0)
            {
                try
                {
                    Datatools.deleteCustomer(customerId);
                    buildCustomerTable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error when attempting to delete customer: \n\n" + ex);
                }

            }
            else
            {
                MessageBox.Show("Select a Customer to Delete");
            }
        }
        private void btnAppDelete_Click(object sender, EventArgs e)
        {
            int appId = Convert.ToInt32(dgvAppointments.Rows[dgvAppointments.CurrentCell.RowIndex].Cells[0].Value);

            if (appId > 0)
            {
                try
                {
                    Datatools.deleteAppointment(appId);
                    buildAppointmentTable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error when attempting to delete appointment: \n\n" + ex);
                }

            }
            else
            {
                MessageBox.Show("Select an Appointment to Delete");
            }
        }
        private void btnCustEdit_Click(object sender, EventArgs e)
        {
            int customerId = Convert.ToInt32(dgvCustomers.Rows[dgvCustomers.CurrentCell.RowIndex].Cells[0].Value);

            if (customerId > 0)
            {
                CustEdit edit = new CustEdit(customerId);
                this.Hide();
                edit.Show();
            }
            else
            {
                MessageBox.Show("Select a Customer to Edit");
            }
        }
        private void btnAppEdit_Click(object sender, EventArgs e)
        {
            int appId = Convert.ToInt32(dgvAppointments.Rows[dgvAppointments.CurrentCell.RowIndex].Cells[0].Value);
            DateTime startTime = (DateTime)dgvAppointments.Rows[dgvAppointments.CurrentCell.RowIndex].Cells[4].Value;

            if (appId > 0 && startTime > DateTime.Now)
            {
                AppEdit edit = new AppEdit(appId);
                this.Hide();
                edit.Show();
            }
            else
            {
                MessageBox.Show("Select an Appointment. Note: Cannot edit an appointment that has already passed. You will need to schedule a new appointment.");
            }
        }
        private void rdoAll_CheckedChanged(object sender, EventArgs e)
        {
            buildAppointmentTable();
        }
        private void rdoWeek_CheckedChanged(object sender, EventArgs e)
        {
            weekView();
        }
        private void rdoMonth_CheckedChanged(object sender, EventArgs e)
        {
            monthView();
        }
        private void buildCustomerTable()
        {
            try
            {
                dgvCustomers.DataSource = Datatools.customerTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting Customer data: " + ex.Message);
            }
        }
        private void buildAppointmentTable()
        {
            try
            {
                dgvAppointments.DataSource = Datatools.getAppointmentTable(Datatools.allAppointmentsQuery);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting Appointment data: " + ex.Message);
            }
        }
        private void weekView()
        {
            try
            {
                dgvAppointments.DataSource = Datatools.getAppointmentTable(Datatools.weeklyAppointmentsQuery);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting weekly Appointment data: " + ex.Message);
            }
        }
        private void monthView()
        {
            try
            {
                dgvAppointments.DataSource = Datatools.getAppointmentTable(Datatools.monthlyAppointmentsQuery);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting monthly Appointment data: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(System.String.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Enter a customer name in the search field");
            }
            else
            {
                dgvCustomers.DataSource = Datatools.searchCustomer(txtSearch.Text);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            buildCustomerTable();
        }
    }
}
