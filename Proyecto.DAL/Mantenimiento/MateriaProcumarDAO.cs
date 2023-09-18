using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class MateriaProcumarDAO
    {

        SqlCommand cmd = new();

        public List<MateriaProcumarDTO> ObtenerMateriaProcumars()
        {
            List<MateriaProcumarDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_MateriaProcumarListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MateriaProcumarDTO()
                        {
                            MateriaProcumarId = Convert.ToInt32(dr["MateriaProcumarId"]),
                            DescMateriaProcumar = dr["DescMateriaProcumar"].ToString(),
                            CodigoMateriaProcumar = dr["CodigoMateriaProcumar"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarMateriaProcumar(MateriaProcumarDTO materiaProcumarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MateriaProcumarRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescMateriaProcumar", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescMateriaProcumar"].Value = materiaProcumarDTO.DescMateriaProcumar;

                    cmd.Parameters.Add("@CodigoMateriaProcumar", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoMateriaProcumar"].Value = materiaProcumarDTO.CodigoMateriaProcumar;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = materiaProcumarDTO.UsuarioIngresoRegistro;

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

        public MateriaProcumarDTO BuscarMateriaProcumarID(int Codigo)
        {
            MateriaProcumarDTO materiaProcumarDTO = new MateriaProcumarDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MateriaProcumarEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MateriaProcumarId", SqlDbType.Int);
                    cmd.Parameters["@MateriaProcumarId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        materiaProcumarDTO.MateriaProcumarId = Convert.ToInt32(dr["MateriaProcumarId"]);
                        materiaProcumarDTO.DescMateriaProcumar = dr["DescMateriaProcumar"].ToString();
                        materiaProcumarDTO.CodigoMateriaProcumar = dr["CodigoMateriaProcumar"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return materiaProcumarDTO;
        }

        public string ActualizarMateriaProcumar(MateriaProcumarDTO materiaProcumarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MateriaProcumarActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MateriaProcumarId", SqlDbType.Int);
                    cmd.Parameters["@MateriaProcumarId"].Value = materiaProcumarDTO.MateriaProcumarId;

                    cmd.Parameters.Add("@DescMateriaProcumar", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescMateriaProcumar"].Value = materiaProcumarDTO.DescMateriaProcumar;

                    cmd.Parameters.Add("@CodigoMateriaProcumar", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMateriaProcumar"].Value = materiaProcumarDTO.CodigoMateriaProcumar;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = materiaProcumarDTO.UsuarioIngresoRegistro;

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

        public string EliminarMateriaProcumar(MateriaProcumarDTO materiaProcumarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MateriaProcumarEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MateriaProcumarId", SqlDbType.Int);
                    cmd.Parameters["@MateriaProcumarId"].Value = materiaProcumarDTO.MateriaProcumarId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = materiaProcumarDTO.UsuarioIngresoRegistro;

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
