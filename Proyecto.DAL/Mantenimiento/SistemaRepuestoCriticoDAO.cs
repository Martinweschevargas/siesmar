using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SistemaRepuestoCriticoDAO
    {

        SqlCommand cmd = new();

        public List<SistemaRepuestoCriticoDTO> ObtenerSistemaRepuestoCriticos()
        {
            List<SistemaRepuestoCriticoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SistemaRepuestoCriticoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SistemaRepuestoCriticoDTO()
                        {
                            SistemaRepuestoCriticoId = Convert.ToInt32(dr["SistemaRepuestoCriticoId"]),
                            DescSistemaRepuestoCritico = dr["DescSistemaRepuestoCritico"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSistemaRepuestoCritico(SistemaRepuestoCriticoDTO capitaniaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SistemaRepuestoCriticoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescSistemaRepuestoCritico", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescSistemaRepuestoCritico"].Value = capitaniaDTO.DescSistemaRepuestoCritico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capitaniaDTO.UsuarioIngresoRegistro;

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

        public SistemaRepuestoCriticoDTO BuscarSistemaRepuestoCriticoID(int Codigo)
        {
            SistemaRepuestoCriticoDTO capitaniaDTO = new SistemaRepuestoCriticoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SistemaRepuestoCriticoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SistemaRepuestoCriticoId", SqlDbType.Int);
                    cmd.Parameters["@SistemaRepuestoCriticoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        capitaniaDTO.SistemaRepuestoCriticoId = Convert.ToInt32(dr["SistemaRepuestoCriticoId"]);
                        capitaniaDTO.DescSistemaRepuestoCritico = dr["DescSistemaRepuestoCritico"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return capitaniaDTO;
        }

        public string ActualizarSistemaRepuestoCritico(SistemaRepuestoCriticoDTO capitaniaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SistemaRepuestoCriticoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SistemaRepuestoCriticoId", SqlDbType.Int);
                    cmd.Parameters["@SistemaRepuestoCriticoId"].Value = capitaniaDTO.SistemaRepuestoCriticoId;

                    cmd.Parameters.Add("@DescSistemaRepuestoCritico", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescSistemaRepuestoCritico"].Value = capitaniaDTO.DescSistemaRepuestoCritico;
        
                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capitaniaDTO.UsuarioIngresoRegistro;

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

        public string EliminarSistemaRepuestoCritico(SistemaRepuestoCriticoDTO capitaniaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SistemaRepuestoCriticoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SistemaRepuestoCriticoId", SqlDbType.Int);
                    cmd.Parameters["@SistemaRepuestoCriticoId"].Value = capitaniaDTO.SistemaRepuestoCriticoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capitaniaDTO.UsuarioIngresoRegistro;

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
