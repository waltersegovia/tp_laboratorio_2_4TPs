using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;

//Archivos:
//• Generar una interfaz con las firmas para guardar y leer.
//• Implementar la interfaz en las clases Xml y Texto, a fin de poder guardar y leer archivos de esos tipos.

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter sw = new StreamWriter(archivo, true, Encoding.UTF8);
            try
            {
                sw.Write(datos);
                return true;
            }

            catch (Exception e)
            {
                throw new ArchivosException(e.InnerException);
            }

            finally
            {
                sw.Close();
            }
        }

        public bool Leer(string archivo, out string datos)
        {
            StreamReader sr = new StreamReader(archivo);
            try
            {
                string aux = null;
                while ((sr.ReadLine()) != null)
                {
                    aux = sr.ReadLine();
                }
                datos = aux;
                return true;
            }

            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            finally
            {
                sr.Close();
            }
        }
    }
}
