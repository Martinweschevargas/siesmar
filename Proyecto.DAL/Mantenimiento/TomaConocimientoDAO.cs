using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TomaConocimientoDAO
    {

        SqlCommand cmd = new();

        public List<TomaConocimientoDTO> ObtenerTomaConocimientos()
        {
            List<TomaConocimientoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TomaConocimientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TomaConocimientoDTO()
                        {
                            TomaConocimientoId = Convert.ToInt32(dr["TomaConocimientoId"]),
                            DescTomaConocimiento = dr["DescTomaConocimiento"].ToString(),
                            CodigoTomaConocimiento = dr["CodigoTomaConocimiento"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTomaConocimiento(TomaConocimientoDTO tomaConocimientoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TomaConocimientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTomaConocimiento", SqlDbType.VarChar, 50);                    
                    cmd.Parameters["@DescTomaConocimiento"].Value = tomaConocimientoDTO.DescTomaConocimiento;

                    cmd.Parameters.Add("@CodigoTomaConocimiento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTomaConocimiento"].Value = tomaConocimientoDTO.CodigoTomaConocimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tomaConocimientoDTO.UsuarioIngresoRegistro;

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

        public TomaConocimientoDTO BuscarTomaConocimientoID(int Codigo)
        {
            TomaConocimientoDTO tomaConocimientoDTO = new TomaConocimientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TomaConocimientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TomaConocimientoId", SqlDbType.Int);
                    cmd.Parameters["@TomaConocimientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tomaConocimientoDTO.TomaConocimientoId = Convert.ToInt32(dr["TomaConocimientoId"]);
                        tomaConocimientoDTO.DescTomaConocimiento = dr["DescTomaConocimiento"].ToString();
                        tomaConocimientoDTO.CodigoTomaConocimiento = dr["CodigoTomaConocimiento"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tomaConocimientoDTO;
        }

        public string ActualizarTomaConocimiento(TomaConocimientoDTO tomaConocimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TomaConocimientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TomaConocimientoId", SqlDbType.Int);
                    cmd.Parameters["@TomaConocimientoId"].Value = tomaConocimientoDTO.TomaConocimientoId;

                    cmd.Parameters.Add("@DescTomaConocimiento", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTomaConocimiento"].Value = tomaConocimientoDTO.DescTomaConocimiento;

                    cmd.Parameters.Add("@CodigoTomaConocimiento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTomaConocimiento"].Value = tomaConocimientoDTO.CodigoTomaConocimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tomaConocimientoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTomaConocimiento(TomaConocimientoDTO tomaConocimientoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TomaConocimientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TomaConocimientoId", SqlDbType.Int);
                    cmd.Parameters["@TomaConocimientoId"].Value = tomaConocimientoDTO.TomaConocimientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tomaConocimientoDTO.UsuarioIngresoRegistro;

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
