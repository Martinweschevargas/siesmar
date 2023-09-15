using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoMantenimientoDAO
    {

        SqlCommand cmd = new();

        public List<TipoMantenimientoDTO> ObtenerTipoMantenimientos()
        {
            List<TipoMantenimientoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoMantenimientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoMantenimientoDTO()
                        {
                            TipoMantenimientoId = Convert.ToInt32(dr["TipoMantenimientoId"]),
                            DescTipoMantenimiento = dr["DescTipoMantenimiento"].ToString(),
                            CodigoTipoMantenimiento = dr["CodigoTipoMantenimiento"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoMantenimiento(TipoMantenimientoDTO tipoMantenimientoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoMantenimientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoMantenimiento", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoMantenimiento"].Value = tipoMantenimientoDTO.DescTipoMantenimiento;

                    cmd.Parameters.Add("@CodigoTipoMantenimiento", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoMantenimiento"].Value = tipoMantenimientoDTO.CodigoTipoMantenimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoMantenimientoDTO.UsuarioIngresoRegistro;

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

        public TipoMantenimientoDTO BuscarTipoMantenimientoID(int Codigo)
        {
            TipoMantenimientoDTO tipoMantenimientoDTO = new TipoMantenimientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoMantenimientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoMantenimientoId", SqlDbType.Int);
                    cmd.Parameters["@TipoMantenimientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoMantenimientoDTO.TipoMantenimientoId = Convert.ToInt32(dr["TipoMantenimientoId"]);
                        tipoMantenimientoDTO.DescTipoMantenimiento = dr["DescTipoMantenimiento"].ToString();
                        tipoMantenimientoDTO.CodigoTipoMantenimiento = dr["CodigoTipoMantenimiento"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoMantenimientoDTO;
        }

        public string ActualizarTipoMantenimiento(TipoMantenimientoDTO tipoMantenimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoMantenimientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoMantenimientoId", SqlDbType.Int);
                    cmd.Parameters["@TipoMantenimientoId"].Value = tipoMantenimientoDTO.TipoMantenimientoId;

                    cmd.Parameters.Add("@DescTipoMantenimiento", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoMantenimiento"].Value = tipoMantenimientoDTO.DescTipoMantenimiento;

                    cmd.Parameters.Add("@CodigoTipoMantenimiento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoMantenimiento"].Value = tipoMantenimientoDTO.CodigoTipoMantenimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoMantenimientoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoMantenimiento(TipoMantenimientoDTO tipoMantenimientoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoMantenimientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoMantenimientoId", SqlDbType.Int);
                    cmd.Parameters["@TipoMantenimientoId"].Value = tipoMantenimientoDTO.TipoMantenimientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoMantenimientoDTO.UsuarioIngresoRegistro;

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
