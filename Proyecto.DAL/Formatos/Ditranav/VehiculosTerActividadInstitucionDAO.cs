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
    public class VehiculosTerActividadInstitucionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<VehiculosTerActividadInstitucionDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<VehiculosTerActividadInstitucionDTO> lista = new List<VehiculosTerActividadInstitucionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_VehiculosTerActividadInstitucionListar", conexion);
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
                        lista.Add(new VehiculosTerActividadInstitucionDTO()
                        {
                            VehiculosTerActividadInstitucionId = Convert.ToInt32(dr["VehiculosTerActividadInstitucionId"]),
                            PlacaVehiculo = dr["PlacaVehiculo"].ToString(),
                            ClasificacionFlotaVehiculo = dr["ClasificacionFlotaVehiculo"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            ClasificacionVehiculo = dr["ClasificacionVehiculo"].ToString(),
                            AnioFabricacionVehiculo = Convert.ToInt32(dr["AnioFabricacionVehiculo"]),
                            DependenciaAsignadaVehiculo = dr["DependenciaAsignadaVehiculo"].ToString(),
                            EstadoOperatividadVehiculo = dr["EstadoOperatividadVehiculo"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(VehiculosTerActividadInstitucionDTO vehiculosTerActividadInstDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_VehiculosTerActividadInstitucionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PlacaVehiculo", SqlDbType.VarChar,10);
                    cmd.Parameters["@PlacaVehiculo"].Value = vehiculosTerActividadInstDTO.PlacaVehiculo;

                    cmd.Parameters.Add("@ClasificacionFlotaVehiculo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@ClasificacionFlotaVehiculo"].Value = vehiculosTerActividadInstDTO.ClasificacionFlotaVehiculo;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = vehiculosTerActividadInstDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoMarcaVehiculo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMarcaVehiculo"].Value = vehiculosTerActividadInstDTO.CodigoMarcaVehiculo;

                    cmd.Parameters.Add("@AnioFabricacionVehiculo", SqlDbType.Int);
                    cmd.Parameters["@AnioFabricacionVehiculo"].Value = vehiculosTerActividadInstDTO.AnioFabricacionVehiculo;

                    cmd.Parameters.Add("@DependenciaAsignadaVehiculo", SqlDbType.VarChar,25);
                    cmd.Parameters["@DependenciaAsignadaVehiculo"].Value = vehiculosTerActividadInstDTO.DependenciaAsignadaVehiculo;

                    cmd.Parameters.Add("@EstadoOperatividadVehiculo", SqlDbType.VarChar,15);
                    cmd.Parameters["@EstadoOperatividadVehiculo"].Value = vehiculosTerActividadInstDTO.EstadoOperatividadVehiculo;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = vehiculosTerActividadInstDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = vehiculosTerActividadInstDTO.UsuarioIngresoRegistro;

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

        public VehiculosTerActividadInstitucionDTO BuscarFormato(int Codigo)
        {
            VehiculosTerActividadInstitucionDTO vehiculosTerActividadInstDTO = new VehiculosTerActividadInstitucionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_VehiculosTerActividadInstitucionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VehiculosTerActividadInstitucionId", SqlDbType.Int);
                    cmd.Parameters["@VehiculosTerActividadInstitucionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        vehiculosTerActividadInstDTO.VehiculosTerActividadInstitucionId = Convert.ToInt32(dr["VehiculosTerActividadInstitucionId"]);
                        vehiculosTerActividadInstDTO.PlacaVehiculo = dr["PlacaVehiculo"].ToString();
                        vehiculosTerActividadInstDTO.ClasificacionFlotaVehiculo = dr["ClasificacionFlotaVehiculo"].ToString();
                        vehiculosTerActividadInstDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        vehiculosTerActividadInstDTO.CodigoMarcaVehiculo = dr["CodigoMarcaVehiculo"].ToString();
                        vehiculosTerActividadInstDTO.AnioFabricacionVehiculo = Convert.ToInt32(dr["AnioFabricacionVehiculo"]);
                        vehiculosTerActividadInstDTO.DependenciaAsignadaVehiculo = dr["DependenciaAsignadaVehiculo"].ToString();
                        vehiculosTerActividadInstDTO.EstadoOperatividadVehiculo = dr["EstadoOperatividadVehiculo"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return vehiculosTerActividadInstDTO;
        }

        public string ActualizaFormato(VehiculosTerActividadInstitucionDTO vehiculosTerActividadInstDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_VehiculosTerActividadInstitucionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VehiculosTerActividadInstitucionId", SqlDbType.Int);
                    cmd.Parameters["@VehiculosTerActividadInstitucionId"].Value = vehiculosTerActividadInstDTO.VehiculosTerActividadInstitucionId;

                    cmd.Parameters.Add("@PlacaVehiculo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@PlacaVehiculo"].Value = vehiculosTerActividadInstDTO.PlacaVehiculo;

                    cmd.Parameters.Add("@ClasificacionFlotaVehiculo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@ClasificacionFlotaVehiculo"].Value = vehiculosTerActividadInstDTO.ClasificacionFlotaVehiculo;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = vehiculosTerActividadInstDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoMarcaVehiculo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMarcaVehiculo"].Value = vehiculosTerActividadInstDTO.CodigoMarcaVehiculo;

                    cmd.Parameters.Add("@AnioFabricacionVehiculo", SqlDbType.Int);
                    cmd.Parameters["@AnioFabricacionVehiculo"].Value = vehiculosTerActividadInstDTO.AnioFabricacionVehiculo;

                    cmd.Parameters.Add("@DependenciaAsignadaVehiculo", SqlDbType.VarChar, 25);
                    cmd.Parameters["@DependenciaAsignadaVehiculo"].Value = vehiculosTerActividadInstDTO.DependenciaAsignadaVehiculo;

                    cmd.Parameters.Add("@EstadoOperatividadVehiculo", SqlDbType.VarChar, 15);
                    cmd.Parameters["@EstadoOperatividadVehiculo"].Value = vehiculosTerActividadInstDTO.EstadoOperatividadVehiculo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = vehiculosTerActividadInstDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(VehiculosTerActividadInstitucionDTO vehiculosTerActividadInstDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_VehiculosTerActividadInstitucionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VehiculosTerActividadInstitucionId", SqlDbType.Int);
                    cmd.Parameters["@VehiculosTerActividadInstitucionId"].Value= vehiculosTerActividadInstDTO.VehiculosTerActividadInstitucionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = vehiculosTerActividadInstDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(VehiculosTerActividadInstitucionDTO vehiculosTerActividadInstDTO)
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
                    cmd.Parameters["@Formato"].Value = "VehiculosTerActividadInstitucion";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = vehiculosTerActividadInstDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = vehiculosTerActividadInstDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_VehiculosTerActividadInstitucionRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VehiculosTerActividadInstitucion", SqlDbType.Structured);
                    cmd.Parameters["@VehiculosTerActividadInstitucion"].TypeName = "Formato.VehiculosTerActividadInstitucion";
                    cmd.Parameters["@VehiculosTerActividadInstitucion"].Value = datos;

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
