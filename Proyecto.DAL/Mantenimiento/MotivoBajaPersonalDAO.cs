using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class MotivoBajaPersonalDAO
    {

        SqlCommand cmd = new();

        public List<MotivoBajaPersonalDTO> ObtenerMotivoBajaPersonals()
        {
            List<MotivoBajaPersonalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_MotivoBajaPersonalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MotivoBajaPersonalDTO()
                        {
                            MotivoBajaPersonalId = Convert.ToInt32(dr["MotivoBajaPersonalId"]),
                            FlagMotivoBajaPersonal = dr["FlagMotivoBajaPersonal"].ToString(),
                            DescMotivoBajaPersonal = dr["DescMotivoBajaPersonal"].ToString(),
                            CodigoMotivoBajaPersonal = dr["CodigoMotivoBajaPersonal"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarMotivoBajaPersonal(MotivoBajaPersonalDTO motivoBajaPersonalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MotivoBajaPersonalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FlagMotivoBajaPersonal", SqlDbType.VarChar, 80);
                    cmd.Parameters["@FlagMotivoBajaPersonal"].Value = motivoBajaPersonalDTO.FlagMotivoBajaPersonal;

                    cmd.Parameters.Add("@DescMotivoBajaPersonal", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescMotivoBajaPersonal"].Value = motivoBajaPersonalDTO.DescMotivoBajaPersonal;

                    cmd.Parameters.Add("@CodigoMotivoBajaPersonal", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoMotivoBajaPersonal"].Value = motivoBajaPersonalDTO.CodigoMotivoBajaPersonal;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = motivoBajaPersonalDTO.UsuarioIngresoRegistro;

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

        public MotivoBajaPersonalDTO BuscarMotivoBajaPersonalID(int Codigo)
        {
            MotivoBajaPersonalDTO motivoBajaPersonalDTO = new MotivoBajaPersonalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MotivoBajaPersonalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MotivoBajaPersonalId", SqlDbType.Int);
                    cmd.Parameters["@MotivoBajaPersonalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        motivoBajaPersonalDTO.MotivoBajaPersonalId = Convert.ToInt32(dr["MotivoBajaPersonalId"]);
                        motivoBajaPersonalDTO.FlagMotivoBajaPersonal = dr["FlagMotivoBajaPersonal"].ToString();
                        motivoBajaPersonalDTO.DescMotivoBajaPersonal = dr["DescMotivoBajaPersonal"].ToString();
                        motivoBajaPersonalDTO.CodigoMotivoBajaPersonal = dr["CodigoMotivoBajaPersonal"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return motivoBajaPersonalDTO;
        }

        public string ActualizarMotivoBajaPersonal(MotivoBajaPersonalDTO motivoBajaPersonalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MotivoBajaPersonalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MotivoBajaPersonalId", SqlDbType.Int);
                    cmd.Parameters["@MotivoBajaPersonalId"].Value = motivoBajaPersonalDTO.MotivoBajaPersonalId;

                    cmd.Parameters.Add("@FlagMotivoBajaPersonal", SqlDbType.VarChar, 80);
                    cmd.Parameters["@FlagMotivoBajaPersonal"].Value = motivoBajaPersonalDTO.FlagMotivoBajaPersonal;

                    cmd.Parameters.Add("@DescMotivoBajaPersonal", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescMotivoBajaPersonal"].Value = motivoBajaPersonalDTO.DescMotivoBajaPersonal;

                    cmd.Parameters.Add("@CodigoMotivoBajaPersonal", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMotivoBajaPersonal"].Value = motivoBajaPersonalDTO.CodigoMotivoBajaPersonal;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = motivoBajaPersonalDTO.UsuarioIngresoRegistro;

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

        public string EliminarMotivoBajaPersonal(MotivoBajaPersonalDTO motivoBajaPersonalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MotivoBajaPersonalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MotivoBajaPersonalId", SqlDbType.Int);
                    cmd.Parameters["@MotivoBajaPersonalId"].Value = motivoBajaPersonalDTO.MotivoBajaPersonalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = motivoBajaPersonalDTO.UsuarioIngresoRegistro;

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
