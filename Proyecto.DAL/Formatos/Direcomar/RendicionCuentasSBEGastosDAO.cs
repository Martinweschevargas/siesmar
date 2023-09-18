using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Direcomar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Direcomar
{
    public class RendicionCuentasSBEGastosDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RendicionCuentasSBEGastosDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<RendicionCuentasSBEGastosDTO> lista = new List<RendicionCuentasSBEGastosDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RendicionCuentaSUEGastoListar", conexion);
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
                        lista.Add(new RendicionCuentasSBEGastosDTO()
                        {
                            RendicionCuentaSBEGastoId = Convert.ToInt32(dr["RendicionCuentaSUEGastoId"]),
                            AnioRendicionCuenta = Convert.ToInt32(dr["AnioRendicionCuenta"]),
                            DescMes = dr["DescMes"].ToString(),
                            DescSubUnidadEjecutora = dr["DescSubUnidadEjecutora"].ToString(),
                            DescClasificacionGenericaGasto = dr["DescClasificacionGenericaGasto"].ToString(),
                            Entregado = Convert.ToDecimal(dr["Entregado"]),
                            Rendido = Convert.ToDecimal(dr["Rendido"]),
                            Saldo = Convert.ToDecimal(dr["Saldo"]),
                            EncargadoInterno = Convert.ToDecimal(dr["EncargadoInterno"]),
                            GastoEncargo = Convert.ToDecimal(dr["GastoEncargo"]),
                            EncargoOtorgado = Convert.ToDecimal(dr["EncargoOtorgado"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public List<RendicionCuentasSBEGastosDTO> DirecomarVisualizacionRendicionCuentasSBEGastos(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<RendicionCuentasSBEGastosDTO> lista = new List<RendicionCuentasSBEGastosDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.DirecomarVisualizacionPlanAnualAdquisicionContratacionesSUE", conexion);
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
                        lista.Add(new RendicionCuentasSBEGastosDTO()
                        {
                            AnioRendicionCuenta = Convert.ToInt32(dr["AnioRendicionCuenta"]),
                            DescMes = dr["DescMes"].ToString(),
                            DescSubUnidadEjecutora = dr["DescSubUnidadEjecutora"].ToString(),
                            ClasificacionGenericaGasto = dr["ClasificacionGenericaGasto"].ToString(),
                            Entregado = Convert.ToDecimal(dr["Entregado"]),
                            Rendido = Convert.ToDecimal(dr["Rendido"]),
                            Saldo = Convert.ToDecimal(dr["Saldo"]),
                            EncargadoInterno = Convert.ToDecimal(dr["EncargadoInterno"]),
                            GastoEncargo = Convert.ToDecimal(dr["GastoEncargo"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RendicionCuentasSBEGastosDTO rendicionCuentasSBEGastosDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RendicionCuentaSUEGastoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AnioRendicionCuenta", SqlDbType.Int);
                    cmd.Parameters["@AnioRendicionCuenta"].Value = rendicionCuentasSBEGastosDTO.AnioRendicionCuenta;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.Int);
                    cmd.Parameters["@NumeroMes"].Value = rendicionCuentasSBEGastosDTO.NumeroMes;

                    cmd.Parameters.Add("@CodigoSubunidadEjecutora", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubunidadEjecutora"].Value = rendicionCuentasSBEGastosDTO.CodigoSubunidadEjecutora;

                    cmd.Parameters.Add("@CodigoClasificacionGenericaGasto", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClasificacionGenericaGasto"].Value = rendicionCuentasSBEGastosDTO.ClasificacionGenericaGasto;

                    cmd.Parameters.Add("@Entregado", SqlDbType.Decimal);
                    cmd.Parameters["@Entregado"].Value = rendicionCuentasSBEGastosDTO.Entregado;

                    cmd.Parameters.Add("@Rendido", SqlDbType.Decimal);
                    cmd.Parameters["@Rendido"].Value = rendicionCuentasSBEGastosDTO.Rendido;

                    cmd.Parameters.Add("@Saldo", SqlDbType.Decimal);
                    cmd.Parameters["@Saldo"].Value = rendicionCuentasSBEGastosDTO.Saldo;

                    cmd.Parameters.Add("@EncargadoInterno", SqlDbType.Decimal);
                    cmd.Parameters["@EncargadoInterno"].Value = rendicionCuentasSBEGastosDTO.EncargadoInterno;

                    cmd.Parameters.Add("@GastoEncargo", SqlDbType.Decimal);
                    cmd.Parameters["@GastoEncargo"].Value = rendicionCuentasSBEGastosDTO.GastoEncargo;  
                    
                    cmd.Parameters.Add("@EncargoOtorgado", SqlDbType.Decimal);
                    cmd.Parameters["@EncargoOtorgado"].Value = rendicionCuentasSBEGastosDTO.EncargoOtorgado;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = rendicionCuentasSBEGastosDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = rendicionCuentasSBEGastosDTO.UsuarioIngresoRegistro;

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

        public RendicionCuentasSBEGastosDTO BuscarFormato(int Codigo)
        {
            RendicionCuentasSBEGastosDTO rendicionCuentasSBEGastosDTO = new RendicionCuentasSBEGastosDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RendicionCuentaSUEGastoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RendicionCuentaSUEGastoId", SqlDbType.Int);
                    cmd.Parameters["@RendicionCuentaSUEGastoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        rendicionCuentasSBEGastosDTO.RendicionCuentaSBEGastoId = Convert.ToInt32(dr["RendicionCuentaSUEGastoId"]);
                        rendicionCuentasSBEGastosDTO.AnioRendicionCuenta = Convert.ToInt32(dr["AnioRendicionCuenta"]);
                        rendicionCuentasSBEGastosDTO.NumeroMes = Convert.ToInt32(dr["NumeroMes"]);
                        rendicionCuentasSBEGastosDTO.CodigoSubunidadEjecutora = dr["CodigoSubunidadEjecutora"].ToString();
                        rendicionCuentasSBEGastosDTO.ClasificacionGenericaGasto = dr["CodigoClasificacionGenericaGasto"].ToString();
                        rendicionCuentasSBEGastosDTO.Entregado = Convert.ToDecimal(dr["Entregado"]);
                        rendicionCuentasSBEGastosDTO.Rendido = Convert.ToDecimal(dr["Rendido"]);
                        rendicionCuentasSBEGastosDTO.Saldo = Convert.ToDecimal(dr["Saldo"]);
                        rendicionCuentasSBEGastosDTO.EncargadoInterno = Convert.ToDecimal(dr["EncargadoInterno"]);
                        rendicionCuentasSBEGastosDTO.GastoEncargo = Convert.ToDecimal(dr["GastoEncargo"]); 
                        rendicionCuentasSBEGastosDTO.EncargoOtorgado = Convert.ToDecimal(dr["EncargoOtorgado"]); 
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rendicionCuentasSBEGastosDTO;
        }

        public string ActualizaFormato(RendicionCuentasSBEGastosDTO rendicionCuentasSBEGastosDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RendicionCuentaSUEGastoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RendicionCuentaSUEGastoId", SqlDbType.Int);
                    cmd.Parameters["@RendicionCuentaSUEGastoId"].Value = rendicionCuentasSBEGastosDTO.RendicionCuentaSBEGastoId;

                    cmd.Parameters.Add("@AnioRendicionCuenta", SqlDbType.Int);
                    cmd.Parameters["@AnioRendicionCuenta"].Value = rendicionCuentasSBEGastosDTO.AnioRendicionCuenta;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.Int);
                    cmd.Parameters["@NumeroMes"].Value = rendicionCuentasSBEGastosDTO.NumeroMes;

                    cmd.Parameters.Add("@CodigoSubunidadEjecutora", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubunidadEjecutora"].Value = rendicionCuentasSBEGastosDTO.CodigoSubunidadEjecutora;

                    cmd.Parameters.Add("@CodigoClasificacionGenericaGasto", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClasificacionGenericaGasto"].Value = rendicionCuentasSBEGastosDTO.ClasificacionGenericaGasto;

                    cmd.Parameters.Add("@Entregado", SqlDbType.Decimal);
                    cmd.Parameters["@Entregado"].Value = rendicionCuentasSBEGastosDTO.Entregado;

                    cmd.Parameters.Add("@Rendido", SqlDbType.Decimal);
                    cmd.Parameters["@Rendido"].Value = rendicionCuentasSBEGastosDTO.Rendido;

                    cmd.Parameters.Add("@Saldo", SqlDbType.Decimal);
                    cmd.Parameters["@Saldo"].Value = rendicionCuentasSBEGastosDTO.Saldo;

                    cmd.Parameters.Add("@EncargadoInterno", SqlDbType.Decimal);
                    cmd.Parameters["@EncargadoInterno"].Value = rendicionCuentasSBEGastosDTO.EncargadoInterno;

                    cmd.Parameters.Add("@GastoEncargo", SqlDbType.Decimal);
                    cmd.Parameters["@GastoEncargo"].Value = rendicionCuentasSBEGastosDTO.GastoEncargo;

                    cmd.Parameters.Add("@EncargoOtorgado", SqlDbType.Decimal);
                    cmd.Parameters["@EncargoOtorgado"].Value = rendicionCuentasSBEGastosDTO.EncargoOtorgado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = rendicionCuentasSBEGastosDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RendicionCuentasSBEGastosDTO rendicionCuentasSBEGastosDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RendicionCuentaSUEGastoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RendicionCuentaSUEGastoId", SqlDbType.Int);
                    cmd.Parameters["@RendicionCuentaSUEGastoId"].Value = rendicionCuentasSBEGastosDTO.RendicionCuentaSBEGastoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = rendicionCuentasSBEGastosDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(RendicionCuentasSBEGastosDTO rendicionCuentasSBEGastosDTO)
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
                    cmd.Parameters["@Formato"].Value = "RendicionCuentaSUEGasto";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = rendicionCuentasSBEGastosDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = rendicionCuentasSBEGastosDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RendicionCuentaSUEGastoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RendicionCuentaSUEGasto", SqlDbType.Structured);
                    cmd.Parameters["@RendicionCuentaSUEGasto"].TypeName = "Formato.RendicionCuentaSUEGasto";
                    cmd.Parameters["@RendicionCuentaSUEGasto"].Value = datos;

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
