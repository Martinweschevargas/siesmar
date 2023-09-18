using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dibinfrater;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dibinfrater
{
    public class InspeccionObraServicioPrestadoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<InspeccionObraServicioPrestadoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<InspeccionObraServicioPrestadoDTO> lista = new List<InspeccionObraServicioPrestadoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_InspeccionObraServicioPrestadoListar", conexion);
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
                        lista.Add(new InspeccionObraServicioPrestadoDTO()
                        {
                            InspeccionObraServicioPrestadoId = Convert.ToInt32(dr["InspeccionObraServicioPrestadoId"]),
                            IdentificacionSolicitud = dr["IdentificacionSolicitud"].ToString(),
                            NombreObra = dr["NombreObra"].ToString(),
                            DescAreaDiperadmon = dr["DescAreaDiperadmon"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            EstadoSolicitud = dr["EstadoSolicitud"].ToString(),
                            IdentificacionContrato = dr["IdentificacionContrato"].ToString(),
                            DescTipoObraServicio = dr["DescTipoObraServicio"].ToString(),
                            DescTipoProceso = dr["DescTipoProceso"].ToString(),
                            MontoContrato = Convert.ToDecimal(dr["MontoContrato"]),
                            FechaInicioObraServicio = (dr["FechaInicioObraServicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTerminoEstimada = (dr["FechaTerminoEstimada"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            PorcentajeAvanceFisico = Convert.ToInt32(dr["PorcentajeAvanceFisico"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(InspeccionObraServicioPrestadoDTO inspeccionObraServicioPrestadoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InspeccionObraServicioPrestadoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IdentificacionSolicitud", SqlDbType.VarChar,10);
                    cmd.Parameters["@IdentificacionSolicitud"].Value = inspeccionObraServicioPrestadoDTO.IdentificacionSolicitud;

                    cmd.Parameters.Add("@NombreObra", SqlDbType.VarChar,500);
                    cmd.Parameters["@NombreObra"].Value = inspeccionObraServicioPrestadoDTO.NombreObra;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = inspeccionObraServicioPrestadoDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = inspeccionObraServicioPrestadoDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@EstadoSolicitud", SqlDbType.VarChar,50);
                    cmd.Parameters["@EstadoSolicitud"].Value = inspeccionObraServicioPrestadoDTO.EstadoSolicitud;

                    cmd.Parameters.Add("@IdentificacionContrato", SqlDbType.VarChar,20);
                    cmd.Parameters["@IdentificacionContrato"].Value = inspeccionObraServicioPrestadoDTO.IdentificacionContrato;

                    cmd.Parameters.Add("@CodigoTipoObraServicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoObraServicio"].Value = inspeccionObraServicioPrestadoDTO.CodigoTipoObraServicio;

                    cmd.Parameters.Add("@CodigoTipoProceso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoProceso"].Value = inspeccionObraServicioPrestadoDTO.CodigoTipoProceso;

                    cmd.Parameters.Add("@MontoContrato", SqlDbType.Decimal);
                    cmd.Parameters["@MontoContrato"].Value = inspeccionObraServicioPrestadoDTO.MontoContrato;

                    cmd.Parameters.Add("@FechaInicioObraServicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioObraServicio"].Value = inspeccionObraServicioPrestadoDTO.FechaInicioObraServicio;

                    cmd.Parameters.Add("@FechaTerminoEstimada", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoEstimada"].Value = inspeccionObraServicioPrestadoDTO.FechaTerminoEstimada;

                    cmd.Parameters.Add("@PorcentajeAvanceFisico", SqlDbType.Int);
                    cmd.Parameters["@PorcentajeAvanceFisico"].Value = inspeccionObraServicioPrestadoDTO.PorcentajeAvanceFisico;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = inspeccionObraServicioPrestadoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inspeccionObraServicioPrestadoDTO.UsuarioIngresoRegistro;

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

        public InspeccionObraServicioPrestadoDTO BuscarFormato(int Codigo)
        {
            InspeccionObraServicioPrestadoDTO inspeccionObraServicioPrestadoDTO = new InspeccionObraServicioPrestadoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InspeccionObraServicioPrestadoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InspeccionObraServicioPrestadoId", SqlDbType.Int);
                    cmd.Parameters["@InspeccionObraServicioPrestadoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        inspeccionObraServicioPrestadoDTO.InspeccionObraServicioPrestadoId = Convert.ToInt32(dr["InspeccionObraServicioPrestadoId"]);
                        inspeccionObraServicioPrestadoDTO.IdentificacionSolicitud = dr["IdentificacionSolicitud"].ToString();
                        inspeccionObraServicioPrestadoDTO.NombreObra = dr["NombreObra"].ToString();
                        inspeccionObraServicioPrestadoDTO.CodigoAreaDiperadmon = dr["CodigoAreaDiperadmon"].ToString();
                        inspeccionObraServicioPrestadoDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        inspeccionObraServicioPrestadoDTO.EstadoSolicitud = dr["EstadoSolicitud"].ToString();
                        inspeccionObraServicioPrestadoDTO.IdentificacionContrato = dr["IdentificacionContrato"].ToString();
                        inspeccionObraServicioPrestadoDTO.CodigoTipoObraServicio = dr["CodigoTipoObraServicio"].ToString();
                        inspeccionObraServicioPrestadoDTO.CodigoTipoProceso = dr["CodigoTipoProceso"].ToString();
                        inspeccionObraServicioPrestadoDTO.MontoContrato = Convert.ToDecimal(dr["MontoContrato"]);
                        inspeccionObraServicioPrestadoDTO.FechaInicioObraServicio = Convert.ToDateTime(dr["FechaInicioObraServicio"]).ToString("yyy-MM-dd");
                        inspeccionObraServicioPrestadoDTO.FechaTerminoEstimada = Convert.ToDateTime(dr["FechaTerminoEstimada"]).ToString("yyy-MM-dd");
                        inspeccionObraServicioPrestadoDTO.PorcentajeAvanceFisico = Convert.ToInt32(dr["PorcentajeAvanceFisico"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return inspeccionObraServicioPrestadoDTO;
        }

        public string ActualizaFormato(InspeccionObraServicioPrestadoDTO inspeccionObraServicioPrestadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_InspeccionObraServicioPrestadoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@InspeccionObraServicioPrestadoId", SqlDbType.Int);
                    cmd.Parameters["@InspeccionObraServicioPrestadoId"].Value = inspeccionObraServicioPrestadoDTO.InspeccionObraServicioPrestadoId;

                    cmd.Parameters.Add("@IdentificacionSolicitud", SqlDbType.VarChar, 10);
                    cmd.Parameters["@IdentificacionSolicitud"].Value = inspeccionObraServicioPrestadoDTO.IdentificacionSolicitud;

                    cmd.Parameters.Add("@NombreObra", SqlDbType.VarChar, 500);
                    cmd.Parameters["@NombreObra"].Value = inspeccionObraServicioPrestadoDTO.NombreObra;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = inspeccionObraServicioPrestadoDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = inspeccionObraServicioPrestadoDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@EstadoSolicitud", SqlDbType.VarChar, 50);
                    cmd.Parameters["@EstadoSolicitud"].Value = inspeccionObraServicioPrestadoDTO.EstadoSolicitud;

                    cmd.Parameters.Add("@IdentificacionContrato", SqlDbType.VarChar, 20);
                    cmd.Parameters["@IdentificacionContrato"].Value = inspeccionObraServicioPrestadoDTO.IdentificacionContrato;

                    cmd.Parameters.Add("@CodigoTipoObraServicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoObraServicio"].Value = inspeccionObraServicioPrestadoDTO.CodigoTipoObraServicio;

                    cmd.Parameters.Add("@CodigoTipoProceso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoProceso"].Value = inspeccionObraServicioPrestadoDTO.CodigoTipoProceso;

                    cmd.Parameters.Add("@MontoContrato", SqlDbType.Decimal);
                    cmd.Parameters["@MontoContrato"].Value = inspeccionObraServicioPrestadoDTO.MontoContrato;

                    cmd.Parameters.Add("@FechaInicioObraServicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioObraServicio"].Value = inspeccionObraServicioPrestadoDTO.FechaInicioObraServicio;

                    cmd.Parameters.Add("@FechaTerminoEstimada", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoEstimada"].Value = inspeccionObraServicioPrestadoDTO.FechaTerminoEstimada;

                    cmd.Parameters.Add("@PorcentajeAvanceFisico", SqlDbType.Int);
                    cmd.Parameters["@PorcentajeAvanceFisico"].Value = inspeccionObraServicioPrestadoDTO.PorcentajeAvanceFisico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inspeccionObraServicioPrestadoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(InspeccionObraServicioPrestadoDTO inspeccionObraServicioPrestadoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InspeccionObraServicioPrestadoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InspeccionObraServicioPrestadoId", SqlDbType.Int);
                    cmd.Parameters["@InspeccionObraServicioPrestadoId"].Value = inspeccionObraServicioPrestadoDTO.InspeccionObraServicioPrestadoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inspeccionObraServicioPrestadoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(InspeccionObraServicioPrestadoDTO inspeccionObraServicioPrestadoDTO)
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
                    cmd.Parameters["@Formato"].Value = "InspeccionObraServicioPrestado";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = inspeccionObraServicioPrestadoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inspeccionObraServicioPrestadoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_InspeccionObraServicioPrestadoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InspeccionObraServicioPrestado", SqlDbType.Structured);
                    cmd.Parameters["@InspeccionObraServicioPrestado"].TypeName = "Formato.InspeccionObraServicioPrestado";
                    cmd.Parameters["@InspeccionObraServicioPrestado"].Value = datos;

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
