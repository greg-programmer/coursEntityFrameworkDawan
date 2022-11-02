using _05_CrudWinform.Models;
using _05_CrudWinform.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05_CrudWinform
{
    public partial class Form1 : Form
    {
        private ContactService service = new ContactService();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Remplir(service.GetAll());
            
        }

        private void Remplir(List<Contact> lst)
        {
            gridContacts.DataSource = null;
            gridContacts.DataSource = lst;
        }

        private void Clear()
        {
            txtID.Text = "";
            txtNom.Text = "";
            txtPrenom.Text = "";
            btnAjouter.Text = "Ajouter";
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            Remplir(service.FindByKey(txtRecherche.Text));
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Contact c = new Contact(txtNom.Text, txtPrenom.Text);
            if (btnAjouter.Text.Equals("Ajouter"))
            {
                service.Insert(new Contact(txtNom.Text, txtPrenom.Text));
            }
            else
            {
                c.Id = Convert.ToInt32(txtID.Text);
                service.Update(c);
            }
            Remplir(service.GetAll());
            Clear();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int id = (int)gridContacts.CurrentRow.Cells[0].Value;
            service.Delete(id);
            Remplir(service.GetAll());
        }

        private void gridContacts_DoubleClick(object sender, EventArgs e)
        {
            int id = (int)gridContacts.CurrentRow.Cells[0].Value;
            Contact c = service.GetById(id);
            txtID.Text = c.Id.ToString();
            txtNom.Text = c.Nom;
            txtPrenom.Text = c.Prenom;
            btnAjouter.Text = "Modifier";
        }
    }
}
