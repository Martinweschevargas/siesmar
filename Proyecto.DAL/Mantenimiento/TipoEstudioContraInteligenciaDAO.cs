using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoEstudioContraInteligenciaDAO
    {

        SqlCommand cmd = new();

        public List<TipoEstudioContraInteligenciaDTO> ObtenerTipoEstudioContraInteligencias()
        {
            List<TipoEstudioContraInteligenciaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoEstudioContrainteligenciaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoEstudioContraInteligenciaDTO()
                        {
                            TipoEstudioContrainteligenciaId = Convert.ToInt32(dr["TipoEstudioContrainteligenciaId"]),
                            DescTipoEstudioContrainteligencia = dr["DescTipoEstudioContrainteligencia"].ToString(),
                            CodigoTipoEstudioContrainteligencia = dr["CodigoTipoEstudioContrainteligencia"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoEstudioContraInteligencia(TipoEstudioContraInteligenciaDTO tipoEstudioContraInteligenciaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoEstudioContrainteligenciaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoEstudioContrainteligencia", SqlDbType.VarChar, 60);                    
                    cmd.Parameters["@DescTipoEstudioContrainteligencia"].Value = tipoEstudioContraInteligenciaDTO.DescTipoEstudioContrainteligencia;

                    cmd.Parameters.Add("@CodigoTipoEstudioContrainteligencia", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoEstudioContrainteligencia"].Value = tipoEstudioContraInteligenciaDTO.CodigoTipoEstudioContrainteligencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoEstudioContraInteligenciaDTO.UsuarioIngresoRegistro;

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

        public TipoEstudioContraInteligenciaDTO BuscarTipoEstudioContraInteligenciaID(int Codigo)
        {
            TipoEstudioContraInteligenciaDTO tipoEstudioContraInteligenciaDTO = new TipoEstudioContraInteligenciaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoEstudioContrainteligenciaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoEstudioContrainteligenciaId", SqlDbType.Int);
                    cmd.Parameters["@TipoEstudioContrainteligenciaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoEstudioContraInteligenciaDTO.TipoEstudioContrainteligenciaId = Convert.ToInt32(dr["TipoEstudioContrainteligenciaId"]);
                        tipoEstudioContraInteligenciaDTO.DescTipoEstudioContrainteligencia = dr["DescTipoEstudioContrainteligencia"].ToString();
                        tipoEstudioContraInteligenciaDTO.CodigoTipoEstudioContrainteligencia = dr["CodigoTipoEstudioContrainteligencia"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoEstudioContraInteligenciaDTO;
        }

        public string ActualizarTipoEstudioContraInteligencia(TipoEstudioContraInteligenciaDTO tipoEstudioContraInteligenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoEstudioContrainteligenciaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoEstudioContrainteligenciaId", SqlDbType.Int);
                    cmd.Parameters["@TipoEstudioContrainteligenciaId"].Value = tipoEstudioContraInteligenciaDTO.TipoEstudioContrainteligenciaId;

                    cmd.Parameters.Add("@DescTipoEstudioContrainteligencia", SqlDbType.VarChar, 60);
                    cmd.Parameters["@DescTipoEstudioContrainteligencia"].Value = tipoEstudioContraInteligenciaDTO.DescTipoEstudioContrainteligencia;

                    cmd.Parameters.Add("@CodigoTipoEstudioContrainteligencia", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoEstudioContrainteligencia"].Value = tipoEstudioContraInteligenciaDTO.CodigoTipoEstudioContrainteligencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoEstudioContraInteligenciaDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoEstudioContraInteligencia(TipoEstudioContraInteligenciaDTO tipoEstudioContraInteligenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoEstudioContrainteligenciaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoEstudioContrainteligenciaId", SqlDbType.Int);
                    cmd.Parameters["@TipoEstudioContrainteligenciaId"].Value = tipoEstudioContraInteligenciaDTO.TipoEstudioContrainteligenciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoEstudioContraInteligenciaDTO.UsuarioIngresoRegistro;

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
