using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CodigoEscuelaDAO
    {

        SqlCommand cmd = new();

        public List<CodigoEscuelaDTO> ObtenerCodigoEscuelas()
        {
            List<CodigoEscuelaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CodigoEscuelaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CodigoEscuelaDTO()
                        {
                            CodigoEscuelaId = Convert.ToInt32(dr["CodigoEscuelaId"]),
                            DescCodigoEscuela = dr["DescCodigoEscuela"].ToString(),
                            CodigoCodigoEscuela = dr["CodigoCodigoEscuela"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCodigoEscuela(CodigoEscuelaDTO codigoEscuelaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CodigoEscuelasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@DescCodigoEscuela", SqlDbType.VarChar, 80);

                    cmd.Parameters["@DescCodigoEscuela"].Value = codigoEscuelaDTO.DescCodigoEscuela;

                    cmd.Parameters.Add("@CodigoCodigoEscuela", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoCodigoEscuela"].Value = codigoEscuelaDTO.CodigoCodigoEscuela;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = codigoEscuelaDTO.UsuarioIngresoRegistro;

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

        public CodigoEscuelaDTO BuscarCodigoEscuelaID(int Codigo)
        {
            CodigoEscuelaDTO codigoEscuelaDTO = new CodigoEscuelaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CodigoEscuelasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoEscuelaId", SqlDbType.Int);
                    cmd.Parameters["@CodigoEscuelaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        codigoEscuelaDTO.CodigoEscuelaId = Convert.ToInt32(dr["CodigoEscuelaId"]);
                        codigoEscuelaDTO.DescCodigoEscuela = dr["DescCodigoEscuela"].ToString();
                        codigoEscuelaDTO.CodigoCodigoEscuela = dr["CodigoCodigoEscuela"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return codigoEscuelaDTO;
        }

        public string ActualizarCodigoEscuela(CodigoEscuelaDTO codigoEscuelaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CodigoEscuelasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoEscuelaId", SqlDbType.Int);
                    cmd.Parameters["@CodigoEscuelaId"].Value = codigoEscuelaDTO.CodigoEscuelaId;

                    cmd.Parameters.Add("@DescCodigoEscuela", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescCodigoEscuela"].Value = codigoEscuelaDTO.DescCodigoEscuela;

                    cmd.Parameters.Add("@CodigoCodigoEscuela", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCodigoEscuela"].Value = codigoEscuelaDTO.CodigoCodigoEscuela;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = codigoEscuelaDTO.UsuarioIngresoRegistro;

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

        public string EliminarCodigoEscuela(CodigoEscuelaDTO codigoEscuelaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CodigoEscuelasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoEscuelaId", SqlDbType.Int);
                    cmd.Parameters["@CodigoEscuelaId"].Value = codigoEscuelaDTO.CodigoEscuelaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = codigoEscuelaDTO.UsuarioIngresoRegistro;

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
