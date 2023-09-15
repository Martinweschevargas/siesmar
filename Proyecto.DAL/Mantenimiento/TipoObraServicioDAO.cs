using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoObraServicioDAO
    {

        SqlCommand cmd = new();

        public List<TipoObraServicioDTO> ObtenerTipoObraServicios()
        {
            List<TipoObraServicioDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoObraServicioListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoObraServicioDTO()
                        {
                            TipoObraServicioId = Convert.ToInt32(dr["TipoObraServicioId"]),
                            DescTipoObraServicio = dr["DescTipoObraServicio"].ToString(),
                            CodigoTipoObraServicio = dr["CodigoTipoObraServicio"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoObraServicio(TipoObraServicioDTO tipoObraServicioDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoObraServicioRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoObraServicio", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoObraServicio"].Value = tipoObraServicioDTO.DescTipoObraServicio;

                    cmd.Parameters.Add("@CodigoTipoObraServicio", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoObraServicio"].Value = tipoObraServicioDTO.CodigoTipoObraServicio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoObraServicioDTO.UsuarioIngresoRegistro;

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

        public TipoObraServicioDTO BuscarTipoObraServicioID(int Codigo)
        {
            TipoObraServicioDTO tipoObraServicioDTO = new TipoObraServicioDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoObraServicioEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoObraServicioId", SqlDbType.Int);
                    cmd.Parameters["@TipoObraServicioId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoObraServicioDTO.TipoObraServicioId = Convert.ToInt32(dr["TipoObraServicioId"]);
                        tipoObraServicioDTO.DescTipoObraServicio = dr["DescTipoObraServicio"].ToString();
                        tipoObraServicioDTO.CodigoTipoObraServicio = dr["CodigoTipoObraServicio"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoObraServicioDTO;
        }

        public string ActualizarTipoObraServicio(TipoObraServicioDTO tipoObraServicioDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoObraServicioActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoObraServicioId", SqlDbType.Int);
                    cmd.Parameters["@TipoObraServicioId"].Value = tipoObraServicioDTO.TipoObraServicioId;

                    cmd.Parameters.Add("@DescTipoObraServicio", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoObraServicio"].Value = tipoObraServicioDTO.DescTipoObraServicio;

                    cmd.Parameters.Add("@CodigoTipoObraServicio", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoObraServicio"].Value = tipoObraServicioDTO.CodigoTipoObraServicio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoObraServicioDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoObraServicio(TipoObraServicioDTO tipoObraServicioDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoObraServicioEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoObraServicioId", SqlDbType.Int);
                    cmd.Parameters["@TipoObraServicioId"].Value = tipoObraServicioDTO.TipoObraServicioId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoObraServicioDTO.UsuarioIngresoRegistro;

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
