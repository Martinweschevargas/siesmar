
using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoEstudioInvestigacionDAO
    {

        SqlCommand cmd = new();

        public List<TipoEstudioInvestigacionDTO> ObtenerTipoEstudioInvestigacions()
        {
            List<TipoEstudioInvestigacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoEstudioInvestigacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoEstudioInvestigacionDTO()
                        {
                            TipoEstudioInvestigacionId = Convert.ToInt32(dr["TipoEstudioInvestigacionId"]),
                            DescTipoEstudioInvestigacion = dr["DescTipoEstudioInvestigacion"].ToString(),
                            CodigoTipoEstudioInvestigacion = dr["CodigoTipoEstudioInvestigacion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoEstudioInvestigacion(TipoEstudioInvestigacionDTO tipoEstudioInvestigacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoEstudioInvestigacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoEstudioInvestigacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescTipoEstudioInvestigacion"].Value = tipoEstudioInvestigacionDTO.DescTipoEstudioInvestigacion;

                    cmd.Parameters.Add("@CodigoTipoEstudioInvestigacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoEstudioInvestigacion"].Value = tipoEstudioInvestigacionDTO.CodigoTipoEstudioInvestigacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoEstudioInvestigacionDTO.UsuarioIngresoRegistro;

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

        public TipoEstudioInvestigacionDTO BuscarTipoEstudioInvestigacionID(int Codigo)
        {
            TipoEstudioInvestigacionDTO tipoEstudioInvestigacionDTO = new TipoEstudioInvestigacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoEstudioInvestigacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoEstudioInvestigacionId", SqlDbType.Int);
                    cmd.Parameters["@TipoEstudioInvestigacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoEstudioInvestigacionDTO.TipoEstudioInvestigacionId = Convert.ToInt32(dr["TipoEstudioInvestigacionId"]);
                        tipoEstudioInvestigacionDTO.DescTipoEstudioInvestigacion = dr["DescTipoEstudioInvestigacion"].ToString();
                        tipoEstudioInvestigacionDTO.CodigoTipoEstudioInvestigacion = dr["CodigoTipoEstudioInvestigacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoEstudioInvestigacionDTO;
        }

        public string ActualizarTipoEstudioInvestigacion(TipoEstudioInvestigacionDTO tipoEstudioInvestigacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoEstudioInvestigacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoEstudioInvestigacionId", SqlDbType.Int);
                    cmd.Parameters["@TipoEstudioInvestigacionId"].Value = tipoEstudioInvestigacionDTO.TipoEstudioInvestigacionId;

                    cmd.Parameters.Add("@DescTipoEstudioInvestigacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoEstudioInvestigacion"].Value = tipoEstudioInvestigacionDTO.DescTipoEstudioInvestigacion;

                    cmd.Parameters.Add("@CodigoTipoEstudioInvestigacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoEstudioInvestigacion"].Value = tipoEstudioInvestigacionDTO.CodigoTipoEstudioInvestigacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoEstudioInvestigacionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoEstudioInvestigacion(TipoEstudioInvestigacionDTO tipoEstudioInvestigacionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoEstudioInvestigacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoEstudioInvestigacionId", SqlDbType.Int);
                    cmd.Parameters["@TipoEstudioInvestigacionId"].Value = tipoEstudioInvestigacionDTO.TipoEstudioInvestigacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoEstudioInvestigacionDTO.UsuarioIngresoRegistro;

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
