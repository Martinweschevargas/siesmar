using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CausalLiquidacionDAO
    {

        SqlCommand cmd = new();

        public List<CausalLiquidacionDTO> ObtenerCausalLiquidacions()
        {
            List<CausalLiquidacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CausalLiquidacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CausalLiquidacionDTO()
                        {
                            CausalLiquidacionId = Convert.ToInt32(dr["CausalLiquidacionId"]),
                            DescCausalLiquidacion = dr["DescCausalLiquidacion"].ToString(),
                            CodigoCausalLiquidacion = dr["CodigoCausalLiquidacion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCausalLiquidacion(CausalLiquidacionDTO causalLiquidacionDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CausalLiquidacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCausalLiquidacion", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescCausalLiquidacion"].Value = causalLiquidacionDTO.DescCausalLiquidacion;

                    cmd.Parameters.Add("@CodigoCausalLiquidacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoCausalLiquidacion"].Value = causalLiquidacionDTO.CodigoCausalLiquidacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = causalLiquidacionDTO.UsuarioIngresoRegistro;

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

        public CausalLiquidacionDTO BuscarCausalLiquidacionID(int Codigo)
        {
            CausalLiquidacionDTO causalLiquidacionDTO = new CausalLiquidacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CausalLiquidacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CausalLiquidacionId", SqlDbType.Int);
                    cmd.Parameters["@CausalLiquidacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        causalLiquidacionDTO.CausalLiquidacionId = Convert.ToInt32(dr["CausalLiquidacionId"]);
                        causalLiquidacionDTO.DescCausalLiquidacion = dr["DescCausalLiquidacion"].ToString();
                        causalLiquidacionDTO.CodigoCausalLiquidacion = dr["CodigoCausalLiquidacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return causalLiquidacionDTO;
        }

        public string ActualizarCausalLiquidacion(CausalLiquidacionDTO causalLiquidacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CausalLiquidacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CausalLiquidacionId", SqlDbType.Int);
                    cmd.Parameters["@CausalLiquidacionId"].Value = causalLiquidacionDTO.CausalLiquidacionId;

                    cmd.Parameters.Add("@DescCausalLiquidacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCausalLiquidacion"].Value = causalLiquidacionDTO.DescCausalLiquidacion;

                    cmd.Parameters.Add("@CodigoCausalLiquidacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCausalLiquidacion"].Value = causalLiquidacionDTO.CodigoCausalLiquidacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = causalLiquidacionDTO.UsuarioIngresoRegistro;

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

        public string EliminarCausalLiquidacion(CausalLiquidacionDTO causalLiquidacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CausalLiquidacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CausalLiquidacionId", SqlDbType.Int);
                    cmd.Parameters["@CausalLiquidacionId"].Value = causalLiquidacionDTO.CausalLiquidacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = causalLiquidacionDTO.UsuarioIngresoRegistro;

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
