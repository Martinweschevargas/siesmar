using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class FinalidadPrestamoDAO
    {

        SqlCommand cmd = new();

        public List<FinalidadPrestamoDTO> ObtenerFinalidadPrestamos()
        {
            List<FinalidadPrestamoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_FinalidadPrestamoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new FinalidadPrestamoDTO()
                        {
                            FinalidadPrestamoId = Convert.ToInt32(dr["FinalidadPrestamoId"]),
                            DescFinalidadPrestamo = dr["DescFinalidadPrestamo"].ToString(),
                            CodigoFinalidadPrestamo = dr["CodigoFinalidadPrestamo"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarFinalidadPrestamo(FinalidadPrestamoDTO finalidadPrestamoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FinalidadPrestamoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescFinalidadPrestamo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescFinalidadPrestamo"].Value = finalidadPrestamoDTO.DescFinalidadPrestamo;

                    cmd.Parameters.Add("@CodigoFinalidadPrestamo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFinalidadPrestamo"].Value = finalidadPrestamoDTO.CodigoFinalidadPrestamo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = finalidadPrestamoDTO.UsuarioIngresoRegistro;

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

        public FinalidadPrestamoDTO BuscarFinalidadPrestamoID(int Codigo)
        {
            FinalidadPrestamoDTO finalidadPrestamoDTO = new FinalidadPrestamoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FinalidadPrestamoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FinalidadPrestamoId", SqlDbType.Int);
                    cmd.Parameters["@FinalidadPrestamoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        finalidadPrestamoDTO.FinalidadPrestamoId = Convert.ToInt32(dr["FinalidadPrestamoId"]);
                        finalidadPrestamoDTO.DescFinalidadPrestamo = dr["DescFinalidadPrestamo"].ToString();
                        finalidadPrestamoDTO.CodigoFinalidadPrestamo = dr["CodigoFinalidadPrestamo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return finalidadPrestamoDTO;
        }

        public string ActualizarFinalidadPrestamo(FinalidadPrestamoDTO finalidadPrestamoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FinalidadPrestamoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FinalidadPrestamoId", SqlDbType.Int);
                    cmd.Parameters["@FinalidadPrestamoId"].Value = finalidadPrestamoDTO.FinalidadPrestamoId;

                    cmd.Parameters.Add("@DescFinalidadPrestamo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescFinalidadPrestamo"].Value = finalidadPrestamoDTO.DescFinalidadPrestamo;

                    cmd.Parameters.Add("@CodigoFinalidadPrestamo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFinalidadPrestamo"].Value = finalidadPrestamoDTO.CodigoFinalidadPrestamo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = finalidadPrestamoDTO.UsuarioIngresoRegistro;

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

        public string EliminarFinalidadPrestamo(FinalidadPrestamoDTO finalidadPrestamoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FinalidadPrestamoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FinalidadPrestamoId", SqlDbType.Int);
                    cmd.Parameters["@FinalidadPrestamoId"].Value = finalidadPrestamoDTO.FinalidadPrestamoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = finalidadPrestamoDTO.UsuarioIngresoRegistro;

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
