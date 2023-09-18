using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class GrupoClasificacionEspecialidadDAO
    {

        SqlCommand cmd = new();

        public List<GrupoClasificacionEspecialidadDTO> ObtenerGrupoClasificacionEspecialidads()
        {
            List<GrupoClasificacionEspecialidadDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_GrupoClasificacionEspecialidadListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new GrupoClasificacionEspecialidadDTO()
                        {
                            GrupoClasificacionEspecialidadId = Convert.ToInt32(dr["GrupoClasificacionEspecialidadId"]),
                            DescGrupoClasificacionEspecialidad = dr["DescGrupoClasificacionEspecialidad"].ToString(),
                            CodigoGrupoClasificacionEspecialidad = dr["CodigoGrupoClasificacionEspecialidad"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarGrupoClasificacionEspecialidad(GrupoClasificacionEspecialidadDTO grupoClasificacionEspecialidadDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoClasificacionEspecialidadRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescGrupoClasificacionEspecialidad", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescGrupoClasificacionEspecialidad"].Value = grupoClasificacionEspecialidadDTO.DescGrupoClasificacionEspecialidad;

                    cmd.Parameters.Add("@CodigoGrupoClasificacionEspecialidad", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoGrupoClasificacionEspecialidad"].Value = grupoClasificacionEspecialidadDTO.CodigoGrupoClasificacionEspecialidad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = grupoClasificacionEspecialidadDTO.UsuarioIngresoRegistro;

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

        public GrupoClasificacionEspecialidadDTO BuscarGrupoClasificacionEspecialidadID(int Codigo)
        {
            GrupoClasificacionEspecialidadDTO grupoClasificacionEspecialidadDTO = new GrupoClasificacionEspecialidadDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoClasificacionEspecialidadEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoClasificacionEspecialidadId", SqlDbType.Int);
                    cmd.Parameters["@GrupoClasificacionEspecialidadId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        grupoClasificacionEspecialidadDTO.GrupoClasificacionEspecialidadId = Convert.ToInt32(dr["GrupoClasificacionEspecialidadId"]);
                        grupoClasificacionEspecialidadDTO.DescGrupoClasificacionEspecialidad = dr["DescGrupoClasificacionEspecialidad"].ToString();
                        grupoClasificacionEspecialidadDTO.CodigoGrupoClasificacionEspecialidad = dr["CodigoGrupoClasificacionEspecialidad"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return grupoClasificacionEspecialidadDTO;
        }

        public string ActualizarGrupoClasificacionEspecialidad(GrupoClasificacionEspecialidadDTO grupoClasificacionEspecialidadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_GrupoClasificacionEspecialidadActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoClasificacionEspecialidadId", SqlDbType.Int);
                    cmd.Parameters["@GrupoClasificacionEspecialidadId"].Value = grupoClasificacionEspecialidadDTO.GrupoClasificacionEspecialidadId;

                    cmd.Parameters.Add("@DescGrupoClasificacionEspecialidad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescGrupoClasificacionEspecialidad"].Value = grupoClasificacionEspecialidadDTO.DescGrupoClasificacionEspecialidad;

                    cmd.Parameters.Add("@CodigoGrupoClasificacionEspecialidad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoGrupoClasificacionEspecialidad"].Value = grupoClasificacionEspecialidadDTO.CodigoGrupoClasificacionEspecialidad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = grupoClasificacionEspecialidadDTO.UsuarioIngresoRegistro;

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

        public bool EliminarGrupoClasificacionEspecialidad(GrupoClasificacionEspecialidadDTO grupoClasificacionEspecialidadDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoClasificacionEspecialidadEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoClasificacionEspecialidadId", SqlDbType.Int);
                    cmd.Parameters["@GrupoClasificacionEspecialidadId"].Value = grupoClasificacionEspecialidadDTO.GrupoClasificacionEspecialidadId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = grupoClasificacionEspecialidadDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    cmd.ExecuteNonQuery();
                    eliminado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return eliminado;
        }

    }
}
