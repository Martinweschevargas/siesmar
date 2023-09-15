using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diabaste;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diabaste
{
    public class DistribucionVestuarioDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<DistribucionVestuarioDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<DistribucionVestuarioDTO> lista = new List<DistribucionVestuarioDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_DistribucionVestuarioListar", conexion);
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
                        lista.Add(new DistribucionVestuarioDTO()
                        {
                            DistribucionVestuarioId = Convert.ToInt32(dr["DistribucionVestuarioId"]),
                            Anio = Convert.ToInt32(dr["Anio"]),
                            DescMes = dr["DescMes"].ToString(),
                            DescAreaDiperadmon = dr["DescAreaDiperadmon"].ToString(),
                            DescTipoPrenda = dr["DescTipoPrenda"].ToString(),
                            DescUnidadMedida = dr["DescUnidadMedida"].ToString(),
                            CantidadPrendaEntregada = Convert.ToInt32(dr["CantidadPrendaEntregada"]),
                            FechaEntrega = (dr["FechaEntrega"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(DistribucionVestuarioDTO distribucionVestuarioDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DistribucionVestuarioRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Anio", SqlDbType.Int);
                    cmd.Parameters["@Anio"].Value = distribucionVestuarioDTO.Anio;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroMes"].Value = distribucionVestuarioDTO.NumeroMes;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = distribucionVestuarioDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@CodigoTipoPrenda", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPrenda"].Value = distribucionVestuarioDTO.CodigoTipoPrenda;

                    cmd.Parameters.Add("@CodigoUnidadMedida", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadMedida"].Value = distribucionVestuarioDTO.CodigoUnidadMedida;

                    cmd.Parameters.Add("@CantidadPrendaEntregada", SqlDbType.Int);
                    cmd.Parameters["@CantidadPrendaEntregada"].Value = distribucionVestuarioDTO.CantidadPrendaEntregada;

                    cmd.Parameters.Add("@FechaEntrega", SqlDbType.Date);
                    cmd.Parameters["@FechaEntrega"].Value = distribucionVestuarioDTO.FechaEntrega;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = distribucionVestuarioDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = distribucionVestuarioDTO.UsuarioIngresoRegistro;

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

        public DistribucionVestuarioDTO BuscarFormato(int Codigo)
        {
            DistribucionVestuarioDTO distribucionVestuarioDTO = new DistribucionVestuarioDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DistribucionVestuarioEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DistribucionVestuarioId", SqlDbType.Int);
                    cmd.Parameters["@DistribucionVestuarioId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        distribucionVestuarioDTO.DistribucionVestuarioId = Convert.ToInt32(dr["DistribucionVestuarioId"]);
                        distribucionVestuarioDTO.Anio = Convert.ToInt32(dr["Anio"]);
                        distribucionVestuarioDTO.NumeroMes = dr["NumeroMes"].ToString();
                        distribucionVestuarioDTO.CodigoAreaDiperadmon = dr["CodigoAreaDiperadmon"].ToString();
                        distribucionVestuarioDTO.CodigoTipoPrenda = dr["CodigoTipoPrenda"].ToString();
                        distribucionVestuarioDTO.CodigoUnidadMedida = dr["CodigoUnidadMedida"].ToString();
                        distribucionVestuarioDTO.CantidadPrendaEntregada = Convert.ToInt32(dr["CantidadPrendaEntregada"]);
                        distribucionVestuarioDTO.FechaEntrega = Convert.ToDateTime(dr["FechaEntrega"]).ToString("yyy-MM-dd"); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return distribucionVestuarioDTO;
        }

        public string ActualizaFormato(DistribucionVestuarioDTO distribucionVestuarioDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_DistribucionVestuarioActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@DistribucionVestuarioId", SqlDbType.Int);
                    cmd.Parameters["@DistribucionVestuarioId"].Value = distribucionVestuarioDTO.DistribucionVestuarioId;

                    cmd.Parameters.Add("@Anio", SqlDbType.Int);
                    cmd.Parameters["@Anio"].Value = distribucionVestuarioDTO.Anio;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumeroMes"].Value = distribucionVestuarioDTO.NumeroMes;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = distribucionVestuarioDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@CodigoTipoPrenda", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPrenda"].Value = distribucionVestuarioDTO.CodigoTipoPrenda;

                    cmd.Parameters.Add("@CodigoUnidadMedida", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadMedida"].Value = distribucionVestuarioDTO.CodigoUnidadMedida;

                    cmd.Parameters.Add("@CantidadPrendaEntregada", SqlDbType.Int);
                    cmd.Parameters["@CantidadPrendaEntregada"].Value = distribucionVestuarioDTO.CantidadPrendaEntregada;

                    cmd.Parameters.Add("@FechaEntrega", SqlDbType.Date);
                    cmd.Parameters["@FechaEntrega"].Value = distribucionVestuarioDTO.FechaEntrega;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = distribucionVestuarioDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(DistribucionVestuarioDTO distribucionVestuarioDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DistribucionVestuarioEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DistribucionVestuarioId", SqlDbType.Int);
                    cmd.Parameters["@DistribucionVestuarioId"].Value = distribucionVestuarioDTO.DistribucionVestuarioId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = distribucionVestuarioDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(DistribucionVestuarioDTO distribucionVestuarioDTO)
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
                    cmd.Parameters["@Formato"].Value = "DistribucionVestuario";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = distribucionVestuarioDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = distribucionVestuarioDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_DistribucionVestuarioRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DistribucionVestuario", SqlDbType.Structured);
                    cmd.Parameters["@DistribucionVestuario"].TypeName = "Formato.DistribucionVestuario";
                    cmd.Parameters["@DistribucionVestuario"].Value = datos;

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
