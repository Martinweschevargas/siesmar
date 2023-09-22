using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EjercicioEntrenamientoComfasubDAO
    {

        SqlCommand cmd = new();

        public List<EjercicioEntrenamientoComfasubDTO> ObtenerEjercicioEntrenamientoComfasubs()
        {
            List<EjercicioEntrenamientoComfasubDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoComfasubListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EjercicioEntrenamientoComfasubDTO()
                        {
                            EjercicioEntrenamientoComfasubId = Convert.ToInt32(dr["EjercicioEntrenamientoComfasubId"]),
                            CodigoEjercicioEntrenamiento = dr["CodigoEjercicioEntrenamiento"].ToString(),
                            DescEjercicioEntrenamiento = dr["DescEjercicioEntrenamiento"].ToString(),
                            DescCapacidadOperativa = dr["DescCapacidadOperativa"].ToString(),
                            NivelEjercicio = dr["NivelEjercicio"].ToString(),
                            VigenciaDiasClaseIslay = Convert.ToInt32(dr["VigenciaDiasClaseIslay"]),
                            VigenciaDiasClaseAngamos = Convert.ToInt32(dr["VigenciaDiasClaseAngamos"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEjercicioEntrenamientoComfasub(EjercicioEntrenamientoComfasubDTO ejercicioEntrenamientoComfasubDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoComfasubRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoCapacidadOperativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativa"].Value = ejercicioEntrenamientoComfasubDTO.CodigoCapacidadOperativa;

                    cmd.Parameters.Add("@DescEjercicioEntrenamiento", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescEjercicioEntrenamiento"].Value = ejercicioEntrenamientoComfasubDTO.DescEjercicioEntrenamiento;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamiento"].Value = ejercicioEntrenamientoComfasubDTO.CodigoEjercicioEntrenamiento;

                    cmd.Parameters.Add("@NivelEjercicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NivelEjercicio"].Value = ejercicioEntrenamientoComfasubDTO.NivelEjercicio;

                    cmd.Parameters.Add("@VigenciaDiasClaseIslay", SqlDbType.Int);
                    cmd.Parameters["@VigenciaDiasClaseIslay"].Value = ejercicioEntrenamientoComfasubDTO.VigenciaDiasClaseIslay;

                    cmd.Parameters.Add("@VigenciaDiasClaseAngamos", SqlDbType.Int);
                    cmd.Parameters["@VigenciaDiasClaseAngamos"].Value = ejercicioEntrenamientoComfasubDTO.VigenciaDiasClaseAngamos;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioEntrenamientoComfasubDTO.UsuarioIngresoRegistro;

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

        public EjercicioEntrenamientoComfasubDTO BuscarEjercicioEntrenamientoComfasubID(int Codigo)
        {
            EjercicioEntrenamientoComfasubDTO ejercicioEntrenamientoComfasubDTO = new EjercicioEntrenamientoComfasubDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoComfasubEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioEntrenamientoComfasubId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoComfasubId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ejercicioEntrenamientoComfasubDTO.EjercicioEntrenamientoComfasubId = Convert.ToInt32(dr["EjercicioEntrenamientoComfasubId"]);
                        ejercicioEntrenamientoComfasubDTO.CodigoEjercicioEntrenamiento = dr["CodigoEjercicioEntrenamiento"].ToString();
                        ejercicioEntrenamientoComfasubDTO.DescEjercicioEntrenamiento = dr["DescEjercicioEntrenamiento"].ToString();
                        ejercicioEntrenamientoComfasubDTO.CodigoCapacidadOperativa = dr["CodigoCapacidadOperativa"].ToString();
                        ejercicioEntrenamientoComfasubDTO.NivelEjercicio = dr["NivelEjercicio"].ToString();
                        ejercicioEntrenamientoComfasubDTO.VigenciaDiasClaseIslay = Convert.ToInt32(dr["VigenciaDiasClaseIslay"]);
                        ejercicioEntrenamientoComfasubDTO.VigenciaDiasClaseAngamos = Convert.ToInt32(dr["VigenciaDiasClaseAngamos"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ejercicioEntrenamientoComfasubDTO;
        }

        public string ActualizarEjercicioEntrenamientoComfasub(EjercicioEntrenamientoComfasubDTO ejercicioEntrenamientoComfasubDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoComfasubActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioEntrenamientoComfasubId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoComfasubId"].Value = ejercicioEntrenamientoComfasubDTO.EjercicioEntrenamientoComfasubId;

                    cmd.Parameters.Add("@CodigoCapacidadOperativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativa"].Value = ejercicioEntrenamientoComfasubDTO.CodigoCapacidadOperativa;

                    cmd.Parameters.Add("@DescEjercicioEntrenamiento", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescEjercicioEntrenamiento"].Value = ejercicioEntrenamientoComfasubDTO.DescEjercicioEntrenamiento;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamiento"].Value = ejercicioEntrenamientoComfasubDTO.CodigoEjercicioEntrenamiento;

                    cmd.Parameters.Add("@NivelEjercicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NivelEjercicio"].Value = ejercicioEntrenamientoComfasubDTO.NivelEjercicio;

                    cmd.Parameters.Add("@VigenciaDiasClaseIslay", SqlDbType.Int);
                    cmd.Parameters["@VigenciaDiasClaseIslay"].Value = ejercicioEntrenamientoComfasubDTO.VigenciaDiasClaseIslay;

                    cmd.Parameters.Add("@VigenciaDiasClaseAngamos", SqlDbType.Int);
                    cmd.Parameters["@VigenciaDiasClaseAngamos"].Value = ejercicioEntrenamientoComfasubDTO.VigenciaDiasClaseAngamos;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioEntrenamientoComfasubDTO.UsuarioIngresoRegistro;

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

        public string EliminarEjercicioEntrenamientoComfasub(EjercicioEntrenamientoComfasubDTO ejercicioEntrenamientoComfasubDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoComfasubEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioEntrenamientoComfasubId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoComfasubId"].Value = ejercicioEntrenamientoComfasubDTO.EjercicioEntrenamientoComfasubId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioEntrenamientoComfasubDTO.UsuarioIngresoRegistro;

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
