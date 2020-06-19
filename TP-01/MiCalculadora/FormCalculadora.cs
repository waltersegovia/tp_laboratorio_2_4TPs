using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        /// <summary>
        ///  Inicializa el Label
        /// </summary>
        public LaCalculadora()
        {
            InitializeComponent();
            lblResultado.Text = " ";
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
            cmbOperador.Items.Add("/");
        }

        #region Método Limpiar
        /// <summary>
        /// Boton Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            lblResultado.Text = " ";
            cmbOperador.Text = " ";
        }

        #endregion

        /// <summary>
        /// Muestra el Resultado, usando el método estático "Operar"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = LaCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose(); 
        }


        /// <summary>
        /// Convierte el resultado a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != " " && lblResultado.Text != "0")
            lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
        }


        /// <summary>
        /// Convierte el resultado a Decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != " " && lblResultado.Text != "0")
                lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);         
        }
        /// <summary>
        /// Método estático Operar
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
                Numero num1 = new Numero(numero1);
                Numero num2 = new Numero(numero2);                     

                double resultado = Calculadora.Operar(num1, num2, operador);
            
            return resultado;
        }
    }
}
