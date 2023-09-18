using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Difoserece;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Marina.Siesmar.AccesoDatos.Formatos.Difoserece
{
    public class AportFondoRetiroCesacionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AportFondoRetiroCesacionDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<AportFondoRetiroCesacionDTO> lista = new List<AportFondoRetiroCesacionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AportacionFondoRetiroCesacionListar", conexion);
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
                        lista.Add(new AportFondoRetiroCesacionDTO()
                        {
                            AportacionFondoRetiroCesacionId = Convert.ToInt32(dr["AportacionFondoRetiroCesacionId"]),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DNIPersonalRetiro = dr["DNIPersonalRetiro"].ToString(),
                            SexoPersonalRetiro = dr["SexoPersonalRetiro"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            DescGradoRemunerativo = dr["DescGradoRemunerativo"].ToString(),
                            DescSituacionPersonalNaval = dr["DescSituacionPersonalNaval"].ToString(),
                            FechaNacimientoPersonalR = (dr["FechaNacimientoPersonalR"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaIngresoPersonalR = (dr["FechaIngresoPersonalR"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaNombramientoPersonalR = (dr["FechaNombramientoPersonalR"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaPaseRetiroPersonalR = (dr["FechaPaseRetiroPersonalR"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaReincorporacionPersonalR = (dr["FechaReincorporacionPersonalR"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaPrimerAportePersonalR = (dr["FechaPrimerAportePersonalR"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaUltimoAportePersonalR = (dr["FechaUltimoAportePersonalR"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NumeroCuotasAportadasPersonalR = Convert.ToInt32(dr["NumeroCuotasAportadasPersonalR"]),
                            AporteMensualUltimoPersonalR = Convert.ToDecimal(dr["AporteMensualUltimoPersonalR"]),
                            TipoLiquidacionPersonalR = dr["TipoLiquidacionPersonalR"].ToString(),
                            DevolucionAportePersonalR = Convert.ToInt32(dr["DevolucionAportePersonalR"]),
                            FechaLiquidacionPersonalR = (dr["FechaLiquidacionPersonalR"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescCausalLiquidacion = dr["DescCausalLiquidacion"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AportFondoRetiroCesacionDTO aportacionesFondoRetiroCesacionDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AportacionFondoRetiroCesacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = aportacionesFondoRetiroCesacionDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@DNIPersonalRetiro", SqlDbType.VarChar,8);
                    cmd.Parameters["@DNIPersonalRetiro"].Value = aportacionesFondoRetiroCesacionDTO.DNIPersonalRetiro;

                    cmd.Parameters.Add("@SexoPersonalRetiro", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoPersonalRetiro"].Value = aportacionesFondoRetiroCesacionDTO.SexoPersonalRetiro;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = aportacionesFondoRetiroCesacionDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoGradoRemunerativo", SqlDbType.VarChar, 20); ;
                    cmd.Parameters["@CodigoGradoRemunerativo"].Value = aportacionesFondoRetiroCesacionDTO.CodigoGradoRemunerativo;

                    cmd.Parameters.Add("@CodigoSituacionPersonalNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSituacionPersonalNaval"].Value = aportacionesFondoRetiroCesacionDTO.CodigoSituacionPersonalNaval;

                    cmd.Parameters.Add("@FechaNacimientoPersonalR", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimientoPersonalR"].Value = aportacionesFondoRetiroCesacionDTO.FechaNacimientoPersonalR;

                    cmd.Parameters.Add("@FechaIngresoPersonalR", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoPersonalR"].Value = aportacionesFondoRetiroCesacionDTO.FechaIngresoPersonalR;

                    cmd.Parameters.Add("@FechaNombramientoPersonalR", SqlDbType.Date);
                    cmd.Parameters["@FechaNombramientoPersonalR"].Value = aportacionesFondoRetiroCesacionDTO.FechaNombramientoPersonalR;

                    cmd.Parameters.Add("@FechaPaseRetiroPersonalR", SqlDbType.Date);
                    cmd.Parameters["@FechaPaseRetiroPersonalR"].Value = aportacionesFondoRetiroCesacionDTO.FechaPaseRetiroPersonalR;

                    cmd.Parameters.Add("@FechaReincorporacionPersonalR", SqlDbType.Date);
                    cmd.Parameters["@FechaReincorporacionPersonalR"].Value = aportacionesFondoRetiroCesacionDTO.FechaReincorporacionPersonalR;

                    cmd.Parameters.Add("@FechaPrimerAportePersonalR", SqlDbType.Date);
                    cmd.Parameters["@FechaPrimerAportePersonalR"].Value = aportacionesFondoRetiroCesacionDTO.FechaPrimerAportePersonalR;

                    cmd.Parameters.Add("@FechaUltimoAportePersonalR", SqlDbType.Date);
                    cmd.Parameters["@FechaUltimoAportePersonalR"].Value = aportacionesFondoRetiroCesacionDTO.FechaUltimoAportePersonalR;

                    cmd.Parameters.Add("@NumeroCuotasAportadasPersonalR", SqlDbType.Int);
                    cmd.Parameters["@NumeroCuotasAportadasPersonalR"].Value = aportacionesFondoRetiroCesacionDTO.NumeroCuotasAportadasPersonalR;

                    cmd.Parameters.Add("@AporteMensualUltimoPersonalR", SqlDbType.Decimal);
                    cmd.Parameters["@AporteMensualUltimoPersonalR"].Value = aportacionesFondoRetiroCesacionDTO.AporteMensualUltimoPersonalR;

                    cmd.Parameters.Add("@TipoLiquidacionPersonalR", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TipoLiquidacionPersonalR"].Value = aportacionesFondoRetiroCesacionDTO.TipoLiquidacionPersonalR;

                    cmd.Parameters.Add("@DevolucionAportePersonalR", SqlDbType.Int);
                    cmd.Parameters["@DevolucionAportePersonalR"].Value = aportacionesFondoRetiroCesacionDTO.DevolucionAportePersonalR;

                    cmd.Parameters.Add("@FechaLiquidacionPersonalR", SqlDbType.Date);
                    cmd.Parameters["@FechaLiquidacionPersonalR"].Value = aportacionesFondoRetiroCesacionDTO.FechaLiquidacionPersonalR;

                    cmd.Parameters.Add("@CodigoCausalLiquidacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCausalLiquidacion"].Value = aportacionesFondoRetiroCesacionDTO.CodigoCausalLiquidacion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = aportacionesFondoRetiroCesacionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = aportacionesFondoRetiroCesacionDTO.UsuarioIngresoRegistro;

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

        public AportFondoRetiroCesacionDTO BuscarFormato(int Codigo)
        {
            AportFondoRetiroCesacionDTO aportacionesFondoRetiroCesacionDTO = new AportFondoRetiroCesacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AportacionFondoRetiroCesacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AportacionFondoRetiroCesacionId", SqlDbType.Int);
                    cmd.Parameters["@AportacionFondoRetiroCesacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        aportacionesFondoRetiroCesacionDTO.AportacionFondoRetiroCesacionId = Convert.ToInt32(dr["AportacionFondoRetiroCesacionId"]);
                        aportacionesFondoRetiroCesacionDTO.CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar"].ToString();
                        aportacionesFondoRetiroCesacionDTO.DNIPersonalRetiro = dr["DNIPersonalRetiro"].ToString();
                        aportacionesFondoRetiroCesacionDTO.SexoPersonalRetiro = Regex.Replace(dr["SexoPersonalRetiro"].ToString(), @"\s", ""); 
                        aportacionesFondoRetiroCesacionDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        aportacionesFondoRetiroCesacionDTO.CodigoGradoRemunerativo = dr["CodigoGradoRemunerativo"].ToString();
                        aportacionesFondoRetiroCesacionDTO.CodigoSituacionPersonalNaval = dr["CodigoSituacionPersonalNaval"].ToString();
                        aportacionesFondoRetiroCesacionDTO.FechaNacimientoPersonalR = Convert.ToDateTime(dr["FechaNacimientoPersonalR"]).ToString("yyy-MM-dd");
                        aportacionesFondoRetiroCesacionDTO.FechaIngresoPersonalR = Convert.ToDateTime(dr["FechaIngresoPersonalR"]).ToString("yyy-MM-dd");
                        aportacionesFondoRetiroCesacionDTO.FechaNombramientoPersonalR = Convert.ToDateTime(dr["FechaNombramientoPersonalR"]).ToString("yyy-MM-dd");
                        aportacionesFondoRetiroCesacionDTO.FechaPaseRetiroPersonalR = Convert.ToDateTime(dr["FechaPaseRetiroPersonalR"]).ToString("yyy-MM-dd");
                        aportacionesFondoRetiroCesacionDTO.FechaReincorporacionPersonalR = Convert.ToDateTime(dr["FechaReincorporacionPersonalR"]).ToString("yyy-MM-dd");
                        aportacionesFondoRetiroCesacionDTO.FechaPrimerAportePersonalR = Convert.ToDateTime(dr["FechaPrimerAportePersonalR"]).ToString("yyy-MM-dd");
                        aportacionesFondoRetiroCesacionDTO.FechaUltimoAportePersonalR = Convert.ToDateTime(dr["FechaUltimoAportePersonalR"]).ToString("yyy-MM-dd");
                        aportacionesFondoRetiroCesacionDTO.NumeroCuotasAportadasPersonalR = Convert.ToInt32(dr["NumeroCuotasAportadasPersonalR"]);
                        aportacionesFondoRetiroCesacionDTO.AporteMensualUltimoPersonalR = Convert.ToDecimal(dr["AporteMensualUltimoPersonalR"]);
                        aportacionesFondoRetiroCesacionDTO.TipoLiquidacionPersonalR = dr["TipoLiquidacionPersonalR"].ToString();
                        aportacionesFondoRetiroCesacionDTO.DevolucionAportePersonalR = Convert.ToInt32(dr["DevolucionAportePersonalR"]);
                        aportacionesFondoRetiroCesacionDTO.FechaLiquidacionPersonalR = Convert.ToDateTime(dr["FechaLiquidacionPersonalR"]).ToString("yyy-MM-dd");
                        aportacionesFondoRetiroCesacionDTO.CodigoCausalLiquidacion = dr["CodigoCausalLiquidacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return aportacionesFondoRetiroCesacionDTO;
        }

        public string ActualizaFormato(AportFondoRetiroCesacionDTO aportacionesFondoRetiroCesacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AportacionFondoRetiroCesacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AportacionFondoRetiroCesacionId", SqlDbType.Int);
                    cmd.Parameters["@AportacionFondoRetiroCesacionId"].Value = aportacionesFondoRetiroCesacionDTO.AportacionFondoRetiroCesacionId;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = aportacionesFondoRetiroCesacionDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@DNIPersonalRetiro", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPersonalRetiro"].Value = aportacionesFondoRetiroCesacionDTO.DNIPersonalRetiro;

                    cmd.Parameters.Add("@SexoPersonalRetiro", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPersonalRetiro"].Value = aportacionesFondoRetiroCesacionDTO.SexoPersonalRetiro;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = aportacionesFondoRetiroCesacionDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoGradoRemunerativo", SqlDbType.VarChar, 20); ;
                    cmd.Parameters["@CodigoGradoRemunerativo"].Value = aportacionesFondoRetiroCesacionDTO.CodigoGradoRemunerativo;

                    cmd.Parameters.Add("@CodigoSituacionPersonalNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSituacionPersonalNaval"].Value = aportacionesFondoRetiroCesacionDTO.CodigoSituacionPersonalNaval;

                    cmd.Parameters.Add("@FechaNacimientoPersonalR", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimientoPersonalR"].Value = aportacionesFondoRetiroCesacionDTO.FechaNacimientoPersonalR;

                    cmd.Parameters.Add("@FechaIngresoPersonalR", SqlDbType.Date);
                    cmd.Parameters["@FechaIngresoPersonalR"].Value = aportacionesFondoRetiroCesacionDTO.FechaIngresoPersonalR;

                    cmd.Parameters.Add("@FechaNombramientoPersonalR", SqlDbType.Date);
                    cmd.Parameters["@FechaNombramientoPersonalR"].Value = aportacionesFondoRetiroCesacionDTO.FechaNombramientoPersonalR;

                    cmd.Parameters.Add("@FechaPaseRetiroPersonalR", SqlDbType.Date);
                    cmd.Parameters["@FechaPaseRetiroPersonalR"].Value = aportacionesFondoRetiroCesacionDTO.FechaPaseRetiroPersonalR;

                    cmd.Parameters.Add("@FechaReincorporacionPersonalR", SqlDbType.Date);
                    cmd.Parameters["@FechaReincorporacionPersonalR"].Value = aportacionesFondoRetiroCesacionDTO.FechaReincorporacionPersonalR;

                    cmd.Parameters.Add("@FechaPrimerAportePersonalR", SqlDbType.Date);
                    cmd.Parameters["@FechaPrimerAportePersonalR"].Value = aportacionesFondoRetiroCesacionDTO.FechaPrimerAportePersonalR;

                    cmd.Parameters.Add("@FechaUltimoAportePersonalR", SqlDbType.Date);
                    cmd.Parameters["@FechaUltimoAportePersonalR"].Value = aportacionesFondoRetiroCesacionDTO.FechaUltimoAportePersonalR;

                    cmd.Parameters.Add("@NumeroCuotasAportadasPersonalR", SqlDbType.Int);
                    cmd.Parameters["@NumeroCuotasAportadasPersonalR"].Value = aportacionesFondoRetiroCesacionDTO.NumeroCuotasAportadasPersonalR;

                    cmd.Parameters.Add("@AporteMensualUltimoPersonalR", SqlDbType.Decimal);
                    cmd.Parameters["@AporteMensualUltimoPersonalR"].Value = aportacionesFondoRetiroCesacionDTO.AporteMensualUltimoPersonalR;

                    cmd.Parameters.Add("@TipoLiquidacionPersonalR", SqlDbType.VarChar, 10);
                    cmd.Parameters["@TipoLiquidacionPersonalR"].Value = aportacionesFondoRetiroCesacionDTO.TipoLiquidacionPersonalR;

                    cmd.Parameters.Add("@DevolucionAportePersonalR", SqlDbType.Int);
                    cmd.Parameters["@DevolucionAportePersonalR"].Value = aportacionesFondoRetiroCesacionDTO.DevolucionAportePersonalR;

                    cmd.Parameters.Add("@FechaLiquidacionPersonalR", SqlDbType.Date);
                    cmd.Parameters["@FechaLiquidacionPersonalR"].Value = aportacionesFondoRetiroCesacionDTO.FechaLiquidacionPersonalR;

                    cmd.Parameters.Add("@CodigoCausalLiquidacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCausalLiquidacion"].Value = aportacionesFondoRetiroCesacionDTO.CodigoCausalLiquidacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = aportacionesFondoRetiroCesacionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AportFondoRetiroCesacionDTO aportacionesFondoRetiroCesacionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AportacionFondoRetiroCesacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AportacionFondoRetiroCesacionId", SqlDbType.Int);
                    cmd.Parameters["@AportacionFondoRetiroCesacionId"].Value= aportacionesFondoRetiroCesacionDTO.AportacionFondoRetiroCesacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = aportacionesFondoRetiroCesacionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(AportFondoRetiroCesacionDTO aportacionesFondoRetiroCesacionDTO)
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
                    cmd.Parameters["@Formato"].Value = "AportacionFondoRetiroCesacion";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = aportacionesFondoRetiroCesacionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = aportacionesFondoRetiroCesacionDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_AportacionFondoRetiroCesacionRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AportacionFondoRetiroCesacion", SqlDbType.Structured);
                    cmd.Parameters["@AportacionFondoRetiroCesacion"].TypeName = "Formato.AportacionFondoRetiroCesacion";
                    cmd.Parameters["@AportacionFondoRetiroCesacion"].Value = datos;

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
