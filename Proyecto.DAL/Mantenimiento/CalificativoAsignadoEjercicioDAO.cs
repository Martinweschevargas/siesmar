using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CalificativoAsignadoEjercicioDAO
    {

        SqlCommand cmd = new();

        public List<CalificativoAsignadoEjercicioDTO> ObtenerCalificativoAsignadoEjercicios()
        {
            List<CalificativoAsignadoEjercicioDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CalificativoAsignadoEjercicioListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CalificativoAsignadoEjercicioDTO()
                        {
                            CalificativoAsignadoEjercicioId = Convert.ToInt32(dr["CalificativoAsignadoEjercicioId"]),
                            Descripcion = dr["Descripcion"].ToString(),
                            CodigoCalificativoAsignadoEjercicio = dr["CodigoCalificativoAsignadoEjercicio"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCalificativoAsignadoEjercicio(CalificativoAsignadoEjercicioDTO calificativoAsignadoEjercicioDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CalificativoAsignadoEjercicioRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Descripcion"].Value = calificativoAsignadoEjercicioDTO.Descripcion;

                    cmd.Parameters.Add("@CodigoCalificativoAsignadoEjercicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCalificativoAsignadoEjercicio"].Value = calificativoAsignadoEjercicioDTO.CodigoCalificativoAsignadoEjercicio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = calificativoAsignadoEjercicioDTO.UsuarioIngresoRegistro;

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

        public CalificativoAsignadoEjercicioDTO BuscarCalificativoAsignadoEjercicioID(int Codigo)
        {
            CalificativoAsignadoEjercicioDTO calificativoAsignadoEjercicioDTO = new CalificativoAsignadoEjercicioDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CalificativoAsignadoEjercicioEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CalificativoAsignadoEjercicioId", SqlDbType.Int);
                    cmd.Parameters["@CalificativoAsignadoEjercicioId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        calificativoAsignadoEjercicioDTO.CalificativoAsignadoEjercicioId = Convert.ToInt32(dr["CalificativoAsignadoEjercicioId"]);
                        calificativoAsignadoEjercicioDTO.Descripcion = dr["Descripcion"].ToString();
                        calificativoAsignadoEjercicioDTO.CodigoCalificativoAsignadoEjercicio = dr["CodigoCalificativoAsignadoEjercicio"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return calificativoAsignadoEjercicioDTO;
        }

        public string ActualizarCalificativoAsignadoEjercicio(CalificativoAsignadoEjercicioDTO calificativoAsignadoEjercicioDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CalificativoAsignadoEjercicioActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CalificativoAsignadoEjercicioId", SqlDbType.Int);
                    cmd.Parameters["@CalificativoAsignadoEjercicioId"].Value = calificativoAsignadoEjercicioDTO.CalificativoAsignadoEjercicioId;

                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Descripcion"].Value = calificativoAsignadoEjercicioDTO.Descripcion;

                    cmd.Parameters.Add("@CodigoCalificativoAsignadoEjercicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCalificativoAsignadoEjercicio"].Value = calificativoAsignadoEjercicioDTO.CodigoCalificativoAsignadoEjercicio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = calificativoAsignadoEjercicioDTO.UsuarioIngresoRegistro;

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

        public string EliminarCalificativoAsignadoEjercicio(CalificativoAsignadoEjercicioDTO calificativoAsignadoEjercicioDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CalificativoAsignadoEjercicioEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CalificativoAsignadoEjercicioId", SqlDbType.Int);
                    cmd.Parameters["@CalificativoAsignadoEjercicioId"].Value = calificativoAsignadoEjercicioDTO.CalificativoAsignadoEjercicioId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = calificativoAsignadoEjercicioDTO.UsuarioIngresoRegistro;

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
