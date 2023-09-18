using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ServicioLavanderiaDAO
    {

        SqlCommand cmd = new();

        public List<ServicioLavanderiaDTO> ObtenerServicioLavanderias()
        {
            List<ServicioLavanderiaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ServicioLavanderiaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ServicioLavanderiaDTO()
                        {
                            ServicioLavanderiaId = Convert.ToInt32(dr["ServicioLavanderiaId"]),
                            DescServicioLavanderia = dr["DescServicioLavanderia"].ToString(),
                            CodigoServicioLavanderia = dr["CodigoServicioLavanderia"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarServicioLavanderia(ServicioLavanderiaDTO servicioLavanderiaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ServicioLavanderiaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescServicioLavanderia", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescServicioLavanderia"].Value = servicioLavanderiaDTO.DescServicioLavanderia;

                    cmd.Parameters.Add("@CodigoServicioLavanderia", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoServicioLavanderia"].Value = servicioLavanderiaDTO.CodigoServicioLavanderia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioLavanderiaDTO.UsuarioIngresoRegistro;

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

        public ServicioLavanderiaDTO BuscarServicioLavanderiaID(int Codigo)
        {
            ServicioLavanderiaDTO servicioLavanderiaDTO = new ServicioLavanderiaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ServicioLavanderiaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioLavanderiaId", SqlDbType.Int);
                    cmd.Parameters["@ServicioLavanderiaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        servicioLavanderiaDTO.ServicioLavanderiaId = Convert.ToInt32(dr["ServicioLavanderiaId"]);
                        servicioLavanderiaDTO.DescServicioLavanderia = dr["DescServicioLavanderia"].ToString();
                        servicioLavanderiaDTO.CodigoServicioLavanderia = dr["CodigoServicioLavanderia"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return servicioLavanderiaDTO;
        }

        public string ActualizarServicioLavanderia(ServicioLavanderiaDTO servicioLavanderiaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ServicioLavanderiaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioLavanderiaId", SqlDbType.Int);
                    cmd.Parameters["@ServicioLavanderiaId"].Value = servicioLavanderiaDTO.ServicioLavanderiaId;

                    cmd.Parameters.Add("@DescServicioLavanderia", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescServicioLavanderia"].Value = servicioLavanderiaDTO.DescServicioLavanderia;

                    cmd.Parameters.Add("@CodigoServicioLavanderia", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoServicioLavanderia"].Value = servicioLavanderiaDTO.CodigoServicioLavanderia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioLavanderiaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarServicioLavanderia(ServicioLavanderiaDTO servicioLavanderiaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ServicioLavanderiaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioLavanderiaId", SqlDbType.Int);
                    cmd.Parameters["@ServicioLavanderiaId"].Value = servicioLavanderiaDTO.ServicioLavanderiaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioLavanderiaDTO.UsuarioIngresoRegistro;

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
