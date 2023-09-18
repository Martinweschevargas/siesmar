using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diali
{
    public class LicenciaArmasMenoresMilitarDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<LicenciaArmasMenoresMilitarDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<LicenciaArmasMenoresMilitarDTO> lista = new List<LicenciaArmasMenoresMilitarDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_LicenciaArmaMenorMilitarListar", conexion); 
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
                        lista.Add(new LicenciaArmasMenoresMilitarDTO()
                        {
                            LicenciaArmaMenorId = Convert.ToInt32(dr["LicenciaArmaMenorId"]),
                            CodigoDocumentoArmaMenor = dr["CodigoDocumentoArmaMenor"].ToString(),
                            SolDocumentoArmaMenor = dr["SolDocumentoArmaMenor"].ToString(),
                            FechaSolicitudLicArmaMenor = (dr["FechaSolicitudLicArmaMenor"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescTramiteArmaMenor = dr["DescTramiteArmaMenor"].ToString(),
                            DescSituacionPersonalSol = dr["DescSituacionPersonalSol"].ToString(),
                            CondicionAprobLicArmaMenor = dr["CondicionAprobLicArmaMenor"].ToString(),
                            FechaOtorgamientoLicArmaMenor = (dr["FechaOtorgamientoLicArmaMenor"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NroLicenciaArmaMenor = dr["NroLicenciaArmaMenor"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(LicenciaArmasMenoresMilitarDTO licenciaArmaMenorDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_LicenciaArmaMenorMilitarRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoDocumentoArmaMenor", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDocumentoArmaMenor"].Value = licenciaArmaMenorDTO.CodigoDocumentoArmaMenor;

                    cmd.Parameters.Add("@SolDocumentoArmaMenor", SqlDbType.VarChar, 70);
                    cmd.Parameters["@SolDocumentoArmaMenor"].Value = licenciaArmaMenorDTO.SolDocumentoArmaMenor;

                    cmd.Parameters.Add("@FechaSolicitudLicArmaMenor", SqlDbType.Date);
                    cmd.Parameters["@FechaSolicitudLicArmaMenor"].Value = licenciaArmaMenorDTO.FechaSolicitudLicArmaMenor;

                    cmd.Parameters.Add("@CodigoTramiteArmaMenor", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTramiteArmaMenor"].Value = licenciaArmaMenorDTO.CodigoTramiteArmaMenor;

                    cmd.Parameters.Add("@CodigoSituacionPersonalSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSituacionPersonalSolicitante"].Value = licenciaArmaMenorDTO.CodigoSituacionPersonalSolicitante;

                    cmd.Parameters.Add("@CondicionAprobLicArmaMenor", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CondicionAprobLicArmaMenor"].Value = licenciaArmaMenorDTO.CondicionAprobLicArmaMenor;

                    cmd.Parameters.Add("@FechaOtorgamientoLicArmaMenor", SqlDbType.Date);
                    cmd.Parameters["@FechaOtorgamientoLicArmaMenor"].Value = licenciaArmaMenorDTO.FechaOtorgamientoLicArmaMenor;

                    cmd.Parameters.Add("@NroLicenciaArmaMenor", SqlDbType.NChar, 10);
                    cmd.Parameters["@NroLicenciaArmaMenor"].Value = licenciaArmaMenorDTO.NroLicenciaArmaMenor;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = licenciaArmaMenorDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = licenciaArmaMenorDTO.UsuarioIngresoRegistro;

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

        public LicenciaArmasMenoresMilitarDTO BuscarFormato(int Codigo)
        {
            LicenciaArmasMenoresMilitarDTO licenciaArmaMenorDTO = new LicenciaArmasMenoresMilitarDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_LicenciaArmaMenorMilitarEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@LicenciaArmaMenorId", SqlDbType.Int);
                    cmd.Parameters["@LicenciaArmaMenorId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        licenciaArmaMenorDTO.LicenciaArmaMenorId = Convert.ToInt32(dr["LicenciaArmaMenorId"]);
                        licenciaArmaMenorDTO.CodigoDocumentoArmaMenor = dr["CodigoDocumentoArmaMenor"].ToString();
                        licenciaArmaMenorDTO.SolDocumentoArmaMenor = dr["SolDocumentoArmaMenor"].ToString();
                        licenciaArmaMenorDTO.FechaSolicitudLicArmaMenor = Convert.ToDateTime(dr["FechaSolicitudLicArmaMenor"]).ToString("yyy-MM-dd");
                        licenciaArmaMenorDTO.CodigoTramiteArmaMenor = dr["CodigoTramiteArmaMenor"].ToString();
                        licenciaArmaMenorDTO.CodigoSituacionPersonalSolicitante = dr["CodigoSituacionPersonalSolicitante"].ToString();
                        licenciaArmaMenorDTO.CondicionAprobLicArmaMenor = dr["CondicionAprobLicArmaMenor"].ToString();
                        licenciaArmaMenorDTO.FechaOtorgamientoLicArmaMenor = Convert.ToDateTime(dr["FechaOtorgamientoLicArmaMenor"]).ToString("yyy-MM-dd");
                        licenciaArmaMenorDTO.NroLicenciaArmaMenor = dr["NroLicenciaArmaMenor"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return licenciaArmaMenorDTO;
        }

        public string ActualizaFormato(LicenciaArmasMenoresMilitarDTO licenciaArmaMenorDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_LicenciaArmaMenorMilitarActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@LicenciaArmaMenorId", SqlDbType.Int);
                    cmd.Parameters["@LicenciaArmaMenorId"].Value = licenciaArmaMenorDTO.LicenciaArmaMenorId;

                    cmd.Parameters.Add("@CodigoDocumentoArmaMenor", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDocumentoArmaMenor"].Value = licenciaArmaMenorDTO.CodigoDocumentoArmaMenor;

                    cmd.Parameters.Add("@SolDocumentoArmaMenor", SqlDbType.VarChar, 70);
                    cmd.Parameters["@SolDocumentoArmaMenor"].Value = licenciaArmaMenorDTO.SolDocumentoArmaMenor;

                    cmd.Parameters.Add("@FechaSolicitudLicArmaMenor", SqlDbType.Date);
                    cmd.Parameters["@FechaSolicitudLicArmaMenor"].Value = licenciaArmaMenorDTO.FechaSolicitudLicArmaMenor;

                    cmd.Parameters.Add("@CodigoTramiteArmaMenor", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTramiteArmaMenor"].Value = licenciaArmaMenorDTO.CodigoTramiteArmaMenor;

                    cmd.Parameters.Add("@CodigoSituacionPersonalSolicitante", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoSituacionPersonalSolicitante"].Value = licenciaArmaMenorDTO.CodigoSituacionPersonalSolicitante;

                    cmd.Parameters.Add("@CondicionAprobLicArmaMenor", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CondicionAprobLicArmaMenor"].Value = licenciaArmaMenorDTO.CondicionAprobLicArmaMenor;

                    cmd.Parameters.Add("@FechaOtorgamientoLicArmaMenor", SqlDbType.Date);
                    cmd.Parameters["@FechaOtorgamientoLicArmaMenor"].Value = licenciaArmaMenorDTO.FechaOtorgamientoLicArmaMenor;

                    cmd.Parameters.Add("@NroLicenciaArmaMenor", SqlDbType.NChar, 10);
                    cmd.Parameters["@NroLicenciaArmaMenor"].Value = licenciaArmaMenorDTO.NroLicenciaArmaMenor;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = licenciaArmaMenorDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(LicenciaArmasMenoresMilitarDTO licenciaArmaMenorDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_LicenciaArmaMenorMilitarEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@LicenciaArmaMenorId", SqlDbType.Int);
                    cmd.Parameters["@LicenciaArmaMenorId"].Value = licenciaArmaMenorDTO.LicenciaArmaMenorId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = licenciaArmaMenorDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(LicenciaArmasMenoresMilitarDTO licenciaArmaMenorDTO)
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
                    cmd.Parameters["@Formato"].Value = "LicenciaArmaMenorMilitar";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = licenciaArmaMenorDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = licenciaArmaMenorDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_LicenciaArmaMenorMilitarRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@LicenciaArmaMenorMilitar", SqlDbType.Structured);
                    cmd.Parameters["@LicenciaArmaMenorMilitar"].TypeName = "Formato.LicenciaArmaMenorMilitar";
                    cmd.Parameters["@LicenciaArmaMenorMilitar"].Value = datos;

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
