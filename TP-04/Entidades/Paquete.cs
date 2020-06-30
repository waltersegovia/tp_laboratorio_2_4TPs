using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Entidades
{
    public class Paquete:IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }

        /// <summary>
        /// MockCicloDeVida hará que el paquete cambie de estado de la siguiente forma:
        ///   a.Colocar una demora de 4 segundos.
        ///   b.Pasar al siguiente estado.
        ///   c.Informar el estado a través de InformarEstado.EventArgs no tendrá ningún dato extra.
        ///   d.Repetir las acciones desde el punto A hasta que el estado sea Entregado.
        ///   e.Finalmente guardar los datos del paquete en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            do
            {
                this.InformaEstado.Invoke(this, null);
                Thread.Sleep(4000);
                if (this.Estado == EEstado.Ingresado)
                {
                    this.Estado = EEstado.EnViaje;
                }
                else
                {
                    this.Estado = EEstado.Entregado;
                }


            } while (this.Estado != EEstado.Entregado);
            this.InformaEstado.Invoke(this, null);
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error en Base de Datos");
            }
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }


        /// <summary>
        /// Dos paquetes serán iguales siempre y cuando su Tracking ID sea el mismo.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.TrackingID == p2.TrackingID);
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// MostrarDatos utilizará string.Format con el siguiente formato "{0} para {1}", p.trackingID,
        /// direccionEntrega para compilar la información del paquete.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1} ({2})", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega, ((Paquete)elemento).Estado);
        }
    }
}
