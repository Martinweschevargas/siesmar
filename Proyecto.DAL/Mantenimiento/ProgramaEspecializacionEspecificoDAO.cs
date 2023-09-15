using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ProgramaEspecializacionEspecificoDAO
    {

        SqlCommand cmd = new();

        public List<ProgramaEspecializacionEspecificoDTO> ObtenerProgramaEspecializacionEspecificos()
        {
            List<ProgramaEspecializacionEspecificoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ProgramaEspecializacionEspecificoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ProgramaEspecializacionEspecificoDTO()
                        {
                            ProgramaEspecializacionEspecificoId = Convert.ToInt32(dr["ProgramaEspecializacionEspecificoId"]),
                            DescProgramaEspecializacionEspecifico = dr["DescProgramaEspecializacionEspecifico"].ToString(),
                            CodigoProgramaEspecializacionEspecifico = dr["CodigoProgramaEspecializacionEspecifico"].ToString(),
                            DescProgramaEspecializacionGrupo = dr["DescProgramaEspecializacionGrupo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarProgramaEspecializacionEspecifico(ProgramaEspecializacionEspecificoDTO programaEspecializacionEspecificoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProgramaEspecializacionEspecificoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescProgramaEspecializacionEspecifico", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescProgramaEspecializacionEspecifico"].Value = programaEspecializacionEspecificoDTO.DescProgramaEspecializacionEspecifico;

                    cmd.Parameters.Add("@CodigoProgramaEspecializacionEspecifico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoProgramaEspecializacionEspecifico"].Value = programaEspecializacionEspecificoDTO.CodigoProgramaEspecializacionEspecifico;

                    cmd.Parameters.Add("@ProgramaEspecializacionGrupoId", SqlDbType.Int);
                    cmd.Parameters["@ProgramaEspecializacionGrupoId"].Value = programaEspecializacionEspecificoDTO.ProgramaEspecializacionGrupoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programaEspecializacionEspecificoDTO.UsuarioIngresoRegistro;

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

        public ProgramaEspecializacionEspecificoDTO BuscarProgramaEspecializacionEspecificoID(int Codigo)
        {
            ProgramaEspecializacionEspecificoDTO programaEspecializacionEspecificoDTO = new ProgramaEspecializacionEspecificoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProgramaEspecializacionEspecificoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProgramaEspecializacionEspecificoId", SqlDbType.Int);
                    cmd.Parameters["@ProgramaEspecializacionEspecificoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        programaEspecializacionEspecificoDTO.ProgramaEspecializacionEspecificoId = Convert.ToInt32(dr["ProgramaEspecializacionEspecificoId"]);
                        programaEspecializacionEspecificoDTO.DescProgramaEspecializacionEspecifico = dr["DescProgramaEspecializacionEspecifico"].ToString();
                        programaEspecializacionEspecificoDTO.CodigoProgramaEspecializacionEspecifico = dr["CodigoProgramaEspecializacionEspecifico"].ToString();
                        programaEspecializacionEspecificoDTO.ProgramaEspecializacionGrupoId = Convert.ToInt32(dr["ProgramaEspecializacionGrupoId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return programaEspecializacionEspecificoDTO;
        }

        public string ActualizarProgramaEspecializacionEspecifico(ProgramaEspecializacionEspecificoDTO programaEspecializacionEspecificoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ProgramaEspecializacionEspecificoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProgramaEspecializacionEspecificoId", SqlDbType.Int);
                    cmd.Parameters["@ProgramaEspecializacionEspecificoId"].Value = programaEspecializacionEspecificoDTO.ProgramaEspecializacionEspecificoId;

                    cmd.Parameters.Add("@DescProgramaEspecializacionEspecifico", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescProgramaEspecializacionEspecifico"].Value = programaEspecializacionEspecificoDTO.DescProgramaEspecializacionEspecifico;

                    cmd.Parameters.Add("@CodigoProgramaEspecializacionEspecifico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoProgramaEspecializacionEspecifico"].Value = programaEspecializacionEspecificoDTO.CodigoProgramaEspecializacionEspecifico;

                    cmd.Parameters.Add("@ProgramaEspecializacionGrupoId", SqlDbType.Int);
                    cmd.Parameters["@ProgramaEspecializacionGrupoId"].Value = programaEspecializacionEspecificoDTO.ProgramaEspecializacionGrupoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programaEspecializacionEspecificoDTO.UsuarioIngresoRegistro;

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

        public string EliminarProgramaEspecializacionEspecifico(ProgramaEspecializacionEspecificoDTO programaEspecializacionEspecificoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProgramaEspecializacionEspecificoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProgramaEspecializacionEspecificoId", SqlDbType.Int);
                    cmd.Parameters["@ProgramaEspecializacionEspecificoId"].Value = programaEspecializacionEspecificoDTO.ProgramaEspecializacionEspecificoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programaEspecializacionEspecificoDTO.UsuarioIngresoRegistro;

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
