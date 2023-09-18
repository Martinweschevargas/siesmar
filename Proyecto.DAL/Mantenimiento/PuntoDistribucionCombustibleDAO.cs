using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class PuntoDistribucionCombustibleDAO
    {

        SqlCommand cmd = new();

        public List<PuntoDistribucionCombustibleDTO> ObtenerPuntoDistribucionCombustibles()
        {
            List<PuntoDistribucionCombustibleDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_PuntosDistribucionCombustibleListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PuntoDistribucionCombustibleDTO()
                        {
                            PuntoDistribucionCombustibleId = Convert.ToInt32(dr["PuntoDistribucionCombustibleId"]),
                            DescPuntoDistribucionCombustible = dr["DescPuntoDistribucionCombustible"].ToString(),
                            CodigoPuntoDistribucionCombustible = dr["CodigoPuntoDistribucionCombustible"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarPuntoDistribucionCombustible(PuntoDistribucionCombustibleDTO puntoDistribucionCombustibleDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PuntosDistribucionCombustibleRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescPuntoDistribucionCombustible", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescPuntoDistribucionCombustible"].Value = puntoDistribucionCombustibleDTO.DescPuntoDistribucionCombustible;

                    cmd.Parameters.Add("@CodigoPuntoDistribucionCombustible", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoPuntoDistribucionCombustible"].Value = puntoDistribucionCombustibleDTO.CodigoPuntoDistribucionCombustible;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = puntoDistribucionCombustibleDTO.UsuarioIngresoRegistro;

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

        public PuntoDistribucionCombustibleDTO BuscarPuntoDistribucionCombustibleID(int Codigo)
        {
            PuntoDistribucionCombustibleDTO puntoDistribucionCombustibleDTO = new PuntoDistribucionCombustibleDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PuntosDistribucionCombustibleEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PuntoDistribucionCombustibleId", SqlDbType.Int);
                    cmd.Parameters["@PuntoDistribucionCombustibleId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        puntoDistribucionCombustibleDTO.PuntoDistribucionCombustibleId = Convert.ToInt32(dr["PuntoDistribucionCombustibleId"]);
                        puntoDistribucionCombustibleDTO.DescPuntoDistribucionCombustible = dr["DescPuntoDistribucionCombustible"].ToString();
                        puntoDistribucionCombustibleDTO.CodigoPuntoDistribucionCombustible = dr["CodigoPuntoDistribucionCombustible"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return puntoDistribucionCombustibleDTO;
        }

        public string ActualizarPuntoDistribucionCombustible(PuntoDistribucionCombustibleDTO puntoDistribucionCombustibleDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_PuntosDistribucionCombustibleActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PuntoDistribucionCombustibleId", SqlDbType.Int);
                    cmd.Parameters["@PuntoDistribucionCombustibleId"].Value = puntoDistribucionCombustibleDTO.PuntoDistribucionCombustibleId;

                    cmd.Parameters.Add("@DescPuntoDistribucionCombustible", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescPuntoDistribucionCombustible"].Value = puntoDistribucionCombustibleDTO.DescPuntoDistribucionCombustible;

                    cmd.Parameters.Add("@CodigoPuntoDistribucionCombustible", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoPuntoDistribucionCombustible"].Value = puntoDistribucionCombustibleDTO.CodigoPuntoDistribucionCombustible;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = puntoDistribucionCombustibleDTO.UsuarioIngresoRegistro;

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

        public bool EliminarPuntoDistribucionCombustible(PuntoDistribucionCombustibleDTO puntoDistribucionCombustibleDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PuntosDistribucionCombustibleEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PuntoDistribucionCombustibleId", SqlDbType.Int);
                    cmd.Parameters["@PuntoDistribucionCombustibleId"].Value = puntoDistribucionCombustibleDTO.PuntoDistribucionCombustibleId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = puntoDistribucionCombustibleDTO.UsuarioIngresoRegistro;

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
