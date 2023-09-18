using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoAsignacionCasaServicioDAO
    {

        SqlCommand cmd = new();

        public List<TipoAsignacionCasaServicioDTO> ObtenerTipoAsignacionCasaServicios()
        {
            List<TipoAsignacionCasaServicioDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoAsignacionCasaServicioListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoAsignacionCasaServicioDTO()
                        {
                            TipoAsignacionCasaServicioId = Convert.ToInt32(dr["TipoAsignacionCasaServicioId"]),
                            DescTipoAsignacionCasaServicio = dr["DescTipoAsignacionCasaServicio"].ToString(),
                            CodigoTipoAsignacionCasaServicio = dr["CodigoTipoAsignacionCasaServicio"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoAsignacionCasaServicio(TipoAsignacionCasaServicioDTO TipoAsignacionCasaServicioDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAsignacionCasaServicioRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoAsignacionCasaServicio", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescTipoAsignacionCasaServicio"].Value = TipoAsignacionCasaServicioDTO.DescTipoAsignacionCasaServicio;

                    cmd.Parameters.Add("@CodigoTipoAsignacionCasaServicio", SqlDbType.VarChar, 20);                    
                    cmd.Parameters["@CodigoTipoAsignacionCasaServicio"].Value = TipoAsignacionCasaServicioDTO.CodigoTipoAsignacionCasaServicio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoAsignacionCasaServicioDTO.UsuarioIngresoRegistro;

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

        public TipoAsignacionCasaServicioDTO BuscarTipoAsignacionCasaServicioID(int Codigo)
        {
            TipoAsignacionCasaServicioDTO TipoAsignacionCasaServicioDTO = new TipoAsignacionCasaServicioDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAsignacionCasaServicioEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoAsignacionCasaServicioId", SqlDbType.Int);
                    cmd.Parameters["@TipoAsignacionCasaServicioId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        TipoAsignacionCasaServicioDTO.TipoAsignacionCasaServicioId = Convert.ToInt32(dr["TipoAsignacionCasaServicioId"]);
                        TipoAsignacionCasaServicioDTO.DescTipoAsignacionCasaServicio = dr["DescTipoAsignacionCasaServicio"].ToString();
                        TipoAsignacionCasaServicioDTO.CodigoTipoAsignacionCasaServicio = dr["CodigoTipoAsignacionCasaServicio"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return TipoAsignacionCasaServicioDTO;
        }

        public string ActualizarTipoAsignacionCasaServicio(TipoAsignacionCasaServicioDTO TipoAsignacionCasaServicioDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAsignacionCasaServicioActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoAsignacionCasaServicioId", SqlDbType.Int);
                    cmd.Parameters["@TipoAsignacionCasaServicioId"].Value = TipoAsignacionCasaServicioDTO.TipoAsignacionCasaServicioId;

                    cmd.Parameters.Add("@DescTipoAsignacionCasaServicio", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescTipoAsignacionCasaServicio"].Value = TipoAsignacionCasaServicioDTO.DescTipoAsignacionCasaServicio;

                    cmd.Parameters.Add("@CodigoTipoAsignacionCasaServicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoAsignacionCasaServicio"].Value = TipoAsignacionCasaServicioDTO.CodigoTipoAsignacionCasaServicio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoAsignacionCasaServicioDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoAsignacionCasaServicio(TipoAsignacionCasaServicioDTO TipoAsignacionCasaServicioDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAsignacionCasaServicioEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoAsignacionCasaServicioId", SqlDbType.Int);
                    cmd.Parameters["@TipoAsignacionCasaServicioId"].Value = TipoAsignacionCasaServicioDTO.TipoAsignacionCasaServicioId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoAsignacionCasaServicioDTO.UsuarioIngresoRegistro;

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
