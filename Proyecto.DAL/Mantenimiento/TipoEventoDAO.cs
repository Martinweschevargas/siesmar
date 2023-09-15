using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoEventoDAO
    {

        SqlCommand cmd = new();

        public List<TipoEventoDTO> ObtenerTipoEventos()
        {
            List<TipoEventoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoEventoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoEventoDTO()
                        {
                            TipoEventoId = Convert.ToInt32(dr["TipoEventoId"]),
                            DescTipoEvento = dr["DescTipoEvento"].ToString(),
                            CodigoTipoEvento = dr["CodigoTipoEvento"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoEvento(TipoEventoDTO tipoEventoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoEventoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoEvento", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoEvento"].Value = tipoEventoDTO.DescTipoEvento;

                    cmd.Parameters.Add("@CodigoTipoEvento", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoEvento"].Value = tipoEventoDTO.CodigoTipoEvento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoEventoDTO.UsuarioIngresoRegistro;

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

        public TipoEventoDTO BuscarTipoEventoID(int Codigo)
        {
            TipoEventoDTO tipoEventoDTO = new TipoEventoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoEventoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoEventoId", SqlDbType.Int);
                    cmd.Parameters["@TipoEventoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoEventoDTO.TipoEventoId = Convert.ToInt32(dr["TipoEventoId"]);
                        tipoEventoDTO.DescTipoEvento = dr["DescTipoEvento"].ToString();
                        tipoEventoDTO.CodigoTipoEvento = dr["CodigoTipoEvento"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoEventoDTO;
        }

        public string ActualizarTipoEvento(TipoEventoDTO tipoEventoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoEventoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoEventoId", SqlDbType.Int);
                    cmd.Parameters["@TipoEventoId"].Value = tipoEventoDTO.TipoEventoId;

                    cmd.Parameters.Add("@DescTipoEvento", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoEvento"].Value = tipoEventoDTO.DescTipoEvento;

                    cmd.Parameters.Add("@CodigoTipoEvento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoEvento"].Value = tipoEventoDTO.CodigoTipoEvento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoEventoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoEvento(TipoEventoDTO tipoEventoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoEventoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoEventoId", SqlDbType.Int);
                    cmd.Parameters["@TipoEventoId"].Value = tipoEventoDTO.TipoEventoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoEventoDTO.UsuarioIngresoRegistro;

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
