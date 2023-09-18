using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CausalTramiteAltaDAO
    {

        SqlCommand cmd = new();

        public List<CausalTramiteAltaDTO> ObtenerCausalTramiteAltas()
        {
            List<CausalTramiteAltaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CausalTramiteAltaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CausalTramiteAltaDTO()
                        {
                            CausalTramiteAltaId = Convert.ToInt32(dr["CausalTramiteAltaId"]),
                            DescCausalTramiteAlta = dr["DescCausalTramiteAlta"].ToString(),
                            CodigoCausalTramiteAlta = dr["CodigoCausalTramiteAlta"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCausalTramiteAlta(CausalTramiteAltaDTO CausalTramiteAltaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CausalTramiteAltaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCausalTramiteAlta", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCausalTramiteAlta"].Value = CausalTramiteAltaDTO.DescCausalTramiteAlta;

                    cmd.Parameters.Add("@CodigoCausalTramiteAlta", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCausalTramiteAlta"].Value = CausalTramiteAltaDTO.CodigoCausalTramiteAlta;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CausalTramiteAltaDTO.UsuarioIngresoRegistro;

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

        public CausalTramiteAltaDTO BuscarCausalTramiteAltaID(int Codigo)
        {
            CausalTramiteAltaDTO CausalTramiteAltaDTO = new CausalTramiteAltaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CausalTramiteAltaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CausalTramiteAltaId", SqlDbType.Int);
                    cmd.Parameters["@CausalTramiteAltaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        CausalTramiteAltaDTO.CausalTramiteAltaId = Convert.ToInt32(dr["CausalTramiteAltaId"]);
                        CausalTramiteAltaDTO.DescCausalTramiteAlta = dr["DescCausalTramiteAlta"].ToString();
                        CausalTramiteAltaDTO.CodigoCausalTramiteAlta = dr["CodigoCausalTramiteAlta"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return CausalTramiteAltaDTO;
        }

        public string ActualizarCausalTramiteAlta(CausalTramiteAltaDTO CausalTramiteAltaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CausalTramiteAltaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CausalTramiteAltaId", SqlDbType.Int);
                    cmd.Parameters["@CausalTramiteAltaId"].Value = CausalTramiteAltaDTO.CausalTramiteAltaId;

                    cmd.Parameters.Add("@DescCausalTramiteAlta", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCausalTramiteAlta"].Value = CausalTramiteAltaDTO.DescCausalTramiteAlta;

                    cmd.Parameters.Add("@CodigoCausalTramiteAlta", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCausalTramiteAlta"].Value = CausalTramiteAltaDTO.CodigoCausalTramiteAlta;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CausalTramiteAltaDTO.UsuarioIngresoRegistro;

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

        public string EliminarCausalTramiteAlta(CausalTramiteAltaDTO CausalTramiteAltaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CausalTramiteAltaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CausalTramiteAltaId", SqlDbType.Int);
                    cmd.Parameters["@CausalTramiteAltaId"].Value = CausalTramiteAltaDTO.CausalTramiteAltaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CausalTramiteAltaDTO.UsuarioIngresoRegistro;

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
