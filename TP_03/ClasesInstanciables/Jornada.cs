using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

//Clase Jornada:
//• Atributos Profesor, Clase y Alumnos que toman dicha clase.
//• Se inicializará la lista de alumnos en el constructor por defecto.
//• Una Jornada será igual a un Alumno si el mismo participa de la clase.
//• Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
//• ToString mostrará todos los datos de la Jornada.
//• Guardar de clase guardará los datos de la Jornada en un archivo de texto.
//• Leer de clase retornará los datos de la Jornada como texto.

namespace ClasesInstanciables
{
    [Serializable]

    public class Jornada
    {
        //Atributos Profesor, Clase y Alumnos que toman dicha clase.
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        /// <summary>
        /// Se inicializará la lista de alumnos en el constructor por defecto.
        /// </summary>
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.Instructor = instructor;
        }

        /// <summary>
        /// Guardar de clase guardará los datos de la Jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                string direccion = AppDomain.CurrentDomain.BaseDirectory;
                Texto texto = new Texto();
                return texto.Guardar(direccion + "\\AJornada.txt", jornada.ToString());
            }

            catch (ArchivosException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Leer de clase retornará los datos de la Jornada como texto.
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            try
            {
                string direccion = AppDomain.CurrentDomain.BaseDirectory;
                Texto texto = new Texto();
                string aux;
                if (texto.Leer(direccion + "\\AJornada.txt", out aux))
                    return aux;
                return null;
            }

            catch (ArchivosException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno item in j.alumnos)
            {
                if (item == a)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Una Jornada será distinta a un Alumno si el mismo no participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.alumnos.Add(a);

            return j;
        }

        /// <summary>
        /// ToString mostrará todos los datos de la Jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASE DE " + this.Clase);
            sb.AppendLine(this.Instructor.ToString());
            sb.AppendLine("ALUMNOS: ");

            foreach (Alumno item in Alumnos)
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine("<--------------------------------------------->\n");
            return sb.ToString();
        }
    }
}
