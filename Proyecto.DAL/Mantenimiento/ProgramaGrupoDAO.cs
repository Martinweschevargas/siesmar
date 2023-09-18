using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ProgramaGrupoDAO
    {

        SqlCommand cmd = new();

        public List<ProgramaGrupoDTO> ObtenerProgramaGrupos()
        {
            List<ProgramaGrupoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ProgramaGrupoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ProgramaGrupoDTO()
                        {
                            ProgramaGrupoId = Convert.ToInt32(dr["ProgramaGrupoId"]),
                            DescProgramaGrupo = dr["DescProgramaGrupo"].ToString(),
                            CodigoProgramaGrupo = dr["CodigoProgramaGrupo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarProgramaGrupo(ProgramaGrupoDTO programaGrupoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProgramaGrupoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescProgramaGrupo", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescProgramaGrupo"].Value = programaGrupoDTO.DescProgramaGrupo;

                    cmd.Parameters.Add("@CodigoProgramaGrupo", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoProgramaGrupo"].Value = programaGrupoDTO.CodigoProgramaGrupo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programaGrupoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                        }
                    }
                }
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public ProgramaGrupoDTO BuscarProgramaGrupoID(int Codigo)
        {
            ProgramaGrupoDTO programaGrupoDTO = new ProgramaGrupoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProgramaGrupoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProgramaGrupoId", SqlDbType.Int);
                    cmd.Parameters["@ProgramaGrupoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        programaGrupoDTO.ProgramaGrupoId = Convert.ToInt32(dr["ProgramaGrupoId"]);
                        programaGrupoDTO.DescProgramaGrupo = dr["DescProgramaGrupo"].ToString();
                        programaGrupoDTO.CodigoProgramaGrupo = dr["CodigoProgramaGrupo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return programaGrupoDTO;
        }

        public string ActualizarProgramaGrupo(ProgramaGrupoDTO programaGrupoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ProgramaGrupoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProgramaGrupoId", SqlDbType.Int);
                    cmd.Parameters["@ProgramaGrupoId"].Value = programaGrupoDTO.ProgramaGrupoId;

                    cmd.Parameters.Add("@DescProgramaGrupo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescProgramaGrupo"].Value = programaGrupoDTO.DescProgramaGrupo;

                    cmd.Parameters.Add("@CodigoProgramaGrupo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoProgramaGrupo"].Value = programaGrupoDTO.CodigoProgramaGrupo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programaGrupoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public bool EliminarProgramaGrupo(ProgramaGrupoDTO programaGrupoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProgramaGrupoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProgramaGrupoId", SqlDbType.Int);
                    cmd.Parameters["@ProgramaGrupoId"].Value = programaGrupoDTO.ProgramaGrupoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programaGrupoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    cmd.ExecuteNonQuery();
                    eliminado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return eliminado;
        }

    }
}
