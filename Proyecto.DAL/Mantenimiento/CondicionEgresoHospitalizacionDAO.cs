using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CondicionEgresoHospitalizacionDAO
    {

        SqlCommand cmd = new();

        public List<CondicionEgresoHospitalizacionDTO> ObtenerCondicionEgresoHospitalizacions()
        {
            List<CondicionEgresoHospitalizacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CondicionEgresoHospitalizacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CondicionEgresoHospitalizacionDTO()
                        {
                            CondicionEgresoHospitalizacionId = Convert.ToInt32(dr["CondicionEgresoHospitalizacionId"]),
                            DescCondicionEgresoHospitalizacion = dr["DescCondicionEgresoHospitalizacion"].ToString(),
                            CodigoCondicionEgresoHospitalizacion = dr["CodigoCondicionEgresoHospitalizacion"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCondicionEgresoHospitalizacion(CondicionEgresoHospitalizacionDTO condicionEgresoHospitalizacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionEgresoHospitalizacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCondicionEgresoHospitalizacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescCondicionEgresoHospitalizacion"].Value = condicionEgresoHospitalizacionDTO.DescCondicionEgresoHospitalizacion;

                    cmd.Parameters.Add("@CodigoCondicionEgresoHospitalizacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCondicionEgresoHospitalizacion"].Value = condicionEgresoHospitalizacionDTO.CodigoCondicionEgresoHospitalizacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = condicionEgresoHospitalizacionDTO.UsuarioIngresoRegistro;

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

        public CondicionEgresoHospitalizacionDTO BuscarCondicionEgresoHospitalizacionID(int Codigo)
        {
            CondicionEgresoHospitalizacionDTO condicionEgresoHospitalizacionDTO = new CondicionEgresoHospitalizacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionEgresoHospitalizacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionEgresoHospitalizacionId", SqlDbType.Int);
                    cmd.Parameters["@CondicionEgresoHospitalizacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        condicionEgresoHospitalizacionDTO.CondicionEgresoHospitalizacionId = Convert.ToInt32(dr["CondicionEgresoHospitalizacionId"]);
                        condicionEgresoHospitalizacionDTO.DescCondicionEgresoHospitalizacion = dr["DescCondicionEgresoHospitalizacion"].ToString();
                        condicionEgresoHospitalizacionDTO.CodigoCondicionEgresoHospitalizacion = dr["CodigoCondicionEgresoHospitalizacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return condicionEgresoHospitalizacionDTO;
        }

        public string ActualizarCondicionEgresoHospitalizacion(CondicionEgresoHospitalizacionDTO condicionEgresoHospitalizacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionEgresoHospitalizacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionEgresoHospitalizacionId", SqlDbType.Int);
                    cmd.Parameters["@CondicionEgresoHospitalizacionId"].Value = condicionEgresoHospitalizacionDTO.CondicionEgresoHospitalizacionId;

                    cmd.Parameters.Add("@DescCondicionEgresoHospitalizacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescCondicionEgresoHospitalizacion"].Value = condicionEgresoHospitalizacionDTO.DescCondicionEgresoHospitalizacion;

                    cmd.Parameters.Add("@CodigoCondicionEgresoHospitalizacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCondicionEgresoHospitalizacion"].Value = condicionEgresoHospitalizacionDTO.CodigoCondicionEgresoHospitalizacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = condicionEgresoHospitalizacionDTO.UsuarioIngresoRegistro;

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

        public string EliminarCondicionEgresoHospitalizacion(CondicionEgresoHospitalizacionDTO condicionEgresoHospitalizacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionEgresoHospitalizacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionEgresoHospitalizacionId", SqlDbType.Int);
                    cmd.Parameters["@CondicionEgresoHospitalizacionId"].Value = condicionEgresoHospitalizacionDTO.CondicionEgresoHospitalizacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = condicionEgresoHospitalizacionDTO.UsuarioIngresoRegistro;

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
