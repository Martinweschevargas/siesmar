using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class OrigenPacienteIntervenidoDAO
    {

        SqlCommand cmd = new();

        public List<OrigenPacienteIntervenidoDTO> ObtenerOrigenPacienteIntervenidos()
        {
            List<OrigenPacienteIntervenidoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_OrigenPacienteIntervenidoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new OrigenPacienteIntervenidoDTO()
                        {
                            OrigenPacienteIntervenidoId = Convert.ToInt32(dr["OrigenPacienteIntervenidoId"]),
                            DescOrigenPacienteIntervenido = dr["DescOrigenPacienteIntervenido"].ToString(),
                            CodigoOrigenPacienteIntervenido = dr["CodigoOrigenPacienteIntervenido"].ToString(),
                            AbrevOrigenPacienteIntervenido = dr["AbrevOrigenPacienteIntervenido"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarOrigenPacienteIntervenido(OrigenPacienteIntervenidoDTO origenPacienteIntervenidoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_OrigenPacienteIntervenidoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescOrigenPacienteIntervenido", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescOrigenPacienteIntervenido"].Value = origenPacienteIntervenidoDTO.DescOrigenPacienteIntervenido;

                    cmd.Parameters.Add("@CodigoOrigenPacienteIntervenido", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoOrigenPacienteIntervenido"].Value = origenPacienteIntervenidoDTO.CodigoOrigenPacienteIntervenido;

                    cmd.Parameters.Add("@AbrevOrigenPacienteIntervenido", SqlDbType.VarChar, 10);
                    cmd.Parameters["@AbrevOrigenPacienteIntervenido"].Value = origenPacienteIntervenidoDTO.AbrevOrigenPacienteIntervenido;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = origenPacienteIntervenidoDTO.UsuarioIngresoRegistro;

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

        public OrigenPacienteIntervenidoDTO BuscarOrigenPacienteIntervenidoID(int Codigo)
        {
            OrigenPacienteIntervenidoDTO origenPacienteIntervenidoDTO = new OrigenPacienteIntervenidoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_OrigenPacienteIntervenidoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OrigenPacienteIntervenidoId", SqlDbType.Int);
                    cmd.Parameters["@OrigenPacienteIntervenidoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        origenPacienteIntervenidoDTO.OrigenPacienteIntervenidoId = Convert.ToInt32(dr["OrigenPacienteIntervenidoId"]);
                        origenPacienteIntervenidoDTO.DescOrigenPacienteIntervenido = dr["DescOrigenPacienteIntervenido"].ToString();
                        origenPacienteIntervenidoDTO.CodigoOrigenPacienteIntervenido = dr["CodigoOrigenPacienteIntervenido"].ToString();
                        origenPacienteIntervenidoDTO.AbrevOrigenPacienteIntervenido = dr["AbrevOrigenPacienteIntervenido"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return origenPacienteIntervenidoDTO;
        }

        public string ActualizarOrigenPacienteIntervenido(OrigenPacienteIntervenidoDTO origenPacienteIntervenidoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_OrigenPacienteIntervenidoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OrigenPacienteIntervenidoId", SqlDbType.Int);
                    cmd.Parameters["@OrigenPacienteIntervenidoId"].Value = origenPacienteIntervenidoDTO.OrigenPacienteIntervenidoId;

                    cmd.Parameters.Add("@DescOrigenPacienteIntervenido", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescOrigenPacienteIntervenido"].Value = origenPacienteIntervenidoDTO.DescOrigenPacienteIntervenido;

                    cmd.Parameters.Add("@CodigoOrigenPacienteIntervenido", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoOrigenPacienteIntervenido"].Value = origenPacienteIntervenidoDTO.CodigoOrigenPacienteIntervenido;

                    cmd.Parameters.Add("@AbrevOrigenPacienteIntervenido", SqlDbType.VarChar, 10);
                    cmd.Parameters["@AbrevOrigenPacienteIntervenido"].Value = origenPacienteIntervenidoDTO.AbrevOrigenPacienteIntervenido;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = origenPacienteIntervenidoDTO.UsuarioIngresoRegistro;

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

        public string EliminarOrigenPacienteIntervenido(OrigenPacienteIntervenidoDTO origenPacienteIntervenidoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_OrigenPacienteIntervenidoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OrigenPacienteIntervenidoId", SqlDbType.Int);
                    cmd.Parameters["@OrigenPacienteIntervenidoId"].Value = origenPacienteIntervenidoDTO.OrigenPacienteIntervenidoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = origenPacienteIntervenidoDTO.UsuarioIngresoRegistro;

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
