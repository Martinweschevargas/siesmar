using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoContraInteligenciaDAO
    {

        SqlCommand cmd = new();

        public List<TipoContraInteligenciaDTO> ObtenerTipoContraInteligencias()
        {
            List<TipoContraInteligenciaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoContrainteligenciaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoContraInteligenciaDTO()
                        {
                            TipoContrainteligenciaId = Convert.ToInt32(dr["TipoContrainteligenciaId"]),
                            DescTipoContrainteligencia = dr["DescTipoContrainteligencia"].ToString(),
                            CodigoTipoContrainteligencia = dr["CodigoTipoContrainteligencia"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoContraInteligencia(TipoContraInteligenciaDTO tipoContraInteligenciaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoContrainteligenciaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoContrainteligencia", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoContrainteligencia"].Value = tipoContraInteligenciaDTO.DescTipoContrainteligencia;

                    cmd.Parameters.Add("@CodigoTipoContrainteligencia", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoContrainteligencia"].Value = tipoContraInteligenciaDTO.CodigoTipoContrainteligencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoContraInteligenciaDTO.UsuarioIngresoRegistro;

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

        public TipoContraInteligenciaDTO BuscarTipoContraInteligenciaID(int Codigo)
        {
            TipoContraInteligenciaDTO tipoContraInteligenciaDTO = new TipoContraInteligenciaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoContrainteligenciaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoContrainteligenciaId", SqlDbType.Int);
                    cmd.Parameters["@TipoContrainteligenciaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoContraInteligenciaDTO.TipoContrainteligenciaId = Convert.ToInt32(dr["TipoContrainteligenciaId"]);
                        tipoContraInteligenciaDTO.DescTipoContrainteligencia = dr["DescTipoContrainteligencia"].ToString();
                        tipoContraInteligenciaDTO.CodigoTipoContrainteligencia = dr["CodigoTipoContrainteligencia"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoContraInteligenciaDTO;
        }

        public string ActualizarTipoContraInteligencia(TipoContraInteligenciaDTO tipoContraInteligenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoContrainteligenciaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoContrainteligenciaId", SqlDbType.Int);
                    cmd.Parameters["@TipoContrainteligenciaId"].Value = tipoContraInteligenciaDTO.TipoContrainteligenciaId;

                    cmd.Parameters.Add("@DescTipoContrainteligencia", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescTipoContrainteligencia"].Value = tipoContraInteligenciaDTO.DescTipoContrainteligencia;

                    cmd.Parameters.Add("@CodigoTipoContrainteligencia", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoContrainteligencia"].Value = tipoContraInteligenciaDTO.CodigoTipoContrainteligencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoContraInteligenciaDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoContraInteligencia(TipoContraInteligenciaDTO tipoContraInteligenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoContrainteligenciaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoContrainteligenciaId", SqlDbType.Int);
                    cmd.Parameters["@TipoContrainteligenciaId"].Value = tipoContraInteligenciaDTO.TipoContrainteligenciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoContraInteligenciaDTO.UsuarioIngresoRegistro;

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
