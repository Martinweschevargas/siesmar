using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CausalBajaDAO
    {

        SqlCommand cmd = new();

        public List<CausalBajaDTO> ObtenerCausalBajas()
        {
            List<CausalBajaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CausalBajaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CausalBajaDTO()
                        {
                            CausalBajaId = Convert.ToInt32(dr["CausalBajaId"]),
                            DescCausalBaja = dr["DescCausalBaja"].ToString(),
                            CodigoCausalBaja = dr["CodigoCausalBaja"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCausalBaja(CausalBajaDTO causalBajaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CausalBajaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCausalBaja", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCausalBaja"].Value = causalBajaDTO.DescCausalBaja;

                    cmd.Parameters.Add("@CodigoCausalBaja", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCausalBaja"].Value = causalBajaDTO.CodigoCausalBaja;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = causalBajaDTO.UsuarioIngresoRegistro;

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

        public CausalBajaDTO BuscarCausalBajaID(int Codigo)
        {
            CausalBajaDTO causalBajaDTO = new CausalBajaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CausalBajaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CausalBajaId", SqlDbType.Int);
                    cmd.Parameters["@CausalBajaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        causalBajaDTO.CausalBajaId = Convert.ToInt32(dr["CausalBajaId"]);
                        causalBajaDTO.DescCausalBaja = dr["DescCausalBaja"].ToString();
                        causalBajaDTO.CodigoCausalBaja = dr["CodigoCausalBaja"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return causalBajaDTO;
        }

        public string ActualizarCausalBaja(CausalBajaDTO causalBajaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CausalBajaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CausalBajaId", SqlDbType.Int);
                    cmd.Parameters["@CausalBajaId"].Value = causalBajaDTO.CausalBajaId;

                    cmd.Parameters.Add("@DescCausalBaja", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCausalBaja"].Value = causalBajaDTO.DescCausalBaja;

                    cmd.Parameters.Add("@CodigoCausalBaja", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCausalBaja"].Value = causalBajaDTO.CodigoCausalBaja;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = causalBajaDTO.UsuarioIngresoRegistro;

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

        public string EliminarCausalBaja(CausalBajaDTO causalBajaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CausalBajaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CausalBajaId", SqlDbType.Int);
                    cmd.Parameters["@CausalBajaId"].Value = causalBajaDTO.CausalBajaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = causalBajaDTO.UsuarioIngresoRegistro;

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
