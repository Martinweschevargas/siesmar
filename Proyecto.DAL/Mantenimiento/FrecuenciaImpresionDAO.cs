using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class FrecuenciaImpresionDAO
    {

        SqlCommand cmd = new();

        public List<FrecuenciaImpresionDTO> ObtenerFrecuenciaImpresions()
        {
            List<FrecuenciaImpresionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_FrecuenciaImpresionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new FrecuenciaImpresionDTO()
                        {
                            FrecuenciaImpresionId = Convert.ToInt32(dr["FrecuenciaImpresionId"]),
                            DescFrecuenciaImpresion = dr["DescFrecuenciaImpresion"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarFrecuenciaImpresion(FrecuenciaImpresionDTO frecuenciaImpresionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FrecuenciaImpresionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescFrecuenciaImpresion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescFrecuenciaImpresion"].Value = frecuenciaImpresionDTO.DescFrecuenciaImpresion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = frecuenciaImpresionDTO.UsuarioIngresoRegistro;

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

        public FrecuenciaImpresionDTO BuscarFrecuenciaImpresionID(int Codigo)
        {
            FrecuenciaImpresionDTO frecuenciaImpresionDTO = new FrecuenciaImpresionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FrecuenciaImpresionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FrecuenciaImpresionId", SqlDbType.Int);
                    cmd.Parameters["@FrecuenciaImpresionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        frecuenciaImpresionDTO.FrecuenciaImpresionId = Convert.ToInt32(dr["FrecuenciaImpresionId"]);
                        frecuenciaImpresionDTO.DescFrecuenciaImpresion = dr["DescFrecuenciaImpresion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return frecuenciaImpresionDTO;
        }

        public string ActualizarFrecuenciaImpresion(FrecuenciaImpresionDTO frecuenciaImpresionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FrecuenciaImpresionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FrecuenciaImpresionId", SqlDbType.Int);
                    cmd.Parameters["@FrecuenciaImpresionId"].Value = frecuenciaImpresionDTO.FrecuenciaImpresionId;

                    cmd.Parameters.Add("@DescFrecuenciaImpresion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescFrecuenciaImpresion"].Value = frecuenciaImpresionDTO.DescFrecuenciaImpresion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = frecuenciaImpresionDTO.UsuarioIngresoRegistro;

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

        public string EliminarFrecuenciaImpresion(FrecuenciaImpresionDTO frecuenciaImpresionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FrecuenciaImpresionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FrecuenciaImpresionId", SqlDbType.Int);
                    cmd.Parameters["@FrecuenciaImpresionId"].Value = frecuenciaImpresionDTO.FrecuenciaImpresionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = frecuenciaImpresionDTO.UsuarioIngresoRegistro;

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
