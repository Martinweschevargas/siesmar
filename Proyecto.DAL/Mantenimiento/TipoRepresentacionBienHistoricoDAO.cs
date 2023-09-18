
using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoRepresentacionBienHistoricoDAO
    {

        SqlCommand cmd = new();

        public List<TipoRepresentacionBienHistoricoDTO> ObtenerTipoRepresentacionBienHistoricos()
        {
            List<TipoRepresentacionBienHistoricoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoRepresentacionBienHistoricoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoRepresentacionBienHistoricoDTO()
                        {
                            TipoRepresentacionBienHistoricoId = Convert.ToInt32(dr["TipoRepresentacionBienHistoricoId"]),
                            DescTipoRepresentacionBienHistorico = dr["DescTipoRepresentacionBienHistorico"].ToString(),
                            CodigoTipoRepresentacionBienHistorico = dr["CodigoTipoRepresentacionBienHistorico"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoRepresentacionBienHistorico(TipoRepresentacionBienHistoricoDTO tipoRepresentacionBienHistoricoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoRepresentacionBienHistoricoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoRepresentacionBienHistorico", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescTipoRepresentacionBienHistorico"].Value = tipoRepresentacionBienHistoricoDTO.DescTipoRepresentacionBienHistorico;

                    cmd.Parameters.Add("@CodigoTipoRepresentacionBienHistorico", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoRepresentacionBienHistorico"].Value = tipoRepresentacionBienHistoricoDTO.CodigoTipoRepresentacionBienHistorico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoRepresentacionBienHistoricoDTO.UsuarioIngresoRegistro;

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

        public TipoRepresentacionBienHistoricoDTO BuscarTipoRepresentacionBienHistoricoID(int Codigo)
        {
            TipoRepresentacionBienHistoricoDTO tipoRepresentacionBienHistoricoDTO = new TipoRepresentacionBienHistoricoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoRepresentacionBienHistoricoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoRepresentacionBienHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@TipoRepresentacionBienHistoricoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoRepresentacionBienHistoricoDTO.TipoRepresentacionBienHistoricoId = Convert.ToInt32(dr["TipoRepresentacionBienHistoricoId"]);
                        tipoRepresentacionBienHistoricoDTO.DescTipoRepresentacionBienHistorico = dr["DescTipoRepresentacionBienHistorico"].ToString();
                        tipoRepresentacionBienHistoricoDTO.CodigoTipoRepresentacionBienHistorico = dr["CodigoTipoRepresentacionBienHistorico"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoRepresentacionBienHistoricoDTO;
        }

        public string ActualizarTipoRepresentacionBienHistorico(TipoRepresentacionBienHistoricoDTO tipoRepresentacionBienHistoricoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoRepresentacionBienHistoricoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoRepresentacionBienHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@TipoRepresentacionBienHistoricoId"].Value = tipoRepresentacionBienHistoricoDTO.TipoRepresentacionBienHistoricoId;

                    cmd.Parameters.Add("@DescTipoRepresentacionBienHistorico", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoRepresentacionBienHistorico"].Value = tipoRepresentacionBienHistoricoDTO.DescTipoRepresentacionBienHistorico;

                    cmd.Parameters.Add("@CodigoTipoRepresentacionBienHistorico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoRepresentacionBienHistorico"].Value = tipoRepresentacionBienHistoricoDTO.CodigoTipoRepresentacionBienHistorico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoRepresentacionBienHistoricoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoRepresentacionBienHistorico(TipoRepresentacionBienHistoricoDTO tipoRepresentacionBienHistoricoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoRepresentacionBienHistoricoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoRepresentacionBienHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@TipoRepresentacionBienHistoricoId"].Value = tipoRepresentacionBienHistoricoDTO.TipoRepresentacionBienHistoricoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoRepresentacionBienHistoricoDTO.UsuarioIngresoRegistro;

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
