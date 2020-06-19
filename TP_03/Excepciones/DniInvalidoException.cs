﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException() : base("DNI inválido")
        { }

        public DniInvalidoException(Exception e) : base("*DNI inválido*", e)
        { }

        public DniInvalidoException(string mensaje) : base(mensaje)
        { }

        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e)
        { }
    }
}
