using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AccionAnteCiberataqueDAO
    {

        SqlCommand cmd = new();

        public List<AccionAnteCiberataqueDTO> ObtenerAccionAnteCiberataques()
        {
            List<AccionAnteCiberataqueDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AccionAnteCiberataqueListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AccionAnteCiberataqueDTO()
                        {
                            AccionAnteCiberataqueId = Convert.ToInt32(dr["AccionAnteCiberataqueId"]),
                            DescAccionAnteCiberataque = dr["DescAccionAnteCiberataque"].ToString(),
                            CodigoAccionAnteCiberataque = dr["CodigoAccionAnteCiberataque"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAccionAnteCiberataque(AccionAnteCiberataqueDTO accionAnteCiberataqueDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AccionAnteCiberataqueRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescAccionAnteCiberataque", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescAccionAnteCiberataque"].Value = accionAnteCiberataqueDTO.DescAccionAnteCiberataque;

                    cmd.Parameters.Add("@CodigoAccionAnteCiberataque", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoAccionAnteCiberataque"].Value = accionAnteCiberataqueDTO.CodigoAccionAnteCiberataque;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = accionAnteCiberataqueDTO.UsuarioIngresoRegistro;

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

        public AccionAnteCiberataqueDTO BuscarAccionAnteCiberataqueID(int Codigo)
        {
            AccionAnteCiberataqueDTO accionAnteCiberataqueDTO = new AccionAnteCiberataqueDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AccionAnteCiberataqueEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AccionAnteCiberataqueId", SqlDbType.Int);
                    cmd.Parameters["@AccionAnteCiberataqueId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        accionAnteCiberataqueDTO.AccionAnteCiberataqueId = Convert.ToInt32(dr["AccionAnteCiberataqueId"]);
                        accionAnteCiberataqueDTO.DescAccionAnteCiberataque = dr["DescAccionAnteCiberataque"].ToString();
                        accionAnteCiberataqueDTO.CodigoAccionAnteCiberataque = dr["CodigoAccionAnteCiberataque"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return accionAnteCiberataqueDTO;
        }

        public string ActualizarAccionAnteCiberataque(AccionAnteCiberataqueDTO accionAnteCiberataqueDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AccionAnteCiberataqueActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AccionAnteCiberataqueId", SqlDbType.Int);
                    cmd.Parameters["@AccionAnteCiberataqueId"].Value = accionAnteCiberataqueDTO.AccionAnteCiberataqueId;

                    cmd.Parameters.Add("@DescAccionAnteCiberataque", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescAccionAnteCiberataque"].Value = accionAnteCiberataqueDTO.DescAccionAnteCiberataque;

                    cmd.Parameters.Add("@CodigoAccionAnteCiberataque", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoAccionAnteCiberataque"].Value = accionAnteCiberataqueDTO.CodigoAccionAnteCiberataque;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = accionAnteCiberataqueDTO.UsuarioIngresoRegistro;

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

        public string EliminarAccionAnteCiberataque(AccionAnteCiberataqueDTO accionAnteCiberataqueDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AccionAnteCiberataqueEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AccionAnteCiberataqueId", SqlDbType.Int);
                    cmd.Parameters["@AccionAnteCiberataqueId"].Value = accionAnteCiberataqueDTO.AccionAnteCiberataqueId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = accionAnteCiberataqueDTO.UsuarioIngresoRegistro;

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
