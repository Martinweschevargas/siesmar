using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AmbitoNaveDAO
    {

        SqlCommand cmd = new();

        public List<AmbitoNaveDTO> ObtenerAmbitoNaves()
        {
            List<AmbitoNaveDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AmbitoNaveListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AmbitoNaveDTO()
                        {
                            AmbitoNaveId = Convert.ToInt32(dr["AmbitoNaveId"]),
                            DescAmbitoNave = dr["DescAmbitoNave"].ToString(),
                            CodigoAmbitoNave = dr["CodigoAmbitoNave"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAmbitoNave(AmbitoNaveDTO AmbitoNaveDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AmbitoNaveRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescAmbitoNave", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescAmbitoNave"].Value = AmbitoNaveDTO.DescAmbitoNave;

                    cmd.Parameters.Add("@CodigoAmbitoNave", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoAmbitoNave"].Value = AmbitoNaveDTO.CodigoAmbitoNave;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AmbitoNaveDTO.UsuarioIngresoRegistro;

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

        public AmbitoNaveDTO BuscarAmbitoNaveID(int Codigo)
        {
            AmbitoNaveDTO AmbitoNaveDTO = new AmbitoNaveDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AmbitoNaveEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AmbitoNaveId", SqlDbType.Int);
                    cmd.Parameters["@AmbitoNaveId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        AmbitoNaveDTO.AmbitoNaveId = Convert.ToInt32(dr["AmbitoNaveId"]);
                        AmbitoNaveDTO.DescAmbitoNave = dr["DescAmbitoNave"].ToString();
                        AmbitoNaveDTO.CodigoAmbitoNave = dr["CodigoAmbitoNave"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return AmbitoNaveDTO;
        }

        public string ActualizarAmbitoNave(AmbitoNaveDTO AmbitoNaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AmbitoNaveActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AmbitoNaveId", SqlDbType.Int);
                    cmd.Parameters["@AmbitoNaveId"].Value = AmbitoNaveDTO.AmbitoNaveId;

                    cmd.Parameters.Add("@DescAmbitoNave", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescAmbitoNave"].Value = AmbitoNaveDTO.DescAmbitoNave;

                    cmd.Parameters.Add("@CodigoAmbitoNave", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoAmbitoNave"].Value = AmbitoNaveDTO.CodigoAmbitoNave;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AmbitoNaveDTO.UsuarioIngresoRegistro;

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

        public string EliminarAmbitoNave(AmbitoNaveDTO AmbitoNaveDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AmbitoNaveEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AmbitoNaveId", SqlDbType.Int);
                    cmd.Parameters["@AmbitoNaveId"].Value = AmbitoNaveDTO.AmbitoNaveId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AmbitoNaveDTO.UsuarioIngresoRegistro;

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
