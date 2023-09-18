using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoPrestamoConvenioDAO
    {

        SqlCommand cmd = new();

        public List<TipoPrestamoConvenioDTO> ObtenerTipoPrestamoConvenios()
        {
            List<TipoPrestamoConvenioDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoPrestamoConvenioListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoPrestamoConvenioDTO()
                        {
                            TipoPrestamoConvenioId = Convert.ToInt32(dr["TipoPrestamoConvenioId"]),
                            DescTipoPrestamoConvenio = dr["DescTipoPrestamoConvenio"].ToString(),
                            CodigoTipoPrestamoConvenio = dr["CodigoTipoPrestamoConvenio"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoPrestamoConvenio(TipoPrestamoConvenioDTO TipoPrestamoConvenioDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPrestamoConvenioRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoPrestamoConvenio", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescTipoPrestamoConvenio"].Value = TipoPrestamoConvenioDTO.DescTipoPrestamoConvenio;

                    cmd.Parameters.Add("@CodigoTipoPrestamoConvenio", SqlDbType.VarChar, 20);                    
                    cmd.Parameters["@CodigoTipoPrestamoConvenio"].Value = TipoPrestamoConvenioDTO.CodigoTipoPrestamoConvenio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoPrestamoConvenioDTO.UsuarioIngresoRegistro;

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

        public TipoPrestamoConvenioDTO BuscarTipoPrestamoConvenioID(int Codigo)
        {
            TipoPrestamoConvenioDTO TipoPrestamoConvenioDTO = new TipoPrestamoConvenioDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPrestamoConvenioEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPrestamoConvenioId", SqlDbType.Int);
                    cmd.Parameters["@TipoPrestamoConvenioId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        TipoPrestamoConvenioDTO.TipoPrestamoConvenioId = Convert.ToInt32(dr["TipoPrestamoConvenioId"]);
                        TipoPrestamoConvenioDTO.DescTipoPrestamoConvenio = dr["DescTipoPrestamoConvenio"].ToString();
                        TipoPrestamoConvenioDTO.CodigoTipoPrestamoConvenio = dr["CodigoTipoPrestamoConvenio"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return TipoPrestamoConvenioDTO;
        }

        public string ActualizarTipoPrestamoConvenio(TipoPrestamoConvenioDTO TipoPrestamoConvenioDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPrestamoConvenioActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPrestamoConvenioId", SqlDbType.Int);
                    cmd.Parameters["@TipoPrestamoConvenioId"].Value = TipoPrestamoConvenioDTO.TipoPrestamoConvenioId;

                    cmd.Parameters.Add("@DescTipoPrestamoConvenio", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescTipoPrestamoConvenio"].Value = TipoPrestamoConvenioDTO.DescTipoPrestamoConvenio;

                    cmd.Parameters.Add("@CodigoTipoPrestamoConvenio", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoPrestamoConvenio"].Value = TipoPrestamoConvenioDTO.CodigoTipoPrestamoConvenio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoPrestamoConvenioDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoPrestamoConvenio(TipoPrestamoConvenioDTO TipoPrestamoConvenioDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPrestamoConvenioEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPrestamoConvenioId", SqlDbType.Int);
                    cmd.Parameters["@TipoPrestamoConvenioId"].Value = TipoPrestamoConvenioDTO.TipoPrestamoConvenioId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoPrestamoConvenioDTO.UsuarioIngresoRegistro;

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
