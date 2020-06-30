using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo:IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            { return this.paquetes; }

            set
            { this.paquetes = value; }
        }

        public Correo()
        {
            paquetes = new List<Paquete>();
            mockPaquetes = new List<Thread>();
        }

        /// <summary>
        /// En el operador +:
        ///   a.Controlar si el paquete ya está en la lista.En el caso de que esté, se lanzará la excepción
        ///     TrackingIdRepetidoException.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {

            foreach (Paquete aux in c.Paquetes)
            {
                if (aux == p)
                {
                    throw new TrackingIdRepetidoException("Paquete repetido");
                }
            }
            c.Paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();

            return c;
        }
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            if (elementos is Correo)
            {
                foreach (Paquete aux in ((Correo)elementos).Paquetes)
                {
                    sb.AppendFormat("{0} para {1} ({2})", aux.TrackingID, aux.DireccionEntrega,
                    aux.Estado.ToString());
                    sb.AppendLine();
                }
            }
            return sb.ToString();
        }

        public void FinEntregas()
        {
            foreach (Thread aux in this.mockPaquetes)
            {
                if (aux.IsAlive)
                {
                    aux.Abort();
                }
            }
        }
    }
}
