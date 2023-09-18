using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ClaseInversionDAO
    {

        SqlCommand cmd = new();

        public List<ClaseInversionDTO> ObtenerClaseInversions()
        {
            List<ClaseInversionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ClaseInversionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ClaseInversionDTO()
                        {
                            ClaseInversionId = Convert.ToInt32(dr["ClaseInversionId"]),
                            DescClaseInversion = dr["DescClaseInversion"].ToString(),
                            CodigoClaseInversion = dr["CodigoClaseInversion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarClaseInversion(ClaseInversionDTO ClaseInversionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClaseInversionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescClaseInversion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClaseInversion"].Value = ClaseInversionDTO.DescClaseInversion;

                    cmd.Parameters.Add("@CodigoClaseInversion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoClaseInversion"].Value = ClaseInversionDTO.CodigoClaseInversion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClaseInversionDTO.UsuarioIngresoRegistro;

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

        public ClaseInversionDTO BuscarClaseInversionID(int Codigo)
        {
            ClaseInversionDTO ClaseInversionDTO = new ClaseInversionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClaseInversionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClaseInversionId", SqlDbType.Int);
                    cmd.Parameters["@ClaseInversionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ClaseInversionDTO.ClaseInversionId = Convert.ToInt32(dr["ClaseInversionId"]);
                        ClaseInversionDTO.DescClaseInversion = dr["DescClaseInversion"].ToString();
                        ClaseInversionDTO.CodigoClaseInversion = dr["CodigoClaseInversion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ClaseInversionDTO;
        }

        public string ActualizarClaseInversion(ClaseInversionDTO ClaseInversionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClaseInversionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClaseInversionId", SqlDbType.Int);
                    cmd.Parameters["@ClaseInversionId"].Value = ClaseInversionDTO.ClaseInversionId;

                    cmd.Parameters.Add("@DescClaseInversion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClaseInversion"].Value = ClaseInversionDTO.DescClaseInversion;

                    cmd.Parameters.Add("@CodigoClaseInversion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoClaseInversion"].Value = ClaseInversionDTO.CodigoClaseInversion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClaseInversionDTO.UsuarioIngresoRegistro;

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

        public string EliminarClaseInversion(ClaseInversionDTO ClaseInversionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClaseInversionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClaseInversionId", SqlDbType.Int);
                    cmd.Parameters["@ClaseInversionId"].Value = ClaseInversionDTO.ClaseInversionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClaseInversionDTO.UsuarioIngresoRegistro;

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
