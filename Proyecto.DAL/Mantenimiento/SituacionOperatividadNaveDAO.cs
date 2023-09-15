using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SituacionOperatividadNaveDAO
    {

        SqlCommand cmd = new();

        public List<SituacionOperatividadNaveDTO> ObtenerSituacionOperatividadNaves()
        {
            List<SituacionOperatividadNaveDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SituacionOperatividadNaveListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SituacionOperatividadNaveDTO()
                        {
                            SituacionOperatividadNaveId = Convert.ToInt32(dr["SituacionOperatividadNaveId"]),
                            Nave = dr["Nave"].ToString(),
                            NumeroCasco = dr["NumeroCasco"].ToString(),
                            TipoPlataforma = dr["TipoPlataforma"].ToString(),
                            CodigoDependencia = dr["CodigoDependencia"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSituacionOperatividadNave(SituacionOperatividadNaveDTO situacionOperatividadNaveDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SituacionOperatividadNaveRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Nave", SqlDbType.VarChar, 20);                    
                    cmd.Parameters["@Nave"].Value = situacionOperatividadNaveDTO.Nave;

                    cmd.Parameters.Add("@NumeroCasco", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumeroCasco"].Value = situacionOperatividadNaveDTO.NumeroCasco;

                    cmd.Parameters.Add("@TipoPlataforma", SqlDbType.VarChar, 20);
                    cmd.Parameters["@TipoPlataforma"].Value = situacionOperatividadNaveDTO.TipoPlataforma;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = situacionOperatividadNaveDTO.CodigoDependencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperatividadNaveDTO.UsuarioIngresoRegistro;

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

        public SituacionOperatividadNaveDTO BuscarSituacionOperatividadNaveID(int Codigo)
        {
            SituacionOperatividadNaveDTO situacionOperatividadNaveDTO = new SituacionOperatividadNaveDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SituacionOperatividadNaveEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadNaveId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadNaveId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        situacionOperatividadNaveDTO.SituacionOperatividadNaveId = Convert.ToInt32(dr["SituacionOperatividadNaveId"]);
                        situacionOperatividadNaveDTO.Nave = dr["Nave"].ToString();
                        situacionOperatividadNaveDTO.NumeroCasco = dr["NumeroCasco"].ToString();
                        situacionOperatividadNaveDTO.TipoPlataforma = dr["TipoPlataforma"].ToString();
                        situacionOperatividadNaveDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return situacionOperatividadNaveDTO;
        }

        public string ActualizarSituacionOperatividadNave(SituacionOperatividadNaveDTO situacionOperatividadNaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_SituacionOperatividadNaveActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadNaveId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadNaveId"].Value = situacionOperatividadNaveDTO.SituacionOperatividadNaveId;

                    cmd.Parameters.Add("@Nave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Nave"].Value = situacionOperatividadNaveDTO.Nave;

                    cmd.Parameters.Add("@NumeroCasco", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumeroCasco"].Value = situacionOperatividadNaveDTO.NumeroCasco;

                    cmd.Parameters.Add("@TipoPlataforma", SqlDbType.VarChar, 20);
                    cmd.Parameters["@TipoPlataforma"].Value = situacionOperatividadNaveDTO.TipoPlataforma;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = situacionOperatividadNaveDTO.CodigoDependencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperatividadNaveDTO.UsuarioIngresoRegistro;

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

        public string EliminarSituacionOperatividadNave(SituacionOperatividadNaveDTO situacionOperatividadNaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SituacionOperatividadNaveEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadNaveId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadNaveId"].Value = situacionOperatividadNaveDTO.SituacionOperatividadNaveId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperatividadNaveDTO.UsuarioIngresoRegistro;

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
