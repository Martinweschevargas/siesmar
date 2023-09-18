using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperguard
{
    public class ActividadIlicitaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ActividadIlicitaComoperguardDTO> ObtenerLista(int? CargaId = null)
        {
            List<ActividadIlicitaComoperguardDTO> lista = new List<ActividadIlicitaComoperguardDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ActividadIlicitaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ActividadIlicitaComoperguardDTO()
                        {
                            FActividadIlicitaId = Convert.ToInt32(dr["FActividadIlicitaId"]),
                            DescJefaturaDistritoCapitania = dr["DescJefaturaDistritoCapitania"].ToString(),
                            NombreCapitania = dr["NombreCapitania"].ToString(),
                            FechaIntervencion = (dr["FechaIntervencion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescActividadIlicita = dr["DescActividadIlicita"].ToString(),
                            DescTomaConocimiento = dr["DescTomaConocimiento"].ToString(),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            CascoNave = Convert.ToInt32(dr["CascoNave"]),
                            LatitudUbicacionNave = dr["LatitudUbicacionNave"].ToString(),
                            LongitudUbicacionNave = dr["LongitudUbicacionNave"].ToString(),
                            DescAmbitoNave = dr["DescAmbitoNave"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            NombreNave = dr["NombreNave"].ToString(),
                            MatriculaNave = dr["MatriculaNave"].ToString(),
                            NombrePais = dr["NombrePais"].ToString(),
                            DescTipoNave = dr["DescTipoNave"].ToString(),
                            NumeroIntervenidos = Convert.ToInt32(dr["NumeroIntervenidos"]),
                            DescMaterialIncautado = dr["DescMaterialIncautado"].ToString(),
                            CantidadMaterialIncautado = Convert.ToInt32(dr["CantidadMaterialIncautado"]),
                            DescUnidadMedida = dr["DescUnidadMedida"].ToString(),
                            DocumentoInformacion = dr["DocumentoInformacion"].ToString(),
                            FechaDocumento = (dr["FechaDocumento"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            ObservacionIntervencion = dr["ObservacionIntervencion"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ActividadIlicitaComoperguardDTO actividadIlicitaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ActividadIlicitaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@CodigoJefaturaDistritoCapitania", SqlDbType.Int);
                    cmd.Parameters["@CodigoJefaturaDistritoCapitania"].Value = actividadIlicitaDTO.CodigoJefaturaDistritoCapitania;

                    cmd.Parameters.Add("@CodigoCapitania", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoCapitania"].Value = actividadIlicitaDTO.CodigoCapitania;

                    cmd.Parameters.Add("@FechaIntervencion", SqlDbType.DateTime);
                    cmd.Parameters["@FechaIntervencion"].Value = actividadIlicitaDTO.FechaIntervencion;

                    cmd.Parameters.Add("@CodigoActividadIlicita", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoActividadIlicita"].Value = actividadIlicitaDTO.CodigoActividadIlicita;

                    cmd.Parameters.Add("@CodigoTomaConocimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTomaConocimiento"].Value = actividadIlicitaDTO.CodigoTomaConocimiento;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = actividadIlicitaDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CascoNave", SqlDbType.Int);
                    cmd.Parameters["@CascoNave"].Value = actividadIlicitaDTO.CascoNave;

                    cmd.Parameters.Add("@LatitudUbicacionNave", SqlDbType.VarChar,15);
                    cmd.Parameters["@LatitudUbicacionNave"].Value = actividadIlicitaDTO.LatitudUbicacionNave;

                    cmd.Parameters.Add("@LongitudUbicacionNave", SqlDbType.VarChar,15);
                    cmd.Parameters["@LongitudUbicacionNave"].Value = actividadIlicitaDTO.LongitudUbicacionNave;

                    cmd.Parameters.Add("@CodigoAmbitoNave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAmbitoNave"].Value = actividadIlicitaDTO.CodigoAmbitoNave;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = actividadIlicitaDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@NombreNave", SqlDbType.VarChar,150);
                    cmd.Parameters["@NombreNave"].Value = actividadIlicitaDTO.NombreNave;

                    cmd.Parameters.Add("@MatriculaNave", SqlDbType.VarChar,20);
                    cmd.Parameters["@MatriculaNave"].Value = actividadIlicitaDTO.MatriculaNave;

                    cmd.Parameters.Add("@NumericoPais", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais"].Value = actividadIlicitaDTO.NumericoPais;

                    cmd.Parameters.Add("@CodigoTipoNave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoNave"].Value = actividadIlicitaDTO.CodigoTipoNave;

                    cmd.Parameters.Add("@NumeroIntervenidos", SqlDbType.Int);
                    cmd.Parameters["@NumeroIntervenidos"].Value = actividadIlicitaDTO.NumeroIntervenidos;

                    cmd.Parameters.Add("@CodigoMaterialIncautado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMaterialIncautado"].Value = actividadIlicitaDTO.CodigoMaterialIncautado;

                    cmd.Parameters.Add("@CantidadMaterialIncautado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CantidadMaterialIncautado"].Value = actividadIlicitaDTO.CantidadMaterialIncautado;

                    cmd.Parameters.Add("@CodigoUnidadMedida", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadMedida"].Value = actividadIlicitaDTO.CodigoUnidadMedida;

                    cmd.Parameters.Add("@DocumentoInformacion", SqlDbType.VarChar,50);
                    cmd.Parameters["@DocumentoInformacion"].Value = actividadIlicitaDTO.DocumentoInformacion;

                    cmd.Parameters.Add("@FechaDocumento", SqlDbType.Date);
                    cmd.Parameters["@FechaDocumento"].Value = actividadIlicitaDTO.FechaDocumento;

                    cmd.Parameters.Add("@ObservacionIntervencion", SqlDbType.VarChar,500);
                    cmd.Parameters["@ObservacionIntervencion"].Value = actividadIlicitaDTO.ObservacionIntervencion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = actividadIlicitaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actividadIlicitaDTO.UsuarioIngresoRegistro;

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

        public ActividadIlicitaComoperguardDTO BuscarFormato(int Codigo)
        {
            ActividadIlicitaComoperguardDTO actividadIlicitaDTO = new ActividadIlicitaComoperguardDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ActividadIlicitaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoActividadIlicita", SqlDbType.Int);
                    cmd.Parameters["@CodigoActividadIlicita"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        actividadIlicitaDTO.FActividadIlicitaId = Convert.ToInt32(dr["FActividadIlicitaId"]);
                        actividadIlicitaDTO.CodigoJefaturaDistritoCapitania = dr["CodigoJefaturaDistritoCapitania"].ToString();
                        actividadIlicitaDTO.CodigoCapitania = dr["CodigoCapitania"].ToString();
                        actividadIlicitaDTO.FechaIntervencion = Convert.ToDateTime(dr["FechaIntervencion"]).ToString("yyy-MM-dd");
                        actividadIlicitaDTO.CodigoActividadIlicita = dr["CodigoActividadIlicita"].ToString();
                        actividadIlicitaDTO.CodigoTomaConocimiento = dr["CodigoTomaConocimiento"].ToString();
                        actividadIlicitaDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        actividadIlicitaDTO.CascoNave = Convert.ToInt32(dr["CascoNave"]);
                        actividadIlicitaDTO.LatitudUbicacionNave = dr["LatitudUbicacionNave"].ToString();
                        actividadIlicitaDTO.LongitudUbicacionNave = dr["LongitudUbicacionNave"].ToString();
                        actividadIlicitaDTO.CodigoAmbitoNave = dr["CodigoAmbitoNave"].ToString();
                        actividadIlicitaDTO.DistritoUbigeo = dr["DistritoUbigeo"].ToString();
                        actividadIlicitaDTO.NombreNave = dr["NombreNave"].ToString();
                        actividadIlicitaDTO.MatriculaNave = dr["MatriculaNave"].ToString();
                        actividadIlicitaDTO.NumericoPais = dr["NumericoPais"].ToString();
                        actividadIlicitaDTO.CodigoTipoNave = dr["CodigoTipoNave"].ToString();
                        actividadIlicitaDTO.NumeroIntervenidos = Convert.ToInt32(dr["NumeroIntervenidos"]);
                        actividadIlicitaDTO.CodigoMaterialIncautado = dr["CodigoMaterialIncautado"].ToString();
                        actividadIlicitaDTO.CantidadMaterialIncautado = Convert.ToInt32(dr["CantidadMaterialIncautado"]);
                        actividadIlicitaDTO.CodigoUnidadMedida = dr["CodigoUnidadMedida"].ToString();
                        actividadIlicitaDTO.DocumentoInformacion = dr["DocumentoInformacion"].ToString();
                        actividadIlicitaDTO.FechaDocumento = Convert.ToDateTime(dr["FechaDocumento"]).ToString("yyy-MM-dd");
                        actividadIlicitaDTO.ObservacionIntervencion = dr["ObservacionIntervencion"].ToString(); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return actividadIlicitaDTO;
        }

        public string ActualizaFormato(ActividadIlicitaComoperguardDTO actividadIlicitaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ActividadIlicitaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@FActividadIlicitaId", SqlDbType.Int);
                    cmd.Parameters["@FActividadIlicitaId"].Value = actividadIlicitaDTO.FActividadIlicitaId;

                    cmd.Parameters.Add("@CodigoJefaturaDistritoCapitania", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoJefaturaDistritoCapitania"].Value = actividadIlicitaDTO.CodigoJefaturaDistritoCapitania;

                    cmd.Parameters.Add("@CodigoCapitania", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapitania"].Value = actividadIlicitaDTO.CodigoCapitania;

                    cmd.Parameters.Add("@FechaIntervencion", SqlDbType.DateTime);
                    cmd.Parameters["@FechaIntervencion"].Value = actividadIlicitaDTO.FechaIntervencion;

                    cmd.Parameters.Add("@CodigoActividadIlicita", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoActividadIlicita"].Value = actividadIlicitaDTO.CodigoActividadIlicita;

                    cmd.Parameters.Add("@CodigoTomaConocimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTomaConocimiento"].Value = actividadIlicitaDTO.CodigoTomaConocimiento;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = actividadIlicitaDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CascoNave", SqlDbType.Int);
                    cmd.Parameters["@CascoNave"].Value = actividadIlicitaDTO.CascoNave;

                    cmd.Parameters.Add("@LatitudUbicacionNave", SqlDbType.VarChar, 15);
                    cmd.Parameters["@LatitudUbicacionNave"].Value = actividadIlicitaDTO.LatitudUbicacionNave;

                    cmd.Parameters.Add("@LongitudUbicacionNave", SqlDbType.VarChar, 15);
                    cmd.Parameters["@LongitudUbicacionNave"].Value = actividadIlicitaDTO.LongitudUbicacionNave;

                    cmd.Parameters.Add("@CodigoAmbitoNave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAmbitoNave"].Value = actividadIlicitaDTO.CodigoAmbitoNave;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = actividadIlicitaDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@NombreNave", SqlDbType.VarChar, 150);
                    cmd.Parameters["@NombreNave"].Value = actividadIlicitaDTO.NombreNave;

                    cmd.Parameters.Add("@MatriculaNave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@MatriculaNave"].Value = actividadIlicitaDTO.MatriculaNave;

                    cmd.Parameters.Add("@NumericoPais", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais"].Value = actividadIlicitaDTO.NumericoPais;

                    cmd.Parameters.Add("@CodigoTipoNave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoNave"].Value = actividadIlicitaDTO.CodigoTipoNave;

                    cmd.Parameters.Add("@NumeroIntervenidos", SqlDbType.Int);
                    cmd.Parameters["@NumeroIntervenidos"].Value = actividadIlicitaDTO.NumeroIntervenidos;

                    cmd.Parameters.Add("@CodigoMaterialIncautado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMaterialIncautado"].Value = actividadIlicitaDTO.CodigoMaterialIncautado;

                    cmd.Parameters.Add("@CantidadMaterialIncautado", SqlDbType.Int);
                    cmd.Parameters["@CantidadMaterialIncautado"].Value = actividadIlicitaDTO.CantidadMaterialIncautado;

                    cmd.Parameters.Add("@CodigoUnidadMedida", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadMedida"].Value = actividadIlicitaDTO.CodigoUnidadMedida;

                    cmd.Parameters.Add("@DocumentoInformacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DocumentoInformacion"].Value = actividadIlicitaDTO.DocumentoInformacion;

                    cmd.Parameters.Add("@FechaDocumento", SqlDbType.Date);
                    cmd.Parameters["@FechaDocumento"].Value = actividadIlicitaDTO.FechaDocumento;

                    cmd.Parameters.Add("@ObservacionIntervencion", SqlDbType.VarChar, 500);
                    cmd.Parameters["@ObservacionIntervencion"].Value = actividadIlicitaDTO.ObservacionIntervencion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actividadIlicitaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ActividadIlicitaComoperguardDTO actividadIlicitaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ActividadIlicitaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoActividadIlicita", SqlDbType.Int);
                    cmd.Parameters["@CodigoActividadIlicita"].Value = actividadIlicitaDTO.CodigoActividadIlicita;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actividadIlicitaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ActividadIlicitaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadIlicita", SqlDbType.Structured);
                    cmd.Parameters["@ActividadIlicita"].TypeName = "Formato.ActividadIlicita";
                    cmd.Parameters["@ActividadIlicita"].Value = datos;

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
