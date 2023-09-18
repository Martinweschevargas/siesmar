using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ModalidadVentaDAO
    {

        SqlCommand cmd = new();

        public List<ModalidadVentaDTO> ObtenerModalidadVentas()
        {
            List<ModalidadVentaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ModalidadVentaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ModalidadVentaDTO()
                        {
                            ModalidadVentaId = Convert.ToInt32(dr["ModalidadVentaId"]),
                            DescModalidadVenta = dr["DescModalidadVenta"].ToString(),
                            CodigoModalidadVenta = dr["CodigoModalidadVenta"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarModalidadVenta(ModalidadVentaDTO ModalidadVentaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModalidadVentaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescModalidadVenta", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescModalidadVenta"].Value = ModalidadVentaDTO.DescModalidadVenta;

                    cmd.Parameters.Add("@CodigoModalidadVenta", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoModalidadVenta"].Value = ModalidadVentaDTO.CodigoModalidadVenta;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ModalidadVentaDTO.UsuarioIngresoRegistro;

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

        public ModalidadVentaDTO BuscarModalidadVentaID(int Codigo)
        {
            ModalidadVentaDTO ModalidadVentaDTO = new ModalidadVentaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModalidadVentaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModalidadVentaId", SqlDbType.Int);
                    cmd.Parameters["@ModalidadVentaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ModalidadVentaDTO.ModalidadVentaId = Convert.ToInt32(dr["ModalidadVentaId"]);
                        ModalidadVentaDTO.DescModalidadVenta = dr["DescModalidadVenta"].ToString();
                        ModalidadVentaDTO.CodigoModalidadVenta = dr["CodigoModalidadVenta"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ModalidadVentaDTO;
        }

        public string ActualizarModalidadVenta(ModalidadVentaDTO ModalidadVentaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModalidadVentaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModalidadVentaId", SqlDbType.Int);
                    cmd.Parameters["@ModalidadVentaId"].Value = ModalidadVentaDTO.ModalidadVentaId;

                    cmd.Parameters.Add("@DescModalidadVenta", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescModalidadVenta"].Value = ModalidadVentaDTO.DescModalidadVenta;

                    cmd.Parameters.Add("@CodigoModalidadVenta", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoModalidadVenta"].Value = ModalidadVentaDTO.CodigoModalidadVenta;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ModalidadVentaDTO.UsuarioIngresoRegistro;

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

        public string EliminarModalidadVenta(ModalidadVentaDTO ModalidadVentaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModalidadVentaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModalidadVentaId", SqlDbType.Int);
                    cmd.Parameters["@ModalidadVentaId"].Value = ModalidadVentaDTO.ModalidadVentaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ModalidadVentaDTO.UsuarioIngresoRegistro;

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
