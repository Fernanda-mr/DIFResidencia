using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Residencia.Modelo;
using Residencia.Logica;

namespace Residencia
{
    public partial class Registro : Form
    {
        BDConexion bd = new BDConexion();
        Apoyos datos=new Apoyos();
        Apoyoslogica apoyonuevo = new Apoyoslogica();
        
        public Panel p;
        int ID;
        Boolean Modif;
        

        DateTime fechaentrega;

        public Registro(Panel panelPrincipal)
        {
            InitializeComponent();
            p = panelPrincipal;
        }
        public Registro()
        {
            InitializeComponent();
            

        }
        public Registro(Panel panelPrincipal, int id, Boolean modif)
        {
            InitializeComponent();
            p = panelPrincipal;
            ID = id;
            Modif = modif;
        }

        public Boolean VerificadoCorrecto()
        {
            Boolean v;
            if (txtnombre.Text.Equals("") || txtapellido.Text.Equals("") || txboxtapoyo.Text.Equals("") || txtfecha.Text.Equals(""))
            {
                v = false;
            }
            else
            {
                v = true;
            }
            return v;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (VerificadoCorrecto())
            {
                try
                {
                    datos.Nombre = txtnombre.Text;
                    datos.Apellido = txtapellido.Text;
                    datos.Tipo_Apoyo = txboxtapoyo.Text;
                    datos.Fecha = txtfecha.Text;
                    apoyonuevo.NuevoRegistro(datos);

                    Registro re = new Registro(p) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    re.FormBorderStyle=FormBorderStyle.Sizable;
                    p.Controls.Add(re);
                    re.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
            else
            {
                MessageBox.Show("No a llenado todos los campos");
            }
        }
        

        public void mostar_apoyos()
        {
                   
        }

        public void limpiar()
        {
            txtID.Text = "";
            txtnombre.Text = "";
            txtapellido.Text = "";
            txboxtapoyo.Text = "";
            txtnombre.Focus();
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Registro_Load(object sender, EventArgs e)
        {
            dgvapoyos.DataSource = bd.SelectDataTable("Select * from Apoyos");

            fechaentrega = DateTime.Now;
            fechaentrega = monthCalendar2.SelectionRange.Start.Date;

            txtfecha.Text = fechaentrega.ToShortDateString();
         
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (VerificadoCorrecto())
            {
                try
                {
                    datos.ID = Int32.Parse (txtID.Text);
                    datos.Nombre = txtnombre.Text;
                    datos.Apellido = txtapellido.Text;
                    datos.Tipo_Apoyo = txboxtapoyo.Text;
                    datos.Fecha = txtfecha.Text;
                    apoyonuevo.EditarRegistro(datos);

                    Registro re = new Registro(p) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    re.FormBorderStyle = FormBorderStyle.Sizable;
                    p.Controls.Add(re);
                    re.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void txtapellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvapoyos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            fechaentrega = monthCalendar2.SelectionRange.Start.Date;
            txtfecha.Text = fechaentrega.ToShortDateString();
        }
    }
}
