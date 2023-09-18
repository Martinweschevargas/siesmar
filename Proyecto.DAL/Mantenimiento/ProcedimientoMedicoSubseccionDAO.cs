using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ProcedimientoMedicoSubseccionDAO
    {

        SqlCommand cmd = new();

        public List<ProcedimientoMedicoSubseccionDTO> ObtenerProcedimientoMedicoSubseccions()
        {
            List<ProcedimientoMedicoSubseccionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ProcedimientoMedicoSubseccionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ProcedimientoMedicoSubseccionDTO()
                        {
                            ProcedimientoMedicoSubseccionId = Convert.ToInt32(dr["ProcedimientoMedicoSubseccionId"]),
                            DescProcedimientoMedicoSubseccion = dr["DescProcedimientoMedicoSubseccion"].ToString(),
                            CodigoProcedimientoMedicoSubseccion = dr["CodigoProcedimientoMedicoSubseccion"].ToString(),
                            DescProcedimientoMedicoSeccion = dr["DescProcedimientoMedicoSeccion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarProcedimientoMedicoSubseccion(ProcedimientoMedicoSubseccionDTO procedimientoMedicoSubseccionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProcedimientoMedicoSubseccionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescProcedimientoMedicoSubseccion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescProcedimientoMedicoSubseccion"].Value = procedimientoMedicoSubseccionDTO.DescProcedimientoMedicoSubseccion;

                    cmd.Parameters.Add("@CodigoProcedimientoMedicoSubseccion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoProcedimientoMedicoSubseccion"].Value = procedimientoMedicoSubseccionDTO.CodigoProcedimientoMedicoSubseccion;

                    cmd.Parameters.Add("@ProcedimientoMedicoSeccionId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoMedicoSeccionId"].Value = procedimientoMedicoSubseccionDTO.ProcedimientoMedicoSeccionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procedimientoMedicoSubseccionDTO.UsuarioIngresoRegistro;

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

        public ProcedimientoMedicoSubseccionDTO BuscarProcedimientoMedicoSubseccionID(int Codigo)
        {
            ProcedimientoMedicoSubseccionDTO procedimientoMedicoSubseccionDTO = new ProcedimientoMedicoSubseccionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProcedimientoMedicoSubseccionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcedimientoMedicoSubseccionId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoMedicoSubseccionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        procedimientoMedicoSubseccionDTO.ProcedimientoMedicoSubseccionId = Convert.ToInt32(dr["ProcedimientoMedicoSubseccionId"]);
                        procedimientoMedicoSubseccionDTO.DescProcedimientoMedicoSubseccion = dr["DescProcedimientoMedicoSubseccion"].ToString();
                        procedimientoMedicoSubseccionDTO.CodigoProcedimientoMedicoSubseccion = dr["CodigoProcedimientoMedicoSubseccion"].ToString();
                        procedimientoMedicoSubseccionDTO.ProcedimientoMedicoSeccionId = Convert.ToInt32(dr["ProcedimientoMedicoSeccionId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return procedimientoMedicoSubseccionDTO;
        }

        public string ActualizarProcedimientoMedicoSubseccion(ProcedimientoMedicoSubseccionDTO procedimientoMedicoSubseccionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ProcedimientoMedicoSubseccionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcedimientoMedicoSubseccionId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoMedicoSubseccionId"].Value = procedimientoMedicoSubseccionDTO.ProcedimientoMedicoSubseccionId;

                    cmd.Parameters.Add("@DescProcedimientoMedicoSubseccion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescProcedimientoMedicoSubseccion"].Value = procedimientoMedicoSubseccionDTO.DescProcedimientoMedicoSubseccion;

                    cmd.Parameters.Add("@CodigoProcedimientoMedicoSubseccion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoProcedimientoMedicoSubseccion"].Value = procedimientoMedicoSubseccionDTO.CodigoProcedimientoMedicoSubseccion;

                    cmd.Parameters.Add("@ProcedimientoMedicoSeccionId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoMedicoSeccionId"].Value = procedimientoMedicoSubseccionDTO.ProcedimientoMedicoSeccionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procedimientoMedicoSubseccionDTO.UsuarioIngresoRegistro;

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

        public string EliminarProcedimientoMedicoSubseccion(ProcedimientoMedicoSubseccionDTO procedimientoMedicoSubseccionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProcedimientoMedicoSubseccionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcedimientoMedicoSubseccionId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoMedicoSubseccionId"].Value = procedimientoMedicoSubseccionDTO.ProcedimientoMedicoSubseccionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procedimientoMedicoSubseccionDTO.UsuarioIngresoRegistro;

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
