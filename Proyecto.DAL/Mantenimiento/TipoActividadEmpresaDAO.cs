using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoActividadEmpresaDAO
    {

        SqlCommand cmd = new();

        public List<TipoActividadEmpresaDTO> ObtenerTipoActividadEmpresas()
        {
            List<TipoActividadEmpresaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoActividadEmpresaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoActividadEmpresaDTO()
                        {
                            TipoActividadEmpresaId = Convert.ToInt32(dr["TipoActividadEmpresaId"]),
                            DescTipoActividadEmpresa = dr["DescTipoActividadEmpresa"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoActividadEmpresa(TipoActividadEmpresaDTO tipoActividadEmpresaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoActividadEmpresaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoActividadEmpresa", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoActividadEmpresa"].Value = tipoActividadEmpresaDTO.DescTipoActividadEmpresa;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoActividadEmpresaDTO.UsuarioIngresoRegistro;

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

        public TipoActividadEmpresaDTO BuscarTipoActividadEmpresaID(int Codigo)
        {
            TipoActividadEmpresaDTO tipoActividadEmpresaDTO = new TipoActividadEmpresaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoActividadEmpresaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoActividadEmpresaId", SqlDbType.Int);
                    cmd.Parameters["@TipoActividadEmpresaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoActividadEmpresaDTO.TipoActividadEmpresaId = Convert.ToInt32(dr["TipoActividadEmpresaId"]);
                        tipoActividadEmpresaDTO.DescTipoActividadEmpresa = dr["DescTipoActividadEmpresa"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoActividadEmpresaDTO;
        }

        public string ActualizarTipoActividadEmpresa(TipoActividadEmpresaDTO tipoActividadEmpresaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoActividadEmpresaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoActividadEmpresaId", SqlDbType.Int);
                    cmd.Parameters["@TipoActividadEmpresaId"].Value = tipoActividadEmpresaDTO.TipoActividadEmpresaId;

                    cmd.Parameters.Add("@DescTipoActividadEmpresa", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoActividadEmpresa"].Value = tipoActividadEmpresaDTO.DescTipoActividadEmpresa;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoActividadEmpresaDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoActividadEmpresa(TipoActividadEmpresaDTO tipoActividadEmpresaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoActividadEmpresaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoActividadEmpresaId", SqlDbType.Int);
                    cmd.Parameters["@TipoActividadEmpresaId"].Value = tipoActividadEmpresaDTO.TipoActividadEmpresaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoActividadEmpresaDTO.UsuarioIngresoRegistro;

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
