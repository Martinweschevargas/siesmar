using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoNovedadDAO
    {

        SqlCommand cmd = new();

        public List<TipoNovedadDTO> ObtenerTipoNovedads()
        {
            List<TipoNovedadDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoNovedadListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoNovedadDTO()
                        {
                            TipoNovedadId = Convert.ToInt32(dr["TipoNovedadId"]),
                            DescTipoNovedad = dr["DescTipoNovedad"].ToString(),
                            CodigoTipoNovedad = dr["CodigoTipoNovedad"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoNovedad(TipoNovedadDTO tipoNovedadDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoNovedadRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoNovedad", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoNovedad"].Value = tipoNovedadDTO.DescTipoNovedad;

                    cmd.Parameters.Add("@CodigoTipoNovedad", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoNovedad"].Value = tipoNovedadDTO.CodigoTipoNovedad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoNovedadDTO.UsuarioIngresoRegistro;

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

        public TipoNovedadDTO BuscarTipoNovedadID(int Codigo)
        {
            TipoNovedadDTO tipoNovedadDTO = new TipoNovedadDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoNovedadEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoNovedadId", SqlDbType.Int);
                    cmd.Parameters["@TipoNovedadId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoNovedadDTO.TipoNovedadId = Convert.ToInt32(dr["TipoNovedadId"]);
                        tipoNovedadDTO.DescTipoNovedad = dr["DescTipoNovedad"].ToString();
                        tipoNovedadDTO.CodigoTipoNovedad = dr["CodigoTipoNovedad"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoNovedadDTO;
        }

        public string ActualizarTipoNovedad(TipoNovedadDTO tipoNovedadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoNovedadActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoNovedadId", SqlDbType.Int);
                    cmd.Parameters["@TipoNovedadId"].Value = tipoNovedadDTO.TipoNovedadId;

                    cmd.Parameters.Add("@DescTipoNovedad", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescTipoNovedad"].Value = tipoNovedadDTO.DescTipoNovedad;

                    cmd.Parameters.Add("@CodigoTipoNovedad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoNovedad"].Value = tipoNovedadDTO.CodigoTipoNovedad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoNovedadDTO.UsuarioIngresoRegistro;

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
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
            return IND_OPERACION;
        }

        public string EliminarTipoNovedad(TipoNovedadDTO tipoNovedadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoNovedadEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoNovedadId", SqlDbType.Int);
                    cmd.Parameters["@TipoNovedadId"].Value = tipoNovedadDTO.TipoNovedadId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoNovedadDTO.UsuarioIngresoRegistro;

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
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
            return IND_OPERACION;
        }

    }
}
