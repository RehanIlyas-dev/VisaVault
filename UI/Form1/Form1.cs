using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visavault_g43
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            customizeDesing();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void customizeDesing()
        {
            panelClient.Visible = false;
            panelCases.Visible = false;
            panelDocument.Visible = false;
            panelFinance.Visible = false;

        }
        private void hidesubmenu()
        {
            if(panelClient.Visible == true)
            {
                panelClient.Visible = false;
            }
            if(panelCases.Visible == true)
            {
                panelCases.Visible = false;
            }
            if(panelDocument.Visible == true)
            {
                panelDocument.Visible = false;
            }
            if(panelFinance.Visible == true)
            {
                panelFinance.Visible = false;
            }

        }
        private void showsubmenue(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hidesubmenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;

            }

        }

        private void Clientbtn_Click(object sender, EventArgs e)
        {
            showsubmenue(panelClient);
        }

        private void CRbtn_Click(object sender, EventArgs e)
        {
            fromload(new Client_Registry());
            hidesubmenu();
        }

        private void CMbtn_Click(object sender, EventArgs e)
        {
            fromload(new Client_Management());
            hidesubmenu();
        }

        private void DPbtn_Click(object sender, EventArgs e)
        {
            fromload(new Document_Portfolio());
            hidesubmenu();
        }

        private void DMbtn_Click(object sender, EventArgs e)
        {
            fromload(new Document_Manag());
            hidesubmenu();
        }

        private void RWbtn_Click(object sender, EventArgs e)
        {
            fromload(new Renewal_WorkFlow());
            hidesubmenu();
        }

        private void ARbtn_Click(object sender, EventArgs e)
        {
            hidesubmenu();
        }

        private void DVbtn_Click(object sender, EventArgs e)
        {
            fromload(new Dependency_Validator());
            hidesubmenu();
        }

        private void DCbtn_Click(object sender, EventArgs e)
        {
            fromload(new Deadline_Calculator());
            hidesubmenu();
        }

        private void Ibtn_Click(object sender, EventArgs e)
        {
            fromload(new Invoice());
            hidesubmenu();
        }

        private void FCbtn_Click(object sender, EventArgs e)
        {
            fromload(new Fee_Calculator());
            hidesubmenu();
        }

        private void Documentbtn_Click(object sender, EventArgs e)
        {
            showsubmenue(panelDocument);
        }

        private void btncase_Click(object sender, EventArgs e)
        {
            showsubmenue(panelCases);
        }

        private void financebtn_Click(object sender, EventArgs e)
        {
            showsubmenue(panelFinance);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fromload(new Home());
        }
        public void fromload(object Form)
        {
            if(this.Mainpanel.Controls.Count > 0)
            {
                this.Mainpanel.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock=DockStyle.Fill;
            this.Mainpanel.Controls.Add (f);
            this.Mainpanel.Tag = f;
            f.Show();   
        }

        private void Homebtn_Click(object sender, EventArgs e)
        {
            fromload(new Home());
        }

        private void appbtn_Click(object sender, EventArgs e)
        {
            fromload(new Appoinment());
        }

        private void EAbtn_Click(object sender, EventArgs e)
        {

            fromload(new Expiry_Alert());
        }
    }
}
