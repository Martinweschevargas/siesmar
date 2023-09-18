using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoSeguridadDAO
    {

        SqlCommand cmd = new();

        public List<TipoSeguridadDTO> ObtenerTipoSeguridads()
        {
            List<TipoSeguridadDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoSeguridadListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoSeguridadDTO()
                        {
                            TipoSeguridadId = Convert.ToInt32(dr["TipoSeguridadId"]),
                            DescTipoSeguridad = dr["DescTipoSeguridad"].ToString(),
                            CodigoTipoSeguridad = dr["CodigoTipoSeguridad"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoSeguridad(TipoSeguridadDTO tipoSeguridadDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoSeguridadRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoSeguridad", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoSeguridad"].Value = tipoSeguridadDTO.DescTipoSeguridad;

                    cmd.Parameters.Add("@CodigoTipoSeguridad", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoSeguridad"].Value = tipoSeguridadDTO.CodigoTipoSeguridad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoSeguridadDTO.UsuarioIngresoRegistro;

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

        public TipoSeguridadDTO BuscarTipoSeguridadID(int Codigo)
        {
            TipoSeguridadDTO tipoSeguridadDTO = new TipoSeguridadDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoSeguridadEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoSeguridadId", SqlDbType.Int);
                    cmd.Parameters["@TipoSeguridadId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoSeguridadDTO.TipoSeguridadId = Convert.ToInt32(dr["TipoSeguridadId"]);
                        tipoSeguridadDTO.DescTipoSeguridad = dr["DescTipoSeguridad"].ToString();
                        tipoSeguridadDTO.CodigoTipoSeguridad = dr["CodigoTipoSeguridad"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoSeguridadDTO;
        }

        public string ActualizarTipoSeguridad(TipoSeguridadDTO tipoSeguridadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoSeguridadActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoSeguridadId", SqlDbType.Int);
                    cmd.Parameters["@TipoSeguridadId"].Value = tipoSeguridadDTO.TipoSeguridadId;

                    cmd.Parameters.Add("@DescTipoSeguridad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoSeguridad"].Value = tipoSeguridadDTO.DescTipoSeguridad;

                    cmd.Parameters.Add("@CodigoTipoSeguridad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoSeguridad"].Value = tipoSeguridadDTO.CodigoTipoSeguridad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoSeguridadDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoSeguridad(TipoSeguridadDTO tipoSeguridadDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoSeguridadEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoSeguridadId", SqlDbType.Int);
                    cmd.Parameters["@TipoSeguridadId"].Value = tipoSeguridadDTO.TipoSeguridadId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoSeguridadDTO.UsuarioIngresoRegistro;

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
