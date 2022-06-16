using Residencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Residencia.Logica;
using Residencia.Modelo;

namespace Residencia
{
    public class apoyosSql
    {
        BDConexion bd = new BDConexion();

        public void AñadirRegistro(Apoyos datos)
        {
            try
            {
                string agregar = "insert into Apoyos(Nombre,Apellido,Tipo_Apoyo,Fecha) values (@nombre,@apellido,@tipo_apoyo,@fecha)";
                if (bd.excecutecommand(agregar))
                {
                    MessageBox.Show("Beneficiario Registrado");
                }
                else
                {
                    MessageBox.Show("Algo salio mal, intente de nuevo");
                }
                bd.closeconnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void BuscarDatosRegistro(Apoyos datos)
        {
            bd.connecttodb();
            SQLiteCommand buscarRegistro = new SQLiteCommand("SELECT * FROM apoyos WHERE Nombre = nombre AND Apellido = apellido");

            SQLiteDataReader registro = buscarRegistro.ExecuteReader();
            if (registro.Read())
            {
                datos.Nombre = registro[1].ToString();
                datos.Apellido=registro[2].ToString();
                datos.Tipo_Apoyo=registro[3].ToString();
                datos.Fecha=registro[4].ToString();
            }
            registro.Close();
            bd.closeconnection();
        }
        public void ModificarRegistro(Apoyos datos)
        {
            try
            {
                bd.connecttodb();
                string actualizar = "update Apoyos set Nombre = @nombre,Apellido = @apellido,Tipo_Apoyo = @tipo_apoyo where ID = @id";

                if (bd.excecutecommand(actualizar))
                {
                    MessageBox.Show("Registro modificado");
                }
                else
                {
                    MessageBox.Show("No es posible modificar, intente de nuevo");
                }
                bd.closeconnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
