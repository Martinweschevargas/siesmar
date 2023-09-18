using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoSiniestroDAO
    {

        SqlCommand cmd = new();

        public List<TipoSiniestroDTO> ObtenerTipoSiniestros()
        {
            List<TipoSiniestroDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoSiniestroListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoSiniestroDTO()
                        {
                            TipoSiniestroId = Convert.ToInt32(dr["TipoSiniestroId"]),
                            DescTipoSiniestro = dr["DescTipoSiniestro"].ToString(),
                            CodTipoSiniestro = dr["CodigoTipoSiniestro"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoSiniestro(TipoSiniestroDTO TipoSiniestroDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoSiniestroRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoSiniestro", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescTipoSiniestro"].Value = TipoSiniestroDTO.DescTipoSiniestro;

                    cmd.Parameters.Add("@CodigoTipoSiniestro", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoSiniestro"].Value = TipoSiniestroDTO.CodTipoSiniestro;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoSiniestroDTO.UsuarioIngresoRegistro;

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

        public TipoSiniestroDTO BuscarTipoSiniestroID(int Codigo)
        {
            TipoSiniestroDTO TipoSiniestroDTO = new TipoSiniestroDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoSiniestroEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoSiniestroId", SqlDbType.Int);
                    cmd.Parameters["@TipoSiniestroId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        TipoSiniestroDTO.TipoSiniestroId = Convert.ToInt32(dr["TipoSiniestroId"]);
                        TipoSiniestroDTO.DescTipoSiniestro = dr["DescTipoSiniestro"].ToString();
                        TipoSiniestroDTO.CodTipoSiniestro = dr["CodigoTipoSiniestro"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return TipoSiniestroDTO;
        }

        public string ActualizarTipoSiniestro(TipoSiniestroDTO TipoSiniestroDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoSiniestroActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoSiniestroId", SqlDbType.Int);
                    cmd.Parameters["@TipoSiniestroId"].Value = TipoSiniestroDTO.TipoSiniestroId;

                    cmd.Parameters.Add("@DescTipoSiniestro", SqlDbType.VarChar, 10);
                    cmd.Parameters["@DescTipoSiniestro"].Value = TipoSiniestroDTO.DescTipoSiniestro;

                    cmd.Parameters.Add("@CodigoTipoSiniestro", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoSiniestro"].Value = TipoSiniestroDTO.CodTipoSiniestro;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoSiniestroDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoSiniestro(TipoSiniestroDTO TipoSiniestroDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoSiniestroEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoSiniestroId", SqlDbType.Int);
                    cmd.Parameters["@TipoSiniestroId"].Value = TipoSiniestroDTO.TipoSiniestroId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoSiniestroDTO.UsuarioIngresoRegistro;

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
