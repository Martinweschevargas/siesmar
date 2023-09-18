using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dipermar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dipermar
{
    public class ProcedimientoAdministrativoCivilDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ProcedimientoAdministrativoCivilDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ProcedimientoAdministrativoCivilDTO> lista = new List<ProcedimientoAdministrativoCivilDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ProcedimientoAdministrativoCivilListar", conexion);
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
                        lista.Add(new ProcedimientoAdministrativoCivilDTO()
                        {
                            ProcedimientoAdministrativoCivilId = Convert.ToInt32(dr["ProcedimientoAdministrativoCivilId"]),
                            NroDocumentoProcedimientoAdm = dr["NroDocumentoProcedimientoAdm"].ToString(),
                            FechaDocumento = (dr["FechaDocumento"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescCondicionLaboralCivil = dr["DescCondicionLaboralCivil"].ToString(),
                            DescGrupoOcupacionalCivil = dr["DescGrupoOcupacionalCivil"].ToString(),
                            DescCargo = dr["DescCargo"].ToString(),
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            DescInfraccionDisciplinariaCivil = dr["DescInfraccionDisciplinariaCivil"].ToString(),
                            SolicitanteSancion = dr["SolicitanteSancion"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            DescCargoSolicitante = dr["DescCargoSolicitante"].ToString(),
                            DescGradoPersonalMilitarSansion = dr["DescGradoPersonalMilitarSansion"].ToString(),
                            DescCargoImponeSancion = dr["DescCargoImponeSancion"].ToString(),
                            DescSancionDisciplinariaCivil = dr["DescSancionDisciplinariaCivil"].ToString(),
                            InicioSancion = dr["InicioSancion"].ToString(),
                            TerminoSancion = dr["TerminoSancion"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ProcedimientoAdministrativoCivilDTO procedimientoAdministrativoCivilDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ProcedimientoAdministrativoCivilRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NroDocumentoProcedimientoAdm", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NroDocumentoProcedimientoAdm"].Value = procedimientoAdministrativoCivilDTO.NroDocumentoProcedimientoAdm;

                    cmd.Parameters.Add("@FechaDocumento", SqlDbType.Date);
                    cmd.Parameters["@FechaDocumento"].Value = procedimientoAdministrativoCivilDTO.FechaDocumento;

                    cmd.Parameters.Add("@CodigoCondicionLaboralCivil", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoCondicionLaboralCivil"].Value = procedimientoAdministrativoCivilDTO.CodigoCondicionLaboralCivil;

                    cmd.Parameters.Add("@CodigoGrupoOcupacionalCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGrupoOcupacionalCivil"].Value = procedimientoAdministrativoCivilDTO.CodigoGrupoOcupacionalCivil;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCargo"].Value = procedimientoAdministrativoCivilDTO.CodigoCargo;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = procedimientoAdministrativoCivilDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoInfraccionDisciplinariaCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInfraccionDisciplinariaCivil"].Value = procedimientoAdministrativoCivilDTO.CodigoInfraccionDisciplinariaCivil;

                    cmd.Parameters.Add("@SolicitanteSancion", SqlDbType.VarChar, 260);
                    cmd.Parameters["@SolicitanteSancion"].Value = procedimientoAdministrativoCivilDTO.SolicitanteSancion;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = procedimientoAdministrativoCivilDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoCargoSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCargoSolicitante"].Value = procedimientoAdministrativoCivilDTO.CodigoCargoSolicitante;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarSansion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarSansion"].Value = procedimientoAdministrativoCivilDTO.CodigoGradoPersonalMilitarSansion;

                    cmd.Parameters.Add("@CodigoCargoImponeSancion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCargoImponeSancion"].Value = procedimientoAdministrativoCivilDTO.CodigoCargoImponeSancion;

                    cmd.Parameters.Add("@CodigoSancionDisciplinariaCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSancionDisciplinariaCivil"].Value = procedimientoAdministrativoCivilDTO.CodigoSancionDisciplinariaCivil;

                    cmd.Parameters.Add("@InicioSancion", SqlDbType.DateTime);
                    cmd.Parameters["@InicioSancion"].Value = procedimientoAdministrativoCivilDTO.InicioSancion;

                    cmd.Parameters.Add("@TerminoSancion", SqlDbType.DateTime);
                    cmd.Parameters["@TerminoSancion"].Value = procedimientoAdministrativoCivilDTO.TerminoSancion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = procedimientoAdministrativoCivilDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procedimientoAdministrativoCivilDTO.UsuarioIngresoRegistro;

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

        public ProcedimientoAdministrativoCivilDTO BuscarFormato(int Codigo)
        {
            ProcedimientoAdministrativoCivilDTO procedimientoAdministrativoCivilDTO = new ProcedimientoAdministrativoCivilDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ProcedimientoAdministrativoCivilEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcedimientoAdministrativoCivilId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoAdministrativoCivilId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        procedimientoAdministrativoCivilDTO.ProcedimientoAdministrativoCivilId = Convert.ToInt32(dr["ProcedimientoAdministrativoCivilId"]);
                        procedimientoAdministrativoCivilDTO.NroDocumentoProcedimientoAdm = dr["NroDocumentoProcedimientoAdm"].ToString();
                        procedimientoAdministrativoCivilDTO.FechaDocumento = Convert.ToDateTime(dr["FechaDocumento"]).ToString("yyy-MM-dd");
                        procedimientoAdministrativoCivilDTO.CodigoCondicionLaboralCivil = dr["CodigoCondicionLaboralCivil"].ToString();
                        procedimientoAdministrativoCivilDTO.CodigoGrupoOcupacionalCivil = dr["CodigoGrupoOcupacionalCivil"].ToString();
                        procedimientoAdministrativoCivilDTO.CodigoCargo = dr["CodigoCargo"].ToString();
                        procedimientoAdministrativoCivilDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        procedimientoAdministrativoCivilDTO.CodigoInfraccionDisciplinariaCivil = dr["CodigoInfraccionDisciplinariaCivil"].ToString();
                        procedimientoAdministrativoCivilDTO.SolicitanteSancion = dr["SolicitanteSancion"].ToString();
                        procedimientoAdministrativoCivilDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        procedimientoAdministrativoCivilDTO.CodigoCargoSolicitante = dr["CodigoCargoSolicitante"].ToString();
                        procedimientoAdministrativoCivilDTO.CodigoGradoPersonalMilitarSansion = dr["CodigoGradoPersonalMilitarSansion"].ToString();
                        procedimientoAdministrativoCivilDTO.CodigoCargoImponeSancion = dr["CodigoCargoImponeSancion"].ToString();
                        procedimientoAdministrativoCivilDTO.CodigoSancionDisciplinariaCivil = dr["CodigoSancionDisciplinariaCivil"].ToString();
                        procedimientoAdministrativoCivilDTO.InicioSancion = Convert.ToDateTime(dr["InicioSancion"]).ToString("yyy-MM-dd HH:mm:ss");
                        procedimientoAdministrativoCivilDTO.TerminoSancion = Convert.ToDateTime(dr["TerminoSancion"]).ToString("yyy-MM-dd HH:mm:ss");
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return procedimientoAdministrativoCivilDTO;
        }

        public string ActualizaFormato(ProcedimientoAdministrativoCivilDTO procedimientoAdministrativoCivilDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ProcedimientoAdministrativoCivilActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcedimientoAdministrativoCivilId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoAdministrativoCivilId"].Value = procedimientoAdministrativoCivilDTO.ProcedimientoAdministrativoCivilId;

                    cmd.Parameters.Add("@NroDocumentoProcedimientoAdm", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NroDocumentoProcedimientoAdm"].Value = procedimientoAdministrativoCivilDTO.NroDocumentoProcedimientoAdm;

                    cmd.Parameters.Add("@FechaDocumento", SqlDbType.Date);
                    cmd.Parameters["@FechaDocumento"].Value = procedimientoAdministrativoCivilDTO.FechaDocumento;

                    cmd.Parameters.Add("@CodigoCondicionLaboralCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionLaboralCivil"].Value = procedimientoAdministrativoCivilDTO.CodigoCondicionLaboralCivil;

                    cmd.Parameters.Add("@CodigoGrupoOcupacionalCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGrupoOcupacionalCivil"].Value = procedimientoAdministrativoCivilDTO.CodigoGrupoOcupacionalCivil;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCargo"].Value = procedimientoAdministrativoCivilDTO.CodigoCargo;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = procedimientoAdministrativoCivilDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoInfraccionDisciplinariaCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInfraccionDisciplinariaCivil"].Value = procedimientoAdministrativoCivilDTO.CodigoInfraccionDisciplinariaCivil;

                    cmd.Parameters.Add("@SolicitanteSancion", SqlDbType.VarChar, 260);
                    cmd.Parameters["@SolicitanteSancion"].Value = procedimientoAdministrativoCivilDTO.SolicitanteSancion;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = procedimientoAdministrativoCivilDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoCargoSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCargoSolicitante"].Value = procedimientoAdministrativoCivilDTO.CodigoCargoSolicitante;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarSansion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarSansion"].Value = procedimientoAdministrativoCivilDTO.CodigoGradoPersonalMilitarSansion;

                    cmd.Parameters.Add("@CodigoCargoImponeSancion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCargoImponeSancion"].Value = procedimientoAdministrativoCivilDTO.CodigoCargoImponeSancion;

                    cmd.Parameters.Add("@CodigoSancionDisciplinariaCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSancionDisciplinariaCivil"].Value = procedimientoAdministrativoCivilDTO.CodigoSancionDisciplinariaCivil;

                    cmd.Parameters.Add("@InicioSancion", SqlDbType.DateTime);
                    cmd.Parameters["@InicioSancion"].Value = procedimientoAdministrativoCivilDTO.InicioSancion;

                    cmd.Parameters.Add("@TerminoSancion", SqlDbType.DateTime);
                    cmd.Parameters["@TerminoSancion"].Value = procedimientoAdministrativoCivilDTO.TerminoSancion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procedimientoAdministrativoCivilDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ProcedimientoAdministrativoCivilDTO procedimientoAdministrativoCivilDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ProcedimientoAdministrativoCivilEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcedimientoAdministrativoCivilId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoAdministrativoCivilId"].Value = procedimientoAdministrativoCivilDTO.ProcedimientoAdministrativoCivilId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procedimientoAdministrativoCivilDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ProcedimientoAdministrativoCivilDTO procedimientoAdministrativoCivilDTO)
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
                    cmd.Parameters["@Formato"].Value = "ProcedimientoAdministrativoCivil";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = procedimientoAdministrativoCivilDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procedimientoAdministrativoCivilDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ProcedimientoAdministrativoCivilRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcedimientoAdministrativoCivil", SqlDbType.Structured);
                    cmd.Parameters["@ProcedimientoAdministrativoCivil"].TypeName = "Formato.ProcedimientoAdministrativoCivil";
                    cmd.Parameters["@ProcedimientoAdministrativoCivil"].Value = datos;

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
