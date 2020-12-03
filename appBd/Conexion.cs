using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace appBd
{
    class Conexion
    {
        // Propiedades
        // Metodos
        public SqlConnection conectarToDB()
        {
            // instanciar el generador de cadenas de conexion
            SqlConnectionStringBuilder generadorCadena = new SqlConnectionStringBuilder();

            // Asignar valores a las propiedades del generador
            generadorCadena.DataSource = "localhost"; // servidor
            generadorCadena.InitialCatalog = "BDMARKET"; // base de datos
            generadorCadena.IntegratedSecurity = true; //seguridad windows
            //generadorCadena.UserID = "sa"; // usuario
            //generadorCadena.Password = "123456"; // contrase;a

            //recuperar cadena
            string cadena = generadorCadena.ConnectionString;

            SqlConnection conexion = new SqlConnection(cadena);

            //retornar la conexion
            return conexion;
        }
    }
}
