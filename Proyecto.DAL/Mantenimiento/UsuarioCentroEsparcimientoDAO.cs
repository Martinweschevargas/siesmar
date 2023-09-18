using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class UsuarioCentroEsparcimientoDAO
    {

        SqlCommand cmd = new();

        public List<UsuarioCentroEsparcimientoDTO> ObtenerUsuarioCentroEsparcimientos()
        {
            List<UsuarioCentroEsparcimientoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_UsuarioCentroEsparcimientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new UsuarioCentroEsparcimientoDTO()
                        {
                            UsuarioCentroEsparcimientoId = Convert.ToInt32(dr["UsuarioCentroEsparcimientoId"]),
                            DescUsuarioCentroEsparcimiento = dr["DescUsuarioCentroEsparcimiento"].ToString(),
                            CodigoUsuarioCentroEsparcimiento = dr["CodigoUsuarioCentroEsparcimiento"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarUsuarioCentroEsparcimiento(UsuarioCentroEsparcimientoDTO UsuarioCentroEsparcimientoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UsuarioCentroEsparcimientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescUsuarioCentroEsparcimiento", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescUsuarioCentroEsparcimiento"].Value = UsuarioCentroEsparcimientoDTO.DescUsuarioCentroEsparcimiento;

                    cmd.Parameters.Add("@CodigoUsuarioCentroEsparcimiento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoUsuarioCentroEsparcimiento"].Value = UsuarioCentroEsparcimientoDTO.CodigoUsuarioCentroEsparcimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = UsuarioCentroEsparcimientoDTO.UsuarioIngresoRegistro;

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

        public UsuarioCentroEsparcimientoDTO BuscarUsuarioCentroEsparcimientoID(int Codigo)
        {
            UsuarioCentroEsparcimientoDTO UsuarioCentroEsparcimientoDTO = new UsuarioCentroEsparcimientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UsuarioCentroEsparcimientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsuarioCentroEsparcimientoId", SqlDbType.Int);
                    cmd.Parameters["@UsuarioCentroEsparcimientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        UsuarioCentroEsparcimientoDTO.UsuarioCentroEsparcimientoId = Convert.ToInt32(dr["UsuarioCentroEsparcimientoId"]);
                        UsuarioCentroEsparcimientoDTO.DescUsuarioCentroEsparcimiento = dr["DescUsuarioCentroEsparcimiento"].ToString();
                        UsuarioCentroEsparcimientoDTO.CodigoUsuarioCentroEsparcimiento = dr["CodigoUsuarioCentroEsparcimiento"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return UsuarioCentroEsparcimientoDTO;
        }

        public string ActualizarUsuarioCentroEsparcimiento(UsuarioCentroEsparcimientoDTO UsuarioCentroEsparcimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UsuarioCentroEsparcimientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsuarioCentroEsparcimientoId", SqlDbType.Int);
                    cmd.Parameters["@UsuarioCentroEsparcimientoId"].Value = UsuarioCentroEsparcimientoDTO.UsuarioCentroEsparcimientoId;

                    cmd.Parameters.Add("@DescUsuarioCentroEsparcimiento", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescUsuarioCentroEsparcimiento"].Value = UsuarioCentroEsparcimientoDTO.DescUsuarioCentroEsparcimiento;

                    cmd.Parameters.Add("@CodigoUsuarioCentroEsparcimiento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoUsuarioCentroEsparcimiento"].Value = UsuarioCentroEsparcimientoDTO.CodigoUsuarioCentroEsparcimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = UsuarioCentroEsparcimientoDTO.UsuarioIngresoRegistro;

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

        public string EliminarUsuarioCentroEsparcimiento(UsuarioCentroEsparcimientoDTO UsuarioCentroEsparcimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UsuarioCentroEsparcimientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsuarioCentroEsparcimientoId", SqlDbType.Int);
                    cmd.Parameters["@UsuarioCentroEsparcimientoId"].Value = UsuarioCentroEsparcimientoDTO.UsuarioCentroEsparcimientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = UsuarioCentroEsparcimientoDTO.UsuarioIngresoRegistro;

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
