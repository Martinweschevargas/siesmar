using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EmpresaProveedoraDAO
    {

        SqlCommand cmd = new();

        public List<EmpresaProveedoraDTO> ObtenerEmpresaProveedoras()
        {
            List<EmpresaProveedoraDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EmpresaProveedoraListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EmpresaProveedoraDTO()
                        {
                            EmpresaProveedoraId = Convert.ToInt32(dr["EmpresaProveedoraId"]),
                            DescEmpresaProveedora = dr["DescEmpresaProveedora"].ToString(),
                            CodigoEmpresaProveedora = dr["CodigoEmpresaProveedora"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEmpresaProveedora(EmpresaProveedoraDTO empresaProveedoraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EmpresaProveedoraRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescEmpresaProveedora", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescEmpresaProveedora"].Value = empresaProveedoraDTO.DescEmpresaProveedora;

                    cmd.Parameters.Add("@CodigoEmpresaProveedora", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoEmpresaProveedora"].Value = empresaProveedoraDTO.CodigoEmpresaProveedora;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = empresaProveedoraDTO.UsuarioIngresoRegistro;

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

        public EmpresaProveedoraDTO BuscarEmpresaProveedoraID(int Codigo)
        {
            EmpresaProveedoraDTO empresaProveedoraDTO = new EmpresaProveedoraDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EmpresaProveedoraEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EmpresaProveedoraId", SqlDbType.Int);
                    cmd.Parameters["@EmpresaProveedoraId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        empresaProveedoraDTO.EmpresaProveedoraId = Convert.ToInt32(dr["EmpresaProveedoraId"]);
                        empresaProveedoraDTO.DescEmpresaProveedora = dr["DescEmpresaProveedora"].ToString();
                        empresaProveedoraDTO.CodigoEmpresaProveedora = dr["CodigoEmpresaProveedora"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return empresaProveedoraDTO;
        }

        public string ActualizarEmpresaProveedora(EmpresaProveedoraDTO empresaProveedoraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EmpresaProveedoraActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EmpresaProveedoraId", SqlDbType.Int);
                    cmd.Parameters["@EmpresaProveedoraId"].Value = empresaProveedoraDTO.EmpresaProveedoraId;

                    cmd.Parameters.Add("@DescEmpresaProveedora", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescEmpresaProveedora"].Value = empresaProveedoraDTO.DescEmpresaProveedora;

                    cmd.Parameters.Add("@CodigoEmpresaProveedora", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoEmpresaProveedora"].Value = empresaProveedoraDTO.CodigoEmpresaProveedora;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = empresaProveedoraDTO.UsuarioIngresoRegistro;

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

        public string EliminarEmpresaProveedora(EmpresaProveedoraDTO empresaProveedoraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EmpresaProveedoraEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EmpresaProveedoraId", SqlDbType.Int);
                    cmd.Parameters["@EmpresaProveedoraId"].Value = empresaProveedoraDTO.EmpresaProveedoraId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = empresaProveedoraDTO.UsuarioIngresoRegistro;

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
