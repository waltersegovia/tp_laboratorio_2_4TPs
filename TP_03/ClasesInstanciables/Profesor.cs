using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EntidadesAbstractas;

//Clase Profesor:
//• Atributos ClasesDelDia del tipo Cola y random del tipo Random y estático.
//• Sobrescribir el método MostrarDatos con todos los datos del profesor.
//• ParticiparEnClase retornará la cadena "CLASES DEL DÍA" junto al nombre de la clases que da.
//• ToString hará públicos los datos del Profesor.
//• Se inicializará a Random sólo en un constructor.
//• En el constructor de instancia se inicializará ClasesDelDia y 
//  se asignarán dos clases al azar al Profesor mediante el método randomClases.Las dos clases pueden o no ser la misma.
//• Un Profesor será igual a un EClase si da esa clase.

namespace ClasesInstanciables
{
    [Serializable]

    public sealed class Profesor : Universitario
    {
        //• Atributos ClasesDelDia del tipo Cola y random del tipo Random y estático.
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        /// <summary>
        /// Se asignarán dos clases al azar al Profesor mediante el método randomClases.Las dos clases pueden o no ser la misma.
        /// </summary>
        private void randomClases()
        {
            int cl;
            for (int i = 0; i < 2; i++)
            {
                cl = random.Next(0,4);
                Thread.Sleep(40);
                clasesDelDia.Enqueue((Universidad.EClases)cl);
            }

        }

        /// <summary>
        /// Sobrescribir el método MostrarDatos con todos los datos del profesor.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            return sb.ToString();
        }

        /// <summary>
        /// ParticiparEnClase retornará la cadena "CLASES DEL DÍA" junto al nombre de la clases que da.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DÍA: ");
            foreach (Universidad.EClases item in clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString(); 
        }

        /// <summary>
        /// ToString hará públicos los datos del Profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (this.MostrarDatos() + "\n" + ParticiparEnClase());
        }

        /// <summary>
        /// Un Profesor será igual a un EClases si da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item.Equals(clase))
                    return true;
            }
            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Se inicializará a Random sólo en un constructor.
        /// </summary>
        static Profesor() 
        {
            random = new Random();
        }

        /// <summary>
        ///  En el constructor de instancia se inicializará ClasesDelDia y 
        ///  se asignarán dos clases al azar al Profesor mediante el método randomClases. Las dos clases pueden o no ser la misma.
        /// </summary>
        public Profesor() 
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            randomClases();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):this()
        {
            this.Legajo = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.StringToDNI = dni;
            this.Nacionalidad = nacionalidad;
        }

    }
}
