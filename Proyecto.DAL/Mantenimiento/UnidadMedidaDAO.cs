using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class UnidadMedidaDAO
    {

        SqlCommand cmd = new();

        public List<UnidadMedidaDTO> ObtenerUnidadMedidas()
        {
            List<UnidadMedidaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_UnidadMedidaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new UnidadMedidaDTO()
                        {
                            UnidadMedidaId = Convert.ToInt32(dr["UnidadMedidaId"]),
                            CodigoUnidadMedida = dr["CodigoUnidadMedida"].ToString(),
                            DescUnidadMedida = dr["DescUnidadMedida"].ToString(),
                            AbrevUnidadMedida = dr["AbrevUnidadMedida"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarUnidadMedida(UnidadMedidaDTO unidadMedidaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadMedidaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadMedida", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoUnidadMedida"].Value = unidadMedidaDTO.CodigoUnidadMedida;

                    cmd.Parameters.Add("@DescUnidadMedida", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescUnidadMedida"].Value = unidadMedidaDTO.DescUnidadMedida;

                    cmd.Parameters.Add("@AbrevUnidadMedida", SqlDbType.VarChar, 10);
                    cmd.Parameters["@AbrevUnidadMedida"].Value = unidadMedidaDTO.AbrevUnidadMedida;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadMedidaDTO.UsuarioIngresoRegistro;

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

        public UnidadMedidaDTO BuscarUnidadMedidaID(int Codigo)
        {
            UnidadMedidaDTO unidadMedidaDTO = new UnidadMedidaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadMedidaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadMedidaId", SqlDbType.Int);
                    cmd.Parameters["@UnidadMedidaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        unidadMedidaDTO.UnidadMedidaId = Convert.ToInt32(dr["UnidadMedidaId"]);
                        unidadMedidaDTO.CodigoUnidadMedida = dr["CodigoUnidadMedida"].ToString();
                        unidadMedidaDTO.DescUnidadMedida = dr["DescUnidadMedida"].ToString();
                        unidadMedidaDTO.AbrevUnidadMedida = dr["AbrevUnidadMedida"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return unidadMedidaDTO;
        }

        public string ActualizarUnidadMedida(UnidadMedidaDTO unidadMedidaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadMedidaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadMedidaId", SqlDbType.Int);
                    cmd.Parameters["@UnidadMedidaId"].Value = unidadMedidaDTO.UnidadMedidaId;

                    cmd.Parameters.Add("@CodigoUnidadMedida", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoUnidadMedida"].Value = unidadMedidaDTO.CodigoUnidadMedida;

                    cmd.Parameters.Add("@DescUnidadMedida", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescUnidadMedida"].Value = unidadMedidaDTO.DescUnidadMedida;

                    cmd.Parameters.Add("@AbrevUnidadMedida", SqlDbType.VarChar, 10);
                    cmd.Parameters["@AbrevUnidadMedida"].Value = unidadMedidaDTO.AbrevUnidadMedida;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadMedidaDTO.UsuarioIngresoRegistro;

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

        public string EliminarUnidadMedida(UnidadMedidaDTO unidadMedidaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadMedidaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadMedidaId", SqlDbType.Int);
                    cmd.Parameters["@UnidadMedidaId"].Value = unidadMedidaDTO.UnidadMedidaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadMedidaDTO.UsuarioIngresoRegistro;

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
