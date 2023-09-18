using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class PuertoPeruDAO
    {

        SqlCommand cmd = new();

        public List<PuertoPeruDTO> ObtenerPuertoPerus()
        {
            List<PuertoPeruDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_PuertoPeruListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PuertoPeruDTO()
                        {
                            PuertoPeruId = Convert.ToInt32(dr["PuertoPeruId"]),
                            DescPuertoPeru = dr["DescPuertoPeru"].ToString(),
                            CodigoPuertoPeru = dr["CodigoPuertoPeru"].ToString(),
                            DescTipoPuertoPeru = dr["DescTipoPuertoPeru"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarPuertoPeru(PuertoPeruDTO PuertoPeruDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PuertoPeruRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescPuertoPeru", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescPuertoPeru"].Value = PuertoPeruDTO.DescPuertoPeru;

                    cmd.Parameters.Add("@CodigoPuertoPeru", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoPuertoPeru"].Value = PuertoPeruDTO.CodigoPuertoPeru;

                    cmd.Parameters.Add("@TipoPuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@TipoPuertoPeruId"].Value = PuertoPeruDTO.TipoPuertoPeruId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = PuertoPeruDTO.UsuarioIngresoRegistro;

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

        public PuertoPeruDTO BuscarPuertoPeruID(int Codigo)
        {
            PuertoPeruDTO PuertoPeruDTO = new PuertoPeruDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PuertoPeruEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@PuertoPeruId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        PuertoPeruDTO.PuertoPeruId = Convert.ToInt32(dr["PuertoPeruId"]);
                        PuertoPeruDTO.DescPuertoPeru = dr["DescPuertoPeru"].ToString();
                        PuertoPeruDTO.CodigoPuertoPeru = dr["CodigoPuertoPeru"].ToString();
                        PuertoPeruDTO.TipoPuertoPeruId = Convert.ToInt32(dr["TipoPuertoPeruId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return PuertoPeruDTO;
        }

        public string ActualizarPuertoPeru(PuertoPeruDTO PuertoPeruDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_PuertoPeruActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@PuertoPeruId"].Value = PuertoPeruDTO.PuertoPeruId;

                    cmd.Parameters.Add("@DescPuertoPeru", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescPuertoPeru"].Value = PuertoPeruDTO.DescPuertoPeru;

                    cmd.Parameters.Add("@CodigoPuertoPeru", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoPuertoPeru"].Value = PuertoPeruDTO.CodigoPuertoPeru;

                    cmd.Parameters.Add("@TipoPuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@TipoPuertoPeruId"].Value = PuertoPeruDTO.TipoPuertoPeruId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = PuertoPeruDTO.UsuarioIngresoRegistro;

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

        public string EliminarPuertoPeru(PuertoPeruDTO PuertoPeruDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PuertoPeruEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@PuertoPeruId"].Value = PuertoPeruDTO.PuertoPeruId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = PuertoPeruDTO.UsuarioIngresoRegistro;

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
