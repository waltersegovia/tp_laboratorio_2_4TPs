using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

//Clase Alumno:
//• Atributos ClaseQueToma del tipo EClase y EstadoCuenta del tipo EEstadoCuenta.
//• Sobreescribirá el método MostrarDatos con todos los datos del alumno.
//• ParticiparEnClase retornará la cadena "TOMA CLASE DE " junto al nombre de la clase que toma.
//• ToString hará públicos los datos del Alumno.
//• Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
//• Un Alumno será distinto a un EClase sólo si no toma esa clase.

namespace ClasesInstanciables
{
    [Serializable]

    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta { AlDia, Deudor, Becado }

        // Atributos ClaseQueToma del tipo EClase y EstadoCuenta del tipo EEstadoCuenta.
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno()
        { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Sobreescribirá el método MostrarDatos con todos los datos del alumno.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("Estado de cuenta: " + this.estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());           

            return sb.ToString();
        }

        /// <summary>
        /// ParticiparEnClase retornará la cadena "TOMA CLASE DE " junto al nombre de la clase que toma.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return ("TOMA CLASE DE: " + this.claseQueToma);
        }

        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma.Equals(clase) && !(a.estadoCuenta.Equals(EEstadoCuenta.Deudor)));
        }

        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a.claseQueToma.Equals(clase));
        }

        /// <summary>
        /// ToString hará públicos los datos del Alumno.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
