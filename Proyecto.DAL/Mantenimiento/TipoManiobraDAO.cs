using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoManiobraDAO
    {

        SqlCommand cmd = new();

        public List<TipoManiobraDTO> ObtenerTipoManiobras()
        {
            List<TipoManiobraDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoManiobraListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoManiobraDTO()
                        {
                            TipoManiobraId = Convert.ToInt32(dr["TipoManiobraId"]),
                            DescTipoManiobra = dr["DescTipoManiobra"].ToString(),
                            CodigoTipoManiobra = dr["CodigoTipoManiobra"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoManiobra(TipoManiobraDTO tipoManiobraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoManiobraRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoManiobra", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescTipoManiobra"].Value = tipoManiobraDTO.DescTipoManiobra;

                    cmd.Parameters.Add("@CodigoTipoManiobra", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoManiobra"].Value = tipoManiobraDTO.CodigoTipoManiobra;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoManiobraDTO.UsuarioIngresoRegistro;

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

        public TipoManiobraDTO BuscarTipoManiobraID(int Codigo)
        {
            TipoManiobraDTO tipoManiobraDTO = new TipoManiobraDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoManiobraEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoManiobraId", SqlDbType.Int);
                    cmd.Parameters["@TipoManiobraId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoManiobraDTO.TipoManiobraId = Convert.ToInt32(dr["TipoManiobraId"]);
                        tipoManiobraDTO.DescTipoManiobra = dr["DescTipoManiobra"].ToString();
                        tipoManiobraDTO.CodigoTipoManiobra = dr["CodigoTipoManiobra"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoManiobraDTO;
        }

        public string ActualizarTipoManiobra(TipoManiobraDTO tipoManiobraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoManiobraActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoManiobraId", SqlDbType.Int);
                    cmd.Parameters["@TipoManiobraId"].Value = tipoManiobraDTO.TipoManiobraId;

                    cmd.Parameters.Add("@DescTipoManiobra", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescTipoManiobra"].Value = tipoManiobraDTO.DescTipoManiobra;

                    cmd.Parameters.Add("@CodigoTipoManiobra", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoManiobra"].Value = tipoManiobraDTO.CodigoTipoManiobra;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoManiobraDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoManiobra(TipoManiobraDTO tipoManiobraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoManiobraEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoManiobraId", SqlDbType.Int);
                    cmd.Parameters["@TipoManiobraId"].Value = tipoManiobraDTO.TipoManiobraId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoManiobraDTO.UsuarioIngresoRegistro;

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
