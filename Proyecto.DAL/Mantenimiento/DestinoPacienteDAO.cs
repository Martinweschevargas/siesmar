using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class DestinoPacienteDAO
    {

        SqlCommand cmd = new();

        public List<DestinoPacienteDTO> ObtenerDestinoPacientes()
        {
            List<DestinoPacienteDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_DestinoPacienteListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DestinoPacienteDTO()
                        {
                            DestinoPacienteId = Convert.ToInt32(dr["DestinoPacienteId"]),
                            DescDestinoPaciente = dr["DescDestinoPaciente"].ToString(),
                            CodigoDestinoPaciente = dr["CodigoDestinoPaciente"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarDestinoPaciente(DestinoPacienteDTO destinoPacienteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DestinoPacienteRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescDestinoPaciente", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescDestinoPaciente"].Value = destinoPacienteDTO.DescDestinoPaciente;

                    cmd.Parameters.Add("@CodigoDestinoPaciente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoDestinoPaciente"].Value = destinoPacienteDTO.CodigoDestinoPaciente;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = destinoPacienteDTO.UsuarioIngresoRegistro;

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

        public DestinoPacienteDTO BuscarDestinoPacienteID(int Codigo)
        {
            DestinoPacienteDTO destinoPacienteDTO = new DestinoPacienteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DestinoPacienteEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DestinoPacienteId", SqlDbType.Int);
                    cmd.Parameters["@DestinoPacienteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        destinoPacienteDTO.DestinoPacienteId = Convert.ToInt32(dr["DestinoPacienteId"]);
                        destinoPacienteDTO.DescDestinoPaciente = dr["DescDestinoPaciente"].ToString();
                        destinoPacienteDTO.CodigoDestinoPaciente = dr["CodigoDestinoPaciente"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return destinoPacienteDTO;
        }

        public string ActualizarDestinoPaciente(DestinoPacienteDTO destinoPacienteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DestinoPacienteActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DestinoPacienteId", SqlDbType.Int);
                    cmd.Parameters["@DestinoPacienteId"].Value = destinoPacienteDTO.DestinoPacienteId;

                    cmd.Parameters.Add("@DescDestinoPaciente", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescDestinoPaciente"].Value = destinoPacienteDTO.DescDestinoPaciente;

                    cmd.Parameters.Add("@CodigoDestinoPaciente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoDestinoPaciente"].Value = destinoPacienteDTO.CodigoDestinoPaciente;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = destinoPacienteDTO.UsuarioIngresoRegistro;

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

        public string EliminarDestinoPaciente(DestinoPacienteDTO destinoPacienteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DestinoPacienteEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DestinoPacienteId", SqlDbType.Int);
                    cmd.Parameters["@DestinoPacienteId"].Value = destinoPacienteDTO.DestinoPacienteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = destinoPacienteDTO.UsuarioIngresoRegistro;

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
