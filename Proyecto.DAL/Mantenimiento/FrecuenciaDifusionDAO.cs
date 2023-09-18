using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class FrecuenciaDifusionDAO
    {

        SqlCommand cmd = new();

        public List<FrecuenciaDifusionDTO> ObtenerFrecuenciaDifusions()
        {
            List<FrecuenciaDifusionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_FrecuenciaDifusionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new FrecuenciaDifusionDTO()
                        {
                            FrecuenciaDifusionId = Convert.ToInt32(dr["FrecuenciaDifusionId"]),
                            DescFrecuenciaDifusion = dr["DescFrecuenciaDifusion"].ToString(),
                            CodigoFrecuenciaDifusion = dr["CodigoFrecuenciaDifusion"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarFrecuenciaDifusion(FrecuenciaDifusionDTO frecuenciaDifusionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FrecuenciaDifusionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescFrecuenciaDifusion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescFrecuenciaDifusion"].Value = frecuenciaDifusionDTO.DescFrecuenciaDifusion;

                    cmd.Parameters.Add("@CodigoFrecuenciaDifusion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoFrecuenciaDifusion"].Value = frecuenciaDifusionDTO.CodigoFrecuenciaDifusion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = frecuenciaDifusionDTO.UsuarioIngresoRegistro;

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

        public FrecuenciaDifusionDTO BuscarFrecuenciaDifusionID(int Codigo)
        {
            FrecuenciaDifusionDTO frecuenciaDifusionDTO = new FrecuenciaDifusionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FrecuenciaDifusionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FrecuenciaDifusionId", SqlDbType.Int);
                    cmd.Parameters["@FrecuenciaDifusionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        frecuenciaDifusionDTO.FrecuenciaDifusionId = Convert.ToInt32(dr["FrecuenciaDifusionId"]);
                        frecuenciaDifusionDTO.DescFrecuenciaDifusion = dr["DescFrecuenciaDifusion"].ToString();
                        frecuenciaDifusionDTO.CodigoFrecuenciaDifusion = dr["CodigoFrecuenciaDifusion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return frecuenciaDifusionDTO;
        }

        public string ActualizarFrecuenciaDifusion(FrecuenciaDifusionDTO frecuenciaDifusionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FrecuenciaDifusionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FrecuenciaDifusionId", SqlDbType.Int);
                    cmd.Parameters["@FrecuenciaDifusionId"].Value = frecuenciaDifusionDTO.FrecuenciaDifusionId;

                    cmd.Parameters.Add("@DescFrecuenciaDifusion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescFrecuenciaDifusion"].Value = frecuenciaDifusionDTO.DescFrecuenciaDifusion;

                    cmd.Parameters.Add("@CodigoFrecuenciaDifusion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoFrecuenciaDifusion"].Value = frecuenciaDifusionDTO.CodigoFrecuenciaDifusion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = frecuenciaDifusionDTO.UsuarioIngresoRegistro;

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

        public string EliminarFrecuenciaDifusion(FrecuenciaDifusionDTO frecuenciaDifusionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FrecuenciaDifusionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FrecuenciaDifusionId", SqlDbType.Int);
                    cmd.Parameters["@FrecuenciaDifusionId"].Value = frecuenciaDifusionDTO.FrecuenciaDifusionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = frecuenciaDifusionDTO.UsuarioIngresoRegistro;

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
