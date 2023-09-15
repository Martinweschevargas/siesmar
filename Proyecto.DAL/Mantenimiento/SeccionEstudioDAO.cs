using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SeccionEstudioDAO
    {

        SqlCommand cmd = new();

        public List<SeccionEstudioDTO> ObtenerSeccionEstudios()
        {
            List<SeccionEstudioDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SeccionEstudioListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SeccionEstudioDTO()
                        {
                            SeccionEstudioId = Convert.ToInt32(dr["SeccionEstudioId"]),
                            DescSeccionEstudio = dr["DescSeccionEstudio"].ToString(),
                            CodigoSeccionEstudio = dr["CodigoSeccionEstudio"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSeccionEstudio(SeccionEstudioDTO SeccionEstudioDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SeccionEstudioRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescSeccionEstudio", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescSeccionEstudio"].Value = SeccionEstudioDTO.DescSeccionEstudio;

                    cmd.Parameters.Add("@CodigoSeccionEstudio", SqlDbType.VarChar, 10);                    
                    cmd.Parameters["@CodigoSeccionEstudio"].Value = SeccionEstudioDTO.CodigoSeccionEstudio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = SeccionEstudioDTO.UsuarioIngresoRegistro;

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

        public SeccionEstudioDTO BuscarSeccionEstudioID(int Codigo)
        {
            SeccionEstudioDTO SeccionEstudioDTO = new SeccionEstudioDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SeccionEstudioEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SeccionEstudioId", SqlDbType.Int);
                    cmd.Parameters["@SeccionEstudioId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        SeccionEstudioDTO.SeccionEstudioId = Convert.ToInt32(dr["SeccionEstudioId"]);
                        SeccionEstudioDTO.DescSeccionEstudio = dr["DescSeccionEstudio"].ToString();
                        SeccionEstudioDTO.CodigoSeccionEstudio = dr["CodigoSeccionEstudio"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return SeccionEstudioDTO;
        }

        public string ActualizarSeccionEstudio(SeccionEstudioDTO SeccionEstudioDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SeccionEstudioActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SeccionEstudioId", SqlDbType.Int);
                    cmd.Parameters["@SeccionEstudioId"].Value = SeccionEstudioDTO.SeccionEstudioId;

                    cmd.Parameters.Add("@DescSeccionEstudio", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescSeccionEstudio"].Value = SeccionEstudioDTO.DescSeccionEstudio;

                    cmd.Parameters.Add("@CodigoSeccionEstudio", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoSeccionEstudio"].Value = SeccionEstudioDTO.CodigoSeccionEstudio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = SeccionEstudioDTO.UsuarioIngresoRegistro;

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

        public string EliminarSeccionEstudio(SeccionEstudioDTO SeccionEstudioDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SeccionEstudioEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SeccionEstudioId", SqlDbType.Int);
                    cmd.Parameters["@SeccionEstudioId"].Value = SeccionEstudioDTO.SeccionEstudioId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = SeccionEstudioDTO.UsuarioIngresoRegistro;

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
