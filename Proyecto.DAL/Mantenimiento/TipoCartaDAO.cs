using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoCartaDAO
    {

        SqlCommand cmd = new();

        public List<TipoCartaDTO> ObtenerTipoCartas()
        {
            List<TipoCartaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoCartaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoCartaDTO()
                        {
                            TipoCartaId = Convert.ToInt32(dr["TipoCartaId"]),
                            DescTipoCarta = dr["DescTipoCarta"].ToString(),
                            CodigoTipoCarta = dr["CodigoTipoCarta"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoCarta(TipoCartaDTO TipoCartaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoCartaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoCarta", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoCarta"].Value = TipoCartaDTO.DescTipoCarta;

                    cmd.Parameters.Add("@CodigoTipoCarta", SqlDbType.VarChar, 10);                    
                    cmd.Parameters["@CodigoTipoCarta"].Value = TipoCartaDTO.CodigoTipoCarta;                 

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoCartaDTO.UsuarioIngresoRegistro;

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

        public TipoCartaDTO BuscarTipoCartaID(int Codigo)
        {
            TipoCartaDTO TipoCartaDTO = new TipoCartaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoCartaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoCartaId", SqlDbType.Int);
                    cmd.Parameters["@TipoCartaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        TipoCartaDTO.TipoCartaId = Convert.ToInt32(dr["TipoCartaId"]);
                        TipoCartaDTO.DescTipoCarta = dr["DescTipoCarta"].ToString();
                        TipoCartaDTO.CodigoTipoCarta = dr["CodigoTipoCarta"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return TipoCartaDTO;
        }

        public string ActualizarTipoCarta(TipoCartaDTO TipoCartaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoCartaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoCartaId", SqlDbType.Int);
                    cmd.Parameters["@TipoCartaId"].Value = TipoCartaDTO.TipoCartaId;

                    cmd.Parameters.Add("@DescTipoCarta", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoCarta"].Value = TipoCartaDTO.DescTipoCarta;

                    cmd.Parameters.Add("@CodigoTipoCarta", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoCarta"].Value = TipoCartaDTO.CodigoTipoCarta;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoCartaDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoCarta(TipoCartaDTO TipoCartaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoCartaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoCartaId", SqlDbType.Int);
                    cmd.Parameters["@TipoCartaId"].Value = TipoCartaDTO.TipoCartaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoCartaDTO.UsuarioIngresoRegistro;

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
