using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class MedidaAdaptadaDisposicionFinalDAO
    {

        SqlCommand cmd = new();

        public List<MedidaAdaptadaDisposicionFinalDTO> ObtenerMedidaAdaptadaDisposicionFinals()
        {
            List<MedidaAdaptadaDisposicionFinalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_MedidaAdaptadaDisposicionFinalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MedidaAdaptadaDisposicionFinalDTO()
                        {
                            MedidaAdaptadaDisposicionFinalId = Convert.ToInt32(dr["MedidaAdaptadaDisposicionFinalId"]),
                            DescMedidaAdaptadaDisposicionFinal = dr["DescMedidaAdaptadaDisposicionFinal"].ToString(),
                            CodigoMedidaAdaptadaDisposicionFinal = dr["CodigoMedidaAdaptadaDisposicionFinal"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarMedidaAdaptadaDisposicionFinal(MedidaAdaptadaDisposicionFinalDTO MedidaAdaptadaDisposicionFinalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MedidaAdaptadaDisposicionFinalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescMedidaAdaptadaDisposicionFinal", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescMedidaAdaptadaDisposicionFinal"].Value = MedidaAdaptadaDisposicionFinalDTO.DescMedidaAdaptadaDisposicionFinal;

                    cmd.Parameters.Add("@CodigoMedidaAdaptadaDisposicionFinal", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMedidaAdaptadaDisposicionFinal"].Value = MedidaAdaptadaDisposicionFinalDTO.CodigoMedidaAdaptadaDisposicionFinal;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = MedidaAdaptadaDisposicionFinalDTO.UsuarioIngresoRegistro;

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

        public MedidaAdaptadaDisposicionFinalDTO BuscarMedidaAdaptadaDisposicionFinalID(int Codigo)
        {
            MedidaAdaptadaDisposicionFinalDTO MedidaAdaptadaDisposicionFinalDTO = new MedidaAdaptadaDisposicionFinalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MedidaAdaptadaDisposicionFinalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MedidaAdaptadaDisposicionFinalId", SqlDbType.Int);
                    cmd.Parameters["@MedidaAdaptadaDisposicionFinalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        MedidaAdaptadaDisposicionFinalDTO.MedidaAdaptadaDisposicionFinalId = Convert.ToInt32(dr["MedidaAdaptadaDisposicionFinalId"]);
                        MedidaAdaptadaDisposicionFinalDTO.DescMedidaAdaptadaDisposicionFinal = dr["DescMedidaAdaptadaDisposicionFinal"].ToString();
                        MedidaAdaptadaDisposicionFinalDTO.CodigoMedidaAdaptadaDisposicionFinal = dr["CodigoMedidaAdaptadaDisposicionFinal"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return MedidaAdaptadaDisposicionFinalDTO;
        }

        public string ActualizarMedidaAdaptadaDisposicionFinal(MedidaAdaptadaDisposicionFinalDTO MedidaAdaptadaDisposicionFinalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MedidaAdaptadaDisposicionFinalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MedidaAdaptadaDisposicionFinalId", SqlDbType.Int);
                    cmd.Parameters["@MedidaAdaptadaDisposicionFinalId"].Value = MedidaAdaptadaDisposicionFinalDTO.MedidaAdaptadaDisposicionFinalId;

                    cmd.Parameters.Add("@DescMedidaAdaptadaDisposicionFinal", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescMedidaAdaptadaDisposicionFinal"].Value = MedidaAdaptadaDisposicionFinalDTO.DescMedidaAdaptadaDisposicionFinal;

                    cmd.Parameters.Add("@CodigoMedidaAdaptadaDisposicionFinal", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMedidaAdaptadaDisposicionFinal"].Value = MedidaAdaptadaDisposicionFinalDTO.CodigoMedidaAdaptadaDisposicionFinal;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = MedidaAdaptadaDisposicionFinalDTO.UsuarioIngresoRegistro;

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

        public string EliminarMedidaAdaptadaDisposicionFinal(MedidaAdaptadaDisposicionFinalDTO MedidaAdaptadaDisposicionFinalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MedidaAdaptadaDisposicionFinalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MedidaAdaptadaDisposicionFinalId", SqlDbType.Int);
                    cmd.Parameters["@MedidaAdaptadaDisposicionFinalId"].Value = MedidaAdaptadaDisposicionFinalDTO.MedidaAdaptadaDisposicionFinalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = MedidaAdaptadaDisposicionFinalDTO.UsuarioIngresoRegistro;

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
