using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Ipecamar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Ipecamar
{
    public class InvestigacionInstCaracterPrevioDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<InvestigacionInstCaracterPrevioDTO> ObtenerLista(int? CargaId=null)
        {
            List<InvestigacionInstCaracterPrevioDTO> lista = new List<InvestigacionInstCaracterPrevioDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_InvestigacionInstCaracterPrevioListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new InvestigacionInstCaracterPrevioDTO()
                        {
                            InvestigacionInstCaracterPrevioId = Convert.ToInt32(dr["InvestigacionInstCaracterPrevioId"]),
                            DescTipoInvestigacion = dr["DescTipoInvestigacion"].ToString(),
                            DescMedioInvestigacion = dr["DescMedioInvestigacion"].ToString(),
                            DescMotivoInvestigacion = dr["DescMotivoInvestigacion"].ToString(),
                            DescComandanciaDependencia = dr["DescComandanciaDependencia"].ToString(),
                            FechaInicioInvestigacion = (dr["FechaInicioInvestigacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTermino = (dr["FechaTermino"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            SituacionInvestigacion = dr["SituacionInvestigacion"].ToString(),
                            DescResultadoInvestigacion = dr["DescResultadoInvestigacion"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(InvestigacionInstCaracterPrevioDTO investigacionInstCaracterPrevioDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InvestigacionInstCaracterPrevioRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoTipoInvestigacion", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoInvestigacion"].Value = investigacionInstCaracterPrevioDTO.CodigoTipoInvestigacion;

                    cmd.Parameters.Add("@CodigoMedioInvestigacion", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoMedioInvestigacion"].Value = investigacionInstCaracterPrevioDTO.CodigoMedioInvestigacion;

                    cmd.Parameters.Add("@CodigoMotivoInvestigacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMotivoInvestigacion"].Value = investigacionInstCaracterPrevioDTO.CodigoMotivoInvestigacion;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComandanciaDependencia"].Value = investigacionInstCaracterPrevioDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@FechaInicioInvestigacion", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioInvestigacion"].Value = investigacionInstCaracterPrevioDTO.FechaInicioInvestigacion;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = investigacionInstCaracterPrevioDTO.FechaTermino;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = investigacionInstCaracterPrevioDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@SituacionInvestigacion", SqlDbType.VarChar,20);
                    cmd.Parameters["@SituacionInvestigacion"].Value = investigacionInstCaracterPrevioDTO.SituacionInvestigacion;

                    cmd.Parameters.Add("@CodigoResultadoInvestigacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoResultadoInvestigacion"].Value = investigacionInstCaracterPrevioDTO.CodigoResultadoInvestigacion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = investigacionInstCaracterPrevioDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = investigacionInstCaracterPrevioDTO.UsuarioIngresoRegistro;

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

        public InvestigacionInstCaracterPrevioDTO BuscarFormato(int Codigo)
        {
            InvestigacionInstCaracterPrevioDTO investigacionInstCaracterPrevioDTO = new InvestigacionInstCaracterPrevioDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InvestigacionInstCaracterPrevioEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InvestigacionInstCaracterPrevioId", SqlDbType.Int);
                    cmd.Parameters["@InvestigacionInstCaracterPrevioId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        investigacionInstCaracterPrevioDTO.InvestigacionInstCaracterPrevioId = Convert.ToInt32(dr["InvestigacionInstCaracterPrevioId"]);
                        investigacionInstCaracterPrevioDTO.CodigoTipoInvestigacion = dr["CodigoTipoInvestigacion"].ToString();
                        investigacionInstCaracterPrevioDTO.CodigoMedioInvestigacion = dr["CodigoMedioInvestigacion"].ToString();
                        investigacionInstCaracterPrevioDTO.CodigoMotivoInvestigacion = dr["CodigoMotivoInvestigacion"].ToString();
                        investigacionInstCaracterPrevioDTO.CodigoComandanciaDependencia = dr["CodigoComandanciaDependencia"].ToString();
                        investigacionInstCaracterPrevioDTO.FechaInicioInvestigacion = Convert.ToDateTime(dr["FechaInicioInvestigacion"]).ToString("yyy-MM-dd");
                        investigacionInstCaracterPrevioDTO.FechaTermino = Convert.ToDateTime(dr["FechaTermino"]).ToString("yyy-MM-dd");
                        investigacionInstCaracterPrevioDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        investigacionInstCaracterPrevioDTO.SituacionInvestigacion = dr["SituacionInvestigacion"].ToString();
                        investigacionInstCaracterPrevioDTO.CodigoResultadoInvestigacion = dr["CodigoResultadoInvestigacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return investigacionInstCaracterPrevioDTO;
        }

        public string ActualizaFormato(InvestigacionInstCaracterPrevioDTO investigacionInstCaracterPrevioDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_InvestigacionInstCaracterPrevioActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InvestigacionInstCaracterPrevioId", SqlDbType.Int);
                    cmd.Parameters["@InvestigacionInstCaracterPrevioId"].Value = investigacionInstCaracterPrevioDTO.InvestigacionInstCaracterPrevioId;

                    cmd.Parameters.Add("@CodigoTipoInvestigacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoInvestigacion"].Value = investigacionInstCaracterPrevioDTO.CodigoTipoInvestigacion;

                    cmd.Parameters.Add("@CodigoMedioInvestigacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMedioInvestigacion"].Value = investigacionInstCaracterPrevioDTO.CodigoMedioInvestigacion;

                    cmd.Parameters.Add("@CodigoMotivoInvestigacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMotivoInvestigacion"].Value = investigacionInstCaracterPrevioDTO.CodigoMotivoInvestigacion;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComandanciaDependencia"].Value = investigacionInstCaracterPrevioDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@FechaInicioInvestigacion", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioInvestigacion"].Value = investigacionInstCaracterPrevioDTO.FechaInicioInvestigacion;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = investigacionInstCaracterPrevioDTO.FechaTermino;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = investigacionInstCaracterPrevioDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@SituacionInvestigacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@SituacionInvestigacion"].Value = investigacionInstCaracterPrevioDTO.SituacionInvestigacion;

                    cmd.Parameters.Add("@CodigoResultadoInvestigacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoResultadoInvestigacion"].Value = investigacionInstCaracterPrevioDTO.CodigoResultadoInvestigacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = investigacionInstCaracterPrevioDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(InvestigacionInstCaracterPrevioDTO investigacionInstCaracterPrevioDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InvestigacionInstCaracterPrevioEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InvestigacionInstCaracterPrevioId", SqlDbType.Int);
                    cmd.Parameters["@InvestigacionInstCaracterPrevioId"].Value = investigacionInstCaracterPrevioDTO.InvestigacionInstCaracterPrevioId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = investigacionInstCaracterPrevioDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_InvestigacionInstCaracterPrevioRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InvestigacionInstCaracterPrevio", SqlDbType.Structured);
                    cmd.Parameters["@InvestigacionInstCaracterPrevio"].TypeName = "Formato.InvestigacionInstCaracterPrevio";
                    cmd.Parameters["@InvestigacionInstCaracterPrevio"].Value = datos;

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
