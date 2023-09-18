using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirtel
{
    public class RegistroDesarrolloSistemaInstitucionalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RegistroDesarrolloSistemaInstitucionalDTO> ObtenerLista(int? CargaId = null)
        {
            List<RegistroDesarrolloSistemaInstitucionalDTO> lista = new List<RegistroDesarrolloSistemaInstitucionalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroDesarrolloSistemaInstitucionalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegistroDesarrolloSistemaInstitucionalDTO()
                        {
                            RegistroDesarrolloSistemaInstitucionalId = Convert.ToInt32(dr["RegistroDesarrolloSistemaInstitucionalId"]),
                            NombreSistema = dr["NombreSistema"].ToString(),
                            SiglaSoftware = dr["SiglaSoftware"].ToString(),
                            DescAreaSatisfaceDirtel = dr["DescAreaSatisfaceDirtel"].ToString(),
                            DescripcionFuncionalidad = dr["DescripcionFuncionalidad"].ToString(),
                            FechaDesarrollo = (dr["FechaDesarrollo"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescCicloDesarrolloSoftware = dr["DescCicloDesarrolloSoftware"].ToString(),
                            AvanceDesarrollo = dr["AvanceDesarrollo"].ToString(),
                            ServicioWeb = dr["ServicioWeb"].ToString(),
                            AlcanceSistemaInstitucional = dr["AlcanceSistemaInstitucional"].ToString(),
                            ModalidadDesarrollo = dr["ModalidadDesarrollo"].ToString(),
                            DescDenominacionBaseDato = dr["DescDenominacionBaseDato"].ToString(),
                            DescDenominacionLenguajeProgramacion = dr["DescDenominacionLenguajeProgramacion"].ToString(),
                            ServidorWeb = dr["ServidorWeb"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            FechaPuestaProduccion = (dr["FechaPuestaProduccion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            ServidorBD = dr["ServidorBD"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RegistroDesarrolloSistemaInstitucionalDTO registroDesarrolloSistemaInstitucionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroDesarrolloSistemaInstitucionalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NombreSistema", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NombreSistema"].Value = registroDesarrolloSistemaInstitucionalDTO.NombreSistema;

                    cmd.Parameters.Add("@SiglaSoftware", SqlDbType.VarChar, 20);
                    cmd.Parameters["@SiglaSoftware"].Value = registroDesarrolloSistemaInstitucionalDTO.SiglaSoftware;

                    cmd.Parameters.Add("@CodigoAreaSatisfaceDirtel ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaSatisfaceDirtel "].Value = registroDesarrolloSistemaInstitucionalDTO.CodigoAreaSatisfaceDirtel;

                    cmd.Parameters.Add("@DescripcionFuncionalidad", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescripcionFuncionalidad"].Value = registroDesarrolloSistemaInstitucionalDTO.DescripcionFuncionalidad;

                    cmd.Parameters.Add("@FechaDesarrollo", SqlDbType.Date);
                    cmd.Parameters["@FechaDesarrollo"].Value = registroDesarrolloSistemaInstitucionalDTO.FechaDesarrollo;

                    cmd.Parameters.Add("@CodigoCicloDesarrolloSoftware ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCicloDesarrolloSoftware "].Value = registroDesarrolloSistemaInstitucionalDTO.CodigoCicloDesarrolloSoftware;

                    cmd.Parameters.Add("@AvanceDesarrollo", SqlDbType.VarChar, 260);
                    cmd.Parameters["@AvanceDesarrollo"].Value = registroDesarrolloSistemaInstitucionalDTO.AvanceDesarrollo;

                    cmd.Parameters.Add("@ServicioWeb", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ServicioWeb"].Value = registroDesarrolloSistemaInstitucionalDTO.ServicioWeb;

                    cmd.Parameters.Add("@AlcanceSistemaInstitucional", SqlDbType.VarChar, 50);
                    cmd.Parameters["@AlcanceSistemaInstitucional"].Value = registroDesarrolloSistemaInstitucionalDTO.AlcanceSistemaInstitucional;

                    cmd.Parameters.Add("@ModalidadDesarrollo", SqlDbType.VarChar, 50); 
                    cmd.Parameters["@ModalidadDesarrollo"].Value = registroDesarrolloSistemaInstitucionalDTO.ModalidadDesarrollo;

                    cmd.Parameters.Add("@CodigoDenominacionBaseDato ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDenominacionBaseDato "].Value = registroDesarrolloSistemaInstitucionalDTO.CodigoDenominacionBaseDato;

                    cmd.Parameters.Add("@CodigoDenominacionLenguajeProgramacion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDenominacionLenguajeProgramacion "].Value = registroDesarrolloSistemaInstitucionalDTO.CodigoDenominacionLenguajeProgramacion;

                    cmd.Parameters.Add("@ServidorWeb", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ServidorWeb"].Value = registroDesarrolloSistemaInstitucionalDTO.ServidorWeb;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = registroDesarrolloSistemaInstitucionalDTO.CodigoDependencia;

                    cmd.Parameters.Add("@FechaPuestaProduccion", SqlDbType.Date);
                    cmd.Parameters["@FechaPuestaProduccion"].Value = registroDesarrolloSistemaInstitucionalDTO.FechaPuestaProduccion;

                    cmd.Parameters.Add("@ServidorBD", SqlDbType.VarChar, 50); 
                    cmd.Parameters["@ServidorBD"].Value = registroDesarrolloSistemaInstitucionalDTO.ServidorBD;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = registroDesarrolloSistemaInstitucionalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroDesarrolloSistemaInstitucionalDTO.UsuarioIngresoRegistro;

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

        public RegistroDesarrolloSistemaInstitucionalDTO BuscarFormato(int Codigo)
        {
            RegistroDesarrolloSistemaInstitucionalDTO registroDesarrolloSistemaInstitucionalDTO = new RegistroDesarrolloSistemaInstitucionalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroDesarrolloSistemaInstitucionalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroDesarrolloSistemaInstitucionalId", SqlDbType.Int);
                    cmd.Parameters["@RegistroDesarrolloSistemaInstitucionalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        registroDesarrolloSistemaInstitucionalDTO.RegistroDesarrolloSistemaInstitucionalId = Convert.ToInt32(dr["RegistroDesarrolloSistemaInstitucionalId"]);
                        registroDesarrolloSistemaInstitucionalDTO.NombreSistema = dr["NombreSistema"].ToString();
                        registroDesarrolloSistemaInstitucionalDTO.SiglaSoftware = dr["SiglaSoftware"].ToString();
                        registroDesarrolloSistemaInstitucionalDTO.CodigoAreaSatisfaceDirtel  = dr["CodigoAreaSatisfaceDirtel "].ToString();
                        registroDesarrolloSistemaInstitucionalDTO.DescripcionFuncionalidad = dr["DescripcionFuncionalidad"].ToString();
                        registroDesarrolloSistemaInstitucionalDTO.FechaDesarrollo = Convert.ToDateTime(dr["FechaDesarrollo"]).ToString("yyy-MM-dd");
                        registroDesarrolloSistemaInstitucionalDTO.CodigoCicloDesarrolloSoftware = dr["CodigoCicloDesarrolloSoftware"].ToString();
                        registroDesarrolloSistemaInstitucionalDTO.AvanceDesarrollo = dr["AvanceDesarrollo"].ToString();
                        registroDesarrolloSistemaInstitucionalDTO.ServicioWeb = dr["ServicioWeb"].ToString();
                        registroDesarrolloSistemaInstitucionalDTO.AlcanceSistemaInstitucional = dr["AlcanceSistemaInstitucional"].ToString();
                        registroDesarrolloSistemaInstitucionalDTO.ModalidadDesarrollo = dr["ModalidadDesarrollo"].ToString();
                        registroDesarrolloSistemaInstitucionalDTO.CodigoDenominacionBaseDato = dr["CodigoDenominacionBaseDato "].ToString();
                        registroDesarrolloSistemaInstitucionalDTO.CodigoDenominacionLenguajeProgramacion = dr["CodigoDenominacionLenguajeProgramacion "].ToString();
                        registroDesarrolloSistemaInstitucionalDTO.ServidorWeb = dr["ServidorWeb"].ToString();
                        registroDesarrolloSistemaInstitucionalDTO.CodigoDependencia = dr["CodigoDependencia "].ToString();
                        registroDesarrolloSistemaInstitucionalDTO.FechaPuestaProduccion = Convert.ToDateTime(dr["FechaPuestaProduccion"]).ToString("yyy-MM-dd");
                        registroDesarrolloSistemaInstitucionalDTO.ServidorBD = dr["ServidorBD"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroDesarrolloSistemaInstitucionalDTO;
        }

        public string ActualizaFormato(RegistroDesarrolloSistemaInstitucionalDTO registroDesarrolloSistemaInstitucionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroDesarrolloSistemaInstitucionalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroDesarrolloSistemaInstitucionalId", SqlDbType.Int);
                    cmd.Parameters["@RegistroDesarrolloSistemaInstitucionalId"].Value = registroDesarrolloSistemaInstitucionalDTO.RegistroDesarrolloSistemaInstitucionalId;

                    cmd.Parameters.Add("@NombreSistema", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NombreSistema"].Value = registroDesarrolloSistemaInstitucionalDTO.NombreSistema;

                    cmd.Parameters.Add("@SiglaSoftware", SqlDbType.VarChar, 20);
                    cmd.Parameters["@SiglaSoftware"].Value = registroDesarrolloSistemaInstitucionalDTO.SiglaSoftware;

                    cmd.Parameters.Add("@CodigoAreaSatisfaceDirtel ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaSatisfaceDirtel "].Value = registroDesarrolloSistemaInstitucionalDTO.CodigoAreaSatisfaceDirtel;

                    cmd.Parameters.Add("@DescripcionFuncionalidad", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescripcionFuncionalidad"].Value = registroDesarrolloSistemaInstitucionalDTO.DescripcionFuncionalidad;

                    cmd.Parameters.Add("@FechaDesarrollo", SqlDbType.Date);
                    cmd.Parameters["@FechaDesarrollo"].Value = registroDesarrolloSistemaInstitucionalDTO.FechaDesarrollo;

                    cmd.Parameters.Add("@CodigoCicloDesarrolloSoftware ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCicloDesarrolloSoftware "].Value = registroDesarrolloSistemaInstitucionalDTO.CodigoCicloDesarrolloSoftware;

                    cmd.Parameters.Add("@AvanceDesarrollo", SqlDbType.VarChar, 260);
                    cmd.Parameters["@AvanceDesarrollo"].Value = registroDesarrolloSistemaInstitucionalDTO.AvanceDesarrollo;

                    cmd.Parameters.Add("@ServicioWeb", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ServicioWeb"].Value = registroDesarrolloSistemaInstitucionalDTO.ServicioWeb;

                    cmd.Parameters.Add("@AlcanceSistemaInstitucional", SqlDbType.VarChar, 50);
                    cmd.Parameters["@AlcanceSistemaInstitucional"].Value = registroDesarrolloSistemaInstitucionalDTO.AlcanceSistemaInstitucional;

                    cmd.Parameters.Add("@ModalidadDesarrollo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ModalidadDesarrollo"].Value = registroDesarrolloSistemaInstitucionalDTO.ModalidadDesarrollo;

                    cmd.Parameters.Add("@CodigoDenominacionBaseDato ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDenominacionBaseDato "].Value = registroDesarrolloSistemaInstitucionalDTO.CodigoDenominacionBaseDato;

                    cmd.Parameters.Add("@CodigoDenominacionLenguajeProgramacion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDenominacionLenguajeProgramacion "].Value = registroDesarrolloSistemaInstitucionalDTO.CodigoDenominacionLenguajeProgramacion;

                    cmd.Parameters.Add("@ServidorWeb", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ServidorWeb"].Value = registroDesarrolloSistemaInstitucionalDTO.ServidorWeb;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = registroDesarrolloSistemaInstitucionalDTO.CodigoDependencia;

                    cmd.Parameters.Add("@FechaPuestaProduccion", SqlDbType.Date);
                    cmd.Parameters["@FechaPuestaProduccion"].Value = registroDesarrolloSistemaInstitucionalDTO.FechaPuestaProduccion;

                    cmd.Parameters.Add("@ServidorBD", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ServidorBD"].Value = registroDesarrolloSistemaInstitucionalDTO.ServidorBD;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroDesarrolloSistemaInstitucionalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroDesarrolloSistemaInstitucionalDTO registroDesarrolloSistemaInstitucionalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroDesarrolloSistemaInstitucionalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroDesarrolloSistemaInstitucionalId", SqlDbType.Int);
                    cmd.Parameters["@RegistroDesarrolloSistemaInstitucionalId"].Value = registroDesarrolloSistemaInstitucionalDTO.RegistroDesarrolloSistemaInstitucionalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroDesarrolloSistemaInstitucionalDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_RegistroDesarrolloSistemaInstitucionalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroDesarrolloSistemaInstitucional", SqlDbType.Structured);
                    cmd.Parameters["@RegistroDesarrolloSistemaInstitucional"].TypeName = "Formato.RegistroDesarrolloSistemaInstitucional";
                    cmd.Parameters["@RegistroDesarrolloSistemaInstitucional"].Value = datos;

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
