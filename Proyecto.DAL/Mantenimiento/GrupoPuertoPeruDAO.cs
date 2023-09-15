using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class GrupoPuertoPeruDAO
    {

        SqlCommand cmd = new();

        public List<GrupoPuertoPeruDTO> ObtenerGrupoPuertoPerus()
        {
            List<GrupoPuertoPeruDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_GrupoPuertosPeruListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new GrupoPuertoPeruDTO()
                        {
                            GrupoPuertoPeruId = Convert.ToInt32(dr["GrupoPuertoPeruId"]),
                            DescGrupoPuertoPeru = dr["DescGrupoPuertoPeru"].ToString(),
                            CodigoGrupoPuertoPeru = dr["CodigoGrupoPuertoPeru"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarGrupoPuertoPeru(GrupoPuertoPeruDTO GrupoPuertoPeruDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoPuertosPeruRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescGrupoPuertoPeru", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescGrupoPuertoPeru"].Value = GrupoPuertoPeruDTO.DescGrupoPuertoPeru;

                    cmd.Parameters.Add("@CodigoGrupoPuertoPeru", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoGrupoPuertoPeru"].Value = GrupoPuertoPeruDTO.CodigoGrupoPuertoPeru;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = GrupoPuertoPeruDTO.UsuarioIngresoRegistro;

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

        public GrupoPuertoPeruDTO BuscarGrupoPuertoPeruID(int Codigo)
        {
            GrupoPuertoPeruDTO GrupoPuertoPeruDTO = new GrupoPuertoPeruDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoPuertosPeruEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoPuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@GrupoPuertoPeruId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        GrupoPuertoPeruDTO.GrupoPuertoPeruId = Convert.ToInt32(dr["GrupoPuertoPeruId"]);
                        GrupoPuertoPeruDTO.DescGrupoPuertoPeru = dr["DescGrupoPuertoPeru"].ToString();
                        GrupoPuertoPeruDTO.CodigoGrupoPuertoPeru = dr["CodigoGrupoPuertoPeru"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return GrupoPuertoPeruDTO;
        }

        public string ActualizarGrupoPuertoPeru(GrupoPuertoPeruDTO GrupoPuertoPeruDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoPuertosPeruActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoPuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@GrupoPuertoPeruId"].Value = GrupoPuertoPeruDTO.GrupoPuertoPeruId;

                    cmd.Parameters.Add("@DescGrupoPuertoPeru", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescGrupoPuertoPeru"].Value = GrupoPuertoPeruDTO.DescGrupoPuertoPeru;

                    cmd.Parameters.Add("@CodigoGrupoPuertoPeru", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoGrupoPuertoPeru"].Value = GrupoPuertoPeruDTO.CodigoGrupoPuertoPeru;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = GrupoPuertoPeruDTO.UsuarioIngresoRegistro;

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

        public string EliminarGrupoPuertoPeru(GrupoPuertoPeruDTO GrupoPuertoPeruDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoPuertosPeruEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoPuertoPeruId", SqlDbType.Int);
                    cmd.Parameters["@GrupoPuertoPeruId"].Value = GrupoPuertoPeruDTO.GrupoPuertoPeruId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = GrupoPuertoPeruDTO.UsuarioIngresoRegistro;

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
