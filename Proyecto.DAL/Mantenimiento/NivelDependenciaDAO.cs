using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class NivelDependenciaDAO
    {

        SqlCommand cmd = new();

        public List<NivelDependenciaDTO> ObtenerNivelDependencias()
        {
            List<NivelDependenciaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_NivelDependenciaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new NivelDependenciaDTO()
                        {
                            NivelDependenciaId = Convert.ToInt32(dr["NivelDependenciaId"]),
                            DescNivelDependencia = dr["DescNivelDependencia"].ToString(),
                            CodigoNivelDependencia = dr["CodigoNivelDependencia"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarNivelDependencia(NivelDependenciaDTO nivelDependenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_NivelDependenciaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescNivelDependencia", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescNivelDependencia"].Value = nivelDependenciaDTO.DescNivelDependencia;

                    cmd.Parameters.Add("@CodigoNivelDependencia", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoNivelDependencia"].Value = nivelDependenciaDTO.CodigoNivelDependencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = nivelDependenciaDTO.UsuarioIngresoRegistro;

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

        public NivelDependenciaDTO BuscarNivelDependenciaID(int Codigo)
        {
            NivelDependenciaDTO nivelDependenciaDTO = new NivelDependenciaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_NivelDependenciaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NivelDependenciaId", SqlDbType.Int);
                    cmd.Parameters["@NivelDependenciaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        nivelDependenciaDTO.NivelDependenciaId = Convert.ToInt32(dr["NivelDependenciaId"]);
                        nivelDependenciaDTO.DescNivelDependencia = dr["DescNivelDependencia"].ToString();
                        nivelDependenciaDTO.CodigoNivelDependencia = dr["CodigoNivelDependencia"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return nivelDependenciaDTO;
        }

        public string ActualizarNivelDependencia(NivelDependenciaDTO nivelDependenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_NivelDependenciaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NivelDependenciaId", SqlDbType.Int);
                    cmd.Parameters["@NivelDependenciaId"].Value = nivelDependenciaDTO.NivelDependenciaId;

                    cmd.Parameters.Add("@DescNivelDependencia", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescNivelDependencia"].Value = nivelDependenciaDTO.DescNivelDependencia;

                    cmd.Parameters.Add("@CodigoNivelDependencia", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoNivelDependencia"].Value = nivelDependenciaDTO.CodigoNivelDependencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = nivelDependenciaDTO.UsuarioIngresoRegistro;

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

        public string EliminarNivelDependencia(NivelDependenciaDTO nivelDependenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_NivelDependenciaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NivelDependenciaId", SqlDbType.Int);
                    cmd.Parameters["@NivelDependenciaId"].Value = nivelDependenciaDTO.NivelDependenciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = nivelDependenciaDTO.UsuarioIngresoRegistro;

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
