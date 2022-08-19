using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Profesor
    {

        ///Propiedades propias de la tabla 
        public int IdProfesor { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public decimal Sueldo { get; set; }

        //Variable para llenar Lista de Objetos
        public List<object> Profesores { get; set; }
    }
}
