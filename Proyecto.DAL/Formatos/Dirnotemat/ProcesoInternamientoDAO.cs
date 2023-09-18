using AspNetCore.ReportingServices.ReportProcessing.ReportObjectModel;
using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dirnotemat;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirnotemat
{
    public class ProcesoInternamientoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ProcesoInternamientoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ProcesoInternamientoDTO> lista = new List<ProcesoInternamientoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ProcesoInternamientoListar", conexion);
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
                        lista.Add(new ProcesoInternamientoDTO()
                        {
                            ProcesoInternamientoId = Convert.ToInt32(dr["ProcesoInternamientoId"]),
                            NombreProceso = dr["NombreProceso"].ToString(),
                            NroContratoProceso = dr["NroContratoProceso"].ToString(),
                            DescTipoProcesoDirnotemat = dr["DescTipoProcesoDirnotemat"].ToString(),
                            NroProcesoInternamiento = dr["NroProcesoInternamiento"].ToString(),
                            NroguiaProceso = dr["NroguiaProceso"].ToString(),
                            FechaIngresoProceso = (dr["FechaIngresoProceso"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            TiempoEvaluacion = dr["TiempoEvaluacion"].ToString(),
                            ResultadoEvaluacion = dr["ResultadoEvaluacion"].ToString(),
                            LaboratorioProcesoInternamiento = dr["LaboratorioProcesoInternamiento"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ProcesoInternamientoDTO procesoInternamientoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ProcesoInternamientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NombreProceso", SqlDbType.VarChar, 200);
                    cmd.Parameters["@NombreProceso"].Value = procesoInternamientoDTO.NombreProceso;

                    cmd.Parameters.Add("@NroContratoProceso", SqlDbType.VarChar, 15);
                    cmd.Parameters["@NroContratoProceso"].Value = procesoInternamientoDTO.NroContratoProceso;

                    cmd.Parameters.Add("@CodigoTipoProcesoDirnotemat", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoProcesoDirnotemat"].Value = procesoInternamientoDTO.CodigoTipoProcesoDirnotemat;

                    cmd.Parameters.Add("@NroProcesoInternamiento", SqlDbType.VarChar, 15);
                    cmd.Parameters["@NroProcesoInternamiento"].Value = procesoInternamientoDTO.NroProcesoInternamiento;

                    cmd.Parameters.Add("@NroguiaProceso", SqlDbType.VarChar, 15);
                    cmd.Parameters["@NroguiaProceso"].Value = procesoInternamientoDTO.NroguiaProceso;

                    cmd.Parameters.Add("@FechaIngresoProceso", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoProceso"].Value = procesoInternamientoDTO.FechaIngresoProceso;

                    cmd.Parameters.Add("@TiempoEvaluacion", SqlDbType.Int);
                    cmd.Parameters["@TiempoEvaluacion"].Value = procesoInternamientoDTO.TiempoEvaluacion;

                    cmd.Parameters.Add("@ResultadoEvaluacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@ResultadoEvaluacion"].Value = procesoInternamientoDTO.ResultadoEvaluacion;

                    cmd.Parameters.Add("@LaboratorioProcesoInternamiento", SqlDbType.VarChar, 30);
                    cmd.Parameters["@LaboratorioProcesoInternamiento"].Value = procesoInternamientoDTO.LaboratorioProcesoInternamiento;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = procesoInternamientoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procesoInternamientoDTO.UsuarioIngresoRegistro;

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

        public ProcesoInternamientoDTO BuscarFormato(int Codigo)
        {
            ProcesoInternamientoDTO procesoInternamientoDTO = new ProcesoInternamientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ProcesoInternamientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcesoInternamientoId", SqlDbType.Int);
                    cmd.Parameters["@ProcesoInternamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        procesoInternamientoDTO.ProcesoInternamientoId = Convert.ToInt32(dr["ProcesoInternamientoId"]);
                        procesoInternamientoDTO.NombreProceso = dr["NombreProceso"].ToString();
                        procesoInternamientoDTO.NroContratoProceso = dr["NroContratoProceso"].ToString();
                        procesoInternamientoDTO.CodigoTipoProcesoDirnotemat = dr["CodigoTipoProcesoDirnotemat"].ToString();
                        procesoInternamientoDTO.NroProcesoInternamiento = dr["NroProcesoInternamiento"].ToString();
                        procesoInternamientoDTO.NroguiaProceso = dr["NroguiaProceso"].ToString();
                        procesoInternamientoDTO.FechaIngresoProceso = Convert.ToDateTime(dr["FechaIngresoProceso"]).ToString("yyy-MM-dd");
                        procesoInternamientoDTO.TiempoEvaluacion = dr["TiempoEvaluacion"].ToString();
                        procesoInternamientoDTO.ResultadoEvaluacion = Regex.Replace(dr["ResultadoEvaluacion"].ToString(), @"\s", "");
                        procesoInternamientoDTO.LaboratorioProcesoInternamiento = dr["LaboratorioProcesoInternamiento"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return procesoInternamientoDTO;
        }

        public string ActualizaFormato(ProcesoInternamientoDTO procesoInternamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ProcesoInternamientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcesoInternamientoId", SqlDbType.Int);
                    cmd.Parameters["@ProcesoInternamientoId"].Value = procesoInternamientoDTO.ProcesoInternamientoId;

                    cmd.Parameters.Add("@NombreProceso", SqlDbType.VarChar, 200);
                    cmd.Parameters["@NombreProceso"].Value = procesoInternamientoDTO.NombreProceso;

                    cmd.Parameters.Add("@NroContratoProceso", SqlDbType.VarChar, 15);
                    cmd.Parameters["@NroContratoProceso"].Value = procesoInternamientoDTO.NroContratoProceso;

                    cmd.Parameters.Add("@CodigoTipoProcesoDirnotemat", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoProcesoDirnotemat"].Value = procesoInternamientoDTO.CodigoTipoProcesoDirnotemat;

                    cmd.Parameters.Add("@NroProcesoInternamiento", SqlDbType.VarChar, 15);
                    cmd.Parameters["@NroProcesoInternamiento"].Value = procesoInternamientoDTO.NroProcesoInternamiento;

                    cmd.Parameters.Add("@NroguiaProceso", SqlDbType.VarChar, 15);
                    cmd.Parameters["@NroguiaProceso"].Value = procesoInternamientoDTO.NroguiaProceso;

                    cmd.Parameters.Add("@FechaIngresoProceso", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoProceso"].Value = procesoInternamientoDTO.FechaIngresoProceso;

                    cmd.Parameters.Add("@TiempoEvaluacion", SqlDbType.Int);
                    cmd.Parameters["@TiempoEvaluacion"].Value = procesoInternamientoDTO.TiempoEvaluacion;

                    cmd.Parameters.Add("@ResultadoEvaluacion", SqlDbType.NChar, 10);
                    cmd.Parameters["@ResultadoEvaluacion"].Value = procesoInternamientoDTO.ResultadoEvaluacion;

                    cmd.Parameters.Add("@LaboratorioProcesoInternamiento", SqlDbType.VarChar, 30);
                    cmd.Parameters["@LaboratorioProcesoInternamiento"].Value = procesoInternamientoDTO.LaboratorioProcesoInternamiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procesoInternamientoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ProcesoInternamientoDTO procesoInternamientoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ProcesoInternamientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcesoInternamientoId", SqlDbType.Int);
                    cmd.Parameters["@ProcesoInternamientoId"].Value= procesoInternamientoDTO.ProcesoInternamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procesoInternamientoDTO.UsuarioIngresoRegistro;

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


        public bool EliminarCarga(ProcesoInternamientoDTO procesoInternamientoDTO)
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
                    cmd.Parameters["@Formato"].Value = "ProcesoInternamiento";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = procesoInternamientoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procesoInternamientoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ProcesoInternamientoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcesoInternamiento", SqlDbType.Structured);
                    cmd.Parameters["@ProcesoInternamiento"].TypeName = "Formato.ProcesoInternamiento";
                    cmd.Parameters["@ProcesoInternamiento"].Value = datos;

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
