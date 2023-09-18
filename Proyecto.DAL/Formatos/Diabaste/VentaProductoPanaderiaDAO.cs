using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diabaste;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;


namespace Marina.Siesmar.AccesoDatos.Formatos.Diabaste
{
    public class VentaProductoPanaderiaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<VentaProductoPanaderiaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<VentaProductoPanaderiaDTO> lista = new List<VentaProductoPanaderiaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_VentaProductoPanaderiaListar", conexion);
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
                        lista.Add(new VentaProductoPanaderiaDTO()
                        {
                            VentaProductoPanaderiaId = Convert.ToInt32(dr["VentaProductoPanaderiaId"]),
                            FechaVenta = (dr["FechaVenta"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescPuntoDistribucionPanificacion = dr["DescPuntoDistribucionPanificacion"].ToString(),
                            DescProductoPanificacion = dr["DescProductoPanificacion"].ToString(),
                            CantidadProducidaConsumida = Convert.ToInt32(dr["CantidadProducidaConsumida"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(VentaProductoPanaderiaDTO VentaProductoPanaderiaDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_VentaProductoPanaderiaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaVenta", SqlDbType.Date);
                    cmd.Parameters["@FechaVenta"].Value = VentaProductoPanaderiaDTO.FechaVenta;

                    cmd.Parameters.Add("@CodigoPuntoDistribucionPanificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPuntoDistribucionPanificacion"].Value = VentaProductoPanaderiaDTO.CodigoPuntoDistribucionPanificacion;

                    cmd.Parameters.Add("@CodigoProductoPanificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProductoPanificacion"].Value = VentaProductoPanaderiaDTO.CodigoProductoPanificacion;

                    cmd.Parameters.Add("@CantidadProducidaConsumida", SqlDbType.Int);
                    cmd.Parameters["@CantidadProducidaConsumida"].Value = VentaProductoPanaderiaDTO.CantidadProducidaConsumida;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = VentaProductoPanaderiaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = VentaProductoPanaderiaDTO.UsuarioIngresoRegistro;

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

        public VentaProductoPanaderiaDTO BuscarFormato(int Codigo)
        {
            VentaProductoPanaderiaDTO VentaProductoPanaderiaDTO = new VentaProductoPanaderiaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_VentaProductoPanaderiaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VentaProductoPanaderiaId", SqlDbType.Int);
                    cmd.Parameters["@VentaProductoPanaderiaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        VentaProductoPanaderiaDTO.VentaProductoPanaderiaId = Convert.ToInt32(dr["VentaProductoPanaderiaId"]);
                        VentaProductoPanaderiaDTO.FechaVenta = Convert.ToDateTime(dr["FechaVenta"]).ToString("yyy-MM-dd");
                        VentaProductoPanaderiaDTO.CodigoPuntoDistribucionPanificacion = dr["CodigoPuntoDistribucionPanificacion"].ToString();
                        VentaProductoPanaderiaDTO.CodigoProductoPanificacion = dr["CodigoProductoPanificacion"].ToString();
                        VentaProductoPanaderiaDTO.CantidadProducidaConsumida = Convert.ToInt32(dr["CantidadProducidaConsumida"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return VentaProductoPanaderiaDTO;
        }

        public string ActualizaFormato(VentaProductoPanaderiaDTO VentaProductoPanaderiaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_VentaProductoPanaderiaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@VentaProductoPanaderiaId", SqlDbType.Int);
                    cmd.Parameters["@VentaProductoPanaderiaId"].Value = VentaProductoPanaderiaDTO.VentaProductoPanaderiaId;

                    cmd.Parameters.Add("@FechaVenta", SqlDbType.Date);
                    cmd.Parameters["@FechaVenta"].Value = VentaProductoPanaderiaDTO.FechaVenta;

                    cmd.Parameters.Add("@CodigoPuntoDistribucionPanificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPuntoDistribucionPanificacion"].Value = VentaProductoPanaderiaDTO.CodigoPuntoDistribucionPanificacion;

                    cmd.Parameters.Add("@CodigoProductoPanificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProductoPanificacion"].Value = VentaProductoPanaderiaDTO.CodigoProductoPanificacion;

                    cmd.Parameters.Add("@CantidadProducidaConsumida", SqlDbType.Int);
                    cmd.Parameters["@CantidadProducidaConsumida"].Value = VentaProductoPanaderiaDTO.CantidadProducidaConsumida;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = VentaProductoPanaderiaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(VentaProductoPanaderiaDTO VentaProductoPanaderiaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_VentaProductoPanaderiaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VentaProductoPanaderiaId", SqlDbType.Int);
                    cmd.Parameters["@VentaProductoPanaderiaId"].Value = VentaProductoPanaderiaDTO.VentaProductoPanaderiaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = VentaProductoPanaderiaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(VentaProductoPanaderiaDTO VentaProductoPanaderiaDTO)
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
                    cmd.Parameters["@Formato"].Value = "VentaProductoPanaderia";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = VentaProductoPanaderiaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = VentaProductoPanaderiaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_VentaProductoPanaderiaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VentaProductoPanaderia", SqlDbType.Structured);
                    cmd.Parameters["@VentaProductoPanaderia"].TypeName = "Formato.VentaProductoPanaderia";
                    cmd.Parameters["@VentaProductoPanaderia"].Value = datos;

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
