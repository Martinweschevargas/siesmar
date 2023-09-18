using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ClaseVisitaDAO
    {

        SqlCommand cmd = new();

        public List<ClaseVisitaDTO> ObtenerClaseVisitas()
        {
            List<ClaseVisitaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ClaseVisitaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ClaseVisitaDTO()
                        {
                            ClaseVisitaId = Convert.ToInt32(dr["ClaseVisitaId"]),
                            DescClaseVisita = dr["DescClaseVisita"].ToString(),
                            CodigoClaseVisita = dr["CodigoClaseVisita"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarClaseVisita(ClaseVisitaDTO ClaseVisitaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClaseVisitaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescClaseVisita", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClaseVisita"].Value = ClaseVisitaDTO.DescClaseVisita;

                    cmd.Parameters.Add("@CodigoClaseVisita", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoClaseVisita"].Value = ClaseVisitaDTO.CodigoClaseVisita;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClaseVisitaDTO.UsuarioIngresoRegistro;

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

        public ClaseVisitaDTO BuscarClaseVisitaID(int Codigo)
        {
            ClaseVisitaDTO ClaseVisitaDTO = new ClaseVisitaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClaseVisitaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClaseVisitaId", SqlDbType.Int);
                    cmd.Parameters["@ClaseVisitaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ClaseVisitaDTO.ClaseVisitaId = Convert.ToInt32(dr["ClaseVisitaId"]);
                        ClaseVisitaDTO.DescClaseVisita = dr["DescClaseVisita"].ToString();
                        ClaseVisitaDTO.CodigoClaseVisita = dr["CodigoClaseVisita"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ClaseVisitaDTO;
        }

        public string ActualizarClaseVisita(ClaseVisitaDTO ClaseVisitaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClaseVisitaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClaseVisitaId", SqlDbType.Int);
                    cmd.Parameters["@ClaseVisitaId"].Value = ClaseVisitaDTO.ClaseVisitaId;

                    cmd.Parameters.Add("@DescClaseVisita", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClaseVisita"].Value = ClaseVisitaDTO.DescClaseVisita;

                    cmd.Parameters.Add("@CodigoClaseVisita", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoClaseVisita"].Value = ClaseVisitaDTO.CodigoClaseVisita;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClaseVisitaDTO.UsuarioIngresoRegistro;

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

        public string EliminarClaseVisita(ClaseVisitaDTO ClaseVisitaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClaseVisitaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClaseVisitaId", SqlDbType.Int);
                    cmd.Parameters["@ClaseVisitaId"].Value = ClaseVisitaDTO.ClaseVisitaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClaseVisitaDTO.UsuarioIngresoRegistro;

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
