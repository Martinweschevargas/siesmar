using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoRadiobalizaDAO
    {

        SqlCommand cmd = new();

        public List<TipoRadiobalizaDTO> ObtenerTipoRadiobalizas()
        {
            List<TipoRadiobalizaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoRadiobalizaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoRadiobalizaDTO()
                        {
                            TipoRadiobalizaId = Convert.ToInt32(dr["TipoRadiobalizaId"]),
                            DescTipoRadiobaliza = dr["DescTipoRadiobaliza"].ToString(),
                            CodigoTipoRadiobaliza = dr["CodigoTipoRadiobaliza"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoRadiobaliza(TipoRadiobalizaDTO TipoRadiobalizaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoRadiobalizaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoRadiobaliza", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoRadiobaliza"].Value = TipoRadiobalizaDTO.DescTipoRadiobaliza;

                    cmd.Parameters.Add("@CodigoTipoRadiobaliza", SqlDbType.VarChar, 10);                    
                    cmd.Parameters["@CodigoTipoRadiobaliza"].Value = TipoRadiobalizaDTO.CodigoTipoRadiobaliza;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoRadiobalizaDTO.UsuarioIngresoRegistro;

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

        public TipoRadiobalizaDTO BuscarTipoRadiobalizaID(int Codigo)
        {
            TipoRadiobalizaDTO TipoRadiobalizaDTO = new TipoRadiobalizaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoRadiobalizaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoRadiobalizaId", SqlDbType.Int);
                    cmd.Parameters["@TipoRadiobalizaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        TipoRadiobalizaDTO.TipoRadiobalizaId = Convert.ToInt32(dr["TipoRadiobalizaId"]);
                        TipoRadiobalizaDTO.DescTipoRadiobaliza = dr["DescTipoRadiobaliza"].ToString();
                        TipoRadiobalizaDTO.CodigoTipoRadiobaliza = dr["CodigoTipoRadiobaliza"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return TipoRadiobalizaDTO;
        }

        public string ActualizarTipoRadiobaliza(TipoRadiobalizaDTO TipoRadiobalizaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoRadiobalizaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoRadiobalizaId", SqlDbType.Int);
                    cmd.Parameters["@TipoRadiobalizaId"].Value = TipoRadiobalizaDTO.TipoRadiobalizaId;

                    cmd.Parameters.Add("@DescTipoRadiobaliza", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoRadiobaliza"].Value = TipoRadiobalizaDTO.DescTipoRadiobaliza;

                    cmd.Parameters.Add("@CodigoTipoRadiobaliza", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoRadiobaliza"].Value = TipoRadiobalizaDTO.CodigoTipoRadiobaliza;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoRadiobalizaDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoRadiobaliza(TipoRadiobalizaDTO TipoRadiobalizaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoRadiobalizaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoRadiobalizaId", SqlDbType.Int);
                    cmd.Parameters["@TipoRadiobalizaId"].Value = TipoRadiobalizaDTO.TipoRadiobalizaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoRadiobalizaDTO.UsuarioIngresoRegistro;

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
