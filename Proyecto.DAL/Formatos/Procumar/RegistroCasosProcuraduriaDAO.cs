using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Procumar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace Marina.Siesmar.AccesoDatos.Formatos.Procumar
{
    public class RegistroCasosProcuraduriaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RegistroCasosProcuraduriaDTO> ObtenerLista(int? CargaId=null)
        {
            List<RegistroCasosProcuraduriaDTO> lista = new List<RegistroCasosProcuraduriaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroCasosProcuraduriaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegistroCasosProcuraduriaDTO()
                        {
                            RegistroCasosProcuraduriaId = Convert.ToInt32(dr["RegistroCasosProcuraduriaId"]),
                            AnioDemanda = Convert.ToInt32(dr["AñoDemanda"]),
                            MesDemanda = dr["MesDemanda"].ToString(),
                            CodigoAreaProcumar = dr["CodigoAreaProcumar"].ToString(),
                            NombreAbogado = dr["NombreAbogado"].ToString(),
                            NroExpediente = dr["NroExpediente"].ToString(),
                            NroCodInterno = dr["NroCodInterno"].ToString(),
                            NombreDemandante = dr["NombreDemandante"].ToString(),
                            NombreDemandado = dr["NombreDemandado"].ToString(),
                            DescGradoPersonal = dr["DescGradoPersonal"].ToString(),
                            DescEspecialidadPersonal = dr["DescEspecialidadPersonal"].ToString(),
                            DescMateriaProcumar = dr["DescMateriaProcumar"].ToString(),
                            Petitorio = dr["Petitorio"].ToString(),
                            DescDistritoJudicial = dr["DescDistritoJudicial"].ToString(),
                            DescInstanciaJudicial = dr["DescInstanciaJudicial"].ToString(),
                            DescCasoExcepcional = dr["DescCasoExcepcional"].ToString(),
                            UltimoActuado = dr["UltimoActuado"].ToString(),
                            DescEstadoProceso = dr["DescEstadoProceso"].ToString(),
                            SentenciaEjecutoria = dr["SentenciaEjecutoria"].ToString(),
                            AnioTerminoProceso = Convert.ToInt32(dr["AñoTerminoProceso"]),
                            MonedaId = dr["MonedaId"].ToString(),
                            MontoPretencion = Convert.ToDecimal(dr["MontoPretencion"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });

                    }

                }
            }
            return lista;
        }

        public string AgregarRegistro(RegistroCasosProcuraduriaDTO registroCasosProcuraduriaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroCasosProcuraduriaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AñoDemanda", SqlDbType.Int);
                    cmd.Parameters["@AñoDemanda"].Value = registroCasosProcuraduriaDTO.AnioDemanda;

                    cmd.Parameters.Add("@MesDemanda", SqlDbType.VarChar,50);
                    cmd.Parameters["@MesDemanda"].Value = registroCasosProcuraduriaDTO.MesDemanda;

                    cmd.Parameters.Add("@CodigoAreaProcumar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoAreaProcumar"].Value = registroCasosProcuraduriaDTO.CodigoAreaProcumar;

                    cmd.Parameters.Add("@NombreAbogado", SqlDbType.VarChar,50);
                    cmd.Parameters["@NombreAbogado"].Value = registroCasosProcuraduriaDTO.NombreAbogado;

                    cmd.Parameters.Add("@NroExpediente", SqlDbType.VarChar,50);
                    cmd.Parameters["@NroExpediente"].Value = registroCasosProcuraduriaDTO.NroExpediente;

                    cmd.Parameters.Add("@NroCodInterno", SqlDbType.VarChar,20);
                    cmd.Parameters["@NroCodInterno"].Value = registroCasosProcuraduriaDTO.NroCodInterno;

                    cmd.Parameters.Add("@NombreDemandante", SqlDbType.VarChar,60);
                    cmd.Parameters["@NombreDemandante"].Value = registroCasosProcuraduriaDTO.NombreDemandante;

                    cmd.Parameters.Add("@NombreDemandado", SqlDbType.VarChar, 60);
                    cmd.Parameters["@NombreDemandado"].Value = registroCasosProcuraduriaDTO.NombreDemandado;

                    cmd.Parameters.Add("@CodigoGradoPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonal"].Value = registroCasosProcuraduriaDTO.CodigoGradoPersonal;

                    cmd.Parameters.Add("@CodigoEspecialidadPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadPersonal"].Value = registroCasosProcuraduriaDTO.CodigoEspecialidadPersonal;

                    cmd.Parameters.Add("@CodigoMateriaProcumar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMateriaProcumar"].Value = registroCasosProcuraduriaDTO.CodigoMateriaProcumar;

                    cmd.Parameters.Add("@Petitorio", SqlDbType.VarChar,200);
                    cmd.Parameters["@Petitorio"].Value = registroCasosProcuraduriaDTO.Petitorio;

                    cmd.Parameters.Add("@CodigoDistritoJudicial", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDistritoJudicial"].Value = registroCasosProcuraduriaDTO.CodigoDistritoJudicial;

                    cmd.Parameters.Add("@CodigoInstanciaJudicial", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoInstanciaJudicial"].Value = registroCasosProcuraduriaDTO.CodigoInstanciaJudicial;

                    cmd.Parameters.Add("@CodigoCasoExcepcional", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoCasoExcepcional"].Value = registroCasosProcuraduriaDTO.CodigoCasoExcepcional;

                    cmd.Parameters.Add("@UltimoActuado", SqlDbType.VarChar,100);
                    cmd.Parameters["@UltimoActuado"].Value = registroCasosProcuraduriaDTO.UltimoActuado;

                    cmd.Parameters.Add("@CodigoEstadoProceso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstadoProceso"].Value = registroCasosProcuraduriaDTO.CodigoEstadoProceso;

                    cmd.Parameters.Add("@SentenciaEjecutoria", SqlDbType.VarChar, 15);
                    cmd.Parameters["@SentenciaEjecutoria"].Value = registroCasosProcuraduriaDTO.SentenciaEjecutoria;

                    cmd.Parameters.Add("@AñoTerminoProceso", SqlDbType.Int);
                    cmd.Parameters["@AñoTerminoProceso"].Value = registroCasosProcuraduriaDTO.AnioTerminoProceso;

                    cmd.Parameters.Add("@MonedaId", SqlDbType.Int);
                    cmd.Parameters["@MonedaId"].Value = registroCasosProcuraduriaDTO.MonedaId;

                    cmd.Parameters.Add("@MontoPretencion", SqlDbType.Decimal);
                    cmd.Parameters["@MontoPretencion"].Value = registroCasosProcuraduriaDTO.MontoPretencion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = registroCasosProcuraduriaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroCasosProcuraduriaDTO.UsuarioIngresoRegistro;

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

        public RegistroCasosProcuraduriaDTO BuscarFormato(int Codigo)
        {
            RegistroCasosProcuraduriaDTO registroCasosProcuraduriaDTO = new RegistroCasosProcuraduriaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroCasosProcuraduriaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroCasosProcuraduriaId", SqlDbType.Int);
                    cmd.Parameters["@RegistroCasosProcuraduriaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        registroCasosProcuraduriaDTO.RegistroCasosProcuraduriaId = Convert.ToInt32(dr["RegistroCasosProcuraduriaId"]);
                        registroCasosProcuraduriaDTO.AnioDemanda = Convert.ToInt32(dr["AñoDemanda"]);
                        registroCasosProcuraduriaDTO.MesDemanda = dr["MesDemanda"].ToString();
                        registroCasosProcuraduriaDTO.CodigoAreaProcumar = dr["CodigoAreaProcumar"].ToString();
                        registroCasosProcuraduriaDTO.NombreAbogado = dr["NombreAbogado"].ToString();
                        registroCasosProcuraduriaDTO.NroExpediente = dr["NroExpediente"].ToString();
                        registroCasosProcuraduriaDTO.NroCodInterno = dr["NroCodInterno"].ToString();
                        registroCasosProcuraduriaDTO.NombreDemandante = dr["NombreDemandante"].ToString();
                        registroCasosProcuraduriaDTO.NombreDemandado = dr["NombreDemandado"].ToString();
                        registroCasosProcuraduriaDTO.CodigoGradoPersonal = dr["CodigoGradoPersonal"].ToString();
                        registroCasosProcuraduriaDTO.CodigoEspecialidadPersonal = dr["CodigoEspecialidadPersonal"].ToString();
                        registroCasosProcuraduriaDTO.CodigoMateriaProcumar = dr["CodigoMateriaProcumar"].ToString();
                        registroCasosProcuraduriaDTO.Petitorio = dr["Petitorio"].ToString();
                        registroCasosProcuraduriaDTO.CodigoDistritoJudicial = dr["CodigoDistritoJudicial"].ToString();
                        registroCasosProcuraduriaDTO.CodigoInstanciaJudicial = dr["CodigoInstanciaJudicial"].ToString();
                        registroCasosProcuraduriaDTO.CodigoCasoExcepcional = dr["CodigoCasoExcepcional"].ToString();
                        registroCasosProcuraduriaDTO.UltimoActuado = dr["UltimoActuado"].ToString();
                        registroCasosProcuraduriaDTO.CodigoEstadoProceso = dr["CodigoEstadoProceso"].ToString();
                        registroCasosProcuraduriaDTO.SentenciaEjecutoria = dr["SentenciaEjecutoria"].ToString();
                        registroCasosProcuraduriaDTO.AnioTerminoProceso = Convert.ToInt32(dr["AñoTerminoProceso"]);
                        registroCasosProcuraduriaDTO.MonedaId = dr["MonedaId"].ToString();
                        registroCasosProcuraduriaDTO.MontoPretencion = Convert.ToDecimal(dr["MontoPretencion"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroCasosProcuraduriaDTO;
        }

        public string ActualizaFormato(RegistroCasosProcuraduriaDTO registroCasosProcuraduriaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroCasosProcuraduriaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroCasosProcuraduriaId", SqlDbType.Int);
                    cmd.Parameters["@RegistroCasosProcuraduriaId"].Value = registroCasosProcuraduriaDTO.RegistroCasosProcuraduriaId;

                    cmd.Parameters.Add("@AñoDemanda", SqlDbType.Int);
                    cmd.Parameters["@AñoDemanda"].Value = registroCasosProcuraduriaDTO.AnioDemanda;

                    cmd.Parameters.Add("@MesDemanda", SqlDbType.VarChar, 50);
                    cmd.Parameters["@MesDemanda"].Value = registroCasosProcuraduriaDTO.MesDemanda;

                    cmd.Parameters.Add("@CodigoAreaProcumar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaProcumar"].Value = registroCasosProcuraduriaDTO.CodigoAreaProcumar;

                    cmd.Parameters.Add("@NombreAbogado", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NombreAbogado"].Value = registroCasosProcuraduriaDTO.NombreAbogado;

                    cmd.Parameters.Add("@NroExpediente", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NroExpediente"].Value = registroCasosProcuraduriaDTO.NroExpediente;

                    cmd.Parameters.Add("@NroCodInterno", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NroCodInterno"].Value = registroCasosProcuraduriaDTO.NroCodInterno;

                    cmd.Parameters.Add("@NombreDemandante", SqlDbType.VarChar, 60);
                    cmd.Parameters["@NombreDemandante"].Value = registroCasosProcuraduriaDTO.NombreDemandante;

                    cmd.Parameters.Add("@NombreDemandado", SqlDbType.VarChar, 60);
                    cmd.Parameters["@NombreDemandado"].Value = registroCasosProcuraduriaDTO.NombreDemandado;

                    cmd.Parameters.Add("@CodigoGradoPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonal"].Value = registroCasosProcuraduriaDTO.CodigoGradoPersonal;

                    cmd.Parameters.Add("@CodigoEspecialidadPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadPersonal"].Value = registroCasosProcuraduriaDTO.CodigoEspecialidadPersonal;

                    cmd.Parameters.Add("@CodigoMateriaProcumar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMateriaProcumar"].Value = registroCasosProcuraduriaDTO.CodigoMateriaProcumar;

                    cmd.Parameters.Add("@Petitorio", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Petitorio"].Value = registroCasosProcuraduriaDTO.Petitorio;

                    cmd.Parameters.Add("@CodigoDistritoJudicial", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDistritoJudicial"].Value = registroCasosProcuraduriaDTO.CodigoDistritoJudicial;

                    cmd.Parameters.Add("@CodigoInstanciaJudicial", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInstanciaJudicial"].Value = registroCasosProcuraduriaDTO.CodigoInstanciaJudicial;

                    cmd.Parameters.Add("@CodigoCasoExcepcional", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCasoExcepcional"].Value = registroCasosProcuraduriaDTO.CodigoCasoExcepcional;

                    cmd.Parameters.Add("@UltimoActuado", SqlDbType.VarChar, 100);
                    cmd.Parameters["@UltimoActuado"].Value = registroCasosProcuraduriaDTO.UltimoActuado;

                    cmd.Parameters.Add("@CodigoEstadoProceso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstadoProceso"].Value = registroCasosProcuraduriaDTO.CodigoEstadoProceso;

                    cmd.Parameters.Add("@SentenciaEjecutoria", SqlDbType.VarChar, 15);
                    cmd.Parameters["@SentenciaEjecutoria"].Value = registroCasosProcuraduriaDTO.SentenciaEjecutoria;

                    cmd.Parameters.Add("@AñoTerminoProceso", SqlDbType.Int);
                    cmd.Parameters["@AñoTerminoProceso"].Value = registroCasosProcuraduriaDTO.AnioTerminoProceso;

                    cmd.Parameters.Add("@MonedaId", SqlDbType.Int);
                    cmd.Parameters["@MonedaId"].Value = registroCasosProcuraduriaDTO.MonedaId;

                    cmd.Parameters.Add("@MontoPretencion", SqlDbType.Decimal);
                    cmd.Parameters["@MontoPretencion"].Value = registroCasosProcuraduriaDTO.MontoPretencion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroCasosProcuraduriaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroCasosProcuraduriaDTO registroCasosProcuraduriaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroCasosProcuraduriaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroCasosProcuraduriaId", SqlDbType.Int);
                    cmd.Parameters["@RegistroCasosProcuraduriaId"].Value= registroCasosProcuraduriaDTO.RegistroCasosProcuraduriaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroCasosProcuraduriaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RegistroCasoProcuraduriaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroCasoProcuraduria", SqlDbType.Structured);
                    cmd.Parameters["@RegistroCasoProcuraduria"].TypeName = "Formato.RegistroCasoProcuraduria";
                    cmd.Parameters["@RegistroCasoProcuraduria"].Value = datos;

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
