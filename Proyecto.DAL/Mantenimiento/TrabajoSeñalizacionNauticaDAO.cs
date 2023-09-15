using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TrabajoSeñalizacionNauticaDAO
    {

        SqlCommand cmd = new();

        public List<TrabajoSeñalizacionNauticaDTO> ObtenerTrabajoSeñalizacionNauticas()
        {
            List<TrabajoSeñalizacionNauticaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TrabajoSenializacionNauticaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TrabajoSeñalizacionNauticaDTO()
                        {
                            TrabajoSeñalizacionNauticaId = Convert.ToInt32(dr["TrabajoSenializacionNauticaId"]),
                            DescTrabajoSeñalizacionNautica = dr["DescTrabajoSenializacionNautica"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTrabajoSeñalizacionNautica(TrabajoSeñalizacionNauticaDTO trabajoSeñalizacionNauticaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TrabajoSenializacionNauticaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTrabajoSenializacionNautica", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTrabajoSenializacionNautica"].Value = trabajoSeñalizacionNauticaDTO.DescTrabajoSeñalizacionNautica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = trabajoSeñalizacionNauticaDTO.UsuarioIngresoRegistro;

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

        public TrabajoSeñalizacionNauticaDTO BuscarTrabajoSeñalizacionNauticaID(int Codigo)
        {
            TrabajoSeñalizacionNauticaDTO trabajoSeñalizacionNauticaDTO = new TrabajoSeñalizacionNauticaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TrabajoSenializacionNauticaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TrabajoSenializacionNauticaId", SqlDbType.Int);
                    cmd.Parameters["@TrabajoSenializacionNauticaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        trabajoSeñalizacionNauticaDTO.TrabajoSeñalizacionNauticaId = Convert.ToInt32(dr["TrabajoSenializacionNauticaId"]);
                        trabajoSeñalizacionNauticaDTO.DescTrabajoSeñalizacionNautica = dr["DescTrabajoSenializacionNautica"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return trabajoSeñalizacionNauticaDTO;
        }

        public string ActualizarTrabajoSeñalizacionNautica(TrabajoSeñalizacionNauticaDTO trabajoSeñalizacionNauticaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TrabajoSenializacionNauticaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TrabajoSenializacionNauticaId", SqlDbType.Int);
                    cmd.Parameters["@TrabajoSenializacionNauticaId"].Value = trabajoSeñalizacionNauticaDTO.TrabajoSeñalizacionNauticaId;

                    cmd.Parameters.Add("@DescTrabajoSenializacionNautica", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTrabajoSenializacionNautica"].Value = trabajoSeñalizacionNauticaDTO.DescTrabajoSeñalizacionNautica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = trabajoSeñalizacionNauticaDTO.UsuarioIngresoRegistro;

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

        public string EliminarTrabajoSeñalizacionNautica(TrabajoSeñalizacionNauticaDTO trabajoSeñalizacionNauticaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TrabajoSenializacionNauticaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TrabajoSenializacionNauticaId", SqlDbType.Int);
                    cmd.Parameters["@TrabajoSenializacionNauticaId"].Value = trabajoSeñalizacionNauticaDTO.TrabajoSeñalizacionNauticaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = trabajoSeñalizacionNauticaDTO.UsuarioIngresoRegistro;

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
