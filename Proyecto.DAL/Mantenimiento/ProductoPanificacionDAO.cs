using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ProductoPanificacionDAO
    {
        SqlCommand cmd = new();

        public List<ProductoPanificacionDTO> ObtenerProductos()
        {
            List<ProductoPanificacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ProductoPanificacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ProductoPanificacionDTO()
                        {
                            ProductoPanificacionId = Convert.ToInt32(dr["ProductoPanificacionId"]),
                            DescProductoPanificacion = dr["DescProductoPanificacion"].ToString(),
                            CodigoProductoPanificacion = dr["CodigoProductoPanificacion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarProducto(ProductoPanificacionDTO productoPanificacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProductoPanificacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescProductoPanificacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescProductoPanificacion"].Value = productoPanificacionDTO.DescProductoPanificacion;

                    cmd.Parameters.Add("@CodigoProductoPanificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProductoPanificacion"].Value = productoPanificacionDTO.CodigoProductoPanificacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = productoPanificacionDTO.UsuarioIngresoRegistro;

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

        public ProductoPanificacionDTO BuscarProductoPanificacionId(int Codigo)
        {
            ProductoPanificacionDTO productoPanificacionDTO = new ProductoPanificacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProductoPanificacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductoPanificacionId", SqlDbType.Int);
                    cmd.Parameters["@ProductoPanificacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        productoPanificacionDTO.ProductoPanificacionId = Convert.ToInt32(dr["ProductoPanificacionId"]);
                        productoPanificacionDTO.DescProductoPanificacion = dr["DescProductoPanificacion"].ToString();
                        productoPanificacionDTO.CodigoProductoPanificacion = dr["CodigoProductoPanificacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return productoPanificacionDTO;
        }

        public string ActualizarProducto(ProductoPanificacionDTO productoPanificacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProductoPanificacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductoPanificacionId", SqlDbType.Int);
                    cmd.Parameters["@ProductoPanificacionId"].Value = productoPanificacionDTO.ProductoPanificacionId;

                    cmd.Parameters.Add("@DescProductoPanificacion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescProductoPanificacion"].Value = productoPanificacionDTO.DescProductoPanificacion;

                    cmd.Parameters.Add("@CodigoProductoPanificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProductoPanificacion"].Value = productoPanificacionDTO.CodigoProductoPanificacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = productoPanificacionDTO.UsuarioIngresoRegistro;

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

        public string EliminarProducto(ProductoPanificacionDTO productoPanificacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProductoPanificacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductoPanificacionId", SqlDbType.Int);
                    cmd.Parameters["@ProductoPanificacionId"].Value = productoPanificacionDTO.ProductoPanificacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = productoPanificacionDTO.UsuarioIngresoRegistro;

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
