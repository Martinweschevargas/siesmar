using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ClasificacionCursoDAO
    {

        SqlCommand cmd = new();

        public List<ClasificacionCursoDTO> ObtenerClasificacionCursos()
        {
            List<ClasificacionCursoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ClasificacionCursoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ClasificacionCursoDTO()
                        {
                            ClasificacionCursoId = Convert.ToInt32(dr["ClasificacionCursoId"]),
                            DescClasificacionCurso = dr["DescClasificacionCurso"].ToString(),
                            CodigoClasificacionCurso = dr["CodigoClasificacionCurso"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarClasificacionCurso(ClasificacionCursoDTO clasificacionCursoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionCursoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescClasificacionCurso", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescClasificacionCurso"].Value = clasificacionCursoDTO.DescClasificacionCurso;

                    cmd.Parameters.Add("@CodigoClasificacionCurso", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoClasificacionCurso"].Value = clasificacionCursoDTO.CodigoClasificacionCurso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionCursoDTO.UsuarioIngresoRegistro;

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

        public ClasificacionCursoDTO BuscarClasificacionCursoID(int Codigo)
        {
            ClasificacionCursoDTO clasificacionCursoDTO = new ClasificacionCursoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionCursoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionCursoId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionCursoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        clasificacionCursoDTO.ClasificacionCursoId = Convert.ToInt32(dr["ClasificacionCursoId"]);
                        clasificacionCursoDTO.DescClasificacionCurso = dr["DescClasificacionCurso"].ToString();
                        clasificacionCursoDTO.CodigoClasificacionCurso = dr["CodigoClasificacionCurso"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return clasificacionCursoDTO;
        }

        public string ActualizarClasificacionCurso(ClasificacionCursoDTO clasificacionCursoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionCursoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionCursoId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionCursoId"].Value = clasificacionCursoDTO.ClasificacionCursoId;

                    cmd.Parameters.Add("@DescClasificacionCurso", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClasificacionCurso"].Value = clasificacionCursoDTO.DescClasificacionCurso;

                    cmd.Parameters.Add("@CodigoClasificacionCurso", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoClasificacionCurso"].Value = clasificacionCursoDTO.CodigoClasificacionCurso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionCursoDTO.UsuarioIngresoRegistro;

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

        public string EliminarClasificacionCurso(ClasificacionCursoDTO clasificacionCursoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionCursoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionCursoId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionCursoId"].Value = clasificacionCursoDTO.ClasificacionCursoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionCursoDTO.UsuarioIngresoRegistro;

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
