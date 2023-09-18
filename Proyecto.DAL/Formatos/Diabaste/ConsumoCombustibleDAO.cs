using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diabaste;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diabaste
{
    public class ConsumoCombustibleDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ConsumoCombustibleDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ConsumoCombustibleDTO> lista = new List<ConsumoCombustibleDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ConsumoCombustibleListar", conexion);
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
                        lista.Add(new ConsumoCombustibleDTO()
                        {
                            ConsumoCombustibleId = Convert.ToInt32(dr["ConsumoCombustibleId"]),
                            Anio = Convert.ToInt32(dr["Anio"]),
                            DescMes = dr["DescMes"].ToString(),
                            DescClaseCombustible = dr["DescClaseCombustible"].ToString(),
                            DescVehiculoServicioGrupo = dr["DescVehiculoServicioGrupo"].ToString(),
                            DescPuntoDistribucionCombustible = dr["DescPuntoDistribucionCombustible"].ToString(),
                            DescVehiculoServicioTipo = dr["DescVehiculoServicioTipo"].ToString(),
                            DescTipoPresupuesto = dr["DescTipoPresupuesto"].ToString(),
                            DescCombustibleEspecificacion = dr["DescCombustibleEspecificacion"].ToString(),
                            CantidadConsumidaGalon = Convert.ToInt32(dr["CantidadConsumidaGalon"]),
                            ValorCantidadConsumida = Convert.ToInt32(dr["ValorCantidadConsumida"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ConsumoCombustibleDTO consumoCombustibleDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConsumoCombustibleRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Anio", SqlDbType.Int);
                    cmd.Parameters["@Anio"].Value = consumoCombustibleDTO.Anio;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroMes"].Value = consumoCombustibleDTO.NumeroMes;

                    cmd.Parameters.Add("@CodigoClaseCombustible", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClaseCombustible"].Value = consumoCombustibleDTO.CodigoClaseCombustible;

                    cmd.Parameters.Add("@CodigoVehiculoServicioGrupo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoVehiculoServicioGrupo"].Value = consumoCombustibleDTO.CodigoVehiculoServicioGrupo;

                    cmd.Parameters.Add("@CodigoPuntoDistribucionCombustible", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPuntoDistribucionCombustible"].Value = consumoCombustibleDTO.CodigoPuntoDistribucionCombustible;

                    cmd.Parameters.Add("@CodigoVehiculoServicioTipo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoVehiculoServicioTipo"].Value = consumoCombustibleDTO.CodigoVehiculoServicioTipo;

                    cmd.Parameters.Add("@CodigoTipoPresupuesto", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPresupuesto"].Value = consumoCombustibleDTO.CodigoTipoPresupuesto;

                    cmd.Parameters.Add("@CodigoCombustibleEspecificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCombustibleEspecificacion"].Value = consumoCombustibleDTO.CodigoCombustibleEspecificacion;

                    cmd.Parameters.Add("@CantidadConsumidaGalon", SqlDbType.Int);
                    cmd.Parameters["@CantidadConsumidaGalon"].Value = consumoCombustibleDTO.CantidadConsumidaGalon;

                    cmd.Parameters.Add("@ValorCantidadConsumida", SqlDbType.Int);
                    cmd.Parameters["@ValorCantidadConsumida"].Value = consumoCombustibleDTO.ValorCantidadConsumida;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = consumoCombustibleDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consumoCombustibleDTO.UsuarioIngresoRegistro;

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

        public ConsumoCombustibleDTO BuscarFormato(int Codigo)
        {
            ConsumoCombustibleDTO consumoCombustibleDTO = new ConsumoCombustibleDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConsumoCombustibleEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConsumoCombustibleId", SqlDbType.Int);
                    cmd.Parameters["@ConsumoCombustibleId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        consumoCombustibleDTO.ConsumoCombustibleId = Convert.ToInt32(dr["ConsumoCombustibleId"]);
                        consumoCombustibleDTO.Anio = Convert.ToInt32(dr["Anio"]);
                        consumoCombustibleDTO.NumeroMes = dr["NumeroMes"].ToString();
                        consumoCombustibleDTO.CodigoClaseCombustible = dr["CodigoClaseCombustible"].ToString();
                        consumoCombustibleDTO.CodigoVehiculoServicioGrupo = dr["CodigoVehiculoServicioGrupo"].ToString();
                        consumoCombustibleDTO.CodigoPuntoDistribucionCombustible = dr["CodigoPuntoDistribucionCombustible"].ToString();
                        consumoCombustibleDTO.CodigoVehiculoServicioTipo = dr["CodigoVehiculoServicioTipo"].ToString();
                        consumoCombustibleDTO.CodigoTipoPresupuesto = dr["CodigoTipoPresupuesto"].ToString();
                        consumoCombustibleDTO.CodigoCombustibleEspecificacion = dr["CodigoCombustibleEspecificacion"].ToString();
                        consumoCombustibleDTO.CantidadConsumidaGalon = Convert.ToInt32(dr["CantidadConsumidaGalon"]);
                        consumoCombustibleDTO.ValorCantidadConsumida = Convert.ToInt32(dr["ValorCantidadConsumida"]); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return consumoCombustibleDTO;
        }

        public string ActualizaFormato(ConsumoCombustibleDTO consumoCombustibleDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ConsumoCombustibleActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ConsumoCombustibleId", SqlDbType.Int);
                    cmd.Parameters["@ConsumoCombustibleId"].Value = consumoCombustibleDTO.ConsumoCombustibleId;

                    cmd.Parameters.Add("@Anio", SqlDbType.Int);
                    cmd.Parameters["@Anio"].Value = consumoCombustibleDTO.Anio;

                    cmd.Parameters.Add("@CodigoClaseCombustible", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClaseCombustible"].Value = consumoCombustibleDTO.CodigoClaseCombustible;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroMes"].Value = consumoCombustibleDTO.NumeroMes;

                    cmd.Parameters.Add("@CodigoVehiculoServicioGrupo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoVehiculoServicioGrupo"].Value = consumoCombustibleDTO.CodigoVehiculoServicioGrupo;

                    cmd.Parameters.Add("@CodigoPuntoDistribucionCombustible", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPuntoDistribucionCombustible"].Value = consumoCombustibleDTO.CodigoPuntoDistribucionCombustible;

                    cmd.Parameters.Add("@CodigoVehiculoServicioTipo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoVehiculoServicioTipo"].Value = consumoCombustibleDTO.CodigoVehiculoServicioTipo;

                    cmd.Parameters.Add("@CodigoTipoPresupuesto", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPresupuesto"].Value = consumoCombustibleDTO.CodigoTipoPresupuesto;

                    cmd.Parameters.Add("@CodigoCombustibleEspecificacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCombustibleEspecificacion"].Value = consumoCombustibleDTO.CodigoCombustibleEspecificacion;

                    cmd.Parameters.Add("@CantidadConsumidaGalon", SqlDbType.Int);
                    cmd.Parameters["@CantidadConsumidaGalon"].Value = consumoCombustibleDTO.CantidadConsumidaGalon;

                    cmd.Parameters.Add("@ValorCantidadConsumida", SqlDbType.Int);
                    cmd.Parameters["@ValorCantidadConsumida"].Value = consumoCombustibleDTO.ValorCantidadConsumida;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consumoCombustibleDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ConsumoCombustibleDTO consumoCombustibleDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConsumoCombustibleEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConsumoCombustibleId", SqlDbType.Int);
                    cmd.Parameters["@ConsumoCombustibleId"].Value = consumoCombustibleDTO.ConsumoCombustibleId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consumoCombustibleDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ConsumoCombustibleDTO consumoCombustibleDTO)
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
                    cmd.Parameters["@Formato"].Value = "ConsumoCombustible"; 

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = consumoCombustibleDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consumoCombustibleDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ConsumoCombustibleRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConsumoCombustible", SqlDbType.Structured);
                    cmd.Parameters["@ConsumoCombustible"].TypeName = "Formato.ConsumoCombustible";
                    cmd.Parameters["@ConsumoCombustible"].Value = datos;

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
