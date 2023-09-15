using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoSituacionTramiteDAO
    {

        SqlCommand cmd = new();

        public List<TipoSituacionTramiteDTO> ObtenerTipoSituacionTramites()
        {
            List<TipoSituacionTramiteDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoSituacionTramiteListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoSituacionTramiteDTO()
                        {
                            TipoSituacionTramiteId = Convert.ToInt32(dr["TipoSituacionTramiteId"]),
                            DescTipoSituacionTramite = dr["DescTipoSituacionTramite"].ToString(),
                            CodigoTipoSituacionTramite = dr["CodigoTipoSituacionTramite"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoSituacionTramite(TipoSituacionTramiteDTO tipoSituacionTramiteDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoSituacionTramiteRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoSituacionTramite", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoSituacionTramite"].Value = tipoSituacionTramiteDTO.DescTipoSituacionTramite;

                    cmd.Parameters.Add("@CodigoTipoSituacionTramite", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoSituacionTramite"].Value = tipoSituacionTramiteDTO.CodigoTipoSituacionTramite;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoSituacionTramiteDTO.UsuarioIngresoRegistro;

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

        public TipoSituacionTramiteDTO BuscarTipoSituacionTramiteID(int Codigo)
        {
            TipoSituacionTramiteDTO tipoSituacionTramiteDTO = new TipoSituacionTramiteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoSituacionTramiteEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoSituacionTramiteId", SqlDbType.Int);
                    cmd.Parameters["@TipoSituacionTramiteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoSituacionTramiteDTO.TipoSituacionTramiteId = Convert.ToInt32(dr["TipoSituacionTramiteId"]);
                        tipoSituacionTramiteDTO.DescTipoSituacionTramite = dr["DescTipoSituacionTramite"].ToString();
                        tipoSituacionTramiteDTO.CodigoTipoSituacionTramite = dr["CodigoTipoSituacionTramite"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoSituacionTramiteDTO;
        }

        public string ActualizarTipoSituacionTramite(TipoSituacionTramiteDTO tipoSituacionTramiteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoSituacionTramiteActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoSituacionTramiteId", SqlDbType.Int);
                    cmd.Parameters["@TipoSituacionTramiteId"].Value = tipoSituacionTramiteDTO.TipoSituacionTramiteId;

                    cmd.Parameters.Add("@DescTipoSituacionTramite", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoSituacionTramite"].Value = tipoSituacionTramiteDTO.DescTipoSituacionTramite;

                    cmd.Parameters.Add("@CodigoTipoSituacionTramite", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoSituacionTramite"].Value = tipoSituacionTramiteDTO.CodigoTipoSituacionTramite;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoSituacionTramiteDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoSituacionTramite(TipoSituacionTramiteDTO tipoSituacionTramiteDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoSituacionTramiteEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoSituacionTramiteId", SqlDbType.Int);
                    cmd.Parameters["@TipoSituacionTramiteId"].Value = tipoSituacionTramiteDTO.TipoSituacionTramiteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoSituacionTramiteDTO.UsuarioIngresoRegistro;

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
