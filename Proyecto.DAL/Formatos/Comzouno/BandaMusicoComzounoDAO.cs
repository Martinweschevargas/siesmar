using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comzouno;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comzouno
{
    public class BandaMusicoComzounoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<BandaMusicoComzounoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<BandaMusicoComzounoDTO> lista = new List<BandaMusicoComzounoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_BandaMusicoComzounoListar", conexion);
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
                        lista.Add(new BandaMusicoComzounoDTO()
                        {
                            BandaMusicoComzounoId = Convert.ToInt32(dr["BandaMusicoComzounoId"]),
                            DescTipoComision = dr["DescTipoComision"].ToString(),
                            DescEvento = dr["DescEvento"].ToString(),
                            SolicitudDocumentoRef = dr["SolicitudDocumentoRef"].ToString(),
                            DescEntidadSolicitante = dr["DescEntidadSolicitante"].ToString(),
                            DescGrupoComisionado = dr["DescGrupoComisionado"].ToString(),
                            DescVestimentaUniforme = dr["DescVestimentaUniforme"].ToString(),
                            NombreEvento = dr["NombreEvento"].ToString(),
                            Lugar = dr["Lugar"].ToString(),
                            FechaHoraSalida = Convert.ToDateTime(dr["FechaHoraSalida"]).ToString("yyyy-MM-dd HH:mm:ss"),
                            FechaHoraInicio = Convert.ToDateTime(dr["FechaHoraInicio"]).ToString("yyyy-MM-dd HH:mm:ss"),
                            FechaHoraTermino = Convert.ToDateTime(dr["FechaHoraTermino"]).ToString("yyyy-MM-dd HH:mm:ss"),
                            RequerimientoMovilidad = dr["RequerimientoMovilidad"].ToString(),
                            Observacion = dr["Observacion"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(BandaMusicoComzounoDTO bandaMusicoComzounoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_BandaMusicoComzounoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoTipoComision", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoComision"].Value = bandaMusicoComzounoDTO.CodigoTipoComision;

                    cmd.Parameters.Add("@CodigoEvento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEvento"].Value = bandaMusicoComzounoDTO.CodigoEvento;

                    cmd.Parameters.Add("@SolicitudDocumentoRef", SqlDbType.VarChar,20);
                    cmd.Parameters["@SolicitudDocumentoRef"].Value = bandaMusicoComzounoDTO.SolicitudDocumentoRef;

                    cmd.Parameters.Add("@CodigoEntidadSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadSolicitante"].Value = bandaMusicoComzounoDTO.CodigoEntidadSolicitante;

                    cmd.Parameters.Add("@CodigoGrupoComisionado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGrupoComisionado"].Value = bandaMusicoComzounoDTO.CodigoGrupoComisionado;

                    cmd.Parameters.Add("@CodigoVestimentaUniforme", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoVestimentaUniforme"].Value = bandaMusicoComzounoDTO.CodigoVestimentaUniforme;

                    cmd.Parameters.Add("@NombreEvento", SqlDbType.VarChar,200);
                    cmd.Parameters["@NombreEvento"].Value = bandaMusicoComzounoDTO.NombreEvento;

                    cmd.Parameters.Add("@Lugar", SqlDbType.VarChar,200);
                    cmd.Parameters["@Lugar"].Value = bandaMusicoComzounoDTO.Lugar;

                    cmd.Parameters.Add("@FechaHoraSalida", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraSalida"].Value = bandaMusicoComzounoDTO.FechaHoraSalida;

                    cmd.Parameters.Add("@FechaHoraInicio", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraInicio"].Value = bandaMusicoComzounoDTO.FechaHoraInicio;

                    cmd.Parameters.Add("@FechaHoraTermino", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraTermino"].Value = bandaMusicoComzounoDTO.FechaHoraTermino;

                    cmd.Parameters.Add("@RequerimientoMovilidad", SqlDbType.VarChar,1);
                    cmd.Parameters["@RequerimientoMovilidad"].Value = bandaMusicoComzounoDTO.RequerimientoMovilidad;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observacion"].Value = bandaMusicoComzounoDTO.Observacion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = bandaMusicoComzounoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = bandaMusicoComzounoDTO.UsuarioIngresoRegistro;

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

        public BandaMusicoComzounoDTO BuscarFormato(int Codigo)
        {
            BandaMusicoComzounoDTO bandaMusicoComzounoDTO = new BandaMusicoComzounoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_BandaMusicoComzounoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BandaMusicoComzounoId", SqlDbType.Int);
                    cmd.Parameters["@BandaMusicoComzounoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        bandaMusicoComzounoDTO.BandaMusicoComzounoId = Convert.ToInt32(dr["BandaMusicoComzounoId"]);
                        bandaMusicoComzounoDTO.CodigoTipoComision = dr["CodigoTipoComision"].ToString();
                        bandaMusicoComzounoDTO.CodigoEvento = dr["CodigoEvento"].ToString();
                        bandaMusicoComzounoDTO.SolicitudDocumentoRef = dr["SolicitudDocumentoRef"].ToString();
                        bandaMusicoComzounoDTO.CodigoEntidadSolicitante = dr["CodigoEntidadSolicitante"].ToString();
                        bandaMusicoComzounoDTO.CodigoGrupoComisionado = dr["CodigoGrupoComisionado"].ToString();
                        bandaMusicoComzounoDTO.CodigoVestimentaUniforme = dr["CodigoVestimentaUniforme"].ToString();
                        bandaMusicoComzounoDTO.NombreEvento = dr["NombreEvento"].ToString();
                        bandaMusicoComzounoDTO.Lugar = dr["Lugar"].ToString();
                        bandaMusicoComzounoDTO.FechaHoraSalida = Convert.ToDateTime(dr["FechaHoraSalida"]).ToString("yyyy-MM-dd HH:mm:ss");
                        bandaMusicoComzounoDTO.FechaHoraInicio = Convert.ToDateTime(dr["FechaHoraInicio"]).ToString("yyyy-MM-dd HH:mm:ss");
                        bandaMusicoComzounoDTO.FechaHoraTermino = Convert.ToDateTime(dr["FechaHoraTermino"]).ToString("yyyy-MM-dd HH:mm:ss");
                        bandaMusicoComzounoDTO.RequerimientoMovilidad = dr["RequerimientoMovilidad"].ToString();
                        bandaMusicoComzounoDTO.Observacion = dr["Observacion"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return bandaMusicoComzounoDTO;
        }

        public string ActualizaFormato(BandaMusicoComzounoDTO bandaMusicoComzounoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_BandaMusicoComzounoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@BandaMusicoComzounoId", SqlDbType.Int);
                    cmd.Parameters["@BandaMusicoComzounoId"].Value = bandaMusicoComzounoDTO.BandaMusicoComzounoId;

                    cmd.Parameters.Add("@CodigoTipoComision", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoComision"].Value = bandaMusicoComzounoDTO.CodigoTipoComision;

                    cmd.Parameters.Add("@CodigoEvento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEvento"].Value = bandaMusicoComzounoDTO.CodigoEvento;

                    cmd.Parameters.Add("@SolicitudDocumentoRef", SqlDbType.VarChar, 20);
                    cmd.Parameters["@SolicitudDocumentoRef"].Value = bandaMusicoComzounoDTO.SolicitudDocumentoRef;

                    cmd.Parameters.Add("@CodigoEntidadSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadSolicitante"].Value = bandaMusicoComzounoDTO.CodigoEntidadSolicitante;

                    cmd.Parameters.Add("@CodigoGrupoComisionado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGrupoComisionado"].Value = bandaMusicoComzounoDTO.CodigoGrupoComisionado;

                    cmd.Parameters.Add("@CodigoVestimentaUniforme", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoVestimentaUniforme"].Value = bandaMusicoComzounoDTO.CodigoVestimentaUniforme;

                    cmd.Parameters.Add("@NombreEvento", SqlDbType.VarChar, 200);
                    cmd.Parameters["@NombreEvento"].Value = bandaMusicoComzounoDTO.NombreEvento;

                    cmd.Parameters.Add("@Lugar", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Lugar"].Value = bandaMusicoComzounoDTO.Lugar;

                    cmd.Parameters.Add("@FechaHoraSalida", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraSalida"].Value = bandaMusicoComzounoDTO.FechaHoraSalida;

                    cmd.Parameters.Add("@FechaHoraInicio", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraInicio"].Value = bandaMusicoComzounoDTO.FechaHoraInicio;

                    cmd.Parameters.Add("@FechaHoraTermino", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraTermino"].Value = bandaMusicoComzounoDTO.FechaHoraTermino;

                    cmd.Parameters.Add("@RequerimientoMovilidad", SqlDbType.VarChar, 1);
                    cmd.Parameters["@RequerimientoMovilidad"].Value = bandaMusicoComzounoDTO.RequerimientoMovilidad;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Observacion"].Value = bandaMusicoComzounoDTO.Observacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = bandaMusicoComzounoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(BandaMusicoComzounoDTO bandaMusicoComzounoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_BandaMusicoComzounoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BandaMusicoComzounoId", SqlDbType.Int);
                    cmd.Parameters["@BandaMusicoComzounoId"].Value = bandaMusicoComzounoDTO.BandaMusicoComzounoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = bandaMusicoComzounoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(BandaMusicoComzounoDTO bandaMusicoComzounoDTO)
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
                    cmd.Parameters["@Formato"].Value = "BandaMusicoComzouno";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = bandaMusicoComzounoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = bandaMusicoComzounoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_BandaMusicoComzounoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BandaMusicoComzouno", SqlDbType.Structured);
                    cmd.Parameters["@BandaMusicoComzouno"].TypeName = "Formato.BandaMusicoComzouno";
                    cmd.Parameters["@BandaMusicoComzouno"].Value = datos;

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
