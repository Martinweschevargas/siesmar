using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CertificacionCETPRODAO
    {

        SqlCommand cmd = new();

        public List<CertificacionCETPRODTO> ObtenerCertificacionCETPROs()
        {
            List<CertificacionCETPRODTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CertificacionCETPROListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CertificacionCETPRODTO()
                        {
                            CertificacionCETPROId = Convert.ToInt32(dr["CertificacionCETPROId"]),
                            DescCertificacionCETPRO = dr["DescCertificacionCETPRO"].ToString(),
                            CodigoCertificacionCETPRO = dr["CodigoCertificacionCETPRO"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCertificacionCETPRO(CertificacionCETPRODTO CertificacionCETPRODTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CertificacionCETPRORegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCertificacionCETPRO", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCertificacionCETPRO"].Value = CertificacionCETPRODTO.DescCertificacionCETPRO;

                    cmd.Parameters.Add("@CodigoCertificacionCETPRO", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCertificacionCETPRO"].Value = CertificacionCETPRODTO.CodigoCertificacionCETPRO;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CertificacionCETPRODTO.UsuarioIngresoRegistro;

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

        public CertificacionCETPRODTO BuscarCertificacionCETPROID(int Codigo)
        {
            CertificacionCETPRODTO CertificacionCETPRODTO = new CertificacionCETPRODTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CertificacionCETPROEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CertificacionCETPROId", SqlDbType.Int);
                    cmd.Parameters["@CertificacionCETPROId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        CertificacionCETPRODTO.CertificacionCETPROId = Convert.ToInt32(dr["CertificacionCETPROId"]);
                        CertificacionCETPRODTO.DescCertificacionCETPRO = dr["DescCertificacionCETPRO"].ToString();
                        CertificacionCETPRODTO.CodigoCertificacionCETPRO = dr["CodigoCertificacionCETPRO"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return CertificacionCETPRODTO;
        }

        public string ActualizarCertificacionCETPRO(CertificacionCETPRODTO CertificacionCETPRODTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CertificacionCETPROActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CertificacionCETPROId", SqlDbType.Int);
                    cmd.Parameters["@CertificacionCETPROId"].Value = CertificacionCETPRODTO.CertificacionCETPROId;

                    cmd.Parameters.Add("@DescCertificacionCETPRO", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCertificacionCETPRO"].Value = CertificacionCETPRODTO.DescCertificacionCETPRO;

                    cmd.Parameters.Add("@CodigoCertificacionCETPRO", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCertificacionCETPRO"].Value = CertificacionCETPRODTO.CodigoCertificacionCETPRO;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CertificacionCETPRODTO.UsuarioIngresoRegistro;

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

        public string EliminarCertificacionCETPRO(CertificacionCETPRODTO CertificacionCETPRODTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CertificacionCETPROEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CertificacionCETPROId", SqlDbType.Int);
                    cmd.Parameters["@CertificacionCETPROId"].Value = CertificacionCETPRODTO.CertificacionCETPROId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CertificacionCETPRODTO.UsuarioIngresoRegistro;

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
