using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EjercicioEntrenamientoAspectoDAO
    {

        SqlCommand cmd = new();

        public List<EjercicioEntrenamientoAspectoDTO> ObtenerEjercicioEntrenamientoAspectos()
        {
            List<EjercicioEntrenamientoAspectoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoAspectoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EjercicioEntrenamientoAspectoDTO()
                        {
                            EjercicioEntrenamientoAspectoId = Convert.ToInt32(dr["EjercicioEntrenamientoAspectoId"]),
                            AspectoEvaluacion = dr["AspectoEvaluacion"].ToString(),
                            Peso = dr["Peso"].ToString(),
                            DescEjercicioEntrenamiento = dr["DescEjercicioEntrenamiento"].ToString(),
                            CodigoEjercicioEntrenamientoAspecto = dr["CodigoEjercicioEntrenamientoAspecto"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEjercicioEntrenamientoAspecto(EjercicioEntrenamientoAspectoDTO ejercicioEntrenamientoAspectoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoAspectoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AspectoEvaluacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@AspectoEvaluacion"].Value = ejercicioEntrenamientoAspectoDTO.AspectoEvaluacion;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamientoAspecto", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamientoAspecto"].Value = ejercicioEntrenamientoAspectoDTO.CodigoEjercicioEntrenamientoAspecto;

                    cmd.Parameters.Add("@Peso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Peso"].Value = ejercicioEntrenamientoAspectoDTO.Peso;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamiento"].Value = ejercicioEntrenamientoAspectoDTO.CodigoEjercicioEntrenamiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioEntrenamientoAspectoDTO.UsuarioIngresoRegistro;

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

        public EjercicioEntrenamientoAspectoDTO BuscarEjercicioEntrenamientoAspectoID(int Codigo)
        {
            EjercicioEntrenamientoAspectoDTO ejercicioEntrenamientoAspectoDTO = new EjercicioEntrenamientoAspectoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoAspectoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioEntrenamientoAspectoId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoAspectoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ejercicioEntrenamientoAspectoDTO.EjercicioEntrenamientoAspectoId = Convert.ToInt32(dr["EjercicioEntrenamientoAspectoId"]);
                        ejercicioEntrenamientoAspectoDTO.AspectoEvaluacion = dr["AspectoEvaluacion"].ToString();
                        ejercicioEntrenamientoAspectoDTO.Peso = dr["Peso"].ToString();
                        ejercicioEntrenamientoAspectoDTO.CodigoEjercicioEntrenamientoAspecto = dr["CodigoEjercicioEntrenamientoAspecto"].ToString();
                        ejercicioEntrenamientoAspectoDTO.CodigoEjercicioEntrenamiento = dr["CodigoEjercicioEntrenamiento"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ejercicioEntrenamientoAspectoDTO;
        }

        public string ActualizarEjercicioEntrenamientoAspecto(EjercicioEntrenamientoAspectoDTO ejercicioEntrenamientoAspectoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoAspectoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioEntrenamientoAspectoId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoAspectoId"].Value = ejercicioEntrenamientoAspectoDTO.EjercicioEntrenamientoAspectoId;

                    cmd.Parameters.Add("@AspectoEvaluacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@AspectoEvaluacion"].Value = ejercicioEntrenamientoAspectoDTO.AspectoEvaluacion;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamientoAspecto", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamientoAspecto"].Value = ejercicioEntrenamientoAspectoDTO.CodigoEjercicioEntrenamientoAspecto;

                    cmd.Parameters.Add("@Peso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Peso"].Value = ejercicioEntrenamientoAspectoDTO.Peso;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamiento"].Value = ejercicioEntrenamientoAspectoDTO.CodigoEjercicioEntrenamiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioEntrenamientoAspectoDTO.UsuarioIngresoRegistro;

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

        public string EliminarEjercicioEntrenamientoAspecto(EjercicioEntrenamientoAspectoDTO ejercicioEntrenamientoAspectoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoAspectoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioEntrenamientoAspectoId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoAspectoId"].Value = ejercicioEntrenamientoAspectoDTO.EjercicioEntrenamientoAspectoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioEntrenamientoAspectoDTO.UsuarioIngresoRegistro;

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
