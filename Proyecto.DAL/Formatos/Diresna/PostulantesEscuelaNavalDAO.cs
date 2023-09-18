using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diresna;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diresna
{
    public class PostulantesEscuelaNavalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PostulantesEscuelaNavalDTO> ObtenerLista(int? CargaId = null)
        {
            List<PostulantesEscuelaNavalDTO> lista = new List<PostulantesEscuelaNavalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PostulantesEscuelaNavalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PostulantesEscuelaNavalDTO()
                        {
                            PostulanteEscuelaNavalId = Convert.ToInt32(dr["PostulanteEscuelaNavalId"]),
                            DNIPostulante = dr["DNIPostulante"].ToString(),
                            SexoPostulante = dr["SexoPostulante"].ToString(),
                            FechaNacimientoPostulante = (dr["FechaNacimientoPostulante"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            TallaPostulante = Convert.ToDecimal(dr["TallaPostulante"]),
                            PesoPostulante = Convert.ToDecimal(dr["PesoPostulante"]),
                            DescDistritoNacimiento = dr["DescDistritoNacimiento"].ToString(),
                            DescDistritoDomicilio = dr["DescDistritoDomicilio"].ToString(),
                            TipoInstitucionEducativa = dr["TipoInstitucionEducativa"].ToString(),
                            DescInstitucionEducativa = dr["DescInstitucionEducativa"].ToString(),
                            DescDistritoInstitucion = dr["DescDistritoInstitucion"].ToString(),
                            PadresMilitar = dr["PadresMilitar"].ToString(),
                            DescEntidadMilitar = dr["DescEntidadMilitar"].ToString(),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescCarreraUniversitariaEspecialidad = dr["DescCarreraUniversitariaEspecialidad"].ToString(),
                            ConcursoAdmision = dr["ConcursoAdmision"].ToString(),
                            DescModalidadIngresoEsna = dr["DescModalidadIngresoEsna"].ToString(),
                            TipoPreparacion = dr["TipoPreparacion"].ToString(),
                            DeportistaCalificado = dr["DeportistaCalificado"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            QVecesPostulacion = Convert.ToInt32(dr["QVecesPostulacion"]),
                            DescPublicidadEsna = dr["DescPublicidadEsna"].ToString(),
                            SituacionIngreso = dr["SituacionIngreso"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(PostulantesEscuelaNavalDTO postulantesEscuelaNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PostulantesEscuelaNavalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIPostulante", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPostulante"].Value = postulantesEscuelaNavalDTO.DNIPostulante;

                    cmd.Parameters.Add("@SexoPostulante", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoPostulante"].Value = postulantesEscuelaNavalDTO.SexoPostulante;

                    cmd.Parameters.Add("@FechaNacimientoPostulante", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimientoPostulante"].Value = postulantesEscuelaNavalDTO.FechaNacimientoPostulante;

                    cmd.Parameters.Add("@TallaPostulante", SqlDbType.Decimal);
                    cmd.Parameters["@TallaPostulante"].Value = postulantesEscuelaNavalDTO.TallaPostulante;

                    cmd.Parameters.Add("@PesoPostulante", SqlDbType.Decimal);
                    cmd.Parameters["@PesoPostulante"].Value = postulantesEscuelaNavalDTO.PesoPostulante;

                    cmd.Parameters.Add("@UbigeoNacimiento ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@UbigeoNacimiento "].Value = postulantesEscuelaNavalDTO.UbigeoNacimiento;

                    cmd.Parameters.Add("@UbigeoDomicilio ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@UbigeoDomicilio "].Value = postulantesEscuelaNavalDTO.UbigeoDomicilio;

                    cmd.Parameters.Add("@TipoInstitucionEducativa", SqlDbType.VarChar,10);
                    cmd.Parameters["@TipoInstitucionEducativa"].Value = postulantesEscuelaNavalDTO.TipoInstitucionEducativa;

                    cmd.Parameters.Add("@CodigoInstitucionEducativa ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInstitucionEducativa "].Value = postulantesEscuelaNavalDTO.CodigoInstitucionEducativa;

                    cmd.Parameters.Add("@UbigeoInstitucion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@UbigeoInstitucion "].Value = postulantesEscuelaNavalDTO.UbigeoInstitucion;

                    cmd.Parameters.Add("@PadresMilitar", SqlDbType.VarChar,10);
                    cmd.Parameters["@PadresMilitar"].Value = postulantesEscuelaNavalDTO.PadresMilitar;

                    cmd.Parameters.Add("@CodigoEntidadMilitar ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadMilitar "].Value = postulantesEscuelaNavalDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar "].Value = postulantesEscuelaNavalDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoCarreraUniversitariaEspecialidad ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitariaEspecialidad "].Value = postulantesEscuelaNavalDTO.CodigoCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@ConcursoAdmision", SqlDbType.VarChar,10);
                    cmd.Parameters["@ConcursoAdmision"].Value = postulantesEscuelaNavalDTO.ConcursoAdmision;

                    cmd.Parameters.Add("@CodigoModalidadIngresoEsna ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoModalidadIngresoEsna "].Value = postulantesEscuelaNavalDTO.CodigoModalidadIngresoEsna;

                    cmd.Parameters.Add("@TipoPreparacion", SqlDbType.VarChar,50);
                    cmd.Parameters["@TipoPreparacion"].Value = postulantesEscuelaNavalDTO.TipoPreparacion;

                    cmd.Parameters.Add("@DeportistaCalificado", SqlDbType.VarChar,10);
                    cmd.Parameters["@DeportistaCalificado"].Value = postulantesEscuelaNavalDTO.DeportistaCalificado;

                    cmd.Parameters.Add("@CodigoZonaNaval ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval "].Value = postulantesEscuelaNavalDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@QVecesPostulacion", SqlDbType.Int);
                    cmd.Parameters["@QVecesPostulacion"].Value = postulantesEscuelaNavalDTO.QVecesPostulacion;

                    cmd.Parameters.Add("@CodigoPublicidadEsna", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPublicidadEsna "].Value = postulantesEscuelaNavalDTO.CodigoPublicidadEsna;

                    cmd.Parameters.Add("@SituacionIngreso", SqlDbType.VarChar);
                    cmd.Parameters["@SituacionIngreso"].Value = postulantesEscuelaNavalDTO.SituacionIngreso;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = postulantesEscuelaNavalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = postulantesEscuelaNavalDTO.UsuarioIngresoRegistro;

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

        public PostulantesEscuelaNavalDTO BuscarFormato(int Codigo)
        {
            PostulantesEscuelaNavalDTO postulantesEscuelaNavalDTO = new PostulantesEscuelaNavalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PostulantesEscuelaNavalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PostulanteEscuelaNavalId", SqlDbType.Int);
                    cmd.Parameters["@PostulanteEscuelaNavalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        postulantesEscuelaNavalDTO.PostulanteEscuelaNavalId = Convert.ToInt32(dr["PostulanteEscuelaNavalId"]);
                        postulantesEscuelaNavalDTO.DNIPostulante = dr["DNIPostulante"].ToString();
                        postulantesEscuelaNavalDTO.SexoPostulante = dr["SexoPostulante"].ToString();
                        postulantesEscuelaNavalDTO.FechaNacimientoPostulante = Convert.ToDateTime(dr["FechaNacimientoPostulante"]).ToString("yyy-MM-dd");
                        postulantesEscuelaNavalDTO.TallaPostulante = Convert.ToDecimal(dr["TallaPostulante"]);
                        postulantesEscuelaNavalDTO.PesoPostulante = Convert.ToDecimal(dr["PesoPostulante"]);
                        postulantesEscuelaNavalDTO.UbigeoNacimiento = dr["UbigeoNacimiento "].ToString();
                        postulantesEscuelaNavalDTO.UbigeoDomicilio = dr["UbigeoDomicilio "].ToString();
                        postulantesEscuelaNavalDTO.TipoInstitucionEducativa = dr["TipoInstitucionEducativa"].ToString();
                        postulantesEscuelaNavalDTO.CodigoInstitucionEducativa = dr["CodigoInstitucionEducativa "].ToString();
                        postulantesEscuelaNavalDTO.UbigeoInstitucion = dr["UbigeoInstitucion "].ToString();
                        postulantesEscuelaNavalDTO.PadresMilitar = dr["PadresMilitar"].ToString();
                        postulantesEscuelaNavalDTO.CodigoEntidadMilitar = dr["CodigoEntidadMilitar "].ToString();
                        postulantesEscuelaNavalDTO.CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar "].ToString();
                        postulantesEscuelaNavalDTO.CodigoCarreraUniversitariaEspecialidad = dr["CodigoCarreraUniversitariaEspecialidad "].ToString();
                        postulantesEscuelaNavalDTO.ConcursoAdmision = dr["ConcursoAdmision"].ToString();
                        postulantesEscuelaNavalDTO.CodigoModalidadIngresoEsna = dr["CodigoModalidadIngresoEsna "].ToString();
                        postulantesEscuelaNavalDTO.TipoPreparacion = dr["TipoPreparacion"].ToString();
                        postulantesEscuelaNavalDTO.DeportistaCalificado = dr["DeportistaCalificado"].ToString();
                        postulantesEscuelaNavalDTO.CodigoZonaNaval = dr["CodigoZonaNaval "].ToString();
                        postulantesEscuelaNavalDTO.QVecesPostulacion = Convert.ToInt32(dr["QVecesPostulacion"]);
                        postulantesEscuelaNavalDTO.CodigoPublicidadEsna = dr["CodigoPublicidadEsna "].ToString();
                        postulantesEscuelaNavalDTO.SituacionIngreso = dr["SituacionIngreso"].ToString(); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return postulantesEscuelaNavalDTO;
        }

        public string ActualizaFormato(PostulantesEscuelaNavalDTO postulantesEscuelaNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PostulantesEscuelaNavalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@PostulanteEscuelaNavalId", SqlDbType.Int);
                    cmd.Parameters["@PostulanteEscuelaNavalId"].Value = postulantesEscuelaNavalDTO.PostulanteEscuelaNavalId;

                    cmd.Parameters.Add("@DNIPostulante", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPostulante"].Value = postulantesEscuelaNavalDTO.DNIPostulante;

                    cmd.Parameters.Add("@SexoPostulante", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPostulante"].Value = postulantesEscuelaNavalDTO.SexoPostulante;

                    cmd.Parameters.Add("@FechaNacimientoPostulante", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimientoPostulante"].Value = postulantesEscuelaNavalDTO.FechaNacimientoPostulante;

                    cmd.Parameters.Add("@TallaPostulante", SqlDbType.Decimal);
                    cmd.Parameters["@TallaPostulante"].Value = postulantesEscuelaNavalDTO.TallaPostulante;

                    cmd.Parameters.Add("@PesoPostulante", SqlDbType.Decimal);
                    cmd.Parameters["@PesoPostulante"].Value = postulantesEscuelaNavalDTO.PesoPostulante;

                    cmd.Parameters.Add("@UbigeoNacimiento ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@UbigeoNacimiento "].Value = postulantesEscuelaNavalDTO.UbigeoNacimiento;

                    cmd.Parameters.Add("@UbigeoDomicilio ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@UbigeoDomicilio "].Value = postulantesEscuelaNavalDTO.UbigeoDomicilio;

                    cmd.Parameters.Add("@TipoInstitucionEducativa", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TipoInstitucionEducativa"].Value = postulantesEscuelaNavalDTO.TipoInstitucionEducativa;

                    cmd.Parameters.Add("@CodigoInstitucionEducativa ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInstitucionEducativa "].Value = postulantesEscuelaNavalDTO.CodigoInstitucionEducativa;

                    cmd.Parameters.Add("@UbigeoInstitucion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@UbigeoInstitucion "].Value = postulantesEscuelaNavalDTO.UbigeoInstitucion;

                    cmd.Parameters.Add("@PadresMilitar", SqlDbType.VarChar, 10);
                    cmd.Parameters["@PadresMilitar"].Value = postulantesEscuelaNavalDTO.PadresMilitar;

                    cmd.Parameters.Add("@CodigoEntidadMilitar ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadMilitar "].Value = postulantesEscuelaNavalDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar "].Value = postulantesEscuelaNavalDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoCarreraUniversitariaEspecialidad ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitariaEspecialidad "].Value = postulantesEscuelaNavalDTO.CodigoCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@ConcursoAdmision", SqlDbType.VarChar, 10);
                    cmd.Parameters["@ConcursoAdmision"].Value = postulantesEscuelaNavalDTO.ConcursoAdmision;

                    cmd.Parameters.Add("@CodigoModalidadIngresoEsna ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoModalidadIngresoEsna "].Value = postulantesEscuelaNavalDTO.CodigoModalidadIngresoEsna;

                    cmd.Parameters.Add("@TipoPreparacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoPreparacion"].Value = postulantesEscuelaNavalDTO.TipoPreparacion;

                    cmd.Parameters.Add("@DeportistaCalificado", SqlDbType.VarChar, 10);
                    cmd.Parameters["@DeportistaCalificado"].Value = postulantesEscuelaNavalDTO.DeportistaCalificado;

                    cmd.Parameters.Add("@CodigoZonaNaval ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval "].Value = postulantesEscuelaNavalDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@QVecesPostulacion", SqlDbType.Int);
                    cmd.Parameters["@QVecesPostulacion"].Value = postulantesEscuelaNavalDTO.QVecesPostulacion;

                    cmd.Parameters.Add("@CodigoPublicidadEsna", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPublicidadEsna "].Value = postulantesEscuelaNavalDTO.CodigoPublicidadEsna;

                    cmd.Parameters.Add("@SituacionIngreso", SqlDbType.VarChar);
                    cmd.Parameters["@SituacionIngreso"].Value = postulantesEscuelaNavalDTO.SituacionIngreso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = postulantesEscuelaNavalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(PostulantesEscuelaNavalDTO postulantesEscuelaNavalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PostulantesEscuelaNavalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PostulantesEscuelaNavalId", SqlDbType.Int);
                    cmd.Parameters["@PostulantesEscuelaNavalId"].Value = postulantesEscuelaNavalDTO.PostulanteEscuelaNavalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = postulantesEscuelaNavalDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_PostulantesEscuelaNavalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PostulantesEscuelaNaval", SqlDbType.Structured);
                    cmd.Parameters["@PostulantesEscuelaNaval"].TypeName = "Formato.PostulantesEscuelaNaval";
                    cmd.Parameters["@PostulantesEscuelaNaval"].Value = datos;

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