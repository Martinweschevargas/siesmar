using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ClasificacionEspecialidadDAO
    {

        SqlCommand cmd = new();

        public List<ClasificacionEspecialidadDTO> ObtenerClasificacionEspecialidads()
        {
            List<ClasificacionEspecialidadDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ClasificacionEspecialidadListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ClasificacionEspecialidadDTO()
                        {
                            ClasificacionEspecialidadId = Convert.ToInt32(dr["ClasificacionEspecialidadId"]),
                            DescClasificacionEspecialidad = dr["DescClasificacionEspecialidad"].ToString(),
                            AbrevClasificacionEspecialidad = dr["AbrevClasificacionEspecialidad"].ToString(),
                            CodigoClasificacionEspecialidad = dr["CodigoClasificacionEspecialidad"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarClasificacionEspecialidad(ClasificacionEspecialidadDTO clasificacionEspecialidadDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionEspecialidadRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescClasificacionEspecialidad", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescClasificacionEspecialidad"].Value = clasificacionEspecialidadDTO.DescClasificacionEspecialidad;

                    cmd.Parameters.Add("@AbrevClasificacionEspecialidad", SqlDbType.VarChar, 80);
                    cmd.Parameters["@AbrevClasificacionEspecialidad"].Value = clasificacionEspecialidadDTO.AbrevClasificacionEspecialidad;

                    cmd.Parameters.Add("@CodigoClasificacionEspecialidad", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoClasificacionEspecialidad"].Value = clasificacionEspecialidadDTO.CodigoClasificacionEspecialidad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionEspecialidadDTO.UsuarioIngresoRegistro;

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

        public ClasificacionEspecialidadDTO BuscarClasificacionEspecialidadID(int Codigo)
        {
            ClasificacionEspecialidadDTO clasificacionEspecialidadDTO = new ClasificacionEspecialidadDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionEspecialidadEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionEspecialidadId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionEspecialidadId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        clasificacionEspecialidadDTO.ClasificacionEspecialidadId = Convert.ToInt32(dr["ClasificacionEspecialidadId"]);
                        clasificacionEspecialidadDTO.DescClasificacionEspecialidad = dr["DescClasificacionEspecialidad"].ToString();
                        clasificacionEspecialidadDTO.AbrevClasificacionEspecialidad = dr["AbrevClasificacionEspecialidad"].ToString();
                        clasificacionEspecialidadDTO.CodigoClasificacionEspecialidad = dr["CodigoClasificacionEspecialidad"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return clasificacionEspecialidadDTO;
        }

        public string ActualizarClasificacionEspecialidad(ClasificacionEspecialidadDTO clasificacionEspecialidadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionEspecialidadActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionEspecialidadId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionEspecialidadId"].Value = clasificacionEspecialidadDTO.ClasificacionEspecialidadId;

                    cmd.Parameters.Add("@DescClasificacionEspecialidad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClasificacionEspecialidad"].Value = clasificacionEspecialidadDTO.DescClasificacionEspecialidad;

                    cmd.Parameters.Add("@AbrevClasificacionEspecialidad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@AbrevClasificacionEspecialidad"].Value = clasificacionEspecialidadDTO.AbrevClasificacionEspecialidad;

                    cmd.Parameters.Add("@CodigoClasificacionEspecialidad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoClasificacionEspecialidad"].Value = clasificacionEspecialidadDTO.CodigoClasificacionEspecialidad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionEspecialidadDTO.UsuarioIngresoRegistro;

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

        public bool EliminarClasificacionEspecialidad(ClasificacionEspecialidadDTO clasificacionEspecialidadDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionEspecialidadEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionEspecialidadId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionEspecialidadId"].Value = clasificacionEspecialidadDTO.ClasificacionEspecialidadId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionEspecialidadDTO.UsuarioIngresoRegistro;

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
