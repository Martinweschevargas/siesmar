using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dihidronav
{
    public class ServicioConstruccionInstalacionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ServicioConstruccionInstalacionDTO> ObtenerLista(int? CargaId=null)
        {
            List<ServicioConstruccionInstalacionDTO> lista = new List<ServicioConstruccionInstalacionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ServicioConstruccionInstalacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ServicioConstruccionInstalacionDTO()
                        {
                            ServicioConstruccionInstalacionId = Convert.ToInt32(dr["ServicioConstruccionInstalacionId"]),
                            NumeroOrden = Convert.ToInt32(dr["NumeroOrden"]),
                            DescTrabajoSenializacionNautica = dr["DescTrabajoSenializacionNautica"].ToString(),
                            DescripcionServicio = dr["DescripcionServicio"].ToString(),
                            FechaInicio = (dr["FechaInicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTermino = (dr["FechaTermino"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescZonaNautica = dr["DescZonaNautica"].ToString(),
                            EstadoServicio = dr["EstadoServicio"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ServicioConstruccionInstalacionDTO servicioConstruccionInstalacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioConstruccionInstalacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroOrden", SqlDbType.Int);
                    cmd.Parameters["@NumeroOrden"].Value = servicioConstruccionInstalacionDTO.NumeroOrden;

                    cmd.Parameters.Add("@CodigoTrabajoSenializacionNautica", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTrabajoSenializacionNautica"].Value = servicioConstruccionInstalacionDTO.CodigoTrabajoSenializacionNautica;

                    cmd.Parameters.Add("@DescripcionServicio", SqlDbType.VarChar, 500);
                    cmd.Parameters["@DescripcionServicio"].Value = servicioConstruccionInstalacionDTO.DescripcionServicio;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = servicioConstruccionInstalacionDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = servicioConstruccionInstalacionDTO.FechaTermino;

                    cmd.Parameters.Add("@CodigoZonaNautica", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoZonaNautica"].Value = servicioConstruccionInstalacionDTO.CodigoZonaNautica;

                    cmd.Parameters.Add("@EstadoServicio", SqlDbType.VarChar,20);
                    cmd.Parameters["@EstadoServicio"].Value = servicioConstruccionInstalacionDTO.EstadoServicio;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = servicioConstruccionInstalacionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioConstruccionInstalacionDTO.UsuarioIngresoRegistro;

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

        public ServicioConstruccionInstalacionDTO BuscarFormato(int Codigo)
        {
            ServicioConstruccionInstalacionDTO servicioConstruccionInstalacionDTO = new ServicioConstruccionInstalacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioConstruccionInstalacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioConstruccionInstalacionId", SqlDbType.Int);
                    cmd.Parameters["@ServicioConstruccionInstalacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        servicioConstruccionInstalacionDTO.ServicioConstruccionInstalacionId = Convert.ToInt32(dr["ServicioConstruccionInstalacionId"]);
                        servicioConstruccionInstalacionDTO.NumeroOrden = Convert.ToInt32(dr["NumeroOrden"]);
                        servicioConstruccionInstalacionDTO.CodigoTrabajoSenializacionNautica = dr["CodigoTrabajoSenializacionNautica"].ToString();
                        servicioConstruccionInstalacionDTO.DescripcionServicio = dr["DescripcionServicio"].ToString();
                        servicioConstruccionInstalacionDTO.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]).ToString("yyy-MM-dd");
                        servicioConstruccionInstalacionDTO.FechaTermino = Convert.ToDateTime(dr["FechaTermino"]).ToString("yyy-MM-dd");
                        servicioConstruccionInstalacionDTO.CodigoZonaNautica = dr["CodigoZonaNautica"].ToString();
                        servicioConstruccionInstalacionDTO.EstadoServicio = dr["EstadoServicio"].ToString(); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return servicioConstruccionInstalacionDTO;
        }

        public string ActualizaFormato(ServicioConstruccionInstalacionDTO servicioConstruccionInstalacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ServicioConstruccionInstalacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ServicioConstruccionInstalacionId", SqlDbType.Int);
                    cmd.Parameters["@ServicioConstruccionInstalacionId"].Value = servicioConstruccionInstalacionDTO.ServicioConstruccionInstalacionId;

                    cmd.Parameters.Add("@NumeroOrden", SqlDbType.Int);
                    cmd.Parameters["@NumeroOrden"].Value = servicioConstruccionInstalacionDTO.NumeroOrden;

                    cmd.Parameters.Add("@CodigoTrabajoSenializacionNautica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTrabajoSenializacionNautica"].Value = servicioConstruccionInstalacionDTO.CodigoTrabajoSenializacionNautica;

                    cmd.Parameters.Add("@DescripcionServicio", SqlDbType.VarChar, 500);
                    cmd.Parameters["@DescripcionServicio"].Value = servicioConstruccionInstalacionDTO.DescripcionServicio;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = servicioConstruccionInstalacionDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = servicioConstruccionInstalacionDTO.FechaTermino;

                    cmd.Parameters.Add("@CodigoZonaNautica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNautica"].Value = servicioConstruccionInstalacionDTO.CodigoZonaNautica;

                    cmd.Parameters.Add("@EstadoServicio", SqlDbType.VarChar,20);
                    cmd.Parameters["@EstadoServicio"].Value = servicioConstruccionInstalacionDTO.EstadoServicio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioConstruccionInstalacionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ServicioConstruccionInstalacionDTO servicioConstruccionInstalacionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioConstruccionInstalacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioConstruccionInstalacionId", SqlDbType.Int);
                    cmd.Parameters["@ServicioConstruccionInstalacionId"].Value = servicioConstruccionInstalacionDTO.ServicioConstruccionInstalacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioConstruccionInstalacionDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ServicioConstruccionInstalacionRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioConstruccionInstalacion", SqlDbType.Structured);
                    cmd.Parameters["@ServicioConstruccionInstalacion"].TypeName = "Formato.ServicioConstruccionInstalacion";
                    cmd.Parameters["@ServicioConstruccionInstalacion"].Value = datos;

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
