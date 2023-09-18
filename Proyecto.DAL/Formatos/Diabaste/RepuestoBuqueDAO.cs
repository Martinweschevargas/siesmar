using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diabaste;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diabaste
{
    public class RepuestoBuqueDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RepuestoBuqueDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<RepuestoBuqueDTO> lista = new List<RepuestoBuqueDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RepuestoBuqueListar", conexion);
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
                        lista.Add(new RepuestoBuqueDTO()
                        {
                            RepuestoBuqueId = Convert.ToInt32(dr["RepuestoBuqueId"]),
                            Anio = Convert.ToInt32(dr["Anio"]),
                            DescMes = dr["DescMes"].ToString(),
                            DescAreaDiperadmon = dr["DescAreaDiperadmon"].ToString(),
                            DescCondicion = dr["DescCondicion"].ToString(),
                            NombreProducto = dr["NombreProducto"].ToString(),
                            CantidadProducto = Convert.ToInt32(dr["CantidadProducto"]),
                            FechaIngreso = (dr["FechaIngreso"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaSalida = (dr["FechaSalida"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            TiempoCustodiaDia = Convert.ToInt32(dr["TiempoCustodiaDia"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RepuestoBuqueDTO repuestoBuqueDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RepuestoBuqueRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Anio", SqlDbType.Int);
                    cmd.Parameters["@Anio"].Value = repuestoBuqueDTO.Anio;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumeroMes"].Value = repuestoBuqueDTO.NumeroMes;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = repuestoBuqueDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@CodigoCondicion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicion"].Value = repuestoBuqueDTO.CodigoCondicion;

                    cmd.Parameters.Add("@NombreProducto", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NombreProducto"].Value = repuestoBuqueDTO.NombreProducto;

                    cmd.Parameters.Add("@CantidadProducto", SqlDbType.Int);
                    cmd.Parameters["@CantidadProducto"].Value = repuestoBuqueDTO.CantidadProducto;

                    cmd.Parameters.Add("@FechaIngreso", SqlDbType.Date);
                    cmd.Parameters["@FechaIngreso"].Value = repuestoBuqueDTO.FechaIngreso;

                    cmd.Parameters.Add("@FechaSalida", SqlDbType.Date);
                    cmd.Parameters["@FechaSalida"].Value = repuestoBuqueDTO.FechaSalida;

                    cmd.Parameters.Add("@TiempoCustodiaDia", SqlDbType.Int);
                    cmd.Parameters["@TiempoCustodiaDia"].Value = repuestoBuqueDTO.TiempoCustodiaDia;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = repuestoBuqueDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = repuestoBuqueDTO.UsuarioIngresoRegistro;

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

        public RepuestoBuqueDTO BuscarFormato(int Codigo)
        {
            RepuestoBuqueDTO repuestoBuqueDTO = new RepuestoBuqueDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RepuestoBuqueEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RepuestoBuqueId", SqlDbType.Int);
                    cmd.Parameters["@RepuestoBuqueId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        repuestoBuqueDTO.RepuestoBuqueId = Convert.ToInt32(dr["RepuestoBuqueId"]);
                        repuestoBuqueDTO.Anio = Convert.ToInt32(dr["Anio"]);
                        repuestoBuqueDTO.NumeroMes = dr["NumeroMes"].ToString();
                        repuestoBuqueDTO.CodigoAreaDiperadmon = dr["CodigoAreaDiperadmon"].ToString();
                        repuestoBuqueDTO.CodigoCondicion = dr["CodigoCondicion"].ToString();
                        repuestoBuqueDTO.NombreProducto = dr["NombreProducto"].ToString();
                        repuestoBuqueDTO.CantidadProducto = Convert.ToInt32(dr["CantidadProducto"]);
                        repuestoBuqueDTO.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]).ToString("yyy-MM-dd");
                        repuestoBuqueDTO.FechaSalida = Convert.ToDateTime(dr["FechaSalida"]).ToString("yyy-MM-dd");
                        repuestoBuqueDTO.TiempoCustodiaDia = Convert.ToInt32(dr["TiempoCustodiaDia"]); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return repuestoBuqueDTO;
        }

        public string ActualizaFormato(RepuestoBuqueDTO repuestoBuqueDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RepuestoBuqueActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RepuestoBuqueId", SqlDbType.Int);
                    cmd.Parameters["@RepuestoBuqueId"].Value = repuestoBuqueDTO.RepuestoBuqueId;

                    cmd.Parameters.Add("@Anio", SqlDbType.Int);
                    cmd.Parameters["@Anio"].Value = repuestoBuqueDTO.Anio;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroMes"].Value = repuestoBuqueDTO.NumeroMes;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = repuestoBuqueDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@CodigoCondicion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicion"].Value = repuestoBuqueDTO.CodigoCondicion;

                    cmd.Parameters.Add("@NombreProducto", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NombreProducto"].Value = repuestoBuqueDTO.NombreProducto;

                    cmd.Parameters.Add("@CantidadProducto", SqlDbType.Int);
                    cmd.Parameters["@CantidadProducto"].Value = repuestoBuqueDTO.CantidadProducto;

                    cmd.Parameters.Add("@FechaIngreso", SqlDbType.Date);
                    cmd.Parameters["@FechaIngreso"].Value = repuestoBuqueDTO.FechaIngreso;

                    cmd.Parameters.Add("@FechaSalida", SqlDbType.Date);
                    cmd.Parameters["@FechaSalida"].Value = repuestoBuqueDTO.FechaSalida;

                    cmd.Parameters.Add("@TiempoCustodiaDia", SqlDbType.Int);
                    cmd.Parameters["@TiempoCustodiaDia"].Value = repuestoBuqueDTO.TiempoCustodiaDia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = repuestoBuqueDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RepuestoBuqueDTO repuestoBuqueDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RepuestoBuqueEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RepuestoBuqueId", SqlDbType.Int);
                    cmd.Parameters["@RepuestoBuqueId"].Value = repuestoBuqueDTO.RepuestoBuqueId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = repuestoBuqueDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(RepuestoBuqueDTO repuestoBuqueDTO)
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
                    cmd.Parameters["@Formato"].Value = "RepuestoBuque";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = repuestoBuqueDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = repuestoBuqueDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RepuestoBuqueRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RepuestoBuque", SqlDbType.Structured);
                    cmd.Parameters["@RepuestoBuque"].TypeName = "Formato.RepuestoBuque";
                    cmd.Parameters["@RepuestoBuque"].Value = datos;

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
