using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class GradoRemunerativoGrupoDAO
    {

        SqlCommand cmd = new();

        public List<GradoRemunerativoGrupoDTO> ObtenerGradoRemunerativoGrupos()
        {
            List<GradoRemunerativoGrupoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_GradoRemunerativoGrupoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new GradoRemunerativoGrupoDTO()
                        {
                            GradoRemunerativoGrupoId = Convert.ToInt32(dr["GradoRemunerativoGrupoId"]),
                            DescGradoRemunerativoGrupo = dr["DescGradoRemunerativoGrupo"].ToString(),
                            DescGrupoRemunerativo = dr["DescGrupoRemunerativo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarGradoRemunerativoGrupo(GradoRemunerativoGrupoDTO gradoRemunerativoGrupoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoRemunerativoGrupoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescGradoRemunerativoGrupo", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescGradoRemunerativoGrupo"].Value = gradoRemunerativoGrupoDTO.DescGradoRemunerativoGrupo;

                    cmd.Parameters.Add("@GrupoRemunerativoId", SqlDbType.Int);
                    cmd.Parameters["@GrupoRemunerativoId"].Value = gradoRemunerativoGrupoDTO.GrupoRemunerativoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = gradoRemunerativoGrupoDTO.UsuarioIngresoRegistro;

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

        public GradoRemunerativoGrupoDTO BuscarGradoRemunerativoGrupoID(int Codigo)
        {
            GradoRemunerativoGrupoDTO gradoRemunerativoGrupoDTO = new GradoRemunerativoGrupoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoRemunerativoGrupoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GradoRemunerativoGrupoId", SqlDbType.Int);
                    cmd.Parameters["@GradoRemunerativoGrupoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        gradoRemunerativoGrupoDTO.GradoRemunerativoGrupoId = Convert.ToInt32(dr["GradoRemunerativoGrupoId"]);
                        gradoRemunerativoGrupoDTO.DescGradoRemunerativoGrupo = dr["DescGradoRemunerativoGrupo"].ToString();
                        gradoRemunerativoGrupoDTO.GrupoRemunerativoId = Convert.ToInt32(dr["GrupoRemunerativoId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return gradoRemunerativoGrupoDTO;
        }

        public string ActualizarGradoRemunerativoGrupo(GradoRemunerativoGrupoDTO gradoRemunerativoGrupoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoRemunerativoGrupoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GradoRemunerativoGrupoId", SqlDbType.Int);
                    cmd.Parameters["@GradoRemunerativoGrupoId"].Value = gradoRemunerativoGrupoDTO.GradoRemunerativoGrupoId;

                    cmd.Parameters.Add("@DescGradoRemunerativoGrupo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescGradoRemunerativoGrupo"].Value = gradoRemunerativoGrupoDTO.DescGradoRemunerativoGrupo;

                    cmd.Parameters.Add("@GrupoRemunerativoId", SqlDbType.Int);
                    cmd.Parameters["@GrupoRemunerativoId"].Value = gradoRemunerativoGrupoDTO.GrupoRemunerativoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = gradoRemunerativoGrupoDTO.UsuarioIngresoRegistro;

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

        public string EliminarGradoRemunerativoGrupo(GradoRemunerativoGrupoDTO gradoRemunerativoGrupoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoRemunerativoGrupoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GradoRemunerativoGrupoId", SqlDbType.Int);
                    cmd.Parameters["@GradoRemunerativoGrupoId"].Value = gradoRemunerativoGrupoDTO.GradoRemunerativoGrupoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = gradoRemunerativoGrupoDTO.UsuarioIngresoRegistro;

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
