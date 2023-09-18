using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EjercicioEntrenamientoComfoeDAO
    {

        SqlCommand cmd = new();

        public List<EjercicioEntrenamientoComfoeDTO> ObtenerEjercicioEntrenamientoComfoes()
        {
            List<EjercicioEntrenamientoComfoeDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoComfoeListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EjercicioEntrenamientoComfoeDTO()
                        {
                            EjercicioEntrenamientoComfoeId = Convert.ToInt32(dr["EjercicioEntrenamientoComfoeId"]),
                            DescTipoCompetenciaTecnica = dr["DescTipoCompetenciaTecnica"].ToString(),
                            CodigoEjercicioEntrenamientoComfoe = dr["CodigoEjercicioEntrenamientoComfoe"].ToString(),
                            DescripcionEjercicioEntrenamiento = dr["DescripcionEjercicioEntrenamiento"].ToString(),
                            Nivel = dr["Nivel"].ToString(),
                            VigenciaDia = Convert.ToInt32(dr["VigenciaDia"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEjercicioEntrenamientoComfoe(EjercicioEntrenamientoComfoeDTO EjercicioEntrenamientoComfoeDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoComfoeRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoTipoCompetenciaTecnica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoCompetenciaTecnica"].Value = EjercicioEntrenamientoComfoeDTO.CodigoTipoCompetenciaTecnica;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamientoComfoe", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamientoComfoe"].Value = EjercicioEntrenamientoComfoeDTO.CodigoEjercicioEntrenamientoComfoe;

                    cmd.Parameters.Add("@DescripcionEjercicioEntrenamiento", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescripcionEjercicioEntrenamiento"].Value = EjercicioEntrenamientoComfoeDTO.DescripcionEjercicioEntrenamiento;

                    cmd.Parameters.Add("@Nivel", SqlDbType.VarChar, 10);
                    cmd.Parameters["@Nivel"].Value = EjercicioEntrenamientoComfoeDTO.Nivel;

                    cmd.Parameters.Add("@VigenciaDia", SqlDbType.Int);
                    cmd.Parameters["@VigenciaDia"].Value = EjercicioEntrenamientoComfoeDTO.VigenciaDia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = EjercicioEntrenamientoComfoeDTO.UsuarioIngresoRegistro;

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

        public EjercicioEntrenamientoComfoeDTO BuscarEjercicioEntrenamientoComfoeID(int Codigo)
        {
            EjercicioEntrenamientoComfoeDTO EjercicioEntrenamientoComfoeDTO = new EjercicioEntrenamientoComfoeDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoComfoeEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioEntrenamientoComfoeId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoComfoeId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        EjercicioEntrenamientoComfoeDTO.EjercicioEntrenamientoComfoeId = Convert.ToInt32(dr["EjercicioEntrenamientoComfoeId"]);
                        EjercicioEntrenamientoComfoeDTO.CodigoTipoCompetenciaTecnica = dr["CodigoTipoCompetenciaTecnica"].ToString();
                        EjercicioEntrenamientoComfoeDTO.DescripcionEjercicioEntrenamiento = dr["DescripcionEjercicioEntrenamiento"].ToString();
                        EjercicioEntrenamientoComfoeDTO.CodigoEjercicioEntrenamientoComfoe = dr["CodigoEjercicioEntrenamientoComfoe"].ToString();
                        EjercicioEntrenamientoComfoeDTO.Nivel = dr["Nivel"].ToString();
                        EjercicioEntrenamientoComfoeDTO.VigenciaDia = Convert.ToInt32(dr["VigenciaDia"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return EjercicioEntrenamientoComfoeDTO;
        }

        public string ActualizarEjercicioEntrenamientoComfoe(EjercicioEntrenamientoComfoeDTO EjercicioEntrenamientoComfoeDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoComfoeActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioEntrenamientoComfoeId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoComfoeId"].Value = EjercicioEntrenamientoComfoeDTO.EjercicioEntrenamientoComfoeId;

                    cmd.Parameters.Add("@CodigoTipoCompetenciaTecnica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoCompetenciaTecnica"].Value = EjercicioEntrenamientoComfoeDTO.CodigoTipoCompetenciaTecnica;

                    cmd.Parameters.Add("@DescripcionEjercicioEntrenamiento", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescripcionEjercicioEntrenamiento"].Value = EjercicioEntrenamientoComfoeDTO.DescripcionEjercicioEntrenamiento;

                    cmd.Parameters.Add("@CodigoEjercicioEntrenamientoComfoe", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEjercicioEntrenamientoComfoe"].Value = EjercicioEntrenamientoComfoeDTO.CodigoEjercicioEntrenamientoComfoe;

                    cmd.Parameters.Add("@Nivel", SqlDbType.VarChar, 10);
                    cmd.Parameters["@Nivel"].Value = EjercicioEntrenamientoComfoeDTO.Nivel;

                    cmd.Parameters.Add("@VigenciaDia", SqlDbType.Int);
                    cmd.Parameters["@VigenciaDia"].Value = EjercicioEntrenamientoComfoeDTO.VigenciaDia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = EjercicioEntrenamientoComfoeDTO.UsuarioIngresoRegistro;

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

        public string EliminarEjercicioEntrenamientoComfoe(EjercicioEntrenamientoComfoeDTO EjercicioEntrenamientoComfoeDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EjercicioEntrenamientoComfoeEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioEntrenamientoComfoeId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioEntrenamientoComfoeId"].Value = EjercicioEntrenamientoComfoeDTO.EjercicioEntrenamientoComfoeId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = EjercicioEntrenamientoComfoeDTO.UsuarioIngresoRegistro;

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
