using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;
using EntidadesAbstractas;

//Clase Universidad:
//• Atributos Alumnos(lista de inscriptos), Profesores(lista de quienes pueden dar clases) y Jornadas.*
//• Se accederá a una Jornada específica a través de un indexador.*
//• Un Universidad será igual a un Alumno si el mismo está inscripto en él.*
//• Un Universidad será igual a un Profesor si el mismo está dando clases en él.*
//• Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la clase, *
//   un Profesor que pueda darla (según su atributo ClasesDelDia) y la lista de alumnos que la toman(todos los que coincidan *
//   en su campo ClaseQueToma).*
//• Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente cargados.*
//• La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase.*
//   Sino, lanzará la Excepción SinProfesorException. *
//   El distinto retornará el primer Profesor que no pueda dar la clase.*
//• Si al querer agregar alumnos este ya figura en la lista, lanzar la excepción AlumnoRepetidoException.*
//• MostrarDatos será privado y de clase. Los datos del Universidad se harán públicos mediante ToString.*
//• Guardar de clase serializará los datos del Universidad en un XML, incluyendo todos los datos de sus Profesores, Alumnos y Jornadas.*
//• Leer de clase retornará un Universidad con todos los datos previamente serializados.*

namespace ClasesInstanciables
{
    [Serializable]

    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }

        //• Atributos Alumnos(lista de inscriptos), Profesores(lista de quienes pueden dar clases) y Jornadas.
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornadas; }
            set { this.jornadas = value; }
        }

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornadas = new List<Jornada>();
            profesores = new List<Profesor>();
        }

        /// <summary>
        /// MostrarDatos será privado y de clase. Los datos del Universidad se harán públicos mediante ToString.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            foreach (Jornada jornada in uni.Jornadas)
            {
                sb.Append(jornada.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Los datos del Universidad se harán públicos mediante ToString.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Leer de clase retornará un Universidad con todos los datos previamente serializados.
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            try
            {
                string direccion = AppDomain.CurrentDomain.BaseDirectory;
                Xml<Universidad> ser = new Xml<Universidad>();
                Universidad aux;
                if (ser.Leer(direccion + "\\AUniversidad.txt", out aux))
                    return aux;
                return null;
            }

            catch (ArchivosException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Guardar de clase serializará los datos del Universidad en un XML,
        /// incluyendo todos los datos de sus Profesores, Alumnos y Jornadas.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            try
            {
                string direccion = AppDomain.CurrentDomain.BaseDirectory;
                Xml<Universidad> ser = new Xml<Universidad>();
                if (ser.Guardar(direccion + "\\AUniversidad.xml", uni))
                    return true;
                return false;
            }

            catch (ArchivosException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno item in g.alumnos)
            {
                if (item == a)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor item in g.Instructores)
            {
                if (item == i)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        ///  La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase. 
        ///  Sino, lanzará la Excepción SinProfesorException. 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.Instructores)
            {
                if (item == clase)
                    return item;
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// El distinto retornará el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.profesores)
            {
                if (!(item == clase))
                    return item;
            }
            return null;
        }

        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la clase, 
        /// un Profesor que pueda darla (según su atributo ClasesDelDia) y la lista de alumnos que la toman(todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada j = null;
            Profesor aux = null;

            aux = (g == clase);
            if (!(Object.Equals(aux, null)))
                j = new Jornada(clase, aux);


            if (!(Object.Equals(j, null)))
            {
                foreach (Alumno item in g.Alumnos)
                {
                    if (item == clase)
                        j = j + item;
                }

                g.Jornadas.Add(j);

            }
            return g;
        }

        /// <summary>
        /// Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente cargados.
        /// Si al querer agregar alumnos este ya figura en la lista, lanzar la excepción AlumnoRepetidoException.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u == a)
                throw new AlumnoRepetidoException();
            u.Alumnos.Add(a);
            return u;
        }

        /// <summary>
        /// Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.Instructores.Add(i);
            return u;
        }

        /// <summary>
        /// Se accederá a una Jornada específica a través de un indexador.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                return this.Jornadas[i];
            }

            set
            {
                if (i >= 0 && i < jornadas.Count)
                    this.Jornadas[i] = value;
            }
        }
    }
}
