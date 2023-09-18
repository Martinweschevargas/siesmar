using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoCargaDAO
    {

        SqlCommand cmd = new();

        public List<TipoCargaDTO> ObtenerTipoCargas()
        {
            List<TipoCargaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoCargaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoCargaDTO()
                        {
                            TipoCargaId = Convert.ToInt32(dr["TipoCargaId"]),
                            DescTipoCarga = dr["DescTipoCarga"].ToString(),
                            CodigoTipoCarga = dr["CodigoTipoCarga"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoCarga(TipoCargaDTO TipoCargaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoCargaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoCarga", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescTipoCarga"].Value = TipoCargaDTO.DescTipoCarga;

                    cmd.Parameters.Add("@CodigoTipoCarga", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoCarga"].Value = TipoCargaDTO.CodigoTipoCarga;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoCargaDTO.UsuarioIngresoRegistro;

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

        public TipoCargaDTO BuscarTipoCargaID(int Codigo)
        {
            TipoCargaDTO TipoCargaDTO = new TipoCargaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoCargaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoCargaId", SqlDbType.Int);
                    cmd.Parameters["@TipoCargaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        TipoCargaDTO.TipoCargaId = Convert.ToInt32(dr["TipoCargaId"]);
                        TipoCargaDTO.DescTipoCarga = dr["DescTipoCarga"].ToString();
                        TipoCargaDTO.CodigoTipoCarga = dr["CodigoTipoCarga"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return TipoCargaDTO;
        }

        public string ActualizarTipoCarga(TipoCargaDTO TipoCargaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoCargaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoCargaId", SqlDbType.Int);
                    cmd.Parameters["@TipoCargaId"].Value = TipoCargaDTO.TipoCargaId;

                    cmd.Parameters.Add("@DescTipoCarga", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescTipoCarga"].Value = TipoCargaDTO.DescTipoCarga;

                    cmd.Parameters.Add("@CodigoTipoCarga", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoCarga"].Value = TipoCargaDTO.CodigoTipoCarga;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoCargaDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoCarga(TipoCargaDTO TipoCargaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoCargaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoCargaId", SqlDbType.Int);
                    cmd.Parameters["@TipoCargaId"].Value = TipoCargaDTO.TipoCargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoCargaDTO.UsuarioIngresoRegistro;

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
