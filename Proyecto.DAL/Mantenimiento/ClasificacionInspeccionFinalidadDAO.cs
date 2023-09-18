using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ClasificacionInspeccionFinalidadDAO
    {

        SqlCommand cmd = new();

        public List<ClasificacionInspeccionFinalidadDTO> ObtenerClasificacionInspeccionFinalidads()
        {
            List<ClasificacionInspeccionFinalidadDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ClasificacionInspeccionFinalidadListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ClasificacionInspeccionFinalidadDTO()
                        {
                            ClasificacionInspeccionFinalidadId = Convert.ToInt32(dr["ClasificacionInspeccionFinalidadId"]),
                            DescClasificacionInspeccionFinalidad = dr["DescClasificacionInspeccionFinalidad"].ToString(),
                            CodigoClasificacionInspeccionFinalidad = dr["CodigoClasificacionInspeccionFinalidad"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarClasificacionInspeccionFinalidad(ClasificacionInspeccionFinalidadDTO clasificacionInspeccionFinalidadDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionInspeccionFinalidadRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescClasificacionInspeccionFinalidad", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescClasificacionInspeccionFinalidad"].Value = clasificacionInspeccionFinalidadDTO.DescClasificacionInspeccionFinalidad;

                    cmd.Parameters.Add("@CodigoClasificacionInspeccionFinalidad", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoClasificacionInspeccionFinalidad"].Value = clasificacionInspeccionFinalidadDTO.CodigoClasificacionInspeccionFinalidad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionInspeccionFinalidadDTO.UsuarioIngresoRegistro;

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

        public ClasificacionInspeccionFinalidadDTO BuscarClasificacionInspeccionFinalidadID(int Codigo)
        {
            ClasificacionInspeccionFinalidadDTO clasificacionInspeccionFinalidadDTO = new ClasificacionInspeccionFinalidadDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionInspeccionFinalidadEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionInspeccionFinalidadId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionInspeccionFinalidadId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        clasificacionInspeccionFinalidadDTO.ClasificacionInspeccionFinalidadId = Convert.ToInt32(dr["ClasificacionInspeccionFinalidadId"]);
                        clasificacionInspeccionFinalidadDTO.DescClasificacionInspeccionFinalidad = dr["DescClasificacionInspeccionFinalidad"].ToString();
                        clasificacionInspeccionFinalidadDTO.CodigoClasificacionInspeccionFinalidad = dr["CodigoClasificacionInspeccionFinalidad"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return clasificacionInspeccionFinalidadDTO;
        }

        public string ActualizarClasificacionInspeccionFinalidad(ClasificacionInspeccionFinalidadDTO clasificacionInspeccionFinalidadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionInspeccionFinalidadActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionInspeccionFinalidadId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionInspeccionFinalidadId"].Value = clasificacionInspeccionFinalidadDTO.ClasificacionInspeccionFinalidadId;

                    cmd.Parameters.Add("@DescClasificacionInspeccionFinalidad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClasificacionInspeccionFinalidad"].Value = clasificacionInspeccionFinalidadDTO.DescClasificacionInspeccionFinalidad;

                    cmd.Parameters.Add("@CodigoClasificacionInspeccionFinalidad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoClasificacionInspeccionFinalidad"].Value = clasificacionInspeccionFinalidadDTO.CodigoClasificacionInspeccionFinalidad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionInspeccionFinalidadDTO.UsuarioIngresoRegistro;

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

        public bool EliminarClasificacionInspeccionFinalidad(ClasificacionInspeccionFinalidadDTO clasificacionInspeccionFinalidadDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionInspeccionFinalidadEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionInspeccionFinalidadId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionInspeccionFinalidadId"].Value = clasificacionInspeccionFinalidadDTO.ClasificacionInspeccionFinalidadId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionInspeccionFinalidadDTO.UsuarioIngresoRegistro;

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
