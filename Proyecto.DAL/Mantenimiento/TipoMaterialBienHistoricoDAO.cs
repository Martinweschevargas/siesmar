
using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoMaterialBienHistoricoDAO
    {

        SqlCommand cmd = new();

        public List<TipoMaterialBienHistoricoDTO> ObtenerTipoMaterialBienHistoricos()
        {
            List<TipoMaterialBienHistoricoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoMaterialBienHistoricoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoMaterialBienHistoricoDTO()
                        {
                            TipoMaterialBienHistoricoId = Convert.ToInt32(dr["TipoMaterialBienHistoricoId"]),
                            DescTipoMaterialBienHistorico = dr["DescTipoMaterialBienHistorico"].ToString(),
                            CodigoTipoMaterialBienHistorico = dr["CodigoTipoMaterialBienHistorico"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoMaterialBienHistorico(TipoMaterialBienHistoricoDTO tipoMaterialBienHistoricoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoMaterialBienHistoricoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoMaterialBienHistorico", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescTipoMaterialBienHistorico"].Value = tipoMaterialBienHistoricoDTO.DescTipoMaterialBienHistorico;

                    cmd.Parameters.Add("@CodigoTipoMaterialBienHistorico", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoMaterialBienHistorico"].Value = tipoMaterialBienHistoricoDTO.CodigoTipoMaterialBienHistorico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoMaterialBienHistoricoDTO.UsuarioIngresoRegistro;

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

        public TipoMaterialBienHistoricoDTO BuscarTipoMaterialBienHistoricoID(int Codigo)
        {
            TipoMaterialBienHistoricoDTO tipoMaterialBienHistoricoDTO = new TipoMaterialBienHistoricoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoMaterialBienHistoricoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoMaterialBienHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@TipoMaterialBienHistoricoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoMaterialBienHistoricoDTO.TipoMaterialBienHistoricoId = Convert.ToInt32(dr["TipoMaterialBienHistoricoId"]);
                        tipoMaterialBienHistoricoDTO.DescTipoMaterialBienHistorico = dr["DescTipoMaterialBienHistorico"].ToString();
                        tipoMaterialBienHistoricoDTO.CodigoTipoMaterialBienHistorico = dr["CodigoTipoMaterialBienHistorico"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoMaterialBienHistoricoDTO;
        }

        public string ActualizarTipoMaterialBienHistorico(TipoMaterialBienHistoricoDTO tipoMaterialBienHistoricoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoMaterialBienHistoricoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoMaterialBienHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@TipoMaterialBienHistoricoId"].Value = tipoMaterialBienHistoricoDTO.TipoMaterialBienHistoricoId;

                    cmd.Parameters.Add("@DescTipoMaterialBienHistorico", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoMaterialBienHistorico"].Value = tipoMaterialBienHistoricoDTO.DescTipoMaterialBienHistorico;

                    cmd.Parameters.Add("@CodigoTipoMaterialBienHistorico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoMaterialBienHistorico"].Value = tipoMaterialBienHistoricoDTO.CodigoTipoMaterialBienHistorico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoMaterialBienHistoricoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoMaterialBienHistorico(TipoMaterialBienHistoricoDTO tipoMaterialBienHistoricoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoMaterialBienHistoricoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoMaterialBienHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@TipoMaterialBienHistoricoId"].Value = tipoMaterialBienHistoricoDTO.TipoMaterialBienHistoricoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoMaterialBienHistoricoDTO.UsuarioIngresoRegistro;

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
