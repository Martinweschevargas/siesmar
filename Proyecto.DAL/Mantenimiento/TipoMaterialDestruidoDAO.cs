using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoMaterialDestruidoDAO
    {

        SqlCommand cmd = new();

        public List<TipoMaterialDestruidoDTO> ObtenerTipoMaterialDestruidos()
        {
            List<TipoMaterialDestruidoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoMaterialDestruidoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoMaterialDestruidoDTO()
                        {
                            TipoMaterialDestruidoId = Convert.ToInt32(dr["TipoMaterialDestruidoId"]),
                            DescTipoMaterialDestruido = dr["DescTipoMaterialDestruido"].ToString(),
                            CodigoTipoMaterialDestruido = dr["CodigoTipoMaterialDestruido"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoMaterialDestruido(TipoMaterialDestruidoDTO TipoMaterialDestruidoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoMaterialDestruidoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoMaterialDestruido", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoMaterialDestruido"].Value = TipoMaterialDestruidoDTO.DescTipoMaterialDestruido;

                    cmd.Parameters.Add("@CodigoTipoMaterialDestruido", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoMaterialDestruido"].Value = TipoMaterialDestruidoDTO.CodigoTipoMaterialDestruido;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoMaterialDestruidoDTO.UsuarioIngresoRegistro;

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

        public TipoMaterialDestruidoDTO BuscarTipoMaterialDestruidoID(int Codigo)
        {
            TipoMaterialDestruidoDTO TipoMaterialDestruidoDTO = new TipoMaterialDestruidoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoMaterialDestruidoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoMaterialDestruidoId", SqlDbType.Int);
                    cmd.Parameters["@TipoMaterialDestruidoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        TipoMaterialDestruidoDTO.TipoMaterialDestruidoId = Convert.ToInt32(dr["TipoMaterialDestruidoId"]);
                        TipoMaterialDestruidoDTO.DescTipoMaterialDestruido = dr["DescTipoMaterialDestruido"].ToString();
                        TipoMaterialDestruidoDTO.CodigoTipoMaterialDestruido = dr["CodigoTipoMaterialDestruido"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return TipoMaterialDestruidoDTO;
        }

        public string ActualizarTipoMaterialDestruido(TipoMaterialDestruidoDTO TipoMaterialDestruidoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoMaterialDestruidoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoMaterialDestruidoId", SqlDbType.Int);
                    cmd.Parameters["@TipoMaterialDestruidoId"].Value = TipoMaterialDestruidoDTO.TipoMaterialDestruidoId;

                    cmd.Parameters.Add("@DescTipoMaterialDestruido", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoMaterialDestruido"].Value = TipoMaterialDestruidoDTO.DescTipoMaterialDestruido;

                    cmd.Parameters.Add("@CodigoTipoMaterialDestruido", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoMaterialDestruido"].Value = TipoMaterialDestruidoDTO.CodigoTipoMaterialDestruido;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoMaterialDestruidoDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoMaterialDestruido(TipoMaterialDestruidoDTO TipoMaterialDestruidoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoMaterialDestruidoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoMaterialDestruidoId", SqlDbType.Int);
                    cmd.Parameters["@TipoMaterialDestruidoId"].Value = TipoMaterialDestruidoDTO.TipoMaterialDestruidoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoMaterialDestruidoDTO.UsuarioIngresoRegistro;

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
