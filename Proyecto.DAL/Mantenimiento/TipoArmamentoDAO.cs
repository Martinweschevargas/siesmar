using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoArmamentoDAO
    {

        SqlCommand cmd = new();

        public List<TipoArmamentoDTO> ObtenerTipoArmamentos()
        {
            List<TipoArmamentoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoArmamentoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoArmamentoDTO()
                        {
                            TipoArmamentoId = Convert.ToInt32(dr["TipoArmamentoId"]),
                            DescTipoArmamento = dr["DescTipoArmamento"].ToString(),
                            CodigoTipoArmamento = dr["CodigoTipoArmamento"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoArmamento(TipoArmamentoDTO tipoArmamentoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoArmamentoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoArmamento", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoArmamento"].Value = tipoArmamentoDTO.DescTipoArmamento;

                    cmd.Parameters.Add("@CodigoTipoArmamento", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoArmamento"].Value = tipoArmamentoDTO.CodigoTipoArmamento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoArmamentoDTO.UsuarioIngresoRegistro;

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

        public TipoArmamentoDTO BuscarTipoArmamentoID(int Codigo)
        {
            TipoArmamentoDTO tipoArmamentoDTO = new TipoArmamentoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoArmamentoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoArmamentoId", SqlDbType.Int);
                    cmd.Parameters["@TipoArmamentoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoArmamentoDTO.TipoArmamentoId = Convert.ToInt32(dr["TipoArmamentoId"]);
                        tipoArmamentoDTO.DescTipoArmamento = dr["DescTipoArmamento"].ToString();
                        tipoArmamentoDTO.CodigoTipoArmamento = dr["CodigoTipoArmamento"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoArmamentoDTO;
        }

        public string ActualizarTipoArmamento(TipoArmamentoDTO tipoArmamentoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoArmamentoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoArmamentoId", SqlDbType.Int);
                    cmd.Parameters["@TipoArmamentoId"].Value = tipoArmamentoDTO.TipoArmamentoId;

                    cmd.Parameters.Add("@DescTipoArmamento", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoArmamento"].Value = tipoArmamentoDTO.DescTipoArmamento;

                    cmd.Parameters.Add("@CodigoTipoArmamento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoArmamento"].Value = tipoArmamentoDTO.CodigoTipoArmamento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoArmamentoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoArmamento(TipoArmamentoDTO tipoArmamentoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoArmamentoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoArmamentoId", SqlDbType.Int);
                    cmd.Parameters["@TipoArmamentoId"].Value = tipoArmamentoDTO.TipoArmamentoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoArmamentoDTO.UsuarioIngresoRegistro;

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
