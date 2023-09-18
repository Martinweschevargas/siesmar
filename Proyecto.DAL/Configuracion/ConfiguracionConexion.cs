using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Siesmar.AccesoDatos.Configuracion
{
    public class ConfiguracionConexion
    {
        private string cadenaSQL = string.Empty;

        public ConfiguracionConexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadenaSQL = builder.GetSection("ConnectionStrings:cadenaSql").Value;
        }

        public string getCadenaSQL()
        {
            return cadenaSQL;
        }
    }
}
