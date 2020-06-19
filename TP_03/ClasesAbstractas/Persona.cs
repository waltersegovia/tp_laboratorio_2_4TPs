using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

//Clase Persona:
//• Abstracta, con los atributos Nombre, Apellido, Nacionalidad y DNI.
//• Se deberá validar que el DNI sea correcto, teniendo en cuenta su nacionalidad.Argentino entre 1 y 89999999 y
//   Extranjero entre 90000000 y 99999999. Caso contrario, se lanzará la excepción NacionalidadInvalidaException.
//• Si el DNI presenta un error de formato (más caracteres de los permitidos, letras, etc.) se lanzará DniInvalidoException.
//• Sólo se realizarán las validaciones dentro de las propiedades.
//• Validará que los nombres sean cadenas con caracteres válidos para nombres.Caso contrario, no se cargará.
//• ToString retornará los datos de la Persona.

namespace EntidadesAbstractas
{
    [XmlInclude(typeof(Universitario))]
    public abstract class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero }

        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;

        //• Sólo se realizarán las validaciones dentro de las propiedades.
        public string Nombre
        {
            get { return this.nombre; }
            set
            {
                if (!(ValidarNombreApellido(value) is null))
                    this.nombre = value;
            }
        }

        public string Apellido
        {
            get { return this.apellido; }
            set
            {
                if (!(ValidarNombreApellido(value) is null))
                    this.apellido = value;
            }
        }

        public int DNI
        {
            get { return this.dni; }
            set
            {
                this.dni = ValidarDni(Nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        public string StringToDNI
        {
            set
            {
               this.dni = ValidarDni(Nacionalidad, value);
            }
        }

        public Persona()
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// ToString retornará los datos de la Persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Nombre completo: {0}, {1}\n", this.Apellido, this.Nombre);
            sb.AppendLine("Nacionalidad: " + this.nacionalidad);

            return sb.ToString();
        }

        /// <summary>
        /// • Se deberá validar que el DNI sea correcto, teniendo en cuenta su nacionalidad.Argentino entre 1 y 89999999 y
        ///   Extranjero entre 90000000 y 99999999. Caso contrario, se lanzará la excepción NacionalidadInvalidaException.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (((nacionalidad.Equals(ENacionalidad.Argentino)) && dato > 0 && dato < 90000000))
                return dato;
            if (((nacionalidad.Equals(ENacionalidad.Extranjero)) && dato > 89999999 && dato <= 99999999))
                return dato;
            else { throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI"); }
        }

        /// <summary>
        /// Si el DNI presenta un error de formato (más caracteres de los permitidos, letras, etc.) se lanzará DniInvalidoException.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int num;
            string tipo = "^\\d{8}$";
            if (int.TryParse(dato, out num) && dato.Length <= 8 && Regex.IsMatch(dato, tipo))
                return ValidarDni(nacionalidad, num);
            else { throw new DniInvalidoException("Dni Inválido"); } 
        }

        /// <summary>
        /// Validará que los nombres sean cadenas con caracteres válidos para nombres.Caso contrario, no se cargará.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string aux = null;
            int flag = -1;
            for (int i = 0; i < dato.Length; i++)
            {
                if (!(char.IsLetter(dato[i])))
                    flag = 1;
            }

            if (flag == -1)
                aux = dato;
            return aux;
        }
    }
}
