using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;


        /// <summary>
        /// Si value es un valor válido lo asigna número.
        /// </summary>
        private string SetNumero 
        {
            set
            { 
                this.numero = ValidarNumero(value);
            }       
        }

        /// <summary>
        /// Inicializo numero=0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }


        public Numero(double numero):this()
        {
            this.numero = numero;
        }

       
        /// <summary>
        /// Recibe el string y lo valida con la propiedad
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

       
        /// <summary>
        /// Si es válido el parseo retorna el número de tipo double.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private static double ValidarNumero(string strNumero)
        {
            double numero;
            if (double.TryParse(strNumero, out numero)) 
                return numero;
            return 0;
        }

        #region DecimalBinario(double)
        /// <summary>
        /// Conversor Decimal-Binario para parámetro tipo double
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {
            string[] aux = new string[16];
            int numero_aux = (int)numero;
            int pos = 0;
            StringBuilder sb = new StringBuilder();
            do
            {
                if (numero_aux % 2 != 0)
                {
                    aux[pos] = "1";
                    pos++;
                }
                else
                {
                    aux[pos] = "0";
                    pos++;
                }
                numero_aux = numero_aux / 2;

            } while (numero_aux != 0);

            
            Array.Reverse(aux);  //invierto el Array de string

            for (int i = 0; i < aux.Length; i++)
            {
                sb.Append("" + aux[i]);
            }
           
            return sb.ToString(); ;
        }
        #endregion

        /// <summary>
        /// Conversor de Decimal-Binario para parámetro string
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        #region DecimalBinario(string)
        public static string DecimalBinario(string numero)
        {
            double numero_aux;
            if (double.TryParse(numero, out numero_aux))
                return Numero.DecimalBinario(numero_aux);
            return "Valor inválido";
        }
        #endregion


        #region Método BinarioDecimal(string)
        /// <summary>
        /// Conversor de Binario a Decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public static string BinarioDecimal(string binario)
        {
            char[] cadena = binario.ToCharArray();
            Array.Reverse(cadena);
            double resultado = 0;
           
               for (int i = 0; i < cadena.Length; i++)
               {
                   if (cadena[i] != '1' && cadena[i] != '0')
                       return "Valor inválido";
                if (cadena[i] == '1')
                    resultado += Math.Pow(2, i);
               }
            
            return resultado.ToString();
        }
#endregion
        /// <summary>
        /// Operrador -
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double resultado=0;       
            resultado = n1.numero - n2.numero;
            return resultado;                
        }

        /// <summary>
        /// Operrador +
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double resultado = 0;
            resultado = n1.numero + n2.numero;
            return resultado;
        }
        /// <summary>
        /// Operador *
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double resultado = 0;
            resultado = n1.numero * n2.numero;
            return resultado;
        }
        /// <summary>
        /// Operador /
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double resultado = 0;
            if (n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
                return resultado;
            }
            else { return double.MinValue; } // Si se tratara de una división por 0, retornará double.MinValue.
        }
    }
}
