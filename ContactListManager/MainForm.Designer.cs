
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ContactListManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private List<Contact> contacts = new List<Contact>();
        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void LoadContactsFromCSV()
        {
            if (!File.Exists("contacts.csv"))
            {
                File.WriteAllText("contacts.csv", "Name, Email, Phone Number");
            }
            string[] lines = File.ReadAllLines("contacts.csv");
            
            foreach (string line in lines.Skip(1))
            {
                var parts = line.Split(',');
                contacts.Add(new Contact
                    {
                        Name = parts[0],
                        Email = parts[1], 
                        PhoneNumber = parts[2]
                    }
                );
                
            }


            UpdateContactGrid();
        }

        private void UpdateContactGrid()
        {
            dgvContacts.DataSource = null;
            dgvContacts.DataSource = contacts;
        }


        private System.Windows.Forms.DataGridView dgvContacts;
        private System.Windows.Forms.Button btnAddContact;
        private Button btnEditContact;
        private Button btnSaveToCSV;

        private void SaveContactsToCSV()
        {
            var lines = new List<string> { "Name,Email,Phone Number" };
            foreach (var contact in contacts)
            {
                lines.Add($"{contact.Name}, {contact.Email}, {contact.PhoneNumber}");
            }
            
            File.WriteAllLines("contacts.csv", lines);
            MessageBox.Show("Contacts saved successfully!");
        }



        #region Windows Form Designer generated code


        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvContacts = new System.Windows.Forms.DataGridView();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.btnEditContact = new System.Windows.Forms.Button();
            this.btnSaveToCSV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvContacts
            // 
            this.dgvContacts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContacts.Location = new System.Drawing.Point(27, 35);
            this.dgvContacts.Name = "dgvContacts";
            this.dgvContacts.RowTemplate.Height = 25;
            this.dgvContacts.Size = new System.Drawing.Size(240, 150);
            this.dgvContacts.TabIndex = 0;
            this.dgvContacts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContacts_CellContentClick);
            // 
            // btnAddContact
            // 
            this.btnAddContact.Location = new System.Drawing.Point(27, 213);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(108, 23);
            this.btnAddContact.TabIndex = 1;
            this.btnAddContact.Text = "Add Contact";
            this.btnAddContact.UseVisualStyleBackColor = true;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // btnEditContact
            // 
            this.btnEditContact.Location = new System.Drawing.Point(141, 213);
            this.btnEditContact.Name = "btnEditContact";
            this.btnEditContact.Size = new System.Drawing.Size(108, 23);
            this.btnEditContact.TabIndex = 2;
            this.btnEditContact.Text = "Edit Contact";
            this.btnEditContact.UseVisualStyleBackColor = true;
            this.btnEditContact.Click += new System.EventHandler(this.btnEditContact_Click);
            // 
            // btnSaveToCSV
            // 
            this.btnSaveToCSV.Location = new System.Drawing.Point(255, 213);
            this.btnSaveToCSV.Name = "btnSaveToCSV";
            this.btnSaveToCSV.Size = new System.Drawing.Size(108, 23);
            this.btnSaveToCSV.TabIndex = 3;
            this.btnSaveToCSV.Text = "Save to CSV";
            this.btnSaveToCSV.UseVisualStyleBackColor = true;
            this.btnSaveToCSV.Click += new System.EventHandler(this.btnSaveToCSV_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSaveToCSV);
            this.Controls.Add(this.btnEditContact);
            this.Controls.Add(this.btnAddContact);
            this.Controls.Add(this.dgvContacts);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


    }
}

