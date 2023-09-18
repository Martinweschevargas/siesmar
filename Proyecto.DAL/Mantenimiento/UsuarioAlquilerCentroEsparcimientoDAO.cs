using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class UsuarioAlquilerCentroEsparcimientoDAO
    {

        SqlCommand cmd = new();

        public List<UsuarioAlquilerCentroEsparcimientoDTO> ObtenerUsuarioAlquilerCentroEsparcimientos()
        {
            List<UsuarioAlquilerCentroEsparcimientoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_UsuarioAlquilerCentroEsparcimientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new UsuarioAlquilerCentroEsparcimientoDTO()
                        {
                            UsuarioAlquilerCentroEsparcimientoId = Convert.ToInt32(dr["UsuarioAlquilerCentroEsparcimientoId"]),
                            DescUsuarioAlquilerCentroEsparcimiento = dr["DescUsuarioAlquilerCentroEsparcimiento"].ToString(),
                            CodigoUsuarioAlquilerCentroEsparcimiento = dr["CodigoUsuarioAlquilerCentroEsparcimiento"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarUsuarioAlquilerCentroEsparcimiento(UsuarioAlquilerCentroEsparcimientoDTO UsuarioAlquilerCentroEsparcimientoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UsuarioAlquilerCentroEsparcimientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.Add("@DescUsuarioAlquilerCentroEsparcimiento", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescUsuarioAlquilerCentroEsparcimiento"].Value = UsuarioAlquilerCentroEsparcimientoDTO.DescUsuarioAlquilerCentroEsparcimiento;

                    cmd.Parameters.Add("@CodigoUsuarioAlquilerCentroEsparcimiento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoUsuarioAlquilerCentroEsparcimiento"].Value = UsuarioAlquilerCentroEsparcimientoDTO.CodigoUsuarioAlquilerCentroEsparcimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = UsuarioAlquilerCentroEsparcimientoDTO.UsuarioIngresoRegistro;

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

        public UsuarioAlquilerCentroEsparcimientoDTO BuscarUsuarioAlquilerCentroEsparcimientoID(int Codigo)
        {
            UsuarioAlquilerCentroEsparcimientoDTO UsuarioAlquilerCentroEsparcimientoDTO = new UsuarioAlquilerCentroEsparcimientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UsuarioAlquilerCentroEsparcimientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsuarioAlquilerCentroEsparcimientoId", SqlDbType.Int);
                    cmd.Parameters["@UsuarioAlquilerCentroEsparcimientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        UsuarioAlquilerCentroEsparcimientoDTO.UsuarioAlquilerCentroEsparcimientoId = Convert.ToInt32(dr["UsuarioAlquilerCentroEsparcimientoId"]);
                        UsuarioAlquilerCentroEsparcimientoDTO.DescUsuarioAlquilerCentroEsparcimiento = dr["DescUsuarioAlquilerCentroEsparcimiento"].ToString();
                        UsuarioAlquilerCentroEsparcimientoDTO.CodigoUsuarioAlquilerCentroEsparcimiento = dr["CodigoUsuarioAlquilerCentroEsparcimiento"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return UsuarioAlquilerCentroEsparcimientoDTO;
        }

        public string ActualizarUsuarioAlquilerCentroEsparcimiento(UsuarioAlquilerCentroEsparcimientoDTO UsuarioAlquilerCentroEsparcimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UsuarioAlquilerCentroEsparcimientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsuarioAlquilerCentroEsparcimientoId", SqlDbType.Int);
                    cmd.Parameters["@UsuarioAlquilerCentroEsparcimientoId"].Value = UsuarioAlquilerCentroEsparcimientoDTO.UsuarioAlquilerCentroEsparcimientoId;

                    cmd.Parameters.Add("@DescUsuarioAlquilerCentroEsparcimiento", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescUsuarioAlquilerCentroEsparcimiento"].Value = UsuarioAlquilerCentroEsparcimientoDTO.DescUsuarioAlquilerCentroEsparcimiento;

                    cmd.Parameters.Add("@CodigoUsuarioAlquilerCentroEsparcimiento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoUsuarioAlquilerCentroEsparcimiento"].Value = UsuarioAlquilerCentroEsparcimientoDTO.CodigoUsuarioAlquilerCentroEsparcimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = UsuarioAlquilerCentroEsparcimientoDTO.UsuarioIngresoRegistro;

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

        public string EliminarUsuarioAlquilerCentroEsparcimiento(UsuarioAlquilerCentroEsparcimientoDTO UsuarioAlquilerCentroEsparcimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UsuarioAlquilerCentroEsparcimientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsuarioAlquilerCentroEsparcimientoId", SqlDbType.Int);
                    cmd.Parameters["@UsuarioAlquilerCentroEsparcimientoId"].Value = UsuarioAlquilerCentroEsparcimientoDTO.UsuarioAlquilerCentroEsparcimientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = UsuarioAlquilerCentroEsparcimientoDTO.UsuarioIngresoRegistro;

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
