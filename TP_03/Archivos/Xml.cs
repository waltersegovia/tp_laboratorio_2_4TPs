using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;


//• Implementar la interfaz en las clases Xml y Texto, a fin de poder guardar y leer archivos de esos tipos.

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            StreamWriter sw = new StreamWriter(archivo, true);
            XmlSerializer xml = new XmlSerializer(typeof(T));

            try
            {
                xml.Serialize(sw, datos);
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

        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                XmlTextReader wt = new XmlTextReader(archivo);
                datos = (T)ser.Deserialize(wt);
                wt.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
