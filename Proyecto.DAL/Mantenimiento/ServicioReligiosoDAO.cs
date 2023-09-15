using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ServicioReligiosoDAO
    {

        SqlCommand cmd = new();

        public List<ServicioReligiosoDTO> ObtenerServicioReligiosos()
        {
            List<ServicioReligiosoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ServicioReligiosoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ServicioReligiosoDTO()
                        {
                            ServicioReligiosoId = Convert.ToInt32(dr["ServicioReligiosoId"]),
                            DescServicioReligioso = dr["DescServicioReligioso"].ToString(),
                            CodigoServicioReligioso = dr["CodigoServicioReligioso"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarServicioReligioso(ServicioReligiosoDTO servicioReligiosoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ServicioReligiosoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescServicioReligioso", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescServicioReligioso"].Value = servicioReligiosoDTO.DescServicioReligioso;

                    cmd.Parameters.Add("@CodigoServicioReligioso", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoServicioReligioso"].Value = servicioReligiosoDTO.CodigoServicioReligioso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioReligiosoDTO.UsuarioIngresoRegistro;

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

        public ServicioReligiosoDTO BuscarServicioReligiosoID(int Codigo)
        {
            ServicioReligiosoDTO servicioReligiosoDTO = new ServicioReligiosoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ServicioReligiosoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioReligiosoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioReligiosoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        servicioReligiosoDTO.ServicioReligiosoId = Convert.ToInt32(dr["ServicioReligiosoId"]);
                        servicioReligiosoDTO.DescServicioReligioso = dr["DescServicioReligioso"].ToString();
                        servicioReligiosoDTO.CodigoServicioReligioso = dr["CodigoServicioReligioso"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return servicioReligiosoDTO;
        }

        public string ActualizarServicioReligioso(ServicioReligiosoDTO servicioReligiosoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ServicioReligiosoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioReligiosoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioReligiosoId"].Value = servicioReligiosoDTO.ServicioReligiosoId;

                    cmd.Parameters.Add("@DescServicioReligioso", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescServicioReligioso"].Value = servicioReligiosoDTO.DescServicioReligioso;

                    cmd.Parameters.Add("@CodigoServicioReligioso", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoServicioReligioso"].Value = servicioReligiosoDTO.CodigoServicioReligioso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioReligiosoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarServicioReligioso(ServicioReligiosoDTO servicioReligiosoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ServicioReligiosoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioReligiosoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioReligiosoId"].Value = servicioReligiosoDTO.ServicioReligiosoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioReligiosoDTO.UsuarioIngresoRegistro;

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
