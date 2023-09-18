
using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoActividadDifusionDAO
    {

        SqlCommand cmd = new();

        public List<TipoActividadDifusionDTO> ObtenerTipoActividadDifusions()
        {
            List<TipoActividadDifusionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoActividadDifusionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoActividadDifusionDTO()
                        {
                            TipoActividadDifusionId = Convert.ToInt32(dr["TipoActividadDifusionId"]),
                            DescTipoActividadDifusion = dr["DescTipoActividadDifusion"].ToString(),
                            CodigoTipoActividadDifusion = dr["CodigoTipoActividadDifusion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoActividadDifusion(TipoActividadDifusionDTO tipoActividadDifusionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoActividadDifusionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoActividadDifusion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescTipoActividadDifusion"].Value = tipoActividadDifusionDTO.DescTipoActividadDifusion;

                    cmd.Parameters.Add("@CodigoTipoActividadDifusion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoActividadDifusion"].Value = tipoActividadDifusionDTO.CodigoTipoActividadDifusion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoActividadDifusionDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
            return IND_OPERACION;
        }

        public TipoActividadDifusionDTO BuscarTipoActividadDifusionID(int Codigo)
        {
            TipoActividadDifusionDTO tipoActividadDifusionDTO = new TipoActividadDifusionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoActividadDifusionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoActividadDifusionId", SqlDbType.Int);
                    cmd.Parameters["@TipoActividadDifusionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoActividadDifusionDTO.TipoActividadDifusionId = Convert.ToInt32(dr["TipoActividadDifusionId"]);
                        tipoActividadDifusionDTO.DescTipoActividadDifusion = dr["DescTipoActividadDifusion"].ToString();
                        tipoActividadDifusionDTO.CodigoTipoActividadDifusion = dr["CodigoTipoActividadDifusion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoActividadDifusionDTO;
        }

        public string ActualizarTipoActividadDifusion(TipoActividadDifusionDTO tipoActividadDifusionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoActividadDifusionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoActividadDifusionId", SqlDbType.Int);
                    cmd.Parameters["@TipoActividadDifusionId"].Value = tipoActividadDifusionDTO.TipoActividadDifusionId;

                    cmd.Parameters.Add("@DescTipoActividadDifusion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoActividadDifusion"].Value = tipoActividadDifusionDTO.DescTipoActividadDifusion;

                    cmd.Parameters.Add("@CodigoTipoActividadDifusion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoActividadDifusion"].Value = tipoActividadDifusionDTO.CodigoTipoActividadDifusion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoActividadDifusionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoActividadDifusion(TipoActividadDifusionDTO tipoActividadDifusionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoActividadDifusionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoActividadDifusionId", SqlDbType.Int);
                    cmd.Parameters["@TipoActividadDifusionId"].Value = tipoActividadDifusionDTO.TipoActividadDifusionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoActividadDifusionDTO.UsuarioIngresoRegistro;

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
