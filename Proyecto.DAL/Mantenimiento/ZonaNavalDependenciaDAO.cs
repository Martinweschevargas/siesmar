using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ZonaNavalDependenciaDAO
    {

        SqlCommand cmd = new();

        public List<ZonaNavalDependenciaDTO> ObtenerZonaNavalDependencias()
        {
            List<ZonaNavalDependenciaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ZonaNavalDependenciaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ZonaNavalDependenciaDTO()
                        {
                            ZonaNavalDependenciaId = Convert.ToInt32(dr["ZonaNavalDependenciaId"]),
                            DescZonaNavalDependencia = dr["DescZonaNavalDependencia"].ToString(),
                            CodigoZonaNavalDependencia = dr["CodigoZonaNavalDependencia"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarZonaNavalDependencia(ZonaNavalDependenciaDTO zonaNavalDependenciaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ZonaNavalDependenciaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescZonaNavalDependencia", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescZonaNavalDependencia"].Value = zonaNavalDependenciaDTO.DescZonaNavalDependencia;

                    cmd.Parameters.Add("@CodigoZonaNavalDependencia", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoZonaNavalDependencia"].Value = zonaNavalDependenciaDTO.CodigoZonaNavalDependencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = zonaNavalDependenciaDTO.UsuarioIngresoRegistro;

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
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public ZonaNavalDependenciaDTO BuscarZonaNavalDependenciaID(int Codigo)
        {
            ZonaNavalDependenciaDTO zonaNavalDependenciaDTO = new ZonaNavalDependenciaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ZonaNavalDependenciaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ZonaNavalDependenciaId", SqlDbType.Int);
                    cmd.Parameters["@ZonaNavalDependenciaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        zonaNavalDependenciaDTO.ZonaNavalDependenciaId = Convert.ToInt32(dr["ZonaNavalDependenciaId"]);
                        zonaNavalDependenciaDTO.DescZonaNavalDependencia = dr["DescZonaNavalDependencia"].ToString();
                        zonaNavalDependenciaDTO.CodigoZonaNavalDependencia = dr["CodigoZonaNavalDependencia"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return zonaNavalDependenciaDTO;
        }

        public string ActualizarZonaNavalDependencia(ZonaNavalDependenciaDTO zonaNavalDependenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ZonaNavalDependenciaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ZonaNavalDependenciaId", SqlDbType.Int);
                    cmd.Parameters["@ZonaNavalDependenciaId"].Value = zonaNavalDependenciaDTO.ZonaNavalDependenciaId;

                    cmd.Parameters.Add("@DescZonaNavalDependencia", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescZonaNavalDependencia"].Value = zonaNavalDependenciaDTO.DescZonaNavalDependencia;

                    cmd.Parameters.Add("@CodigoZonaNavalDependencia", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoZonaNavalDependencia"].Value = zonaNavalDependenciaDTO.CodigoZonaNavalDependencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = zonaNavalDependenciaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarZonaNavalDependencia(ZonaNavalDependenciaDTO zonaNavalDependenciaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ZonaNavalDependenciaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ZonaNavalDependenciaId", SqlDbType.Int);
                    cmd.Parameters["@ZonaNavalDependenciaId"].Value = zonaNavalDependenciaDTO.ZonaNavalDependenciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = zonaNavalDependenciaDTO.UsuarioIngresoRegistro;

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
