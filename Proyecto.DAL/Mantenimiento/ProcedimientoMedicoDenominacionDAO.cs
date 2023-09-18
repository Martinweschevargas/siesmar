using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ProcedimientoMedicoDenominacionDAO
    {

        SqlCommand cmd = new();

        public List<ProcedimientoMedicoDenominacionDTO> ObtenerProcedimientoMedicoDenominacions()
        {
            List<ProcedimientoMedicoDenominacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ProcedimientoMedicoDenominacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ProcedimientoMedicoDenominacionDTO()
                        {
                            ProcedimientoMedicoDenominacionId = Convert.ToInt32(dr["ProcedimientoMedicoDenominacionId"]),
                            DescProcedimientoMedicoDenominacion = dr["DescProcedimientoMedicoDenominacion"].ToString(),
                            CodigoProcedimientoMedicoDenominacion = dr["CodigoProcedimientoMedicoDenominacion"].ToString(),
                            DescProcedimientoMedicoSubseccion = dr["DescProcedimientoMedicoSubseccion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarProcedimientoMedicoDenominacion(ProcedimientoMedicoDenominacionDTO procedimientoMedicoDenominacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProcedimientoMedicoDenominacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescProcedimientoMedicoDenominacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescProcedimientoMedicoDenominacion"].Value = procedimientoMedicoDenominacionDTO.DescProcedimientoMedicoDenominacion;

                    cmd.Parameters.Add("@CodigoProcedimientoMedicoDenominacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoProcedimientoMedicoDenominacion"].Value = procedimientoMedicoDenominacionDTO.CodigoProcedimientoMedicoDenominacion;

                    cmd.Parameters.Add("@ProcedimientoMedicoSubseccionId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoMedicoSubseccionId"].Value = procedimientoMedicoDenominacionDTO.ProcedimientoMedicoSubseccionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procedimientoMedicoDenominacionDTO.UsuarioIngresoRegistro;

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

        public ProcedimientoMedicoDenominacionDTO BuscarProcedimientoMedicoDenominacionID(int Codigo)
        {
            ProcedimientoMedicoDenominacionDTO procedimientoMedicoDenominacionDTO = new ProcedimientoMedicoDenominacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProcedimientoMedicoDenominacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcedimientoMedicoDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoMedicoDenominacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        procedimientoMedicoDenominacionDTO.ProcedimientoMedicoDenominacionId = Convert.ToInt32(dr["ProcedimientoMedicoDenominacionId"]);
                        procedimientoMedicoDenominacionDTO.DescProcedimientoMedicoDenominacion = dr["DescProcedimientoMedicoDenominacion"].ToString();
                        procedimientoMedicoDenominacionDTO.CodigoProcedimientoMedicoDenominacion = dr["CodigoProcedimientoMedicoDenominacion"].ToString();
                        procedimientoMedicoDenominacionDTO.ProcedimientoMedicoSubseccionId = Convert.ToInt32(dr["ProcedimientoMedicoSubseccionId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return procedimientoMedicoDenominacionDTO;
        }

        public string ActualizarProcedimientoMedicoDenominacion(ProcedimientoMedicoDenominacionDTO procedimientoMedicoDenominacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ProcedimientoMedicoDenominacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcedimientoMedicoDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoMedicoDenominacionId"].Value = procedimientoMedicoDenominacionDTO.ProcedimientoMedicoDenominacionId;

                    cmd.Parameters.Add("@DescProcedimientoMedicoDenominacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescProcedimientoMedicoDenominacion"].Value = procedimientoMedicoDenominacionDTO.DescProcedimientoMedicoDenominacion;

                    cmd.Parameters.Add("@CodigoProcedimientoMedicoDenominacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoProcedimientoMedicoDenominacion"].Value = procedimientoMedicoDenominacionDTO.CodigoProcedimientoMedicoDenominacion;

                    cmd.Parameters.Add("@ProcedimientoMedicoSubseccionId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoMedicoSubseccionId"].Value = procedimientoMedicoDenominacionDTO.ProcedimientoMedicoSubseccionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procedimientoMedicoDenominacionDTO.UsuarioIngresoRegistro;

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

        public string EliminarProcedimientoMedicoDenominacion(ProcedimientoMedicoDenominacionDTO procedimientoMedicoDenominacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProcedimientoMedicoDenominacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcedimientoMedicoDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoMedicoDenominacionId"].Value = procedimientoMedicoDenominacionDTO.ProcedimientoMedicoDenominacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procedimientoMedicoDenominacionDTO.UsuarioIngresoRegistro;

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
