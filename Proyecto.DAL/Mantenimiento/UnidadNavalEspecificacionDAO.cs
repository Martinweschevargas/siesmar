using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class UnidadNavalEspecificacionDAO
    {

        SqlCommand cmd = new();

        public List<UnidadNavalEspecificacionDTO> ObtenerUnidadNavalEspecificacions()
        {
            List<UnidadNavalEspecificacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_UnidadNavalEspecificacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new UnidadNavalEspecificacionDTO()
                        {
                            UnidadNavalEspecificacionId = Convert.ToInt32(dr["UnidadNavalEspecificacionId"]),
                            DescUnidadNavalEspecificacion = dr["DescUnidadNavalEspecificacion"].ToString(),
                            CodigoUnidadNavalEspecificacion = dr["CodigoUnidadNavalEspecificacion"].ToString(),
                            DescUnidadNavalTipo = dr["DescUnidadNavalTipo"].ToString(),
                            nCasoUnidadNavalEspecificacion = dr["nCasoUnidadNavalEspecificacion"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarUnidadNavalEspecificacion(UnidadNavalEspecificacionDTO unidadNavalEspecificacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadNavalEspecificacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescUnidadNavalEspecificacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescUnidadNavalEspecificacion"].Value = unidadNavalEspecificacionDTO.DescUnidadNavalEspecificacion;

                    cmd.Parameters.Add("@CodigoUnidadNavalEspecificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNavalEspecificacion"].Value = unidadNavalEspecificacionDTO.CodigoUnidadNavalEspecificacion;

                    cmd.Parameters.Add("@nCasoUnidadNavalEspecificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@nCasoUnidadNavalEspecificacion"].Value = unidadNavalEspecificacionDTO.nCasoUnidadNavalEspecificacion;

                    cmd.Parameters.Add("@UnidadNavalTipoId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalTipoId"].Value = unidadNavalEspecificacionDTO.UnidadNavalTipoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadNavalEspecificacionDTO.UsuarioIngresoRegistro;

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

        public UnidadNavalEspecificacionDTO BuscarUnidadNavalEspecificacionID(int Codigo)
        {
            UnidadNavalEspecificacionDTO unidadNavalEspecificacionDTO = new UnidadNavalEspecificacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadNavalEspecificacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalEspecificacionId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalEspecificacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        unidadNavalEspecificacionDTO.UnidadNavalEspecificacionId = Convert.ToInt32(dr["UnidadNavalEspecificacionId"]);
                        unidadNavalEspecificacionDTO.DescUnidadNavalEspecificacion = dr["DescUnidadNavalEspecificacion"].ToString();
                        unidadNavalEspecificacionDTO.CodigoUnidadNavalEspecificacion = dr["CodigoUnidadNavalEspecificacion"].ToString();
                        unidadNavalEspecificacionDTO.UnidadNavalTipoId = Convert.ToInt32(dr["UnidadNavalTipoId"]);
                        unidadNavalEspecificacionDTO.nCasoUnidadNavalEspecificacion = dr["nCasoUnidadNavalEspecificacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return unidadNavalEspecificacionDTO;
        }

        public string ActualizarUnidadNavalEspecificacion(UnidadNavalEspecificacionDTO unidadNavalEspecificacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_UnidadNavalEspecificacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalEspecificacionId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalEspecificacionId"].Value = unidadNavalEspecificacionDTO.UnidadNavalEspecificacionId;

                    cmd.Parameters.Add("@DescUnidadNavalEspecificacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescUnidadNavalEspecificacion"].Value = unidadNavalEspecificacionDTO.DescUnidadNavalEspecificacion;

                    cmd.Parameters.Add("@CodigoUnidadNavalEspecificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNavalEspecificacion"].Value = unidadNavalEspecificacionDTO.CodigoUnidadNavalEspecificacion;

                    cmd.Parameters.Add("@nCasoUnidadNavalEspecificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@nCasoUnidadNavalEspecificacion"].Value = unidadNavalEspecificacionDTO.nCasoUnidadNavalEspecificacion;

                    cmd.Parameters.Add("@UnidadNavalTipoId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalTipoId"].Value = unidadNavalEspecificacionDTO.UnidadNavalTipoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadNavalEspecificacionDTO.UsuarioIngresoRegistro;

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

        public string EliminarUnidadNavalEspecificacion(UnidadNavalEspecificacionDTO unidadNavalEspecificacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadNavalEspecificacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalEspecificacionId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalEspecificacionId"].Value = unidadNavalEspecificacionDTO.UnidadNavalEspecificacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadNavalEspecificacionDTO.UsuarioIngresoRegistro;

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
