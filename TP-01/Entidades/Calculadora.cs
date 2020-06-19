using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public static class Calculadora
    {
        #region Metodo Operar


        /// <summary>
        /// Método estático Operar según el operador retorna un resultado de tipo double.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;
            string op = ValidarOperador(operador);
                switch (op)
                {
                    case "-":
                        resultado = numero1 - numero2;
                        break;
                    case "+":
                        resultado = numero1 + numero2;
                        break;
                    case "*":
                        resultado = numero1 * numero2;
                        break;
                    case "/":
                        resultado = numero1 / numero2;
                        break;

                }
            
            return resultado;
        }
        #endregion
        
        /// <summary>
        /// Valida el operador y va por default "+"
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string ValidarOperador(string operador)
        {
            if (operador == "-" || operador == "+" || operador == "*" || operador == "/")
                return operador;
            return "+";
        }
    }
}
