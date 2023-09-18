using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Ditranav;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace Marina.Siesmar.AccesoDatos.Formatos.Ditranav
{
    public class VehiculoEmpleadoComisionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<VehiculoEmpleadoComisionDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<VehiculoEmpleadoComisionDTO> lista = new List<VehiculoEmpleadoComisionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_VehiculoEmpleadoComisionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                cmd.Parameters["@FechaInicio"].Value = fechainicio;

                cmd.Parameters.Add("@FechaFin", SqlDbType.Date);
                cmd.Parameters["@FechaFin"].Value = fechafin;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new VehiculoEmpleadoComisionDTO()
                        {
                            VehiculoEmpleadoComisionId = Convert.ToInt32(dr["VehiculoEmpleadoComisionId"]),
                            PlacaVehiculoComision = dr["PlacaVehiculoComision"].ToString(),
                            ClasificacionFlotaComision = dr["ClasificacionFlotaComision"].ToString(),
                            ClasificacionVehiculo = dr["ClasificacionVehiculo"].ToString(),
                            FechaComisionVehiculo = (dr["FechaComisionVehiculo"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescTipoVehiculoTransporte = dr["DescTipoVehiculoTransporte"].ToString(),
                            DependenciaSolicitante = dr["DependenciaSolicitante"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });

                    }

                }
            }
            return lista;
        }

        public string AgregarRegistro(VehiculoEmpleadoComisionDTO vehiculoEmpleadoComisionDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_VehiculoEmpleadoComisionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PlacaVehiculoComision", SqlDbType.VarChar,10);
                    cmd.Parameters["@PlacaVehiculoComision"].Value = vehiculoEmpleadoComisionDTO.PlacaVehiculoComision;

                    cmd.Parameters.Add("@ClasificacionFlotaComision", SqlDbType.VarChar, 10);
                    cmd.Parameters["@ClasificacionFlotaComision"].Value = vehiculoEmpleadoComisionDTO.ClasificacionFlotaComision;

                    cmd.Parameters.Add("@CodigoMarcaVehiculo", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoMarcaVehiculo"].Value = vehiculoEmpleadoComisionDTO.CodigoMarcaVehiculo;

                    cmd.Parameters.Add("@FechaComisionVehiculo", SqlDbType.Date);
                    cmd.Parameters["@FechaComisionVehiculo"].Value = vehiculoEmpleadoComisionDTO.FechaComisionVehiculo;

                    cmd.Parameters.Add("@CodigoTipoVehiculoTransporte", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoVehiculoTransporte"].Value = vehiculoEmpleadoComisionDTO.CodigoTipoVehiculoTransporte;

                    cmd.Parameters.Add("@DependenciaSolicitante", SqlDbType.VarChar,25);
                    cmd.Parameters["@DependenciaSolicitante"].Value = vehiculoEmpleadoComisionDTO.DependenciaSolicitante;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = vehiculoEmpleadoComisionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = vehiculoEmpleadoComisionDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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

        public VehiculoEmpleadoComisionDTO BuscarFormato(int Codigo)
        {
            VehiculoEmpleadoComisionDTO vehiculoEmpleadoComisionDTO = new VehiculoEmpleadoComisionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_VehiculoEmpleadoComisionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VehiculoEmpleadoComisionId", SqlDbType.Int);
                    cmd.Parameters["@VehiculoEmpleadoComisionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        vehiculoEmpleadoComisionDTO.VehiculoEmpleadoComisionId = Convert.ToInt32(dr["VehiculoEmpleadoComisionId"]);
                        vehiculoEmpleadoComisionDTO.PlacaVehiculoComision = dr["PlacaVehiculoComision"].ToString();
                        vehiculoEmpleadoComisionDTO.ClasificacionFlotaComision = dr["ClasificacionFlotaComision"].ToString();
                        vehiculoEmpleadoComisionDTO.CodigoMarcaVehiculo = dr["CodigoMarcaVehiculo"].ToString();
                        vehiculoEmpleadoComisionDTO.FechaComisionVehiculo = Convert.ToDateTime(dr["FechaComisionVehiculo"]).ToString("yyy-MM-dd");
                        vehiculoEmpleadoComisionDTO.CodigoTipoVehiculoTransporte = dr["CodigoTipoVehiculoTransporte"].ToString() ;
                        vehiculoEmpleadoComisionDTO.DependenciaSolicitante = dr["DependenciaSolicitante"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return vehiculoEmpleadoComisionDTO;
        }

        public string ActualizaFormato(VehiculoEmpleadoComisionDTO vehiculoEmpleadoComisionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_VehiculoEmpleadoComisionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VehiculoEmpleadoComisionId", SqlDbType.Int);
                    cmd.Parameters["@VehiculoEmpleadoComisionId"].Value = vehiculoEmpleadoComisionDTO.VehiculoEmpleadoComisionId;

                    cmd.Parameters.Add("@PlacaVehiculoComision", SqlDbType.VarChar, 10);
                    cmd.Parameters["@PlacaVehiculoComision"].Value = vehiculoEmpleadoComisionDTO.PlacaVehiculoComision;

                    cmd.Parameters.Add("@ClasificacionFlotaComision", SqlDbType.VarChar, 10);
                    cmd.Parameters["@ClasificacionFlotaComision"].Value = vehiculoEmpleadoComisionDTO.ClasificacionFlotaComision;

                    cmd.Parameters.Add("@CodigoMarcaVehiculo", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoMarcaVehiculo"].Value = vehiculoEmpleadoComisionDTO.CodigoMarcaVehiculo;

                    cmd.Parameters.Add("@FechaComisionVehiculo", SqlDbType.Date);
                    cmd.Parameters["@FechaComisionVehiculo"].Value = vehiculoEmpleadoComisionDTO.FechaComisionVehiculo;

                    cmd.Parameters.Add("@CodigoTipoVehiculoTransporte", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoVehiculoTransporte"].Value = vehiculoEmpleadoComisionDTO.CodigoTipoVehiculoTransporte;

                    cmd.Parameters.Add("@DependenciaSolicitante", SqlDbType.VarChar, 25);
                    cmd.Parameters["@DependenciaSolicitante"].Value = vehiculoEmpleadoComisionDTO.DependenciaSolicitante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = vehiculoEmpleadoComisionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(VehiculoEmpleadoComisionDTO vehiculoEmpleadoComisionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_VehiculoEmpleadoComisionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VehiculoEmpleadoComisionId", SqlDbType.Int);
                    cmd.Parameters["@VehiculoEmpleadoComisionId"].Value= vehiculoEmpleadoComisionDTO.VehiculoEmpleadoComisionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = vehiculoEmpleadoComisionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(VehiculoEmpleadoComisionDTO vehiculoEmpleadoComisionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_CargaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Formato", SqlDbType.NVarChar, 200);
                    cmd.Parameters["@Formato"].Value = "VehiculoEmpleadoComision";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = vehiculoEmpleadoComisionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = vehiculoEmpleadoComisionDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_VehiculoEmpleadoComisionRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VehiculoEmpleadoComision", SqlDbType.Structured);
                    cmd.Parameters["@VehiculoEmpleadoComision"].TypeName = "Formato.VehiculoEmpleadoComision";
                    cmd.Parameters["@VehiculoEmpleadoComision"].Value = datos;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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
