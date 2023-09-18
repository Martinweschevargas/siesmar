using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dibinfrater;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dibinfrater
{
    public class MantenimientoGeneralDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<MantenimientoGeneralDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<MantenimientoGeneralDTO> lista = new List<MantenimientoGeneralDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_MantenimientoGeneralListar", conexion);
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
                        lista.Add(new MantenimientoGeneralDTO()
                        {
                            MantenimientoGeneralId = Convert.ToInt32(dr["MantenimientoGeneralId"]),
                            SolicitudMantenimiento = dr["SolicitudMantenimiento"].ToString(),
                            DescAreaDiperadmon = dr["DescAreaDiperadmon"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            EstadoSolicitud = dr["EstadoSolicitud"].ToString(),
                            DescTipoMantenimiento = dr["DescTipoMantenimiento"].ToString(),
                            FechaInicioMantenimiento = (dr["FechaInicioMantenimiento"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTerminoMantenimiento = (dr["FechaTerminoMantenimiento"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(MantenimientoGeneralDTO mantenimientoGeneralDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MantenimientoGeneralRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SolicitudMantenimiento", SqlDbType.VarChar,10);
                    cmd.Parameters["@SolicitudMantenimiento"].Value = mantenimientoGeneralDTO.SolicitudMantenimiento;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = mantenimientoGeneralDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = mantenimientoGeneralDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@EstadoSolicitud", SqlDbType.VarChar,50);
                    cmd.Parameters["@EstadoSolicitud"].Value = mantenimientoGeneralDTO.EstadoSolicitud;

                    cmd.Parameters.Add("@CodigoTipoMantenimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoMantenimiento"].Value = mantenimientoGeneralDTO.CodigoTipoMantenimiento;

                    cmd.Parameters.Add("@FechaInicioMantenimiento", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioMantenimiento"].Value = mantenimientoGeneralDTO.FechaInicioMantenimiento;

                    cmd.Parameters.Add("@FechaTerminoMantenimiento", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoMantenimiento"].Value = mantenimientoGeneralDTO.FechaTerminoMantenimiento;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = mantenimientoGeneralDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = mantenimientoGeneralDTO.UsuarioIngresoRegistro;

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

        public MantenimientoGeneralDTO BuscarFormato(int Codigo)
        {
            MantenimientoGeneralDTO mantenimientoGeneralDTO = new MantenimientoGeneralDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MantenimientoGeneralEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MantenimientoGeneralId", SqlDbType.Int);
                    cmd.Parameters["@MantenimientoGeneralId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        mantenimientoGeneralDTO.MantenimientoGeneralId = Convert.ToInt32(dr["MantenimientoGeneralId"]);
                        mantenimientoGeneralDTO.SolicitudMantenimiento = dr["SolicitudMantenimiento"].ToString();
                        mantenimientoGeneralDTO.CodigoAreaDiperadmon = dr["CodigoAreaDiperadmon"].ToString();
                        mantenimientoGeneralDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        mantenimientoGeneralDTO.EstadoSolicitud = dr["EstadoSolicitud"].ToString();
                        mantenimientoGeneralDTO.CodigoTipoMantenimiento = dr["CodigoTipoMantenimiento"].ToString();
                        mantenimientoGeneralDTO.FechaInicioMantenimiento = Convert.ToDateTime(dr["FechaInicioMantenimiento"]).ToString("yyy-MM-dd");
                        mantenimientoGeneralDTO.FechaTerminoMantenimiento = Convert.ToDateTime(dr["FechaTerminoMantenimiento"]).ToString("yyy-MM-dd"); 
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return mantenimientoGeneralDTO;
        }

        public string ActualizaFormato(MantenimientoGeneralDTO mantenimientoGeneralDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_MantenimientoGeneralActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@MantenimientoGeneralId", SqlDbType.Int);
                    cmd.Parameters["@MantenimientoGeneralId"].Value = mantenimientoGeneralDTO.MantenimientoGeneralId;

                    cmd.Parameters.Add("@SolicitudMantenimiento", SqlDbType.VarChar,10);
                    cmd.Parameters["@SolicitudMantenimiento"].Value = mantenimientoGeneralDTO.SolicitudMantenimiento;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = mantenimientoGeneralDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = mantenimientoGeneralDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@EstadoSolicitud", SqlDbType.VarChar,50);
                    cmd.Parameters["@EstadoSolicitud"].Value = mantenimientoGeneralDTO.EstadoSolicitud;

                    cmd.Parameters.Add("@CodigoTipoMantenimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoMantenimiento"].Value = mantenimientoGeneralDTO.CodigoTipoMantenimiento;

                    cmd.Parameters.Add("@FechaInicioMantenimiento", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioMantenimiento"].Value = mantenimientoGeneralDTO.FechaInicioMantenimiento;

                    cmd.Parameters.Add("@FechaTerminoMantenimiento", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoMantenimiento"].Value = mantenimientoGeneralDTO.FechaTerminoMantenimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = mantenimientoGeneralDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(MantenimientoGeneralDTO mantenimientoGeneralDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MantenimientoGeneralEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MantenimientoGeneralId", SqlDbType.Int);
                    cmd.Parameters["@MantenimientoGeneralId"].Value = mantenimientoGeneralDTO.MantenimientoGeneralId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = mantenimientoGeneralDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(MantenimientoGeneralDTO mantenimientoGeneralDTO)
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
                    cmd.Parameters["@Formato"].Value = "MantenimientoGeneral";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = mantenimientoGeneralDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = mantenimientoGeneralDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_MantenimientoGeneralRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MantenimientoGeneral", SqlDbType.Structured);
                    cmd.Parameters["@MantenimientoGeneral"].TypeName = "Formato.MantenimientoGeneral";
                    cmd.Parameters["@MantenimientoGeneral"].Value = datos;

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
