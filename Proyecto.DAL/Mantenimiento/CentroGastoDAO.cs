using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CentroGastoDAO
    {

        SqlCommand cmd = new();

        public List<CentroGastoDTO> ObtenerCentroGastos()
        {
            List<CentroGastoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CentroGastoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CentroGastoDTO()
                        {
                            CentroGastoId = Convert.ToInt32(dr["CentroGastoId"]),
                            DescCentroGasto = dr["DescCentroGasto"].ToString(),
                            CodigoCentroGasto = dr["CodigoCentroGasto"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCentroGasto(CentroGastoDTO CentroGastoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CentroGastoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCentroGasto", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCentroGasto"].Value = CentroGastoDTO.DescCentroGasto;

                    cmd.Parameters.Add("@CodigoCentroGasto", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCentroGasto"].Value = CentroGastoDTO.CodigoCentroGasto;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CentroGastoDTO.UsuarioIngresoRegistro;

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

        public CentroGastoDTO BuscarCentroGastoID(int Codigo)
        {
            CentroGastoDTO CentroGastoDTO = new CentroGastoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CentroGastoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CentroGastoId", SqlDbType.Int);
                    cmd.Parameters["@CentroGastoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        CentroGastoDTO.CentroGastoId = Convert.ToInt32(dr["CentroGastoId"]);
                        CentroGastoDTO.DescCentroGasto = dr["DescCentroGasto"].ToString();
                        CentroGastoDTO.CodigoCentroGasto = dr["CodigoCentroGasto"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return CentroGastoDTO;
        }

        public string ActualizarCentroGasto(CentroGastoDTO CentroGastoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CentroGastoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CentroGastoId", SqlDbType.Int);
                    cmd.Parameters["@CentroGastoId"].Value = CentroGastoDTO.CentroGastoId;

                    cmd.Parameters.Add("@DescCentroGasto", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCentroGasto"].Value = CentroGastoDTO.DescCentroGasto;

                    cmd.Parameters.Add("@CodigoCentroGasto", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCentroGasto"].Value = CentroGastoDTO.CodigoCentroGasto;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CentroGastoDTO.UsuarioIngresoRegistro;

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

        public string EliminarCentroGasto(CentroGastoDTO CentroGastoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CentroGastoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CentroGastoId", SqlDbType.Int);
                    cmd.Parameters["@CentroGastoId"].Value = CentroGastoDTO.CentroGastoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CentroGastoDTO.UsuarioIngresoRegistro;

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
