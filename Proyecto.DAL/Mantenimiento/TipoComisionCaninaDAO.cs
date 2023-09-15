using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoComisionCaninaDAO
    {

        SqlCommand cmd = new();

        public List<TipoComisionCaninaDTO> ObtenerTipoComisionCaninas()
        {
            List<TipoComisionCaninaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoComisionCaninaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoComisionCaninaDTO()
                        {
                            TipoComisionCaninaId = Convert.ToInt32(dr["TipoComisionCaninaId"]),
                            DescTipoComisionCanina = dr["DescTipoComisionCanina"].ToString(),
                            CodigoTipoComisionCanina = dr["CodigoTipoComisionCanina"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoComisionCanina(TipoComisionCaninaDTO tipoComisionCaninaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoComisionCaninaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoComisionCanina", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoComisionCanina"].Value = tipoComisionCaninaDTO.DescTipoComisionCanina;

                    cmd.Parameters.Add("@CodigoTipoComisionCanina", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoComisionCanina"].Value = tipoComisionCaninaDTO.CodigoTipoComisionCanina;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoComisionCaninaDTO.UsuarioIngresoRegistro;

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

        public TipoComisionCaninaDTO BuscarTipoComisionCaninaID(int Codigo)
        {
            TipoComisionCaninaDTO tipoComisionCaninaDTO = new TipoComisionCaninaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoComisionCaninaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoComisionCaninaId", SqlDbType.Int);
                    cmd.Parameters["@TipoComisionCaninaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoComisionCaninaDTO.TipoComisionCaninaId = Convert.ToInt32(dr["TipoComisionCaninaId"]);
                        tipoComisionCaninaDTO.DescTipoComisionCanina = dr["DescTipoComisionCanina"].ToString();
                        tipoComisionCaninaDTO.CodigoTipoComisionCanina = dr["CodigoTipoComisionCanina"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoComisionCaninaDTO;
        }

        public string ActualizarTipoComisionCanina(TipoComisionCaninaDTO tipoComisionCaninaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoComisionCaninaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoComisionCaninaId", SqlDbType.Int);
                    cmd.Parameters["@TipoComisionCaninaId"].Value = tipoComisionCaninaDTO.TipoComisionCaninaId;

                    cmd.Parameters.Add("@DescTipoComisionCanina", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoComisionCanina"].Value = tipoComisionCaninaDTO.DescTipoComisionCanina;

                    cmd.Parameters.Add("@CodigoTipoComisionCanina", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoComisionCanina"].Value = tipoComisionCaninaDTO.CodigoTipoComisionCanina;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoComisionCaninaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoComisionCanina(TipoComisionCaninaDTO tipoComisionCaninaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoComisionCaninaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoComisionCaninaId", SqlDbType.Int);
                    cmd.Parameters["@TipoComisionCaninaId"].Value = tipoComisionCaninaDTO.TipoComisionCaninaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoComisionCaninaDTO.UsuarioIngresoRegistro;

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
