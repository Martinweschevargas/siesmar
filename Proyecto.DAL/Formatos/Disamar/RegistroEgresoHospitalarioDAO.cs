using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Disamar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Disamar
{
    public class RegistroEgresoHospitalarioDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RegistroEgresoHospitalarioDTO> ObtenerLista(int? CargaId=null)
        {
            List<RegistroEgresoHospitalarioDTO> lista = new List<RegistroEgresoHospitalarioDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroEgresoHospitalarioListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegistroEgresoHospitalarioDTO()
                        {
                            RegistroEgresoHospitalarioId = Convert.ToInt32(dr["RegistroEgresoHospitalarioId"]),
                            DescEntidadMilitar = dr["DescEntidadMilitar "].ToString(),
                            DescZonaNaval = dr["DescZonaNaval "].ToString(),
                            DescEstablecimientoSalud = dr["DescEstablecimientoSalud "].ToString(),
                            DescDepartamento = dr["DescDepartamento "].ToString(),
                            DescProvincia = dr["DescProvincia "].ToString(),
                            DescDitrito = dr["DescDitrito "].ToString(),
                            DescEspecialidadMedicaNoMedica = dr["DescEspecialidadMedicaNoMedica "].ToString(),
                            ResponsableRegistro = dr["ResponsableRegistro"].ToString(),
                            NSACIP = Convert.ToInt32(dr["NSACIP"]),
                            DNIResponsableSalud = dr["DNIResponsableSalud"].ToString(),
                            HistoriaClinica = Convert.ToInt32(dr["HistoriaClinica"]),
                            DNIPaciente = dr["DNIPaciente"].ToString(),
                            DescUnidadDependencia = dr["DescUnidadDependencia "].ToString(),
                            DescDistritroPaciente = dr["DescDistrito "].ToString(),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar "].ToString(),
                            DescGrado = dr["DescGrado "].ToString(),
                            SituacionPaciente = dr["SituacionPaciente"].ToString(),
                            CondicionPaciente = dr["CondicionPaciente"].ToString(),
                            OrigenPaciente = dr["OrigenPaciente"].ToString(),
                            EdadPaciente = Convert.ToInt32(dr["EdadPaciente"]),
                            TipoEdad = dr["TipoEdad"].ToString(),
                            SexoPaciente = dr["SexoPaciente"].ToString(),
                            DiagnosticoMotivoAtencion1 = dr["CodigoDiagnosticoMotivoAtencion1"].ToString(),
                            TipoDX1 = dr["TipoDX1"].ToString(),
                            CIE10_1 = dr["CodigoCIE10_1"].ToString(),
                            DiagnosticoMotivoAtencion2 = dr["CodigoDiagnosticoMotivoAtencion2"].ToString(),
                            TipoDX2 = dr["TipoDX2"].ToString(),
                            CIE10_2 =   dr["CodigoCIE10_2"].ToString(),
                            DiagnosticoMotivoAtencion3 = dr["CodigoDiagnosticoMotivoAtencion3"].ToString(),
                            TipoDX3 = dr["TipoDX3"].ToString(),
                            CIE10_3 = dr["CodigoCIE10_3"].ToString(),
                            DiagnosticoMotivoAtencion4 = dr["CodigoDiagnosticoMotivoAtencion4"].ToString(),
                            TipoDX4 = dr["TipoDX4"].ToString(),
                            CIE10_4 = dr["CodigoCIE10_4"].ToString(),
                            DiagnosticoMotivoAtencion5 = dr["CodigoDiagnosticoMotivoAtencion5"].ToString(),
                            TipoDX5 = dr["TipoDX5"].ToString(),
                            CIE10_5 =       dr["CodigoCIE10_5"].ToString(),
                            DiagnosticoMotivoAtencion6 = dr["CodigoDiagnosticoMotivoAtencion6"].ToString(),
                            TipoDX6 = dr["TipoDX6"].ToString(),
                            CIE10_6 = dr["CodigoCIE10_6"].ToString(),
                            DescCondicionEgresoHospitalizacion = dr["DescCondicionEgresoHospitalizacion "].ToString(),
                            FechaIngreso = (dr["FechaIngreso"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            HoraIngreso = dr["HoraIngreso"].ToString(),
                            FechaEgreso = (dr["FechaEgreso"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            HoraEgreso = dr["HoraEgreso"].ToString(),
                            EspecialidadMedicoTratanteIngreso = dr["EspecialidadMedicoTratanteIngreso"].ToString(),
                            NombreMedicoIngreso = dr["NombreMedicoIngreso"].ToString(),
                            DiagnosticoIngreso = dr["DiagnosticoIngreso"].ToString(),
                            EspecialidadMedicoTratanteEgreso = dr["EspecialidadMedicoTratanteEgreso"].ToString(),
                            NombreMedicoEgreso = dr["NombreMedicoEgreso"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RegistroEgresoHospitalarioDTO registroEgresoHospitalarioDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEgresoHospitalarioRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = registroEgresoHospitalarioDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = registroEgresoHospitalarioDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoEstablecimientoSaludMGP", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoEstablecimientoSaludMGP"].Value = registroEgresoHospitalarioDTO.CodigoEstablecimientoSaludMGP;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = registroEgresoHospitalarioDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CodigoUPS", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUPS"].Value = registroEgresoHospitalarioDTO.CodigoUPS;

                    cmd.Parameters.Add("@ResponsableRegistro", SqlDbType.VarChar, 200);
                    cmd.Parameters["@ResponsableRegistro"].Value = registroEgresoHospitalarioDTO.ResponsableRegistro;

                    cmd.Parameters.Add("@NSACIP", SqlDbType.Int);
                    cmd.Parameters["@NSACIP"].Value = registroEgresoHospitalarioDTO.NSACIP;

                    cmd.Parameters.Add("@DNIResponsableSalud", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIResponsableSalud"].Value = registroEgresoHospitalarioDTO.DNIResponsableSalud;

                    cmd.Parameters.Add("@HistoriaClinica", SqlDbType.Int);
                    cmd.Parameters["@HistoriaClinica"].Value = registroEgresoHospitalarioDTO.HistoriaClinica;

                    cmd.Parameters.Add("@DNIPaciente", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPaciente"].Value = registroEgresoHospitalarioDTO.DNIPaciente;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = registroEgresoHospitalarioDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@DistritoPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoPaciente"].Value = registroEgresoHospitalarioDTO.DistritoPaciente;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = registroEgresoHospitalarioDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = registroEgresoHospitalarioDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@SituacionPaciente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SituacionPaciente"].Value = registroEgresoHospitalarioDTO.SituacionPaciente;

                    cmd.Parameters.Add("@CondicionPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CondicionPaciente"].Value = registroEgresoHospitalarioDTO.CondicionPaciente;

                    cmd.Parameters.Add("@OrigenPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@OrigenPaciente"].Value = registroEgresoHospitalarioDTO.OrigenPaciente;

                    cmd.Parameters.Add("@EdadPaciente", SqlDbType.Int);
                    cmd.Parameters["@EdadPaciente"].Value = registroEgresoHospitalarioDTO.EdadPaciente;

                    cmd.Parameters.Add("@TipoEdad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TipoEdad"].Value = registroEgresoHospitalarioDTO.TipoEdad;

                    cmd.Parameters.Add("@SexoPaciente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPaciente"].Value = registroEgresoHospitalarioDTO.SexoPaciente;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion1", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion1"].Value = registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion1;

                    cmd.Parameters.Add("@TipoDX1", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX1"].Value = registroEgresoHospitalarioDTO.TipoDX1;

                    cmd.Parameters.Add("@CodigoCIE10_1", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_1"].Value = registroEgresoHospitalarioDTO.CIE10_1;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion2"].Value = registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion2;

                    cmd.Parameters.Add("@TipoDX2", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX2"].Value = registroEgresoHospitalarioDTO.TipoDX2;

                    cmd.Parameters.Add("@CodigoCIE10_2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_2"].Value = registroEgresoHospitalarioDTO.CIE10_2;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion3", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion3"].Value = registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion3;

                    cmd.Parameters.Add("@TipoDX3", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX3"].Value = registroEgresoHospitalarioDTO.TipoDX3;

                    cmd.Parameters.Add("@CodigoCIE10_3", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_3"].Value = registroEgresoHospitalarioDTO.CIE10_3;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion4", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion4"].Value = registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion4;

                    cmd.Parameters.Add("@TipoDX4", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX4"].Value = registroEgresoHospitalarioDTO.TipoDX4;

                    cmd.Parameters.Add("@CodigoCIE10_4", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_4"].Value = registroEgresoHospitalarioDTO.CIE10_4;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion5", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion5"].Value = registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion5;

                    cmd.Parameters.Add("@TipoDX5", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX5"].Value = registroEgresoHospitalarioDTO.TipoDX5;

                    cmd.Parameters.Add("@CodigoCIE10_5", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_5"].Value = registroEgresoHospitalarioDTO.CIE10_5;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion6", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion6"].Value = registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion6;

                    cmd.Parameters.Add("@TipoDX6", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX6"].Value = registroEgresoHospitalarioDTO.TipoDX6;

                    cmd.Parameters.Add("@CodigoCIE10_6", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_6"].Value = registroEgresoHospitalarioDTO.CIE10_6;

                    cmd.Parameters.Add("@CodigoCondicionEgresoHospitalizacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionEgresoHospitalizacion"].Value = registroEgresoHospitalarioDTO.CodigoCondicionEgresoHospitalizacion;

                    cmd.Parameters.Add("@FechaIngreso", SqlDbType.Date);
                    cmd.Parameters["@FechaIngreso"].Value = registroEgresoHospitalarioDTO.FechaIngreso;

                    cmd.Parameters.Add("@HoraIngreso", SqlDbType.Time);
                    cmd.Parameters["@HoraIngreso"].Value = registroEgresoHospitalarioDTO.HoraIngreso;

                    cmd.Parameters.Add("@FechaEgreso", SqlDbType.Date);
                    cmd.Parameters["@FechaEgreso"].Value = registroEgresoHospitalarioDTO.FechaEgreso;

                    cmd.Parameters.Add("@HoraEgreso", SqlDbType.Time);
                    cmd.Parameters["@HoraEgreso"].Value = registroEgresoHospitalarioDTO.HoraEgreso;

                    cmd.Parameters.Add("@EspecialidadMedicoTratanteIngreso", SqlDbType.VarChar, 200);
                    cmd.Parameters["@EspecialidadMedicoTratanteIngreso"].Value = registroEgresoHospitalarioDTO.EspecialidadMedicoTratanteIngreso;

                    cmd.Parameters.Add("@NombreMedicoIngreso", SqlDbType.VarChar, 200);
                    cmd.Parameters["@NombreMedicoIngreso"].Value = registroEgresoHospitalarioDTO.NombreMedicoIngreso;

                    cmd.Parameters.Add("@DiagnosticoIngreso", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DiagnosticoIngreso"].Value = registroEgresoHospitalarioDTO.DiagnosticoIngreso;

                    cmd.Parameters.Add("@EspecialidadMedicoTratanteEgreso", SqlDbType.VarChar, 200);
                    cmd.Parameters["@EspecialidadMedicoTratanteEgreso"].Value = registroEgresoHospitalarioDTO.EspecialidadMedicoTratanteEgreso;

                    cmd.Parameters.Add("@NombreMedicoEgreso", SqlDbType.VarChar, 200);
                    cmd.Parameters["@NombreMedicoEgreso"].Value = registroEgresoHospitalarioDTO.NombreMedicoEgreso;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = registroEgresoHospitalarioDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEgresoHospitalarioDTO.UsuarioIngresoRegistro;

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

        public RegistroEgresoHospitalarioDTO BuscarFormato(int Codigo)
        {
            RegistroEgresoHospitalarioDTO registroEgresoHospitalarioDTO = new RegistroEgresoHospitalarioDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEgresoHospitalarioEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEgresoHospitalarioId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEgresoHospitalarioId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        registroEgresoHospitalarioDTO.RegistroEgresoHospitalarioId = Convert.ToInt32(dr["RegistroEgresoHospitalarioId"]);
                        registroEgresoHospitalarioDTO.CodigoEntidadMilitar = dr["CodigoEntidadMilitar"].ToString();
                        registroEgresoHospitalarioDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        registroEgresoHospitalarioDTO.CodigoEstablecimientoSaludMGP = dr["CodigoEstablecimientoSaludMGP"].ToString();
                        registroEgresoHospitalarioDTO.DistritoUbigeo = dr["DistritoUbigeo"].ToString();
                        registroEgresoHospitalarioDTO.CodigoUPS = dr["CodigoUPS"].ToString();
                        registroEgresoHospitalarioDTO.ResponsableRegistro = dr["ResponsableRegistro"].ToString();
                        registroEgresoHospitalarioDTO.NSACIP = Convert.ToInt32(dr["NSACIP"]);
                        registroEgresoHospitalarioDTO.DNIResponsableSalud = dr["DNIResponsableSalud"].ToString();
                        registroEgresoHospitalarioDTO.HistoriaClinica = Convert.ToInt32(dr["HistoriaClinica"]);
                        registroEgresoHospitalarioDTO.DNIPaciente = dr["DNIPaciente"].ToString();
                        registroEgresoHospitalarioDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        registroEgresoHospitalarioDTO.DistritoPaciente = dr["DistritoPaciente"].ToString();
                        registroEgresoHospitalarioDTO.CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar"].ToString();
                        registroEgresoHospitalarioDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        registroEgresoHospitalarioDTO.SituacionPaciente = dr["SituacionPaciente"].ToString();
                        registroEgresoHospitalarioDTO.CondicionPaciente = dr["CondicionPaciente"].ToString();
                        registroEgresoHospitalarioDTO.OrigenPaciente = dr["OrigenPaciente"].ToString();
                        registroEgresoHospitalarioDTO.EdadPaciente = Convert.ToInt32(dr["EdadPaciente"]);
                        registroEgresoHospitalarioDTO.TipoEdad = dr["TipoEdad"].ToString();
                        registroEgresoHospitalarioDTO.SexoPaciente = dr["SexoPaciente"].ToString();
                        registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion1 = dr["CodigoDiagnosticoMotivoAtencion1"].ToString();
                        registroEgresoHospitalarioDTO.TipoDX1 = dr["TipoDX1"].ToString();
                        registroEgresoHospitalarioDTO.CIE10_1 = dr["CodigoCIE10_1"].ToString();
                        registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion2 = dr["CodigoDiagnosticoMotivoAtencion2"].ToString();
                        registroEgresoHospitalarioDTO.TipoDX2 = dr["TipoDX2"].ToString();
                        registroEgresoHospitalarioDTO.CIE10_2 = dr["CodigoCIE10_2"].ToString();
                        registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion3 = dr["CodigoDiagnosticoMotivoAtencion3"].ToString();
                        registroEgresoHospitalarioDTO.TipoDX3 = dr["TipoDX3"].ToString();
                        registroEgresoHospitalarioDTO.CIE10_3 = dr["CodigoCIE10_3"].ToString();
                        registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion4 = dr["CodigoDiagnosticoMotivoAtencion4"].ToString();
                        registroEgresoHospitalarioDTO.TipoDX4 = dr["TipoDX4"].ToString();
                        registroEgresoHospitalarioDTO.CIE10_4 = dr["CodigoCIE10_4"].ToString();
                        registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion5 = dr["CodigoDiagnosticoMotivoAtencion5"].ToString();
                        registroEgresoHospitalarioDTO.TipoDX5 = dr["TipoDX5"].ToString();
                        registroEgresoHospitalarioDTO.CIE10_5 = dr["CodigoCIE10_5"].ToString();
                        registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion6 = dr["CodigoDiagnosticoMotivoAtencion6"].ToString();
                        registroEgresoHospitalarioDTO.TipoDX6 = dr["TipoDX6"].ToString();
                        registroEgresoHospitalarioDTO.CIE10_6 = dr["CodigoCIE10_6"].ToString();
                        registroEgresoHospitalarioDTO.CodigoCondicionEgresoHospitalizacion = dr["CodigoCondicionEgresoHospitalizacion"].ToString();
                        registroEgresoHospitalarioDTO.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]).ToString("yyy-MM-dd");
                        registroEgresoHospitalarioDTO.HoraIngreso = dr["HoraIngreso"].ToString();
                        registroEgresoHospitalarioDTO.FechaEgreso = Convert.ToDateTime(dr["FechaEgreso"]).ToString("yyy-MM-dd");
                        registroEgresoHospitalarioDTO.HoraEgreso = dr["HoraEgreso"].ToString();
                        registroEgresoHospitalarioDTO.EspecialidadMedicoTratanteIngreso = dr["EspecialidadMedicoTratanteIngreso"].ToString();
                        registroEgresoHospitalarioDTO.NombreMedicoIngreso = dr["NombreMedicoIngreso"].ToString();
                        registroEgresoHospitalarioDTO.DiagnosticoIngreso = dr["DiagnosticoIngreso"].ToString();
                        registroEgresoHospitalarioDTO.EspecialidadMedicoTratanteEgreso = dr["EspecialidadMedicoTratanteEgreso"].ToString();
                        registroEgresoHospitalarioDTO.NombreMedicoEgreso = dr["NombreMedicoEgreso"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroEgresoHospitalarioDTO;
        }

        public string ActualizaFormato(RegistroEgresoHospitalarioDTO registroEgresoHospitalarioDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroEgresoHospitalarioActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RegistroEgresosHospitalariosId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEgresosHospitalariosId"].Value = registroEgresoHospitalarioDTO.RegistroEgresoHospitalarioId;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = registroEgresoHospitalarioDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = registroEgresoHospitalarioDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoEstablecimientoSaludMGP", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstablecimientoSaludMGP"].Value = registroEgresoHospitalarioDTO.CodigoEstablecimientoSaludMGP;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = registroEgresoHospitalarioDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CodigoUPS", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUPS"].Value = registroEgresoHospitalarioDTO.CodigoUPS;

                    cmd.Parameters.Add("@ResponsableRegistro", SqlDbType.VarChar, 200);
                    cmd.Parameters["@ResponsableRegistro"].Value = registroEgresoHospitalarioDTO.ResponsableRegistro;

                    cmd.Parameters.Add("@NSACIP", SqlDbType.Int);
                    cmd.Parameters["@NSACIP"].Value = registroEgresoHospitalarioDTO.NSACIP;

                    cmd.Parameters.Add("@DNIResponsableSalud", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIResponsableSalud"].Value = registroEgresoHospitalarioDTO.DNIResponsableSalud;

                    cmd.Parameters.Add("@HistoriaClinica", SqlDbType.Int);
                    cmd.Parameters["@HistoriaClinica"].Value = registroEgresoHospitalarioDTO.HistoriaClinica;

                    cmd.Parameters.Add("@DNIPaciente", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPaciente"].Value = registroEgresoHospitalarioDTO.DNIPaciente;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = registroEgresoHospitalarioDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@DistritoPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoPaciente"].Value = registroEgresoHospitalarioDTO.DistritoPaciente;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = registroEgresoHospitalarioDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = registroEgresoHospitalarioDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@SituacionPaciente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SituacionPaciente"].Value = registroEgresoHospitalarioDTO.SituacionPaciente;

                    cmd.Parameters.Add("@CondicionPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CondicionPaciente"].Value = registroEgresoHospitalarioDTO.CondicionPaciente;

                    cmd.Parameters.Add("@OrigenPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@OrigenPaciente"].Value = registroEgresoHospitalarioDTO.OrigenPaciente;

                    cmd.Parameters.Add("@EdadPaciente", SqlDbType.Int);
                    cmd.Parameters["@EdadPaciente"].Value = registroEgresoHospitalarioDTO.EdadPaciente;

                    cmd.Parameters.Add("@TipoEdad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TipoEdad"].Value = registroEgresoHospitalarioDTO.TipoEdad;

                    cmd.Parameters.Add("@SexoPaciente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPaciente"].Value = registroEgresoHospitalarioDTO.SexoPaciente;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion1", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion1"].Value = registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion1;

                    cmd.Parameters.Add("@TipoDX1", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX1"].Value = registroEgresoHospitalarioDTO.TipoDX1;

                    cmd.Parameters.Add("@CodigoCIE10_1", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_1"].Value = registroEgresoHospitalarioDTO.CIE10_1;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion2"].Value = registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion2;

                    cmd.Parameters.Add("@TipoDX2", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX2"].Value = registroEgresoHospitalarioDTO.TipoDX2;

                    cmd.Parameters.Add("@CodigoCIE10_2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_2"].Value = registroEgresoHospitalarioDTO.CIE10_2;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion3", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion3"].Value = registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion3;

                    cmd.Parameters.Add("@TipoDX3", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX3"].Value = registroEgresoHospitalarioDTO.TipoDX3;

                    cmd.Parameters.Add("@CodigoCIE10_3", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_3"].Value = registroEgresoHospitalarioDTO.CIE10_3;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion4", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion4"].Value = registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion4;

                    cmd.Parameters.Add("@TipoDX4", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX4"].Value = registroEgresoHospitalarioDTO.TipoDX4;

                    cmd.Parameters.Add("@CodigoCIE10_4", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_4"].Value = registroEgresoHospitalarioDTO.CIE10_4;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion5", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion5"].Value = registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion5;

                    cmd.Parameters.Add("@TipoDX5", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX5"].Value = registroEgresoHospitalarioDTO.TipoDX5;

                    cmd.Parameters.Add("@CodigoCIE10_5", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_5"].Value = registroEgresoHospitalarioDTO.CIE10_5;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion6", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion6"].Value = registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion6;

                    cmd.Parameters.Add("@TipoDX6", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX6"].Value = registroEgresoHospitalarioDTO.TipoDX6;

                    cmd.Parameters.Add("@CodigoCIE10_6", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_6"].Value = registroEgresoHospitalarioDTO.CIE10_6;

                    cmd.Parameters.Add("@CodigoCondicionEgresoHospitalizacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionEgresoHospitalizacion"].Value = registroEgresoHospitalarioDTO.CodigoCondicionEgresoHospitalizacion;

                    cmd.Parameters.Add("@FechaIngreso", SqlDbType.Date);
                    cmd.Parameters["@FechaIngreso"].Value = registroEgresoHospitalarioDTO.FechaIngreso;

                    cmd.Parameters.Add("@HoraIngreso", SqlDbType.Time);
                    cmd.Parameters["@HoraIngreso"].Value = registroEgresoHospitalarioDTO.HoraIngreso;

                    cmd.Parameters.Add("@FechaEgreso", SqlDbType.Date);
                    cmd.Parameters["@FechaEgreso"].Value = registroEgresoHospitalarioDTO.FechaEgreso;

                    cmd.Parameters.Add("@HoraEgreso", SqlDbType.Time);
                    cmd.Parameters["@HoraEgreso"].Value = registroEgresoHospitalarioDTO.HoraEgreso;

                    cmd.Parameters.Add("@EspecialidadMedicoTratanteIngreso", SqlDbType.VarChar, 200);
                    cmd.Parameters["@EspecialidadMedicoTratanteIngreso"].Value = registroEgresoHospitalarioDTO.EspecialidadMedicoTratanteIngreso;

                    cmd.Parameters.Add("@NombreMedicoIngreso", SqlDbType.VarChar, 200);
                    cmd.Parameters["@NombreMedicoIngreso"].Value = registroEgresoHospitalarioDTO.NombreMedicoIngreso;

                    cmd.Parameters.Add("@DiagnosticoIngreso", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DiagnosticoIngreso"].Value = registroEgresoHospitalarioDTO.DiagnosticoIngreso;

                    cmd.Parameters.Add("@EspecialidadMedicoTratanteEgreso", SqlDbType.VarChar, 200);
                    cmd.Parameters["@EspecialidadMedicoTratanteEgreso"].Value = registroEgresoHospitalarioDTO.EspecialidadMedicoTratanteEgreso;

                    cmd.Parameters.Add("@NombreMedicoEgreso", SqlDbType.VarChar, 200);
                    cmd.Parameters["@NombreMedicoEgreso"].Value = registroEgresoHospitalarioDTO.NombreMedicoEgreso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEgresoHospitalarioDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroEgresoHospitalarioDTO registroEgresoHospitalarioDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEgresoHospitalarioEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEgresoHospitalarioId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEgresoHospitalarioId"].Value = registroEgresoHospitalarioDTO.RegistroEgresoHospitalarioId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEgresoHospitalarioDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RegistroEgresoHospitalarioRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEgresoHospitalario", SqlDbType.Structured);
                    cmd.Parameters["@RegistroEgresoHospitalario"].TypeName = "Formato.RegistroEgresoHospitalario";
                    cmd.Parameters["@RegistroEgresoHospitalario"].Value = datos;

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
