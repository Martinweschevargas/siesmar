using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class InstitucionEducativaSuperiorDAO
    {

        SqlCommand cmd = new();

        public List<InstitucionEducativaSuperiorDTO> ObtenerInstitucionEducativaSuperiors()
        {
            List<InstitucionEducativaSuperiorDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_InstitucionEducativaSuperiorListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new InstitucionEducativaSuperiorDTO()
                        {
                            InstitucionEducativaSuperiorId = Convert.ToInt32(dr["InstitucionEducativaSuperiorId"]),
                            DescInstitucionEducativaSuperior = dr["DescInstitucionEducativaSuperior"].ToString(),
                            CodigoInstitucionEducativaSuperior = dr["CodigoInstitucionEducativaSuperior"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarInstitucionEducativaSuperior(InstitucionEducativaSuperiorDTO institucionEducativaSuperiorDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InstitucionEducativaSuperiorRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescInstitucionEducativaSuperior", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescInstitucionEducativaSuperior"].Value = institucionEducativaSuperiorDTO.DescInstitucionEducativaSuperior;

                    cmd.Parameters.Add("@CodigoInstitucionEducativaSuperior", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoInstitucionEducativaSuperior"].Value = institucionEducativaSuperiorDTO.CodigoInstitucionEducativaSuperior;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = institucionEducativaSuperiorDTO.UsuarioIngresoRegistro;

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

        public InstitucionEducativaSuperiorDTO BuscarInstitucionEducativaSuperiorID(int Codigo)
        {
            InstitucionEducativaSuperiorDTO institucionEducativaSuperiorDTO = new InstitucionEducativaSuperiorDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InstitucionEducativaSuperiorEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InstitucionEducativaSuperiorId", SqlDbType.Int);
                    cmd.Parameters["@InstitucionEducativaSuperiorId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        institucionEducativaSuperiorDTO.InstitucionEducativaSuperiorId = Convert.ToInt32(dr["InstitucionEducativaSuperiorId"]);
                        institucionEducativaSuperiorDTO.DescInstitucionEducativaSuperior = dr["DescInstitucionEducativaSuperior"].ToString();
                        institucionEducativaSuperiorDTO.CodigoInstitucionEducativaSuperior = dr["CodigoInstitucionEducativaSuperior"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return institucionEducativaSuperiorDTO;
        }

        public string ActualizarInstitucionEducativaSuperior(InstitucionEducativaSuperiorDTO institucionEducativaSuperiorDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InstitucionEducativaSuperiorActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InstitucionEducativaSuperiorId", SqlDbType.Int);
                    cmd.Parameters["@InstitucionEducativaSuperiorId"].Value = institucionEducativaSuperiorDTO.InstitucionEducativaSuperiorId;

                    cmd.Parameters.Add("@DescInstitucionEducativaSuperior", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescInstitucionEducativaSuperior"].Value = institucionEducativaSuperiorDTO.DescInstitucionEducativaSuperior;

                    cmd.Parameters.Add("@CodigoInstitucionEducativaSuperior", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoInstitucionEducativaSuperior"].Value = institucionEducativaSuperiorDTO.CodigoInstitucionEducativaSuperior;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = institucionEducativaSuperiorDTO.UsuarioIngresoRegistro;

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

        public string EliminarInstitucionEducativaSuperior(InstitucionEducativaSuperiorDTO institucionEducativaSuperiorDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InstitucionEducativaSuperiorEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InstitucionEducativaSuperiorId", SqlDbType.Int);
                    cmd.Parameters["@InstitucionEducativaSuperiorId"].Value = institucionEducativaSuperiorDTO.InstitucionEducativaSuperiorId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = institucionEducativaSuperiorDTO.UsuarioIngresoRegistro;

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
