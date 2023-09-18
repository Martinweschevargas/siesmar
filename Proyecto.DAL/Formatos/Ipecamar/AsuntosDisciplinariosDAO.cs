using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Ipecamar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Ipecamar
{
    public class AsuntosDisciplinariosDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AsuntosDisciplinariosDTO> ObtenerLista(int? CargaId=null)
        {
            List<AsuntosDisciplinariosDTO> lista = new List<AsuntosDisciplinariosDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AsuntosDisciplinariosListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value =CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AsuntosDisciplinariosDTO()
                        {
                            AsuntoDisciplinarioId = Convert.ToInt32(dr["AsuntoDisciplinarioId"]),
                            UUDDConvocante = dr["UUDDConvocante"].ToString(),
                            DescMotivoInvestigacion = dr["DescMotivoInvestigacion"].ToString(),
                            DescDetalleInfraccion = dr["DescDetalleInfraccion"].ToString(),
                            FechaInicioInvestigacion = (dr["FechaInicioInvestigacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTerminoInvestigacion = (dr["FechaTerminoInvestigacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            PlazoInvestigacion = Convert.ToInt32(dr["PlazoInvestigacion"]),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            SituacionInvestigacion = dr["SituacionInvestigacion"].ToString(),
                            DescResultadoInvestigacion = dr["DescResultadoInvestigacion"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AsuntosDisciplinariosDTO asuntosDisciplinariosDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AsuntosDisciplinariosRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UUDDConvocante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@UUDDConvocante"].Value = asuntosDisciplinariosDTO.UUDDConvocante;

                    cmd.Parameters.Add("@CodigoMotivoInvestigacion", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoMotivoInvestigacion"].Value = asuntosDisciplinariosDTO.CodigoMotivoInvestigacion;

                    cmd.Parameters.Add("@CodigoDetalleInfraccion", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDetalleInfraccion"].Value = asuntosDisciplinariosDTO.CodigoDetalleInfraccion;

                    cmd.Parameters.Add("@FechaInicioInvestigacion", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioInvestigacion"].Value = asuntosDisciplinariosDTO.FechaInicioInvestigacion;

                    cmd.Parameters.Add("@FechaTerminoInvestigacion", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoInvestigacion"].Value = asuntosDisciplinariosDTO.FechaTerminoInvestigacion;

                    cmd.Parameters.Add("@PlazoInvestigacion", SqlDbType.Int);
                    cmd.Parameters["@PlazoInvestigacion"].Value = asuntosDisciplinariosDTO.PlazoInvestigacion;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = asuntosDisciplinariosDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = asuntosDisciplinariosDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = asuntosDisciplinariosDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@SituacionInvestigacion", SqlDbType.VarChar,10);
                    cmd.Parameters["@SituacionInvestigacion"].Value = asuntosDisciplinariosDTO.SituacionInvestigacion;

                    cmd.Parameters.Add("@CodigoResultadoInvestigacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoResultadoInvestigacion"].Value = asuntosDisciplinariosDTO.CodigoResultadoInvestigacion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = asuntosDisciplinariosDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = asuntosDisciplinariosDTO.UsuarioIngresoRegistro;

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

        public AsuntosDisciplinariosDTO BuscarFormato(int Codigo)
        {
            AsuntosDisciplinariosDTO asuntosDisciplinariosDTO = new AsuntosDisciplinariosDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AsuntosDisciplinariosEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AsuntoDisciplinarioId", SqlDbType.Int);
                    cmd.Parameters["@AsuntoDisciplinarioId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        asuntosDisciplinariosDTO.AsuntoDisciplinarioId = Convert.ToInt32(dr["AsuntoDisciplinarioId"]);
                        asuntosDisciplinariosDTO.UUDDConvocante = dr["UUDDConvocante"].ToString();
                        asuntosDisciplinariosDTO.CodigoMotivoInvestigacion = dr["CodigoMotivoInvestigacion"].ToString();
                        asuntosDisciplinariosDTO.CodigoDetalleInfraccion = dr["CodigoDetalleInfraccion"].ToString();
                        asuntosDisciplinariosDTO.FechaInicioInvestigacion = Convert.ToDateTime(dr["FechaInicioInvestigacion"]).ToString("yyy-MM-dd");
                        asuntosDisciplinariosDTO.FechaTerminoInvestigacion = Convert.ToDateTime(dr["FechaTerminoInvestigacion"]).ToString("yyy-MM-dd");
                        asuntosDisciplinariosDTO.PlazoInvestigacion = Convert.ToInt32(dr["PlazoInvestigacion"]);
                        asuntosDisciplinariosDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        asuntosDisciplinariosDTO.CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar"].ToString();
                        asuntosDisciplinariosDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        asuntosDisciplinariosDTO.SituacionInvestigacion = dr["SituacionInvestigacion"].ToString();
                        asuntosDisciplinariosDTO.CodigoResultadoInvestigacion = dr["CodigoResultadoInvestigacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return asuntosDisciplinariosDTO;
        }

        public string ActualizaFormato(AsuntosDisciplinariosDTO asuntosDisciplinariosDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AsuntosDisciplinariosActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AsuntoDisciplinarioId", SqlDbType.Int);
                    cmd.Parameters["@AsuntoDisciplinarioId"].Value = asuntosDisciplinariosDTO.AsuntoDisciplinarioId;

                    cmd.Parameters.Add("@UUDDConvocante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@UUDDConvocante"].Value = asuntosDisciplinariosDTO.UUDDConvocante;

                    cmd.Parameters.Add("@CodigoMotivoInvestigacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMotivoInvestigacion"].Value = asuntosDisciplinariosDTO.CodigoMotivoInvestigacion;

                    cmd.Parameters.Add("@CodigoDetalleInfraccion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDetalleInfraccion"].Value = asuntosDisciplinariosDTO.CodigoDetalleInfraccion;

                    cmd.Parameters.Add("@FechaInicioInvestigacion", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioInvestigacion"].Value = asuntosDisciplinariosDTO.FechaInicioInvestigacion;

                    cmd.Parameters.Add("@FechaTerminoInvestigacion", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoInvestigacion"].Value = asuntosDisciplinariosDTO.FechaTerminoInvestigacion;

                    cmd.Parameters.Add("@PlazoInvestigacion", SqlDbType.Int);
                    cmd.Parameters["@PlazoInvestigacion"].Value = asuntosDisciplinariosDTO.PlazoInvestigacion;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = asuntosDisciplinariosDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = asuntosDisciplinariosDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = asuntosDisciplinariosDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@SituacionInvestigacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SituacionInvestigacion"].Value = asuntosDisciplinariosDTO.SituacionInvestigacion;

                    cmd.Parameters.Add("@CodigoResultadoInvestigacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoResultadoInvestigacion"].Value = asuntosDisciplinariosDTO.CodigoResultadoInvestigacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = asuntosDisciplinariosDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AsuntosDisciplinariosDTO asuntosDisciplinariosDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AsuntosDisciplinariosEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AsuntoDisciplinarioId", SqlDbType.Int);
                    cmd.Parameters["@AsuntoDisciplinarioId"].Value = asuntosDisciplinariosDTO.AsuntoDisciplinarioId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = asuntosDisciplinariosDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_AsuntosDisciplinariosRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AsuntosDisciplinarios", SqlDbType.Structured);
                    cmd.Parameters["@AsuntosDisciplinarios"].TypeName = "Formato.AsuntosDisciplinarios";
                    cmd.Parameters["@AsuntosDisciplinarios"].Value = datos;

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
