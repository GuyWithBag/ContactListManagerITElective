using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactListManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadContactsFromCSV();
        }

        private void btnSaveToCSV_Click(object sender, EventArgs e)
        {
            SaveContactsToCSV();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            ContactPopup popup = new ContactPopup(); 
            if (popup.ShowDialog() == DialogResult.OK)
            {
                contacts.Add(popup.Contact);
                UpdateContactGrid();
            }
        }

        private void btnEditContact_Click(object sender, EventArgs e)
        {
            if (dgvContacts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a contact to edit. ");
                return;
            }
            var SelectedContact = (Contact)dgvContacts.SelectedRows[0].DataBoundItem;
            ContactPopup popup = new ContactPopup();
            popup.Contact = SelectedContact;
            popup.PopulateField();

            if (popup.ShowDialog() == DialogResult.OK)
            {
                UpdateContactGrid();
            }
        }

        private void dgvContacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
