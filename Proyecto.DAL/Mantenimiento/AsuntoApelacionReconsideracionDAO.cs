using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AsuntoApelacionReconsideracionDAO
    {

        SqlCommand cmd = new();

        public List<AsuntoApelacionReconsideracionDTO> ObtenerAsuntoApelacionReconsideraciones()
        {
            List<AsuntoApelacionReconsideracionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AsuntoApelacionReconsideracionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AsuntoApelacionReconsideracionDTO()
                        {
                            AsuntoApelacionReconsideracionId = Convert.ToInt32(dr["AsuntoApelacionReconsideracionId"]),
                            DescAsuntoApelacionReconsideracion = dr["DescAsuntoApelacionReconsideracion"].ToString(),
                            CodigoAsuntoApelacionReconsideracion = dr["CodigoAsuntoApelacionReconsideracion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAsuntoApelacionReconsideracion(AsuntoApelacionReconsideracionDTO AsuntoApelacionReconsideracionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AsuntoApelacionReconsideracionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescAsuntoApelacionReconsideracion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescAsuntoApelacionReconsideracion"].Value = AsuntoApelacionReconsideracionDTO.DescAsuntoApelacionReconsideracion;

                    cmd.Parameters.Add("@CodigoAsuntoApelacionReconsideracion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoAsuntoApelacionReconsideracion"].Value = AsuntoApelacionReconsideracionDTO.CodigoAsuntoApelacionReconsideracion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AsuntoApelacionReconsideracionDTO.UsuarioIngresoRegistro;

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

        public AsuntoApelacionReconsideracionDTO BuscarAsuntoApelacionReconsideracionID(int Codigo)
        {
            AsuntoApelacionReconsideracionDTO AsuntoApelacionReconsideracionDTO = new AsuntoApelacionReconsideracionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AsuntoApelacionReconsideracionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AsuntoApelacionReconsideracionId", SqlDbType.Int);
                    cmd.Parameters["@AsuntoApelacionReconsideracionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        AsuntoApelacionReconsideracionDTO.AsuntoApelacionReconsideracionId = Convert.ToInt32(dr["AsuntoApelacionReconsideracionId"]);
                        AsuntoApelacionReconsideracionDTO.DescAsuntoApelacionReconsideracion = dr["DescAsuntoApelacionReconsideracion"].ToString();
                        AsuntoApelacionReconsideracionDTO.CodigoAsuntoApelacionReconsideracion = dr["CodigoAsuntoApelacionReconsideracion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return AsuntoApelacionReconsideracionDTO;
        }

        public string ActualizarAsuntoApelacionReconsideracion(AsuntoApelacionReconsideracionDTO AsuntoApelacionReconsideracionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AsuntoApelacionReconsideracionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AsuntoApelacionReconsideracionId", SqlDbType.Int);
                    cmd.Parameters["@AsuntoApelacionReconsideracionId"].Value = AsuntoApelacionReconsideracionDTO.AsuntoApelacionReconsideracionId;

                    cmd.Parameters.Add("@DescAsuntoApelacionReconsideracion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescAsuntoApelacionReconsideracion"].Value = AsuntoApelacionReconsideracionDTO.DescAsuntoApelacionReconsideracion;

                    cmd.Parameters.Add("@CodigoAsuntoApelacionReconsideracion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoAsuntoApelacionReconsideracion"].Value = AsuntoApelacionReconsideracionDTO.CodigoAsuntoApelacionReconsideracion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AsuntoApelacionReconsideracionDTO.UsuarioIngresoRegistro;

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

        public string EliminarAsuntoApelacionReconsideracion(AsuntoApelacionReconsideracionDTO AsuntoApelacionReconsideracionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AsuntoApelacionReconsideracionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AsuntoApelacionReconsideracionId", SqlDbType.Int);
                    cmd.Parameters["@AsuntoApelacionReconsideracionId"].Value = AsuntoApelacionReconsideracionDTO.AsuntoApelacionReconsideracionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AsuntoApelacionReconsideracionDTO.UsuarioIngresoRegistro;

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
