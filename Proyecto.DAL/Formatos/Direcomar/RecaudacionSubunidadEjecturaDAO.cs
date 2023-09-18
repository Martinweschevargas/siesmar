using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Direcomar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Direcomar
{
    public class RecaudacionSubunidadEjecturaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RecaudacionSubunidadEjecturaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<RecaudacionSubunidadEjecturaDTO> lista = new List<RecaudacionSubunidadEjecturaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RecaudacionSubunidadEjecturaListar", conexion);
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
                        lista.Add(new RecaudacionSubunidadEjecturaDTO()
                        {
                            RecaudacionSubunidadEjecturaId = Convert.ToInt32(dr["RecaudacionSubunidadEjecturaId"]),
                            AnioRecaudacionSUE = Convert.ToInt32(dr["AnioRecaudacionSUE"]),
                            DescMes = dr["DescMes"].ToString(),
                            DescSubUnidadEjecutora = dr["DescSubUnidadEjecutora"].ToString(),
                            ProyeccionRecaudacionSUE = Convert.ToDecimal(dr["ProyeccionRecaudacionSUE"]),
                            RecaudadoRecaudacionSUE = Convert.ToDecimal(dr["RecaudadoRecaudacionSUE"]),
                            MetaRecaudacionSUE = Convert.ToInt32(dr["MetaRecaudacionSUE"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public List<RecaudacionSubunidadEjecturaDTO> DirecomarVisualizacionRecaudacionSubunidadEjectura(int? CargaId = null, string? fechaInicio=null, string? fechaFin = null)
        {
            List<RecaudacionSubunidadEjecturaDTO> lista = new List<RecaudacionSubunidadEjecturaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.DirecomarVisualizacionRecaudacionSubunidadEjectura", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                cmd.Parameters["@FechaInicio"].Value = fechaInicio;

                cmd.Parameters.Add("@FechaFin", SqlDbType.Date);
                cmd.Parameters["@FechaFin"].Value = fechaFin;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RecaudacionSubunidadEjecturaDTO()
                        {
                            RecaudacionSubunidadEjecturaId = Convert.ToInt32(dr["RecaudacionSubunidadEjecturaId"]),
                            AnioRecaudacionSUE = Convert.ToInt32(dr["AnioRecaudacionSUE"]),
                            DescMes = dr["DescMes"].ToString(),
                            DescSubUnidadEjecutora = dr["DescSubUnidadEjecutora"].ToString(),
                            ProyeccionRecaudacionSUE = Convert.ToDecimal(dr["ProyeccionRecaudacionSUE"]),
                            RecaudadoRecaudacionSUE = Convert.ToDecimal(dr["RecaudadoRecaudacionSUE"]),
                            MetaRecaudacionSUE = Convert.ToInt32(dr["MetaRecaudacionSUE"]),
                        });
                    }
                }
            }
            return lista;
        }


        public string AgregarRegistro(RecaudacionSubunidadEjecturaDTO recaudacionSubunidadEjecturaDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RecaudacionSubunidadEjecturaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AnioRecaudacionSUE", SqlDbType.Int);
                    cmd.Parameters["@AnioRecaudacionSUE"].Value = recaudacionSubunidadEjecturaDTO.AnioRecaudacionSUE;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumeroMes"].Value = recaudacionSubunidadEjecturaDTO.NumeroMes;

                    cmd.Parameters.Add("@CodigoSubunidadEjecutora", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoSubunidadEjecutora"].Value = recaudacionSubunidadEjecturaDTO.CodigoSubunidadEjecutora;

                    cmd.Parameters.Add("@ProyeccionRecaudacionSUE", SqlDbType.Decimal);
                    cmd.Parameters["@ProyeccionRecaudacionSUE"].Value = recaudacionSubunidadEjecturaDTO.ProyeccionRecaudacionSUE;

                    cmd.Parameters.Add("@RecaudadoRecaudacionSUE", SqlDbType.Decimal);
                    cmd.Parameters["@RecaudadoRecaudacionSUE"].Value = recaudacionSubunidadEjecturaDTO.RecaudadoRecaudacionSUE;

                    cmd.Parameters.Add("@MetaRecaudacionSUE", SqlDbType.Int);
                    cmd.Parameters["@MetaRecaudacionSUE"].Value = recaudacionSubunidadEjecturaDTO.MetaRecaudacionSUE;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = recaudacionSubunidadEjecturaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = recaudacionSubunidadEjecturaDTO.UsuarioIngresoRegistro;

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

        public RecaudacionSubunidadEjecturaDTO BuscarFormato(int Codigo)
        {
            RecaudacionSubunidadEjecturaDTO recaudacionSubunidadEjecturaDTO = new RecaudacionSubunidadEjecturaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RecaudacionSubunidadEjecturaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RecaudacionSubunidadEjecturaId", SqlDbType.Int);
                    cmd.Parameters["@RecaudacionSubunidadEjecturaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        recaudacionSubunidadEjecturaDTO.RecaudacionSubunidadEjecturaId = Convert.ToInt32(dr["RecaudacionSubunidadEjecturaId"]);
                        recaudacionSubunidadEjecturaDTO.AnioRecaudacionSUE = Convert.ToInt32(dr["AnioRecaudacionSUE"]);
                        recaudacionSubunidadEjecturaDTO.NumeroMes = dr["NumeroMes"].ToString();
                        recaudacionSubunidadEjecturaDTO.CodigoSubunidadEjecutora = dr["CodigoSubunidadEjecutora"].ToString();
                        recaudacionSubunidadEjecturaDTO.ProyeccionRecaudacionSUE = Convert.ToDecimal(dr["ProyeccionRecaudacionSUE"]);
                        recaudacionSubunidadEjecturaDTO.RecaudadoRecaudacionSUE = Convert.ToDecimal(dr["RecaudadoRecaudacionSUE"]);
                        recaudacionSubunidadEjecturaDTO.MetaRecaudacionSUE = Convert.ToInt32(dr["MetaRecaudacionSUE"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return recaudacionSubunidadEjecturaDTO;
        }

        public string ActualizaFormato(RecaudacionSubunidadEjecturaDTO recaudacionSubunidadEjecturaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RecaudacionSubunidadEjecturaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RecaudacionSubunidadEjecturaId", SqlDbType.Int);
                    cmd.Parameters["@RecaudacionSubunidadEjecturaId"].Value = recaudacionSubunidadEjecturaDTO.RecaudacionSubunidadEjecturaId;

                    cmd.Parameters.Add("@AnioRecaudacionSUE", SqlDbType.Int);
                    cmd.Parameters["@AnioRecaudacionSUE"].Value = recaudacionSubunidadEjecturaDTO.AnioRecaudacionSUE;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumeroMes"].Value = recaudacionSubunidadEjecturaDTO.NumeroMes;

                    cmd.Parameters.Add("@CodigoSubunidadEjecutora", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoSubunidadEjecutora"].Value = recaudacionSubunidadEjecturaDTO.CodigoSubunidadEjecutora;

                    cmd.Parameters.Add("@ProyeccionRecaudacionSUE", SqlDbType.Decimal);
                    cmd.Parameters["@ProyeccionRecaudacionSUE"].Value = recaudacionSubunidadEjecturaDTO.ProyeccionRecaudacionSUE;

                    cmd.Parameters.Add("@RecaudadoRecaudacionSUE", SqlDbType.Decimal);
                    cmd.Parameters["@RecaudadoRecaudacionSUE"].Value = recaudacionSubunidadEjecturaDTO.RecaudadoRecaudacionSUE;

                    cmd.Parameters.Add("@MetaRecaudacionSUE", SqlDbType.Int);
                    cmd.Parameters["@MetaRecaudacionSUE"].Value = recaudacionSubunidadEjecturaDTO.MetaRecaudacionSUE;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = recaudacionSubunidadEjecturaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RecaudacionSubunidadEjecturaDTO recaudacionSubunidadEjecturaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RecaudacionSubunidadEjecturaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RecaudacionSubunidadEjecturaId", SqlDbType.Int);
                    cmd.Parameters["@RecaudacionSubunidadEjecturaId"].Value = recaudacionSubunidadEjecturaDTO.RecaudacionSubunidadEjecturaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = recaudacionSubunidadEjecturaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(RecaudacionSubunidadEjecturaDTO recaudacionSubunidadEjecturaDTO)
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
                    cmd.Parameters["@Formato"].Value = "RecaudacionSubunidadEjectura";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = recaudacionSubunidadEjecturaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = recaudacionSubunidadEjecturaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RecaudacionSubunidadEjecturaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RecaudacionSubunidadEjectura", SqlDbType.Structured);
                    cmd.Parameters["@RecaudacionSubunidadEjectura"].TypeName = "Formato.RecaudacionSubunidadEjectura";
                    cmd.Parameters["@RecaudacionSubunidadEjectura"].Value = datos;

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
