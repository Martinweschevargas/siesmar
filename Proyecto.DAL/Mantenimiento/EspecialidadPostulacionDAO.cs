using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EspecialidadPostulacionDAO
    {

        SqlCommand cmd = new();

        public List<EspecialidadPostulacionDTO> ObtenerEspecialidadPostulacions()
        {
            List<EspecialidadPostulacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EspecialidadPostulacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EspecialidadPostulacionDTO()
                        {
                            EspecialidadPostulacionId = Convert.ToInt32(dr["EspecialidadPostulacionId"]),
                            DescEspecialidadPostulacion = dr["DescEspecialidadPostulacion"].ToString(),
                            CodigoEspecialidadPostulacion = dr["CodigoEspecialidadPostulacion"].ToString(),
                            AbrevEspecialidadPostulacion = dr["AbrevEspecialidadPostulacion"].ToString(),
                            ProfesionalEspecialidadPostulacion = dr["ProfesionalEspecialidadPostulacion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEspecialidadPostulacion(EspecialidadPostulacionDTO especialidadPostulacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecialidadPostulacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescEspecialidadPostulacion", SqlDbType.VarChar, 300);
                    cmd.Parameters["@DescEspecialidadPostulacion"].Value = especialidadPostulacionDTO.DescEspecialidadPostulacion;

                    cmd.Parameters.Add("@CodigoEspecialidadPostulacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadPostulacion"].Value = especialidadPostulacionDTO.CodigoEspecialidadPostulacion;

                    cmd.Parameters.Add("@AbrevEspecialidadPostulacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@AbrevEspecialidadPostulacion"].Value = especialidadPostulacionDTO.AbrevEspecialidadPostulacion;

                    cmd.Parameters.Add("@ProfesionalEspecialidadPostulacion", SqlDbType.VarChar, 300);
                    cmd.Parameters["@ProfesionalEspecialidadPostulacion"].Value = especialidadPostulacionDTO.ProfesionalEspecialidadPostulacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = especialidadPostulacionDTO.UsuarioIngresoRegistro;

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

        public EspecialidadPostulacionDTO BuscarEspecialidadPostulacionID(int Codigo)
        {
            EspecialidadPostulacionDTO especialidadPostulacionDTO = new EspecialidadPostulacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecialidadPostulacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecialidadPostulacionId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadPostulacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        especialidadPostulacionDTO.EspecialidadPostulacionId = Convert.ToInt32(dr["EspecialidadPostulacionId"]);
                        especialidadPostulacionDTO.DescEspecialidadPostulacion = dr["DescEspecialidadPostulacion"].ToString();
                        especialidadPostulacionDTO.CodigoEspecialidadPostulacion = dr["CodigoEspecialidadPostulacion"].ToString();
                        especialidadPostulacionDTO.AbrevEspecialidadPostulacion = dr["AbrevEspecialidadPostulacion"].ToString();
                        especialidadPostulacionDTO.ProfesionalEspecialidadPostulacion = dr["ProfesionalEspecialidadPostulacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return especialidadPostulacionDTO;
        }

        public string ActualizarEspecialidadPostulacion(EspecialidadPostulacionDTO especialidadPostulacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecialidadPostulacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecialidadPostulacionId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadPostulacionId"].Value = especialidadPostulacionDTO.EspecialidadPostulacionId;

                    cmd.Parameters.Add("@DescEspecialidadPostulacion", SqlDbType.VarChar, 300);
                    cmd.Parameters["@DescEspecialidadPostulacion"].Value = especialidadPostulacionDTO.DescEspecialidadPostulacion;

                    cmd.Parameters.Add("@CodigoEspecialidadPostulacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadPostulacion"].Value = especialidadPostulacionDTO.CodigoEspecialidadPostulacion;

                    cmd.Parameters.Add("@AbrevEspecialidadPostulacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@AbrevEspecialidadPostulacion"].Value = especialidadPostulacionDTO.AbrevEspecialidadPostulacion;

                    cmd.Parameters.Add("@ProfesionalEspecialidadPostulacion", SqlDbType.VarChar, 300);
                    cmd.Parameters["@ProfesionalEspecialidadPostulacion"].Value = especialidadPostulacionDTO.ProfesionalEspecialidadPostulacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = especialidadPostulacionDTO.UsuarioIngresoRegistro;

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

        public string EliminarEspecialidadPostulacion(EspecialidadPostulacionDTO especialidadPostulacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EspecialidadPostulacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EspecialidadPostulacionId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadPostulacionId"].Value = especialidadPostulacionDTO.EspecialidadPostulacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = especialidadPostulacionDTO.UsuarioIngresoRegistro;

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
