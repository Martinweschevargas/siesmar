using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class InstitucionEducativaDAO
    {

        SqlCommand cmd = new();

        public List<InstitucionEducativaDTO> ObtenerInstitucionEducativas()
        {
            List<InstitucionEducativaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_InstitucionEducativaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new InstitucionEducativaDTO()
                        {
                            InstitucionEducativaId = Convert.ToInt32(dr["InstitucionEducativaId"]),
                            DescInstitucionEducativa = dr["DescInstitucionEducativa"].ToString(),
                            CodigoInstitucionEducativa = dr["CodigoInstitucionEducativa"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarInstitucionEducativa(InstitucionEducativaDTO institucionEducativaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InstitucionEducativaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescInstitucionEducativa", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescInstitucionEducativa"].Value = institucionEducativaDTO.DescInstitucionEducativa;

                    cmd.Parameters.Add("@CodigoInstitucionEducativa", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoInstitucionEducativa"].Value = institucionEducativaDTO.CodigoInstitucionEducativa;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = institucionEducativaDTO.UsuarioIngresoRegistro;

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

        public InstitucionEducativaDTO BuscarInstitucionEducativaID(int Codigo)
        {
            InstitucionEducativaDTO institucionEducativaDTO = new InstitucionEducativaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InstitucionEducativaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InstitucionEducativaId", SqlDbType.Int);
                    cmd.Parameters["@InstitucionEducativaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        institucionEducativaDTO.InstitucionEducativaId = Convert.ToInt32(dr["InstitucionEducativaId"]);
                        institucionEducativaDTO.DescInstitucionEducativa = dr["DescInstitucionEducativa"].ToString();
                        institucionEducativaDTO.CodigoInstitucionEducativa = dr["CodigoInstitucionEducativa"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return institucionEducativaDTO;
        }

        public string ActualizarInstitucionEducativa(InstitucionEducativaDTO institucionEducativaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InstitucionEducativaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InstitucionEducativaId", SqlDbType.Int);
                    cmd.Parameters["@InstitucionEducativaId"].Value = institucionEducativaDTO.InstitucionEducativaId;

                    cmd.Parameters.Add("@DescInstitucionEducativa", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescInstitucionEducativa"].Value = institucionEducativaDTO.DescInstitucionEducativa;

                    cmd.Parameters.Add("@CodigoInstitucionEducativa", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoInstitucionEducativa"].Value = institucionEducativaDTO.CodigoInstitucionEducativa;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = institucionEducativaDTO.UsuarioIngresoRegistro;

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

        public string EliminarInstitucionEducativa(InstitucionEducativaDTO institucionEducativaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InstitucionEducativaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InstitucionEducativaId", SqlDbType.Int);
                    cmd.Parameters["@InstitucionEducativaId"].Value = institucionEducativaDTO.InstitucionEducativaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = institucionEducativaDTO.UsuarioIngresoRegistro;

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
