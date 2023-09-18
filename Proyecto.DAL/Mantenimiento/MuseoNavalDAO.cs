
using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class MuseoNavalDAO
    {

        SqlCommand cmd = new();

        public List<MuseoNavalDTO> ObtenerMuseoNavals()
        {
            List<MuseoNavalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_MuseoNavalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MuseoNavalDTO()
                        {
                            MuseoNavalId = Convert.ToInt32(dr["MuseoNavalId"]),
                            DescMuseoNaval = dr["DescMuseoNaval"].ToString(),
                            CodigoMuseoNaval = dr["CodigoMuseoNaval"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarMuseoNaval(MuseoNavalDTO museoNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MuseoNavalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescMuseoNaval", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescMuseoNaval"].Value = museoNavalDTO.DescMuseoNaval;

                    cmd.Parameters.Add("@CodigoMuseoNaval", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoMuseoNaval"].Value = museoNavalDTO.CodigoMuseoNaval;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = museoNavalDTO.UsuarioIngresoRegistro;

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

        public MuseoNavalDTO BuscarMuseoNavalID(int Codigo)
        {
            MuseoNavalDTO museoNavalDTO = new MuseoNavalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MuseoNavalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MuseoNavalId", SqlDbType.Int);
                    cmd.Parameters["@MuseoNavalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        museoNavalDTO.MuseoNavalId = Convert.ToInt32(dr["MuseoNavalId"]);
                        museoNavalDTO.DescMuseoNaval = dr["DescMuseoNaval"].ToString();
                        museoNavalDTO.CodigoMuseoNaval = dr["CodigoMuseoNaval"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return museoNavalDTO;
        }

        public string ActualizarMuseoNaval(MuseoNavalDTO museoNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_MuseoNavalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MuseoNavalId", SqlDbType.Int);
                    cmd.Parameters["@MuseoNavalId"].Value = museoNavalDTO.MuseoNavalId;

                    cmd.Parameters.Add("@DescMuseoNaval", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescMuseoNaval"].Value = museoNavalDTO.DescMuseoNaval;

                    cmd.Parameters.Add("@CodigoMuseoNaval", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMuseoNaval"].Value = museoNavalDTO.CodigoMuseoNaval;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = museoNavalDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public bool EliminarMuseoNaval(MuseoNavalDTO museoNavalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MuseoNavalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MuseoNavalId", SqlDbType.Int);
                    cmd.Parameters["@MuseoNavalId"].Value = museoNavalDTO.MuseoNavalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = museoNavalDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    cmd.ExecuteNonQuery();
                    eliminado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return eliminado;
        }

    }
}
