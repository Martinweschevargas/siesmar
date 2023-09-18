using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Ipecamar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Ipecamar
{
    public class InspeccionInstitucionalesDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<InspeccionInstitucionalesDTO> ObtenerLista(int? CargaId=null)
        {
            List<InspeccionInstitucionalesDTO> lista = new List<InspeccionInstitucionalesDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_InspeccionInstitucionalesListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new InspeccionInstitucionalesDTO()
                        {
                            InspeccionInstitucionalId = Convert.ToInt32(dr["InspeccionInstitucionalId"]),
                            FechaInicioInspeccion = (dr["FechaInicioInspeccion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTerminoInspeccion = (dr["FechaTerminoInspeccion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DuracionInspeccion = Convert.ToInt32(dr["DuracionInspeccion"]),
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            DescComandanciaDependencia = dr["DescComandanciaDependencia"].ToString(),
                            DescNivelDependencia = dr["DescNivelDependencia"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            DescInspeccionConocimiento = dr["DescInspeccionConocimiento"].ToString(),
                            DescInspeccionExtension = dr["DescInspeccionExtension"].ToString(),
                            DescInspeccionFinalidad = dr["DescInspeccionFinalidad"].ToString(),
                            DescOrganoControlInspeccion = dr["DescOrganoControlInspeccion"].ToString(),
                            QInspectorParticipante = Convert.ToInt32(dr["QInspectorParticipante"]),
                            DeficienciaOperAdm = Convert.ToInt32(dr["DeficienciaOperAdm"]),
                            DeficienciaComunesOperAdm = Convert.ToInt32(dr["DeficienciaComunesOperAdm"]),
                            ApreciacionOperAdm = Convert.ToInt32(dr["ApreciacionOperAdm"]),
                            ObservacionOperAdm = Convert.ToInt32(dr["ObservacionOperAdm"]),
                            IrregularidadOperAdm = Convert.ToInt32(dr["IrregularidadOperAdm"]),
                            DeficienciaControlGestion = Convert.ToInt32(dr["DeficienciaControlGestion"]),
                            DeficienciaComunControlG = Convert.ToInt32(dr["DeficienciaComunControlG"]),
                            ApreciacionControlGestion = Convert.ToInt32(dr["ApreciacionControlGestion"]),
                            ObservacionControlGestion = Convert.ToInt32(dr["ObservacionControlGestion"]),
                            IrregularidadControlGestion = Convert.ToInt32(dr["IrregularidadControlGestion"]),
                            DeficienciaPendOperAdm = Convert.ToInt32(dr["DeficienciaPendOperAdm"]),
                            DeficienciaComunPendOperAdm = Convert.ToInt32(dr["DeficienciaComunPendOperAdm"]),
                            ApreciacionPendOperAdm = Convert.ToInt32(dr["ApreciacionPendOperAdm"]),
                            ObservacionPendOperAdm = Convert.ToInt32(dr["ObservacionPendOperAdm"]),
                            IrregularidadPendOperAdm = Convert.ToInt32(dr["IrregularidadPendOperAdm"]),
                            DeficienciaPendControlGestion = Convert.ToInt32(dr["DeficienciaPendControlGestion"]),
                            DeficienciaComunPendControlGestion = Convert.ToInt32(dr["DeficienciaComunPendControlGestion"]),
                            ApreciacionPendControlGestion = Convert.ToInt32(dr["ApreciacionPendControlGestion"]),
                            ObservacionPendControlGestion = Convert.ToInt32(dr["ObservacionPendControlGestion"]),
                            IrregularidadPendControlGestion = Convert.ToInt32(dr["IrregularidadPendControlGestion"]),
                            DeficienciaSuperadaOperAdm = Convert.ToInt32(dr["DeficienciaSuperadaOperAdm"]),
                            DeficienciaComunSuperadaOperAdm = Convert.ToInt32(dr["DeficienciaComunSuperadaOperAdm"]),
                            ApreciacionSuperadaOperAdm = Convert.ToInt32(dr["ApreciacionSuperadaOperAdm"]),
                            ObservacionSuperadaOperAdm = Convert.ToInt32(dr["ObservacionSuperadaOperAdm"]),
                            IrregularidadSuperadaOperAdm = Convert.ToInt32(dr["IrregularidadSuperadaOperAdm"]),
                            DeficienciaSuperadaControlGestion = Convert.ToInt32(dr["DeficienciaSuperadaControlGestion"]),
                            DeficienciaComunSuperadaControlGestion = Convert.ToInt32(dr["DeficienciaComunSuperadaControlGestion"]),
                            ApreciacionSuperadaControlGestion = Convert.ToInt32(dr["ApreciacionSuperadaControlGestion"]),
                            ObservacionSuperadaControlGestion = Convert.ToInt32(dr["ObservacionSuperadaControlGestion"]),
                            IrregularidadSuperadaControlGestion = Convert.ToInt32(dr["IrregularidadSuperadaControlGestion"]),
                            FTotalDeficiencias = Convert.ToInt32(dr["FTotalDeficiencias"]),
                            FTotalApreciaciones = Convert.ToInt32(dr["FTotalApreciaciones"]),
                            FTotalObservaciones = Convert.ToInt32(dr["FTotalObservaciones"]),
                            FTotalIrregularidades = Convert.ToInt32(dr["FTotalIrregularidades"]),
                            FTotalDeficienciaSuperadas = Convert.ToInt32(dr["FTotalDeficienciaSuperadas"]),
                            FTotalApreciacionSuperadas = Convert.ToInt32(dr["FTotalApreciacionSuperadas"]),
                            FTotalObservacionSuperadas = Convert.ToInt32(dr["FTotalObservacionSuperadas"]),
                            FTotalIrregularidadSuperadas = Convert.ToInt32(dr["FTotalIrregularidadSuperadas"]),
                            FTotalDeficienciasPendientes = Convert.ToInt32(dr["FTotalDeficienciasPendientes"]),
                            FTotalApreciacionesPendientes = Convert.ToInt32(dr["FTotalApreciacionesPendientes"]),
                            FTotalObservacionPendientes = Convert.ToInt32(dr["FTotalObservacionPendientes"]),
                            FTotalIrregularidadPendientes = Convert.ToInt32(dr["FTotalIrregularidadPendientes"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(InspeccionInstitucionalesDTO inspeccionInstitucionalesDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InspeccionInstitucionalesRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaInicioInspeccion", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioInspeccion"].Value = inspeccionInstitucionalesDTO.FechaInicioInspeccion;

                    cmd.Parameters.Add("@FechaTerminoInspeccion", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoInspeccion"].Value = inspeccionInstitucionalesDTO.FechaTerminoInspeccion;

                    cmd.Parameters.Add("@DuracionInspeccion", SqlDbType.Int);
                    cmd.Parameters["@DuracionInspeccion"].Value = inspeccionInstitucionalesDTO.DuracionInspeccion;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDependencia"].Value = inspeccionInstitucionalesDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoComandanciaDependencia"].Value = inspeccionInstitucionalesDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@CodigoNivelDependencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoNivelDependencia"].Value = inspeccionInstitucionalesDTO.CodigoNivelDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = inspeccionInstitucionalesDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoInspeccionConocimiento", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoInspeccionConocimiento"].Value = inspeccionInstitucionalesDTO.CodigoInspeccionConocimiento;

                    cmd.Parameters.Add("@CodigoInspeccionExtension", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoInspeccionExtension"].Value = inspeccionInstitucionalesDTO.CodigoInspeccionExtension;

                    cmd.Parameters.Add("@CodigoInspeccionFinalidad", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoInspeccionFinalidad"].Value = inspeccionInstitucionalesDTO.CodigoInspeccionFinalidad;

                    cmd.Parameters.Add("@CodigoOrganoControlInspeccion", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoOrganoControlInspeccion"].Value = inspeccionInstitucionalesDTO.CodigoOrganoControlInspeccion;

                    cmd.Parameters.Add("@QInspectorParticipante", SqlDbType.Int);
                    cmd.Parameters["@QInspectorParticipante"].Value = inspeccionInstitucionalesDTO.QInspectorParticipante;

                    cmd.Parameters.Add("@DeficienciaOperAdm", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaOperAdm"].Value = inspeccionInstitucionalesDTO.DeficienciaOperAdm;

                    cmd.Parameters.Add("@DeficienciaComunesOperAdm", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaComunesOperAdm"].Value = inspeccionInstitucionalesDTO.DeficienciaComunesOperAdm;

                    cmd.Parameters.Add("@ApreciacionOperAdm", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionOperAdm"].Value = inspeccionInstitucionalesDTO.ApreciacionOperAdm;

                    cmd.Parameters.Add("@ObservacionOperAdm", SqlDbType.Int);
                    cmd.Parameters["@ObservacionOperAdm"].Value = inspeccionInstitucionalesDTO.ObservacionOperAdm;

                    cmd.Parameters.Add("@IrregularidadOperAdm", SqlDbType.Int);
                    cmd.Parameters["@IrregularidadOperAdm"].Value = inspeccionInstitucionalesDTO.IrregularidadOperAdm;

                    cmd.Parameters.Add("@DeficienciaControlGestion", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaControlGestion"].Value = inspeccionInstitucionalesDTO.DeficienciaControlGestion;

                    cmd.Parameters.Add("@DeficienciaComunControlG", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaComunControlG"].Value = inspeccionInstitucionalesDTO.DeficienciaComunControlG;

                    cmd.Parameters.Add("@ApreciacionControlGestion", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionControlGestion"].Value = inspeccionInstitucionalesDTO.ApreciacionControlGestion;

                    cmd.Parameters.Add("@ObservacionControlGestion", SqlDbType.Int);
                    cmd.Parameters["@ObservacionControlGestion"].Value = inspeccionInstitucionalesDTO.ObservacionControlGestion;

                    cmd.Parameters.Add("@IrregularidadControlGestion", SqlDbType.Int);
                    cmd.Parameters["@IrregularidadControlGestion"].Value = inspeccionInstitucionalesDTO.IrregularidadControlGestion;

                    cmd.Parameters.Add("@DeficienciaPendOperAdm", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaPendOperAdm"].Value = inspeccionInstitucionalesDTO.DeficienciaPendOperAdm;

                    cmd.Parameters.Add("@DeficienciaComunPendOperAdm", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaComunPendOperAdm"].Value = inspeccionInstitucionalesDTO.DeficienciaComunPendOperAdm;

                    cmd.Parameters.Add("@ApreciacionPendOperAdm", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionPendOperAdm"].Value = inspeccionInstitucionalesDTO.ApreciacionPendOperAdm;

                    cmd.Parameters.Add("@ObservacionPendOperAdm", SqlDbType.Int);
                    cmd.Parameters["@ObservacionPendOperAdm"].Value = inspeccionInstitucionalesDTO.ObservacionPendOperAdm;

                    cmd.Parameters.Add("@IrregularidadPendOperAdm", SqlDbType.Int);
                    cmd.Parameters["@IrregularidadPendOperAdm"].Value = inspeccionInstitucionalesDTO.IrregularidadPendOperAdm;

                    cmd.Parameters.Add("@DeficienciaPendControlGestion", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaPendControlGestion"].Value = inspeccionInstitucionalesDTO.DeficienciaPendControlGestion;

                    cmd.Parameters.Add("@DeficienciaComunPendControlGestion", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaComunPendControlGestion"].Value = inspeccionInstitucionalesDTO.DeficienciaComunPendControlGestion;

                    cmd.Parameters.Add("@ApreciacionPendControlGestion", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionPendControlGestion"].Value = inspeccionInstitucionalesDTO.ApreciacionPendControlGestion;

                    cmd.Parameters.Add("@ObservacionPendControlGestion", SqlDbType.Int);
                    cmd.Parameters["@ObservacionPendControlGestion"].Value = inspeccionInstitucionalesDTO.ObservacionPendControlGestion;

                    cmd.Parameters.Add("@IrregularidadPendControlGestion", SqlDbType.Int);
                    cmd.Parameters["@IrregularidadPendControlGestion"].Value = inspeccionInstitucionalesDTO.IrregularidadPendControlGestion;

                    cmd.Parameters.Add("@DeficienciaSuperadaOperAdm", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaSuperadaOperAdm"].Value = inspeccionInstitucionalesDTO.DeficienciaSuperadaOperAdm;

                    cmd.Parameters.Add("@DeficienciaComunSuperadaOperAdm", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaComunSuperadaOperAdm"].Value = inspeccionInstitucionalesDTO.DeficienciaComunSuperadaOperAdm;

                    cmd.Parameters.Add("@ApreciacionSuperadaOperAdm", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionSuperadaOperAdm"].Value = inspeccionInstitucionalesDTO.ApreciacionSuperadaOperAdm;

                    cmd.Parameters.Add("@ObservacionSuperadaOperAdm", SqlDbType.Int);
                    cmd.Parameters["@ObservacionSuperadaOperAdm"].Value = inspeccionInstitucionalesDTO.ObservacionSuperadaOperAdm;

                    cmd.Parameters.Add("@IrregularidadSuperadaOperAdm", SqlDbType.Int);
                    cmd.Parameters["@IrregularidadSuperadaOperAdm"].Value = inspeccionInstitucionalesDTO.IrregularidadSuperadaOperAdm;

                    cmd.Parameters.Add("@DeficienciaSuperadaControlGestion", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaSuperadaControlGestion"].Value = inspeccionInstitucionalesDTO.DeficienciaSuperadaControlGestion;

                    cmd.Parameters.Add("@DeficienciaComunSuperadaControlGestion", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaComunSuperadaControlGestion"].Value = inspeccionInstitucionalesDTO.DeficienciaComunSuperadaControlGestion;

                    cmd.Parameters.Add("@ApreciacionSuperadaControlGestion", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionSuperadaControlGestion"].Value = inspeccionInstitucionalesDTO.ApreciacionSuperadaControlGestion;

                    cmd.Parameters.Add("@ObservacionSuperadaControlGestion", SqlDbType.Int);
                    cmd.Parameters["@ObservacionSuperadaControlGestion"].Value = inspeccionInstitucionalesDTO.ObservacionSuperadaControlGestion;

                    cmd.Parameters.Add("@IrregularidadSuperadaControlGestion", SqlDbType.Int);
                    cmd.Parameters["@IrregularidadSuperadaControlGestion"].Value = inspeccionInstitucionalesDTO.IrregularidadSuperadaControlGestion;

                    cmd.Parameters.Add("@FTotalDeficiencias", SqlDbType.Int);
                    cmd.Parameters["@FTotalDeficiencias"].Value = inspeccionInstitucionalesDTO.FTotalDeficiencias;

                    cmd.Parameters.Add("@FTotalApreciaciones", SqlDbType.Int);
                    cmd.Parameters["@FTotalApreciaciones"].Value = inspeccionInstitucionalesDTO.FTotalApreciaciones;

                    cmd.Parameters.Add("@FTotalObservaciones", SqlDbType.Int);
                    cmd.Parameters["@FTotalObservaciones"].Value = inspeccionInstitucionalesDTO.FTotalObservaciones;

                    cmd.Parameters.Add("@FTotalIrregularidades", SqlDbType.Int);
                    cmd.Parameters["@FTotalIrregularidades"].Value = inspeccionInstitucionalesDTO.FTotalIrregularidades;

                    cmd.Parameters.Add("@FTotalDeficienciaSuperadas", SqlDbType.Int);
                    cmd.Parameters["@FTotalDeficienciaSuperadas"].Value = inspeccionInstitucionalesDTO.FTotalDeficienciaSuperadas;

                    cmd.Parameters.Add("@FTotalApreciacionSuperadas", SqlDbType.Int);
                    cmd.Parameters["@FTotalApreciacionSuperadas"].Value = inspeccionInstitucionalesDTO.FTotalApreciacionSuperadas;

                    cmd.Parameters.Add("@FTotalObservacionSuperadas", SqlDbType.Int);
                    cmd.Parameters["@FTotalObservacionSuperadas"].Value = inspeccionInstitucionalesDTO.FTotalObservacionSuperadas;

                    cmd.Parameters.Add("@FTotalIrregularidadSuperadas", SqlDbType.Int);
                    cmd.Parameters["@FTotalIrregularidadSuperadas"].Value = inspeccionInstitucionalesDTO.FTotalIrregularidadSuperadas;

                    cmd.Parameters.Add("@FTotalDeficienciasPendientes", SqlDbType.Int);
                    cmd.Parameters["@FTotalDeficienciasPendientes"].Value = inspeccionInstitucionalesDTO.FTotalDeficienciasPendientes;

                    cmd.Parameters.Add("@FTotalApreciacionesPendientes", SqlDbType.Int);
                    cmd.Parameters["@FTotalApreciacionesPendientes"].Value = inspeccionInstitucionalesDTO.FTotalApreciacionesPendientes;

                    cmd.Parameters.Add("@FTotalObservacionPendientes", SqlDbType.Int);
                    cmd.Parameters["@FTotalObservacionPendientes"].Value = inspeccionInstitucionalesDTO.FTotalObservacionPendientes;

                    cmd.Parameters.Add("@FTotalIrregularidadPendientes", SqlDbType.Int);
                    cmd.Parameters["@FTotalIrregularidadPendientes"].Value = inspeccionInstitucionalesDTO.FTotalIrregularidadPendientes;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = inspeccionInstitucionalesDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inspeccionInstitucionalesDTO.UsuarioIngresoRegistro;

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

        public InspeccionInstitucionalesDTO BuscarFormato(int Codigo)
        {
            InspeccionInstitucionalesDTO inspeccionInstitucionalesDTO = new InspeccionInstitucionalesDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InspeccionInstitucionalesEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InspeccionInstitucionalId", SqlDbType.Int);
                    cmd.Parameters["@InspeccionInstitucionalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        inspeccionInstitucionalesDTO.InspeccionInstitucionalId = Convert.ToInt32(dr["InspeccionInstitucionalId"]);
                        inspeccionInstitucionalesDTO.FechaInicioInspeccion = Convert.ToDateTime(dr["FechaInicioInspeccion"]).ToString("yyy-MM-dd");
                        inspeccionInstitucionalesDTO.FechaTerminoInspeccion = Convert.ToDateTime(dr["FechaTerminoInspeccion"]).ToString("yyy-MM-dd");
                        inspeccionInstitucionalesDTO.DuracionInspeccion = Convert.ToInt32(dr["DuracionInspeccion"]);
                        inspeccionInstitucionalesDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        inspeccionInstitucionalesDTO.CodigoComandanciaDependencia = dr["CodigoComandanciaDependencia"].ToString();
                        inspeccionInstitucionalesDTO.CodigoNivelDependencia = dr["CodigoNivelDependencia"].ToString();
                        inspeccionInstitucionalesDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        inspeccionInstitucionalesDTO.CodigoInspeccionConocimiento = dr["CodigoInspeccionConocimiento"].ToString();
                        inspeccionInstitucionalesDTO.CodigoInspeccionExtension =    dr["CodigoInspeccionExtension"].ToString();
                        inspeccionInstitucionalesDTO.CodigoInspeccionFinalidad = dr["CodigoInspeccionFinalidad"].ToString();
                        inspeccionInstitucionalesDTO.CodigoOrganoControlInspeccion = dr["CodigoOrganoControlInspeccion"].ToString();
                        inspeccionInstitucionalesDTO.QInspectorParticipante = Convert.ToInt32(dr["QInspectorParticipante"]);
                        inspeccionInstitucionalesDTO.DeficienciaOperAdm = Convert.ToInt32(dr["DeficienciaOperAdm"]);
                        inspeccionInstitucionalesDTO.DeficienciaComunesOperAdm = Convert.ToInt32(dr["DeficienciaComunesOperAdm"]);
                        inspeccionInstitucionalesDTO.ApreciacionOperAdm = Convert.ToInt32(dr["ApreciacionOperAdm"]);
                        inspeccionInstitucionalesDTO.ObservacionOperAdm = Convert.ToInt32(dr["ObservacionOperAdm"]);
                        inspeccionInstitucionalesDTO.IrregularidadOperAdm = Convert.ToInt32(dr["IrregularidadOperAdm"]);
                        inspeccionInstitucionalesDTO.DeficienciaControlGestion = Convert.ToInt32(dr["DeficienciaControlGestion"]);
                        inspeccionInstitucionalesDTO.DeficienciaComunControlG = Convert.ToInt32(dr["DeficienciaComunControlG"]);
                        inspeccionInstitucionalesDTO.ApreciacionControlGestion = Convert.ToInt32(dr["ApreciacionControlGestion"]);
                        inspeccionInstitucionalesDTO.ObservacionControlGestion = Convert.ToInt32(dr["ObservacionControlGestion"]);
                        inspeccionInstitucionalesDTO.IrregularidadControlGestion = Convert.ToInt32(dr["IrregularidadControlGestion"]);
                        inspeccionInstitucionalesDTO.DeficienciaPendOperAdm = Convert.ToInt32(dr["DeficienciaPendOperAdm"]);
                        inspeccionInstitucionalesDTO.DeficienciaComunPendOperAdm = Convert.ToInt32(dr["DeficienciaComunPendOperAdm"]);
                        inspeccionInstitucionalesDTO.ApreciacionPendOperAdm = Convert.ToInt32(dr["ApreciacionPendOperAdm"]);
                        inspeccionInstitucionalesDTO.ObservacionPendOperAdm = Convert.ToInt32(dr["ObservacionPendOperAdm"]);
                        inspeccionInstitucionalesDTO.IrregularidadPendOperAdm = Convert.ToInt32(dr["IrregularidadPendOperAdm"]);
                        inspeccionInstitucionalesDTO.DeficienciaPendControlGestion = Convert.ToInt32(dr["DeficienciaPendControlGestion"]);
                        inspeccionInstitucionalesDTO.DeficienciaComunPendControlGestion = Convert.ToInt32(dr["DeficienciaComunPendControlGestion"]);
                        inspeccionInstitucionalesDTO.ApreciacionPendControlGestion = Convert.ToInt32(dr["ApreciacionPendControlGestion"]);
                        inspeccionInstitucionalesDTO.ObservacionPendControlGestion = Convert.ToInt32(dr["ObservacionPendControlGestion"]);
                        inspeccionInstitucionalesDTO.IrregularidadPendControlGestion = Convert.ToInt32(dr["IrregularidadPendControlGestion"]);
                        inspeccionInstitucionalesDTO.DeficienciaSuperadaOperAdm = Convert.ToInt32(dr["DeficienciaSuperadaOperAdm"]);
                        inspeccionInstitucionalesDTO.DeficienciaComunSuperadaOperAdm = Convert.ToInt32(dr["DeficienciaComunSuperadaOperAdm"]);
                        inspeccionInstitucionalesDTO.ApreciacionSuperadaOperAdm = Convert.ToInt32(dr["ApreciacionSuperadaOperAdm"]);
                        inspeccionInstitucionalesDTO.ObservacionSuperadaOperAdm = Convert.ToInt32(dr["ObservacionSuperadaOperAdm"]);
                        inspeccionInstitucionalesDTO.IrregularidadSuperadaOperAdm = Convert.ToInt32(dr["IrregularidadSuperadaOperAdm"]);
                        inspeccionInstitucionalesDTO.DeficienciaSuperadaControlGestion = Convert.ToInt32(dr["DeficienciaSuperadaControlGestion"]);
                        inspeccionInstitucionalesDTO.DeficienciaComunSuperadaControlGestion = Convert.ToInt32(dr["DeficienciaComunSuperadaControlGestion"]);
                        inspeccionInstitucionalesDTO.ApreciacionSuperadaControlGestion = Convert.ToInt32(dr["ApreciacionSuperadaControlGestion"]);
                        inspeccionInstitucionalesDTO.ObservacionSuperadaControlGestion = Convert.ToInt32(dr["ObservacionSuperadaControlGestion"]);
                        inspeccionInstitucionalesDTO.IrregularidadSuperadaControlGestion = Convert.ToInt32(dr["IrregularidadSuperadaControlGestion"]);
                        inspeccionInstitucionalesDTO.FTotalDeficiencias = Convert.ToInt32(dr["FTotalDeficiencias"]);
                        inspeccionInstitucionalesDTO.FTotalApreciaciones = Convert.ToInt32(dr["FTotalApreciaciones"]);
                        inspeccionInstitucionalesDTO.FTotalObservaciones = Convert.ToInt32(dr["FTotalObservaciones"]);
                        inspeccionInstitucionalesDTO.FTotalIrregularidades = Convert.ToInt32(dr["FTotalIrregularidades"]);
                        inspeccionInstitucionalesDTO.FTotalDeficienciaSuperadas = Convert.ToInt32(dr["FTotalDeficienciaSuperadas"]);
                        inspeccionInstitucionalesDTO.FTotalApreciacionSuperadas = Convert.ToInt32(dr["FTotalApreciacionSuperadas"]);
                        inspeccionInstitucionalesDTO.FTotalObservacionSuperadas = Convert.ToInt32(dr["FTotalObservacionSuperadas"]);
                        inspeccionInstitucionalesDTO.FTotalIrregularidadSuperadas = Convert.ToInt32(dr["FTotalIrregularidadSuperadas"]);
                        inspeccionInstitucionalesDTO.FTotalDeficienciasPendientes = Convert.ToInt32(dr["FTotalDeficienciasPendientes"]);
                        inspeccionInstitucionalesDTO.FTotalApreciacionesPendientes = Convert.ToInt32(dr["FTotalApreciacionesPendientes"]);
                        inspeccionInstitucionalesDTO.FTotalObservacionPendientes = Convert.ToInt32(dr["FTotalObservacionPendientes"]);
                        inspeccionInstitucionalesDTO.FTotalIrregularidadPendientes = Convert.ToInt32(dr["FTotalIrregularidadPendientes"]); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return inspeccionInstitucionalesDTO;
        }

        public string ActualizaFormato(InspeccionInstitucionalesDTO inspeccionInstitucionalesDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_InspeccionInstitucionalesActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@InspeccionInstitucionalId", SqlDbType.Int);
                    cmd.Parameters["@InspeccionInstitucionalId"].Value = inspeccionInstitucionalesDTO.InspeccionInstitucionalId;

                    cmd.Parameters.Add("@FechaInicioInspeccion", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioInspeccion"].Value = inspeccionInstitucionalesDTO.FechaInicioInspeccion;

                    cmd.Parameters.Add("@FechaTerminoInspeccion", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoInspeccion"].Value = inspeccionInstitucionalesDTO.FechaTerminoInspeccion;

                    cmd.Parameters.Add("@DuracionInspeccion", SqlDbType.Int);
                    cmd.Parameters["@DuracionInspeccion"].Value = inspeccionInstitucionalesDTO.DuracionInspeccion;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = inspeccionInstitucionalesDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComandanciaDependencia"].Value = inspeccionInstitucionalesDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@CodigoNivelDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoNivelDependencia"].Value = inspeccionInstitucionalesDTO.CodigoNivelDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = inspeccionInstitucionalesDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoInspeccionConocimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInspeccionConocimiento"].Value = inspeccionInstitucionalesDTO.CodigoInspeccionConocimiento;

                    cmd.Parameters.Add("@CodigoInspeccionExtension", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInspeccionExtension"].Value = inspeccionInstitucionalesDTO.CodigoInspeccionExtension;

                    cmd.Parameters.Add("@CodigoInspeccionFinalidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInspeccionFinalidad"].Value = inspeccionInstitucionalesDTO.CodigoInspeccionFinalidad;

                    cmd.Parameters.Add("@CodigoOrganoControlInspeccion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoOrganoControlInspeccion"].Value = inspeccionInstitucionalesDTO.CodigoOrganoControlInspeccion;

                    cmd.Parameters.Add("@QInspectorParticipante", SqlDbType.Int);
                    cmd.Parameters["@QInspectorParticipante"].Value = inspeccionInstitucionalesDTO.QInspectorParticipante;

                    cmd.Parameters.Add("@DeficienciaOperAdm", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaOperAdm"].Value = inspeccionInstitucionalesDTO.DeficienciaOperAdm;

                    cmd.Parameters.Add("@DeficienciaComunesOperAdm", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaComunesOperAdm"].Value = inspeccionInstitucionalesDTO.DeficienciaComunesOperAdm;

                    cmd.Parameters.Add("@ApreciacionOperAdm", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionOperAdm"].Value = inspeccionInstitucionalesDTO.ApreciacionOperAdm;

                    cmd.Parameters.Add("@ObservacionOperAdm", SqlDbType.Int);
                    cmd.Parameters["@ObservacionOperAdm"].Value = inspeccionInstitucionalesDTO.ObservacionOperAdm;

                    cmd.Parameters.Add("@IrregularidadOperAdm", SqlDbType.Int);
                    cmd.Parameters["@IrregularidadOperAdm"].Value = inspeccionInstitucionalesDTO.IrregularidadOperAdm;

                    cmd.Parameters.Add("@DeficienciaControlGestion", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaControlGestion"].Value = inspeccionInstitucionalesDTO.DeficienciaControlGestion;

                    cmd.Parameters.Add("@DeficienciaComunControlG", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaComunControlG"].Value = inspeccionInstitucionalesDTO.DeficienciaComunControlG;

                    cmd.Parameters.Add("@ApreciacionControlGestion", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionControlGestion"].Value = inspeccionInstitucionalesDTO.ApreciacionControlGestion;

                    cmd.Parameters.Add("@ObservacionControlGestion", SqlDbType.Int);
                    cmd.Parameters["@ObservacionControlGestion"].Value = inspeccionInstitucionalesDTO.ObservacionControlGestion;

                    cmd.Parameters.Add("@IrregularidadControlGestion", SqlDbType.Int);
                    cmd.Parameters["@IrregularidadControlGestion"].Value = inspeccionInstitucionalesDTO.IrregularidadControlGestion;

                    cmd.Parameters.Add("@DeficienciaPendOperAdm", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaPendOperAdm"].Value = inspeccionInstitucionalesDTO.DeficienciaPendOperAdm;

                    cmd.Parameters.Add("@DeficienciaComunPendOperAdm", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaComunPendOperAdm"].Value = inspeccionInstitucionalesDTO.DeficienciaComunPendOperAdm;

                    cmd.Parameters.Add("@ApreciacionPendOperAdm", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionPendOperAdm"].Value = inspeccionInstitucionalesDTO.ApreciacionPendOperAdm;

                    cmd.Parameters.Add("@ObservacionPendOperAdm", SqlDbType.Int);
                    cmd.Parameters["@ObservacionPendOperAdm"].Value = inspeccionInstitucionalesDTO.ObservacionPendOperAdm;

                    cmd.Parameters.Add("@IrregularidadPendOperAdm", SqlDbType.Int);
                    cmd.Parameters["@IrregularidadPendOperAdm"].Value = inspeccionInstitucionalesDTO.IrregularidadPendOperAdm;

                    cmd.Parameters.Add("@DeficienciaPendControlGestion", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaPendControlGestion"].Value = inspeccionInstitucionalesDTO.DeficienciaPendControlGestion;

                    cmd.Parameters.Add("@DeficienciaComunPendControlGestion", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaComunPendControlGestion"].Value = inspeccionInstitucionalesDTO.DeficienciaComunPendControlGestion;

                    cmd.Parameters.Add("@ApreciacionPendControlGestion", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionPendControlGestion"].Value = inspeccionInstitucionalesDTO.ApreciacionPendControlGestion;

                    cmd.Parameters.Add("@ObservacionPendControlGestion", SqlDbType.Int);
                    cmd.Parameters["@ObservacionPendControlGestion"].Value = inspeccionInstitucionalesDTO.ObservacionPendControlGestion;

                    cmd.Parameters.Add("@IrregularidadPendControlGestion", SqlDbType.Int);
                    cmd.Parameters["@IrregularidadPendControlGestion"].Value = inspeccionInstitucionalesDTO.IrregularidadPendControlGestion;

                    cmd.Parameters.Add("@DeficienciaSuperadaOperAdm", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaSuperadaOperAdm"].Value = inspeccionInstitucionalesDTO.DeficienciaSuperadaOperAdm;

                    cmd.Parameters.Add("@DeficienciaComunSuperadaOperAdm", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaComunSuperadaOperAdm"].Value = inspeccionInstitucionalesDTO.DeficienciaComunSuperadaOperAdm;

                    cmd.Parameters.Add("@ApreciacionSuperadaOperAdm", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionSuperadaOperAdm"].Value = inspeccionInstitucionalesDTO.ApreciacionSuperadaOperAdm;

                    cmd.Parameters.Add("@ObservacionSuperadaOperAdm", SqlDbType.Int);
                    cmd.Parameters["@ObservacionSuperadaOperAdm"].Value = inspeccionInstitucionalesDTO.ObservacionSuperadaOperAdm;

                    cmd.Parameters.Add("@IrregularidadSuperadaOperAdm", SqlDbType.Int);
                    cmd.Parameters["@IrregularidadSuperadaOperAdm"].Value = inspeccionInstitucionalesDTO.IrregularidadSuperadaOperAdm;

                    cmd.Parameters.Add("@DeficienciaSuperadaControlGestion", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaSuperadaControlGestion"].Value = inspeccionInstitucionalesDTO.DeficienciaSuperadaControlGestion;

                    cmd.Parameters.Add("@DeficienciaComunSuperadaControlGestion", SqlDbType.Int);
                    cmd.Parameters["@DeficienciaComunSuperadaControlGestion"].Value = inspeccionInstitucionalesDTO.DeficienciaComunSuperadaControlGestion;

                    cmd.Parameters.Add("@ApreciacionSuperadaControlGestion", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionSuperadaControlGestion"].Value = inspeccionInstitucionalesDTO.ApreciacionSuperadaControlGestion;

                    cmd.Parameters.Add("@ObservacionSuperadaControlGestion", SqlDbType.Int);
                    cmd.Parameters["@ObservacionSuperadaControlGestion"].Value = inspeccionInstitucionalesDTO.ObservacionSuperadaControlGestion;

                    cmd.Parameters.Add("@IrregularidadSuperadaControlGestion", SqlDbType.Int);
                    cmd.Parameters["@IrregularidadSuperadaControlGestion"].Value = inspeccionInstitucionalesDTO.IrregularidadSuperadaControlGestion;

                    cmd.Parameters.Add("@FTotalDeficiencias", SqlDbType.Int);
                    cmd.Parameters["@FTotalDeficiencias"].Value = inspeccionInstitucionalesDTO.FTotalDeficiencias;

                    cmd.Parameters.Add("@FTotalApreciaciones", SqlDbType.Int);
                    cmd.Parameters["@FTotalApreciaciones"].Value = inspeccionInstitucionalesDTO.FTotalApreciaciones;

                    cmd.Parameters.Add("@FTotalObservaciones", SqlDbType.Int);
                    cmd.Parameters["@FTotalObservaciones"].Value = inspeccionInstitucionalesDTO.FTotalObservaciones;

                    cmd.Parameters.Add("@FTotalIrregularidades", SqlDbType.Int);
                    cmd.Parameters["@FTotalIrregularidades"].Value = inspeccionInstitucionalesDTO.FTotalIrregularidades;

                    cmd.Parameters.Add("@FTotalDeficienciaSuperadas", SqlDbType.Int);
                    cmd.Parameters["@FTotalDeficienciaSuperadas"].Value = inspeccionInstitucionalesDTO.FTotalDeficienciaSuperadas;

                    cmd.Parameters.Add("@FTotalApreciacionSuperadas", SqlDbType.Int);
                    cmd.Parameters["@FTotalApreciacionSuperadas"].Value = inspeccionInstitucionalesDTO.FTotalApreciacionSuperadas;

                    cmd.Parameters.Add("@FTotalObservacionSuperadas", SqlDbType.Int);
                    cmd.Parameters["@FTotalObservacionSuperadas"].Value = inspeccionInstitucionalesDTO.FTotalObservacionSuperadas;

                    cmd.Parameters.Add("@FTotalIrregularidadSuperadas", SqlDbType.Int);
                    cmd.Parameters["@FTotalIrregularidadSuperadas"].Value = inspeccionInstitucionalesDTO.FTotalIrregularidadSuperadas;

                    cmd.Parameters.Add("@FTotalDeficienciasPendientes", SqlDbType.Int);
                    cmd.Parameters["@FTotalDeficienciasPendientes"].Value = inspeccionInstitucionalesDTO.FTotalDeficienciasPendientes;

                    cmd.Parameters.Add("@FTotalApreciacionesPendientes", SqlDbType.Int);
                    cmd.Parameters["@FTotalApreciacionesPendientes"].Value = inspeccionInstitucionalesDTO.FTotalApreciacionesPendientes;

                    cmd.Parameters.Add("@FTotalObservacionPendientes", SqlDbType.Int);
                    cmd.Parameters["@FTotalObservacionPendientes"].Value = inspeccionInstitucionalesDTO.FTotalObservacionPendientes;

                    cmd.Parameters.Add("@FTotalIrregularidadPendientes", SqlDbType.Int);
                    cmd.Parameters["@FTotalIrregularidadPendientes"].Value = inspeccionInstitucionalesDTO.FTotalIrregularidadPendientes;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inspeccionInstitucionalesDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(InspeccionInstitucionalesDTO inspeccionInstitucionalesDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InspeccionInstitucionalesEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InspeccionInstitucionalId", SqlDbType.Int);
                    cmd.Parameters["@InspeccionInstitucionalId"].Value = inspeccionInstitucionalesDTO.InspeccionInstitucionalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inspeccionInstitucionalesDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_InspeccionInstitucionalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InspeccionInstitucional", SqlDbType.Structured);
                    cmd.Parameters["@InspeccionInstitucional"].TypeName = "Formato.InspeccionInstitucional";
                    cmd.Parameters["@InspeccionInstitucional"].Value = datos;

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
