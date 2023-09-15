using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoVehiculoMovilDAO
    {

        SqlCommand cmd = new();

        public List<TipoVehiculoMovilDTO> ObtenerTipoVehiculoMovils()
        {
            List<TipoVehiculoMovilDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoVehiculoMovilListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoVehiculoMovilDTO()
                        {
                            TipoVehiculoMovilId = Convert.ToInt32(dr["TipoVehiculoMovilId"]),
                            DescTipoVehiculoMovil = dr["DescTipoVehiculoMovil"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoVehiculoMovil(TipoVehiculoMovilDTO TipoVehiculoMovilDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoVehiculoMovilRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoVehiculoMovil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DescTipoVehiculoMovil"].Value = TipoVehiculoMovilDTO.DescTipoVehiculoMovil;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoVehiculoMovilDTO.UsuarioIngresoRegistro;

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

        public TipoVehiculoMovilDTO BuscarTipoVehiculoMovilID(int Codigo)
        {
            TipoVehiculoMovilDTO TipoVehiculoMovilDTO = new TipoVehiculoMovilDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoVehiculoMovilEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoVehiculoMovilId", SqlDbType.Int);
                    cmd.Parameters["@TipoVehiculoMovilId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        TipoVehiculoMovilDTO.TipoVehiculoMovilId = Convert.ToInt32(dr["TipoVehiculoMovilId"]);
                        TipoVehiculoMovilDTO.DescTipoVehiculoMovil = dr["DescTipoVehiculoMovil"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return TipoVehiculoMovilDTO;
        }

        public string ActualizarTipoVehiculoMovil(TipoVehiculoMovilDTO TipoVehiculoMovilDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoVehiculoMovilActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoVehiculoMovilId", SqlDbType.Int);
                    cmd.Parameters["@TipoVehiculoMovilId"].Value = TipoVehiculoMovilDTO.TipoVehiculoMovilId;

                    cmd.Parameters.Add("@DescTipoVehiculoMovil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DescTipoVehiculoMovil"].Value = TipoVehiculoMovilDTO.DescTipoVehiculoMovil;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoVehiculoMovilDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoVehiculoMovil(TipoVehiculoMovilDTO TipoVehiculoMovilDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoVehiculoMovilEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoVehiculoMovilId", SqlDbType.Int);
                    cmd.Parameters["@TipoVehiculoMovilId"].Value = TipoVehiculoMovilDTO.TipoVehiculoMovilId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoVehiculoMovilDTO.UsuarioIngresoRegistro;

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
