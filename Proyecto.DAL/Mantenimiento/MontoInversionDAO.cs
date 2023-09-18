using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class MontoInversionDAO
    {

        SqlCommand cmd = new();

        public List<MontoInversionDTO> ObtenerMontoInversions()
        {
            List<MontoInversionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_MontoInversionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MontoInversionDTO()
                        {
                            MontoInversionId = Convert.ToInt32(dr["MontoInversionId"]),
                            DescMontoInversion = dr["DescMontoInversion"].ToString(),
                            CodigoMontoInversion = dr["CodigoMontoInversion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarMontoInversion(MontoInversionDTO montoInversionDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MontoInversionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescMontoInversion", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescMontoInversion"].Value = montoInversionDTO.DescMontoInversion;

                    cmd.Parameters.Add("@CodigoMontoInversion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoMontoInversion"].Value = montoInversionDTO.CodigoMontoInversion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = montoInversionDTO.UsuarioIngresoRegistro;

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

        public MontoInversionDTO BuscarMontoInversionID(int Codigo)
        {
            MontoInversionDTO montoInversionDTO = new MontoInversionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MontoInversionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MontoInversionId", SqlDbType.Int);
                    cmd.Parameters["@MontoInversionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        montoInversionDTO.MontoInversionId = Convert.ToInt32(dr["MontoInversionId"]);
                        montoInversionDTO.DescMontoInversion = dr["DescMontoInversion"].ToString();
                        montoInversionDTO.CodigoMontoInversion = dr["CodigoMontoInversion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return montoInversionDTO;
        }

        public string ActualizarMontoInversion(MontoInversionDTO montoInversionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_MontoInversionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MontoInversionId", SqlDbType.Int);
                    cmd.Parameters["@MontoInversionId"].Value = montoInversionDTO.MontoInversionId;

                    cmd.Parameters.Add("@DescMontoInversion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescMontoInversion"].Value = montoInversionDTO.DescMontoInversion;

                    cmd.Parameters.Add("@CodigoMontoInversion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMontoInversion"].Value = montoInversionDTO.CodigoMontoInversion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = montoInversionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarMontoInversion(int Codigo)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MontoInversionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MontoInversionId", SqlDbType.Int);
                    cmd.Parameters["@MontoInversionId"].Value = Codigo;
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
