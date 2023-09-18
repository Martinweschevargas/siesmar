using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comzodos;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comzodos
{
    public class ServicioDispositivoSeguridadPrestadoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ServicioDispositivoSeguridadPrestadoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ServicioDispositivoSeguridadPrestadoDTO> lista = new List<ServicioDispositivoSeguridadPrestadoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ServicioDispositivoSeguridadPrestadoListar", conexion);
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
                        lista.Add(new ServicioDispositivoSeguridadPrestadoDTO()
                        {
                            ServicioDispositivoSeguridadPrestadoId = Convert.ToInt32(dr["ServicioDispositivoSeguridadPrestadoId"]),
                            FechaSolicitud = (dr["FechaSolicitud"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            DescDependecia = dr["DescDependecia"].ToString(),
                            FechaHoraInicio = (dr["FechaHoraInicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaHoraTermino = (dr["FechaHoraTermino"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            EfectivoParticipante = Convert.ToInt32(dr["EfectivoParticipante"]),
                            Lugar = dr["Lugar"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            ObservacionServicioDispositivo = dr["ObservacionServicioDispositivo"].ToString(),
                            ComisionPorMes = Convert.ToInt32(dr["ComisionPorMes"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ServicioDispositivoSeguridadPrestadoDTO servicioDispositivoSeguridadPrestadoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioDispositivoSeguridadPrestadoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaSolicitud"].Value = servicioDispositivoSeguridadPrestadoDTO.FechaSolicitud;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = servicioDispositivoSeguridadPrestadoDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = servicioDispositivoSeguridadPrestadoDTO.CodigoDependencia;

                    cmd.Parameters.Add("@FechaHoraInicio", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraInicio"].Value = servicioDispositivoSeguridadPrestadoDTO.FechaHoraInicio;

                    cmd.Parameters.Add("@FechaHoraTermino", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraTermino"].Value = servicioDispositivoSeguridadPrestadoDTO.FechaHoraTermino;

                    cmd.Parameters.Add("@EfectivoParticipante", SqlDbType.Int);
                    cmd.Parameters["@EfectivoParticipante"].Value = servicioDispositivoSeguridadPrestadoDTO.EfectivoParticipante;

                    cmd.Parameters.Add("@Lugar", SqlDbType.VarChar,260);
                    cmd.Parameters["@Lugar"].Value = servicioDispositivoSeguridadPrestadoDTO.Lugar;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = servicioDispositivoSeguridadPrestadoDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@ObservacionServicioDispositivo", SqlDbType.VarChar,500);
                    cmd.Parameters["@ObservacionServicioDispositivo"].Value = servicioDispositivoSeguridadPrestadoDTO.ObservacionServicioDispositivo;

                    cmd.Parameters.Add("@ComisionPorMes", SqlDbType.Int);
                    cmd.Parameters["@ComisionPorMes"].Value = servicioDispositivoSeguridadPrestadoDTO.ComisionPorMes;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = servicioDispositivoSeguridadPrestadoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioDispositivoSeguridadPrestadoDTO.UsuarioIngresoRegistro;

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

        public ServicioDispositivoSeguridadPrestadoDTO BuscarFormato(int Codigo)
        {
            ServicioDispositivoSeguridadPrestadoDTO servicioDispositivoSeguridadPrestadoDTO = new ServicioDispositivoSeguridadPrestadoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioDispositivoSeguridadPrestadoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioDispositivoSeguridadPrestadoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioDispositivoSeguridadPrestadoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        servicioDispositivoSeguridadPrestadoDTO.ServicioDispositivoSeguridadPrestadoId = Convert.ToInt32(dr["ServicioDispositivoSeguridadPrestadoId"]);
                        servicioDispositivoSeguridadPrestadoDTO.FechaSolicitud = Convert.ToDateTime(dr["FechaSolicitud"]).ToString("yyy-MM-dd");
                        servicioDispositivoSeguridadPrestadoDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        servicioDispositivoSeguridadPrestadoDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        servicioDispositivoSeguridadPrestadoDTO.FechaHoraInicio = Convert.ToDateTime(dr["FechaHoraInicio"]).ToString("yyy-MM-dd HH:mm:ss");
                        servicioDispositivoSeguridadPrestadoDTO.FechaHoraTermino = Convert.ToDateTime(dr["FechaHoraTermino"]).ToString("yyy-MM-dd HH:mm:ss");
                        servicioDispositivoSeguridadPrestadoDTO.EfectivoParticipante = Convert.ToInt32(dr["EfectivoParticipante"]);
                        servicioDispositivoSeguridadPrestadoDTO.Lugar = dr["Lugar"].ToString();
                        servicioDispositivoSeguridadPrestadoDTO.DistritoUbigeo = dr["DistritoUbigeo"].ToString();
                        servicioDispositivoSeguridadPrestadoDTO.ObservacionServicioDispositivo = dr["ObservacionServicioDispositivo"].ToString();
                        servicioDispositivoSeguridadPrestadoDTO.ComisionPorMes = Convert.ToInt32(dr["ComisionPorMes"]); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return servicioDispositivoSeguridadPrestadoDTO;
        }

        public string ActualizaFormato(ServicioDispositivoSeguridadPrestadoDTO servicioDispositivoSeguridadPrestadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ServicioDispositivoSeguridadPrestadoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ServicioDispositivoSeguridadPrestadoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioDispositivoSeguridadPrestadoId"].Value = servicioDispositivoSeguridadPrestadoDTO.ServicioDispositivoSeguridadPrestadoId;

                    cmd.Parameters.Add("@FechaSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaSolicitud"].Value = servicioDispositivoSeguridadPrestadoDTO.FechaSolicitud;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = servicioDispositivoSeguridadPrestadoDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = servicioDispositivoSeguridadPrestadoDTO.CodigoDependencia;

                    cmd.Parameters.Add("@FechaHoraInicio", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraInicio"].Value = servicioDispositivoSeguridadPrestadoDTO.FechaHoraInicio;

                    cmd.Parameters.Add("@FechaHoraTermino", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraTermino"].Value = servicioDispositivoSeguridadPrestadoDTO.FechaHoraTermino;

                    cmd.Parameters.Add("@EfectivoParticipante", SqlDbType.Int);
                    cmd.Parameters["@EfectivoParticipante"].Value = servicioDispositivoSeguridadPrestadoDTO.EfectivoParticipante;

                    cmd.Parameters.Add("@Lugar", SqlDbType.VarChar,260);
                    cmd.Parameters["@Lugar"].Value = servicioDispositivoSeguridadPrestadoDTO.Lugar;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = servicioDispositivoSeguridadPrestadoDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@ObservacionServicioDispositivo", SqlDbType.VarChar,500);
                    cmd.Parameters["@ObservacionServicioDispositivo"].Value = servicioDispositivoSeguridadPrestadoDTO.ObservacionServicioDispositivo;

                    cmd.Parameters.Add("@ComisionPorMes", SqlDbType.Int);
                    cmd.Parameters["@ComisionPorMes"].Value = servicioDispositivoSeguridadPrestadoDTO.ComisionPorMes;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioDispositivoSeguridadPrestadoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ServicioDispositivoSeguridadPrestadoDTO servicioDispositivoSeguridadPrestadoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioDispositivoSeguridadPrestadoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioDispositivoSeguridadPrestadoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioDispositivoSeguridadPrestadoId"].Value = servicioDispositivoSeguridadPrestadoDTO.ServicioDispositivoSeguridadPrestadoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioDispositivoSeguridadPrestadoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ServicioDispositivoSeguridadPrestadoDTO servicioDispositivoSeguridadPrestadoDTO)
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
                    cmd.Parameters["@Formato"].Value = "ServicioDispositivoSeguridadPrestado";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = servicioDispositivoSeguridadPrestadoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioDispositivoSeguridadPrestadoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ServicioDispositivoSeguridadPrestadoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioDispositivoSeguridadPrestado", SqlDbType.Structured);
                    cmd.Parameters["@ServicioDispositivoSeguridadPrestado"].TypeName = "Formato.ServicioDispositivoSeguridadPrestado";
                    cmd.Parameters["@ServicioDispositivoSeguridadPrestado"].Value = datos;

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
