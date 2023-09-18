using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ProductoResultadoObtenidoDAO
    {

        SqlCommand cmd = new();

        public List<ProductoResultadoObtenidoDTO> ObtenerProductoResultadoObtenidos()
        {
            List<ProductoResultadoObtenidoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ProductoResultadoObtenidoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ProductoResultadoObtenidoDTO()
                        {
                            ProductoResultadoObtenidoId = Convert.ToInt32(dr["ProductoResultadoObtenidoId"]),
                            DescProductoResultadoObtenido = dr["DescProductoResultadoObtenido"].ToString(),
                            CodigoProductoResultadoObtenido = dr["CodigoProductoResultadoObtenido"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarProductoResultadoObtenido(ProductoResultadoObtenidoDTO ProductoResultadoObtenidoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProductoResultadoObtenidoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescProductoResultadoObtenido", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescProductoResultadoObtenido"].Value = ProductoResultadoObtenidoDTO.DescProductoResultadoObtenido;

                    cmd.Parameters.Add("@CodigoProductoResultadoObtenido", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoProductoResultadoObtenido"].Value = ProductoResultadoObtenidoDTO.CodigoProductoResultadoObtenido;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ProductoResultadoObtenidoDTO.UsuarioIngresoRegistro;

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

        public ProductoResultadoObtenidoDTO BuscarProductoResultadoObtenidoID(int Codigo)
        {
            ProductoResultadoObtenidoDTO ProductoResultadoObtenidoDTO = new ProductoResultadoObtenidoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProductoResultadoObtenidoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductoResultadoObtenidoId", SqlDbType.Int);
                    cmd.Parameters["@ProductoResultadoObtenidoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ProductoResultadoObtenidoDTO.ProductoResultadoObtenidoId = Convert.ToInt32(dr["ProductoResultadoObtenidoId"]);
                        ProductoResultadoObtenidoDTO.DescProductoResultadoObtenido = dr["DescProductoResultadoObtenido"].ToString();
                        ProductoResultadoObtenidoDTO.CodigoProductoResultadoObtenido = dr["CodigoProductoResultadoObtenido"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ProductoResultadoObtenidoDTO;
        }

        public string ActualizarProductoResultadoObtenido(ProductoResultadoObtenidoDTO ProductoResultadoObtenidoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProductoResultadoObtenidoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductoResultadoObtenidoId", SqlDbType.Int);
                    cmd.Parameters["@ProductoResultadoObtenidoId"].Value = ProductoResultadoObtenidoDTO.ProductoResultadoObtenidoId;

                    cmd.Parameters.Add("@DescProductoResultadoObtenido", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescProductoResultadoObtenido"].Value = ProductoResultadoObtenidoDTO.DescProductoResultadoObtenido;

                    cmd.Parameters.Add("@CodigoProductoResultadoObtenido", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoProductoResultadoObtenido"].Value = ProductoResultadoObtenidoDTO.CodigoProductoResultadoObtenido;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ProductoResultadoObtenidoDTO.UsuarioIngresoRegistro;

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

        public string EliminarProductoResultadoObtenido(ProductoResultadoObtenidoDTO ProductoResultadoObtenidoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProductoResultadoObtenidoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductoResultadoObtenidoId", SqlDbType.Int);
                    cmd.Parameters["@ProductoResultadoObtenidoId"].Value = ProductoResultadoObtenidoDTO.ProductoResultadoObtenidoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ProductoResultadoObtenidoDTO.UsuarioIngresoRegistro;

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
