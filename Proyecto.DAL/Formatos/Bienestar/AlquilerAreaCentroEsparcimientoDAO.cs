using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Bienestar
{
    public class AlquilerAreaCentroEsparcimientoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlquilerAreaCentroEsparcimientoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)

        {
            List<AlquilerAreaCentroEsparcimientoDTO> lista = new List<AlquilerAreaCentroEsparcimientoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlquilerAreaCentroEsparcimientoListar", conexion);
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
                        lista.Add(new AlquilerAreaCentroEsparcimientoDTO()
                        {
                            AlquilerAreaCentroEsparcimientoId = Convert.ToInt32(dr["AlquilerAreaCentroEsparcimientoId"]),
                            FechaAlquiler = (dr["FechaAlquiler"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DNIUsuario = dr["DNIUsuario"].ToString(),
                            DescUsuarioAlquilerCentroEsparcimiento = dr["DescUsuarioAlquilerCentroEsparcimiento"].ToString(),
                            DescClubEsparcimiento = dr["DescClubEsparcimiento"].ToString(),
                            DescAreaSalonClubEsparcimiento = dr["DescAreaSalonClubEsparcimiento"].ToString(),
                            DescTipoEvento = dr["DescTipoEvento"].ToString(),
                            HoraInicio = dr["HoraInicio"].ToString(),
                            HoraTermino = dr["HoraTermino"].ToString(),
                            NumeroHoras = Convert.ToInt32(dr["NumeroHoras"]),
                            NumeroInvitados = Convert.ToInt32(dr["NumeroInvitados"]),
                            MontoFacturado = Convert.ToDecimal(dr["MontoFacturado"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public List<AlquilerAreaCentroEsparcimientoDTO> BienestarVisualizacionAlquilerAreaCentroEsparcimiento(int CargaId)
        {
            List<AlquilerAreaCentroEsparcimientoDTO> lista = new List<AlquilerAreaCentroEsparcimientoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_BienestarVisualizacionAlquilerAreaCentroEsparcimiento", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlquilerAreaCentroEsparcimientoDTO()
                        {
                            FechaAlquiler = dr["FechaSolicitudConvenio"].ToString(),
                            DNIUsuario = dr["DNISolicitante"].ToString(),
                            DescUsuarioAlquilerCentroEsparcimiento = dr["DescPersonalSolicitante"].ToString(),
                            DescClubEsparcimiento = dr["NivelEstudioConvenio"].ToString(),
                            DescAreaSalonClubEsparcimiento = dr["TipoEntidadAcademica"].ToString(),
                            DescTipoEvento = dr["DescInstitucionEducativaSuperior"].ToString(),
                            HoraInicio = dr["ResultadoSolicitud"].ToString(),
                            HoraTermino = dr["FechaResultadoSolicitud"].ToString(),
                            NumeroHoras = Convert.ToInt32(dr["NumeroHoras"]),
                            NumeroInvitados = Convert.ToInt32(dr["NumeroInvitados"]),
                            MontoFacturado = Convert.ToInt32(dr["MontoFacturado"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlquilerAreaCentroEsparcimientoDTO alquilerAreaCentroEsparcimientoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlquilerAreaCentroEsparcimientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaAlquiler", SqlDbType.Date);
                    cmd.Parameters["@FechaAlquiler"].Value = alquilerAreaCentroEsparcimientoDTO.FechaAlquiler;

                    cmd.Parameters.Add("@DNIUsuario", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIUsuario"].Value = alquilerAreaCentroEsparcimientoDTO.DNIUsuario;

                    cmd.Parameters.Add("@CodigoUsuarioAlquilerCentroEsparcimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUsuarioAlquilerCentroEsparcimiento"].Value = alquilerAreaCentroEsparcimientoDTO.CodigoUsuarioAlquilerCentroEsparcimiento;

                    cmd.Parameters.Add("@CodigoClubEsparcimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClubEsparcimiento"].Value = alquilerAreaCentroEsparcimientoDTO.CodigoClubEsparcimiento;

                    cmd.Parameters.Add("@CodigoAreaSalonClubEsparcimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaSalonClubEsparcimiento"].Value = alquilerAreaCentroEsparcimientoDTO.CodigoAreaSalonClubEsparcimiento;

                    cmd.Parameters.Add("@CodigoTipoEvento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoEvento"].Value = alquilerAreaCentroEsparcimientoDTO.CodigoTipoEvento;

                    cmd.Parameters.Add("@HoraInicio", SqlDbType.Time);
                    cmd.Parameters["@HoraInicio"].Value = alquilerAreaCentroEsparcimientoDTO.HoraInicio;

                    cmd.Parameters.Add("@HoraTermino", SqlDbType.Time);
                    cmd.Parameters["@HoraTermino"].Value = alquilerAreaCentroEsparcimientoDTO.HoraTermino;

                    cmd.Parameters.Add("@NumeroHoras", SqlDbType.Int);
                    cmd.Parameters["@NumeroHoras"].Value = alquilerAreaCentroEsparcimientoDTO.NumeroHoras;

                    cmd.Parameters.Add("@NumeroInvitados", SqlDbType.Int);
                    cmd.Parameters["@NumeroInvitados"].Value = alquilerAreaCentroEsparcimientoDTO.NumeroInvitados;
                    
                    cmd.Parameters.Add("@MontoFacturado", SqlDbType.Decimal);
                    cmd.Parameters["@MontoFacturado"].Value = alquilerAreaCentroEsparcimientoDTO.MontoFacturado;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alquilerAreaCentroEsparcimientoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alquilerAreaCentroEsparcimientoDTO.UsuarioIngresoRegistro;

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

        public AlquilerAreaCentroEsparcimientoDTO BuscarFormato(int Codigo)
        {
            AlquilerAreaCentroEsparcimientoDTO alquilerAreaCentroEsparcimientoDTO = new AlquilerAreaCentroEsparcimientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlquilerAreaCentroEsparcimientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlquilerAreaCentroEsparcimientoId", SqlDbType.Int);
                    cmd.Parameters["@AlquilerAreaCentroEsparcimientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        alquilerAreaCentroEsparcimientoDTO.AlquilerAreaCentroEsparcimientoId = Convert.ToInt32(dr["AlquilerAreaCentroEsparcimientoId"]);
                        alquilerAreaCentroEsparcimientoDTO.FechaAlquiler = Convert.ToDateTime(dr["FechaAlquiler"]).ToString("yyy-MM-dd");
                        alquilerAreaCentroEsparcimientoDTO.DNIUsuario = dr["DNIUsuario"].ToString();
                        alquilerAreaCentroEsparcimientoDTO.CodigoUsuarioAlquilerCentroEsparcimiento = dr["CodigoUsuarioAlquilerCentroEsparcimiento"].ToString();
                        alquilerAreaCentroEsparcimientoDTO.CodigoClubEsparcimiento = dr["CodigoClubEsparcimiento"].ToString();
                        alquilerAreaCentroEsparcimientoDTO.CodigoAreaSalonClubEsparcimiento = dr["CodigoAreaSalonClubEsparcimiento"].ToString();
                        alquilerAreaCentroEsparcimientoDTO.CodigoTipoEvento = dr["CodigoTipoEvento"].ToString();
                        alquilerAreaCentroEsparcimientoDTO.HoraInicio = dr["HoraInicio"].ToString();
                        alquilerAreaCentroEsparcimientoDTO.HoraTermino = dr["HoraTermino"].ToString();
                        alquilerAreaCentroEsparcimientoDTO.NumeroHoras = Convert.ToInt32(dr["NumeroHoras"]);
                        alquilerAreaCentroEsparcimientoDTO.NumeroInvitados = Convert.ToInt32(dr["NumeroInvitados"]); 
                        alquilerAreaCentroEsparcimientoDTO.MontoFacturado = Convert.ToDecimal(dr["MontoFacturado"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alquilerAreaCentroEsparcimientoDTO;
        }

        public string ActualizaFormato(AlquilerAreaCentroEsparcimientoDTO alquilerAreaCentroEsparcimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlquilerAreaCentroEsparcimientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AlquilerAreaCentroEsparcimientoId", SqlDbType.Int);
                    cmd.Parameters["@AlquilerAreaCentroEsparcimientoId"].Value = alquilerAreaCentroEsparcimientoDTO.AlquilerAreaCentroEsparcimientoId;

                    cmd.Parameters.Add("@FechaAlquiler", SqlDbType.Date);
                    cmd.Parameters["@FechaAlquiler"].Value = alquilerAreaCentroEsparcimientoDTO.FechaAlquiler;

                    cmd.Parameters.Add("@DNIUsuario", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIUsuario"].Value = alquilerAreaCentroEsparcimientoDTO.DNIUsuario;

                    cmd.Parameters.Add("@CodigoUsuarioAlquilerCentroEsparcimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUsuarioAlquilerCentroEsparcimiento"].Value = alquilerAreaCentroEsparcimientoDTO.CodigoUsuarioAlquilerCentroEsparcimiento;

                    cmd.Parameters.Add("@CodigoClubEsparcimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClubEsparcimiento"].Value = alquilerAreaCentroEsparcimientoDTO.CodigoClubEsparcimiento;

                    cmd.Parameters.Add("@CodigoAreaSalonClubEsparcimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaSalonClubEsparcimiento"].Value = alquilerAreaCentroEsparcimientoDTO.CodigoAreaSalonClubEsparcimiento;

                    cmd.Parameters.Add("@CodigoTipoEvento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoEvento"].Value = alquilerAreaCentroEsparcimientoDTO.CodigoTipoEvento;

                    cmd.Parameters.Add("@HoraInicio", SqlDbType.VarChar);
                    cmd.Parameters["@HoraInicio"].Value = alquilerAreaCentroEsparcimientoDTO.HoraInicio;

                    cmd.Parameters.Add("@HoraTermino", SqlDbType.VarChar);
                    cmd.Parameters["@HoraTermino"].Value = alquilerAreaCentroEsparcimientoDTO.HoraTermino;

                    cmd.Parameters.Add("@NumeroHoras", SqlDbType.Int);
                    cmd.Parameters["@NumeroHoras"].Value = alquilerAreaCentroEsparcimientoDTO.NumeroHoras;

                    cmd.Parameters.Add("@NumeroInvitados", SqlDbType.Int);
                    cmd.Parameters["@NumeroInvitados"].Value = alquilerAreaCentroEsparcimientoDTO.NumeroInvitados;

                    cmd.Parameters.Add("@MontoFacturado", SqlDbType.Decimal);
                    cmd.Parameters["@MontoFacturado"].Value = alquilerAreaCentroEsparcimientoDTO.MontoFacturado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alquilerAreaCentroEsparcimientoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlquilerAreaCentroEsparcimientoDTO alquilerAreaCentroEsparcimientoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlquilerAreaCentroEsparcimientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlquilerAreaCentroEsparcimientoId", SqlDbType.Int);
                    cmd.Parameters["@AlquilerAreaCentroEsparcimientoId"].Value = alquilerAreaCentroEsparcimientoDTO.AlquilerAreaCentroEsparcimientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alquilerAreaCentroEsparcimientoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(AlquilerAreaCentroEsparcimientoDTO alquilerAreaCentroEsparcimientoDTO)
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
                    cmd.Parameters["@Formato"].Value = "AlquilerAreaCentroEsparcimiento";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alquilerAreaCentroEsparcimientoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alquilerAreaCentroEsparcimientoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_AlquilerAreaCentroEsparcimientoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlquilerAreaCentroEsparcimiento", SqlDbType.Structured);
                    cmd.Parameters["@AlquilerAreaCentroEsparcimiento"].TypeName = "Formato.AlquilerAreaCentroEsparcimiento";
                    cmd.Parameters["@AlquilerAreaCentroEsparcimiento"].Value = datos;

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
