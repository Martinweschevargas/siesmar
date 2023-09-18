using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ClasificacionGenericaGastoDAO
    {

        SqlCommand cmd = new();

        public List<ClasificacionGenericaGastoDTO> ObtenerClasificacionGenericaGastos()
        {
            List<ClasificacionGenericaGastoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ClasificacionGenericaGastoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ClasificacionGenericaGastoDTO()
                        {
                            ClasificacionGenericaGastoId = Convert.ToInt32(dr["ClasificacionGenericaGastoId"]),
                            DescClasificacionGenericaGasto = dr["DescClasificacionGenericaGasto"].ToString(),
                            ClasificacionGenericaGasto = dr["ClasificacionGenericaGasto"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarClasificacionGenericaGasto(ClasificacionGenericaGastoDTO clasificacionGenericaGastoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionGenericaGastoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescClasificacionGenericaGasto", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClasificacionGenericaGasto"].Value = clasificacionGenericaGastoDTO.DescClasificacionGenericaGasto;

                    cmd.Parameters.Add("@ClasificacionGenericaGasto", SqlDbType.VarChar, 20);
                    cmd.Parameters["@ClasificacionGenericaGasto"].Value = clasificacionGenericaGastoDTO.ClasificacionGenericaGasto;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionGenericaGastoDTO.UsuarioIngresoRegistro;

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

        public ClasificacionGenericaGastoDTO BuscarClasificacionGenericaGastoID(int Codigo)
        {
            ClasificacionGenericaGastoDTO clasificacionGenericaGastoDTO = new ClasificacionGenericaGastoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionGenericaGastoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionGenericaGastoId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionGenericaGastoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        clasificacionGenericaGastoDTO.ClasificacionGenericaGastoId = Convert.ToInt32(dr["ClasificacionGenericaGastoId"]);
                        clasificacionGenericaGastoDTO.DescClasificacionGenericaGasto = dr["DescClasificacionGenericaGasto"].ToString();
                        clasificacionGenericaGastoDTO.ClasificacionGenericaGasto = dr["ClasificacionGenericaGasto"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return clasificacionGenericaGastoDTO;
        }

        public string ActualizarClasificacionGenericaGasto(ClasificacionGenericaGastoDTO clasificacionGenericaGastoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionGenericaGastoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionGenericaGastoId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionGenericaGastoId"].Value = clasificacionGenericaGastoDTO.ClasificacionGenericaGastoId;

                    cmd.Parameters.Add("@DescClasificacionGenericaGasto", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClasificacionGenericaGasto"].Value = clasificacionGenericaGastoDTO.DescClasificacionGenericaGasto;

                    cmd.Parameters.Add("@ClasificacionGenericaGasto", SqlDbType.VarChar, 20);
                    cmd.Parameters["@ClasificacionGenericaGasto"].Value = clasificacionGenericaGastoDTO.ClasificacionGenericaGasto;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionGenericaGastoDTO.UsuarioIngresoRegistro;

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

        public string EliminarClasificacionGenericaGasto(ClasificacionGenericaGastoDTO clasificacionGenericaGastoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionGenericaGastoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionGenericaGastoId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionGenericaGastoId"].Value = clasificacionGenericaGastoDTO.ClasificacionGenericaGastoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = clasificacionGenericaGastoDTO.UsuarioIngresoRegistro;

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
