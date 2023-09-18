using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ActividadIlicitaDAO
    {

        SqlCommand cmd = new();

        public List<ActividadIlicitaDTO> ObtenerActividadIlicitas()
        {
            List<ActividadIlicitaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ActividadIlicitaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ActividadIlicitaDTO()
                        {
                            ActividadIlicitaId = Convert.ToInt32(dr["ActividadIlicitaId"]),
                            DescActividadIlicita = dr["DescActividadIlicita"].ToString(),
                            CodigoActividadIlicita = dr["CodigoActividadIlicita"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarActividadIlicita(ActividadIlicitaDTO ActividadIlicitaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ActividadIlicitaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescActividadIlicita", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescActividadIlicita"].Value = ActividadIlicitaDTO.DescActividadIlicita;

                    cmd.Parameters.Add("@CodigoActividadIlicita", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoActividadIlicita"].Value = ActividadIlicitaDTO.CodigoActividadIlicita;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ActividadIlicitaDTO.UsuarioIngresoRegistro;

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

        public ActividadIlicitaDTO BuscarActividadIlicitaID(int Codigo)
        {
            ActividadIlicitaDTO ActividadIlicitaDTO = new ActividadIlicitaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ActividadIlicitaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadIlicitaId", SqlDbType.Int);
                    cmd.Parameters["@ActividadIlicitaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ActividadIlicitaDTO.ActividadIlicitaId = Convert.ToInt32(dr["ActividadIlicitaId"]);
                        ActividadIlicitaDTO.DescActividadIlicita = dr["DescActividadIlicita"].ToString();
                        ActividadIlicitaDTO.CodigoActividadIlicita = dr["CodigoActividadIlicita"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ActividadIlicitaDTO;
        }

        public string ActualizarActividadIlicita(ActividadIlicitaDTO ActividadIlicitaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ActividadIlicitaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadIlicitaId", SqlDbType.Int);
                    cmd.Parameters["@ActividadIlicitaId"].Value = ActividadIlicitaDTO.ActividadIlicitaId;

                    cmd.Parameters.Add("@DescActividadIlicita", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescActividadIlicita"].Value = ActividadIlicitaDTO.DescActividadIlicita;

                    cmd.Parameters.Add("@CodigoActividadIlicita", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoActividadIlicita"].Value = ActividadIlicitaDTO.CodigoActividadIlicita;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ActividadIlicitaDTO.UsuarioIngresoRegistro;

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

        public string EliminarActividadIlicita(ActividadIlicitaDTO ActividadIlicitaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ActividadIlicitaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadIlicitaId", SqlDbType.Int);
                    cmd.Parameters["@ActividadIlicitaId"].Value = ActividadIlicitaDTO.ActividadIlicitaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ActividadIlicitaDTO.UsuarioIngresoRegistro;

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
