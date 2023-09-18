using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EspecificacionNaveDAO
    {

        SqlCommand cmd = new();

        public List<EspecificacionNaveDTO> ObtenerEspecificacionNaves()
        {
            List<EspecificacionNaveDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EspecificacionNaveListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EspecificacionNaveDTO()
                        {
                            EspecificacionNaveId = Convert.ToInt32(dr["EspecificacionNaveId"]),
                            DescEspecificacionNave = dr["DescEspecificacionNave"].ToString(),
                            CodigoEspecificacionNave = dr["CodigoEspecificacionNave"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEspecificacionNave(EspecificacionNaveDTO especificacionNaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecificacionNaveRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescEspecificacionNave", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescEspecificacionNave"].Value = especificacionNaveDTO.DescEspecificacionNave;

                    cmd.Parameters.Add("@CodigoEspecificacionNave", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoEspecificacionNave"].Value = especificacionNaveDTO.CodigoEspecificacionNave;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = especificacionNaveDTO.UsuarioIngresoRegistro;

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

        public EspecificacionNaveDTO BuscarEspecificacionNaveID(int Codigo)
        {
            EspecificacionNaveDTO especificacionNaveDTO = new EspecificacionNaveDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecificacionNaveEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecificacionNaveId", SqlDbType.Int);
                    cmd.Parameters["@EspecificacionNaveId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        especificacionNaveDTO.EspecificacionNaveId = Convert.ToInt32(dr["EspecificacionNaveId"]);
                        especificacionNaveDTO.DescEspecificacionNave = dr["DescEspecificacionNave"].ToString();
                        especificacionNaveDTO.CodigoEspecificacionNave = dr["CodigoEspecificacionNave"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return especificacionNaveDTO;
        }

        public string ActualizarEspecificacionNave(EspecificacionNaveDTO especificacionNaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecificacionNaveActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecificacionNaveId", SqlDbType.Int);
                    cmd.Parameters["@EspecificacionNaveId"].Value = especificacionNaveDTO.EspecificacionNaveId;

                    cmd.Parameters.Add("@DescEspecificacionNave", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescEspecificacionNave"].Value = especificacionNaveDTO.DescEspecificacionNave;

                    cmd.Parameters.Add("@CodigoEspecificacionNave", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoEspecificacionNave"].Value = especificacionNaveDTO.CodigoEspecificacionNave;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = especificacionNaveDTO.UsuarioIngresoRegistro;

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

        public string EliminarEspecificacionNave(EspecificacionNaveDTO especificacionNaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecificacionNaveEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecificacionNaveId", SqlDbType.Int);
                    cmd.Parameters["@EspecificacionNaveId"].Value = especificacionNaveDTO.EspecificacionNaveId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = especificacionNaveDTO.UsuarioIngresoRegistro;

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
