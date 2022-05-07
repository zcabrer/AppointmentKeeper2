using AppointmentKeeper2.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentKeeper2
{
    public partial class LoginForm : Form
    {
        public static bool Exception { get; set; }
        public static string invalidLoginMessage = "Username or Password incorrect";
        public static string exceptionMessage = "A login error has occurred";
        private static bool loginSuccess { get; set; }
        public static int userId;


        public LoginForm()
        {
            InitializeComponent();
            //Check user system settings if Spanish ("es") language is enabled
            languageCheck();
            //Create the log file if it does not exist
            initializeLog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Login();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Login()
        {
            Exception = false;
            userId = Datatools.validateLogin(txtUsername.Text, txtPassword.Text);

            if (userId > 0)
            {
                loginSuccess = true;
                logEntry();
                this.Hide();
                alert();
                MainForm main = new MainForm();
                main.Show();
            }
            else if (Exception)
            {
                loginSuccess = false;
                logEntry();
                MessageBox.Show(exceptionMessage);
            }
            else
            {
                loginSuccess = false;
                logEntry();
                MessageBox.Show(invalidLoginMessage);
                txtPassword.Text = "";
                txtUsername.Text = "";
            }
        }
        private void languageCheck()
        {
            string lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            if (lang == "es")
            {
                this.Text = "Acceso";
                label1.Text = "nombre de\nusuario";
                label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
                label1.Location = new System.Drawing.Point(12, 25);
                label2.Text = "Contraseña";
                btnExit.Text = "Salida";
                btnLogin.Text = "Acceso";
                exceptionMessage = "Se ha producido un error de inicio de sesión";
                invalidLoginMessage = "Usuario o contraseña incorrectos";
            }
        }
        private void initializeLog()
        {
            try
            {
                Logger.initializeLogFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while creating log file: " + ex + "\n\n\n\nExiting Application");
                Application.Exit();
            }
        }
        private void logEntry()
        {
            try
            {
                Logger.writeLog(loginSuccess, txtUsername.Text, DateTime.Now);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing authentication log: " + ex.Message);
            }
        }
        private void alert()
        {

            //query the DB checking for appointments + 15min from current time. If there is an alert, returns single record
            DataTable dt = Datatools.alertCheck(userId);

            //if data table contains a record, show message box
            if (dt.Rows.Count > 0)
            {
                //get the customer using customerID from the appointment
                Modules.CustomerDetails customer = Datatools.getCustomer((int)dt.Rows[0]["customerId"]);
                string customerName = customer.Name;
                //get the appointment start time
                string appointmentTime = dt.Rows[0]["start"].ToString();
                DateTime convert = DateTime.Parse(appointmentTime).ToLocalTime();
                appointmentTime = convert.ToString();

                //display the alert
                MessageBox.Show($"You have an appointment with {customerName} at {appointmentTime}.");

            }

        }
    }
}
