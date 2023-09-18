using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoCompetenciaTecnicaDAO
    {

        SqlCommand cmd = new();

        public List<TipoCompetenciaTecnicaDTO> ObtenerTipoCompetenciaTecnicas()
        {
            List<TipoCompetenciaTecnicaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoCompetenciaTecnicaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoCompetenciaTecnicaDTO()
                        {
                            TipoCompetenciaTecnicaId = Convert.ToInt32(dr["TipoCompetenciaTecnicaId"]),
                            DescTipoCompetenciaTecnica = dr["DescTipoCompetenciaTecnica"].ToString(),
                            CodigoTipoCompetenciaTecnica = dr["CodigoTipoCompetenciaTecnica"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoCompetenciaTecnica(TipoCompetenciaTecnicaDTO tipoCompetenciaTecnicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoCompetenciaTecnicaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoCompetenciaTecnica", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescTipoCompetenciaTecnica"].Value = tipoCompetenciaTecnicaDTO.DescTipoCompetenciaTecnica;

                    cmd.Parameters.Add("@CodigoTipoCompetenciaTecnica", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoCompetenciaTecnica"].Value = tipoCompetenciaTecnicaDTO.CodigoTipoCompetenciaTecnica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoCompetenciaTecnicaDTO.UsuarioIngresoRegistro;

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

        public TipoCompetenciaTecnicaDTO BuscarTipoCompetenciaTecnicaID(int Codigo)
        {
            TipoCompetenciaTecnicaDTO tipoCompetenciaTecnicaDTO = new TipoCompetenciaTecnicaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoCompetenciaTecnicaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoCompetenciaTecnicaId", SqlDbType.Int);
                    cmd.Parameters["@TipoCompetenciaTecnicaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoCompetenciaTecnicaDTO.TipoCompetenciaTecnicaId = Convert.ToInt32(dr["TipoCompetenciaTecnicaId"]);
                        tipoCompetenciaTecnicaDTO.DescTipoCompetenciaTecnica = dr["DescTipoCompetenciaTecnica"].ToString();
                        tipoCompetenciaTecnicaDTO.CodigoTipoCompetenciaTecnica = dr["CodigoTipoCompetenciaTecnica"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoCompetenciaTecnicaDTO;
        }

        public string ActualizarTipoCompetenciaTecnica(TipoCompetenciaTecnicaDTO tipoCompetenciaTecnicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoCompetenciaTecnicaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoCompetenciaTecnicaId", SqlDbType.Int);
                    cmd.Parameters["@TipoCompetenciaTecnicaId"].Value = tipoCompetenciaTecnicaDTO.TipoCompetenciaTecnicaId;

                    cmd.Parameters.Add("@DescTipoCompetenciaTecnica", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescTipoCompetenciaTecnica"].Value = tipoCompetenciaTecnicaDTO.DescTipoCompetenciaTecnica;

                    cmd.Parameters.Add("@CodigoTipoCompetenciaTecnica", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoCompetenciaTecnica"].Value = tipoCompetenciaTecnicaDTO.CodigoTipoCompetenciaTecnica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoCompetenciaTecnicaDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoCompetenciaTecnica(TipoCompetenciaTecnicaDTO tipoCompetenciaTecnicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoCompetenciaTecnicaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoCompetenciaTecnicaId", SqlDbType.Int);
                    cmd.Parameters["@TipoCompetenciaTecnicaId"].Value = tipoCompetenciaTecnicaDTO.TipoCompetenciaTecnicaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoCompetenciaTecnicaDTO.UsuarioIngresoRegistro;

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
