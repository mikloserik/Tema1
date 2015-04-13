using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication2
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void log_Click(object sender, EventArgs e)
        {
            AngajatService con = new AngajatService();
            if (con.getRole(username.Text, password.Text) == "admin")
            {
                Form f = new AdminForm();
                f.Show();
            }
            else if (con.getRole(username.Text, password.Text) == "angajat")
            {
                Form f = new AngajatForm();
                f.Show();
            }
        }
    }
}
