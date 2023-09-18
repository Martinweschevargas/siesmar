using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class VehiculoServicioGrupoDAO
    {

        SqlCommand cmd = new();

        public List<VehiculoServicioGrupoDTO> ObtenerVehiculoServicioGrupos()
        {
            List<VehiculoServicioGrupoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_VehiculoServicioGrupoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new VehiculoServicioGrupoDTO()
                        {
                            VehiculoServicioGrupoId = Convert.ToInt32(dr["VehiculoServicioGrupoId"]),
                            DescVehiculoServicioGrupo = dr["DescVehiculoServicioGrupo"].ToString(),
                            CodigoVehiculoServicioGrupo = dr["CodigoVehiculoServicioGrupo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarVehiculoServicioGrupo(VehiculoServicioGrupoDTO vehiculoServicioGrupoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_VehiculoServicioGrupoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescVehiculoServicioGrupo", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescVehiculoServicioGrupo"].Value = vehiculoServicioGrupoDTO.DescVehiculoServicioGrupo;

                    cmd.Parameters.Add("@CodigoVehiculoServicioGrupo", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoVehiculoServicioGrupo"].Value = vehiculoServicioGrupoDTO.CodigoVehiculoServicioGrupo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = vehiculoServicioGrupoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                        }
                    }
                }
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public VehiculoServicioGrupoDTO BuscarVehiculoServicioGrupoID(int Codigo)
        {
            VehiculoServicioGrupoDTO vehiculoServicioGrupoDTO = new VehiculoServicioGrupoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_VehiculoServicioGrupoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VehiculoServicioGrupoId", SqlDbType.Int);
                    cmd.Parameters["@VehiculoServicioGrupoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        vehiculoServicioGrupoDTO.VehiculoServicioGrupoId = Convert.ToInt32(dr["VehiculoServicioGrupoId"]);
                        vehiculoServicioGrupoDTO.DescVehiculoServicioGrupo = dr["DescVehiculoServicioGrupo"].ToString();
                        vehiculoServicioGrupoDTO.CodigoVehiculoServicioGrupo = dr["CodigoVehiculoServicioGrupo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return vehiculoServicioGrupoDTO;
        }

        public string ActualizarVehiculoServicioGrupo(VehiculoServicioGrupoDTO vehiculoServicioGrupoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_VehiculoServicioGrupoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VehiculoServicioGrupoId", SqlDbType.Int);
                    cmd.Parameters["@VehiculoServicioGrupoId"].Value = vehiculoServicioGrupoDTO.VehiculoServicioGrupoId;

                    cmd.Parameters.Add("@DescVehiculoServicioGrupo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescVehiculoServicioGrupo"].Value = vehiculoServicioGrupoDTO.DescVehiculoServicioGrupo;

                    cmd.Parameters.Add("@CodigoVehiculoServicioGrupo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoVehiculoServicioGrupo"].Value = vehiculoServicioGrupoDTO.CodigoVehiculoServicioGrupo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = vehiculoServicioGrupoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public bool EliminarVehiculoServicioGrupo(VehiculoServicioGrupoDTO vehiculoServicioGrupoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_VehiculoServicioGrupoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VehiculoServicioGrupoId", SqlDbType.Int);
                    cmd.Parameters["@VehiculoServicioGrupoId"].Value = vehiculoServicioGrupoDTO.VehiculoServicioGrupoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = vehiculoServicioGrupoDTO.UsuarioIngresoRegistro;

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
