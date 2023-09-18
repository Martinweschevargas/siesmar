using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CargoDotacionDAO
    {

        SqlCommand cmd = new();

        public List<CargoDotacionDTO> ObtenerCargoDotacions()
        {
            List<CargoDotacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CargoDotacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CargoDotacionDTO()
                        {
                            CargoDotacionId = Convert.ToInt32(dr["CargoDotacionId"]),
                            DescCargoDotacion = dr["DescCargoDotacion"].ToString(),
                            CodigoCargoDotacion = dr["CodigoCargoDotacion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCargoDotacion(CargoDotacionDTO CargoDotacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CargoDotacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCargoDotacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCargoDotacion"].Value = CargoDotacionDTO.DescCargoDotacion;

                    cmd.Parameters.Add("@CodigoCargoDotacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCargoDotacion"].Value = CargoDotacionDTO.CodigoCargoDotacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CargoDotacionDTO.UsuarioIngresoRegistro;

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

        public CargoDotacionDTO BuscarCargoDotacionID(int Codigo)
        {
            CargoDotacionDTO CargoDotacionDTO = new CargoDotacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CargoDotacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CargoDotacionId", SqlDbType.Int);
                    cmd.Parameters["@CargoDotacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        CargoDotacionDTO.CargoDotacionId = Convert.ToInt32(dr["CargoDotacionId"]);
                        CargoDotacionDTO.DescCargoDotacion = dr["DescCargoDotacion"].ToString();
                        CargoDotacionDTO.CodigoCargoDotacion = dr["CodigoCargoDotacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return CargoDotacionDTO;
        }

        public string ActualizarCargoDotacion(CargoDotacionDTO CargoDotacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CargoDotacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CargoDotacionId", SqlDbType.Int);
                    cmd.Parameters["@CargoDotacionId"].Value = CargoDotacionDTO.CargoDotacionId;

                    cmd.Parameters.Add("@DescCargoDotacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCargoDotacion"].Value = CargoDotacionDTO.DescCargoDotacion;

                    cmd.Parameters.Add("@CodigoCargoDotacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCargoDotacion"].Value = CargoDotacionDTO.CodigoCargoDotacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CargoDotacionDTO.UsuarioIngresoRegistro;

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

        public string EliminarCargoDotacion(CargoDotacionDTO CargoDotacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CargoDotacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CargoDotacionId", SqlDbType.Int);
                    cmd.Parameters["@CargoDotacionId"].Value = CargoDotacionDTO.CargoDotacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CargoDotacionDTO.UsuarioIngresoRegistro;

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
