using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoInspeccionDAO
    {

        SqlCommand cmd = new();

        public List<TipoInspeccionDTO> ObtenerTipoInspeccions()
        {
            List<TipoInspeccionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoInspeccionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoInspeccionDTO()
                        {
                            TipoInspeccionId = Convert.ToInt32(dr["TipoInspeccionId"]),
                            DescTipoInspeccion = dr["DescTipoInspeccion"].ToString(),
                            CodigoTipoInspeccion = dr["DescTipoInspeccion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoInspeccion(TipoInspeccionDTO tipoInspeccionDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoInspeccionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoInspeccion", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoInspeccion"].Value = tipoInspeccionDTO.DescTipoInspeccion;

                    cmd.Parameters.Add("@CodigoTipoInspeccion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoInspeccion"].Value = tipoInspeccionDTO.CodigoTipoInspeccion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoInspeccionDTO.UsuarioIngresoRegistro;

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

        public TipoInspeccionDTO BuscarTipoInspeccionID(int Codigo)
        {
            TipoInspeccionDTO tipoInspeccionDTO = new TipoInspeccionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoInspeccionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoInspeccionId", SqlDbType.Int);
                    cmd.Parameters["@TipoInspeccionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoInspeccionDTO.TipoInspeccionId = Convert.ToInt32(dr["TipoInspeccionId"]);
                        tipoInspeccionDTO.DescTipoInspeccion = dr["DescTipoInspeccion"].ToString();
                        tipoInspeccionDTO.CodigoTipoInspeccion = dr["CodigoTipoInspeccion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoInspeccionDTO;
        }

        public string ActualizarTipoInspeccion(TipoInspeccionDTO tipoInspeccionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoInspeccionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoInspeccionId", SqlDbType.Int);
                    cmd.Parameters["@TipoInspeccionId"].Value = tipoInspeccionDTO.TipoInspeccionId;

                    cmd.Parameters.Add("@DescTipoInspeccion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoInspeccion"].Value = tipoInspeccionDTO.DescTipoInspeccion;

                    cmd.Parameters.Add("@CodigoTipoInspeccion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoInspeccion"].Value = tipoInspeccionDTO.CodigoTipoInspeccion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoInspeccionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoInspeccion(TipoInspeccionDTO tipoInspeccionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoInspeccionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoInspeccionId", SqlDbType.Int);
                    cmd.Parameters["@TipoInspeccionId"].Value = tipoInspeccionDTO.TipoInspeccionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoInspeccionDTO.UsuarioIngresoRegistro;

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
