using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ProgramaEspecializacionGrupoDAO
    {

        SqlCommand cmd = new();

        public List<ProgramaEspecializacionGrupoDTO> ObtenerProgramaEspecializacionGrupos()
        {
            List<ProgramaEspecializacionGrupoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ProgramaEspecializacionGrupoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ProgramaEspecializacionGrupoDTO()
                        {
                            ProgramaEspecializacionGrupoId = Convert.ToInt32(dr["ProgramaEspecializacionGrupoId"]),
                            DescProgramaEspecializacionGrupo = dr["DescProgramaEspecializacionGrupo"].ToString(),
                            CodigoProgramaEspecializacionGrupo = dr["CodigoProgramaEspecializacionGrupo"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarProgramaEspecializacionGrupo(ProgramaEspecializacionGrupoDTO programaEspecializacionGrupoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProgramaEspecializacionGrupoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescProgramaEspecializacionGrupo", SqlDbType.VarChar, 300);
                    cmd.Parameters["@DescProgramaEspecializacionGrupo"].Value = programaEspecializacionGrupoDTO.DescProgramaEspecializacionGrupo;

                    cmd.Parameters.Add("@CodigoProgramaEspecializacionGrupo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoProgramaEspecializacionGrupo"].Value = programaEspecializacionGrupoDTO.CodigoProgramaEspecializacionGrupo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programaEspecializacionGrupoDTO.UsuarioIngresoRegistro;

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

        public ProgramaEspecializacionGrupoDTO BuscarProgramaEspecializacionGrupoID(int Codigo)
        {
            ProgramaEspecializacionGrupoDTO programaEspecializacionGrupoDTO = new ProgramaEspecializacionGrupoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProgramaEspecializacionGrupoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProgramaEspecializacionGrupoId", SqlDbType.Int);
                    cmd.Parameters["@ProgramaEspecializacionGrupoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        programaEspecializacionGrupoDTO.ProgramaEspecializacionGrupoId = Convert.ToInt32(dr["ProgramaEspecializacionGrupoId"]);
                        programaEspecializacionGrupoDTO.DescProgramaEspecializacionGrupo = dr["DescProgramaEspecializacionGrupo"].ToString();
                        programaEspecializacionGrupoDTO.CodigoProgramaEspecializacionGrupo = dr["CodigoProgramaEspecializacionGrupo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return programaEspecializacionGrupoDTO;
        }

        public string ActualizarProgramaEspecializacionGrupo(ProgramaEspecializacionGrupoDTO programaEspecializacionGrupoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProgramaEspecializacionGrupoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProgramaEspecializacionGrupoId", SqlDbType.Int);
                    cmd.Parameters["@ProgramaEspecializacionGrupoId"].Value = programaEspecializacionGrupoDTO.ProgramaEspecializacionGrupoId;

                    cmd.Parameters.Add("@DescProgramaEspecializacionGrupo", SqlDbType.VarChar, 300);
                    cmd.Parameters["@DescProgramaEspecializacionGrupo"].Value = programaEspecializacionGrupoDTO.DescProgramaEspecializacionGrupo;

                    cmd.Parameters.Add("@CodigoProgramaEspecializacionGrupo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoProgramaEspecializacionGrupo"].Value = programaEspecializacionGrupoDTO.CodigoProgramaEspecializacionGrupo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programaEspecializacionGrupoDTO.UsuarioIngresoRegistro;

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

        public string EliminarProgramaEspecializacionGrupo(ProgramaEspecializacionGrupoDTO programaEspecializacionGrupoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProgramaEspecializacionGrupoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProgramaEspecializacionGrupoId", SqlDbType.Int);
                    cmd.Parameters["@ProgramaEspecializacionGrupoId"].Value = programaEspecializacionGrupoDTO.ProgramaEspecializacionGrupoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programaEspecializacionGrupoDTO.UsuarioIngresoRegistro;

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
