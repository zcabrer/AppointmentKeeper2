using AppointmentKeeper2;
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
    public partial class CustAdd : Form
    {
        public CustAdd()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            this.Hide();
            main.Show();
        }

        private void CustAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm main = new MainForm();
            this.Hide();
            main.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;
            string city = txtCity.Text;
            string country = txtCountry.Text;

            if (!InputValidation.validateCustomerInput(name, address, phone, city, country))
            {
                MessageBox.Show("Fields cannot be empty. Please fill all fields");
            }
            else if (!InputValidation.validatePhone(phone))
            {
                MessageBox.Show("Improper phone format. Use format 777-777-7777");
            }
            else if (Datatools.checkDuplicateCustomer(new Modules.CustomerDetails(name, address, phone, city, country)))
            {
                MessageBox.Show("This customer already exists.");
            }
            else
            {
                bool addCustSuccess = false;

                try
                {
                    Datatools.addCustomer(name, address, phone, city, country);
                    addCustSuccess = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving customer:\n\n" + ex);
                }

                if (addCustSuccess)
                {
                    MainForm main = new MainForm();
                    this.Hide();
                    main.Show();
                }
            }

        }
    }
}
