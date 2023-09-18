using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoUnidadNavalInterventoraDAO
    {

        SqlCommand cmd = new();

        public List<TipoUnidadNavalInterventoraDTO> ObtenerTipoUnidadNavalInterventoras()
        {
            List<TipoUnidadNavalInterventoraDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoUnidadNavalInterventoraListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoUnidadNavalInterventoraDTO()
                        {
                            TipoUnidadNavalInterventoraId = Convert.ToInt32(dr["TipoUnidadNavalInterventoraId"]),
                            DescTipoUnidadNavalInterventora = dr["DescTipoUnidadNavalInterventora"].ToString(),
                            CodigoTipoUnidadNavalInterventora = dr["CodigoTipoUnidadNavalInterventora"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoUnidadNavalInterventora(TipoUnidadNavalInterventoraDTO TipoUnidadNavalInterventoraDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoUnidadNavalInterventoraRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoUnidadNavalInterventora", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoUnidadNavalInterventora"].Value = TipoUnidadNavalInterventoraDTO.DescTipoUnidadNavalInterventora;

                    cmd.Parameters.Add("@CodigoTipoUnidadNavalInterventora", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoUnidadNavalInterventora"].Value = TipoUnidadNavalInterventoraDTO.CodigoTipoUnidadNavalInterventora;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoUnidadNavalInterventoraDTO.UsuarioIngresoRegistro;

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

        public TipoUnidadNavalInterventoraDTO BuscarTipoUnidadNavalInterventoraID(int Codigo)
        {
            TipoUnidadNavalInterventoraDTO TipoUnidadNavalInterventoraDTO = new TipoUnidadNavalInterventoraDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoUnidadNavalInterventoraEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoUnidadNavalInterventoraId", SqlDbType.Int);
                    cmd.Parameters["@TipoUnidadNavalInterventoraId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        TipoUnidadNavalInterventoraDTO.TipoUnidadNavalInterventoraId = Convert.ToInt32(dr["TipoUnidadNavalInterventoraId"]);
                        TipoUnidadNavalInterventoraDTO.DescTipoUnidadNavalInterventora = dr["DescTipoUnidadNavalInterventora"].ToString();
                        TipoUnidadNavalInterventoraDTO.CodigoTipoUnidadNavalInterventora = dr["CodigoTipoUnidadNavalInterventora"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return TipoUnidadNavalInterventoraDTO;
        }

        public string ActualizarTipoUnidadNavalInterventora(TipoUnidadNavalInterventoraDTO TipoUnidadNavalInterventoraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoUnidadNavalInterventoraActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoUnidadNavalInterventoraId", SqlDbType.Int);
                    cmd.Parameters["@TipoUnidadNavalInterventoraId"].Value = TipoUnidadNavalInterventoraDTO.TipoUnidadNavalInterventoraId;

                    cmd.Parameters.Add("@DescTipoUnidadNavalInterventora", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoUnidadNavalInterventora"].Value = TipoUnidadNavalInterventoraDTO.DescTipoUnidadNavalInterventora;

                    cmd.Parameters.Add("@CodigoTipoUnidadNavalInterventora", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoUnidadNavalInterventora"].Value = TipoUnidadNavalInterventoraDTO.CodigoTipoUnidadNavalInterventora;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoUnidadNavalInterventoraDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoUnidadNavalInterventora(TipoUnidadNavalInterventoraDTO TipoUnidadNavalInterventoraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoUnidadNavalInterventoraEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoUnidadNavalInterventoraId", SqlDbType.Int);
                    cmd.Parameters["@TipoUnidadNavalInterventoraId"].Value = TipoUnidadNavalInterventoraDTO.TipoUnidadNavalInterventoraId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoUnidadNavalInterventoraDTO.UsuarioIngresoRegistro;

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
