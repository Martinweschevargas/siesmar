using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CapacidadOperativaDAO
    {

        SqlCommand cmd = new();

        public List<CapacidadOperativaDTO> ObtenerCapacidadOperativas()
        {
            List<CapacidadOperativaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CapacidadOperativaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CapacidadOperativaDTO()
                        {
                            CapacidadOperativaId = Convert.ToInt32(dr["CapacidadOperativaId"]),
                            DescCapacidadOperativa = dr["DescCapacidadOperativa"].ToString(),
                            CodigoCapacidadOperativa = Convert.ToInt32(dr["CodigoCapacidadOperativa"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCapacidadOperativa(CapacidadOperativaDTO CapacidadOperativaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CapacidadOperativaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCapacidadOperativa", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCapacidadOperativa"].Value = CapacidadOperativaDTO.DescCapacidadOperativa;

                    cmd.Parameters.Add("@CodigoCapacidadOperativa", SqlDbType.Int);
                    cmd.Parameters["@CodigoCapacidadOperativa"].Value = CapacidadOperativaDTO.CodigoCapacidadOperativa;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CapacidadOperativaDTO.UsuarioIngresoRegistro;

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
                    IND_OPERACION = ex.Message + CapacidadOperativaDTO;
                }
            }
            return IND_OPERACION;
        }

        public CapacidadOperativaDTO BuscarCapacidadOperativaID(int Codigo)
        {
            CapacidadOperativaDTO CapacidadOperativaDTO = new CapacidadOperativaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CapacidadOperativaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        CapacidadOperativaDTO.CapacidadOperativaId = Convert.ToInt32(dr["CapacidadOperativaId"]);
                        CapacidadOperativaDTO.DescCapacidadOperativa = dr["DescCapacidadOperativa"].ToString();
                        CapacidadOperativaDTO.CodigoCapacidadOperativa = Convert.ToInt32(dr["CodigoCapacidadOperativa"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return CapacidadOperativaDTO;
        }

        public string ActualizarCapacidadOperativa(CapacidadOperativaDTO CapacidadOperativaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_CapacidadOperativaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = CapacidadOperativaDTO.CapacidadOperativaId;

                    cmd.Parameters.Add("@DescCapacidadOperativa", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCapacidadOperativa"].Value = CapacidadOperativaDTO.DescCapacidadOperativa;

                    cmd.Parameters.Add("@CodigoCapacidadOperativa", SqlDbType.Int);
                    cmd.Parameters["@CodigoCapacidadOperativa"].Value = CapacidadOperativaDTO.CodigoCapacidadOperativa;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CapacidadOperativaDTO.UsuarioIngresoRegistro;

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

        public string EliminarCapacidadOperativa(CapacidadOperativaDTO CapacidadOperativaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CapacidadOperativaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = CapacidadOperativaDTO.CapacidadOperativaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CapacidadOperativaDTO.UsuarioIngresoRegistro;

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
