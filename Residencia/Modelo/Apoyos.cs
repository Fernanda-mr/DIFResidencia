using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Residencia.Modelo
{
    public class Apoyos
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set;}
        public string Tipo_Apoyo { get; set;}
        public string Fecha { get; set;}

        

        public Apoyos(int id, string nombre, string apellido, string tipo_Apoyo, string fecha)
        {
            ID= id;
            Nombre = nombre;
            Apellido = apellido;
            Tipo_Apoyo = tipo_Apoyo;
            Fecha = fecha;
        }
        public Apoyos()
        {

        }
    }
}
