
using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoActividadCulturalDAO
    {

        SqlCommand cmd = new();

        public List<TipoActividadCulturalDTO> ObtenerTipoActividadCulturals()
        {
            List<TipoActividadCulturalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoActividadCulturalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoActividadCulturalDTO()
                        {
                            TipoActividadCulturalId = Convert.ToInt32(dr["TipoActividadCulturalId"]),
                            DescTipoActividadCultural = dr["DescTipoActividadCultural"].ToString(),
                            CodigoTipoActividadCultural = dr["CodigoTipoActividadCultural"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoActividadCultural(TipoActividadCulturalDTO tipoActividadCulturalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoActividadCulturalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoActividadCultural", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescTipoActividadCultural"].Value = tipoActividadCulturalDTO.DescTipoActividadCultural;

                    cmd.Parameters.Add("@CodigoTipoActividadCultural", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoActividadCultural"].Value = tipoActividadCulturalDTO.CodigoTipoActividadCultural;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoActividadCulturalDTO.UsuarioIngresoRegistro;

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

        public TipoActividadCulturalDTO BuscarTipoActividadCulturalID(int Codigo)
        {
            TipoActividadCulturalDTO tipoActividadCulturalDTO = new TipoActividadCulturalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoActividadCulturalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoActividadCulturalId", SqlDbType.Int);
                    cmd.Parameters["@TipoActividadCulturalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoActividadCulturalDTO.TipoActividadCulturalId = Convert.ToInt32(dr["TipoActividadCulturalId"]);
                        tipoActividadCulturalDTO.DescTipoActividadCultural = dr["DescTipoActividadCultural"].ToString();
                        tipoActividadCulturalDTO.CodigoTipoActividadCultural = dr["CodigoTipoActividadCultural"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoActividadCulturalDTO;
        }

        public string ActualizarTipoActividadCultural(TipoActividadCulturalDTO tipoActividadCulturalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoActividadCulturalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoActividadCulturalId", SqlDbType.Int);
                    cmd.Parameters["@TipoActividadCulturalId"].Value = tipoActividadCulturalDTO.TipoActividadCulturalId;

                    cmd.Parameters.Add("@DescTipoActividadCultural", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoActividadCultural"].Value = tipoActividadCulturalDTO.DescTipoActividadCultural;

                    cmd.Parameters.Add("@CodigoTipoActividadCultural", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoActividadCultural"].Value = tipoActividadCulturalDTO.CodigoTipoActividadCultural;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoActividadCulturalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoActividadCultural(TipoActividadCulturalDTO tipoActividadCulturalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoActividadCulturalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoActividadCulturalId", SqlDbType.Int);
                    cmd.Parameters["@TipoActividadCulturalId"].Value = tipoActividadCulturalDTO.TipoActividadCulturalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoActividadCulturalDTO.UsuarioIngresoRegistro;

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
