using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using ClasesInstanciables;
using EntidadesAbstractas;
using Excepciones;

//Test Unitarios:
//a.Generar al menos dos test unitario que validen Excepciones
//b.Generar al menos uno que valide un valor numérico
//c.Generar al menos uno que valide que no haya valores nulos en algún atributo de las clases dadas.

namespace UnitTestProjectTP3
{
    [TestClass]
    public class UnitTestTP3
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalidoException()
        {
            // DNI con un caracter
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "a2234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAlumnoRepetidoException()
        {
            Universidad u = new Universidad();
            // Alumno repetido 
            Alumno a2 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            u += a2;
            Alumno a3 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            u += a3;
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestExceptionValorNumericoDni()
        {
            // No coincide dni con la nacionalidad
            Profesor i2 = new Profesor(2, "Roberto", "Juarez", "92234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
        }

        [TestMethod]
        public void TestValorNumericoDni()
        {
            Profesor i2 = new Profesor(2, "Roberto", "Juarez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            int aux = i2.DNI;
            Assert.AreEqual(12234456, aux);
        }

        [TestMethod]
        public void TestValorNuloEnLegajo()
        {
            Profesor i2 = new Profesor(2, "Roberto", "Juarez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            int aux = i2.Legajo;
            Assert.IsNotNull(aux);
        }
    }
}
