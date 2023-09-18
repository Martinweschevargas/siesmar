using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class DptoMercanciaPeligrosaDAO
    {

        SqlCommand cmd = new();

        public List<DptoMercanciaPeligrosaDTO> ObtenerDptoMercanciaPeligrosas()
        {
            List<DptoMercanciaPeligrosaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_DptoMercanciaPeligrosaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DptoMercanciaPeligrosaDTO()
                        {
                            DptoMercanciaPeligrosaId = Convert.ToInt32(dr["DptoMercanciaPeligrosaId"]),
                            DescDptoMercanciaPeligrosa = dr["DescDptoMercanciaPeligrosa"].ToString(),
                            CodigoDptoMercanciaPeligrosa = dr["CodigoDptoMercanciaPeligrosa"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarDptoMercanciaPeligrosa(DptoMercanciaPeligrosaDTO DptoMercanciaPeligrosaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DptoMercanciaPeligrosaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescDptoMercanciaPeligrosa", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescDptoMercanciaPeligrosa"].Value = DptoMercanciaPeligrosaDTO.DescDptoMercanciaPeligrosa;

                    cmd.Parameters.Add("@CodigoDptoMercanciaPeligrosa", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoDptoMercanciaPeligrosa"].Value = DptoMercanciaPeligrosaDTO.CodigoDptoMercanciaPeligrosa;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = DptoMercanciaPeligrosaDTO.UsuarioIngresoRegistro;

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

        public DptoMercanciaPeligrosaDTO BuscarDptoMercanciaPeligrosaID(int Codigo)
        {
            DptoMercanciaPeligrosaDTO DptoMercanciaPeligrosaDTO = new DptoMercanciaPeligrosaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DptoMercanciaPeligrosaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DptoMercanciaPeligrosaId", SqlDbType.Int);
                    cmd.Parameters["@DptoMercanciaPeligrosaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        DptoMercanciaPeligrosaDTO.DptoMercanciaPeligrosaId = Convert.ToInt32(dr["DptoMercanciaPeligrosaId"]);
                        DptoMercanciaPeligrosaDTO.DescDptoMercanciaPeligrosa = dr["DescDptoMercanciaPeligrosa"].ToString();
                        DptoMercanciaPeligrosaDTO.CodigoDptoMercanciaPeligrosa = dr["CodigoDptoMercanciaPeligrosa"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return DptoMercanciaPeligrosaDTO;
        }

        public string ActualizarDptoMercanciaPeligrosa(DptoMercanciaPeligrosaDTO DptoMercanciaPeligrosaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DptoMercanciaPeligrosaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DptoMercanciaPeligrosaId", SqlDbType.Int);
                    cmd.Parameters["@DptoMercanciaPeligrosaId"].Value = DptoMercanciaPeligrosaDTO.DptoMercanciaPeligrosaId;

                    cmd.Parameters.Add("@DescDptoMercanciaPeligrosa", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescDptoMercanciaPeligrosa"].Value = DptoMercanciaPeligrosaDTO.DescDptoMercanciaPeligrosa;

                    cmd.Parameters.Add("@CodigoDptoMercanciaPeligrosa", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoDptoMercanciaPeligrosa"].Value = DptoMercanciaPeligrosaDTO.CodigoDptoMercanciaPeligrosa;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = DptoMercanciaPeligrosaDTO.UsuarioIngresoRegistro;

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

        public string EliminarDptoMercanciaPeligrosa(DptoMercanciaPeligrosaDTO DptoMercanciaPeligrosaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DptoMercanciaPeligrosaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DptoMercanciaPeligrosaId", SqlDbType.Int);
                    cmd.Parameters["@DptoMercanciaPeligrosaId"].Value = DptoMercanciaPeligrosaDTO.DptoMercanciaPeligrosaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = DptoMercanciaPeligrosaDTO.UsuarioIngresoRegistro;

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
