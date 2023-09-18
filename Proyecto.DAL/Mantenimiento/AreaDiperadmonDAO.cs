using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AreaDiperadmonDAO
    {

        SqlCommand cmd = new();

        public List<AreaDiperadmonDTO> ObtenerAreaDiperadmons()
        {
            List<AreaDiperadmonDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AreaDiperadmonListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AreaDiperadmonDTO()
                        {
                            AreaDiperadmonId = Convert.ToInt32(dr["AreaDiperadmonId"]),
                            DescAreaDiperadmon = dr["DescAreaDiperadmon"].ToString(),
                            CodigoAreaDiperadmon = dr["CodigoAreaDiperadmon"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAreaDiperadmon(AreaDiperadmonDTO AreaDiperadmonDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreaDiperadmonRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescAreaDiperadmon", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescAreaDiperadmon"].Value = AreaDiperadmonDTO.DescAreaDiperadmon;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar, 10);                    
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = AreaDiperadmonDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AreaDiperadmonDTO.UsuarioIngresoRegistro;

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

        public AreaDiperadmonDTO BuscarAreaDiperadmonID(int Codigo)
        {
            AreaDiperadmonDTO AreaDiperadmonDTO = new AreaDiperadmonDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreaDiperadmonEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AreaDiperadmonId", SqlDbType.Int);
                    cmd.Parameters["@AreaDiperadmonId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        AreaDiperadmonDTO.AreaDiperadmonId = Convert.ToInt32(dr["AreaDiperadmonId"]);
                        AreaDiperadmonDTO.DescAreaDiperadmon = dr["DescAreaDiperadmon"].ToString();
                        AreaDiperadmonDTO.CodigoAreaDiperadmon = dr["CodigoAreaDiperadmon"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return AreaDiperadmonDTO;
        }

        public string ActualizarAreaDiperadmon(AreaDiperadmonDTO AreaDiperadmonDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreaDiperadmonActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AreaDiperadmonId", SqlDbType.Int);
                    cmd.Parameters["@AreaDiperadmonId"].Value = AreaDiperadmonDTO.AreaDiperadmonId;

                    cmd.Parameters.Add("@DescAreaDiperadmon", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescAreaDiperadmon"].Value = AreaDiperadmonDTO.DescAreaDiperadmon;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = AreaDiperadmonDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AreaDiperadmonDTO.UsuarioIngresoRegistro;

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

        public string EliminarAreaDiperadmon(AreaDiperadmonDTO AreaDiperadmonDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreaDiperadmonEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AreaDiperadmonId", SqlDbType.Int);
                    cmd.Parameters["@AreaDiperadmonId"].Value = AreaDiperadmonDTO.AreaDiperadmonId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AreaDiperadmonDTO.UsuarioIngresoRegistro;

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
