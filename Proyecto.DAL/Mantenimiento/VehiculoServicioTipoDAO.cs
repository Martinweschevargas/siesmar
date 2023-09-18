using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class VehiculoServicioTipoDAO
    {

        SqlCommand cmd = new();

        public List<VehiculoServicioTipoDTO> ObtenerVehiculoServicioTipos()
        {
            List<VehiculoServicioTipoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_VehiculoServicioTipoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new VehiculoServicioTipoDTO()
                        {
                            VehiculoServicioTipoId = Convert.ToInt32(dr["VehiculoServicioTipoId"]),
                            DescVehiculoServicioTipo = dr["DescVehiculoServicioTipo"].ToString(),
                            CodigoVehiculoServicioTipo = dr["CodigoVehiculoServicioTipo"].ToString(),
                            DescVehiculoServicioGrupo = dr["DescVehiculoServicioGrupo"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarVehiculoServicioTipo(VehiculoServicioTipoDTO vehiculoServicioTipoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_VehiculoServicioTipoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescVehiculoServicioTipo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescVehiculoServicioTipo"].Value = vehiculoServicioTipoDTO.DescVehiculoServicioTipo;

                    cmd.Parameters.Add("@CodigoVehiculoServicioTipo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoVehiculoServicioTipo"].Value = vehiculoServicioTipoDTO.CodigoVehiculoServicioTipo;

                    cmd.Parameters.Add("@VehiculoServicioGrupoId", SqlDbType.Int);
                    cmd.Parameters["@VehiculoServicioGrupoId"].Value = vehiculoServicioTipoDTO.VehiculoServicioGrupoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = vehiculoServicioTipoDTO.UsuarioIngresoRegistro;

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

        public VehiculoServicioTipoDTO BuscarVehiculoServicioTipoID(int Codigo)
        {
            VehiculoServicioTipoDTO vehiculoServicioTipoDTO = new VehiculoServicioTipoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_VehiculoServicioTipoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VehiculoServicioTipoId", SqlDbType.Int);
                    cmd.Parameters["@VehiculoServicioTipoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        vehiculoServicioTipoDTO.VehiculoServicioTipoId = Convert.ToInt32(dr["VehiculoServicioTipoId"]);
                        vehiculoServicioTipoDTO.DescVehiculoServicioTipo = dr["DescVehiculoServicioTipo"].ToString();
                        vehiculoServicioTipoDTO.CodigoVehiculoServicioTipo = dr["CodigoVehiculoServicioTipo"].ToString();
                        vehiculoServicioTipoDTO.VehiculoServicioGrupoId = Convert.ToInt32(dr["VehiculoServicioGrupoId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return vehiculoServicioTipoDTO;
        }

        public string ActualizarVehiculoServicioTipo(VehiculoServicioTipoDTO vehiculoServicioTipoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_VehiculoServicioTipoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VehiculoServicioTipoId", SqlDbType.Int);
                    cmd.Parameters["@VehiculoServicioTipoId"].Value = vehiculoServicioTipoDTO.VehiculoServicioTipoId;

                    cmd.Parameters.Add("@DescVehiculoServicioTipo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescVehiculoServicioTipo"].Value = vehiculoServicioTipoDTO.DescVehiculoServicioTipo;

                    cmd.Parameters.Add("@CodigoVehiculoServicioTipo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoVehiculoServicioTipo"].Value = vehiculoServicioTipoDTO.CodigoVehiculoServicioTipo;

                    cmd.Parameters.Add("@VehiculoServicioGrupoId", SqlDbType.Int);
                    cmd.Parameters["@VehiculoServicioGrupoId"].Value = vehiculoServicioTipoDTO.VehiculoServicioGrupoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = vehiculoServicioTipoDTO.UsuarioIngresoRegistro;

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

        public string EliminarVehiculoServicioTipo(VehiculoServicioTipoDTO vehiculoServicioTipoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_VehiculoServicioTipoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VehiculoServicioTipoId", SqlDbType.Int);
                    cmd.Parameters["@VehiculoServicioTipoId"].Value = vehiculoServicioTipoDTO.VehiculoServicioTipoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = vehiculoServicioTipoDTO.UsuarioIngresoRegistro;

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
