using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class MotivoInvestigacionDAO
    {

        SqlCommand cmd = new();

        public List<MotivoInvestigacionDTO> ObtenerMotivoInvestigacions()
        {
            List<MotivoInvestigacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_MotivoInvestigacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MotivoInvestigacionDTO()
                        {
                            MotivoInvestigacionId = Convert.ToInt32(dr["MotivoInvestigacionId"]),
                            DescMotivoInvestigacion = dr["DescMotivoInvestigacion"].ToString(),
                            CodigoMotivoInvestigacion = dr["CodigoMotivoInvestigacion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarMotivoInvestigacion(MotivoInvestigacionDTO motivoInvestigacionDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MotivoInvestigacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescMotivoInvestigacion", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescMotivoInvestigacion"].Value = motivoInvestigacionDTO.DescMotivoInvestigacion;

                    cmd.Parameters.Add("@CodigoMotivoInvestigacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoMotivoInvestigacion"].Value = motivoInvestigacionDTO.CodigoMotivoInvestigacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = motivoInvestigacionDTO.UsuarioIngresoRegistro;

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

        public MotivoInvestigacionDTO BuscarMotivoInvestigacionID(int Codigo)
        {
            MotivoInvestigacionDTO motivoInvestigacionDTO = new MotivoInvestigacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MotivoInvestigacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MotivoInvestigacionId", SqlDbType.Int);
                    cmd.Parameters["@MotivoInvestigacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        motivoInvestigacionDTO.MotivoInvestigacionId = Convert.ToInt32(dr["MotivoInvestigacionId"]);
                        motivoInvestigacionDTO.DescMotivoInvestigacion = dr["DescMotivoInvestigacion"].ToString();
                        motivoInvestigacionDTO.CodigoMotivoInvestigacion = dr["CodigoMotivoInvestigacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return motivoInvestigacionDTO;
        }

        public string ActualizarMotivoInvestigacion(MotivoInvestigacionDTO motivoInvestigacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MotivoInvestigacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MotivoInvestigacionId", SqlDbType.Int);
                    cmd.Parameters["@MotivoInvestigacionId"].Value = motivoInvestigacionDTO.MotivoInvestigacionId;

                    cmd.Parameters.Add("@DescMotivoInvestigacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescMotivoInvestigacion"].Value = motivoInvestigacionDTO.DescMotivoInvestigacion;

                    cmd.Parameters.Add("@CodigoMotivoInvestigacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMotivoInvestigacion"].Value = motivoInvestigacionDTO.CodigoMotivoInvestigacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = motivoInvestigacionDTO.UsuarioIngresoRegistro;

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

        public string EliminarMotivoInvestigacion(MotivoInvestigacionDTO motivoInvestigacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MotivoInvestigacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MotivoInvestigacionId", SqlDbType.Int);
                    cmd.Parameters["@MotivoInvestigacionId"].Value = motivoInvestigacionDTO.MotivoInvestigacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = motivoInvestigacionDTO.UsuarioIngresoRegistro;

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
