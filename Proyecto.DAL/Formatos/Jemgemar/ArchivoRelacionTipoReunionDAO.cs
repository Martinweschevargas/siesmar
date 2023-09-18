using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Jemgemar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Marina.Siesmar.AccesoDatos.Formatos.Jemgemar
{
    public class ArchivoRelacionTipoReunionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ArchivoRelacionTipoReunionDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ArchivoRelacionTipoReunionDTO> lista = new List<ArchivoRelacionTipoReunionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ArchivoRelacionTipoReunionListar", conexion);
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
                        lista.Add(new ArchivoRelacionTipoReunionDTO()
                        {
                            ArchivoRelacionTipoReunionId = Convert.ToInt32(dr["ArchivoRelacionTipoReunionId"]),
                            CodigoReunion = dr["CodigoReunion"].ToString(),
                            CondicionPais = dr["CondicionPais"].ToString(),
                            NombrePais = dr["NombrePais"].ToString(),
                            NroReunion = dr["NroReunion"].ToString(),
                            NroParticipantes = Convert.ToInt32(dr["NroParticipantes"]),
                            NroDiasRelacionReunion = Convert.ToInt32(dr["NroDiasRelacionReunion"]),
                            GastosRelacionReunion = Convert.ToDecimal(dr["GastosRelacionReunion"]),
                            Observaciones = dr["Observaciones"].ToString(),
                            AFPersonal = Convert.ToInt32(dr["AFPersonal"]),
                            AFInteligencia = Convert.ToInt32(dr["AFInteligencia"]),
                            AFOperacionEntrenamiento = Convert.ToInt32(dr["AFOperacionEntrenamiento"]),
                            AFLogistica = Convert.ToInt32(dr["AFLogistica"]),
                            AFTelematica = Convert.ToInt32(dr["AFTelematica"]),
                            AFInstruccion = Convert.ToInt32(dr["AFInstruccion"]),
                            AFAccionCivica = Convert.ToInt32(dr["AFAccionCivica"]),
                            AFCienciaTecnologia = Convert.ToInt32(dr["AFCienciaTecnologia"]),
                            AFTerrorismoNarcotrafico = Convert.ToInt32(dr["AFTerrorismoNarcotrafico"]),
                            AFMedioAmbiente = Convert.ToInt32(dr["AFMedioAmbiente"]),
                            APPersonal = Convert.ToInt32(dr["APPersonal"]),
                            APInteligencia = Convert.ToInt32(dr["APInteligencia"]),
                            APOperacionEntrenamiento = Convert.ToInt32(dr["APOperacionEntrenamiento"]),
                            APLogistica = Convert.ToInt32(dr["APLogistica"]),
                            APTelematica = Convert.ToInt32(dr["APTelematica"]),
                            APInstruccion = Convert.ToInt32(dr["APInstruccion"]),
                            APAccionCivica = Convert.ToInt32(dr["APAccionCivica"]),
                            APCienciaTecnologia = Convert.ToInt32(dr["APCienciaTecnologia"]),
                            APTerrorismoNarcotrafico = Convert.ToInt32(dr["APTerrorismoNarcotrafico"]),
                            APMedioAmbiente = Convert.ToInt32(dr["APMedioAmbiente"]),
                            AEPersonal = Convert.ToInt32(dr["AEPersonal"]),
                            AEInteligencia = Convert.ToInt32(dr["AEInteligencia"]),
                            AEOperacionEntrenamiento = Convert.ToInt32(dr["AEOperacionEntrenamiento"]),
                            AELogistica = Convert.ToInt32(dr["AELogistica"]),
                            AETelematica = Convert.ToInt32(dr["AETelematica"]),
                            AEInstruccion = Convert.ToInt32(dr["AEInstruccion"]),
                            AEAccionCivica = Convert.ToInt32(dr["AEAccionCivica"]),
                            AECienciaTecnologia = Convert.ToInt32(dr["AECienciaTecnologia"]),
                            AETerrorismoNarcotrafico = Convert.ToInt32(dr["AETerrorismoNarcotrafico"]),
                            AEMedioAmbiente = Convert.ToInt32(dr["AEMedioAmbiente"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ArchivoRelacionTipoReunionDTO archivoRelacionTipoReunionDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ArchivoRelacionTipoReunionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoReunion", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoReunion"].Value = archivoRelacionTipoReunionDTO.CodigoReunion;

                    cmd.Parameters.Add("@NumericoPais", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumericoPais"].Value = archivoRelacionTipoReunionDTO.NumericoPais;

                    cmd.Parameters.Add("@CondicionPais", SqlDbType.VarChar,20);
                    cmd.Parameters["@CondicionPais"].Value = archivoRelacionTipoReunionDTO.CondicionPais;

                    cmd.Parameters.Add("@NroReunion", SqlDbType.VarChar,20);
                    cmd.Parameters["@NroReunion"].Value = archivoRelacionTipoReunionDTO.NroReunion;

                    cmd.Parameters.Add("@NroParticipantes", SqlDbType.Int);
                    cmd.Parameters["@NroParticipantes"].Value = archivoRelacionTipoReunionDTO.NroParticipantes;

                    cmd.Parameters.Add("@NroDiasRelacionReunion", SqlDbType.Int);
                    cmd.Parameters["@NroDiasRelacionReunion"].Value = archivoRelacionTipoReunionDTO.NroDiasRelacionReunion;

                    cmd.Parameters.Add("@GastosRelacionReunion", SqlDbType.Decimal);
                    cmd.Parameters["@GastosRelacionReunion"].Value = archivoRelacionTipoReunionDTO.GastosRelacionReunion;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar,100);
                    cmd.Parameters["@Observaciones"].Value = archivoRelacionTipoReunionDTO.Observaciones;

                    cmd.Parameters.Add("@AFPersonal", SqlDbType.Int);
                    cmd.Parameters["@AFPersonal"].Value = archivoRelacionTipoReunionDTO.AFPersonal;

                    cmd.Parameters.Add("@AFInteligencia", SqlDbType.Int);
                    cmd.Parameters["@AFInteligencia"].Value = archivoRelacionTipoReunionDTO.AFInteligencia;

                    cmd.Parameters.Add("@AFOperacionEntrenamiento", SqlDbType.Int);
                    cmd.Parameters["@AFOperacionEntrenamiento"].Value = archivoRelacionTipoReunionDTO.AFOperacionEntrenamiento;

                    cmd.Parameters.Add("@AFLogistica", SqlDbType.Int);
                    cmd.Parameters["@AFLogistica"].Value = archivoRelacionTipoReunionDTO.AFLogistica;

                    cmd.Parameters.Add("@AFTelematica", SqlDbType.Int);
                    cmd.Parameters["@AFTelematica"].Value = archivoRelacionTipoReunionDTO.AFTelematica;

                    cmd.Parameters.Add("@AFInstruccion", SqlDbType.Int);
                    cmd.Parameters["@AFInstruccion"].Value = archivoRelacionTipoReunionDTO.AFInstruccion;

                    cmd.Parameters.Add("@AFAccionCivica", SqlDbType.Int);
                    cmd.Parameters["@AFAccionCivica"].Value = archivoRelacionTipoReunionDTO.AFAccionCivica;

                    cmd.Parameters.Add("@AFCienciaTecnologia", SqlDbType.Int);
                    cmd.Parameters["@AFCienciaTecnologia"].Value = archivoRelacionTipoReunionDTO.AFCienciaTecnologia;

                    cmd.Parameters.Add("@AFTerrorismoNarcotrafico", SqlDbType.Int);
                    cmd.Parameters["@AFTerrorismoNarcotrafico"].Value = archivoRelacionTipoReunionDTO.AFTerrorismoNarcotrafico;

                    cmd.Parameters.Add("@AFMedioAmbiente", SqlDbType.Int);
                    cmd.Parameters["@AFMedioAmbiente"].Value = archivoRelacionTipoReunionDTO.AFMedioAmbiente;

                    cmd.Parameters.Add("@APPersonal", SqlDbType.Int);
                    cmd.Parameters["@APPersonal"].Value = archivoRelacionTipoReunionDTO.APPersonal;

                    cmd.Parameters.Add("@APInteligencia", SqlDbType.Int);
                    cmd.Parameters["@APInteligencia"].Value = archivoRelacionTipoReunionDTO.APInteligencia;

                    cmd.Parameters.Add("@APOperacionEntrenamiento", SqlDbType.Int);
                    cmd.Parameters["@APOperacionEntrenamiento"].Value = archivoRelacionTipoReunionDTO.APOperacionEntrenamiento;

                    cmd.Parameters.Add("@APLogistica", SqlDbType.Int);
                    cmd.Parameters["@APLogistica"].Value = archivoRelacionTipoReunionDTO.APLogistica;

                    cmd.Parameters.Add("@APTelematica", SqlDbType.Int);
                    cmd.Parameters["@APTelematica"].Value = archivoRelacionTipoReunionDTO.APTelematica;

                    cmd.Parameters.Add("@APInstruccion", SqlDbType.Int);
                    cmd.Parameters["@APInstruccion"].Value = archivoRelacionTipoReunionDTO.APInstruccion;

                    cmd.Parameters.Add("@APAccionCivica", SqlDbType.Int);
                    cmd.Parameters["@APAccionCivica"].Value = archivoRelacionTipoReunionDTO.APAccionCivica;

                    cmd.Parameters.Add("@APCienciaTecnologia", SqlDbType.Int);
                    cmd.Parameters["@APCienciaTecnologia"].Value = archivoRelacionTipoReunionDTO.APCienciaTecnologia;

                    cmd.Parameters.Add("@APTerrorismoNarcotrafico", SqlDbType.Int);
                    cmd.Parameters["@APTerrorismoNarcotrafico"].Value = archivoRelacionTipoReunionDTO.APTerrorismoNarcotrafico;

                    cmd.Parameters.Add("@APMedioAmbiente", SqlDbType.Int);
                    cmd.Parameters["@APMedioAmbiente"].Value = archivoRelacionTipoReunionDTO.APMedioAmbiente;

                    cmd.Parameters.Add("@AEPersonal", SqlDbType.Int);
                    cmd.Parameters["@AEPersonal"].Value = archivoRelacionTipoReunionDTO.AEPersonal;

                    cmd.Parameters.Add("@AEInteligencia", SqlDbType.Int);
                    cmd.Parameters["@AEInteligencia"].Value = archivoRelacionTipoReunionDTO.AEInteligencia;

                    cmd.Parameters.Add("@AEOperacionEntrenamiento", SqlDbType.Int);
                    cmd.Parameters["@AEOperacionEntrenamiento"].Value = archivoRelacionTipoReunionDTO.AEOperacionEntrenamiento;

                    cmd.Parameters.Add("@AELogistica", SqlDbType.Int);
                    cmd.Parameters["@AELogistica"].Value = archivoRelacionTipoReunionDTO.AELogistica;

                    cmd.Parameters.Add("@AETelematica", SqlDbType.Int);
                    cmd.Parameters["@AETelematica"].Value = archivoRelacionTipoReunionDTO.AETelematica;

                    cmd.Parameters.Add("@AEInstruccion", SqlDbType.Int);
                    cmd.Parameters["@AEInstruccion"].Value = archivoRelacionTipoReunionDTO.AEInstruccion;

                    cmd.Parameters.Add("@AEAccionCivica", SqlDbType.Int);
                    cmd.Parameters["@AEAccionCivica"].Value = archivoRelacionTipoReunionDTO.AEAccionCivica;

                    cmd.Parameters.Add("@AECienciaTecnologia", SqlDbType.Int);
                    cmd.Parameters["@AECienciaTecnologia"].Value = archivoRelacionTipoReunionDTO.AECienciaTecnologia;

                    cmd.Parameters.Add("@AETerrorismoNarcotrafico", SqlDbType.Int);
                    cmd.Parameters["@AETerrorismoNarcotrafico"].Value = archivoRelacionTipoReunionDTO.AETerrorismoNarcotrafico;

                    cmd.Parameters.Add("@AEMedioAmbiente", SqlDbType.Int);
                    cmd.Parameters["@AEMedioAmbiente"].Value = archivoRelacionTipoReunionDTO.AEMedioAmbiente;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = archivoRelacionTipoReunionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoRelacionTipoReunionDTO.UsuarioIngresoRegistro;

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

        public ArchivoRelacionTipoReunionDTO BuscarFormato(int Codigo)
        {
            ArchivoRelacionTipoReunionDTO archivoRelacionTipoReunionDTO = new ArchivoRelacionTipoReunionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ArchivoRelacionTipoReunionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoRelacionTipoReunionId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoRelacionTipoReunionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                            archivoRelacionTipoReunionDTO.ArchivoRelacionTipoReunionId = Convert.ToInt32(dr["ArchivoRelacionTipoReunionId"]);
                            archivoRelacionTipoReunionDTO.CodigoReunion = Regex.Replace(dr["CodigoReunion"].ToString(), @"\s", "");
                            archivoRelacionTipoReunionDTO.NumericoPais = dr["NumericoPais"].ToString();
                            archivoRelacionTipoReunionDTO.CondicionPais = Regex.Replace(dr["CondicionPais"].ToString(), @"\s", "");
                            archivoRelacionTipoReunionDTO.NroReunion = dr["NroReunion"].ToString();
                            archivoRelacionTipoReunionDTO.NroParticipantes = Convert.ToInt32(dr["NroParticipantes"]);
                            archivoRelacionTipoReunionDTO.NroDiasRelacionReunion = Convert.ToInt32(dr["NroDiasRelacionReunion"]);
                            archivoRelacionTipoReunionDTO.GastosRelacionReunion = Convert.ToDecimal(dr["GastosRelacionReunion"]);
                            archivoRelacionTipoReunionDTO.Observaciones = dr["Observaciones"].ToString();
                            archivoRelacionTipoReunionDTO.AFPersonal = Convert.ToInt32(dr["AFPersonal"]);
                            archivoRelacionTipoReunionDTO.AFInteligencia = Convert.ToInt32(dr["AFInteligencia"]);
                            archivoRelacionTipoReunionDTO.AFOperacionEntrenamiento = Convert.ToInt32(dr["AFOperacionEntrenamiento"]);
                            archivoRelacionTipoReunionDTO.AFLogistica = Convert.ToInt32(dr["AFLogistica"]);
                            archivoRelacionTipoReunionDTO.AFTelematica = Convert.ToInt32(dr["AFTelematica"]);
                            archivoRelacionTipoReunionDTO.AFInstruccion = Convert.ToInt32(dr["AFInstruccion"]);
                            archivoRelacionTipoReunionDTO.AFAccionCivica = Convert.ToInt32(dr["AFAccionCivica"]);
                            archivoRelacionTipoReunionDTO.AFCienciaTecnologia = Convert.ToInt32(dr["AFCienciaTecnologia"]);
                            archivoRelacionTipoReunionDTO.AFTerrorismoNarcotrafico = Convert.ToInt32(dr["AFTerrorismoNarcotrafico"]);
                            archivoRelacionTipoReunionDTO.AFMedioAmbiente = Convert.ToInt32(dr["AFMedioAmbiente"]);
                            archivoRelacionTipoReunionDTO.APPersonal = Convert.ToInt32(dr["APPersonal"]);
                            archivoRelacionTipoReunionDTO.APInteligencia = Convert.ToInt32(dr["APInteligencia"]);
                            archivoRelacionTipoReunionDTO.APOperacionEntrenamiento = Convert.ToInt32(dr["APOperacionEntrenamiento"]);
                            archivoRelacionTipoReunionDTO.APLogistica = Convert.ToInt32(dr["APLogistica"]);
                            archivoRelacionTipoReunionDTO.APTelematica = Convert.ToInt32(dr["APTelematica"]);
                            archivoRelacionTipoReunionDTO.APInstruccion = Convert.ToInt32(dr["APInstruccion"]);
                            archivoRelacionTipoReunionDTO.APAccionCivica = Convert.ToInt32(dr["APAccionCivica"]);
                            archivoRelacionTipoReunionDTO.APCienciaTecnologia = Convert.ToInt32(dr["APCienciaTecnologia"]);
                            archivoRelacionTipoReunionDTO.APTerrorismoNarcotrafico = Convert.ToInt32(dr["APTerrorismoNarcotrafico"]);
                            archivoRelacionTipoReunionDTO.APMedioAmbiente = Convert.ToInt32(dr["APMedioAmbiente"]);
                            archivoRelacionTipoReunionDTO.AEPersonal = Convert.ToInt32(dr["AEPersonal"]);
                            archivoRelacionTipoReunionDTO.AEInteligencia = Convert.ToInt32(dr["AEInteligencia"]);
                            archivoRelacionTipoReunionDTO.AEOperacionEntrenamiento = Convert.ToInt32(dr["AEOperacionEntrenamiento"]);
                            archivoRelacionTipoReunionDTO.AELogistica = Convert.ToInt32(dr["AELogistica"]);
                            archivoRelacionTipoReunionDTO.AETelematica = Convert.ToInt32(dr["AETelematica"]);
                            archivoRelacionTipoReunionDTO.AEInstruccion = Convert.ToInt32(dr["AEInstruccion"]);
                            archivoRelacionTipoReunionDTO.AEAccionCivica = Convert.ToInt32(dr["AEAccionCivica"]);
                            archivoRelacionTipoReunionDTO.AECienciaTecnologia = Convert.ToInt32(dr["AECienciaTecnologia"]);
                            archivoRelacionTipoReunionDTO.AETerrorismoNarcotrafico = Convert.ToInt32(dr["AETerrorismoNarcotrafico"]);
                            archivoRelacionTipoReunionDTO.AEMedioAmbiente = Convert.ToInt32(dr["AEMedioAmbiente"]);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return archivoRelacionTipoReunionDTO;
        }

        public string ActualizaFormato(ArchivoRelacionTipoReunionDTO archivoRelacionTipoReunionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ArchivoRelacionTipoReunionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoRelacionTipoReunionId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoRelacionTipoReunionId"].Value = archivoRelacionTipoReunionDTO.ArchivoRelacionTipoReunionId;

                    cmd.Parameters.Add("@CodigoReunion", SqlDbType.VarChar, 12);
                    cmd.Parameters["@CodigoReunion"].Value = archivoRelacionTipoReunionDTO.CodigoReunion;

                    cmd.Parameters.Add("@NumericoPais", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais"].Value = archivoRelacionTipoReunionDTO.NumericoPais;

                    cmd.Parameters.Add("@CondicionPais", SqlDbType.VarChar, 6);
                    cmd.Parameters["@CondicionPais"].Value = archivoRelacionTipoReunionDTO.CondicionPais;

                    cmd.Parameters.Add("@NroReunion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NroReunion"].Value = archivoRelacionTipoReunionDTO.NroReunion;

                    cmd.Parameters.Add("@NroParticipantes", SqlDbType.Int);
                    cmd.Parameters["@NroParticipantes"].Value = archivoRelacionTipoReunionDTO.NroParticipantes;

                    cmd.Parameters.Add("@NroDiasRelacionReunion", SqlDbType.Int);
                    cmd.Parameters["@NroDiasRelacionReunion"].Value = archivoRelacionTipoReunionDTO.NroDiasRelacionReunion;

                    cmd.Parameters.Add("@GastosRelacionReunion", SqlDbType.Decimal);
                    cmd.Parameters["@GastosRelacionReunion"].Value = archivoRelacionTipoReunionDTO.GastosRelacionReunion;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Observaciones"].Value = archivoRelacionTipoReunionDTO.Observaciones;

                    cmd.Parameters.Add("@AFPersonal", SqlDbType.Int);
                    cmd.Parameters["@AFPersonal"].Value = archivoRelacionTipoReunionDTO.AFPersonal;

                    cmd.Parameters.Add("@AFInteligencia", SqlDbType.Int);
                    cmd.Parameters["@AFInteligencia"].Value = archivoRelacionTipoReunionDTO.AFInteligencia;

                    cmd.Parameters.Add("@AFOperacionEntrenamiento", SqlDbType.Int);
                    cmd.Parameters["@AFOperacionEntrenamiento"].Value = archivoRelacionTipoReunionDTO.AFOperacionEntrenamiento;

                    cmd.Parameters.Add("@AFLogistica", SqlDbType.Int);
                    cmd.Parameters["@AFLogistica"].Value = archivoRelacionTipoReunionDTO.AFLogistica;

                    cmd.Parameters.Add("@AFTelematica", SqlDbType.Int);
                    cmd.Parameters["@AFTelematica"].Value = archivoRelacionTipoReunionDTO.AFTelematica;

                    cmd.Parameters.Add("@AFInstruccion", SqlDbType.Int);
                    cmd.Parameters["@AFInstruccion"].Value = archivoRelacionTipoReunionDTO.AFInstruccion;

                    cmd.Parameters.Add("@AFAccionCivica", SqlDbType.Int);
                    cmd.Parameters["@AFAccionCivica"].Value = archivoRelacionTipoReunionDTO.AFAccionCivica;

                    cmd.Parameters.Add("@AFCienciaTecnologia", SqlDbType.Int);
                    cmd.Parameters["@AFCienciaTecnologia"].Value = archivoRelacionTipoReunionDTO.AFCienciaTecnologia;

                    cmd.Parameters.Add("@AFTerrorismoNarcotrafico", SqlDbType.Int);
                    cmd.Parameters["@AFTerrorismoNarcotrafico"].Value = archivoRelacionTipoReunionDTO.AFTerrorismoNarcotrafico;

                    cmd.Parameters.Add("@AFMedioAmbiente", SqlDbType.Int);
                    cmd.Parameters["@AFMedioAmbiente"].Value = archivoRelacionTipoReunionDTO.AFMedioAmbiente;

                    cmd.Parameters.Add("@APPersonal", SqlDbType.Int);
                    cmd.Parameters["@APPersonal"].Value = archivoRelacionTipoReunionDTO.APPersonal;

                    cmd.Parameters.Add("@APInteligencia", SqlDbType.Int);
                    cmd.Parameters["@APInteligencia"].Value = archivoRelacionTipoReunionDTO.APInteligencia;

                    cmd.Parameters.Add("@APOperacionEntrenamiento", SqlDbType.Int);
                    cmd.Parameters["@APOperacionEntrenamiento"].Value = archivoRelacionTipoReunionDTO.APOperacionEntrenamiento;

                    cmd.Parameters.Add("@APLogistica", SqlDbType.Int);
                    cmd.Parameters["@APLogistica"].Value = archivoRelacionTipoReunionDTO.APLogistica;

                    cmd.Parameters.Add("@APTelematica", SqlDbType.Int);
                    cmd.Parameters["@APTelematica"].Value = archivoRelacionTipoReunionDTO.APTelematica;

                    cmd.Parameters.Add("@APInstruccion", SqlDbType.Int);
                    cmd.Parameters["@APInstruccion"].Value = archivoRelacionTipoReunionDTO.APInstruccion;

                    cmd.Parameters.Add("@APAccionCivica", SqlDbType.Int);
                    cmd.Parameters["@APAccionCivica"].Value = archivoRelacionTipoReunionDTO.APAccionCivica;

                    cmd.Parameters.Add("@APCienciaTecnologia", SqlDbType.Int);
                    cmd.Parameters["@APCienciaTecnologia"].Value = archivoRelacionTipoReunionDTO.APCienciaTecnologia;

                    cmd.Parameters.Add("@APTerrorismoNarcotrafico", SqlDbType.Int);
                    cmd.Parameters["@APTerrorismoNarcotrafico"].Value = archivoRelacionTipoReunionDTO.APTerrorismoNarcotrafico;

                    cmd.Parameters.Add("@APMedioAmbiente", SqlDbType.Int);
                    cmd.Parameters["@APMedioAmbiente"].Value = archivoRelacionTipoReunionDTO.APMedioAmbiente;

                    cmd.Parameters.Add("@AEPersonal", SqlDbType.Int);
                    cmd.Parameters["@AEPersonal"].Value = archivoRelacionTipoReunionDTO.AEPersonal;

                    cmd.Parameters.Add("@AEInteligencia", SqlDbType.Int);
                    cmd.Parameters["@AEInteligencia"].Value = archivoRelacionTipoReunionDTO.AEInteligencia;

                    cmd.Parameters.Add("@AEOperacionEntrenamiento", SqlDbType.Int);
                    cmd.Parameters["@AEOperacionEntrenamiento"].Value = archivoRelacionTipoReunionDTO.AEOperacionEntrenamiento;

                    cmd.Parameters.Add("@AELogistica", SqlDbType.Int);
                    cmd.Parameters["@AELogistica"].Value = archivoRelacionTipoReunionDTO.AELogistica;

                    cmd.Parameters.Add("@AETelematica", SqlDbType.Int);
                    cmd.Parameters["@AETelematica"].Value = archivoRelacionTipoReunionDTO.AETelematica;

                    cmd.Parameters.Add("@AEInstruccion", SqlDbType.Int);
                    cmd.Parameters["@AEInstruccion"].Value = archivoRelacionTipoReunionDTO.AEInstruccion;

                    cmd.Parameters.Add("@AEAccionCivica", SqlDbType.Int);
                    cmd.Parameters["@AEAccionCivica"].Value = archivoRelacionTipoReunionDTO.AEAccionCivica;

                    cmd.Parameters.Add("@AECienciaTecnologia", SqlDbType.Int);
                    cmd.Parameters["@AECienciaTecnologia"].Value = archivoRelacionTipoReunionDTO.AECienciaTecnologia;

                    cmd.Parameters.Add("@AETerrorismoNarcotrafico", SqlDbType.Int);
                    cmd.Parameters["@AETerrorismoNarcotrafico"].Value = archivoRelacionTipoReunionDTO.AETerrorismoNarcotrafico;

                    cmd.Parameters.Add("@AEMedioAmbiente", SqlDbType.Int);
                    cmd.Parameters["@AEMedioAmbiente"].Value = archivoRelacionTipoReunionDTO.AEMedioAmbiente;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoRelacionTipoReunionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ArchivoRelacionTipoReunionDTO archivoRelacionTipoReunionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ArchivoRelacionTipoReunionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoRelacionTipoReunionId", SqlDbType.Int);
                    cmd.Parameters["@ArchivoRelacionTipoReunionId"].Value = archivoRelacionTipoReunionDTO.ArchivoRelacionTipoReunionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoRelacionTipoReunionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ArchivoRelacionTipoReunionDTO archivoRelacionTipoReunionDTO)
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
                    cmd.Parameters["@Formato"].Value = "ArchivoRelacionTipoReunion";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = archivoRelacionTipoReunionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = archivoRelacionTipoReunionDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ArchivoRelacionTipoReunionRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArchivoRelacionTipoReunion", SqlDbType.Structured);
                    cmd.Parameters["@ArchivoRelacionTipoReunion"].TypeName = "Formato.ArchivoRelacionTipoReunion";
                    cmd.Parameters["@ArchivoRelacionTipoReunion"].Value = datos;

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
