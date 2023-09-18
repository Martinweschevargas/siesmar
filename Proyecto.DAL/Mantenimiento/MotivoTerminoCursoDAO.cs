using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class MotivoTerminoCursoDAO
    {

        SqlCommand cmd = new();

        public List<MotivoTerminoCursoDTO> ObtenerMotivoTerminoCursos()
        {
            List<MotivoTerminoCursoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_MotivoTerminoCursoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MotivoTerminoCursoDTO()
                        {
                            MotivoTerminoCursoId = Convert.ToInt32(dr["MotivoTerminoCursoId"]),
                            DescMotivoTerminoCurso = dr["DescMotivoTerminoCurso"].ToString(),
                            CodigoMotivoTerminoCurso = dr["CodigoMotivoTerminoCurso"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarMotivoTerminoCurso(MotivoTerminoCursoDTO motivoTerminoCursoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MotivoTerminoCursoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescMotivoTerminoCurso", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescMotivoTerminoCurso"].Value = motivoTerminoCursoDTO.DescMotivoTerminoCurso;

                    cmd.Parameters.Add("@CodigoMotivoTerminoCurso", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoMotivoTerminoCurso"].Value = motivoTerminoCursoDTO.CodigoMotivoTerminoCurso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = motivoTerminoCursoDTO.UsuarioIngresoRegistro;

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

        public MotivoTerminoCursoDTO BuscarMotivoTerminoCursoID(int Codigo)
        {
            MotivoTerminoCursoDTO motivoTerminoCursoDTO = new MotivoTerminoCursoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MotivoTerminoCursoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MotivoTerminoCursoId", SqlDbType.Int);
                    cmd.Parameters["@MotivoTerminoCursoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        motivoTerminoCursoDTO.MotivoTerminoCursoId = Convert.ToInt32(dr["MotivoTerminoCursoId"]);
                        motivoTerminoCursoDTO.DescMotivoTerminoCurso = dr["DescMotivoTerminoCurso"].ToString();
                        motivoTerminoCursoDTO.CodigoMotivoTerminoCurso = dr["CodigoMotivoTerminoCurso"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return motivoTerminoCursoDTO;
        }

        public string ActualizarMotivoTerminoCurso(MotivoTerminoCursoDTO motivoTerminoCursoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MotivoTerminoCursoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MotivoTerminoCursoId", SqlDbType.Int);
                    cmd.Parameters["@MotivoTerminoCursoId"].Value = motivoTerminoCursoDTO.MotivoTerminoCursoId;

                    cmd.Parameters.Add("@DescMotivoTerminoCurso", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescMotivoTerminoCurso"].Value = motivoTerminoCursoDTO.DescMotivoTerminoCurso;

                    cmd.Parameters.Add("@CodigoMotivoTerminoCurso", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMotivoTerminoCurso"].Value = motivoTerminoCursoDTO.CodigoMotivoTerminoCurso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = motivoTerminoCursoDTO.UsuarioIngresoRegistro;

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

        public string EliminarMotivoTerminoCurso(MotivoTerminoCursoDTO motivoTerminoCursoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MotivoTerminoCursoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MotivoTerminoCursoId", SqlDbType.Int);
                    cmd.Parameters["@MotivoTerminoCursoId"].Value = motivoTerminoCursoDTO.MotivoTerminoCursoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = motivoTerminoCursoDTO.UsuarioIngresoRegistro;

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
