using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// ** Dede ser Abstract y no sellada **
    /// </summary>
    public abstract class Vehiculo
    {
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;

        /// <summary>
        /// ** Enum debe ser publico **
        /// </summary>
        public enum EMarca 
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda
        }

        /// <summary>
        /// Enumerado ETamanio
        /// No puede ser menos accesible que la prop Tamanio
        /// </summary>
        public enum ETamanio 
        {
            Chico, Mediano, Grande
        }

        /// <summary>
        /// Constructor de vehículo con tres parámetros
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        //Debe ser protected, get
        protected abstract ETamanio Tamanio { get; }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// ** Usamos el operador Explicit **
        /// </summary>
        /// <returns></returns>
        /// Debe ser publica y virtual, no sealed
        public virtual string Mostrar() 
        {
            //Usamos el operador Explicit
            return (string)this; 
        }

        /// <summary>
        /// Operador Explicit
        /// ** Usamos AppendFormat, el operador no debe ser privado **
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Vehiculo p) 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis); 
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
        //Error en la comparación v1.chasis == v2.chasis
            return !(v1==v2); 
        }
    }
}
