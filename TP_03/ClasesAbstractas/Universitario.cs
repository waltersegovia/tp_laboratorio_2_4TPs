using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

//Clase Universitario:
//• Abstracta, con el atributo Legajo.
//• Método protegido y virtual MostrarDatos retornará todos los datos del Universitario.
//• Método protegido y abstracto ParticiparEnClase.
//• Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// Sobreescribo el método Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is Universitario);
        }

        public int Legajo
        {
            get { return this.legajo; }
            set { this.legajo = value; }
        }
        /// <summary>
        /// Método protegido y virtual MostrarDatos retornará todos los datos del Universitario.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append("LEGAJO NÚMERO: " + this.legajo);
            return sb.ToString();
        }

        /// <summary>
        /// Método protegido y abstracto ParticiparEnClase.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// Llama al método Equals
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return ((pg1.Equals(pg2)) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI));
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1==pg2);
        }

        public Universitario()
        { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
    }
}
