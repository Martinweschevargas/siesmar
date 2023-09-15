using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EjercicioEntrenamientoComfasDAO
    {

        SqlCommand cmd = new();

        public List<EjercicioEntrenamientoComfasDTO> ObtenerEjercicioEntrenamientoComfass()
        {
            List<EjercicioEntrenamientoComfasDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoComfasListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EjercicioEntrenamientoComfasDTO()
                        {
                            EjercicioEntrenamientoComfasId = Convert.ToInt32(dr["EjercicioEntrenamientoComfasId"]),
                            DescCapacidadOperativa = dr["DescCapacidadOperativa"].ToString(),
                            DescEjercicioEntrenamientoComfas = dr["DescEjercicioEntrenamientoComfas"].ToString(),
                            CodigoEjercicioEntrenamientoComfas = dr["CodigoEjercicioEntrenamientoComfas"].ToString(),
                            NivelEjercicio = dr["NivelEjercicio"].ToString(),
                            FFMM = Convert.ToInt32(dr["FFMM"]),
                            CMM = Convert.ToInt32(dr["CMM"]),
                            DDTT = Convert.ToInt32(dr["DDTT"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEjercicioEntrenamientoComfas(EjercicioEntrenamientoComfasDTO ejercicioEntrenamientoComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoComfasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = ejercicioEntrenamientoComfasDTO.CapacidadOperativaId;

                    cmd.Parameters.Add("@DescEjercicioEntrenamientoComfas", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescEjercicioEntrenamientoComfas"].Value = ejercicioEntrenamientoComfasDTO.DescEjercicioEntrenamientoComfas;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamientoComfas", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoEjercicioEntrenamientoComfas"].Value = ejercicioEntrenamientoComfasDTO.CodigoEjercicioEntrenamientoComfas;

                    cmd.Parameters.Add("@NivelEjercicio", SqlDbType.VarChar, 1);
                    cmd.Parameters["@NivelEjercicio"].Value = ejercicioEntrenamientoComfasDTO.NivelEjercicio;

                    cmd.Parameters.Add("@FFMM", SqlDbType.Int);
                    cmd.Parameters["@FFMM"].Value = ejercicioEntrenamientoComfasDTO.FFMM;

                    cmd.Parameters.Add("@CMM", SqlDbType.Int);
                    cmd.Parameters["@CMM"].Value = ejercicioEntrenamientoComfasDTO.CMM;

                    cmd.Parameters.Add("@DDTT", SqlDbType.Int);
                    cmd.Parameters["@DDTT"].Value = ejercicioEntrenamientoComfasDTO.DDTT;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioEntrenamientoComfasDTO.UsuarioIngresoRegistro;

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

        public EjercicioEntrenamientoComfasDTO BuscarEjercicioEntrenamientoComfasID(int Codigo)
        {
            EjercicioEntrenamientoComfasDTO ejercicioEntrenamientoComfasDTO = new EjercicioEntrenamientoComfasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoComfasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioEntrenamientoComfasId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoComfasId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ejercicioEntrenamientoComfasDTO.EjercicioEntrenamientoComfasId = Convert.ToInt32(dr["EjercicioEntrenamientoComfasId"]);
                        ejercicioEntrenamientoComfasDTO.DescEjercicioEntrenamientoComfas = dr["DescEjercicioEntrenamientoComfas"].ToString();
                        ejercicioEntrenamientoComfasDTO.CodigoEjercicioEntrenamientoComfas = dr["CodigoEjercicioEntrenamientoComfas"].ToString();
                        ejercicioEntrenamientoComfasDTO.CapacidadOperativaId = Convert.ToInt32(dr["CapacidadOperativaId"]);
                        ejercicioEntrenamientoComfasDTO.NivelEjercicio = dr["NivelEjercicio"].ToString();
                        ejercicioEntrenamientoComfasDTO.FFMM = Convert.ToInt32(dr["FFMM"]);
                        ejercicioEntrenamientoComfasDTO.CMM = Convert.ToInt32(dr["CMM"]);
                        ejercicioEntrenamientoComfasDTO.DDTT = Convert.ToInt32(dr["DDTT"]);

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ejercicioEntrenamientoComfasDTO;
        }

        public string ActualizarEjercicioEntrenamientoComfas(EjercicioEntrenamientoComfasDTO ejercicioEntrenamientoComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoComfasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioEntrenamientoComfasId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoComfasId"].Value = ejercicioEntrenamientoComfasDTO.EjercicioEntrenamientoComfasId;


                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = ejercicioEntrenamientoComfasDTO.CapacidadOperativaId;

                    cmd.Parameters.Add("@DescEjercicioEntrenamientoComfas", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescEjercicioEntrenamientoComfas"].Value = ejercicioEntrenamientoComfasDTO.DescEjercicioEntrenamientoComfas;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamientoComfas", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoEjercicioEntrenamientoComfas"].Value = ejercicioEntrenamientoComfasDTO.CodigoEjercicioEntrenamientoComfas;

                    cmd.Parameters.Add("@NivelEjercicio", SqlDbType.VarChar, 1);
                    cmd.Parameters["@NivelEjercicio"].Value = ejercicioEntrenamientoComfasDTO.NivelEjercicio;

                    cmd.Parameters.Add("@FFMM", SqlDbType.Int);
                    cmd.Parameters["@FFMM"].Value = ejercicioEntrenamientoComfasDTO.FFMM;

                    cmd.Parameters.Add("@CMM", SqlDbType.Int);
                    cmd.Parameters["@CMM"].Value = ejercicioEntrenamientoComfasDTO.CMM;

                    cmd.Parameters.Add("@DDTT", SqlDbType.Int);
                    cmd.Parameters["@DDTT"].Value = ejercicioEntrenamientoComfasDTO.DDTT;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioEntrenamientoComfasDTO.UsuarioIngresoRegistro;

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

        public string EliminarEjercicioEntrenamientoComfas(EjercicioEntrenamientoComfasDTO ejercicioEntrenamientoComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoComfasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioEntrenamientoComfasId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoComfasId"].Value = ejercicioEntrenamientoComfasDTO.EjercicioEntrenamientoComfasId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioEntrenamientoComfasDTO.UsuarioIngresoRegistro;

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
