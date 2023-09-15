using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diperadmon;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diperadmon
{
    public class PersonalCivilDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PersonalCivilDTO> ObtenerLista(int? CargaId = null, string? fechacarga=null)
        {
            List<PersonalCivilDTO> lista = new List<PersonalCivilDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PersonalCivilListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                cmd.Parameters["@FechaCarga"].Value = fechacarga;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PersonalCivilDTO()
                        {
                            PersonalCivilId = Convert.ToInt32(dr["PersonalCivilId"]),
                            TipoDocumentoPCivil = dr["TipoDocumentoPCivil"].ToString(),
                            DNIPCivil = dr["DNIPCivil"].ToString(),
                            SexoPCivil = dr["SexoPCivil"].ToString(),
                            DescCondicionLaboralPCivil = dr["DescCondicionLaboralCivil"].ToString(),
                            DescGrupoOcupacionalPCivil = dr["DescGrupoOcupacionalCivil"].ToString(),
                            NivelCargoPCivil = dr["NivelCargoPCivil"].ToString(),
                            DescGrupoRemunerativo = dr["DescGrupoRemunerativo"].ToString(),
                            DescGradoRemunerativo = dr["DescGradoRemunerativo"].ToString(),
                            DescRegimenLaboral = dr["DescRegimenLaboral"].ToString(),
                            DescCarreraUniversitariaEspecialidad = dr["DescCarreraUniversitariaEspecialidad"].ToString(),
                            DescSistemaPension = dr["DescSistemaPension"].ToString(),
                            FechaIngresoInstPCivil = (dr["FechaIngresoInstPCivil"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescDependencia = dr["NombreDependencia"].ToString(),
                            DescDistritoLaboraPCivil = dr["DescDistritoNacimientoPCivil"].ToString(),
                            FechaIngresoPCivil = (dr["FechaIngresoPCivil"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaNacimientoPCivil = (dr["FechaNacimientoPCivil"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescDistritoNacimientoPCivil = dr["DescDistritoLaboraPCivil"].ToString(),
                            EstadoCivilPCivil = dr["EstadoCivilPCivil"].ToString(),
                            DescGradoEstudioAlcanzado = dr["DescGradoEstudioAlcanzado"].ToString(),
                            GradoAñoEstudioPSPCivil = dr["GradoAñoEstudioPSPCivil"].ToString(),
                            AnioServicioPCivil = Convert.ToInt32(dr["AnioServicioPCivil"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });

                    }

                }
            }
            return lista;
        }

        public string AgregarRegistro(PersonalCivilDTO personalCivilDTO, string fechacarga)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PersonalCivilRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoDocumentoPCivil", SqlDbType.VarChar,10);
                    cmd.Parameters["@TipoDocumentoPCivil"].Value = personalCivilDTO.TipoDocumentoPCivil;

                    cmd.Parameters.Add("@DNIPCivil", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPCivil"].Value = personalCivilDTO.DNIPCivil;

                    cmd.Parameters.Add("@SexoPCivil", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoPCivil"].Value = personalCivilDTO.SexoPCivil;

                    cmd.Parameters.Add("@CondicionLaboralCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CondicionLaboralCivil"].Value = personalCivilDTO.CodigoCondicionLaboralCivil;

                    cmd.Parameters.Add("@CodigoGrupoOcupacionalCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGrupoOcupacionalCivil"].Value = personalCivilDTO.CodigoGrupoOcupacionalCivil;

                    cmd.Parameters.Add("@NivelCargoPCivil", SqlDbType.VarChar, 40);
                    cmd.Parameters["@NivelCargoPCivil"].Value = personalCivilDTO.NivelCargoPCivil;

                    cmd.Parameters.Add("@CodigoGrupoRemunerativo", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoGrupoRemunerativo"].Value = personalCivilDTO.CodigoGrupoRemunerativo;

                    cmd.Parameters.Add("@CodigoGradoRemunerativo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoRemunerativo"].Value = personalCivilDTO.CodigoGradoRemunerativo;

                    cmd.Parameters.Add("@CodigoRegimenLaboral", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoRegimenLaboral"].Value = personalCivilDTO.CodigoRegimenLaboral;

                    cmd.Parameters.Add("@CodigoCarreraUniversitariaEspecialidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitariaEspecialidad"].Value = personalCivilDTO.CodigoCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@CodigoSistemaPension", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaPension"].Value = personalCivilDTO.CodigoSistemaPension;

                    cmd.Parameters.Add("@FechaIngresoInstPCivil", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoInstPCivil"].Value = personalCivilDTO.FechaIngresoInstPCivil;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = personalCivilDTO.CodigoDependencia;

                    cmd.Parameters.Add("@DistritoLaboraPCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoLaboraPCivil"].Value = personalCivilDTO.DistritoLaboraPCivil;

                    cmd.Parameters.Add("@FechaIngresoPCivil", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoPCivil"].Value = personalCivilDTO.FechaIngresoPCivil;

                    cmd.Parameters.Add("@FechaNacimientoPCivil", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimientoPCivil"].Value = personalCivilDTO.FechaNacimientoPCivil;

                    cmd.Parameters.Add("@DistritoNacimientoPCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoNacimientoPCivil"].Value = personalCivilDTO.DistritoNacimientoPCivil;

                    cmd.Parameters.Add("@EstadoCivilPCivil", SqlDbType.VarChar,15);
                    cmd.Parameters["@EstadoCivilPCivil"].Value = personalCivilDTO.EstadoCivilPCivil;

                    cmd.Parameters.Add("@CodigoGradoEstudioAlcanzado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoEstudioAlcanzado"].Value = personalCivilDTO.CodigoGradoEstudioAlcanzado;

                    cmd.Parameters.Add("@GradoAñoEstudioPSPCivil", SqlDbType.VarChar, 50);
                    cmd.Parameters["@GradoAñoEstudioPSPCivil"].Value = personalCivilDTO.GradoAñoEstudioPSPCivil;

                    cmd.Parameters.Add("@AnioServicioPCivil", SqlDbType.Int);
                    cmd.Parameters["@AnioServicioPCivil"].Value = personalCivilDTO.AnioServicioPCivil;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = personalCivilDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personalCivilDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fechacarga;

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

        public PersonalCivilDTO BuscarFormato(int Codigo)
        {
            PersonalCivilDTO personalCivilDTO = new PersonalCivilDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PersonalCivilEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalCivilId", SqlDbType.Int);
                    cmd.Parameters["@PersonalCivilId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        personalCivilDTO.PersonalCivilId = Convert.ToInt32(dr["PersonalCivilId"]);
                        personalCivilDTO.TipoDocumentoPCivil = dr["TipoDocumentoPCivil"].ToString();
                        personalCivilDTO.DNIPCivil = dr["DNIPCivil"].ToString();
                        personalCivilDTO.SexoPCivil = dr["SexoPCivil"].ToString();
                        personalCivilDTO.CodigoCondicionLaboralCivil = dr["CodigoCondicionLaboralCivil"].ToString();
                        personalCivilDTO.CodigoGrupoOcupacionalCivil = dr["CodigoGrupoOcupacionalCivil"].ToString();
                        personalCivilDTO.NivelCargoPCivil = dr["NivelCargoPCivil"].ToString();
                        personalCivilDTO.CodigoGrupoRemunerativo = dr["CodigoGrupoRemunerativo"].ToString();
                        personalCivilDTO.CodigoGradoRemunerativo = dr["CodigoGradoRemunerativo"].ToString();
                        personalCivilDTO.CodigoRegimenLaboral = dr["CodigoRegimenLaboral"].ToString();
                        personalCivilDTO.CodigoCarreraUniversitariaEspecialidad = dr["CodigoCarreraUniversitariaEspecialidad"].ToString();
                        personalCivilDTO.CodigoSistemaPension = dr["CodigoSistemaPension"].ToString();
                        personalCivilDTO.FechaIngresoInstPCivil = Convert.ToDateTime(dr["FechaIngresoInstPCivil"]).ToString("yyy-MM-dd");
                        personalCivilDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        personalCivilDTO.DistritoLaboraPCivil = dr["DistritoLaboraPCivil"].ToString();
                        personalCivilDTO.FechaIngresoPCivil = Convert.ToDateTime(dr["FechaIngresoPCivil"]).ToString("yyy-MM-dd");
                        personalCivilDTO.FechaNacimientoPCivil = Convert.ToDateTime(dr["FechaNacimientoPCivil"]).ToString("yyy-MM-dd");
                        personalCivilDTO.DistritoNacimientoPCivil = dr["DistritoNacimientoPCivil"].ToString();
                        personalCivilDTO.EstadoCivilPCivil = Regex.Replace(dr["EstadoCivilPCivil"].ToString(), @"\s", "");
                        personalCivilDTO.CodigoGradoEstudioAlcanzado = dr["CodigoGradoEstudioAlcanzado"].ToString();
                        personalCivilDTO.GradoAñoEstudioPSPCivil = dr["GradoAñoEstudioPSPCivil"].ToString();
                        personalCivilDTO.AnioServicioPCivil = Convert.ToInt32(dr["AnioServicioPCivil"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return personalCivilDTO;
        }

        public string ActualizaFormato(PersonalCivilDTO personalCivilDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PersonalCivilActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalCivilId", SqlDbType.Int);
                    cmd.Parameters["@PersonalCivilId"].Value = personalCivilDTO.PersonalCivilId;

                    cmd.Parameters.Add("@DNIPCivil", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPCivil"].Value = personalCivilDTO.DNIPCivil;

                    cmd.Parameters.Add("@SexoPCivil", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPCivil"].Value = personalCivilDTO.SexoPCivil;

                    cmd.Parameters.Add("@CodigoCondicionLaboralCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionLaboralCivil"].Value = personalCivilDTO.CodigoCondicionLaboralCivil;

                    cmd.Parameters.Add("@CodigoGrupoOcupacionalCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGrupoOcupacionalCivil"].Value = personalCivilDTO.CodigoGrupoOcupacionalCivil;

                    cmd.Parameters.Add("@NivelCargoPCivil", SqlDbType.VarChar, 40);
                    cmd.Parameters["@NivelCargoPCivil"].Value = personalCivilDTO.NivelCargoPCivil;

                    cmd.Parameters.Add("@CodigoGrupoRemunerativo", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoGrupoRemunerativo"].Value = personalCivilDTO.CodigoGrupoRemunerativo;

                    cmd.Parameters.Add("@CodigoGradoRemunerativo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoRemunerativo"].Value = personalCivilDTO.CodigoGradoRemunerativo;

                    cmd.Parameters.Add("@CodigoRegimenLaboral", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoRegimenLaboral"].Value = personalCivilDTO.CodigoRegimenLaboral;

                    cmd.Parameters.Add("@CodigoCarreraUniversitariaEspecialidad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCarreraUniversitariaEspecialidad"].Value = personalCivilDTO.CodigoCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@CodigoSistemaPension", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaPension"].Value = personalCivilDTO.CodigoSistemaPension;

                    cmd.Parameters.Add("@FechaIngresoInstPCivil", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoInstPCivil"].Value = personalCivilDTO.FechaIngresoInstPCivil;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = personalCivilDTO.CodigoDependencia;

                    cmd.Parameters.Add("@DistritoLaboraPCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoLaboraPCivil"].Value = personalCivilDTO.DistritoLaboraPCivil;

                    cmd.Parameters.Add("@FechaIngresoPCivil", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoPCivil"].Value = personalCivilDTO.FechaIngresoPCivil;

                    cmd.Parameters.Add("@FechaNacimientoPCivil", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimientoPCivil"].Value = personalCivilDTO.FechaNacimientoPCivil;

                    cmd.Parameters.Add("@DistritoNacimientoPCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoNacimientoPCivil"].Value = personalCivilDTO.DistritoNacimientoPCivil;

                    cmd.Parameters.Add("@EstadoCivilPCivil", SqlDbType.VarChar, 15);
                    cmd.Parameters["@EstadoCivilPCivil"].Value = personalCivilDTO.EstadoCivilPCivil;

                    cmd.Parameters.Add("@CodigoGradoEstudioAlcanzado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoEstudioAlcanzado"].Value = personalCivilDTO.CodigoGradoEstudioAlcanzado;

                    cmd.Parameters.Add("@GradoAñoEstudioPSPCivil", SqlDbType.VarChar, 50);
                    cmd.Parameters["@GradoAñoEstudioPSPCivil"].Value = personalCivilDTO.GradoAñoEstudioPSPCivil;

                    cmd.Parameters.Add("@AnioServicioPCivil", SqlDbType.Int);
                    cmd.Parameters["@AnioServicioPCivil"].Value = personalCivilDTO.AnioServicioPCivil;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personalCivilDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(PersonalCivilDTO personalCivilDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PersonalCivilEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalCivilId", SqlDbType.Int);
                    cmd.Parameters["@PersonalCivilId"].Value = personalCivilDTO.PersonalCivilId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personalCivilDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(PersonalCivilDTO personalCivilDTO)
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
                    cmd.Parameters["@Formato"].Value = "PersonalCivil";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = personalCivilDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personalCivilDTO.UsuarioIngresoRegistro;

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


        public string InsertarDatos(DataTable datos, string fechacarga)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_PersonalCivilRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalCivil", SqlDbType.Structured);
                    cmd.Parameters["@PersonalCivil"].TypeName = "Formato.PersonalCivil";
                    cmd.Parameters["@PersonalCivil"].Value = datos;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fechacarga;

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
