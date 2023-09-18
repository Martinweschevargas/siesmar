using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoVinculoDAO
    {

        SqlCommand cmd = new();

        public List<TipoVinculoDTO> ObtenerTipoVinculos()
        {
            List<TipoVinculoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoVinculoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoVinculoDTO()
                        {
                            TipoVinculoId = Convert.ToInt32(dr["TipoVinculoId"]),
                            DescTipoVinculo = dr["DescTipoVinculo"].ToString(),
                            CodigoTipoVinculo = dr["CodigoTipoVinculo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoVinculo(TipoVinculoDTO tipoVinculoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoVinculoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoVinculo", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoVinculo"].Value = tipoVinculoDTO.DescTipoVinculo;

                    cmd.Parameters.Add("@CodigoTipoVinculo", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoVinculo"].Value = tipoVinculoDTO.CodigoTipoVinculo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoVinculoDTO.UsuarioIngresoRegistro;

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

        public TipoVinculoDTO BuscarTipoVinculoID(int Codigo)
        {
            TipoVinculoDTO tipoVinculoDTO = new TipoVinculoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoVinculoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoVinculoId", SqlDbType.Int);
                    cmd.Parameters["@TipoVinculoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoVinculoDTO.TipoVinculoId = Convert.ToInt32(dr["TipoVinculoId"]);
                        tipoVinculoDTO.DescTipoVinculo = dr["DescTipoVinculo"].ToString();
                        tipoVinculoDTO.CodigoTipoVinculo = dr["CodigoTipoVinculo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoVinculoDTO;
        }

        public string ActualizarTipoVinculo(TipoVinculoDTO tipoVinculoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoVinculoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoVinculoId", SqlDbType.Int);
                    cmd.Parameters["@TipoVinculoId"].Value = tipoVinculoDTO.TipoVinculoId;

                    cmd.Parameters.Add("@DescTipoVinculo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoVinculo"].Value = tipoVinculoDTO.DescTipoVinculo;

                    cmd.Parameters.Add("@CodigoTipoVinculo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoVinculo"].Value = tipoVinculoDTO.CodigoTipoVinculo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoVinculoDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoVinculo(TipoVinculoDTO tipoVinculoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoVinculoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoVinculoId", SqlDbType.Int);
                    cmd.Parameters["@TipoVinculoId"].Value = tipoVinculoDTO.TipoVinculoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoVinculoDTO.UsuarioIngresoRegistro;

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
