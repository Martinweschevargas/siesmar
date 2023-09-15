using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoSeleccionDAO
    {

        SqlCommand cmd = new();

        public List<TipoSeleccionDTO> ObtenerTipoSeleccions()
        {
            List<TipoSeleccionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoSeleccionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoSeleccionDTO()
                        {
                            TipoSeleccionId = Convert.ToInt32(dr["TipoSeleccionId"]),
                            DescTipoSeleccion = dr["DescTipoSeleccion"].ToString(),
                            CodigoTipoSeleccion = dr["CodigoTipoSeleccion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoSeleccion(TipoSeleccionDTO tipoSeleccionDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoSeleccionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoSeleccion", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoSeleccion"].Value = tipoSeleccionDTO.DescTipoSeleccion;

                    cmd.Parameters.Add("@CodigoTipoSeleccion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoSeleccion"].Value = tipoSeleccionDTO.CodigoTipoSeleccion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoSeleccionDTO.UsuarioIngresoRegistro;

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

        public TipoSeleccionDTO BuscarTipoSeleccionID(int Codigo)
        {
            TipoSeleccionDTO tipoSeleccionDTO = new TipoSeleccionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoSeleccionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoSeleccionId", SqlDbType.Int);
                    cmd.Parameters["@TipoSeleccionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoSeleccionDTO.TipoSeleccionId = Convert.ToInt32(dr["TipoSeleccionId"]);
                        tipoSeleccionDTO.DescTipoSeleccion = dr["DescTipoSeleccion"].ToString();
                        tipoSeleccionDTO.CodigoTipoSeleccion = dr["CodigoTipoSeleccion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoSeleccionDTO;
        }

        public string ActualizarTipoSeleccion(TipoSeleccionDTO tipoSeleccionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoSeleccionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoSeleccionId", SqlDbType.Int);
                    cmd.Parameters["@TipoSeleccionId"].Value = tipoSeleccionDTO.TipoSeleccionId;

                    cmd.Parameters.Add("@DescTipoSeleccion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoSeleccion"].Value = tipoSeleccionDTO.DescTipoSeleccion;

                    cmd.Parameters.Add("@CodigoTipoSeleccion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoSeleccion"].Value = tipoSeleccionDTO.CodigoTipoSeleccion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoSeleccionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoSeleccion(TipoSeleccionDTO tipoSeleccionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoSeleccionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoSeleccionId", SqlDbType.Int);
                    cmd.Parameters["@TipoSeleccionId"].Value = tipoSeleccionDTO.TipoSeleccionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoSeleccionDTO.UsuarioIngresoRegistro;

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
