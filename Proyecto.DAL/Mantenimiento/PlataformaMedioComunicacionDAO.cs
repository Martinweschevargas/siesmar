using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class PlataformaMedioComunicacionDAO
    {

        SqlCommand cmd = new();

        public List<PlataformaMedioComunicacionDTO> ObtenerPlataformaMedioComunicacions()
        {
            List<PlataformaMedioComunicacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_PlataformaMedioComunicacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PlataformaMedioComunicacionDTO()
                        {
                            PlataformaMedioComunicacionId = Convert.ToInt32(dr["PlataformaMedioComunicacionId"]),
                            DescPlataformaMedioComunicacion = dr["DescPlataformaMedioComunicacion"].ToString(),
                            CodigoPlataformaMedioComunicacion = dr["CodigoPlataformaMedioComunicacion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarPlataformaMedioComunicacion(PlataformaMedioComunicacionDTO plataformaMedioComunicacionDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PlataformaMedioComunicacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescPlataformaMedioComunicacion", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescPlataformaMedioComunicacion"].Value = plataformaMedioComunicacionDTO.DescPlataformaMedioComunicacion;

                    cmd.Parameters.Add("@CodigoPlataformaMedioComunicacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoPlataformaMedioComunicacion"].Value = plataformaMedioComunicacionDTO.CodigoPlataformaMedioComunicacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = plataformaMedioComunicacionDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                        }
                    }
                }
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public PlataformaMedioComunicacionDTO BuscarPlataformaMedioComunicacionID(int Codigo)
        {
            PlataformaMedioComunicacionDTO plataformaMedioComunicacionDTO = new PlataformaMedioComunicacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PlataformaMedioComunicacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PlataformaMedioComunicacionId", SqlDbType.Int);
                    cmd.Parameters["@PlataformaMedioComunicacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        plataformaMedioComunicacionDTO.PlataformaMedioComunicacionId = Convert.ToInt32(dr["PlataformaMedioComunicacionId"]);
                        plataformaMedioComunicacionDTO.DescPlataformaMedioComunicacion = dr["DescPlataformaMedioComunicacion"].ToString();
                        plataformaMedioComunicacionDTO.CodigoPlataformaMedioComunicacion = dr["CodigoPlataformaMedioComunicacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return plataformaMedioComunicacionDTO;
        }

        public string ActualizarPlataformaMedioComunicacion(PlataformaMedioComunicacionDTO plataformaMedioComunicacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_PlataformaMedioComunicacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PlataformaMedioComunicacionId", SqlDbType.Int);
                    cmd.Parameters["@PlataformaMedioComunicacionId"].Value = plataformaMedioComunicacionDTO.PlataformaMedioComunicacionId;

                    cmd.Parameters.Add("@DescPlataformaMedioComunicacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescPlataformaMedioComunicacion"].Value = plataformaMedioComunicacionDTO.DescPlataformaMedioComunicacion;

                    cmd.Parameters.Add("@CodigoPlataformaMedioComunicacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoPlataformaMedioComunicacion"].Value = plataformaMedioComunicacionDTO.CodigoPlataformaMedioComunicacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = plataformaMedioComunicacionDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public bool EliminarPlataformaMedioComunicacion(PlataformaMedioComunicacionDTO plataformaMedioComunicacionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PlataformaMedioComunicacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PlataformaMedioComunicacionId", SqlDbType.Int);
                    cmd.Parameters["@PlataformaMedioComunicacionId"].Value = plataformaMedioComunicacionDTO.PlataformaMedioComunicacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = plataformaMedioComunicacionDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    cmd.ExecuteNonQuery();
                    eliminado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return eliminado;
        }

    }
}
