using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ServicioBrindadoDAO
    {

        SqlCommand cmd = new();

        public List<ServicioBrindadoDTO> ObtenerServicioBrindados()
        {
            List<ServicioBrindadoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ServicioBrindadoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ServicioBrindadoDTO()
                        {
                            ServicioBrindadoId = Convert.ToInt32(dr["ServicioBrindadoId"]),
                            DescServicioBrindado = dr["DescServicioBrindado"].ToString(),
                            CodigoServicioBrindado = dr["CodigoServicioBrindado"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarServicioBrindado(ServicioBrindadoDTO servicioBrindadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ServicioBrindadoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescServicioBrindado", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescServicioBrindado"].Value = servicioBrindadoDTO.DescServicioBrindado;

                    cmd.Parameters.Add("@CodigoServicioBrindado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoServicioBrindado"].Value = servicioBrindadoDTO.CodigoServicioBrindado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioBrindadoDTO.UsuarioIngresoRegistro;

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

        public ServicioBrindadoDTO BuscarServicioBrindadoID(int Codigo)
        {
            ServicioBrindadoDTO ServicioBrindadoDTO = new ServicioBrindadoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ServicioBrindadoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioBrindadoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioBrindadoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ServicioBrindadoDTO.ServicioBrindadoId = Convert.ToInt32(dr["ServicioBrindadoId"]);
                        ServicioBrindadoDTO.DescServicioBrindado = dr["DescServicioBrindado"].ToString();
                        ServicioBrindadoDTO.CodigoServicioBrindado = dr["CodigoServicioBrindado"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ServicioBrindadoDTO;
        }

        public string ActualizarServicioBrindado(ServicioBrindadoDTO ServicioBrindadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ServicioBrindadoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioBrindadoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioBrindadoId"].Value = ServicioBrindadoDTO.ServicioBrindadoId;

                    cmd.Parameters.Add("@DescServicioBrindado", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescServicioBrindado"].Value = ServicioBrindadoDTO.DescServicioBrindado;

                    cmd.Parameters.Add("@CodigoServicioBrindado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoServicioBrindado"].Value = ServicioBrindadoDTO.CodigoServicioBrindado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ServicioBrindadoDTO.UsuarioIngresoRegistro;

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

        public string EliminarServicioBrindado(ServicioBrindadoDTO ServicioBrindadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ServicioBrindadoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioBrindadoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioBrindadoId"].Value = ServicioBrindadoDTO.ServicioBrindadoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ServicioBrindadoDTO.UsuarioIngresoRegistro;

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

