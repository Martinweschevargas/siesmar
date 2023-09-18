using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class GradoRemunerativoDAO
    {

        SqlCommand cmd = new();

        public List<GradoRemunerativoDTO> ObtenerGradoRemunerativos()
        {
            List<GradoRemunerativoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_GradoRemunerativoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new GradoRemunerativoDTO()
                        {
                            GradoRemunerativoId = Convert.ToInt32(dr["GradoRemunerativoId"]),
                            CodigoGradoRemunerativo = dr["CodigoGradoRemunerativo"].ToString(),
                            DescGradoRemunerativo = dr["DescGradoRemunerativo"].ToString(),
                            DescGradoRemunerativoGrupo = dr["DescGradoRemunerativoGrupo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarGradoRemunerativo(GradoRemunerativoDTO gradoRemunerativoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoRemunerativoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescGradoRemunerativo", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescGradoRemunerativo"].Value = gradoRemunerativoDTO.DescGradoRemunerativo;

                    cmd.Parameters.Add("@CodigoGradoRemunerativo", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoGradoRemunerativo"].Value = gradoRemunerativoDTO.CodigoGradoRemunerativo;

                    cmd.Parameters.Add("@GradoRemunerativoGrupoId", SqlDbType.Int);
                    cmd.Parameters["@GradoRemunerativoGrupoId"].Value = gradoRemunerativoDTO.GradoRemunerativoGrupoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = gradoRemunerativoDTO.UsuarioIngresoRegistro;

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

        public GradoRemunerativoDTO BuscarGradoRemunerativoID(int Codigo)
        {
            GradoRemunerativoDTO gradoRemunerativoDTO = new GradoRemunerativoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoRemunerativoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pIDGradoRemunerativo = new SqlParameter();
                    pIDGradoRemunerativo.ParameterName = "@GradoRemunerativoId";
                    pIDGradoRemunerativo.SqlDbType = SqlDbType.Int;
                    pIDGradoRemunerativo.Value = Codigo;

                    cmd.Parameters.Add(pIDGradoRemunerativo);

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        gradoRemunerativoDTO.GradoRemunerativoId = Convert.ToInt32(dr["GradoRemunerativoId"]);
                        gradoRemunerativoDTO.CodigoGradoRemunerativo = dr["CodigoGradoRemunerativo"].ToString();
                        gradoRemunerativoDTO.DescGradoRemunerativo = dr["DescGradoRemunerativo"].ToString();
                        gradoRemunerativoDTO.GradoRemunerativoGrupoId = Convert.ToInt32(dr["GradoRemunerativoGrupoId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return gradoRemunerativoDTO;
        }

        public string ActualizarGradoRemunerativo(GradoRemunerativoDTO gradoRemunerativoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoRemunerativoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GradoRemunerativoId", SqlDbType.Int);
                    cmd.Parameters["@GradoRemunerativoId"].Value = gradoRemunerativoDTO.GradoRemunerativoId;


                    cmd.Parameters.Add("@CodigoGradoRemunerativo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoRemunerativo"].Value = gradoRemunerativoDTO.CodigoGradoRemunerativo;

                    cmd.Parameters.Add("@DescGradoRemunerativo", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescGradoRemunerativo"].Value = gradoRemunerativoDTO.DescGradoRemunerativo;

                    cmd.Parameters.Add("@GradoRemunerativoGrupoId", SqlDbType.Int);
                    cmd.Parameters["@GradoRemunerativoGrupoId"].Value = gradoRemunerativoDTO.GradoRemunerativoGrupoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = gradoRemunerativoDTO.UsuarioIngresoRegistro;

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

        public string EliminarGradoRemunerativo(GradoRemunerativoDTO gradoRemunerativoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GradoRemunerativoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GradoRemunerativoId", SqlDbType.Int);
                    cmd.Parameters["@GradoRemunerativoId"].Value = gradoRemunerativoDTO.GradoRemunerativoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = gradoRemunerativoDTO.UsuarioIngresoRegistro;

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
