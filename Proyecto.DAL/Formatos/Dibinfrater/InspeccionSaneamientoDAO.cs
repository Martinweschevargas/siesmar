using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dibinfrater;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dibinfrater
{
    public class InspeccionSaneamientoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<InspeccionSaneamientoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<InspeccionSaneamientoDTO> lista = new List<InspeccionSaneamientoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_InspeccionSaneamientoListar", conexion);
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
                        lista.Add(new InspeccionSaneamientoDTO()
                        {
                            InspeccionSaneamientoId = Convert.ToInt32(dr["InspeccionSaneamientoId"]),
                            SolicitudInspeccion = dr["SolicitudInspeccion"].ToString(),
                            DescAreaDiperadmon = dr["DescAreaDiperadmon"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            EstadoSolicitud = dr["EstadoSolicitud"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            DescSituacionLegal = dr["DescSituacionLegal"].ToString(),
                            AreaM2 = Convert.ToInt32(dr["AreaM2"]),
                            FechaInspeccion = (dr["FechaInspeccion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(InspeccionSaneamientoDTO inspeccionSaneamientoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InspeccionSaneamientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SolicitudInspeccion", SqlDbType.VarChar,10);
                    cmd.Parameters["@SolicitudInspeccion"].Value = inspeccionSaneamientoDTO.SolicitudInspeccion;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = inspeccionSaneamientoDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = inspeccionSaneamientoDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@EstadoSolicitud", SqlDbType.VarChar,50);
                    cmd.Parameters["@EstadoSolicitud"].Value = inspeccionSaneamientoDTO.EstadoSolicitud;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = inspeccionSaneamientoDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CodigoSituacionLegal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSituacionLegal"].Value = inspeccionSaneamientoDTO.CodigoSituacionLegal;

                    cmd.Parameters.Add("@AreaM2", SqlDbType.Int);
                    cmd.Parameters["@AreaM2"].Value = inspeccionSaneamientoDTO.AreaM2;

                    cmd.Parameters.Add("@FechaInspeccion", SqlDbType.Date);
                    cmd.Parameters["@FechaInspeccion"].Value = inspeccionSaneamientoDTO.FechaInspeccion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = inspeccionSaneamientoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inspeccionSaneamientoDTO.UsuarioIngresoRegistro;

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

        public InspeccionSaneamientoDTO BuscarFormato(int Codigo)
        {
            InspeccionSaneamientoDTO inspeccionSaneamientoDTO = new InspeccionSaneamientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InspeccionSaneamientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InspeccionSaneamientoId", SqlDbType.Int);
                    cmd.Parameters["@InspeccionSaneamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        inspeccionSaneamientoDTO.InspeccionSaneamientoId = Convert.ToInt32(dr["InspeccionSaneamientoId"]);
                        inspeccionSaneamientoDTO.SolicitudInspeccion = dr["SolicitudInspeccion"].ToString();
                        inspeccionSaneamientoDTO.CodigoAreaDiperadmon =  dr["CodigoAreasDiperadmon"].ToString();
                        inspeccionSaneamientoDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        inspeccionSaneamientoDTO.EstadoSolicitud = dr["EstadoSolicitud"].ToString();
                        inspeccionSaneamientoDTO.DistritoUbigeo = dr["DistritoUbigeo"].ToString();
                        inspeccionSaneamientoDTO.CodigoSituacionLegal = dr["CodigoSituacionLegal"].ToString();
                        inspeccionSaneamientoDTO.AreaM2 = Convert.ToInt32(dr["AreaM2"]);
                        inspeccionSaneamientoDTO.FechaInspeccion = Convert.ToDateTime(dr["FechaInspeccion"]).ToString("yyy-MM-dd"); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return inspeccionSaneamientoDTO;
        }

        public string ActualizaFormato(InspeccionSaneamientoDTO inspeccionSaneamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_InspeccionSaneamientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@InspeccionSaneamientoId", SqlDbType.Int);
                    cmd.Parameters["@InspeccionSaneamientoId"].Value = inspeccionSaneamientoDTO.InspeccionSaneamientoId;

                    cmd.Parameters.Add("@SolicitudInspeccion", SqlDbType.VarChar,10);
                    cmd.Parameters["@SolicitudInspeccion"].Value = inspeccionSaneamientoDTO.SolicitudInspeccion;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = inspeccionSaneamientoDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = inspeccionSaneamientoDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@EstadoSolicitud", SqlDbType.VarChar,50);
                    cmd.Parameters["@EstadoSolicitud"].Value = inspeccionSaneamientoDTO.EstadoSolicitud;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = inspeccionSaneamientoDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CodigoSituacionLegal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSituacionLegal"].Value = inspeccionSaneamientoDTO.CodigoSituacionLegal;

                    cmd.Parameters.Add("@AreaM2", SqlDbType.Int);
                    cmd.Parameters["@AreaM2"].Value = inspeccionSaneamientoDTO.AreaM2;

                    cmd.Parameters.Add("@FechaInspeccion", SqlDbType.Date);
                    cmd.Parameters["@FechaInspeccion"].Value = inspeccionSaneamientoDTO.FechaInspeccion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inspeccionSaneamientoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(InspeccionSaneamientoDTO inspeccionSaneamientoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InspeccionSaneamientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InspeccionSaneamientoId", SqlDbType.Int);
                    cmd.Parameters["@InspeccionSaneamientoId"].Value = inspeccionSaneamientoDTO.InspeccionSaneamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inspeccionSaneamientoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(InspeccionSaneamientoDTO inspeccionSaneamientoDTO)
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
                    cmd.Parameters["@Formato"].Value = "InspeccionSaneamiento";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = inspeccionSaneamientoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inspeccionSaneamientoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_InspeccionSaneamientoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InspeccionSaneamiento", SqlDbType.Structured);
                    cmd.Parameters["@InspeccionSaneamiento"].TypeName = "Formato.InspeccionSaneamiento";
                    cmd.Parameters["@InspeccionSaneamiento"].Value = datos;

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
