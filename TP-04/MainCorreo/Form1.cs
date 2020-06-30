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

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        Paquete paquete;
        Correo correo;

        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            paquete.InformaEstado += paq_InformaEstado;
            try
            {
                correo += paquete;
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        private void ActualizarEstados()
        {
            foreach (Paquete item in correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        if (!lstbEstadoIngresado.Items.Contains(item.ToString()))
                            lstbEstadoIngresado.Items.Add(item.ToString());
                        break;
                    case Paquete.EEstado.EnViaje:
                        if (!lstbEstadoEnViaje.Items.Contains(item.ToString()))
                        {
                            lstbEstadoEnViaje.Items.Add(item.ToString());
                            lstbEstadoIngresado.Items.Clear();
                        }
                        break;
                    case Paquete.EEstado.Entregado:
                        if (!lstbEstadoEntregado.Items.Contains(item.ToString()))
                        {
                            lstbEstadoEntregado.Items.Add(item.ToString());
                            lstbEstadoEnViaje.Items.Clear();
                        }
                        break;
                }
            }
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!(elemento == null))
            {
                string archivo = "salida";
                if (elemento is Paquete)
                {
                    rtbMostrar.Text = ((Paquete)elemento).ToString();
                }
                else if (elemento is Correo)
                {
                    rtbMostrar.Text = ((Correo)elemento).MostrarDatos((Correo)elemento);
                }
                rtbMostrar.Text.Guardar(archivo);
            }
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstbEstadoEntregado.SelectedItem);
        }

        private void Mostrar_Opening(object sender, CancelEventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
    }
}
