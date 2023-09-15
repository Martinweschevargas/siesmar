using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ProcedimientoMedicoGrupoDAO
    {

        SqlCommand cmd = new();

        public List<ProcedimientoMedicoGrupoDTO> ObtenerProcedimientoMedicoGrupos()
        {
            List<ProcedimientoMedicoGrupoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ProcedimientoMedicoGrupoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ProcedimientoMedicoGrupoDTO()
                        {
                            ProcedimientoMedicoGrupoId = Convert.ToInt32(dr["ProcedimientoMedicoGrupoId"]),
                            DescProcedimientoMedicoGrupo = dr["DescProcedimientoMedicoGrupo"].ToString(),
                            CodigoProcedimientoMedicoGrupo = dr["CodigoProcedimientoMedicoGrupo"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarProcedimientoMedicoGrupo(ProcedimientoMedicoGrupoDTO procedimientoMedicoGrupoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProcedimientoMedicoGrupoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescProcedimientoMedicoGrupo", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescProcedimientoMedicoGrupo"].Value = procedimientoMedicoGrupoDTO.DescProcedimientoMedicoGrupo;

                    cmd.Parameters.Add("@CodigoProcedimientoMedicoGrupo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoProcedimientoMedicoGrupo"].Value = procedimientoMedicoGrupoDTO.CodigoProcedimientoMedicoGrupo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procedimientoMedicoGrupoDTO.UsuarioIngresoRegistro;

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

        public ProcedimientoMedicoGrupoDTO BuscarProcedimientoMedicoGrupoID(int Codigo)
        {
            ProcedimientoMedicoGrupoDTO procedimientoMedicoGrupoDTO = new ProcedimientoMedicoGrupoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProcedimientoMedicoGrupoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcedimientoMedicoGrupoId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoMedicoGrupoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        procedimientoMedicoGrupoDTO.ProcedimientoMedicoGrupoId = Convert.ToInt32(dr["ProcedimientoMedicoGrupoId"]);
                        procedimientoMedicoGrupoDTO.DescProcedimientoMedicoGrupo = dr["DescProcedimientoMedicoGrupo"].ToString();
                        procedimientoMedicoGrupoDTO.CodigoProcedimientoMedicoGrupo = dr["CodigoProcedimientoMedicoGrupo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return procedimientoMedicoGrupoDTO;
        }

        public string ActualizarProcedimientoMedicoGrupo(ProcedimientoMedicoGrupoDTO procedimientoMedicoGrupoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProcedimientoMedicoGrupoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcedimientoMedicoGrupoId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoMedicoGrupoId"].Value = procedimientoMedicoGrupoDTO.ProcedimientoMedicoGrupoId;

                    cmd.Parameters.Add("@DescProcedimientoMedicoGrupo", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescProcedimientoMedicoGrupo"].Value = procedimientoMedicoGrupoDTO.DescProcedimientoMedicoGrupo;

                    cmd.Parameters.Add("@CodigoProcedimientoMedicoGrupo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoProcedimientoMedicoGrupo"].Value = procedimientoMedicoGrupoDTO.CodigoProcedimientoMedicoGrupo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procedimientoMedicoGrupoDTO.UsuarioIngresoRegistro;

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

        public string EliminarProcedimientoMedicoGrupo(ProcedimientoMedicoGrupoDTO procedimientoMedicoGrupoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProcedimientoMedicoGrupoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcedimientoMedicoGrupoId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoMedicoGrupoId"].Value = procedimientoMedicoGrupoDTO.ProcedimientoMedicoGrupoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procedimientoMedicoGrupoDTO.UsuarioIngresoRegistro;

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
