using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTestTP4
{
    [TestClass]
    public class UnitTestEntidades
    {
        /// <summary>
        /// Verifiqua que no se puedan cargar dos Paquetes con el mismo Tracking ID.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void PaqueteRepetido()
        {
            Correo c = new Correo();

            c += new Paquete("Venezuela 200 ", "345-800-4554");
            c += new Paquete("Venezuela 200 ", "345-800-4554");
        }

        /// <summary>
        /// Verifiqua que la lista de Paquetes del Correo esté instanciada.
        /// </summary>
        [TestMethod]
        public void InstanciaDeListaPaquetes()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }
      
    }
}
