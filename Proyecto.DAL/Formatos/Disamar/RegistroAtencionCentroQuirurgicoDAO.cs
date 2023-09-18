using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Disamar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Disamar
{
    public class RegistroAtencionCentroQuirurgicoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RegistroAtencionCentroQuirurgicoDTO> ObtenerLista(int? CargaId = null, int? Mes = null, int? Anio = null)
        {
            List<RegistroAtencionCentroQuirurgicoDTO> lista = new List<RegistroAtencionCentroQuirurgicoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroAtencionCentroQuirurgicoListar", conexion);
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
                        lista.Add(new RegistroAtencionCentroQuirurgicoDTO()
                        {
                            RegistroAtencionCentroQuirurgicoId = Convert.ToInt32(dr["RegistroAtencionCentroQuirurgicoId"]),
                            DescEntidadMilitar = dr["DescEntidadMilitar"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            DescEstablecimientoSalud = dr["DescEstablecimientoSalud"].ToString(),
                            DescDitrito = dr["DescDitrito"].ToString(),
                            SalaOperacion = dr["SalaOperacion"].ToString(),
                            NombreMedicoIntervencion = dr["NombreMedicoIntervencion"].ToString(),
                            NSACIPMedicoIntervencion = Convert.ToInt32(dr["NSACIPMedicoIntervencion"]),
                            CMPMedicoIntervencion = Convert.ToInt32(dr["CMPMedicoIntervencion"]),
                            EspecialidadMedico = dr["EspecialidadMedico"].ToString(),
                            NumeroIntervencion = Convert.ToInt32(dr["NumeroIntervencion"]),
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
                            DescOrigenPacienteIntervenido = dr["DescOrigenPacienteIntervenido"].ToString(),
                            DiagnosticoMotivoAtencion1 = dr["CodigoDiagnosticoMotivoAtencion1"].ToString(),
                            TipoDX1 = dr["TipoDX1"].ToString(),
                            CIE10_1 = dr["CodigoCIE10_1"].ToString(),
                            DiagnosticoMotivoAtencion2 = dr["CodigoDiagnosticoMotivoAtencion2"].ToString(),
                            TipoDX2 = dr["TipoDX2"].ToString(),
                            CIE10_2 = dr["CodigoCIE10_2"].ToString(),
                            DiagnosticoMotivoAtencion3 = dr["CodigoDiagnosticoMotivoAtencion3"].ToString(),
                            TipoDX3 = dr["TipoDX3"].ToString(),
                            CIE10_3 = dr["CodigoCIE10_3"].ToString(),
                            IntervencionQuirurgicaEfectuada = dr["IntervencionQuirurgicaEfectuada"].ToString(),
                            CodigoIntervencionEfectuada = dr["CodigoIntervencionEfectuada"].ToString(),
                            IntervencionQuirurgicaAdicional = dr["IntervencionQuirurgicaAdicional"].ToString(),
                            CodigoIntervencionAdicional = dr["CodigoIntervencionAdicional"].ToString(),
                            FechaHoraInicio = Convert.ToDateTime(dr["FechaHoraInicio"]).ToString("yyyy-MM-dd HH:mm:ss"),
                            FechaHoraFin = Convert.ToDateTime(dr["FechaHoraFin"]).ToString("yyyy-MM-dd HH:mm:ss"),
                            TipoIntervencion = dr["TipoIntervencion"].ToString(),
                            EstadoPaciente = dr["EstadoPaciente"].ToString(),
                            DescDestinoPaciente = dr["DescDestinoPaciente"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RegistroAtencionCentroQuirurgicoDTO registroAtencionCentroQuirurgicoDTO, int mes, int anio)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroAtencionCentroQuirurgicoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = registroAtencionCentroQuirurgicoDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = registroAtencionCentroQuirurgicoDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoEstablecimientoSaludMGP", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstablecimientoSaludMGP"].Value = registroAtencionCentroQuirurgicoDTO.CodigoEstablecimientoSaludMGP;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = registroAtencionCentroQuirurgicoDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@SalaOperacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SalaOperacion"].Value = registroAtencionCentroQuirurgicoDTO.SalaOperacion;

                    cmd.Parameters.Add("@NombreMedicoIntervencion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@NombreMedicoIntervencion"].Value = registroAtencionCentroQuirurgicoDTO.NombreMedicoIntervencion;

                    cmd.Parameters.Add("@NSACIPMedicoIntervencion", SqlDbType.Int);
                    cmd.Parameters["@NSACIPMedicoIntervencion"].Value = registroAtencionCentroQuirurgicoDTO.NSACIPMedicoIntervencion;

                    cmd.Parameters.Add("@CMPMedicoIntervencion", SqlDbType.Int);
                    cmd.Parameters["@CMPMedicoIntervencion"].Value = registroAtencionCentroQuirurgicoDTO.CMPMedicoIntervencion;

                    cmd.Parameters.Add("@EspecialidadMedico", SqlDbType.VarChar, 100);
                    cmd.Parameters["@EspecialidadMedico"].Value = registroAtencionCentroQuirurgicoDTO.EspecialidadMedico;

                    cmd.Parameters.Add("@NumeroIntervencion", SqlDbType.Int);
                    cmd.Parameters["@NumeroIntervencion"].Value = registroAtencionCentroQuirurgicoDTO.NumeroIntervencion;

                    cmd.Parameters.Add("@HistoriaClinica", SqlDbType.Int);
                    cmd.Parameters["@HistoriaClinica"].Value = registroAtencionCentroQuirurgicoDTO.HistoriaClinica;

                    cmd.Parameters.Add("@DNIPaciente", SqlDbType.VarChar,20);
                    cmd.Parameters["@DNIPaciente"].Value = registroAtencionCentroQuirurgicoDTO.DNIPaciente;

                    cmd.Parameters.Add("@CodigoUnidadDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadDependencia"].Value = registroAtencionCentroQuirurgicoDTO.CodigoUnidadDependencia;

                    cmd.Parameters.Add("@DistritoPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoPaciente"].Value = registroAtencionCentroQuirurgicoDTO.DistritoPaciente;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = registroAtencionCentroQuirurgicoDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = registroAtencionCentroQuirurgicoDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@SituacionPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@SituacionPaciente"].Value = registroAtencionCentroQuirurgicoDTO.SituacionPaciente;

                    cmd.Parameters.Add("@CondicionPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CondicionPaciente"].Value = registroAtencionCentroQuirurgicoDTO.CondicionPaciente;

                    cmd.Parameters.Add("@EdadPaciente", SqlDbType.Int);
                    cmd.Parameters["@EdadPaciente"].Value = registroAtencionCentroQuirurgicoDTO.EdadPaciente;

                    cmd.Parameters.Add("@TipoEdad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TipoEdad"].Value = registroAtencionCentroQuirurgicoDTO.TipoEdad;

                    cmd.Parameters.Add("@SexoPaciente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPaciente"].Value = registroAtencionCentroQuirurgicoDTO.SexoPaciente;

                    cmd.Parameters.Add("@CodigoOrigenPacienteIntervenido", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoOrigenPacienteIntervenido"].Value = registroAtencionCentroQuirurgicoDTO.CodigoOrigenPacienteIntervenido;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion1", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion1"].Value = registroAtencionCentroQuirurgicoDTO.DiagnosticoMotivoAtencion1;

                    cmd.Parameters.Add("@CodigoCIE10_1", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_1"].Value = registroAtencionCentroQuirurgicoDTO.CIE10_1;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion2"].Value = registroAtencionCentroQuirurgicoDTO.DiagnosticoMotivoAtencion2;

                    cmd.Parameters.Add("@TipoDX2", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX2"].Value = registroAtencionCentroQuirurgicoDTO.TipoDX2;

                    cmd.Parameters.Add("@CodigoCIE10_2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_2"].Value = registroAtencionCentroQuirurgicoDTO.CIE10_2;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion3", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion3"].Value = registroAtencionCentroQuirurgicoDTO.DiagnosticoMotivoAtencion3;

                    cmd.Parameters.Add("@TipoDX3", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX3"].Value = registroAtencionCentroQuirurgicoDTO.TipoDX3;

                    cmd.Parameters.Add("@CodigoCIE10_3", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_3"].Value = registroAtencionCentroQuirurgicoDTO.CIE10_3;

                    cmd.Parameters.Add("@IntervencionQuirurgicaEfectuada", SqlDbType.VarChar, 20);
                    cmd.Parameters["@IntervencionQuirurgicaEfectuada"].Value = registroAtencionCentroQuirurgicoDTO.IntervencionQuirurgicaEfectuada;

                    cmd.Parameters.Add("@CodigoIntervencionEfectuada", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoIntervencionEfectuada"].Value = registroAtencionCentroQuirurgicoDTO.CodigoIntervencionEfectuada;

                    cmd.Parameters.Add("@IntervencionQuirurgicaAdicional", SqlDbType.VarChar, 20);
                    cmd.Parameters["@IntervencionQuirurgicaAdicional"].Value = registroAtencionCentroQuirurgicoDTO.IntervencionQuirurgicaAdicional;

                    cmd.Parameters.Add("@CodigoIntervencionAdicional", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoIntervencionAdicional"].Value = registroAtencionCentroQuirurgicoDTO.CodigoIntervencionAdicional;

                    cmd.Parameters.Add("@FechaHoraInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaHoraInicio"].Value = registroAtencionCentroQuirurgicoDTO.FechaHoraInicio;

                    cmd.Parameters.Add("@FechaHoraFin", SqlDbType.Date);
                    cmd.Parameters["@FechaHoraFin"].Value = registroAtencionCentroQuirurgicoDTO.FechaHoraFin;

                    cmd.Parameters.Add("@TipoIntervencion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@TipoIntervencion"].Value = registroAtencionCentroQuirurgicoDTO.TipoIntervencion;

                    cmd.Parameters.Add("@EstadoPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@EstadoPaciente"].Value = registroAtencionCentroQuirurgicoDTO.EstadoPaciente;

                    cmd.Parameters.Add("@CodigoDestinoPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDestinoPaciente"].Value = registroAtencionCentroQuirurgicoDTO.CodigoDestinoPaciente;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = registroAtencionCentroQuirurgicoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroAtencionCentroQuirurgicoDTO.UsuarioIngresoRegistro;

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

        public RegistroAtencionCentroQuirurgicoDTO BuscarFormato(int Codigo)
        {
            RegistroAtencionCentroQuirurgicoDTO registroAtencionCentroQuirurgicoDTO = new RegistroAtencionCentroQuirurgicoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroAtencionCentroQuirurgicoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroAtencionCentroQuirurgicoId", SqlDbType.Int);
                    cmd.Parameters["@RegistroAtencionCentroQuirurgicoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        registroAtencionCentroQuirurgicoDTO.RegistroAtencionCentroQuirurgicoId = Convert.ToInt32(dr["RegistroAtencionCentroQuirurgicoId"]);
                        registroAtencionCentroQuirurgicoDTO.CodigoEntidadMilitar = dr["CodigoEntidadMilitar"].ToString();
                        registroAtencionCentroQuirurgicoDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        registroAtencionCentroQuirurgicoDTO.CodigoEstablecimientoSaludMGP = dr["CodigoEstablecimientoSaludMGP"].ToString();
                        registroAtencionCentroQuirurgicoDTO.DistritoUbigeo = dr["DistritoUbigeo"].ToString();
                        registroAtencionCentroQuirurgicoDTO.SalaOperacion = dr["SalaOperacion"].ToString();
                        registroAtencionCentroQuirurgicoDTO.NombreMedicoIntervencion = dr["NombreMedicoIntervencion"].ToString();
                        registroAtencionCentroQuirurgicoDTO.NSACIPMedicoIntervencion = Convert.ToInt32(dr["NSACIPMedicoIntervencion"]);
                        registroAtencionCentroQuirurgicoDTO.CMPMedicoIntervencion = Convert.ToInt32(dr["CMPMedicoIntervencion"]);
                        registroAtencionCentroQuirurgicoDTO.EspecialidadMedico = dr["EspecialidadMedico"].ToString();
                        registroAtencionCentroQuirurgicoDTO.NumeroIntervencion = Convert.ToInt32(dr["NumeroIntervencion"]);
                        registroAtencionCentroQuirurgicoDTO.HistoriaClinica = Convert.ToInt32(dr["HistoriaClinica"]);
                        registroAtencionCentroQuirurgicoDTO.DNIPaciente = dr["DNIPaciente"].ToString();
                        registroAtencionCentroQuirurgicoDTO.CodigoUnidadDependencia = dr["CodigoUnidadDependencia"].ToString();
                        registroAtencionCentroQuirurgicoDTO.DistritoPaciente = dr["DistritoPaciente"].ToString();
                        registroAtencionCentroQuirurgicoDTO.CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar"].ToString();
                        registroAtencionCentroQuirurgicoDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        registroAtencionCentroQuirurgicoDTO.SituacionPaciente = dr["SituacionPaciente"].ToString();
                        registroAtencionCentroQuirurgicoDTO.CondicionPaciente = dr["CondicionPaciente"].ToString();
                        registroAtencionCentroQuirurgicoDTO.EdadPaciente = Convert.ToInt32(dr["EdadPaciente"]);
                        registroAtencionCentroQuirurgicoDTO.TipoEdad = dr["TipoEdad"].ToString();
                        registroAtencionCentroQuirurgicoDTO.SexoPaciente = dr["SexoPaciente"].ToString();
                        registroAtencionCentroQuirurgicoDTO.CodigoOrigenPacienteIntervenido = dr["CodigoOrigenPacienteIntervenido"].ToString();
                        registroAtencionCentroQuirurgicoDTO.DiagnosticoMotivoAtencion1 = dr["CodigoDiagnosticoMotivoAtencion1"].ToString();
                        registroAtencionCentroQuirurgicoDTO.TipoDX1 = dr["TipoDX1"].ToString();
                        registroAtencionCentroQuirurgicoDTO.CIE10_1 = dr["CodigoCIE10_1"].ToString();
                        registroAtencionCentroQuirurgicoDTO.DiagnosticoMotivoAtencion2 = dr["CodigoDiagnosticoMotivoAtencion2"].ToString();
                        registroAtencionCentroQuirurgicoDTO.TipoDX2 = dr["TipoDX2"].ToString();
                        registroAtencionCentroQuirurgicoDTO.CIE10_2 = dr["CodigoCIE10_2"].ToString();
                        registroAtencionCentroQuirurgicoDTO.DiagnosticoMotivoAtencion3 = dr["CodigoDiagnosticoMotivoAtencion3"].ToString();
                        registroAtencionCentroQuirurgicoDTO.TipoDX3 = dr["TipoDX3"].ToString();
                        registroAtencionCentroQuirurgicoDTO.CIE10_3 = dr["CodigoCIE10_3"].ToString();
                        registroAtencionCentroQuirurgicoDTO.IntervencionQuirurgicaEfectuada = dr["IntervencionQuirurgicaEfectuada"].ToString();
                        registroAtencionCentroQuirurgicoDTO.CodigoIntervencionEfectuada = dr["CodigoIntervencionEfectuada"].ToString();
                        registroAtencionCentroQuirurgicoDTO.IntervencionQuirurgicaAdicional = dr["IntervencionQuirurgicaAdicional"].ToString();
                        registroAtencionCentroQuirurgicoDTO.CodigoIntervencionAdicional = dr["CodigoIntervencionAdicional"].ToString();
                        registroAtencionCentroQuirurgicoDTO.FechaHoraInicio = Convert.ToDateTime(dr["FechaHoraInicio"]).ToString("yyyy-MM-dd HH:mm:ss");
                        registroAtencionCentroQuirurgicoDTO.FechaHoraFin = Convert.ToDateTime(dr["FechaHoraFin"]).ToString("yyyy-MM-dd HH:mm:ss");
                        registroAtencionCentroQuirurgicoDTO.TipoIntervencion = dr["TipoIntervencion"].ToString();
                        registroAtencionCentroQuirurgicoDTO.EstadoPaciente = dr["EstadoPaciente"].ToString();
                        registroAtencionCentroQuirurgicoDTO.CodigoDestinoPaciente = dr["CodigoDestinoPaciente"].ToString(); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroAtencionCentroQuirurgicoDTO;
        }

        public string ActualizaFormato(RegistroAtencionCentroQuirurgicoDTO registroAtencionCentroQuirurgicoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroAtencionCentroQuirurgicoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RegistroAtencionCentroQuirurgicoId", SqlDbType.Int);
                    cmd.Parameters["@RegistroAtencionCentroQuirurgicoId"].Value = registroAtencionCentroQuirurgicoDTO.RegistroAtencionCentroQuirurgicoId;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = registroAtencionCentroQuirurgicoDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = registroAtencionCentroQuirurgicoDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoEstablecimientoSaludMGP", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstablecimientoSaludMGP"].Value = registroAtencionCentroQuirurgicoDTO.CodigoEstablecimientoSaludMGP;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = registroAtencionCentroQuirurgicoDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@SalaOperacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SalaOperacion"].Value = registroAtencionCentroQuirurgicoDTO.SalaOperacion;

                    cmd.Parameters.Add("@NombreMedicoIntervencion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@NombreMedicoIntervencion"].Value = registroAtencionCentroQuirurgicoDTO.NombreMedicoIntervencion;

                    cmd.Parameters.Add("@NSACIPMedicoIntervencion", SqlDbType.Int);
                    cmd.Parameters["@NSACIPMedicoIntervencion"].Value = registroAtencionCentroQuirurgicoDTO.NSACIPMedicoIntervencion;

                    cmd.Parameters.Add("@CMPMedicoIntervencion", SqlDbType.Int);
                    cmd.Parameters["@CMPMedicoIntervencion"].Value = registroAtencionCentroQuirurgicoDTO.CMPMedicoIntervencion;

                    cmd.Parameters.Add("@EspecialidadMedico", SqlDbType.VarChar, 100);
                    cmd.Parameters["@EspecialidadMedico"].Value = registroAtencionCentroQuirurgicoDTO.EspecialidadMedico;

                    cmd.Parameters.Add("@NumeroIntervencion", SqlDbType.Int);
                    cmd.Parameters["@NumeroIntervencion"].Value = registroAtencionCentroQuirurgicoDTO.NumeroIntervencion;

                    cmd.Parameters.Add("@HistoriaClinica", SqlDbType.Int);
                    cmd.Parameters["@HistoriaClinica"].Value = registroAtencionCentroQuirurgicoDTO.HistoriaClinica;

                    cmd.Parameters.Add("@DNIPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DNIPaciente"].Value = registroAtencionCentroQuirurgicoDTO.DNIPaciente;

                    cmd.Parameters.Add("@CodigoUnidadDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadDependencia"].Value = registroAtencionCentroQuirurgicoDTO.CodigoUnidadDependencia;

                    cmd.Parameters.Add("@DistritoPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoPaciente"].Value = registroAtencionCentroQuirurgicoDTO.DistritoPaciente;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = registroAtencionCentroQuirurgicoDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = registroAtencionCentroQuirurgicoDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@SituacionPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@SituacionPaciente"].Value = registroAtencionCentroQuirurgicoDTO.SituacionPaciente;

                    cmd.Parameters.Add("@CondicionPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CondicionPaciente"].Value = registroAtencionCentroQuirurgicoDTO.CondicionPaciente;

                    cmd.Parameters.Add("@EdadPaciente", SqlDbType.Int);
                    cmd.Parameters["@EdadPaciente"].Value = registroAtencionCentroQuirurgicoDTO.EdadPaciente;

                    cmd.Parameters.Add("@TipoEdad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TipoEdad"].Value = registroAtencionCentroQuirurgicoDTO.TipoEdad;

                    cmd.Parameters.Add("@SexoPaciente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPaciente"].Value = registroAtencionCentroQuirurgicoDTO.SexoPaciente;

                    cmd.Parameters.Add("@CodigoOrigenPacienteIntervenido", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoOrigenPacienteIntervenido"].Value = registroAtencionCentroQuirurgicoDTO.CodigoOrigenPacienteIntervenido;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion1", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion1"].Value = registroAtencionCentroQuirurgicoDTO.DiagnosticoMotivoAtencion1;

                    cmd.Parameters.Add("@CodigoCIE10_1", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_1"].Value = registroAtencionCentroQuirurgicoDTO.CIE10_1;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion2"].Value = registroAtencionCentroQuirurgicoDTO.DiagnosticoMotivoAtencion2;

                    cmd.Parameters.Add("@TipoDX2", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX2"].Value = registroAtencionCentroQuirurgicoDTO.TipoDX2;

                    cmd.Parameters.Add("@CodigoCIE10_2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_2"].Value = registroAtencionCentroQuirurgicoDTO.CIE10_2;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion3", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion3"].Value = registroAtencionCentroQuirurgicoDTO.DiagnosticoMotivoAtencion3;

                    cmd.Parameters.Add("@TipoDX3", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX3"].Value = registroAtencionCentroQuirurgicoDTO.TipoDX3;

                    cmd.Parameters.Add("@CodigoCIE10_3", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_3"].Value = registroAtencionCentroQuirurgicoDTO.CIE10_3;

                    cmd.Parameters.Add("@IntervencionQuirurgicaEfectuada", SqlDbType.VarChar, 20);
                    cmd.Parameters["@IntervencionQuirurgicaEfectuada"].Value = registroAtencionCentroQuirurgicoDTO.IntervencionQuirurgicaEfectuada;

                    cmd.Parameters.Add("@CodigoIntervencionEfectuada", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoIntervencionEfectuada"].Value = registroAtencionCentroQuirurgicoDTO.CodigoIntervencionEfectuada;

                    cmd.Parameters.Add("@IntervencionQuirurgicaAdicional", SqlDbType.VarChar, 20);
                    cmd.Parameters["@IntervencionQuirurgicaAdicional"].Value = registroAtencionCentroQuirurgicoDTO.IntervencionQuirurgicaAdicional;

                    cmd.Parameters.Add("@CodigoIntervencionAdicional", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoIntervencionAdicional"].Value = registroAtencionCentroQuirurgicoDTO.CodigoIntervencionAdicional;

                    cmd.Parameters.Add("@FechaHoraInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaHoraInicio"].Value = registroAtencionCentroQuirurgicoDTO.FechaHoraInicio;

                    cmd.Parameters.Add("@FechaHoraFin", SqlDbType.Date);
                    cmd.Parameters["@FechaHoraFin"].Value = registroAtencionCentroQuirurgicoDTO.FechaHoraFin;

                    cmd.Parameters.Add("@TipoIntervencion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@TipoIntervencion"].Value = registroAtencionCentroQuirurgicoDTO.TipoIntervencion;

                    cmd.Parameters.Add("@EstadoPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@EstadoPaciente"].Value = registroAtencionCentroQuirurgicoDTO.EstadoPaciente;

                    cmd.Parameters.Add("@CodigoDestinoPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDestinoPaciente"].Value = registroAtencionCentroQuirurgicoDTO.CodigoDestinoPaciente;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroAtencionCentroQuirurgicoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroAtencionCentroQuirurgicoDTO registroAtencionCentroQuirurgicoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroAtencionCentroQuirurgicoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroAtencionCentroQuirurgicoId", SqlDbType.Int);
                    cmd.Parameters["@RegistroAtencionCentroQuirurgicoId"].Value = registroAtencionCentroQuirurgicoDTO.RegistroAtencionCentroQuirurgicoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroAtencionCentroQuirurgicoDTO.UsuarioIngresoRegistro;

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
        public bool EliminarCarga(RegistroAtencionCentroQuirurgicoDTO registroAtencionCentroQuirurgicoDTO)
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
                    cmd.Parameters["@Formato"].Value = "RegistroAtencionCentroQuirurgico";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = registroAtencionCentroQuirurgicoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroAtencionCentroQuirurgicoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RegistroAtencionCentroQuirurgicoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroAtencionCentroQuirurgico", SqlDbType.Structured);
                    cmd.Parameters["@RegistroAtencionCentroQuirurgico"].TypeName = "Formato.RegistroAtencionCentroQuirurgico";
                    cmd.Parameters["@RegistroAtencionCentroQuirurgico"].Value = datos;

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
