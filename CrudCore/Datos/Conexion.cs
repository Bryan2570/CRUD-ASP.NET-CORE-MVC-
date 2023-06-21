//Realizamoa la conexion con ADO.NET    

using System.Data.SqlClient;

namespace CrudCore.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;

        public Conexion()
        {
            //Obtenemos la cadena de conexion que esta en el archivo appsettings.json
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();  
        }

    }
}
