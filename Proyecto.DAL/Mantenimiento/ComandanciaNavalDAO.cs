using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ComandanciaNavalDAO
    {

        SqlCommand cmd = new();

        public List<ComandanciaNavalDTO> ObtenerComandanciaNavals()
        {
            List<ComandanciaNavalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ComandanciaNavalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ComandanciaNavalDTO()
                        {
                            ComandanciaNavalId = Convert.ToInt32(dr["ComandanciaNavalId"]),
                            DescComandanciaNaval = dr["DescComandanciaNaval"].ToString(),
                            CodigoComandanciaNaval = dr["CodigoComandanciaNaval"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarComandanciaNaval(ComandanciaNavalDTO comandanciaNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ComandanciaNavalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescComandanciaNaval", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescComandanciaNaval"].Value = comandanciaNavalDTO.DescComandanciaNaval;

                    cmd.Parameters.Add("@CodigoComandanciaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComandanciaNaval"].Value = comandanciaNavalDTO.CodigoComandanciaNaval;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = comandanciaNavalDTO.UsuarioIngresoRegistro;

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

        public ComandanciaNavalDTO BuscarComandanciaNavalID(int Codigo)
        {
            ComandanciaNavalDTO comandanciaNavalDTO = new ComandanciaNavalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ComandanciaNavalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ComandanciaNavalId", SqlDbType.Int);
                    cmd.Parameters["@ComandanciaNavalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        comandanciaNavalDTO.ComandanciaNavalId = Convert.ToInt32(dr["ComandanciaNavalId"]);
                        comandanciaNavalDTO.DescComandanciaNaval = dr["DescComandanciaNaval"].ToString();
                        comandanciaNavalDTO.CodigoComandanciaNaval = dr["CodigoComandanciaNaval"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return comandanciaNavalDTO;
        }

        public string ActualizarComandanciaNaval(ComandanciaNavalDTO comandanciaNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ComandanciaNavalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ComandanciaNavalId", SqlDbType.Int);
                    cmd.Parameters["@ComandanciaNavalId"].Value = comandanciaNavalDTO.ComandanciaNavalId;

                    cmd.Parameters.Add("@DescComandanciaNaval", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescComandanciaNaval"].Value = comandanciaNavalDTO.DescComandanciaNaval;

                    cmd.Parameters.Add("@CodigoComandanciaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComandanciaNaval"].Value = comandanciaNavalDTO.CodigoComandanciaNaval;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = comandanciaNavalDTO.UsuarioIngresoRegistro;

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

        public string EliminarComandanciaNaval(ComandanciaNavalDTO comandanciaNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ComandanciaNavalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ComandanciaNavalId", SqlDbType.Int);
                    cmd.Parameters["@ComandanciaNavalId"].Value = comandanciaNavalDTO.ComandanciaNavalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = comandanciaNavalDTO.UsuarioIngresoRegistro;

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
