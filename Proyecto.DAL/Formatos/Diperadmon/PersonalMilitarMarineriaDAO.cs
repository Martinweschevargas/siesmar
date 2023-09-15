using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diperadmon;
using Marina.Siesmar.Entidades.Formatos.Jemgemar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diperadmon
{
    public class PersonalMilitarMarineriaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PersonalMilitarMarineriaDTO> ObtenerLista(int? CargaId = null, int? Mes = null, int? Anio = null)
        {
            List<PersonalMilitarMarineriaDTO> lista = new List<PersonalMilitarMarineriaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PersonalMilitarMarineriaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@R_Mes", SqlDbType.Int);
                cmd.Parameters["@R_Mes"].Value = Mes;

                cmd.Parameters.Add("@R_Anio", SqlDbType.Int);
                cmd.Parameters["@R_Anio"].Value = Anio;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PersonalMilitarMarineriaDTO()
                        {
                            PersonalMilitarMarineriaId = Convert.ToInt32(dr["PersonalMilitarMarineriaId"]),
                            DNIPMilitarMar = dr["DNIPMilitarMar"].ToString(),
                            SexoPMilitarMar = dr["SexoPMilitarMar"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            DescDistritoNacimiento = dr["DescDistritoNacimiento"].ToString(),
                            FechaNacimientoPMilitarMar = (dr["FechaNacimientoPMilitarMar"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescDistritoLabora = dr["DescDistritoLabora"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            FechaIngresoInstPMilitarMar = (dr["FechaIngresoInstPMilitarMar"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            EstadoCivilPMilitarMar = dr["EstadoCivilPMilitarMar"].ToString(),
                            DescGradoEstudioAlcanzado = dr["DescGradoEstudioAlcanzado"].ToString(),
                            GradoAñoEstudioPSPMilitarMar = dr["GradoAñoEstudioPSPMilitarMar"].ToString(),
                            DescEspecialidad = dr["DescEspecialidad"].ToString(),
                            FechaAltaPMilitarMar = (dr["FechaAltaPMilitarMar"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaIngresoDepPMilitarMar = (dr["FechaIngresoDepPMilitarMar"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaUltimoAscensoPMilitarMar = (dr["FechaUltimoAscensoPMilitarMar"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaUltimoReenganchePMilitarMar = (dr["FechaUltimoReenganchePMilitarMar"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            PeriodoReenganchadoPMilitarMar = Convert.ToInt32(dr["PeriodoReenganchadoPMilitarMar"]),
                            DescCarreraUniversitariaEspecialidad = dr["DescCarreraUniversitariaEspecialidad"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });

                    }

                }
            }
            return lista;
        }

        public string AgregarRegistro(PersonalMilitarMarineriaDTO personalMilitarMarineriaDTO, int mes, int anio)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PersonalMilitarMarineriaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIPMilitarMar", SqlDbType.VarChar,8);
                    cmd.Parameters["@DNIPMilitarMar"].Value = personalMilitarMarineriaDTO.DNIPMilitarMar;

                    cmd.Parameters.Add("@SexoPMilitarMar", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPMilitarMar"].Value = personalMilitarMarineriaDTO.SexoPMilitarMar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = personalMilitarMarineriaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@UbigeoNacimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@UbigeoNacimiento"].Value = personalMilitarMarineriaDTO.UbigeoNacimiento;

                    cmd.Parameters.Add("@FechaNacimientoPMilitarMar", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimientoPMilitarMar"].Value = personalMilitarMarineriaDTO.FechaNacimientoPMilitarMar;

                    cmd.Parameters.Add("@UbigeoLabora", SqlDbType.VarChar, 20);
                    cmd.Parameters["@UbigeoLabora"].Value = personalMilitarMarineriaDTO.UbigeoLabora;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = personalMilitarMarineriaDTO.CodigoDependencia;

                    cmd.Parameters.Add("@FechaIngresoInstPMilitarMar", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoInstPMilitarMar"].Value = personalMilitarMarineriaDTO.FechaIngresoInstPMilitarMar;

                    cmd.Parameters.Add("@EstadoCivilPMilitarMar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@EstadoCivilPMilitarMar"].Value = personalMilitarMarineriaDTO.EstadoCivilPMilitarMar;

                    cmd.Parameters.Add("@CodigoGradoEstudioAlcanzado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoEstudioAlcanzado"].Value = personalMilitarMarineriaDTO.CodigoGradoEstudioAlcanzado;

                    cmd.Parameters.Add("@GradoAñoEstudioPSPMilitarMar", SqlDbType.VarChar,20);
                    cmd.Parameters["@GradoAñoEstudioPSPMilitarMar"].Value = personalMilitarMarineriaDTO.GradoAñoEstudioPSPMilitarMar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = personalMilitarMarineriaDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@FechaAltaPMilitarMar", SqlDbType.Date);
                    cmd.Parameters["@FechaAltaPMilitarMar"].Value = personalMilitarMarineriaDTO.FechaAltaPMilitarMar;

                    cmd.Parameters.Add("@FechaIngresoDepPMilitarMar", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoDepPMilitarMar"].Value = personalMilitarMarineriaDTO.FechaIngresoDepPMilitarMar;

                    cmd.Parameters.Add("@FechaUltimoAscensoPMilitarMar", SqlDbType.Date);
                    cmd.Parameters["@FechaUltimoAscensoPMilitarMar"].Value = personalMilitarMarineriaDTO.FechaUltimoAscensoPMilitarMar;

                    cmd.Parameters.Add("@FechaUltimoReenganchePMilitarMar", SqlDbType.Date);
                    cmd.Parameters["@FechaUltimoReenganchePMilitarMar"].Value = personalMilitarMarineriaDTO.FechaUltimoReenganchePMilitarMar;

                    cmd.Parameters.Add("@PeriodoReenganchadoPMilitarMar", SqlDbType.Int);
                    cmd.Parameters["@PeriodoReenganchadoPMilitarMar"].Value = personalMilitarMarineriaDTO.PeriodoReenganchadoPMilitarMar;

                    cmd.Parameters.Add("@CodigoCarreraUniversitariaEspecialidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitariaEspecialidad"].Value = personalMilitarMarineriaDTO.CodigoCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = personalMilitarMarineriaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personalMilitarMarineriaDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@R_Mes", SqlDbType.Int);
                    cmd.Parameters["@R_Mes"].Value = mes;

                    cmd.Parameters.Add("@R_Anio", SqlDbType.Int);
                    cmd.Parameters["@R_Anio"].Value = anio;

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

        public PersonalMilitarMarineriaDTO BuscarFormato(int Codigo)
        {
            PersonalMilitarMarineriaDTO personalMilitarMarineriaDTO = new PersonalMilitarMarineriaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PersonalMilitarMarineriaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalMilitarMarineriaId", SqlDbType.Int);
                    cmd.Parameters["@PersonalMilitarMarineriaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        personalMilitarMarineriaDTO.PersonalMilitarMarineriaId = Convert.ToInt32(dr["PersonalMilitarMarineriaId"]);
                        personalMilitarMarineriaDTO.DNIPMilitarMar = dr["DNIPMilitarMar"].ToString();
                        personalMilitarMarineriaDTO.SexoPMilitarMar = Regex.Replace(dr["SexoPMilitarMar"].ToString(), @"\s", "");
                        personalMilitarMarineriaDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        personalMilitarMarineriaDTO.UbigeoNacimiento = dr["UbigeoNacimiento"].ToString();
                        personalMilitarMarineriaDTO.FechaNacimientoPMilitarMar = Convert.ToDateTime(dr["FechaNacimientoPMilitarMar"]).ToString("yyy-MM-dd");
                        personalMilitarMarineriaDTO.UbigeoLabora = dr["UbigeoLabora"].ToString();
                        personalMilitarMarineriaDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        personalMilitarMarineriaDTO.FechaIngresoInstPMilitarMar = Convert.ToDateTime(dr["FechaIngresoInstPMilitarMar"]).ToString("yyy-MM-dd");
                        personalMilitarMarineriaDTO.EstadoCivilPMilitarMar = Regex.Replace(dr["EstadoCivilPMilitarMar"].ToString(), @"\s", "");
                        personalMilitarMarineriaDTO.CodigoGradoEstudioAlcanzado = dr["CodigoGradoEstudioAlcanzado"].ToString();
                        personalMilitarMarineriaDTO.GradoAñoEstudioPSPMilitarMar = Regex.Replace(dr["GradoAñoEstudioPSPMilitarMar"].ToString(), @"\s", "");
                        personalMilitarMarineriaDTO.CodigoEspecialidadGenericaPersonal = dr["CodigoEspecialidadGenericaPersonal"].ToString();
                        personalMilitarMarineriaDTO.FechaAltaPMilitarMar = Convert.ToDateTime(dr["FechaAltaPMilitarMar"]).ToString("yyy-MM-dd");
                        personalMilitarMarineriaDTO.FechaIngresoDepPMilitarMar = Convert.ToDateTime(dr["FechaIngresoDepPMilitarMar"]).ToString("yyy-MM-dd");
                        personalMilitarMarineriaDTO.FechaUltimoAscensoPMilitarMar = Convert.ToDateTime(dr["FechaUltimoAscensoPMilitarMar"]).ToString("yyy-MM-dd");
                        personalMilitarMarineriaDTO.FechaUltimoReenganchePMilitarMar = Convert.ToDateTime(dr["FechaUltimoReenganchePMilitarMar"]).ToString("yyy-MM-dd");
                        personalMilitarMarineriaDTO.PeriodoReenganchadoPMilitarMar = Convert.ToInt32(dr["PeriodoReenganchadoPMilitarMar"]);
                        personalMilitarMarineriaDTO.CodigoCarreraUniversitariaEspecialidad = dr["CodigoCarreraUniversitariaEspecialidad"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return personalMilitarMarineriaDTO;
        }

        public string ActualizaFormato(PersonalMilitarMarineriaDTO personalMilitarMarineriaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PersonalMilitarMarineriaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalMilitarMarineriaId", SqlDbType.Int);
                    cmd.Parameters["@PersonalMilitarMarineriaId"].Value = personalMilitarMarineriaDTO.PersonalMilitarMarineriaId;

                    cmd.Parameters.Add("@DNIPMilitarMar", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPMilitarMar"].Value = personalMilitarMarineriaDTO.DNIPMilitarMar;

                    cmd.Parameters.Add("@SexoPMilitarMar", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPMilitarMar"].Value = personalMilitarMarineriaDTO.SexoPMilitarMar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = personalMilitarMarineriaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@UbigeoNacimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@UbigeoNacimiento"].Value = personalMilitarMarineriaDTO.UbigeoNacimiento;

                    cmd.Parameters.Add("@FechaNacimientoPMilitarMar", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimientoPMilitarMar"].Value = personalMilitarMarineriaDTO.FechaNacimientoPMilitarMar;

                    cmd.Parameters.Add("@UbigeoLabora", SqlDbType.VarChar, 20);
                    cmd.Parameters["@UbigeoLabora"].Value = personalMilitarMarineriaDTO.UbigeoLabora;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = personalMilitarMarineriaDTO.CodigoDependencia;

                    cmd.Parameters.Add("@FechaIngresoInstPMilitarMar", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoInstPMilitarMar"].Value = personalMilitarMarineriaDTO.FechaIngresoInstPMilitarMar;

                    cmd.Parameters.Add("@EstadoCivilPMilitarMar", SqlDbType.VarChar, 15);
                    cmd.Parameters["@EstadoCivilPMilitarMar"].Value = personalMilitarMarineriaDTO.EstadoCivilPMilitarMar;

                    cmd.Parameters.Add("@CodigoGradoEstudioAlcanzado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoEstudioAlcanzado"].Value = personalMilitarMarineriaDTO.CodigoGradoEstudioAlcanzado;

                    cmd.Parameters.Add("@GradoAñoEstudioPSPMilitarMar", SqlDbType.VarChar, 10);
                    cmd.Parameters["@GradoAñoEstudioPSPMilitarMar"].Value = personalMilitarMarineriaDTO.GradoAñoEstudioPSPMilitarMar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = personalMilitarMarineriaDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@FechaAltaPMilitarMar", SqlDbType.Date);
                    cmd.Parameters["@FechaAltaPMilitarMar"].Value = personalMilitarMarineriaDTO.FechaAltaPMilitarMar;

                    cmd.Parameters.Add("@FechaIngresoDepPMilitarMar", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoDepPMilitarMar"].Value = personalMilitarMarineriaDTO.FechaIngresoDepPMilitarMar;

                    cmd.Parameters.Add("@FechaUltimoAscensoPMilitarMar", SqlDbType.Date);
                    cmd.Parameters["@FechaUltimoAscensoPMilitarMar"].Value = personalMilitarMarineriaDTO.FechaUltimoAscensoPMilitarMar;

                    cmd.Parameters.Add("@FechaUltimoReenganchePMilitarMar", SqlDbType.Date);
                    cmd.Parameters["@FechaUltimoReenganchePMilitarMar"].Value = personalMilitarMarineriaDTO.FechaUltimoReenganchePMilitarMar;

                    cmd.Parameters.Add("@PeriodoReenganchadoPMilitarMar", SqlDbType.Int);
                    cmd.Parameters["@PeriodoReenganchadoPMilitarMar"].Value = personalMilitarMarineriaDTO.PeriodoReenganchadoPMilitarMar;

                    cmd.Parameters.Add("@CodigoCarreraUniversitariaEspecialidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitariaEspecialidad"].Value = personalMilitarMarineriaDTO.CodigoCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personalMilitarMarineriaDTO.UsuarioIngresoRegistro;

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


        public bool EliminarFormato(PersonalMilitarMarineriaDTO personalMilitarMarineriaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PersonalMilitarMarineriaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalMilitarMarineriaId", SqlDbType.Int);
                    cmd.Parameters["@PersonalMilitarMarineriaId"].Value = personalMilitarMarineriaDTO.PersonalMilitarMarineriaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personalMilitarMarineriaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(PersonalMilitarMarineriaDTO personalMilitarMarineriaDTO)
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
                    cmd.Parameters["@Formato"].Value = "PersonalMilitarMarineria";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = personalMilitarMarineriaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personalMilitarMarineriaDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos, int mes, int anio)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_PersonalMilitarMarineriaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalMilitarMarineria", SqlDbType.Structured);
                    cmd.Parameters["@PersonalMilitarMarineria"].TypeName = "Formato.PersonalMilitarMarineria";
                    cmd.Parameters["@PersonalMilitarMarineria"].Value = datos;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@R_Mes", SqlDbType.Int);
                    cmd.Parameters["@R_Mes"].Value = mes;

                    cmd.Parameters.Add("@R_Anio", SqlDbType.Int);
                    cmd.Parameters["@R_Anio"].Value = anio;

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
