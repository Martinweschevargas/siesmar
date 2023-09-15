using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ClasificacionInspeccionExtensionDAO
    {

        SqlCommand cmd = new();

        public List<ClasificacionInspeccionExtensionDTO> ObtenerClasificacionInspeccionExtensions()
        {
            List<ClasificacionInspeccionExtensionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ClasificacionInspeccionExtensionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ClasificacionInspeccionExtensionDTO()
                        {
                            ClasificacionInspeccionExtensionId = Convert.ToInt32(dr["ClasificacionInspeccionExtensionId"]),
                            DescClasificacionInspeccionExtension = dr["DescClasificacionInspeccionExtension"].ToString(),
                            CodigoClasificacionInspeccionExtension = dr["CodigoClasificacionInspeccionExtension"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarClasificacionInspeccionExtension(ClasificacionInspeccionExtensionDTO clasificacionInspeccionExtensionDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionInspeccionExtensionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescClasificacionInspeccionExtension", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescClasificacionInspeccionExtension"].Value = clasificacionInspeccionExtensionDTO.DescClasificacionInspeccionExtension;

                    cmd.Parameters.Add("@CodigoClasificacionInspeccionExtension", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoClasificacionInspeccionExtension"].Value = clasificacionInspeccionExtensionDTO.CodigoClasificacionInspeccionExtension;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionInspeccionExtensionDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                        }
                    }
                }
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public ClasificacionInspeccionExtensionDTO BuscarClasificacionInspeccionExtensionID(int Codigo)
        {
            ClasificacionInspeccionExtensionDTO clasificacionInspeccionExtensionDTO = new ClasificacionInspeccionExtensionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionInspeccionExtensionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionInspeccionExtensionId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionInspeccionExtensionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        clasificacionInspeccionExtensionDTO.ClasificacionInspeccionExtensionId = Convert.ToInt32(dr["ClasificacionInspeccionExtensionId"]);
                        clasificacionInspeccionExtensionDTO.DescClasificacionInspeccionExtension = dr["DescClasificacionInspeccionExtension"].ToString();
                        clasificacionInspeccionExtensionDTO.CodigoClasificacionInspeccionExtension = dr["CodigoClasificacionInspeccionExtension"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return clasificacionInspeccionExtensionDTO;
        }

        public string ActualizarClasificacionInspeccionExtension(ClasificacionInspeccionExtensionDTO clasificacionInspeccionExtensionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionInspeccionExtensionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionInspeccionExtensionId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionInspeccionExtensionId"].Value = clasificacionInspeccionExtensionDTO.ClasificacionInspeccionExtensionId;

                    cmd.Parameters.Add("@DescClasificacionInspeccionExtension", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClasificacionInspeccionExtension"].Value = clasificacionInspeccionExtensionDTO.DescClasificacionInspeccionExtension;

                    cmd.Parameters.Add("@CodigoClasificacionInspeccionExtension", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoClasificacionInspeccionExtension"].Value = clasificacionInspeccionExtensionDTO.CodigoClasificacionInspeccionExtension;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionInspeccionExtensionDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public bool EliminarClasificacionInspeccionExtension(ClasificacionInspeccionExtensionDTO clasificacionInspeccionExtensionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionInspeccionExtensionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionInspeccionExtensionId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionInspeccionExtensionId"].Value = clasificacionInspeccionExtensionDTO.ClasificacionInspeccionExtensionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionInspeccionExtensionDTO.UsuarioIngresoRegistro;

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
