using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ClasificacionSeguridadDAO
    {

        SqlCommand cmd = new();

        public List<ClasificacionSeguridadDTO> ObtenerClasificacionSeguridads()
        {
            List<ClasificacionSeguridadDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ClasificacionSeguridadListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ClasificacionSeguridadDTO()
                        {
                            ClasificacionSeguridadId = Convert.ToInt32(dr["ClasificacionSeguridadId"]),
                            DescClasificacionSeguridad = dr["DescClasificacionSeguridad"].ToString(),
                            CodigoClasificacionSeguridad = dr["CodigoClasificacionSeguridad"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarClasificacionSeguridad(ClasificacionSeguridadDTO ClasificacionSeguridadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionSeguridadRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescClasificacionSeguridad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClasificacionSeguridad"].Value = ClasificacionSeguridadDTO.DescClasificacionSeguridad;

                    cmd.Parameters.Add("@CodigoClasificacionSeguridad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoClasificacionSeguridad"].Value = ClasificacionSeguridadDTO.CodigoClasificacionSeguridad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClasificacionSeguridadDTO.UsuarioIngresoRegistro;

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

        public ClasificacionSeguridadDTO BuscarClasificacionSeguridadID(int Codigo)
        {
            ClasificacionSeguridadDTO ClasificacionSeguridadDTO = new ClasificacionSeguridadDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionSeguridadEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionSeguridadId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionSeguridadId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ClasificacionSeguridadDTO.ClasificacionSeguridadId = Convert.ToInt32(dr["ClasificacionSeguridadId"]);
                        ClasificacionSeguridadDTO.DescClasificacionSeguridad = dr["DescClasificacionSeguridad"].ToString();
                        ClasificacionSeguridadDTO.CodigoClasificacionSeguridad = dr["CodigoClasificacionSeguridad"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ClasificacionSeguridadDTO;
        }

        public string ActualizarClasificacionSeguridad(ClasificacionSeguridadDTO ClasificacionSeguridadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionSeguridadActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionSeguridadId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionSeguridadId"].Value = ClasificacionSeguridadDTO.ClasificacionSeguridadId;

                    cmd.Parameters.Add("@DescClasificacionSeguridad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClasificacionSeguridad"].Value = ClasificacionSeguridadDTO.DescClasificacionSeguridad;

                    cmd.Parameters.Add("@CodigoClasificacionSeguridad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoClasificacionSeguridad"].Value = ClasificacionSeguridadDTO.CodigoClasificacionSeguridad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClasificacionSeguridadDTO.UsuarioIngresoRegistro;

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

        public string EliminarClasificacionSeguridad(ClasificacionSeguridadDTO ClasificacionSeguridadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionSeguridadEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionSeguridadId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionSeguridadId"].Value = ClasificacionSeguridadDTO.ClasificacionSeguridadId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClasificacionSeguridadDTO.UsuarioIngresoRegistro;

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
