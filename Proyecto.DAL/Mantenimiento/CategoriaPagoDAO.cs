using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CategoriaPagoDAO
    {

        SqlCommand cmd = new();

        public List<CategoriaPagoDTO> ObtenerCategoriaPagos()
        {
            List<CategoriaPagoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CategoriaPagoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CategoriaPagoDTO()
                        {
                            CategoriaPagoId = Convert.ToInt32(dr["CategoriaPagoId"]),
                            DescCategoriaPago = dr["DescCategoriaPago"].ToString(),
                            CodigoCategoriaPago = dr["CodigoCategoriaPago"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCategoriaPago(CategoriaPagoDTO CategoriaPagoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CategoriaPagoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCategoriaPago", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescCategoriaPago"].Value = CategoriaPagoDTO.DescCategoriaPago;

                    cmd.Parameters.Add("@CodigoCategoriaPago", SqlDbType.VarChar, 10);                    
                    cmd.Parameters["@CodigoCategoriaPago"].Value = CategoriaPagoDTO.CodigoCategoriaPago;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CategoriaPagoDTO.UsuarioIngresoRegistro;

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

        public CategoriaPagoDTO BuscarCategoriaPagoID(int Codigo)
        {
            CategoriaPagoDTO CategoriaPagoDTO = new CategoriaPagoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CategoriaPagoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CategoriaPagoId", SqlDbType.Int);
                    cmd.Parameters["@CategoriaPagoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        CategoriaPagoDTO.CategoriaPagoId = Convert.ToInt32(dr["CategoriaPagoId"]);
                        CategoriaPagoDTO.DescCategoriaPago = dr["DescCategoriaPago"].ToString();
                        CategoriaPagoDTO.CodigoCategoriaPago = dr["CodigoCategoriaPago"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return CategoriaPagoDTO;
        }

        public string ActualizarCategoriaPago(CategoriaPagoDTO CategoriaPagoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CategoriaPagoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CategoriaPagoId", SqlDbType.Int);
                    cmd.Parameters["@CategoriaPagoId"].Value = CategoriaPagoDTO.CategoriaPagoId;

                    cmd.Parameters.Add("@DescCategoriaPago", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescCategoriaPago"].Value = CategoriaPagoDTO.DescCategoriaPago;

                    cmd.Parameters.Add("@CodigoCategoriaPago", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCategoriaPago"].Value = CategoriaPagoDTO.CodigoCategoriaPago;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CategoriaPagoDTO.UsuarioIngresoRegistro;

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

        public string EliminarCategoriaPago(CategoriaPagoDTO CategoriaPagoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CategoriaPagoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CategoriaPagoId", SqlDbType.Int);
                    cmd.Parameters["@CategoriaPagoId"].Value = CategoriaPagoDTO.CategoriaPagoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CategoriaPagoDTO.UsuarioIngresoRegistro;

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
