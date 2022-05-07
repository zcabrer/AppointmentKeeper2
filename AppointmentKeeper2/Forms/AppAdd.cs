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
    public partial class AppAdd : Form
    {

        public AppAdd()
        {
            InitializeComponent();

            pkrType.DataSource = populateType();
            pkrDuration.DataSource = populateDuration();
            pkrDuration.DisplayMember = "Label";
            pkrDuration.ValueMember = "Time";
            pkrCustomer.DataSource = Datatools.customerTable();
            pkrCustomer.DisplayMember = "name";
            pkrCustomer.ValueMember = "ID";
            pkrUser.DataSource = Datatools.userTable();
            pkrUser.DisplayMember = "userName";
            pkrUser.ValueMember = "userId";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            this.Hide();
            main.Show();
        }

        private void AppAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm main = new MainForm();
            this.Hide();
            main.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isNewAppointment = true;
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
            else if (InputValidation.validateAppointmentConflict(appointment.TimeStart, appointment.TimeEnd, consultant, isNewAppointment))
            {
                MessageBox.Show("Another appointment is already scheduled at this time. Please choose another time.");
            }
            else
            {
                bool addAppSuccess = false;

                try
                {
                    Datatools.addAppointment(appointment);
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

        public static List<string> populateType()
        {
            string[] types = { "Scrum", "Presentation", "Scoping", "Closeout", "Reactive" };
            List<string> typeList = new List<string>(types);

            return typeList;
        }
        public class Duration
        {
            public int Time { get; set; }
            public string Label { get; set; }

            public Duration(int time, string label)
            {
                Time = time;
                Label = label;
            }
        }
        public static List<Duration> populateDuration()
        {
            List<Duration> durations = new List<Duration>();
            durations.Add(new Duration(15, "15 minutes"));
            durations.Add(new Duration(30, "30 minutes"));
            durations.Add(new Duration(60, "60 minutes"));

            return durations;

        }
    }
}
