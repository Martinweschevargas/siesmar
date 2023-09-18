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
    public class MantenimientoReparacionVehiculosDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<MantenimientoReparacionVehiculosDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<MantenimientoReparacionVehiculosDTO> lista = new List<MantenimientoReparacionVehiculosDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_MantenimientoReparacionVehiculoListar", conexion);
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
                        lista.Add(new MantenimientoReparacionVehiculosDTO()
                        {
                            MantenimientoReparacionVehiculoId = Convert.ToInt32(dr["MantenimientoReparacionVehiculoId"]),
                            PlacaVehiculoMantenimiento = dr["PlacaVehiculoMantenimiento"].ToString(),
                            FechaIngresoMantenimiento = (dr["FechaIngresoMantenimiento"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            ClasificacionFlotaVehiculoM = dr["ClasificacionFlotaVehiculoM"].ToString(),
                            ClasificacionVehiculo = dr["ClasificacionVehiculo"].ToString(),
                            AnioFabricacionVehiculoM = Convert.ToInt32(dr["AnioFabricacionVehiculoM"]),
                            KilometrosVehiculoM = Convert.ToInt32(dr["KilometrosVehiculoM"]),
                            DependenciaVehiculoM = dr["DependenciaVehiculoM"].ToString(),
                            MotivoServicioVehiculo = dr["MotivoServicioVehiculo"].ToString(),
                            FechaSalidaVehiculoM = (dr["FechaSalidaVehiculoM"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            RequerimientoRepuesto = dr["RequerimientoRepuesto"].ToString(),
                            CostoRepuestos = Convert.ToDecimal(dr["CostoRepuestos"]),
                            OrdenCompraServicio = dr["OrdenCompraServicio"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });

                    }

                }
            }
            return lista;
        }

        public string AgregarRegistro(MantenimientoReparacionVehiculosDTO mantReparacionVehiculosDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open(); 

                    cmd = new SqlCommand("Formato.usp_MantenimientoReparacionVehiculoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PlacaVehiculoMantenimiento", SqlDbType.VarChar,10);
                    cmd.Parameters["@PlacaVehiculoMantenimiento"].Value = mantReparacionVehiculosDTO.PlacaVehiculoMantenimiento;

                    cmd.Parameters.Add("@FechaIngresoMantenimiento", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoMantenimiento"].Value = mantReparacionVehiculosDTO.FechaIngresoMantenimiento;

                    cmd.Parameters.Add("@ClasificacionFlotaVehiculoM", SqlDbType.VarChar, 20);
                    cmd.Parameters["@ClasificacionFlotaVehiculoM"].Value = mantReparacionVehiculosDTO.ClasificacionFlotaVehiculoM;

                    cmd.Parameters.Add("@CodigoMarcaVehiculo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMarcaVehiculo"].Value = mantReparacionVehiculosDTO.CodigoMarcaVehiculo;

                    cmd.Parameters.Add("@AnioFabricacionVehiculoM", SqlDbType.Int);
                    cmd.Parameters["@AnioFabricacionVehiculoM"].Value = mantReparacionVehiculosDTO.AnioFabricacionVehiculoM;

                    cmd.Parameters.Add("@KilometrosVehiculoM", SqlDbType.Int);
                    cmd.Parameters["@KilometrosVehiculoM"].Value = mantReparacionVehiculosDTO.KilometrosVehiculoM;

                    cmd.Parameters.Add("@DependenciaVehiculoM", SqlDbType.VarChar,25);
                    cmd.Parameters["@DependenciaVehiculoM"].Value = mantReparacionVehiculosDTO.DependenciaVehiculoM;

                    cmd.Parameters.Add("@MotivoServicioVehiculo", SqlDbType.VarChar, 15);
                    cmd.Parameters["@MotivoServicioVehiculo"].Value = mantReparacionVehiculosDTO.MotivoServicioVehiculo;

                    cmd.Parameters.Add("@FechaSalidaVehiculoM", SqlDbType.VarChar,50);
                    cmd.Parameters["@FechaSalidaVehiculoM"].Value = mantReparacionVehiculosDTO.FechaSalidaVehiculoM;

                    cmd.Parameters.Add("@RequerimientoRepuesto", SqlDbType.VarChar,10);
                    cmd.Parameters["@RequerimientoRepuesto"].Value = mantReparacionVehiculosDTO.RequerimientoRepuesto;

                    cmd.Parameters.Add("@CostoRepuestos", SqlDbType.Decimal);
                    cmd.Parameters["@CostoRepuestos"].Value = mantReparacionVehiculosDTO.CostoRepuestos;

                    cmd.Parameters.Add("@OrdenCompraServicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@OrdenCompraServicio"].Value = mantReparacionVehiculosDTO.OrdenCompraServicio;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = mantReparacionVehiculosDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = mantReparacionVehiculosDTO.UsuarioIngresoRegistro;

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

        public MantenimientoReparacionVehiculosDTO BuscarFormato(int Codigo)
        {
            MantenimientoReparacionVehiculosDTO mantReparacionVehiculosDTO = new MantenimientoReparacionVehiculosDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MantenimientoReparacionVehiculoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MantenimientoReparacionVehiculoId", SqlDbType.Int);
                    cmd.Parameters["@MantenimientoReparacionVehiculoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        mantReparacionVehiculosDTO.MantenimientoReparacionVehiculoId = Convert.ToInt32(dr["MantenimientoReparacionVehiculoId"]);
                        mantReparacionVehiculosDTO.PlacaVehiculoMantenimiento = dr["PlacaVehiculoMantenimiento"].ToString();
                        mantReparacionVehiculosDTO.FechaIngresoMantenimiento = Convert.ToDateTime(dr["FechaIngresoMantenimiento"]).ToString("yyy-MM-dd");
                        mantReparacionVehiculosDTO.ClasificacionFlotaVehiculoM = dr["ClasificacionFlotaVehiculoM"].ToString();
                        mantReparacionVehiculosDTO.CodigoMarcaVehiculo = dr["CodigoMarcaVehiculo"].ToString();
                        mantReparacionVehiculosDTO.AnioFabricacionVehiculoM = Convert.ToInt32(dr["AnioFabricacionVehiculoM"]);
                        mantReparacionVehiculosDTO.KilometrosVehiculoM = Convert.ToInt32(dr["KilometrosVehiculoM"]);
                        mantReparacionVehiculosDTO.DependenciaVehiculoM = dr["DependenciaVehiculoM"].ToString();
                        mantReparacionVehiculosDTO.MotivoServicioVehiculo = dr["MotivoServicioVehiculo"].ToString();
                        mantReparacionVehiculosDTO.FechaSalidaVehiculoM = Convert.ToDateTime(dr["FechaSalidaVehiculoM"]).ToString("yyy-MM-dd");
                        mantReparacionVehiculosDTO.RequerimientoRepuesto = dr["RequerimientoRepuesto"].ToString();
                        mantReparacionVehiculosDTO.CostoRepuestos = Convert.ToDecimal(dr["CostoRepuestos"]);
                        mantReparacionVehiculosDTO.OrdenCompraServicio = dr["OrdenCompraServicio"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return mantReparacionVehiculosDTO;
        }

        public string ActualizaFormato(MantenimientoReparacionVehiculosDTO mantReparacionVehiculosDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_MantenimientoReparacionVehiculoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MantenimientoReparacionVehiculoId", SqlDbType.Int);
                    cmd.Parameters["@MantenimientoReparacionVehiculoId"].Value = mantReparacionVehiculosDTO.MantenimientoReparacionVehiculoId;

                    cmd.Parameters.Add("@PlacaVehiculoMantenimiento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@PlacaVehiculoMantenimiento"].Value = mantReparacionVehiculosDTO.PlacaVehiculoMantenimiento;

                    cmd.Parameters.Add("@FechaIngresoMantenimiento", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoMantenimiento"].Value = mantReparacionVehiculosDTO.FechaIngresoMantenimiento;

                    cmd.Parameters.Add("@ClasificacionFlotaVehiculoM", SqlDbType.VarChar, 20);
                    cmd.Parameters["@ClasificacionFlotaVehiculoM"].Value = mantReparacionVehiculosDTO.ClasificacionFlotaVehiculoM;

                    cmd.Parameters.Add("@CodigoMarcaVehiculo", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoMarcaVehiculo"].Value = mantReparacionVehiculosDTO.CodigoMarcaVehiculo;

                    cmd.Parameters.Add("@AnioFabricacionVehiculoM", SqlDbType.Int);
                    cmd.Parameters["@AnioFabricacionVehiculoM"].Value = mantReparacionVehiculosDTO.AnioFabricacionVehiculoM;

                    cmd.Parameters.Add("@KilometrosVehiculoM", SqlDbType.Int);
                    cmd.Parameters["@KilometrosVehiculoM"].Value = mantReparacionVehiculosDTO.KilometrosVehiculoM;

                    cmd.Parameters.Add("@DependenciaVehiculoM", SqlDbType.VarChar, 25);
                    cmd.Parameters["@DependenciaVehiculoM"].Value = mantReparacionVehiculosDTO.DependenciaVehiculoM;

                    cmd.Parameters.Add("@MotivoServicioVehiculo", SqlDbType.VarChar, 15);
                    cmd.Parameters["@MotivoServicioVehiculo"].Value = mantReparacionVehiculosDTO.MotivoServicioVehiculo;

                    cmd.Parameters.Add("@FechaSalidaVehiculoM", SqlDbType.VarChar, 50);
                    cmd.Parameters["@FechaSalidaVehiculoM"].Value = mantReparacionVehiculosDTO.FechaSalidaVehiculoM;

                    cmd.Parameters.Add("@RequerimientoRepuesto", SqlDbType.VarChar, 10);
                    cmd.Parameters["@RequerimientoRepuesto"].Value = mantReparacionVehiculosDTO.RequerimientoRepuesto;

                    cmd.Parameters.Add("@CostoRepuestos", SqlDbType.Decimal);
                    cmd.Parameters["@CostoRepuestos"].Value = mantReparacionVehiculosDTO.CostoRepuestos;

                    cmd.Parameters.Add("@OrdenCompraServicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@OrdenCompraServicio"].Value = mantReparacionVehiculosDTO.OrdenCompraServicio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = mantReparacionVehiculosDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(MantenimientoReparacionVehiculosDTO mantenimientoReparacionVehiculosDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MantenimientoReparacionVehiculoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MantenimientoReparacionVehiculoId", SqlDbType.Int);
                    cmd.Parameters["@MantenimientoReparacionVehiculoId"].Value= mantenimientoReparacionVehiculosDTO.MantenimientoReparacionVehiculoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = mantenimientoReparacionVehiculosDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(MantenimientoReparacionVehiculosDTO mantenimientoReparacionVehiculosDTO)
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
                    cmd.Parameters["@Formato"].Value = "MantenimientoReparacionVehiculo";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = mantenimientoReparacionVehiculosDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = mantenimientoReparacionVehiculosDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_MantenimientoReparacionVehiculoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MantenimientoReparacionVehiculo", SqlDbType.Structured);
                    cmd.Parameters["@MantenimientoReparacionVehiculo"].TypeName = "Formato.MantenimientoReparacionVehiculo";
                    cmd.Parameters["@MantenimientoReparacionVehiculo"].Value = datos;

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
