using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoAeronaveDAO
    {

        SqlCommand cmd = new();

        public List<TipoAeronaveDTO> ObtenerTipoAeronaves()
        {
            List<TipoAeronaveDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoAeronaveListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoAeronaveDTO()
                        {
                            TipoAeronaveId = Convert.ToInt32(dr["TipoAeronaveId"]),
                            DescTipoAeronave = dr["DescTipoAeronave"].ToString(),
                            CodigoTipoAeronave = dr["CodigoTipoAeronave"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoAeronave(TipoAeronaveDTO tipoAeronaveDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAeronaveRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoAeronave", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoAeronave"].Value = tipoAeronaveDTO.DescTipoAeronave;

                    cmd.Parameters.Add("@CodigoTipoAeronave", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoAeronave"].Value = tipoAeronaveDTO.CodigoTipoAeronave;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoAeronaveDTO.UsuarioIngresoRegistro;

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

        public TipoAeronaveDTO BuscarTipoAeronaveID(int Codigo)
        {
            TipoAeronaveDTO tipoAeronaveDTO = new TipoAeronaveDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAeronaveEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoAeronaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoAeronaveId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoAeronaveDTO.TipoAeronaveId = Convert.ToInt32(dr["TipoAeronaveId"]);
                        tipoAeronaveDTO.DescTipoAeronave = dr["DescTipoAeronave"].ToString();
                        tipoAeronaveDTO.CodigoTipoAeronave = dr["CodigoTipoAeronave"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoAeronaveDTO;
        }

        public string ActualizarTipoAeronave(TipoAeronaveDTO tipoAeronaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoAeronaveActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoAeronaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoAeronaveId"].Value = tipoAeronaveDTO.TipoAeronaveId;

                    cmd.Parameters.Add("@DescTipoAeronave", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoAeronave"].Value = tipoAeronaveDTO.DescTipoAeronave;

                    cmd.Parameters.Add("@CodigoTipoAeronave", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoAeronave"].Value = tipoAeronaveDTO.CodigoTipoAeronave;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoAeronaveDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoAeronave(TipoAeronaveDTO tipoAeronaveDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAeronaveEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoAeronaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoAeronaveId"].Value = tipoAeronaveDTO.TipoAeronaveId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoAeronaveDTO.UsuarioIngresoRegistro;

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
