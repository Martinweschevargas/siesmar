using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoEntidadAcademicaDAO
    {

        SqlCommand cmd = new();

        public List<TipoEntidadAcademicaDTO> ObtenerTipoEntidadAcademicas()
        {
            List<TipoEntidadAcademicaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoEntidadAcademicaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoEntidadAcademicaDTO()
                        {
                            TipoEntidadAcademicaId = Convert.ToInt32(dr["TipoEntidadAcademicaId"]),
                            DescTipoEntidadAcademica = dr["DescTipoEntidadAcademica"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoEntidadAcademica(TipoEntidadAcademicaDTO tipoEntidadAcademicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoEntidadAcademicaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoEntidadAcademica", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoEntidadAcademica"].Value = tipoEntidadAcademicaDTO.DescTipoEntidadAcademica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoEntidadAcademicaDTO.UsuarioIngresoRegistro;

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

        public TipoEntidadAcademicaDTO BuscarTipoEntidadAcademicaID(int Codigo)
        {
            TipoEntidadAcademicaDTO tipoEntidadAcademicaDTO = new TipoEntidadAcademicaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoEntidadAcademicaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoEntidadAcademicaId", SqlDbType.Int);
                    cmd.Parameters["@TipoEntidadAcademicaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoEntidadAcademicaDTO.TipoEntidadAcademicaId = Convert.ToInt32(dr["TipoEntidadAcademicaId"]);
                        tipoEntidadAcademicaDTO.DescTipoEntidadAcademica = dr["DescTipoEntidadAcademica"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoEntidadAcademicaDTO;
        }

        public string ActualizarTipoEntidadAcademica(TipoEntidadAcademicaDTO tipoEntidadAcademicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoEntidadAcademicaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoEntidadAcademicaId", SqlDbType.Int);
                    cmd.Parameters["@TipoEntidadAcademicaId"].Value = tipoEntidadAcademicaDTO.TipoEntidadAcademicaId;

                    cmd.Parameters.Add("@DescTipoEntidadAcademica", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoEntidadAcademica"].Value = tipoEntidadAcademicaDTO.DescTipoEntidadAcademica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoEntidadAcademicaDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoEntidadAcademica(TipoEntidadAcademicaDTO tipoEntidadAcademicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoEntidadAcademicaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoEntidadAcademicaId", SqlDbType.Int);
                    cmd.Parameters["@TipoEntidadAcademicaId"].Value = tipoEntidadAcademicaDTO.TipoEntidadAcademicaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoEntidadAcademicaDTO.UsuarioIngresoRegistro;

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
