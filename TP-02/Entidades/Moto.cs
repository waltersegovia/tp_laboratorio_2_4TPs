using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto:Vehiculo
    {
        /// <summary>
        /// Constructor de Moto con tres parámetros
        /// ** Falta herencia de parámetros **
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Moto(EMarca marca, string chasis, ConsoleColor color):base(chasis,marca,color)
        {
        }

        /// <summary>
        /// Las motos son chicas
        /// ** Es de tipo ETamanio **
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// El metodo Mostrar() debe ser público y no sellado
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            //Debe llamar al método base.Mostrar()
            sb.AppendLine(base.Mostrar());
            //Usamos AppendFormat
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio); 
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
