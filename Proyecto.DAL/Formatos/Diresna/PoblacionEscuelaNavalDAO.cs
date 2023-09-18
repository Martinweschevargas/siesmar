using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diresna;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diresna
{
    public class PoblacionEscuelaNavalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PoblacionEscuelaNavalDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<PoblacionEscuelaNavalDTO> lista = new List<PoblacionEscuelaNavalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PoblacionEscuelaNavalListar", conexion);
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
                        lista.Add(new PoblacionEscuelaNavalDTO()
                        {
                            PoblacionEscuelaNavalId = Convert.ToInt32(dr["PoblacionEscuelaNavalId"]),
                            DNIEstudianteEsna = dr["DNIEstudianteEsna"].ToString(),
                            SexoEstudianteEsna = dr["SexoEstudianteEsna"].ToString(),
                            FechaNacimientoEstudiante = (dr["FechaNacimientoEstudiante"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            TallaEstudianteEsna = Convert.ToDecimal(dr["TallaEstudianteEsna"]),
                            PesoEstudianteEsna = Convert.ToDecimal(dr["PesoEstudianteEsna"]),
                            DescDistritoNacimiento = dr["DescDistrito"].ToString(),
                            DescDistritoDomicilio = dr["DescDistrito"].ToString(),
                            FechaIngresoEstudiante = (dr["FechaIngresoEstudiante"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            BecadoEsna = dr["BecadoEsna"].ToString(),
                            DescDistritoProcedencia = dr["DescDistrito"].ToString(),
                            DescAnioAcademicoEsna = dr["DescAnioAcademicoEsna"].ToString(),
                            SemestreAcademico = dr["SemestreAcademico"].ToString(),
                            IRASEstudianteEsna = Convert.ToDecimal(dr["IRASEstudianteEsna"]),
                            NotaCaracterMilitar = Convert.ToDecimal(dr["NotaCaracterMilitar"]),
                            NotaFormacionFisica = Convert.ToDecimal(dr["NotaFormacionFisica"]),
                            NotaConductaEstudiante = Convert.ToDecimal(dr["NotaConductaEstudiante"]),
                            IRGSEstudianteEsna = Convert.ToDecimal(dr["IRGSEstudianteEsna"]),
                            IRGASEstudianteEsna = Convert.ToDecimal(dr["IRGASEstudianteEsna"]),
                            OrdenMerito = Convert.ToInt32(dr["OrdenMerito"]),
                            DescResultadoTerminoSemestre = dr["DescResultadoTerminoSemestre"].ToString(),
                            DescCausalBaja = dr["DescCausalBaja"].ToString(),
                            DescTipoAdmisionIngreso = dr["DescTipoAdmisionIngreso"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(PoblacionEscuelaNavalDTO poblacionEscuelaNavalDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PoblacionEscuelaNavalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIEstudianteEsna", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIEstudianteEsna"].Value = poblacionEscuelaNavalDTO.DNIEstudianteEsna;

                    cmd.Parameters.Add("@SexoEstudianteEsna", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoEstudianteEsna"].Value = poblacionEscuelaNavalDTO.SexoEstudianteEsna;

                    cmd.Parameters.Add("@FechaNacimientoEstudiante", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimientoEstudiante"].Value = poblacionEscuelaNavalDTO.FechaNacimientoEstudiante;

                    cmd.Parameters.Add("@TallaEstudianteEsna", SqlDbType.Decimal);
                    cmd.Parameters["@TallaEstudianteEsna"].Value = poblacionEscuelaNavalDTO.TallaEstudianteEsna;

                    cmd.Parameters.Add("@PesoEstudianteEsna", SqlDbType.Decimal);
                    cmd.Parameters["@PesoEstudianteEsna"].Value = poblacionEscuelaNavalDTO.PesoEstudianteEsna;

                    cmd.Parameters.Add("@DistritoNacimientoEstudiante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoNacimientoEstudiante"].Value = poblacionEscuelaNavalDTO.DistritoNacimientoEstudiante;

                    cmd.Parameters.Add("@DistritoDomicilioEstudiante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoDomicilioEstudiante "].Value = poblacionEscuelaNavalDTO.DistritoDomicilioEstudiante;

                    cmd.Parameters.Add("@FechaIngresoEstudiante", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoEstudiante"].Value = poblacionEscuelaNavalDTO.FechaIngresoEstudiante;

                    cmd.Parameters.Add("@BecadoEsna", SqlDbType.VarChar,10);
                    cmd.Parameters["@BecadoEsna"].Value = poblacionEscuelaNavalDTO.BecadoEsna;

                    cmd.Parameters.Add("@DistritoProcedencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoProcedencia"].Value = poblacionEscuelaNavalDTO.DistritoProcedencia;

                    cmd.Parameters.Add("@CodigoAnioAcademicoEsna", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAnioAcademicoEsna"].Value = poblacionEscuelaNavalDTO.CodigoAnioAcademicoEsna;

                    cmd.Parameters.Add("@SemestreAcademico", SqlDbType.VarChar,50);
                    cmd.Parameters["@SemestreAcademico"].Value = poblacionEscuelaNavalDTO.SemestreAcademico;

                    cmd.Parameters.Add("@IRASEstudianteEsna", SqlDbType.Decimal);
                    cmd.Parameters["@IRASEstudianteEsna"].Value = poblacionEscuelaNavalDTO.IRASEstudianteEsna;

                    cmd.Parameters.Add("@NotaCaracterMilitar", SqlDbType.Decimal);
                    cmd.Parameters["@NotaCaracterMilitar"].Value = poblacionEscuelaNavalDTO.NotaCaracterMilitar;

                    cmd.Parameters.Add("@NotaFormacionFisica", SqlDbType.Decimal);
                    cmd.Parameters["@NotaFormacionFisica"].Value = poblacionEscuelaNavalDTO.NotaFormacionFisica;

                    cmd.Parameters.Add("@NotaConductaEstudiante", SqlDbType.Decimal);
                    cmd.Parameters["@NotaConductaEstudiante"].Value = poblacionEscuelaNavalDTO.NotaConductaEstudiante;

                    cmd.Parameters.Add("@IRGSEstudianteEsna", SqlDbType.Decimal);
                    cmd.Parameters["@IRGSEstudianteEsna"].Value = poblacionEscuelaNavalDTO.IRGSEstudianteEsna;

                    cmd.Parameters.Add("@IRGASEstudianteEsna", SqlDbType.Decimal);
                    cmd.Parameters["@IRGASEstudianteEsna"].Value = poblacionEscuelaNavalDTO.IRGASEstudianteEsna;

                    cmd.Parameters.Add("@OrdenMerito", SqlDbType.Int);
                    cmd.Parameters["@OrdenMerito"].Value = poblacionEscuelaNavalDTO.OrdenMerito;

                    cmd.Parameters.Add("@CodigoResultadoTerminoSemestre", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoResultadoTerminoSemestre"].Value = poblacionEscuelaNavalDTO.CodigoResultadoTerminoSemestre;

                    cmd.Parameters.Add("@CodigoCausalBaja", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCausalBaja"].Value = poblacionEscuelaNavalDTO.CodigoCausalBaja;

                    cmd.Parameters.Add("@CodigoTipoAdmisionIngreso", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoAdmisionIngreso"].Value = poblacionEscuelaNavalDTO.CodigoTipoAdmisionIngreso;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = poblacionEscuelaNavalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = poblacionEscuelaNavalDTO.UsuarioIngresoRegistro;

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

        public PoblacionEscuelaNavalDTO BuscarFormato(int Codigo)
        {
            PoblacionEscuelaNavalDTO poblacionEscuelaNavalDTO = new PoblacionEscuelaNavalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PoblacionEscuelaNavalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PoblacionEscuelaNavalId", SqlDbType.Int);
                    cmd.Parameters["@PoblacionEscuelaNavalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        poblacionEscuelaNavalDTO.PoblacionEscuelaNavalId = Convert.ToInt32(dr["PoblacionEscuelaNavalId"]);
                        poblacionEscuelaNavalDTO.DNIEstudianteEsna = dr["DNIEstudianteEsna"].ToString();
                        poblacionEscuelaNavalDTO.SexoEstudianteEsna = dr["SexoEstudianteEsna"].ToString();
                        poblacionEscuelaNavalDTO.FechaNacimientoEstudiante = Convert.ToDateTime(dr["FechaNacimientoEstudiante"]).ToString("yyy-MM-dd");
                        poblacionEscuelaNavalDTO.TallaEstudianteEsna = Convert.ToDecimal(dr["TallaEstudianteEsna"]);
                        poblacionEscuelaNavalDTO.PesoEstudianteEsna = Convert.ToDecimal(dr["PesoEstudianteEsna"]);
                        poblacionEscuelaNavalDTO.DistritoNacimientoEstudiante = dr["DistritoNacimientoEstudiante "].ToString();
                        poblacionEscuelaNavalDTO.DistritoDomicilioEstudiante = dr["DistritoDomicilioEstudiante "].ToString();
                        poblacionEscuelaNavalDTO.FechaIngresoEstudiante = Convert.ToDateTime(dr["FechaIngresoEstudiante"]).ToString("yyy-MM-dd");
                        poblacionEscuelaNavalDTO.BecadoEsna = dr["BecadoEsna"].ToString();
                        poblacionEscuelaNavalDTO.DistritoProcedencia = dr["DistritoProcedencia "].ToString();
                        poblacionEscuelaNavalDTO.CodigoAnioAcademicoEsna = dr["CodigoAnioAcademicoEsna "].ToString();
                        poblacionEscuelaNavalDTO.SemestreAcademico = dr["SemestreAcademico"].ToString();
                        poblacionEscuelaNavalDTO.IRASEstudianteEsna = Convert.ToDecimal(dr["IRASEstudianteEsna"]);
                        poblacionEscuelaNavalDTO.NotaCaracterMilitar = Convert.ToDecimal(dr["NotaCaracterMilitar"]);
                        poblacionEscuelaNavalDTO.NotaFormacionFisica = Convert.ToDecimal(dr["NotaFormacionFisica"]);
                        poblacionEscuelaNavalDTO.NotaConductaEstudiante = Convert.ToDecimal(dr["NotaConductaEstudiante"]);
                        poblacionEscuelaNavalDTO.IRGSEstudianteEsna = Convert.ToDecimal(dr["IRGSEstudianteEsna"]);
                        poblacionEscuelaNavalDTO.IRGASEstudianteEsna = Convert.ToDecimal(dr["IRGASEstudianteEsna"]);
                        poblacionEscuelaNavalDTO.OrdenMerito = Convert.ToInt32(dr["OrdenMerito"]);
                        poblacionEscuelaNavalDTO.CodigoResultadoTerminoSemestre = dr["CodigoResultadoTerminoSemestre "].ToString();
                        poblacionEscuelaNavalDTO.CodigoCausalBaja = dr["CodigoCausalBaja "].ToString();
                        poblacionEscuelaNavalDTO.CodigoTipoAdmisionIngreso = dr["CodigoTipoAdmisionIngreso "].ToString();

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return poblacionEscuelaNavalDTO;
        }

        public string ActualizaFormato(PoblacionEscuelaNavalDTO poblacionEscuelaNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PoblacionEscuelaNavalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@PoblacionEscuelaNavalId", SqlDbType.Int);
                    cmd.Parameters["@PoblacionEscuelaNavalId"].Value = poblacionEscuelaNavalDTO.PoblacionEscuelaNavalId;

                    cmd.Parameters.Add("@DNIEstudianteEsna", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIEstudianteEsna"].Value = poblacionEscuelaNavalDTO.DNIEstudianteEsna;

                    cmd.Parameters.Add("@SexoEstudianteEsna", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoEstudianteEsna"].Value = poblacionEscuelaNavalDTO.SexoEstudianteEsna;

                    cmd.Parameters.Add("@FechaNacimientoEstudiante", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimientoEstudiante"].Value = poblacionEscuelaNavalDTO.FechaNacimientoEstudiante;

                    cmd.Parameters.Add("@TallaEstudianteEsna", SqlDbType.Decimal);
                    cmd.Parameters["@TallaEstudianteEsna"].Value = poblacionEscuelaNavalDTO.TallaEstudianteEsna;

                    cmd.Parameters.Add("@PesoEstudianteEsna", SqlDbType.Decimal);
                    cmd.Parameters["@PesoEstudianteEsna"].Value = poblacionEscuelaNavalDTO.PesoEstudianteEsna;

                    cmd.Parameters.Add("@DistritoNacimientoEstudiante ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoNacimientoEstudiante "].Value = poblacionEscuelaNavalDTO.DistritoNacimientoEstudiante;

                    cmd.Parameters.Add("@DistritoDomicilioEstudiante ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoDomicilioEstudiante "].Value = poblacionEscuelaNavalDTO.DistritoDomicilioEstudiante;

                    cmd.Parameters.Add("@FechaIngresoEstudiante", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoEstudiante"].Value = poblacionEscuelaNavalDTO.FechaIngresoEstudiante;

                    cmd.Parameters.Add("@BecadoEsna", SqlDbType.VarChar, 10);
                    cmd.Parameters["@BecadoEsna"].Value = poblacionEscuelaNavalDTO.BecadoEsna;

                    cmd.Parameters.Add("@DistritoProcedencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoProcedencia"].Value = poblacionEscuelaNavalDTO.DistritoProcedencia;

                    cmd.Parameters.Add("@CodigoAnioAcademicoEsna ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAnioAcademicoEsna "].Value = poblacionEscuelaNavalDTO.CodigoAnioAcademicoEsna;

                    cmd.Parameters.Add("@SemestreAcademico", SqlDbType.VarChar, 50);
                    cmd.Parameters["@SemestreAcademico"].Value = poblacionEscuelaNavalDTO.SemestreAcademico;

                    cmd.Parameters.Add("@IRASEstudianteEsna", SqlDbType.Decimal);
                    cmd.Parameters["@IRASEstudianteEsna"].Value = poblacionEscuelaNavalDTO.IRASEstudianteEsna;

                    cmd.Parameters.Add("@NotaCaracterMilitar", SqlDbType.Decimal);
                    cmd.Parameters["@NotaCaracterMilitar"].Value = poblacionEscuelaNavalDTO.NotaCaracterMilitar;

                    cmd.Parameters.Add("@NotaFormacionFisica", SqlDbType.Decimal);
                    cmd.Parameters["@NotaFormacionFisica"].Value = poblacionEscuelaNavalDTO.NotaFormacionFisica;

                    cmd.Parameters.Add("@NotaConductaEstudiante", SqlDbType.Decimal);
                    cmd.Parameters["@NotaConductaEstudiante"].Value = poblacionEscuelaNavalDTO.NotaConductaEstudiante;

                    cmd.Parameters.Add("@IRGSEstudianteEsna", SqlDbType.Decimal);
                    cmd.Parameters["@IRGSEstudianteEsna"].Value = poblacionEscuelaNavalDTO.IRGSEstudianteEsna;

                    cmd.Parameters.Add("@IRGASEstudianteEsna", SqlDbType.Decimal);
                    cmd.Parameters["@IRGASEstudianteEsna"].Value = poblacionEscuelaNavalDTO.IRGASEstudianteEsna;

                    cmd.Parameters.Add("@OrdenMerito", SqlDbType.Int);
                    cmd.Parameters["@OrdenMerito"].Value = poblacionEscuelaNavalDTO.OrdenMerito;

                    cmd.Parameters.Add("@CodigoResultadoTerminoSemestre ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoResultadoTerminoSemestre "].Value = poblacionEscuelaNavalDTO.CodigoResultadoTerminoSemestre;

                    cmd.Parameters.Add("@CodigoCausalBaja ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCausalBaja "].Value = poblacionEscuelaNavalDTO.CodigoCausalBaja;

                    cmd.Parameters.Add("@CodigoTipoAdmisionIngreso ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoAdmisionIngreso "].Value = poblacionEscuelaNavalDTO.CodigoTipoAdmisionIngreso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = poblacionEscuelaNavalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(PoblacionEscuelaNavalDTO poblacionEscuelaNavalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PoblacionEscuelaNavalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PoblacionEscuelaNavalId", SqlDbType.Int);
                    cmd.Parameters["@PoblacionEscuelaNavalId"].Value = poblacionEscuelaNavalDTO.PoblacionEscuelaNavalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = poblacionEscuelaNavalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(PoblacionEscuelaNavalDTO poblacionEscuelaNavalDTO)
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
                    cmd.Parameters["@Formato"].Value = "PoblacionEscuelaNaval";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = poblacionEscuelaNavalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = poblacionEscuelaNavalDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_PoblacionEscuelaNavalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PoblacionEscuelaNaval", SqlDbType.Structured);
                    cmd.Parameters["@PoblacionEscuelaNaval"].TypeName = "Formato.PoblacionEscuelaNaval";
                    cmd.Parameters["@PoblacionEscuelaNaval"].Value = datos;

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
