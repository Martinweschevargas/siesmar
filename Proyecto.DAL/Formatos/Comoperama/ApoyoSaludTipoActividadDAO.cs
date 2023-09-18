using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperama;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperama
{
    public class ApoyoSaludTipoActividadDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ApoyoSaludTipoActividadDTO> ObtenerLista(int? CargaId=null)
        {
            List<ApoyoSaludTipoActividadDTO> lista = new List<ApoyoSaludTipoActividadDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ApoyoSaludTipoActividadListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargoId", SqlDbType.Int);
                cmd.Parameters["@CargoId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ApoyoSaludTipoActividadDTO()
                        {
                            ApoyoSaludTipoActividadId = Convert.ToInt32(dr["ApoyoSaludTipoActividadId"]),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DistritoUbigeo = dr["DistritoUbigeo"].ToString(),
                            DescTipoActividadDenominacion = dr["DescTipoActividadDenominacion"].ToString(),
                            FechaInicio = (dr["FechaInicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTermino = (dr["FechaTermino"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NumeroAtenciones = Convert.ToInt32(dr["NumeroAtenciones"]),
                            DescTipoAccionCivica = dr["DescTipoAccionCivica"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ApoyoSaludTipoActividadDTO apoyoSocialIntitucionArmadaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ApoyoSaludTipoActividadRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = apoyoSocialIntitucionArmadaDTO.CodigoZonaNaval;


                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = apoyoSocialIntitucionArmadaDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CodigoTipoActividadDenominacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoActividadDenominacion"].Value = apoyoSocialIntitucionArmadaDTO.CodigoTipoActividadDenominacion;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = apoyoSocialIntitucionArmadaDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = apoyoSocialIntitucionArmadaDTO.FechaTermino;

                    cmd.Parameters.Add("@NumeroAtenciones", SqlDbType.Int);
                    cmd.Parameters["@NumeroAtenciones"].Value = apoyoSocialIntitucionArmadaDTO.NumeroAtenciones;

                    cmd.Parameters.Add("@CodigoTipoAccionCivica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoAccionCivica"].Value = apoyoSocialIntitucionArmadaDTO.CodigoTipoAccionCivica;


                    cmd.Parameters.Add("@CargoId", SqlDbType.Int);
                    cmd.Parameters["@CargoId"].Value = apoyoSocialIntitucionArmadaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = apoyoSocialIntitucionArmadaDTO.UsuarioIngresoRegistro;

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

        public ApoyoSaludTipoActividadDTO BuscarFormato(int Codigo)
        {
            ApoyoSaludTipoActividadDTO apoyoSocialIntitucionArmadaDTO = new ApoyoSaludTipoActividadDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ApoyoSaludTipoActividadEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ApoyoSaludTipoActividadId", SqlDbType.Int);
                    cmd.Parameters["@ApoyoSaludTipoActividadId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        apoyoSocialIntitucionArmadaDTO.ApoyoSaludTipoActividadId = Convert.ToInt32(dr["ApoyoSaludTipoActividadId"]);
                        apoyoSocialIntitucionArmadaDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        apoyoSocialIntitucionArmadaDTO.DistritoUbigeo = dr["DistritoUbigeo"].ToString();
                        apoyoSocialIntitucionArmadaDTO.CodigoTipoActividadDenominacion = dr["CodigoTipoActividadDenominacion"].ToString();
                        apoyoSocialIntitucionArmadaDTO.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]).ToString("yyy-MM-dd");
                        apoyoSocialIntitucionArmadaDTO.FechaTermino = Convert.ToDateTime(dr["FechaTermino"]).ToString("yyy-MM-dd");
                        apoyoSocialIntitucionArmadaDTO.NumeroAtenciones = Convert.ToInt32(dr["NumeroAtenciones"]);
                        apoyoSocialIntitucionArmadaDTO.CodigoTipoAccionCivica = dr["CodigoTipoAccionCivica"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return apoyoSocialIntitucionArmadaDTO;
        }

        public string ActualizaFormato(ApoyoSaludTipoActividadDTO apoyoSocialIntitucionArmadaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ApoyoSaludTipoActividadActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ApoyoSaludTipoActividadId", SqlDbType.Int);
                    cmd.Parameters["@ApoyoSaludTipoActividadId"].Value = apoyoSocialIntitucionArmadaDTO.ApoyoSaludTipoActividadId;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = apoyoSocialIntitucionArmadaDTO.CodigoZonaNaval;


                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar,20);
                    cmd.Parameters["@DistritoUbigeo"].Value = apoyoSocialIntitucionArmadaDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CodigoTipoActividadDenominacion", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoActividadDenominacion"].Value = apoyoSocialIntitucionArmadaDTO.CodigoTipoActividadDenominacion;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = apoyoSocialIntitucionArmadaDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = apoyoSocialIntitucionArmadaDTO.FechaTermino;

                    cmd.Parameters.Add("@NumeroAtenciones", SqlDbType.Int);
                    cmd.Parameters["@NumeroAtenciones"].Value = apoyoSocialIntitucionArmadaDTO.NumeroAtenciones;

                    cmd.Parameters.Add("@CodigoTipoAccionCivica", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoAccionCivica"].Value = apoyoSocialIntitucionArmadaDTO.CodigoTipoAccionCivica;



                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = apoyoSocialIntitucionArmadaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ApoyoSaludTipoActividadDTO apoyoSocialIntitucionArmadaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ApoyoSaludTipoActividadEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ApoyoSaludTipoActividadId", SqlDbType.Int);
                    cmd.Parameters["@ApoyoSaludTipoActividadId"].Value = apoyoSocialIntitucionArmadaDTO.ApoyoSaludTipoActividadId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = apoyoSocialIntitucionArmadaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ApoyoSaludTipoActividadRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ApoyoSaludTipoActividad", SqlDbType.Structured);
                    cmd.Parameters["@ApoyoSaludTipoActividad"].TypeName = "Formato.ApoyoSaludTipoActividad";
                    cmd.Parameters["@ApoyoSaludTipoActividad"].Value = datos;

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
