using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ClasificacionInspeccionConocimientoDAO
    {

        SqlCommand cmd = new();

        public List<ClasificacionInspeccionConocimientoDTO> ObtenerClasificacionInspeccionConocimientos()
        {
            List<ClasificacionInspeccionConocimientoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ClasificacionInspeccionConocimientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ClasificacionInspeccionConocimientoDTO()
                        {
                            ClasificacionInspeccionConocimientoId = Convert.ToInt32(dr["ClasificacionInspeccionConocimientoId"]),
                            DescClasificacionInspeccionConocimiento = dr["DescClasificacionInspeccionConocimiento"].ToString(),
                            CodigoClasificacionInspeccionConocimiento = dr["CodigoClasificacionInspeccionConocimiento"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarClasificacionInspeccionConocimiento(ClasificacionInspeccionConocimientoDTO clasificacionInspeccionConocimientoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionInspeccionConocimientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescClasificacionInspeccionConocimiento", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescClasificacionInspeccionConocimiento"].Value = clasificacionInspeccionConocimientoDTO.DescClasificacionInspeccionConocimiento;

                    cmd.Parameters.Add("@CodigoClasificacionInspeccionConocimiento", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoClasificacionInspeccionConocimiento"].Value = clasificacionInspeccionConocimientoDTO.CodigoClasificacionInspeccionConocimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionInspeccionConocimientoDTO.UsuarioIngresoRegistro;

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

        public ClasificacionInspeccionConocimientoDTO BuscarClasificacionInspeccionConocimientoID(int Codigo)
        {
            ClasificacionInspeccionConocimientoDTO clasificacionInspeccionConocimientoDTO = new ClasificacionInspeccionConocimientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionInspeccionConocimientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionInspeccionConocimientoId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionInspeccionConocimientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        clasificacionInspeccionConocimientoDTO.ClasificacionInspeccionConocimientoId = Convert.ToInt32(dr["ClasificacionInspeccionConocimientoId"]);
                        clasificacionInspeccionConocimientoDTO.DescClasificacionInspeccionConocimiento = dr["DescClasificacionInspeccionConocimiento"].ToString();
                        clasificacionInspeccionConocimientoDTO.CodigoClasificacionInspeccionConocimiento = dr["CodigoClasificacionInspeccionConocimiento"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return clasificacionInspeccionConocimientoDTO;
        }

        public string ActualizarClasificacionInspeccionConocimiento(ClasificacionInspeccionConocimientoDTO clasificacionInspeccionConocimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionInspeccionConocimientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionInspeccionConocimientoId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionInspeccionConocimientoId"].Value = clasificacionInspeccionConocimientoDTO.ClasificacionInspeccionConocimientoId;

                    cmd.Parameters.Add("@DescClasificacionInspeccionConocimiento", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClasificacionInspeccionConocimiento"].Value = clasificacionInspeccionConocimientoDTO.DescClasificacionInspeccionConocimiento;

                    cmd.Parameters.Add("@CodigoClasificacionInspeccionConocimiento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoClasificacionInspeccionConocimiento"].Value = clasificacionInspeccionConocimientoDTO.CodigoClasificacionInspeccionConocimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionInspeccionConocimientoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarClasificacionInspeccionConocimiento(ClasificacionInspeccionConocimientoDTO clasificacionInspeccionConocimientoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionInspeccionConocimientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionInspeccionConocimientoId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionInspeccionConocimientoId"].Value = clasificacionInspeccionConocimientoDTO.ClasificacionInspeccionConocimientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionInspeccionConocimientoDTO.UsuarioIngresoRegistro;

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
