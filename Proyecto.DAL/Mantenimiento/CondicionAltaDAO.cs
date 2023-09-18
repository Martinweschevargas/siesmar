using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CondicionAltaDAO
    {

        SqlCommand cmd = new();

        public List<CondicionAltaDTO> ObtenerCondicionAltas()
        {
            List<CondicionAltaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CondicionAltaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CondicionAltaDTO()
                        {
                            CondicionAltaId = Convert.ToInt32(dr["CondicionAltaId"]),
                            DescCondicionAlta = dr["DescCondicionAlta"].ToString(),
                            CodigoCondicionAlta = dr["CodigoCondicionAlta"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCondicionAlta(CondicionAltaDTO condicionAltaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionAltaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCondicionAlta", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescCondicionAlta"].Value = condicionAltaDTO.DescCondicionAlta;

                    cmd.Parameters.Add("@CodigoCondicionAlta", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCondicionAlta"].Value = condicionAltaDTO.CodigoCondicionAlta;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = condicionAltaDTO.UsuarioIngresoRegistro;

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

        public CondicionAltaDTO BuscarCondicionAltaID(int Codigo)
        {
            CondicionAltaDTO condicionAltaDTO = new CondicionAltaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionAltaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionAltaId", SqlDbType.Int);
                    cmd.Parameters["@CondicionAltaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        condicionAltaDTO.CondicionAltaId = Convert.ToInt32(dr["CondicionAltaId"]);
                        condicionAltaDTO.DescCondicionAlta = dr["DescCondicionAlta"].ToString();
                        condicionAltaDTO.CodigoCondicionAlta = dr["CodigoCondicionAlta"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return condicionAltaDTO;
        }

        public string ActualizarCondicionAlta(CondicionAltaDTO condicionAltaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionAltaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionAltaId", SqlDbType.Int);
                    cmd.Parameters["@CondicionAltaId"].Value = condicionAltaDTO.CondicionAltaId;

                    cmd.Parameters.Add("@DescCondicionAlta", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescCondicionAlta"].Value = condicionAltaDTO.DescCondicionAlta;

                    cmd.Parameters.Add("@CodigoCondicionAlta", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCondicionAlta"].Value = condicionAltaDTO.CodigoCondicionAlta;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = condicionAltaDTO.UsuarioIngresoRegistro;

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

        public string EliminarCondicionAlta(CondicionAltaDTO condicionAltaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionAltaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionAltaId", SqlDbType.Int);
                    cmd.Parameters["@CondicionAltaId"].Value = condicionAltaDTO.CondicionAltaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = condicionAltaDTO.UsuarioIngresoRegistro;

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
