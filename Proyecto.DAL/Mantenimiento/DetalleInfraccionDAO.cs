using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class DetalleInfraccionDAO
    {

        SqlCommand cmd = new();

        public List<DetalleInfraccionDTO> ObtenerDetalleInfraccions()
        {
            List<DetalleInfraccionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_DetalleInfraccionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DetalleInfraccionDTO()
                        {
                            DetalleInfraccionId = Convert.ToInt32(dr["DetalleInfraccionId"]),
                            DescDetalleInfraccion = dr["DescDetalleInfraccion"].ToString(),
                            CodigoDetalleInfraccion = dr["CodigoDetalleInfraccion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarDetalleInfraccion(DetalleInfraccionDTO detalleInfraccionDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DetalleInfraccionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescDetalleInfraccion", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescDetalleInfraccion"].Value = detalleInfraccionDTO.DescDetalleInfraccion;

                    cmd.Parameters.Add("@CodigoDetalleInfraccion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoDetalleInfraccion"].Value = detalleInfraccionDTO.CodigoDetalleInfraccion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = detalleInfraccionDTO.UsuarioIngresoRegistro;

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

        public DetalleInfraccionDTO BuscarDetalleInfraccionID(int Codigo)
        {
            DetalleInfraccionDTO detalleInfraccionDTO = new DetalleInfraccionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DetalleInfraccionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DetalleInfraccionId", SqlDbType.Int);
                    cmd.Parameters["@DetalleInfraccionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        detalleInfraccionDTO.DetalleInfraccionId = Convert.ToInt32(dr["DetalleInfraccionId"]);
                        detalleInfraccionDTO.DescDetalleInfraccion = dr["DescDetalleInfraccion"].ToString();
                        detalleInfraccionDTO.CodigoDetalleInfraccion = dr["CodigoDetalleInfraccion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return detalleInfraccionDTO;
        }

        public string ActualizarDetalleInfraccion(DetalleInfraccionDTO detalleInfraccionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DetalleInfraccionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DetalleInfraccionId", SqlDbType.Int);
                    cmd.Parameters["@DetalleInfraccionId"].Value = detalleInfraccionDTO.DetalleInfraccionId;

                    cmd.Parameters.Add("@DescDetalleInfraccion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescDetalleInfraccion"].Value = detalleInfraccionDTO.DescDetalleInfraccion;

                    cmd.Parameters.Add("@CodigoDetalleInfraccion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoDetalleInfraccion"].Value = detalleInfraccionDTO.CodigoDetalleInfraccion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = detalleInfraccionDTO.UsuarioIngresoRegistro;

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

        public string EliminarDetalleInfraccion(DetalleInfraccionDTO detalleInfraccionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DetalleInfraccionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DetalleInfraccionId", SqlDbType.Int);
                    cmd.Parameters["@DetalleInfraccionId"].Value = detalleInfraccionDTO.DetalleInfraccionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = detalleInfraccionDTO.UsuarioIngresoRegistro;

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
