using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlConnection conexion;
        private static SqlCommand com;
 
        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection(@"Data Source = .\SQLEXPRESS; initial catalog = correo-sp-2017; integrated security = true");
            PaqueteDAO.com = new SqlCommand();
            PaqueteDAO.com.CommandType = System.Data.CommandType.Text;
            PaqueteDAO.com.Connection = PaqueteDAO.conexion;
        }

        /// <summary>
        /// De surgir cualquier error con la carga de datos, se deberá lanzar una excepción tantas veces como sea
        /// necesario hasta llegar a la vista(formulario). A través de un MessageBox informar lo ocurrido al
        /// usuario de forma clara.De ser necesario, utilizar un evento para este fin.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {

            bool resultado = false;
            string alumno = "Segovia Walter";
            string archivo = string.Format("INSERT INTO[dbo].[Paquetes]([direccionEntrega],[trackingID],[alumno])VALUES('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID, alumno);
            try
            {
                resultado = EjecutarNonQuery(archivo);
            }
            catch (Exception e)
            {
                throw new TrackingIdRepetidoException(e.Message);
            }
            return resultado;
        }


        private static bool EjecutarNonQuery(string sql)
        {
            bool connBase = false;
            try
            {
                PaqueteDAO.com.CommandText = sql;
                PaqueteDAO.conexion.Open();
                PaqueteDAO.com.ExecuteNonQuery();
                connBase = true;
            }

            catch (Exception e)
            {
                connBase = false;
                throw e;
            }

            finally
            {
                if (connBase)
                    PaqueteDAO.conexion.Close();
            }
            return connBase;
        }
    }
}
