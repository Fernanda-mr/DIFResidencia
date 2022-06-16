using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Residencia;
using System.Configuration;
using Residencia.Modelo;
using System.Data.SQLite;

namespace Residencia.Logica
{
    public class Apoyoslogica
    {
        apoyosSql Apoyos = new apoyosSql();
        public void NuevoRegistro(Apoyos datos)
        {
            Apoyos.AñadirRegistro(datos);
        }
        public void EditarRegistro(Apoyos datos)
        {
            Apoyos.ModificarRegistro(datos);
        }
        public void BuscarPresupuesto(Apoyos datos)
        {
            Apoyos.BuscarDatosRegistro(datos);
        }
    }
}





/*
 *  private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static Apoyoslogica _instancia = null;
        public Apoyoslogica(){

        }
        public static Apoyoslogica Instancia{
            get{
                if (_instancia == null)
                {
                    _instancia = new Apoyoslogica();
                }
                return _instancia;
            }
        }

        public bool Guardar(Apoyos obj){
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena)){
                conexion.Open();
                string query = "insert into Apoyos(Nombre,Apellido,Tipo_Apoyo) values (@nombre,@apellido,@tipo_apoyo)";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@apellido", obj.Apellido));
                cmd.Parameters.Add(new SQLiteParameter("@tipo_apoyo", obj.Tipo_Apoyo));
                cmd.CommandType = System.Data.CommandType.Text;
                //validamos que sea correcto 
                if (cmd.ExecuteNonQuery() < 1){
                    respuesta = false;
                    
                };
            }
            return respuesta;
        }
        public List<Apoyos> Listar(){
            List<Apoyos> oLista = new List<Apoyos>();
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "select * from Apoyos";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader dr = cmd.ExecuteReader()) {
                    while (dr.Read()) { //mientras lee el resultado 
                        oLista.Add(new Apoyos(){
                        
                            ID = int.Parse(dr["ID"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Tipo_Apoyo = dr["Tipo_Apoyo"].ToString(),
                            
                        });
                    }
                }               
            }
            return oLista;
        }

        public bool Editar(Apoyos obj)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "update Apoyos set Nombre = @nombre,Apellido = @apellido,Tipo_Apoyo = @tipo_apoyo where ID = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@id", obj.ID));
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@apellido", obj.Apellido));
                cmd.Parameters.Add(new SQLiteParameter("@tipo_apoyo", obj.Tipo_Apoyo));
                cmd.CommandType = System.Data.CommandType.Text;
                //validamos que sea correcto 
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        public bool Eliminar(Apoyos obj)
        {
            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "delate from Apoyos where ID = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@id", obj.ID));
                cmd.CommandType = System.Data.CommandType.Text;
                //validamos que sea correcto 
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        public bool Consultar(Apoyos obj)
        {

            bool respuesta = true;
            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                
                //realiza la busqueda
                string query = "SELECT * FROM apoyos WHERE Nombre = nombre AND Apellido = apellido";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@apellido", obj.Apellido));
                cmd.CommandType = System.Data.CommandType.Text;
                //validamos que sea correcto 
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = true;
                }
            }
            return respuesta;
        
        }
 */