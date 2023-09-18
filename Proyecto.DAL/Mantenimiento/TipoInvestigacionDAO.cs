using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoInvestigacionDAO
    {

        SqlCommand cmd = new();

        public List<TipoInvestigacionDTO> ObtenerTipoInvestigacions()
        {
            List<TipoInvestigacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoInvestigacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoInvestigacionDTO()
                        {
                            TipoInvestigacionId = Convert.ToInt32(dr["TipoInvestigacionId"]),
                            DescTipoInvestigacion = dr["DescTipoInvestigacion"].ToString(),
                            CodigoTipoInvestigacion = dr["CodigoTipoInvestigacion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoInvestigacion(TipoInvestigacionDTO tipoInvestigacionDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoInvestigacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoInvestigacion", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoInvestigacion"].Value = tipoInvestigacionDTO.DescTipoInvestigacion;

                    cmd.Parameters.Add("@CodigoTipoInvestigacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoInvestigacion"].Value = tipoInvestigacionDTO.CodigoTipoInvestigacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoInvestigacionDTO.UsuarioIngresoRegistro;

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

        public TipoInvestigacionDTO BuscarTipoInvestigacionID(int Codigo)
        {
            TipoInvestigacionDTO tipoInvestigacionDTO = new TipoInvestigacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoInvestigacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoInvestigacionId", SqlDbType.Int);
                    cmd.Parameters["@TipoInvestigacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoInvestigacionDTO.TipoInvestigacionId = Convert.ToInt32(dr["TipoInvestigacionId"]);
                        tipoInvestigacionDTO.DescTipoInvestigacion = dr["DescTipoInvestigacion"].ToString();
                        tipoInvestigacionDTO.CodigoTipoInvestigacion = dr["CodigoTipoInvestigacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoInvestigacionDTO;
        }

        public string ActualizarTipoInvestigacion(TipoInvestigacionDTO tipoInvestigacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoInvestigacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoInvestigacionId", SqlDbType.Int);
                    cmd.Parameters["@TipoInvestigacionId"].Value = tipoInvestigacionDTO.TipoInvestigacionId;

                    cmd.Parameters.Add("@DescTipoInvestigacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescTipoInvestigacion"].Value = tipoInvestigacionDTO.DescTipoInvestigacion;

                    cmd.Parameters.Add("@CodigoTipoInvestigacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoInvestigacion"].Value = tipoInvestigacionDTO.CodigoTipoInvestigacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoInvestigacionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoInvestigacion(TipoInvestigacionDTO tipoInvestigacionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoInvestigacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoInvestigacionId", SqlDbType.Int);
                    cmd.Parameters["@TipoInvestigacionId"].Value = tipoInvestigacionDTO.TipoInvestigacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoInvestigacionDTO.UsuarioIngresoRegistro;

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
