using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Disamar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Disamar
{
    public class RegistroAtencionEmergenciaDAO
    {

        SqlCommand cmd = new SqlCommand();


        public List<RegistroAtencionEmergenciaDTO> ObtenerLista(int? CargaId=null)
        {
            List<RegistroAtencionEmergenciaDTO> lista = new List<RegistroAtencionEmergenciaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroAtencionEmergenciaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegistroAtencionEmergenciaDTO()
                        {
                            RegistroAtencionEmergenciaId = Convert.ToInt32(dr["RegistroAtencionEmergenciaId"]),
                            DescEntidadMilitar = dr["DescEntidadMilitar"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            DescEstablecimientoSalud = dr["DescEstablecimientoSalud"].ToString(),
                            FechaAtencion = (dr["FechaAtencion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            HoraAtencion = dr["HoraAtencion"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            DescEspecialidadMedicaNoMedica = dr["DescEspecialidadMedicaNoMedica"].ToString(),
                            ResponsableRegistro = dr["ResponsableRegistro"].ToString(),
                            NSACIP = Convert.ToInt32(dr["NSACIP"]),
                            CMP = Convert.ToInt32(dr["CMP"]),
                            Turno = dr["Turno"].ToString(),
                            HoraInicio = dr["HoraInicio"].ToString(),
                            HoraFin = dr["HoraFin"].ToString(),
                            HistoriaClinica = Convert.ToInt32(dr["HistoriaClinica"]),
                            DNIPaciente = dr["DNIPaciente"].ToString(),
                            DescUnidadDependencia = dr["DescUnidadDependencia"].ToString(),
                            DescDistritroPaciente = dr["DescDistrito"].ToString(),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            SituacionPaciente = dr["SituacionPaciente"].ToString(),
                            CondicionPaciente = dr["CondicionPaciente"].ToString(),
                            EdadPaciente = Convert.ToInt32(dr["EdadPaciente"]),
                            TipoEdad = dr["TipoEdad"].ToString(),
                            SexoPaciente = dr["SexoPaciente"].ToString(),
                            DiagnosticoMotivoAtencion1 = dr["CodigoDiagnosticoMotivoAtencion1"].ToString(),
                            TipoDX1 = dr["TipoDX1"].ToString(),
                            CIE10_1 = dr["CodigoCIE10_1"].ToString(),
                            DiagnosticoMotivoAtencion2 = dr["CodigoDiagnosticoMotivoAtencion2"].ToString(),
                            TipoDX2 = dr["TipoDX2"].ToString(),
                            CIE10_2 = dr["CodigoCIE10_2"].ToString(),
                            DiagnosticoMotivoAtencion3 = dr["CodigoDiagnosticoMotivoAtencion3"].ToString(),
                            TipoDX3 = dr["TipoDX3"].ToString(),
                            CIE10_3 = dr["CodigoCIE10_3"].ToString(),
                            DiagnosticoMotivoAtencion4 =    dr["CodigoDiagnosticoMotivoAtencion4"].ToString(),
                            TipoDX4 = dr["TipoDX4"].ToString(),
                            CIE10_4 = dr["CodigoCIE10_4"].ToString(),
                            DiagnosticoMotivoAtencion5 = dr["CodigoDiagnosticoMotivoAtencion5"].ToString(),
                            TipoDX5 = dr["TipoDX5"].ToString(),
                            CIE10_5 = dr["CodigoCIE10_5"].ToString(),
                            DiagnosticoMotivoAtencion6 = dr["CodigoDiagnosticoMotivoAtencion6"].ToString(),
                            TipoDX6 = dr["TipoDX6"].ToString(),
                            CIE10_6 = dr["CodigoCIE10_6"].ToString(),
                            TipoEmergencia = dr["TipoEmergencia"].ToString(),
                            Interconsulta = dr["Interconsulta"].ToString(),
                            EspecialidadMedicaInterconsulta = Convert.ToInt32(dr["EspecialidadMedicaInterconsulta"]),
                            DescMotivoEmergencia = dr["DescMotivoEmergencia"].ToString(),
                            Acompaniante = dr["Acompaniante"].ToString(),
                            DNIAcompaniante = dr["DNIAcompaniante"].ToString(),
                            DescCondicionAlta = dr["DescCondicionAlta"].ToString(),
                            DescDestinoPaciente = dr["DescDestinoPaciente"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RegistroAtencionEmergenciaDTO registroAtencionEmergenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroAtencionEmergenciaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = registroAtencionEmergenciaDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = registroAtencionEmergenciaDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoEstablecimientoSaludMGP", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstablecimientoSaludMGP"].Value = registroAtencionEmergenciaDTO.CodigoEstablecimientoSaludMGP;

                    cmd.Parameters.Add("@FechaAtencion", SqlDbType.Date);
                    cmd.Parameters["@FechaAtencion"].Value = registroAtencionEmergenciaDTO.FechaAtencion;

                    cmd.Parameters.Add("@HoraAtencion", SqlDbType.Time);
                    cmd.Parameters["@HoraAtencion"].Value = registroAtencionEmergenciaDTO.HoraAtencion;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = registroAtencionEmergenciaDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CodigoUPS", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUPS"].Value = registroAtencionEmergenciaDTO.CodigoUPS;

                    cmd.Parameters.Add("@ResponsableRegistro", SqlDbType.VarChar, 200);
                    cmd.Parameters["@ResponsableRegistro"].Value = registroAtencionEmergenciaDTO.ResponsableRegistro;

                    cmd.Parameters.Add("@NSACIP", SqlDbType.Int);
                    cmd.Parameters["@NSACIP"].Value = registroAtencionEmergenciaDTO.NSACIP;

                    cmd.Parameters.Add("@CMP", SqlDbType.Int);
                    cmd.Parameters["@CMP"].Value = registroAtencionEmergenciaDTO.CMP;

                    cmd.Parameters.Add("@Turno", SqlDbType.VarChar, 10);
                    cmd.Parameters["@Turno"].Value = registroAtencionEmergenciaDTO.Turno;

                    cmd.Parameters.Add("@HoraInicio", SqlDbType.Time);
                    cmd.Parameters["@HoraInicio"].Value = registroAtencionEmergenciaDTO.HoraInicio;

                    cmd.Parameters.Add("@HoraFin", SqlDbType.Time);
                    cmd.Parameters["@HoraFin"].Value = registroAtencionEmergenciaDTO.HoraFin;

                    cmd.Parameters.Add("@HistoriaClinica", SqlDbType.Int);
                    cmd.Parameters["@HistoriaClinica"].Value = registroAtencionEmergenciaDTO.HistoriaClinica;

                    cmd.Parameters.Add("@DNIPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DNIPaciente"].Value = registroAtencionEmergenciaDTO.DNIPaciente;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = registroAtencionEmergenciaDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@DistritoPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoPaciente"].Value = registroAtencionEmergenciaDTO.DistritoPaciente;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = registroAtencionEmergenciaDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = registroAtencionEmergenciaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@SituacionPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@SituacionPaciente"].Value = registroAtencionEmergenciaDTO.SituacionPaciente;

                    cmd.Parameters.Add("@CondicionPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CondicionPaciente"].Value = registroAtencionEmergenciaDTO.CondicionPaciente;

                    cmd.Parameters.Add("@EdadPaciente", SqlDbType.Int);
                    cmd.Parameters["@EdadPaciente"].Value = registroAtencionEmergenciaDTO.EdadPaciente;

                    cmd.Parameters.Add("@TipoEdad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TipoEdad"].Value = registroAtencionEmergenciaDTO.TipoEdad;

                    cmd.Parameters.Add("@SexoPaciente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPaciente"].Value = registroAtencionEmergenciaDTO.SexoPaciente;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion1", SqlDbType.Int);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion1"].Value = registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion1;

                    cmd.Parameters.Add("@TipoDX1", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX1"].Value = registroAtencionEmergenciaDTO.TipoDX1;

                    cmd.Parameters.Add("@CodigoCIE10_1", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoCIE10_1"].Value = registroAtencionEmergenciaDTO.CIE10_1;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion2", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion2"].Value = registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion2;

                    cmd.Parameters.Add("@TipoDX2", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX2"].Value = registroAtencionEmergenciaDTO.TipoDX2;

                    cmd.Parameters.Add("@CodigoCIE10_2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_2"].Value = registroAtencionEmergenciaDTO.CIE10_2;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion3", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion3"].Value = registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion3;

                    cmd.Parameters.Add("@TipoDX3", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX3"].Value = registroAtencionEmergenciaDTO.TipoDX3;

                    cmd.Parameters.Add("@CodigoCIE10_3", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_3"].Value = registroAtencionEmergenciaDTO.CIE10_3;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion4", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion4"].Value = registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion4;

                    cmd.Parameters.Add("@TipoDX4", SqlDbType.VarChar,15);
                    cmd.Parameters["@TipoDX4"].Value = registroAtencionEmergenciaDTO.TipoDX4;

                    cmd.Parameters.Add("@CodigoCIE10_4", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoCIE10_4"].Value = registroAtencionEmergenciaDTO.CIE10_4;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion5", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion5"].Value = registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion5;

                    cmd.Parameters.Add("@TipoDX5", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX5"].Value = registroAtencionEmergenciaDTO.TipoDX5;

                    cmd.Parameters.Add("@CodigoCIE10_5", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_5"].Value = registroAtencionEmergenciaDTO.CIE10_5;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion6", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion6"].Value = registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion6;

                    cmd.Parameters.Add("@TipoDX6", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX6"].Value = registroAtencionEmergenciaDTO.TipoDX6;

                    cmd.Parameters.Add("@CodigoCIE10_6", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_6"].Value = registroAtencionEmergenciaDTO.CIE10_6;

                    cmd.Parameters.Add("@TipoEmergencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@TipoEmergencia"].Value = registroAtencionEmergenciaDTO.TipoEmergencia;

                    cmd.Parameters.Add("@Interconsulta", SqlDbType.VarChar, 2);
                    cmd.Parameters["@Interconsulta"].Value = registroAtencionEmergenciaDTO.Interconsulta;

                    cmd.Parameters.Add("@EspecialidadMedicaInterconsulta", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadMedicaInterconsulta"].Value = registroAtencionEmergenciaDTO.EspecialidadMedicaInterconsulta;

                    cmd.Parameters.Add("@CodigoMotivoEmergencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMotivoEmergencia"].Value = registroAtencionEmergenciaDTO.CodigoMotivoEmergencia;

                    cmd.Parameters.Add("@Acompaniante", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Acompaniante"].Value = registroAtencionEmergenciaDTO.Acompaniante;

                    cmd.Parameters.Add("@DNIAcompaniante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DNIAcompaniante"].Value = registroAtencionEmergenciaDTO.DNIAcompaniante;

                    cmd.Parameters.Add("@CodigoCondicionAlta", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionAlta"].Value = registroAtencionEmergenciaDTO.CodigoCondicionAlta;

                    cmd.Parameters.Add("@CodigoDestinoPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDestinoPaciente"].Value = registroAtencionEmergenciaDTO.CodigoDestinoPaciente;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = registroAtencionEmergenciaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroAtencionEmergenciaDTO.UsuarioIngresoRegistro;

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

        public RegistroAtencionEmergenciaDTO BuscarFormato(int Codigo)
        {
            RegistroAtencionEmergenciaDTO registroAtencionEmergenciaDTO = new RegistroAtencionEmergenciaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroAtencionEmergenciaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroAtencionEmergenciaId", SqlDbType.Int);
                    cmd.Parameters["@RegistroAtencionEmergenciaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        registroAtencionEmergenciaDTO.RegistroAtencionEmergenciaId = Convert.ToInt32(dr["RegistroAtencionEmergenciaId"]);
                        registroAtencionEmergenciaDTO.CodigoEntidadMilitar =dr["CodigoEntidadMilitar"].ToString();
                        registroAtencionEmergenciaDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        registroAtencionEmergenciaDTO.CodigoEstablecimientoSaludMGP = dr["CodigoEstablecimientoSaludMGP"].ToString();
                        registroAtencionEmergenciaDTO.FechaAtencion = Convert.ToDateTime(dr["FechaAtencion"]).ToString("yyy-MM-dd");
                        registroAtencionEmergenciaDTO.HoraAtencion = dr["HoraAtencion"].ToString();
                        registroAtencionEmergenciaDTO.DistritoUbigeo = dr["DistritoUbigeo"].ToString();
                        registroAtencionEmergenciaDTO.CodigoUPS = dr["CodigoUPS"].ToString();
                        registroAtencionEmergenciaDTO.ResponsableRegistro = dr["ResponsableRegistro"].ToString();
                        registroAtencionEmergenciaDTO.NSACIP = Convert.ToInt32(dr["NSACIP"]);
                        registroAtencionEmergenciaDTO.CMP = Convert.ToInt32(dr["CMP"]);
                        registroAtencionEmergenciaDTO.Turno = dr["Turno"].ToString();
                        registroAtencionEmergenciaDTO.HoraInicio = dr["HoraInicio"].ToString();
                        registroAtencionEmergenciaDTO.HoraFin = dr["HoraFin"].ToString();
                        registroAtencionEmergenciaDTO.HistoriaClinica = Convert.ToInt32(dr["HistoriaClinica"]);
                        registroAtencionEmergenciaDTO.DNIPaciente = dr["DNIPaciente"].ToString();
                        registroAtencionEmergenciaDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        registroAtencionEmergenciaDTO.DistritoPaciente = dr["DistritoPaciente"].ToString();
                        registroAtencionEmergenciaDTO.CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar"].ToString();
                        registroAtencionEmergenciaDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        registroAtencionEmergenciaDTO.SituacionPaciente = dr["SituacionPaciente"].ToString();
                        registroAtencionEmergenciaDTO.CondicionPaciente = dr["CondicionPaciente"].ToString();
                        registroAtencionEmergenciaDTO.EdadPaciente = Convert.ToInt32(dr["EdadPaciente"]);
                        registroAtencionEmergenciaDTO.TipoEdad = dr["TipoEdad"].ToString();
                        registroAtencionEmergenciaDTO.SexoPaciente = dr["SexoPaciente"].ToString();
                        registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion1 = dr["CodigoDiagnosticoMotivoAtencion1"].ToString();
                        registroAtencionEmergenciaDTO.TipoDX1 = dr["TipoDX1"].ToString();
                        registroAtencionEmergenciaDTO.CIE10_1 = dr["CodigoCIE10_1"].ToString();
                        registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion2 = dr["CodigoDiagnosticoMotivoAtencion2"].ToString();
                        registroAtencionEmergenciaDTO.TipoDX2 = dr["TipoDX2"].ToString();
                        registroAtencionEmergenciaDTO.CIE10_2 = dr["CodigoCIE10_2"].ToString();
                        registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion3 = dr["CodigoDiagnosticoMotivoAtencion3"].ToString();
                        registroAtencionEmergenciaDTO.TipoDX3 = dr["TipoDX3"].ToString();
                        registroAtencionEmergenciaDTO.CIE10_3 = dr["CodigoCIE10_3"].ToString();
                        registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion4 = dr["CodigoDiagnosticoMotivoAtencion4"].ToString();
                        registroAtencionEmergenciaDTO.TipoDX4 = dr["TipoDX4"].ToString();
                        registroAtencionEmergenciaDTO.CIE10_4 = dr["CodigoCIE10_4"].ToString();
                        registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion5 = dr["CodigoDiagnosticoMotivoAtencion5"].ToString();
                        registroAtencionEmergenciaDTO.TipoDX5 = dr["TipoDX5"].ToString();
                        registroAtencionEmergenciaDTO.CIE10_5 = dr["CodigoCIE10_5"].ToString();
                        registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion6 = dr["CodigoDiagnosticoMotivoAtencion6"].ToString();
                        registroAtencionEmergenciaDTO.TipoDX6 = dr["TipoDX6"].ToString();
                        registroAtencionEmergenciaDTO.CIE10_6 = dr["CodigoCIE10_6"].ToString();
                        registroAtencionEmergenciaDTO.TipoEmergencia = dr["TipoEmergencia"].ToString();
                        registroAtencionEmergenciaDTO.Interconsulta = dr["Interconsulta"].ToString();
                        registroAtencionEmergenciaDTO.EspecialidadMedicaInterconsulta = Convert.ToInt32(dr["EspecialidadMedicaInterconsulta"]);
                        registroAtencionEmergenciaDTO.CodigoMotivoEmergencia = dr["CodigoMotivoEmergencia"].ToString();
                        registroAtencionEmergenciaDTO.Acompaniante = dr["Acompaniante"].ToString();
                        registroAtencionEmergenciaDTO.DNIAcompaniante = dr["DNIAcompaniante"].ToString();
                        registroAtencionEmergenciaDTO.CodigoCondicionAlta = dr["CodigoCondicionAlta"].ToString();
                        registroAtencionEmergenciaDTO.CodigoDestinoPaciente = dr["CodigoDestinoPaciente"].ToString(); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroAtencionEmergenciaDTO;
        }

        public string ActualizaFormato(RegistroAtencionEmergenciaDTO registroAtencionEmergenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroAtencionEmergenciaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RegistroAtencionEmergenciaId", SqlDbType.Int);
                    cmd.Parameters["@RegistroAtencionEmergenciaId"].Value = registroAtencionEmergenciaDTO.RegistroAtencionEmergenciaId;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = registroAtencionEmergenciaDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = registroAtencionEmergenciaDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoEstablecimientoSaludMGP", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstablecimientoSaludMGP"].Value = registroAtencionEmergenciaDTO.CodigoEstablecimientoSaludMGP;

                    cmd.Parameters.Add("@FechaAtencion", SqlDbType.Date);
                    cmd.Parameters["@FechaAtencion"].Value = registroAtencionEmergenciaDTO.FechaAtencion;

                    cmd.Parameters.Add("@HoraAtencion", SqlDbType.Time);
                    cmd.Parameters["@HoraAtencion"].Value = registroAtencionEmergenciaDTO.HoraAtencion;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = registroAtencionEmergenciaDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CodigoUPS", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUPS"].Value = registroAtencionEmergenciaDTO.CodigoUPS;

                    cmd.Parameters.Add("@ResponsableRegistro", SqlDbType.VarChar, 200);
                    cmd.Parameters["@ResponsableRegistro"].Value = registroAtencionEmergenciaDTO.ResponsableRegistro;

                    cmd.Parameters.Add("@NSACIP", SqlDbType.Int);
                    cmd.Parameters["@NSACIP"].Value = registroAtencionEmergenciaDTO.NSACIP;

                    cmd.Parameters.Add("@CMP", SqlDbType.Int);
                    cmd.Parameters["@CMP"].Value = registroAtencionEmergenciaDTO.CMP;

                    cmd.Parameters.Add("@Turno", SqlDbType.VarChar, 10);
                    cmd.Parameters["@Turno"].Value = registroAtencionEmergenciaDTO.Turno;

                    cmd.Parameters.Add("@HoraInicio", SqlDbType.Time);
                    cmd.Parameters["@HoraInicio"].Value = registroAtencionEmergenciaDTO.HoraInicio;

                    cmd.Parameters.Add("@HoraFin", SqlDbType.Time);
                    cmd.Parameters["@HoraFin"].Value = registroAtencionEmergenciaDTO.HoraFin;

                    cmd.Parameters.Add("@HistoriaClinica", SqlDbType.Int);
                    cmd.Parameters["@HistoriaClinica"].Value = registroAtencionEmergenciaDTO.HistoriaClinica;

                    cmd.Parameters.Add("@DNIPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DNIPaciente"].Value = registroAtencionEmergenciaDTO.DNIPaciente;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = registroAtencionEmergenciaDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@DistritoPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoPaciente"].Value = registroAtencionEmergenciaDTO.DistritoPaciente;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = registroAtencionEmergenciaDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = registroAtencionEmergenciaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@SituacionPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@SituacionPaciente"].Value = registroAtencionEmergenciaDTO.SituacionPaciente;

                    cmd.Parameters.Add("@CondicionPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CondicionPaciente"].Value = registroAtencionEmergenciaDTO.CondicionPaciente;

                    cmd.Parameters.Add("@EdadPaciente", SqlDbType.Int);
                    cmd.Parameters["@EdadPaciente"].Value = registroAtencionEmergenciaDTO.EdadPaciente;

                    cmd.Parameters.Add("@TipoEdad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TipoEdad"].Value = registroAtencionEmergenciaDTO.TipoEdad;

                    cmd.Parameters.Add("@SexoPaciente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPaciente"].Value = registroAtencionEmergenciaDTO.SexoPaciente;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion1", SqlDbType.Int);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion1"].Value = registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion1;

                    cmd.Parameters.Add("@TipoDX1", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX1"].Value = registroAtencionEmergenciaDTO.TipoDX1;

                    cmd.Parameters.Add("@CodigoCIE10_1", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_1"].Value = registroAtencionEmergenciaDTO.CIE10_1;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion2"].Value = registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion2;

                    cmd.Parameters.Add("@TipoDX2", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX2"].Value = registroAtencionEmergenciaDTO.TipoDX2;

                    cmd.Parameters.Add("@CodigoCIE10_2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_2"].Value = registroAtencionEmergenciaDTO.CIE10_2;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion3", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion3"].Value = registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion3;

                    cmd.Parameters.Add("@TipoDX3", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX3"].Value = registroAtencionEmergenciaDTO.TipoDX3;

                    cmd.Parameters.Add("@CodigoCIE10_3", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_3"].Value = registroAtencionEmergenciaDTO.CIE10_3;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion4", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion4"].Value = registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion4;

                    cmd.Parameters.Add("@TipoDX4", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX4"].Value = registroAtencionEmergenciaDTO.TipoDX4;

                    cmd.Parameters.Add("@CodigoCIE10_4", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_4"].Value = registroAtencionEmergenciaDTO.CIE10_4;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion5", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion5"].Value = registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion5;

                    cmd.Parameters.Add("@TipoDX5", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX5"].Value = registroAtencionEmergenciaDTO.TipoDX5;

                    cmd.Parameters.Add("@CodigoCIE10_5", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_5"].Value = registroAtencionEmergenciaDTO.CIE10_5;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion6", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion6"].Value = registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion6;

                    cmd.Parameters.Add("@TipoDX6", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX6"].Value = registroAtencionEmergenciaDTO.TipoDX6;

                    cmd.Parameters.Add("@CodigoCIE10_6", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_6"].Value = registroAtencionEmergenciaDTO.CIE10_6;

                    cmd.Parameters.Add("@TipoEmergencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@TipoEmergencia"].Value = registroAtencionEmergenciaDTO.TipoEmergencia;

                    cmd.Parameters.Add("@Interconsulta", SqlDbType.VarChar, 2);
                    cmd.Parameters["@Interconsulta"].Value = registroAtencionEmergenciaDTO.Interconsulta;

                    cmd.Parameters.Add("@EspecialidadMedicaInterconsulta", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadMedicaInterconsulta"].Value = registroAtencionEmergenciaDTO.EspecialidadMedicaInterconsulta;

                    cmd.Parameters.Add("@CodigoMotivoEmergencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMotivoEmergencia"].Value = registroAtencionEmergenciaDTO.CodigoMotivoEmergencia;

                    cmd.Parameters.Add("@Acompaniante", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Acompaniante"].Value = registroAtencionEmergenciaDTO.Acompaniante;

                    cmd.Parameters.Add("@DNIAcompaniante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DNIAcompaniante"].Value = registroAtencionEmergenciaDTO.DNIAcompaniante;

                    cmd.Parameters.Add("@CodigoCondicionAlta", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionAlta"].Value = registroAtencionEmergenciaDTO.CodigoCondicionAlta;

                    cmd.Parameters.Add("@CodigoDestinoPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDestinoPaciente"].Value = registroAtencionEmergenciaDTO.CodigoDestinoPaciente;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroAtencionEmergenciaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroAtencionEmergenciaDTO registroAtencionEmergenciaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroAtencionEmergenciaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroAtencionEmergenciaId", SqlDbType.Int);
                    cmd.Parameters["@RegistroAtencionEmergenciaId"].Value = registroAtencionEmergenciaDTO.RegistroAtencionEmergenciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroAtencionEmergenciaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EstudiosInvestigacionHistoricaNavalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroAtencionEmergencia", SqlDbType.Structured);
                    cmd.Parameters["@RegistroAtencionEmergencia"].TypeName = "Formato.RegistroAtencionEmergencia";
                    cmd.Parameters["@RegistroAtencionEmergencia"].Value = datos;

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
