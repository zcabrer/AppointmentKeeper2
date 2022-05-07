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
    public partial class AppEdit : Form
    {
        private int appointmentId;

        public AppEdit(int appId)
        {
            InitializeComponent();
            pkrType.DataSource = AppAdd.populateType();
            pkrDuration.DataSource = AppAdd.populateDuration();
            pkrDuration.DisplayMember = "Label";
            pkrDuration.ValueMember = "Time";
            pkrCustomer.DataSource = Datatools.customerTable();
            pkrCustomer.DisplayMember = "name";
            pkrCustomer.ValueMember = "ID";
            pkrUser.DataSource = Datatools.userTable();
            pkrUser.DisplayMember = "userName";
            pkrUser.ValueMember = "userId";

            appointmentId = appId;

            try
            {
                DataTable dt = Datatools.getAppointment(appId);
                pkrType.SelectedIndex = pkrType.FindStringExact((string)dt.Rows[0]["type"]);
                pkrCustomer.SelectedIndex = pkrCustomer.FindStringExact((string)dt.Rows[0]["customer"]);
                pkrUser.SelectedIndex = pkrUser.FindStringExact((string)dt.Rows[0]["user"]);
                DateTime startTime = (DateTime)dt.Rows[0]["start"];
                pkrTime.Value = startTime.ToLocalTime();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving appointment details" + ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            this.Hide();
            main.Show();
        }

        private void AppEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm main = new MainForm();
            this.Hide();
            main.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isNewAppointment = false;
            string type = pkrType.Text;
            string customer = pkrCustomer.Text;
            DateTime startTime = pkrTime.Value.ToUniversalTime();
            DateTime endTime = pkrTime.Value.AddMinutes(Convert.ToInt32(pkrDuration.SelectedValue)).ToUniversalTime();
            string consultant = pkrUser.Text;

            Modules.Appointment appointment = new Modules.Appointment(customer, consultant, type, startTime, endTime);

            if (!InputValidation.validateAppointment(type, customer, consultant))
            {
                MessageBox.Show("Fields cannot be empty. Please fill all fields");
            }
            else if (!InputValidation.validateBusinessHours(appointment.TimeStart, appointment.TimeEnd))
            {
                MessageBox.Show("Appointment time is outside of business hours (08:00 - 17:00 EST)");
            }
            else if (InputValidation.validateAppointmentConflict(appointment.TimeStart, appointment.TimeEnd, consultant, isNewAppointment, appointmentId))
            {
                MessageBox.Show("Another appointment is already scheduled at this time. Please choose another time.");
            }
            else
            {
                bool addAppSuccess = false;

                try
                {
                    Datatools.editAppointment(appointment, appointmentId);
                    addAppSuccess = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving appointment:\n\n" + ex);
                }

                if (addAppSuccess)
                {
                    MainForm main = new MainForm();
                    this.Hide();
                    main.Show();
                }
            }
        }
    }
}
