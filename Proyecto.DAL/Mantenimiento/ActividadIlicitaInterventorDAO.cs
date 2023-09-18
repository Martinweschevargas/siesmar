using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ActividadIlicitaInterventorDAO
    {

        SqlCommand cmd = new();

        public List<ActividadIlicitaInterventorDTO> ObtenerActividadIlicitaInterventors()
        {
            List<ActividadIlicitaInterventorDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ActividadIlicitaInterventorListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ActividadIlicitaInterventorDTO()
                        {
                            ActividadIlicitaInterventorId = Convert.ToInt32(dr["ActividadIlicitaInterventorId"]),
                            CodUnidad = Convert.ToInt32(dr["CodUnidad"]),
                            DescActividadIlicita = dr["DescActividadIlicita"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarActividadIlicitaInterventor(ActividadIlicitaInterventorDTO actividadIlicitaInterventorDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ActividadIlicitaInterventorRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodUnidad", SqlDbType.Int);
                    cmd.Parameters["@CodUnidad"].Value = actividadIlicitaInterventorDTO.CodUnidad;

                    cmd.Parameters.Add("@ActividadIlicitaId", SqlDbType.Int);
                    cmd.Parameters["@ActividadIlicitaId"].Value = actividadIlicitaInterventorDTO.ActividadIlicitaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actividadIlicitaInterventorDTO.UsuarioIngresoRegistro;

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

        public ActividadIlicitaInterventorDTO BuscarActividadIlicitaInterventorID(int Codigo)
        {
            ActividadIlicitaInterventorDTO actividadIlicitaInterventorDTO = new ActividadIlicitaInterventorDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ActividadIlicitaInterventorEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadIlicitaInterventorId", SqlDbType.Int);
                    cmd.Parameters["@ActividadIlicitaInterventorId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        actividadIlicitaInterventorDTO.ActividadIlicitaInterventorId = Convert.ToInt32(dr["ActividadIlicitaInterventorId"]);
                        actividadIlicitaInterventorDTO.CodUnidad = Convert.ToInt32(dr["CodUnidad"]);
                        actividadIlicitaInterventorDTO.ActividadIlicitaId = Convert.ToInt32(dr["ActividadIlicitaId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return actividadIlicitaInterventorDTO;
        }

        public string ActualizarActividadIlicitaInterventor(ActividadIlicitaInterventorDTO actividadIlicitaInterventorDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ActividadIlicitaInterventorActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadIlicitaInterventorId", SqlDbType.Int);
                    cmd.Parameters["@ActividadIlicitaInterventorId"].Value = actividadIlicitaInterventorDTO.ActividadIlicitaInterventorId;

                    cmd.Parameters.Add("@CodUnidad", SqlDbType.Int);
                    cmd.Parameters["@CodUnidad"].Value = actividadIlicitaInterventorDTO.CodUnidad;

                    cmd.Parameters.Add("@ActividadIlicitaId", SqlDbType.Int);
                    cmd.Parameters["@ActividadIlicitaId"].Value = actividadIlicitaInterventorDTO.ActividadIlicitaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actividadIlicitaInterventorDTO.UsuarioIngresoRegistro;

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

        public string EliminarActividadIlicitaInterventor(ActividadIlicitaInterventorDTO ActividadIlicitaInterventorDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ActividadIlicitaInterventorEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadIlicitaInterventorId", SqlDbType.Int);
                    cmd.Parameters["@ActividadIlicitaInterventorId"].Value = ActividadIlicitaInterventorDTO.ActividadIlicitaInterventorId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ActividadIlicitaInterventorDTO.UsuarioIngresoRegistro;

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
