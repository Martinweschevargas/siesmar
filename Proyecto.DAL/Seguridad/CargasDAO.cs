using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Seguridad;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Seguridad
{
    public class CargaDAO
    {
        SqlCommand cmd = new SqlCommand();

        public List<CargaDTO> ObtenerLista(string descripcion)
        {
            List<CargaDTO> lista = new List<CargaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Seguridad.usp_CargaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaDescripcion", SqlDbType.VarChar, 200);
                cmd.Parameters["@CargaDescripcion"].Value = descripcion;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new CargaDTO()
                        {
                            CodigoCarga = Convert.ToInt32(dr["CodigoCarga"]),
                            DescCarga = dr["DescCarga"].ToString(),
                            FechaCarga = dr["FechaCarga"].ToString(),
                            RegistrosCarga = Convert.ToInt32(dr["RegistroCarga"])
                        });
                    }
                }
            }
            return lista;
        }

    }
}
