using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EjercicioEntrenamientoDAO
    {

        SqlCommand cmd = new();

        public List<EjercicioEntrenamientoDTO> ObtenerEjercicioEntrenamientos()
        {
            List<EjercicioEntrenamientoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EjercicioEntrenamientoDTO()
                        {
                            EjercicioEntrenamientoId = Convert.ToInt32(dr["EjercicioEntrenamientoId"]),
                            DescEjercicioEntrenamiento = dr["DescEjercicioEntrenamiento"].ToString(),
                            CodigoEjercicioEntrenamiento = dr["CodigoEjercicioEntrenamiento"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEjercicioEntrenamiento(EjercicioEntrenamientoDTO ejercicioEntrenamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescEjercicioEntrenamiento", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescEjercicioEntrenamiento"].Value = ejercicioEntrenamientoDTO.DescEjercicioEntrenamiento;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamiento"].Value = ejercicioEntrenamientoDTO.CodigoEjercicioEntrenamiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioEntrenamientoDTO.UsuarioIngresoRegistro;

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

        public EjercicioEntrenamientoDTO BuscarEjercicioEntrenamientoID(int Codigo)
        {
            EjercicioEntrenamientoDTO ejercicioEntrenamientoDTO = new EjercicioEntrenamientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ejercicioEntrenamientoDTO.EjercicioEntrenamientoId = Convert.ToInt32(dr["EjercicioEntrenamientoId"]);
                        ejercicioEntrenamientoDTO.DescEjercicioEntrenamiento = dr["DescEjercicioEntrenamiento"].ToString();
                        ejercicioEntrenamientoDTO.CodigoEjercicioEntrenamiento = dr["CodigoEjercicioEntrenamiento"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ejercicioEntrenamientoDTO;
        }

        public string ActualizarEjercicioEntrenamiento(EjercicioEntrenamientoDTO ejercicioEntrenamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoId"].Value = ejercicioEntrenamientoDTO.EjercicioEntrenamientoId;

                    cmd.Parameters.Add("@DescEjercicioEntrenamiento", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescEjercicioEntrenamiento"].Value = ejercicioEntrenamientoDTO.DescEjercicioEntrenamiento;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamiento"].Value = ejercicioEntrenamientoDTO.CodigoEjercicioEntrenamiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioEntrenamientoDTO.UsuarioIngresoRegistro;

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

        public string EliminarEjercicioEntrenamiento(EjercicioEntrenamientoDTO ejercicioEntrenamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioEntrenamientoId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoId"].Value = ejercicioEntrenamientoDTO.EjercicioEntrenamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioEntrenamientoDTO.UsuarioIngresoRegistro;

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
