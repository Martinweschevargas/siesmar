using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EntidadPublicaPrivadaDAO
    {

        SqlCommand cmd = new();

        public List<EntidadPublicaPrivadaDTO> ObtenerEntidadPublicaPrivadas()
        {
            List<EntidadPublicaPrivadaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EntidadPublicaPrivadaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EntidadPublicaPrivadaDTO()
                        {
                            EntidadPublicaPrivadaId = Convert.ToInt32(dr["EntidadPublicaPrivadaId"]),
                            DescEntidadPublicaPrivada = dr["DescEntidadPublicaPrivada"].ToString(),
                            CodigoEntidadPublicaPrivada = dr["CodigoEntidadPublicaPrivada"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEntidadPublicaPrivada(EntidadPublicaPrivadaDTO entidadPublicaPrivadaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EntidadPublicaPrivadaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescEntidadPublicaPrivada", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescEntidadPublicaPrivada"].Value = entidadPublicaPrivadaDTO.DescEntidadPublicaPrivada;

                    cmd.Parameters.Add("@CodigoEntidadPublicaPrivada", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoEntidadPublicaPrivada"].Value = entidadPublicaPrivadaDTO.CodigoEntidadPublicaPrivada;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entidadPublicaPrivadaDTO.UsuarioIngresoRegistro;

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

        public EntidadPublicaPrivadaDTO BuscarEntidadPublicaPrivadaID(int Codigo)
        {
            EntidadPublicaPrivadaDTO entidadPublicaPrivadaDTO = new EntidadPublicaPrivadaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EntidadPublicaPrivadaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntidadPublicaPrivadaId", SqlDbType.Int);
                    cmd.Parameters["@EntidadPublicaPrivadaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        entidadPublicaPrivadaDTO.EntidadPublicaPrivadaId = Convert.ToInt32(dr["EntidadPublicaPrivadaId"]);
                        entidadPublicaPrivadaDTO.DescEntidadPublicaPrivada = dr["DescEntidadPublicaPrivada"].ToString();
                        entidadPublicaPrivadaDTO.CodigoEntidadPublicaPrivada = dr["CodigoEntidadPublicaPrivada"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return entidadPublicaPrivadaDTO;
        }

        public string ActualizarEntidadPublicaPrivada(EntidadPublicaPrivadaDTO entidadPublicaPrivadaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_EntidadPublicaPrivadaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntidadPublicaPrivadaId", SqlDbType.Int);
                    cmd.Parameters["@EntidadPublicaPrivadaId"].Value = entidadPublicaPrivadaDTO.EntidadPublicaPrivadaId;

                    cmd.Parameters.Add("@DescEntidadPublicaPrivada", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescEntidadPublicaPrivada"].Value = entidadPublicaPrivadaDTO.DescEntidadPublicaPrivada;

                    cmd.Parameters.Add("@CodigoEntidadPublicaPrivada", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoEntidadPublicaPrivada"].Value = entidadPublicaPrivadaDTO.CodigoEntidadPublicaPrivada;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entidadPublicaPrivadaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarEntidadPublicaPrivada(EntidadPublicaPrivadaDTO entidadPublicaPrivadaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EntidadPublicaPrivadaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntidadPublicaPrivadaId", SqlDbType.Int);
                    cmd.Parameters["@EntidadPublicaPrivadaId"].Value = entidadPublicaPrivadaDTO.EntidadPublicaPrivadaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entidadPublicaPrivadaDTO.UsuarioIngresoRegistro;

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
