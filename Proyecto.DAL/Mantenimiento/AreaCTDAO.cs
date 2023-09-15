using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AreaCTDAO
    {

        SqlCommand cmd = new();

        public List<AreaCTDTO> ObtenerAreaCTs()
        {
            List<AreaCTDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AreasCTListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AreaCTDTO()
                        {
                            AreaCTId = Convert.ToInt32(dr["AreaCTId"]),
                            DescAreaCT = dr["DescAreaCT"].ToString(),
                            CodigoAreaCT = dr["CodigoAreaCT"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAreaCT(AreaCTDTO areaCTDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreasCTRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescAreaCT", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescAreaCT"].Value = areaCTDTO.DescAreaCT;

                    cmd.Parameters.Add("@CodigoAreaCT", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoAreaCT"].Value = areaCTDTO.CodigoAreaCT;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = areaCTDTO.UsuarioIngresoRegistro;

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

        public AreaCTDTO BuscarAreaCTID(int Codigo)
        {
            AreaCTDTO areaCTDTO = new AreaCTDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreasCTEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AreaCTId", SqlDbType.Int);
                    cmd.Parameters["@AreaCTId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        areaCTDTO.AreaCTId = Convert.ToInt32(dr["AreaCTId"]);
                        areaCTDTO.DescAreaCT = dr["DescAreaCT"].ToString();
                        areaCTDTO.CodigoAreaCT = dr["CodigoAreaCT"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return areaCTDTO;
        }

        public string ActualizarAreaCT(AreaCTDTO areaCTDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_AreasCTActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AreaCTId", SqlDbType.Int);
                    cmd.Parameters["@AreaCTId"].Value = areaCTDTO.AreaCTId;

                    cmd.Parameters.Add("@DescAreaCT", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescAreaCT"].Value = areaCTDTO.DescAreaCT;

                    cmd.Parameters.Add("@CodigoAreaCT", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoAreaCT"].Value = areaCTDTO.CodigoAreaCT;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = areaCTDTO.UsuarioIngresoRegistro;

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

        public bool EliminarAreaCT(AreaCTDTO areaCTDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreasCTEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AreaCTId", SqlDbType.Int);
                    cmd.Parameters["@AreaCTId"].Value = areaCTDTO.AreaCTId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = areaCTDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    cmd.ExecuteNonQuery();
                    eliminado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return eliminado;
        }

    }
}
