using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class OcupacionPersonalCivilDAO
    {

        SqlCommand cmd = new();

        public List<OcupacionPersonalCivilDTO> ObtenerOcupacionPersonalCivils()
        {
            List<OcupacionPersonalCivilDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_OcupacionPersonalCivilListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new OcupacionPersonalCivilDTO()
                        {
                            OcupacionPersonalCivilId = Convert.ToInt32(dr["OcupacionPersonalCivilId"]),
                            DescOcupacionPersonalCivil = dr["DescOcupacionPersonalCivil"].ToString(),
                            CodigoOcupacionPersonalCivil = dr["CodigoOcupacionPersonalCivil"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarOcupacionPersonalCivil(OcupacionPersonalCivilDTO ocupacionPersonalCivilDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_OcupacionPersonalCivilRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescOcupacionPersonalCivil", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescOcupacionPersonalCivil"].Value = ocupacionPersonalCivilDTO.DescOcupacionPersonalCivil;

                    cmd.Parameters.Add("@CodigoOcupacionPersonalCivil", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoOcupacionPersonalCivil"].Value = ocupacionPersonalCivilDTO.CodigoOcupacionPersonalCivil;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ocupacionPersonalCivilDTO.UsuarioIngresoRegistro;

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
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public OcupacionPersonalCivilDTO BuscarOcupacionPersonalCivilID(int Codigo)
        {
            OcupacionPersonalCivilDTO ocupacionPersonalCivilDTO = new OcupacionPersonalCivilDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_OcupacionPersonalCivilEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OcupacionPersonalCivilId", SqlDbType.Int);
                    cmd.Parameters["@OcupacionPersonalCivilId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ocupacionPersonalCivilDTO.OcupacionPersonalCivilId = Convert.ToInt32(dr["OcupacionPersonalCivilId"]);
                        ocupacionPersonalCivilDTO.DescOcupacionPersonalCivil = dr["DescOcupacionPersonalCivil"].ToString();
                        ocupacionPersonalCivilDTO.CodigoOcupacionPersonalCivil = dr["CodigoOcupacionPersonalCivil"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ocupacionPersonalCivilDTO;
        }

        public string ActualizarOcupacionPersonalCivil(OcupacionPersonalCivilDTO ocupacionPersonalCivilDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_OcupacionPersonalCivilActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OcupacionPersonalCivilId", SqlDbType.Int);
                    cmd.Parameters["@OcupacionPersonalCivilId"].Value = ocupacionPersonalCivilDTO.OcupacionPersonalCivilId;

                    cmd.Parameters.Add("@DescOcupacionPersonalCivil", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescOcupacionPersonalCivil"].Value = ocupacionPersonalCivilDTO.DescOcupacionPersonalCivil;

                    cmd.Parameters.Add("@CodigoOcupacionPersonalCivil", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoOcupacionPersonalCivil"].Value = ocupacionPersonalCivilDTO.CodigoOcupacionPersonalCivil;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ocupacionPersonalCivilDTO.UsuarioIngresoRegistro;

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

        public bool EliminarOcupacionPersonalCivil(int Codigo)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_OcupacionPersonalCivilEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OcupacionPersonalCivilId", SqlDbType.Int);
                    cmd.Parameters["@OcupacionPersonalCivilId"].Value = Codigo;
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
