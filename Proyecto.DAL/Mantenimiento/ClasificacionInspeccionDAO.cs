using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ClasificacionInspeccionDAO
    {

        SqlCommand cmd = new();

        public List<ClasificacionInspeccionDTO> ObtenerClasificacionInspeccions()
        {
            List<ClasificacionInspeccionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ClasificacionInspeccionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ClasificacionInspeccionDTO()
                        {
                            ClasificacionInspeccionId = Convert.ToInt32(dr["ClasificacionInspeccionId"]),
                            DescClasificacionInspeccion = dr["DescClasificacionInspeccion"].ToString(),
                            CodigoClasificacionInspeccion = dr["CodigoClasificacionInspeccion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarClasificacionInspeccion(ClasificacionInspeccionDTO ClasificacionInspeccionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionInspeccionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescClasificacionInspeccion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClasificacionInspeccion"].Value = ClasificacionInspeccionDTO.DescClasificacionInspeccion;

                    cmd.Parameters.Add("@CodigoClasificacionInspeccion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoClasificacionInspeccion"].Value = ClasificacionInspeccionDTO.CodigoClasificacionInspeccion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClasificacionInspeccionDTO.UsuarioIngresoRegistro;

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

        public ClasificacionInspeccionDTO BuscarClasificacionInspeccionID(int Codigo)
        {
            ClasificacionInspeccionDTO ClasificacionInspeccionDTO = new ClasificacionInspeccionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionInspeccionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionInspeccionId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionInspeccionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ClasificacionInspeccionDTO.ClasificacionInspeccionId = Convert.ToInt32(dr["ClasificacionInspeccionId"]);
                        ClasificacionInspeccionDTO.DescClasificacionInspeccion = dr["DescClasificacionInspeccion"].ToString();
                        ClasificacionInspeccionDTO.CodigoClasificacionInspeccion = dr["CodigoClasificacionInspeccion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ClasificacionInspeccionDTO;
        }

        public string ActualizarClasificacionInspeccion(ClasificacionInspeccionDTO ClasificacionInspeccionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionInspeccionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionInspeccionId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionInspeccionId"].Value = ClasificacionInspeccionDTO.ClasificacionInspeccionId;

                    cmd.Parameters.Add("@DescClasificacionInspeccion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClasificacionInspeccion"].Value = ClasificacionInspeccionDTO.DescClasificacionInspeccion;

                    cmd.Parameters.Add("@CodigoClasificacionInspeccion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoClasificacionInspeccion"].Value = ClasificacionInspeccionDTO.CodigoClasificacionInspeccion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClasificacionInspeccionDTO.UsuarioIngresoRegistro;

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

        public string EliminarClasificacionInspeccion(ClasificacionInspeccionDTO ClasificacionInspeccionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionInspeccionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionInspeccionId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionInspeccionId"].Value = ClasificacionInspeccionDTO.ClasificacionInspeccionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClasificacionInspeccionDTO.UsuarioIngresoRegistro;

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
