using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoTransgresionDAO
    {

        SqlCommand cmd = new();

        public List<TipoTransgresionDTO> ObtenerTipoTransgresions()
        {
            List<TipoTransgresionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoTransgresionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoTransgresionDTO()
                        {
                            TipoTransgresionId = Convert.ToInt32(dr["TipoTransgresionId"]),
                            DescTipoTransgresion = dr["DescTipoTransgresion"].ToString(),
                            CodigoTipoTransgresion = dr["CodigoTipoTransgresion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoTransgresion(TipoTransgresionDTO tipoTransgresionDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoTransgresionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoTransgresion", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoTransgresion"].Value = tipoTransgresionDTO.DescTipoTransgresion;

                    cmd.Parameters.Add("@CodigoTipoTransgresion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoTransgresion"].Value = tipoTransgresionDTO.CodigoTipoTransgresion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoTransgresionDTO.UsuarioIngresoRegistro;

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

        public TipoTransgresionDTO BuscarTipoTransgresionID(int Codigo)
        {
            TipoTransgresionDTO tipoTransgresionDTO = new TipoTransgresionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoTransgresionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoTransgresionId", SqlDbType.Int);
                    cmd.Parameters["@TipoTransgresionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoTransgresionDTO.TipoTransgresionId = Convert.ToInt32(dr["TipoTransgresionId"]);
                        tipoTransgresionDTO.DescTipoTransgresion = dr["DescTipoTransgresion"].ToString();
                        tipoTransgresionDTO.CodigoTipoTransgresion = dr["CodigoTipoTransgresion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoTransgresionDTO;
        }

        public string ActualizarTipoTransgresion(TipoTransgresionDTO tipoTransgresionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoTransgresionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoTransgresionId", SqlDbType.Int);
                    cmd.Parameters["@TipoTransgresionId"].Value = tipoTransgresionDTO.TipoTransgresionId;

                    cmd.Parameters.Add("@DescTipoTransgresion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoTransgresion"].Value = tipoTransgresionDTO.DescTipoTransgresion;

                    cmd.Parameters.Add("@CodigoTipoTransgresion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoTransgresion"].Value = tipoTransgresionDTO.CodigoTipoTransgresion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoTransgresionDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoTransgresion(TipoTransgresionDTO tipoTransgresionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoTransgresionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoTransgresionId", SqlDbType.Int);
                    cmd.Parameters["@TipoTransgresionId"].Value = tipoTransgresionDTO.TipoTransgresionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoTransgresionDTO.UsuarioIngresoRegistro;

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
