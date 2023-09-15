using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Bienestar
{
    public class ServicioFunerarioDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ServicioFunerarioDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ServicioFunerarioDTO> lista = new List<ServicioFunerarioDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ServicioFunerarioListar", conexion);
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
                        lista.Add(new ServicioFunerarioDTO()
                        {
                            ServicioFunerarioId = Convert.ToInt32(dr["ServicioFunerarioId"]),
                            FechaServicioFunerario = (dr["FechaServicioFunerario"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DNISolicitante = dr["DNISolicitante"].ToString(),
                            DescPersonalSolicitante = dr["DescPersonalSolicitante"].ToString(),
                            DescCondicionSolicitante = dr["DescCondicionSolicitante"].ToString(),
                            DescPersonalBeneficiado = dr["DescPersonalBeneficiado"].ToString(),
                            DescCategoriaPago = dr["DescCategoriaPago"].ToString(),
                            ServicioTramiteSepelio = dr["ServicioTramiteSepelio"].ToString(),
                            ServicioAlquilerAtaud = dr["ServicioAlquilerAtaud"].ToString(),
                            ServicioVentaAtaud = dr["ServicioVentaAtaud"].ToString(),
                            ServicioCremacion = dr["ServicioCremacion"].ToString(),
                            ServicioSalonVelatorio = dr["ServicioSalonVelatorio"].ToString(),
                            ServicioCapillaArdiente = dr["ServicioCapillaArdiente"].ToString(),
                            ServicioAlquilerCarroza = dr["ServicioAlquilerCarroza"].ToString(),
                            ServicioAlquilerCarroServicio = dr["ServicioAlquilerCarroServicio"].ToString(),
                            ServicioAlquilerCarroFlores = dr["ServicioAlquilerCarroFlores"].ToString(),
                            MontoTotalServicio = Convert.ToDecimal(dr["MontoTotalServicio"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public List<ServicioFunerarioDTO> BienestarVisualizacionServicioFunerario(int CargaId)
        {
            List<ServicioFunerarioDTO> lista = new List<ServicioFunerarioDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_BienestarVisualizacionServicioFunerario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;


                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ServicioFunerarioDTO()
                        {
                            FechaServicioFunerario = dr["FechaSolicitudConvenio"].ToString(),
                            DNISolicitante = dr["DNISolicitante"].ToString(),
                            DescPersonalSolicitante = dr["DescPersonalSolicitante"].ToString(),
                            DescCondicionSolicitante = dr["DescCondicionSolicitante"].ToString(),
                            DescPersonalBeneficiado = dr["DescPersonalBeneficiado"].ToString(),
                            DescCategoriaPago = dr["DescCategoriaPago"].ToString(),
                            ServicioTramiteSepelio = dr["ServicioTramiteSepelio"].ToString(),
                            ServicioAlquilerAtaud = dr["ServicioAlquilerAtaud"].ToString(),
                            ServicioVentaAtaud = dr["ServicioVentaAtaud"].ToString(),
                            ServicioCremacion = dr["ServicioCremacion"].ToString(),
                            ServicioSalonVelatorio = dr["ServicioSalonVelatorio"].ToString(),
                            ServicioCapillaArdiente = dr["ServicioCapillaArdiente"].ToString(),
                            ServicioAlquilerCarroza = dr["ServicioAlquilerCarroza"].ToString(),
                            ServicioAlquilerCarroServicio = dr["ServicioAlquilerCarroServicio"].ToString(),
                            ServicioAlquilerCarroFlores = dr["ServicioAlquilerCarroFlores"].ToString(),
                            MontoTotalServicio = Convert.ToDecimal(dr["MontoTotalServicio"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ServicioFunerarioDTO servicioFunerarioDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioFunerarioRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaServicioFunerario", SqlDbType.Date);
                    cmd.Parameters["@FechaServicioFunerario"].Value = servicioFunerarioDTO.FechaServicioFunerario;

                    cmd.Parameters.Add("@DNISolicitante", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNISolicitante"].Value = servicioFunerarioDTO.DNISolicitante;

                    cmd.Parameters.Add("@CodigoPersonalSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalSolicitante"].Value = servicioFunerarioDTO.CodigoPersonalSolicitante;

                    cmd.Parameters.Add("@CodigoCondicionSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionSolicitante"].Value = servicioFunerarioDTO.CodigoCondicionSolicitante;

                    cmd.Parameters.Add("@CodigoPersonalBeneficiado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalBeneficiado"].Value = servicioFunerarioDTO.CodigoPersonalBeneficiado;

                    cmd.Parameters.Add("@CodigoCategoriaPago", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCategoriaPago"].Value = servicioFunerarioDTO.CodigoCategoriaPago;

                    cmd.Parameters.Add("@ServicioTramiteSepelio", SqlDbType.NChar,1);
                    cmd.Parameters["@ServicioTramiteSepelio"].Value = servicioFunerarioDTO.ServicioTramiteSepelio;

                    cmd.Parameters.Add("@ServicioAlquilerAtaud", SqlDbType.NChar, 1);
                    cmd.Parameters["@ServicioAlquilerAtaud"].Value = servicioFunerarioDTO.ServicioAlquilerAtaud;

                    cmd.Parameters.Add("@ServicioVentaAtaud", SqlDbType.NChar, 1);
                    cmd.Parameters["@ServicioVentaAtaud"].Value = servicioFunerarioDTO.ServicioVentaAtaud;

                    cmd.Parameters.Add("@ServicioCremacion", SqlDbType.NChar, 1);
                    cmd.Parameters["@ServicioCremacion"].Value = servicioFunerarioDTO.ServicioCremacion;

                    cmd.Parameters.Add("@ServicioSalonVelatorio", SqlDbType.NChar, 1);
                    cmd.Parameters["@ServicioSalonVelatorio"].Value = servicioFunerarioDTO.ServicioSalonVelatorio;

                    cmd.Parameters.Add("@ServicioCapillaArdiente", SqlDbType.NChar, 1);
                    cmd.Parameters["@ServicioCapillaArdiente"].Value = servicioFunerarioDTO.ServicioCapillaArdiente;

                    cmd.Parameters.Add("@ServicioAlquilerCarroza", SqlDbType.NChar, 1);
                    cmd.Parameters["@ServicioAlquilerCarroza"].Value = servicioFunerarioDTO.ServicioAlquilerCarroza;

                    cmd.Parameters.Add("@ServicioAlquilerCarroServicio", SqlDbType.NChar, 1);
                    cmd.Parameters["@ServicioAlquilerCarroServicio"].Value = servicioFunerarioDTO.ServicioAlquilerCarroServicio;

                    cmd.Parameters.Add("@ServicioAlquilerCarroFlores", SqlDbType.NChar, 1);
                    cmd.Parameters["@ServicioAlquilerCarroFlores"].Value = servicioFunerarioDTO.ServicioAlquilerCarroFlores;

                    cmd.Parameters.Add("@MontoTotalServicio", SqlDbType.Decimal);
                    cmd.Parameters["@MontoTotalServicio"].Value = servicioFunerarioDTO.MontoTotalServicio;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = servicioFunerarioDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioFunerarioDTO.UsuarioIngresoRegistro;

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

        public ServicioFunerarioDTO BuscarFormato(int Codigo)
        {
            ServicioFunerarioDTO servicioFunerarioDTO = new ServicioFunerarioDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioFunerarioEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioFunerarioId", SqlDbType.Int);
                    cmd.Parameters["@ServicioFunerarioId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        servicioFunerarioDTO.ServicioFunerarioId = Convert.ToInt32(dr["ServicioFunerarioId"]);
                        servicioFunerarioDTO.FechaServicioFunerario = Convert.ToDateTime(dr["FechaServicioFunerario"]).ToString("yyy-MM-dd");
                        servicioFunerarioDTO.DNISolicitante = dr["DNISolicitante"].ToString();
                        servicioFunerarioDTO.CodigoPersonalSolicitante = dr["CodigoPersonalSolicitante"].ToString();
                        servicioFunerarioDTO.CodigoCondicionSolicitante = dr["CodigoCondicionSolicitante"].ToString();
                        servicioFunerarioDTO.CodigoPersonalBeneficiado = dr["CodigoPersonalBeneficiado"].ToString();
                        servicioFunerarioDTO.CodigoCategoriaPago = dr["CodigoCategoriaPago"].ToString();
                        servicioFunerarioDTO.ServicioTramiteSepelio = dr["ServicioTramiteSepelio"].ToString();
                        servicioFunerarioDTO.ServicioAlquilerAtaud = dr["ServicioAlquilerAtaud"].ToString();
                        servicioFunerarioDTO.ServicioVentaAtaud = dr["ServicioVentaAtaud"].ToString();
                        servicioFunerarioDTO.ServicioCremacion = dr["ServicioCremacion"].ToString();
                        servicioFunerarioDTO.ServicioSalonVelatorio = dr["ServicioSalonVelatorio"].ToString();
                        servicioFunerarioDTO.ServicioCapillaArdiente = dr["ServicioCapillaArdiente"].ToString();
                        servicioFunerarioDTO.ServicioAlquilerCarroza = dr["ServicioAlquilerCarroza"].ToString();
                        servicioFunerarioDTO.ServicioAlquilerCarroServicio = dr["ServicioAlquilerCarroServicio"].ToString();
                        servicioFunerarioDTO.ServicioAlquilerCarroFlores = dr["ServicioAlquilerCarroFlores"].ToString();
                        servicioFunerarioDTO.MontoTotalServicio = Convert.ToDecimal(dr["MontoTotalServicio"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return servicioFunerarioDTO;
        }

        public string ActualizaFormato(ServicioFunerarioDTO servicioFunerarioDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ServicioFunerarioActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ServicioFunerarioId", SqlDbType.Int);
                    cmd.Parameters["@ServicioFunerarioId"].Value = servicioFunerarioDTO.ServicioFunerarioId;

                    cmd.Parameters.Add("@FechaServicioFunerario", SqlDbType.Date);
                    cmd.Parameters["@FechaServicioFunerario"].Value = servicioFunerarioDTO.FechaServicioFunerario;

                    cmd.Parameters.Add("@DNISolicitante", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNISolicitante"].Value = servicioFunerarioDTO.DNISolicitante;

                    cmd.Parameters.Add("@CodigoPersonalSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalSolicitante"].Value = servicioFunerarioDTO.CodigoPersonalSolicitante;

                    cmd.Parameters.Add("@CodigoCondicionSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionSolicitante"].Value = servicioFunerarioDTO.CodigoCondicionSolicitante;

                    cmd.Parameters.Add("@CodigoPersonalBeneficiado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalBeneficiado"].Value = servicioFunerarioDTO.CodigoPersonalBeneficiado;

                    cmd.Parameters.Add("@CodigoCategoriaPago", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCategoriaPago"].Value = servicioFunerarioDTO.CodigoCategoriaPago;

                    cmd.Parameters.Add("@ServicioTramiteSepelio", SqlDbType.NChar, 1);
                    cmd.Parameters["@ServicioTramiteSepelio"].Value = servicioFunerarioDTO.ServicioTramiteSepelio;

                    cmd.Parameters.Add("@ServicioAlquilerAtaud", SqlDbType.NChar, 1);
                    cmd.Parameters["@ServicioAlquilerAtaud"].Value = servicioFunerarioDTO.ServicioAlquilerAtaud;

                    cmd.Parameters.Add("@ServicioVentaAtaud", SqlDbType.NChar, 1);
                    cmd.Parameters["@ServicioVentaAtaud"].Value = servicioFunerarioDTO.ServicioVentaAtaud;

                    cmd.Parameters.Add("@ServicioCremacion", SqlDbType.NChar, 1);
                    cmd.Parameters["@ServicioCremacion"].Value = servicioFunerarioDTO.ServicioCremacion;

                    cmd.Parameters.Add("@ServicioSalonVelatorio", SqlDbType.NChar, 1);
                    cmd.Parameters["@ServicioSalonVelatorio"].Value = servicioFunerarioDTO.ServicioSalonVelatorio;

                    cmd.Parameters.Add("@ServicioCapillaArdiente", SqlDbType.NChar, 1);
                    cmd.Parameters["@ServicioCapillaArdiente"].Value = servicioFunerarioDTO.ServicioCapillaArdiente;

                    cmd.Parameters.Add("@ServicioAlquilerCarroza", SqlDbType.NChar, 1);
                    cmd.Parameters["@ServicioAlquilerCarroza"].Value = servicioFunerarioDTO.ServicioAlquilerCarroza;

                    cmd.Parameters.Add("@ServicioAlquilerCarroServicio", SqlDbType.NChar, 1);
                    cmd.Parameters["@ServicioAlquilerCarroServicio"].Value = servicioFunerarioDTO.ServicioAlquilerCarroServicio;

                    cmd.Parameters.Add("@ServicioAlquilerCarroFlores", SqlDbType.NChar, 1);
                    cmd.Parameters["@ServicioAlquilerCarroFlores"].Value = servicioFunerarioDTO.ServicioAlquilerCarroFlores;

                    cmd.Parameters.Add("@MontoTotalServicio", SqlDbType.Decimal);
                    cmd.Parameters["@MontoTotalServicio"].Value = servicioFunerarioDTO.MontoTotalServicio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioFunerarioDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ServicioFunerarioDTO servicioFunerarioDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioFunerarioEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioFunerarioId", SqlDbType.Int);
                    cmd.Parameters["@ServicioFunerarioId"].Value = servicioFunerarioDTO.ServicioFunerarioId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioFunerarioDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ServicioFunerarioDTO servicioFunerarioDTO)

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
                    cmd.Parameters["@Formato"].Value = "ServicioFunerario";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = servicioFunerarioDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioFunerarioDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ServicioFunerarioRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioFunerario", SqlDbType.Structured);
                    cmd.Parameters["@ServicioFunerario"].TypeName = "Formato.ServicioFunerario";
                    cmd.Parameters["@ServicioFunerario"].Value = datos;

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