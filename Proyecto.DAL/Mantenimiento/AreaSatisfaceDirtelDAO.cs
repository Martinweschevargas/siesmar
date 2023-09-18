using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AreaSatisfaceDirtelDAO
    {

        SqlCommand cmd = new();

        public List<AreaSatisfaceDirtelDTO> ObtenerAreaSatisfaceDirtels()
        {
            List<AreaSatisfaceDirtelDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AreaSatisfaceDirtelListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AreaSatisfaceDirtelDTO()
                        {
                            AreaSatisfaceDirtelId = Convert.ToInt32(dr["AreaSatisfaceDirtelId"]),
                            DescAreaSatisfaceDirtel = dr["DescAreaSatisfaceDirtel"].ToString(),
                            CodigoAreaSatisfaceDirtel = dr["CodigoAreaSatisfaceDirtel"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAreaSatisfaceDirtel(AreaSatisfaceDirtelDTO areaSatisfaceDirtelDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreaSatisfaceDirtelRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescAreaSatisfaceDirtel", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescAreaSatisfaceDirtel"].Value = areaSatisfaceDirtelDTO.DescAreaSatisfaceDirtel;

                    cmd.Parameters.Add("@CodigoAreaSatisfaceDirtel", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoAreaSatisfaceDirtel"].Value = areaSatisfaceDirtelDTO.CodigoAreaSatisfaceDirtel;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = areaSatisfaceDirtelDTO.UsuarioIngresoRegistro;

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

        public AreaSatisfaceDirtelDTO BuscarAreaSatisfaceDirtelID(int Codigo)
        {
            AreaSatisfaceDirtelDTO areaSatisfaceDirtelDTO = new AreaSatisfaceDirtelDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreaSatisfaceDirtelEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AreaSatisfaceDirtelId", SqlDbType.Int);
                    cmd.Parameters["@AreaSatisfaceDirtelId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        areaSatisfaceDirtelDTO.AreaSatisfaceDirtelId = Convert.ToInt32(dr["AreaSatisfaceDirtelId"]);
                        areaSatisfaceDirtelDTO.DescAreaSatisfaceDirtel = dr["DescAreaSatisfaceDirtel"].ToString();
                        areaSatisfaceDirtelDTO.CodigoAreaSatisfaceDirtel = dr["CodigoAreaSatisfaceDirtel"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return areaSatisfaceDirtelDTO;
        }

        public string ActualizarAreaSatisfaceDirtel(AreaSatisfaceDirtelDTO areaSatisfaceDirtelDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreaSatisfaceDirtelActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AreaSatisfaceDirtelId", SqlDbType.Int);
                    cmd.Parameters["@AreaSatisfaceDirtelId"].Value = areaSatisfaceDirtelDTO.AreaSatisfaceDirtelId;

                    cmd.Parameters.Add("@DescAreaSatisfaceDirtel", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescAreaSatisfaceDirtel"].Value = areaSatisfaceDirtelDTO.DescAreaSatisfaceDirtel;

                    cmd.Parameters.Add("@CodigoAreaSatisfaceDirtel", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoAreaSatisfaceDirtel"].Value = areaSatisfaceDirtelDTO.CodigoAreaSatisfaceDirtel;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = areaSatisfaceDirtelDTO.UsuarioIngresoRegistro;

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

        public string EliminarAreaSatisfaceDirtel(AreaSatisfaceDirtelDTO areaSatisfaceDirtelDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreaSatisfaceDirtelEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AreaSatisfaceDirtelId", SqlDbType.Int);
                    cmd.Parameters["@AreaSatisfaceDirtelId"].Value = areaSatisfaceDirtelDTO.AreaSatisfaceDirtelId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = areaSatisfaceDirtelDTO.UsuarioIngresoRegistro;

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
