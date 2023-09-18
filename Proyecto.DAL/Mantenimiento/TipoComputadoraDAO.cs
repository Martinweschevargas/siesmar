using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoComputadoraDAO
    {

        SqlCommand cmd = new();

        public List<TipoComputadoraDTO> ObtenerTipoComputadoras()
        {
            List<TipoComputadoraDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoComputadoraListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoComputadoraDTO()
                        {
                            TipoComputadoraId = Convert.ToInt32(dr["TipoComputadoraId"]),
                            DescTipoComputadora = dr["DescTipoComputadora"].ToString(),
                            CodigoTipoComputadora = dr["CodigoTipoComputadora"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoComputadora(TipoComputadoraDTO tipoComputadoraDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoComputadoraRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoComputadora", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoComputadora"].Value = tipoComputadoraDTO.DescTipoComputadora;

                    cmd.Parameters.Add("@CodigoTipoComputadora", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoComputadora"].Value = tipoComputadoraDTO.CodigoTipoComputadora;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoComputadoraDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
            return IND_OPERACION;
        }

        public TipoComputadoraDTO BuscarTipoComputadoraID(int Codigo)
        {
            TipoComputadoraDTO tipoComputadoraDTO = new TipoComputadoraDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoComputadoraEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoComputadoraId", SqlDbType.Int);
                    cmd.Parameters["@TipoComputadoraId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoComputadoraDTO.TipoComputadoraId = Convert.ToInt32(dr["TipoComputadoraId"]);
                        tipoComputadoraDTO.DescTipoComputadora = dr["DescTipoComputadora"].ToString();
                        tipoComputadoraDTO.CodigoTipoComputadora = dr["CodigoTipoComputadora"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoComputadoraDTO;
        }

        public string ActualizarTipoComputadora(TipoComputadoraDTO tipoComputadoraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoComputadoraActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoComputadoraId", SqlDbType.Int);
                    cmd.Parameters["@TipoComputadoraId"].Value = tipoComputadoraDTO.TipoComputadoraId;

                    cmd.Parameters.Add("@DescTipoComputadora", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoComputadora"].Value = tipoComputadoraDTO.DescTipoComputadora;

                    cmd.Parameters.Add("@CodigoTipoComputadora", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoComputadora"].Value = tipoComputadoraDTO.CodigoTipoComputadora;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoComputadoraDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
            return IND_OPERACION;
        }

        public string EliminarTipoComputadora(TipoComputadoraDTO tipoComputadoraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoComputadoraEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoComputadoraId", SqlDbType.Int);
                    cmd.Parameters["@TipoComputadoraId"].Value = tipoComputadoraDTO.TipoComputadoraId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoComputadoraDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
            return IND_OPERACION;
        }

    }
}
