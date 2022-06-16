using Residencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.IO;
using Residencia.Logica;
using Residencia.Modelo;


namespace Residencia
{
    public partial class From1 : Form
    {
        BDConexion bd = new BDConexion();
        Apoyos datos = new Apoyos();
        Apoyoslogica apoyonuevo = new Apoyoslogica();


        public Panel p;
        int id;
        string Nombre;
        bool seleccion = false;
        //Boolean Modif = false;
        
        //Apoyoslogica apoyoslogica = new Apoyoslogica();

        public From1(string text)
        {
            InitializeComponent();
        }
        public From1(Panel panelPrincipal)
        {
            InitializeComponent();
            p = panelPrincipal;
        }

        public From1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            

        }
        public void mostar_apoyos1()
        {          
            
        }
        public void limpiar()
        {
            txtnombreb.Text = "";
            txtapellidob.Text = "";
            txtnombreb.Focus();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form formulario = new Registro();
            formulario.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvapoyosb.DataSource = bd.SelectDataTable("Select * from Apoyos");
        }

        private void txtapellidob_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtnombreb_TextChanged(object sender, EventArgs e)
        {
            dgvapoyosb.DataSource = bd.SelectDataTable("select ID AS 'id', Nombre AS 'nombre',Apellido AS 'apellido', Tipo_Apoyo AS 'tipo_Apoyo', Fecha AS 'fecha' from Apoyos where Nombre like '" + txtnombreb.Text + "%'");
           // dgvapoyosb.DataSource = bd.SelectDataTable("SELECT * FROM apoyos WHERE Nombre = nombre AND Apellido = apellido" + txtnombreb.Text + "%'");
        }

        private void dgvapoyosb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
