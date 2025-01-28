using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ContactListManager
{
    public partial class ContactPopup : Form
    {
        internal Contact Contact = null;

        public ContactPopup()
        {
            InitializeComponent();
            if (Contact == null)
            {
                Contact = new Contact();
            }

        }

        public void PopulateField()
        {
  
            this.txtName.Text = Contact.Name;
            this.txtEmail.Text = Contact.Email;
            this.txtPhoneNumber.Text = Contact.PhoneNumber;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close(); 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            Contact.Name = txtName.Text;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            Contact.Email = txtEmail.Text;
        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            Contact.PhoneNumber = txtPhoneNumber.Text;
        }
    }
}
