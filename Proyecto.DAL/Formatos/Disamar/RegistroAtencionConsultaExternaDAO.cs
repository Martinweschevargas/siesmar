using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Disamar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Disamar
{
    public class RegistroAtencionConsultaExternaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RegistroAtencionConsultaExternaDTO> ObtenerLista(int? CargaId=null)
        {
            List<RegistroAtencionConsultaExternaDTO> lista = new List<RegistroAtencionConsultaExternaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroAtencionConsultaExternaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegistroAtencionConsultaExternaDTO()
                        {
                            RegistroAtencionConsultaExternaId = Convert.ToInt32(dr["RegistroAtencionConsultaExternaId"]),
                            DescEntidadMilitar = dr["DescEntidadMilitar"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            DescEstablecimientoSalud = dr["DescEstablecimientoSalud"].ToString(),
                            FechaRegistro = (dr["FechaRegistro"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDitrito = dr["DescDitrito"].ToString(),
                            DescEspecialidadMedicaNoMedica = dr["DescEspecialidadMedicaNoMedica"].ToString(),
                            ResponsableAtencionMedica = dr["ResponsableAtencionMedica"].ToString(),
                            NSACIP = Convert.ToInt32(dr["NSACIP"]),
                            NumeroCMP = Convert.ToInt32(dr["NumeroCMP"]),
                            Turno = dr["Turno"].ToString(),
                            HoraInicio = dr["HoraInicio"].ToString(),
                            HoraTermino = dr["HoraTermino"].ToString(),
                            HistoriaClinica = Convert.ToInt32(dr["HistoriaClinica"]),
                            DNIPaciente = dr["DNIPaciente"].ToString(),
                            DescUnidadDependencia = dr["DescUnidadDependencia"].ToString(),
                            DescDitritoPaciente = dr["DescDitrito"].ToString(),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            SituacionPaciente = dr["SituacionPaciente"].ToString(),
                            CondicionPaciente = dr["CondicionPaciente"].ToString(),
                            EdadPaciente = Convert.ToInt32(dr["EdadPaciente"]),
                            TipoEdad = dr["TipoEdad"].ToString(),
                            SexoPaciente = dr["SexoPaciente"].ToString(),
                            AlEstablecimiento = dr["AlEstablecimiento"].ToString(),
                            AlServicio = dr["AlServicio"].ToString(),
                            CodigoDiagnosticoMotivoAtencion1 = dr["CodigoDiagnosticoMotivoAtencion1"].ToString(),
                            TipoDX1 = dr["TipoDX1"].ToString(),
                            Lab1 = dr["Lab1"].ToString(),
                            CodigoCIE10_1 = dr["CodigoCodigoCIE10_1"].ToString(),
                            CodigoDiagnosticoMotivoAtencion2 = dr["CodigoDiagnosticoMotivoAtencion2"].ToString(),
                            TipoDX2 = dr["TipoDX2"].ToString(),
                            Lab2 = dr["Lab2"].ToString(),
                            CodigoCIE10_2 = dr["CodigoCIE10_2"].ToString(),
                            CodigoDiagnosticoMotivoAtencion3 = dr["CodigoDiagnosticoMotivoAtencion3"].ToString(),
                            TipoDX3 = dr["TipoDX3"].ToString(),
                            Lab3 = dr["Lab3"].ToString(),
                            CodigoCIE10_3 = dr["CodigoCIE10_3"].ToString(),
                            CodigoDiagnosticoMotivoAtencion4 = dr["CodigoDiagnosticoMotivoAtencion4"].ToString(),
                            TipoDX4 = dr["TipoDX4"].ToString(),
                            Lab4 = dr["Lab4"].ToString(),
                            CodigoCIE10_4 = dr["CodigoCIE10_4"].ToString(),
                            CodigoDiagnosticoMotivoAtencion5 = dr["CodigoDiagnosticoMotivoAtencion5"].ToString(),
                            TipoDX5 = dr["TipoDX5"].ToString(),
                            Lab5 = dr["Lab5"].ToString(),
                            CodigoCIE10_5 = dr["CodigoCIE10_5"].ToString(),
                            CodigoDiagnosticoMotivoAtencion6 = dr["CodigoDiagnosticoMotivoAtencion6"].ToString(),
                            TipoDX6 = dr["TipoDX6"].ToString(),
                            Lab6 = dr["Lab6"].ToString(),
                            CodigoCIE10_6 = dr["CodigoCIE10_6"].ToString(),
                            Interconsulta = dr["Interconsulta"].ToString(),
                            CodigoUPSEspecialidadInterconsulta = dr["CodigoUPSEspecialidadInterconsulta"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RegistroAtencionConsultaExternaDTO registroAtencionConsultaExternaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroAtencionConsultaExternaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = registroAtencionConsultaExternaDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = registroAtencionConsultaExternaDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoEstablecimientoSaludMGP", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstablecimientoSaludMGP"].Value = registroAtencionConsultaExternaDTO.CodigoEstablecimientoSaludMGP;

                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.Date);
                    cmd.Parameters["@FechaRegistro"].Value = registroAtencionConsultaExternaDTO.FechaRegistro;


                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar,20);
                    cmd.Parameters["@DistritoUbigeo"].Value = registroAtencionConsultaExternaDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CodigoUPSMedicaNoMedica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUPSMedicaNoMedica"].Value = registroAtencionConsultaExternaDTO.CodigoUPSMedicaNoMedica;

                    cmd.Parameters.Add("@ResponsableAtencionMedica", SqlDbType.VarChar, 200);
                    cmd.Parameters["@ResponsableAtencionMedica"].Value = registroAtencionConsultaExternaDTO.ResponsableAtencionMedica;

                    cmd.Parameters.Add("@NSACIP", SqlDbType.Int);
                    cmd.Parameters["@NSACIP"].Value = registroAtencionConsultaExternaDTO.NSACIP;

                    cmd.Parameters.Add("@NumeroCMP", SqlDbType.Int);
                    cmd.Parameters["@NumeroCMP"].Value = registroAtencionConsultaExternaDTO.NumeroCMP;

                    cmd.Parameters.Add("@Turno", SqlDbType.VarChar, 10);
                    cmd.Parameters["@Turno"].Value = registroAtencionConsultaExternaDTO.Turno;

                    cmd.Parameters.Add("@HoraInicio", SqlDbType.Time);
                    cmd.Parameters["@HoraInicio"].Value = registroAtencionConsultaExternaDTO.HoraInicio;

                    cmd.Parameters.Add("@HoraTermino", SqlDbType.Time);
                    cmd.Parameters["@HoraTermino"].Value = registroAtencionConsultaExternaDTO.HoraTermino;

                    cmd.Parameters.Add("@HistoriaClinica", SqlDbType.Int);
                    cmd.Parameters["@HistoriaClinica"].Value = registroAtencionConsultaExternaDTO.HistoriaClinica;

                    cmd.Parameters.Add("@DNIPaciente", SqlDbType.VarChar,8);
                    cmd.Parameters["@DNIPaciente"].Value = registroAtencionConsultaExternaDTO.DNIPaciente;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = registroAtencionConsultaExternaDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@DistritoPaciente", SqlDbType.VarChar,20);
                    cmd.Parameters["@DistritoPaciente"].Value = registroAtencionConsultaExternaDTO.DistritoPaciente;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = registroAtencionConsultaExternaDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = registroAtencionConsultaExternaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@SituacionPaciente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SituacionPaciente"].Value = registroAtencionConsultaExternaDTO.SituacionPaciente;

                    cmd.Parameters.Add("@CondicionPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CondicionPaciente"].Value = registroAtencionConsultaExternaDTO.CondicionPaciente;

                    cmd.Parameters.Add("@EdadPaciente", SqlDbType.Int);
                    cmd.Parameters["@EdadPaciente"].Value = registroAtencionConsultaExternaDTO.EdadPaciente;

                    cmd.Parameters.Add("@TipoEdad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TipoEdad"].Value = registroAtencionConsultaExternaDTO.TipoEdad;

                    cmd.Parameters.Add("@SexoPaciente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPaciente"].Value = registroAtencionConsultaExternaDTO.SexoPaciente;

                    cmd.Parameters.Add("@AlEstablecimiento", SqlDbType.VarChar, 15);
                    cmd.Parameters["@AlEstablecimiento"].Value = registroAtencionConsultaExternaDTO.AlEstablecimiento;

                    cmd.Parameters.Add("@AlServicio", SqlDbType.VarChar, 15);
                    cmd.Parameters["@AlServicio"].Value = registroAtencionConsultaExternaDTO.AlServicio;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion1", SqlDbType.Int);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion1"].Value = registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion1;

                    cmd.Parameters.Add("@TipoDX1", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX1"].Value = registroAtencionConsultaExternaDTO.TipoDX1;

                    cmd.Parameters.Add("@Lab1", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Lab1"].Value = registroAtencionConsultaExternaDTO.Lab1;

                    cmd.Parameters.Add("@CodigoCIE10_1", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_1"].Value = registroAtencionConsultaExternaDTO.CodigoCIE10_1;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion2"].Value = registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion2;

                    cmd.Parameters.Add("@TipoDX2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@TipoDX2"].Value = registroAtencionConsultaExternaDTO.TipoDX2;

                    cmd.Parameters.Add("@Lab2", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Lab2"].Value = registroAtencionConsultaExternaDTO.Lab2;

                    cmd.Parameters.Add("@CodigoCIE10_2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_2"].Value = registroAtencionConsultaExternaDTO.CodigoCIE10_2;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion3", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion3"].Value = registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion3;

                    cmd.Parameters.Add("@TipoDX3", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX3"].Value = registroAtencionConsultaExternaDTO.TipoDX3;

                    cmd.Parameters.Add("@Lab3", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Lab3"].Value = registroAtencionConsultaExternaDTO.Lab3;

                    cmd.Parameters.Add("@CodigoCIE10_3", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_3"].Value = registroAtencionConsultaExternaDTO.CodigoCIE10_3;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion4", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion4"].Value = registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion4;

                    cmd.Parameters.Add("@TipoDX4", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX4"].Value = registroAtencionConsultaExternaDTO.TipoDX4;

                    cmd.Parameters.Add("@Lab4", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Lab4"].Value = registroAtencionConsultaExternaDTO.Lab4;

                    cmd.Parameters.Add("@CodigoCIE10_4", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_4"].Value = registroAtencionConsultaExternaDTO.CodigoCIE10_4;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion5", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion5"].Value = registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion5;

                    cmd.Parameters.Add("@TipoDX5", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX5"].Value = registroAtencionConsultaExternaDTO.TipoDX5;

                    cmd.Parameters.Add("@Lab5", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Lab5"].Value = registroAtencionConsultaExternaDTO.Lab5;

                    cmd.Parameters.Add("@CodigoCIE10_5", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_5"].Value = registroAtencionConsultaExternaDTO.CodigoCIE10_5;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion6", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion6"].Value = registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion6;

                    cmd.Parameters.Add("@TipoDX6", SqlDbType.VarChar);
                    cmd.Parameters["@TipoDX6"].Value = registroAtencionConsultaExternaDTO.TipoDX6;

                    cmd.Parameters.Add("@Lab6", SqlDbType.VarChar);
                    cmd.Parameters["@Lab6"].Value = registroAtencionConsultaExternaDTO.Lab6;

                    cmd.Parameters.Add("@CodigoCIE10_6", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_6"].Value = registroAtencionConsultaExternaDTO.CodigoCIE10_6;

                    cmd.Parameters.Add("@Interconsulta", SqlDbType.VarChar, 2);
                    cmd.Parameters["@Interconsulta"].Value = registroAtencionConsultaExternaDTO.Interconsulta;

                    cmd.Parameters.Add("@CodigoUPSEspecialidadInterconsulta", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUPSEspecialidadInterconsulta"].Value = registroAtencionConsultaExternaDTO.CodigoUPSEspecialidadInterconsulta;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = registroAtencionConsultaExternaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroAtencionConsultaExternaDTO.UsuarioIngresoRegistro;

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

        public RegistroAtencionConsultaExternaDTO BuscarFormato(int Codigo)
        {
            RegistroAtencionConsultaExternaDTO registroAtencionConsultaExternaDTO = new RegistroAtencionConsultaExternaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroAtencionConsultaExternaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroAtencionConsultaExternaId", SqlDbType.Int);
                    cmd.Parameters["@RegistroAtencionConsultaExternaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        registroAtencionConsultaExternaDTO.RegistroAtencionConsultaExternaId = Convert.ToInt32(dr["RegistroAtencionConsultaExternaId"]);
                        registroAtencionConsultaExternaDTO.CodigoEntidadMilitar = dr["CodigoEntidadMilitar"].ToString();
                        registroAtencionConsultaExternaDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        registroAtencionConsultaExternaDTO.CodigoEstablecimientoSaludMGP = dr["CodigoEstablecimientoSaludMGP"].ToString();
                        registroAtencionConsultaExternaDTO.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]).ToString("yyy-MM-dd");
                        registroAtencionConsultaExternaDTO.DistritoUbigeo = dr["DistritoUbigeo"].ToString();
                        registroAtencionConsultaExternaDTO.CodigoUPSMedicaNoMedica = dr["CodigoUPSMedicaNoMedica"].ToString();
                        registroAtencionConsultaExternaDTO.ResponsableAtencionMedica = dr["ResponsableAtencionMedica"].ToString();
                        registroAtencionConsultaExternaDTO.NSACIP = Convert.ToInt32(dr["NSACIP"]);
                        registroAtencionConsultaExternaDTO.NumeroCMP = Convert.ToInt32(dr["NumeroCMP"]);
                        registroAtencionConsultaExternaDTO.Turno = dr["Turno"].ToString();
                        registroAtencionConsultaExternaDTO.HoraInicio = dr["HoraInicio"].ToString();
                        registroAtencionConsultaExternaDTO.HoraTermino = dr["HoraTermino"].ToString();
                        registroAtencionConsultaExternaDTO.HistoriaClinica = Convert.ToInt32(dr["HistoriaClinica"]);
                        registroAtencionConsultaExternaDTO.DNIPaciente = dr["DNIPaciente"].ToString();
                        registroAtencionConsultaExternaDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        registroAtencionConsultaExternaDTO.DistritoPaciente = dr["DistritoPaciente"].ToString();
                        registroAtencionConsultaExternaDTO.CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar"].ToString();
                        registroAtencionConsultaExternaDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        registroAtencionConsultaExternaDTO.SituacionPaciente = dr["SituacionPaciente"].ToString();
                        registroAtencionConsultaExternaDTO.CondicionPaciente = dr["CondicionPaciente"].ToString();
                        registroAtencionConsultaExternaDTO.EdadPaciente = Convert.ToInt32(dr["EdadPaciente"]);
                        registroAtencionConsultaExternaDTO.TipoEdad = dr["TipoEdad"].ToString();
                        registroAtencionConsultaExternaDTO.SexoPaciente = dr["SexoPaciente"].ToString();
                        registroAtencionConsultaExternaDTO.AlEstablecimiento = dr["AlEstablecimiento"].ToString();
                        registroAtencionConsultaExternaDTO.AlServicio = dr["AlServicio"].ToString();
                        registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion1 = dr["CodigoDiagnosticoMotivoAtencion1"].ToString();
                        registroAtencionConsultaExternaDTO.TipoDX1 = dr["TipoDX1"].ToString();
                        registroAtencionConsultaExternaDTO.Lab1 = dr["Lab1"].ToString();
                        registroAtencionConsultaExternaDTO.CodigoCIE10_1 = dr["CodigoCIE10_1"].ToString();
                        registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion2 = dr["CodigoDiagnosticoMotivoAtencion2"].ToString();
                        registroAtencionConsultaExternaDTO.TipoDX2 = dr["TipoDX2"].ToString();
                        registroAtencionConsultaExternaDTO.Lab2 = dr["Lab2"].ToString();
                        registroAtencionConsultaExternaDTO.CodigoCIE10_2 = dr["CodigoCIE10_2"].ToString();
                        registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion3 = dr["CodigoDiagnosticoMotivoAtencion3"].ToString();
                        registroAtencionConsultaExternaDTO.TipoDX3 = dr["TipoDX3"].ToString();
                        registroAtencionConsultaExternaDTO.Lab3 = dr["Lab3"].ToString();
                        registroAtencionConsultaExternaDTO.CodigoCIE10_3 = dr["CodigoCIE10_3"].ToString();
                        registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion4 = dr["CodigoDiagnosticoMotivoAtencion4"].ToString();
                        registroAtencionConsultaExternaDTO.TipoDX4 = dr["TipoDX4"].ToString();
                        registroAtencionConsultaExternaDTO.Lab4 = dr["Lab4"].ToString();
                        registroAtencionConsultaExternaDTO.CodigoCIE10_4 = dr["CodigoCIE10_4"].ToString();
                        registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion5 = dr["CodigoDiagnosticoMotivoAtencion5"].ToString();
                        registroAtencionConsultaExternaDTO.TipoDX5 = dr["TipoDX5"].ToString();
                        registroAtencionConsultaExternaDTO.Lab5 = dr["Lab5"].ToString();
                        registroAtencionConsultaExternaDTO.CodigoCIE10_5 = dr["CodigoCIE10_5"].ToString();
                        registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion6 = dr["CodigoDiagnosticoMotivoAtencion6"].ToString();
                        registroAtencionConsultaExternaDTO.TipoDX6 = dr["TipoDX6"].ToString();
                        registroAtencionConsultaExternaDTO.Lab6 = dr["Lab6"].ToString();
                        registroAtencionConsultaExternaDTO.CodigoCIE10_6 = dr["CodigoCIE10_6"].ToString();
                        registroAtencionConsultaExternaDTO.Interconsulta = dr["Interconsulta"].ToString();
                        registroAtencionConsultaExternaDTO.CodigoUPSEspecialidadInterconsulta = dr["CodigoUPSEspecialidadInterconsulta"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroAtencionConsultaExternaDTO;
        }

        public string ActualizaFormato(RegistroAtencionConsultaExternaDTO registroAtencionConsultaExternaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroAtencionConsultaExternaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RegistroAtencionConsultaExternaId", SqlDbType.Int);
                    cmd.Parameters["@RegistroAtencionConsultaExternaId"].Value = registroAtencionConsultaExternaDTO.RegistroAtencionConsultaExternaId;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = registroAtencionConsultaExternaDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = registroAtencionConsultaExternaDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoEstablecimientoSaludMGP", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstablecimientoSaludMGP"].Value = registroAtencionConsultaExternaDTO.CodigoEstablecimientoSaludMGP;

                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.Date);
                    cmd.Parameters["@FechaRegistro"].Value = registroAtencionConsultaExternaDTO.FechaRegistro;


                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = registroAtencionConsultaExternaDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CodigoUPSMedicaNoMedica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUPSMedicaNoMedica"].Value = registroAtencionConsultaExternaDTO.CodigoUPSMedicaNoMedica;

                    cmd.Parameters.Add("@ResponsableAtencionMedica", SqlDbType.VarChar, 200);
                    cmd.Parameters["@ResponsableAtencionMedica"].Value = registroAtencionConsultaExternaDTO.ResponsableAtencionMedica;

                    cmd.Parameters.Add("@NSACIP", SqlDbType.Int);
                    cmd.Parameters["@NSACIP"].Value = registroAtencionConsultaExternaDTO.NSACIP;

                    cmd.Parameters.Add("@NumeroCMP", SqlDbType.Int);
                    cmd.Parameters["@NumeroCMP"].Value = registroAtencionConsultaExternaDTO.NumeroCMP;

                    cmd.Parameters.Add("@Turno", SqlDbType.VarChar, 10);
                    cmd.Parameters["@Turno"].Value = registroAtencionConsultaExternaDTO.Turno;

                    cmd.Parameters.Add("@HoraInicio", SqlDbType.Time);
                    cmd.Parameters["@HoraInicio"].Value = registroAtencionConsultaExternaDTO.HoraInicio;

                    cmd.Parameters.Add("@HoraTermino", SqlDbType.Time);
                    cmd.Parameters["@HoraTermino"].Value = registroAtencionConsultaExternaDTO.HoraTermino;

                    cmd.Parameters.Add("@HistoriaClinica", SqlDbType.Int);
                    cmd.Parameters["@HistoriaClinica"].Value = registroAtencionConsultaExternaDTO.HistoriaClinica;

                    cmd.Parameters.Add("@DNIPaciente", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPaciente"].Value = registroAtencionConsultaExternaDTO.DNIPaciente;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = registroAtencionConsultaExternaDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@DistritoPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoPaciente"].Value = registroAtencionConsultaExternaDTO.DistritoPaciente;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = registroAtencionConsultaExternaDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = registroAtencionConsultaExternaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@SituacionPaciente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SituacionPaciente"].Value = registroAtencionConsultaExternaDTO.SituacionPaciente;

                    cmd.Parameters.Add("@CondicionPaciente", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CondicionPaciente"].Value = registroAtencionConsultaExternaDTO.CondicionPaciente;

                    cmd.Parameters.Add("@EdadPaciente", SqlDbType.Int);
                    cmd.Parameters["@EdadPaciente"].Value = registroAtencionConsultaExternaDTO.EdadPaciente;

                    cmd.Parameters.Add("@TipoEdad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TipoEdad"].Value = registroAtencionConsultaExternaDTO.TipoEdad;

                    cmd.Parameters.Add("@SexoPaciente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPaciente"].Value = registroAtencionConsultaExternaDTO.SexoPaciente;

                    cmd.Parameters.Add("@AlEstablecimiento", SqlDbType.VarChar, 15);
                    cmd.Parameters["@AlEstablecimiento"].Value = registroAtencionConsultaExternaDTO.AlEstablecimiento;

                    cmd.Parameters.Add("@AlServicio", SqlDbType.VarChar, 15);
                    cmd.Parameters["@AlServicio"].Value = registroAtencionConsultaExternaDTO.AlServicio;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion1", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion1"].Value = registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion1;

                    cmd.Parameters.Add("@TipoDX1", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX1"].Value = registroAtencionConsultaExternaDTO.TipoDX1;

                    cmd.Parameters.Add("@Lab1", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Lab1"].Value = registroAtencionConsultaExternaDTO.Lab1;

                    cmd.Parameters.Add("@CodigoCIE10_1", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_1"].Value = registroAtencionConsultaExternaDTO.CodigoCIE10_1;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion2"].Value = registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion2;

                    cmd.Parameters.Add("@TipoDX2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@TipoDX2"].Value = registroAtencionConsultaExternaDTO.TipoDX2;

                    cmd.Parameters.Add("@Lab2", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Lab2"].Value = registroAtencionConsultaExternaDTO.Lab2;

                    cmd.Parameters.Add("@CodigoCIE10_2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_2"].Value = registroAtencionConsultaExternaDTO.CodigoCIE10_2;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion3", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion3"].Value = registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion3;

                    cmd.Parameters.Add("@TipoDX3", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX3"].Value = registroAtencionConsultaExternaDTO.TipoDX3;

                    cmd.Parameters.Add("@Lab3", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Lab3"].Value = registroAtencionConsultaExternaDTO.Lab3;

                    cmd.Parameters.Add("@CodigoCIE10_3", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_3"].Value = registroAtencionConsultaExternaDTO.CodigoCIE10_3;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion4", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion4"].Value = registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion4;

                    cmd.Parameters.Add("@TipoDX4", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX4"].Value = registroAtencionConsultaExternaDTO.TipoDX4;

                    cmd.Parameters.Add("@Lab4", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Lab4"].Value = registroAtencionConsultaExternaDTO.Lab4;

                    cmd.Parameters.Add("@CodigoCIE10_4", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_4"].Value = registroAtencionConsultaExternaDTO.CodigoCIE10_4;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion5", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion5"].Value = registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion5;

                    cmd.Parameters.Add("@TipoDX5", SqlDbType.VarChar, 15);
                    cmd.Parameters["@TipoDX5"].Value = registroAtencionConsultaExternaDTO.TipoDX5;

                    cmd.Parameters.Add("@Lab5", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Lab5"].Value = registroAtencionConsultaExternaDTO.Lab5;

                    cmd.Parameters.Add("@CodigoCIE10_5", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_5"].Value = registroAtencionConsultaExternaDTO.CodigoCIE10_5;

                    cmd.Parameters.Add("@CodigoDiagnosticoMotivoAtencion6", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDiagnosticoMotivoAtencion6"].Value = registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion6;

                    cmd.Parameters.Add("@TipoDX6", SqlDbType.VarChar);
                    cmd.Parameters["@TipoDX6"].Value = registroAtencionConsultaExternaDTO.TipoDX6;

                    cmd.Parameters.Add("@Lab6", SqlDbType.VarChar);
                    cmd.Parameters["@Lab6"].Value = registroAtencionConsultaExternaDTO.Lab6;

                    cmd.Parameters.Add("@CodigoCIE10_6", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCIE10_6"].Value = registroAtencionConsultaExternaDTO.CodigoCIE10_6;

                    cmd.Parameters.Add("@Interconsulta", SqlDbType.VarChar, 2);
                    cmd.Parameters["@Interconsulta"].Value = registroAtencionConsultaExternaDTO.Interconsulta;

                    cmd.Parameters.Add("@CodigoUPSEspecialidadInterconsulta", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUPSEspecialidadInterconsulta"].Value = registroAtencionConsultaExternaDTO.CodigoUPSEspecialidadInterconsulta;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroAtencionConsultaExternaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroAtencionConsultaExternaDTO registroAtencionConsultaExternaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroAtencionConsultaExternaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroAtencionConsultaExternaId", SqlDbType.Int);
                    cmd.Parameters["@RegistroAtencionConsultaExternaId"].Value = registroAtencionConsultaExternaDTO.RegistroAtencionConsultaExternaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroAtencionConsultaExternaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RegistroAtencionConsultaExternaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroAtencionConsultaExterna", SqlDbType.Structured);
                    cmd.Parameters["@RegistroAtencionConsultaExterna"].TypeName = "Formato.RegistroAtencionConsultaExterna";
                    cmd.Parameters["@RegistroAtencionConsultaExterna"].Value = datos;

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
