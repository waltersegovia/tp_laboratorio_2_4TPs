using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Todas las excepciones deberán tener mensajes propios: que tengan al menos un constructor que reciba mensaje y
// que tengan un constructor sin parámetros que asigne un mensaje por defecto.

namespace Excepciones
{
    /// <summary>
    /// Constructor sin parámetros que asigna un mensaje por defecto.
    /// </summary>
    public class AlumnoRepetidoException : Exception
    {
        public AlumnoRepetidoException() : base("Alumno repetido")
        { }
    }
}
