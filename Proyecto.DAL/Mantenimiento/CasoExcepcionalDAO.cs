using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CasoExcepcionalDAO
    {

        SqlCommand cmd = new();

        public List<CasoExcepcionalDTO> ObtenerCasoExcepcionals()
        {
            List<CasoExcepcionalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CasoExcepcionalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CasoExcepcionalDTO()
                        {
                            CasoExcepcionalId = Convert.ToInt32(dr["CasoExcepcionalId"]),
                            DescCasoExcepcional = dr["DescCasoExcepcional"].ToString(),
                            CodigoCasoExcepcional = dr["CodigoCasoExcepcional"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCasoExcepcional(CasoExcepcionalDTO CasoExcepcionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CasoExcepcionalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCasoExcepcional", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCasoExcepcional"].Value = CasoExcepcionalDTO.DescCasoExcepcional;

                    cmd.Parameters.Add("@CodigoCasoExcepcional", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCasoExcepcional"].Value = CasoExcepcionalDTO.CodigoCasoExcepcional;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CasoExcepcionalDTO.UsuarioIngresoRegistro;

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

        public CasoExcepcionalDTO BuscarCasoExcepcionalID(int Codigo)
        {
            CasoExcepcionalDTO CasoExcepcionalDTO = new CasoExcepcionalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CasoExcepcionalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CasoExcepcionalId", SqlDbType.Int);
                    cmd.Parameters["@CasoExcepcionalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        CasoExcepcionalDTO.CasoExcepcionalId = Convert.ToInt32(dr["CasoExcepcionalId"]);
                        CasoExcepcionalDTO.DescCasoExcepcional = dr["DescCasoExcepcional"].ToString();
                        CasoExcepcionalDTO.CodigoCasoExcepcional = dr["CodigoCasoExcepcional"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return CasoExcepcionalDTO;
        }

        public string ActualizarCasoExcepcional(CasoExcepcionalDTO CasoExcepcionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CasoExcepcionalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CasoExcepcionalId", SqlDbType.Int);
                    cmd.Parameters["@CasoExcepcionalId"].Value = CasoExcepcionalDTO.CasoExcepcionalId;

                    cmd.Parameters.Add("@DescCasoExcepcional", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCasoExcepcional"].Value = CasoExcepcionalDTO.DescCasoExcepcional;

                    cmd.Parameters.Add("@CodigoCasoExcepcional", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCasoExcepcional"].Value = CasoExcepcionalDTO.CodigoCasoExcepcional;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CasoExcepcionalDTO.UsuarioIngresoRegistro;

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

        public string EliminarCasoExcepcional(CasoExcepcionalDTO CasoExcepcionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CasoExcepcionalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CasoExcepcionalId", SqlDbType.Int);
                    cmd.Parameters["@CasoExcepcionalId"].Value = CasoExcepcionalDTO.CasoExcepcionalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CasoExcepcionalDTO.UsuarioIngresoRegistro;

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
