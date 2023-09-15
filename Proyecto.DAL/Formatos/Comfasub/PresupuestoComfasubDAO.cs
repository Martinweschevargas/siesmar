using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfasub
{
    public class PresupuestoComfasubDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PresupuestoComfasubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<PresupuestoComfasubDTO> lista = new List<PresupuestoComfasubDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PresupuestoComfasubListar", conexion);
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
                        lista.Add(new PresupuestoComfasubDTO()
                        {
                            PresupuestoComfasubId = Convert.ToInt32(dr["PresupuestoComfasubId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescSistemaPropulsion = dr["DescSistemaPropulsion"].ToString(),
                            DescSubSistemaPropulsion = dr["DescSubSistemaPropulsion"].ToString(),
                            PresupuestoAsignado = Convert.ToDecimal(dr["PresupuestoAsignado"]),
                            DescFuenteFinanciamiento = dr["DescFuenteFinanciamiento"].ToString(),
                            DescSubUnidadEjecutora = dr["DescSubUnidadEjecutora"].ToString(),
                            DescCentroGasto = dr["DescCentroGasto"].ToString(),
                            DescPartida = dr["DescPartida"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(PresupuestoComfasubDTO presupuestoComfasubDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PresupuestoComfasubRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = presupuestoComfasubDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoSistemaPropulsion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaPropulsion"].Value = presupuestoComfasubDTO.CodigoSistemaPropulsion;

                    cmd.Parameters.Add("@CodigoSubSistemaPropulsion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubSistemaPropulsion"].Value = presupuestoComfasubDTO.CodigoSubSistemaPropulsion;

                    cmd.Parameters.Add("@PresupuestoAsignado", SqlDbType.Decimal);
                    cmd.Parameters["@PresupuestoAsignado"].Value = presupuestoComfasubDTO.PresupuestoAsignado;

                    cmd.Parameters.Add("@CodigoFuenteFinanciamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFuenteFinanciamiento"].Value = presupuestoComfasubDTO.CodigoFuenteFinanciamiento;

                    cmd.Parameters.Add("@CodigoSubUnidadEjecutora", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubUnidadEjecutora"].Value = presupuestoComfasubDTO.CodigoSubUnidadEjecutora;

                    cmd.Parameters.Add("@CodigoCentroGasto", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCentroGasto"].Value = presupuestoComfasubDTO.CodigoCentroGasto;

                    cmd.Parameters.Add("@CodigoPartida", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPartida"].Value = presupuestoComfasubDTO.CodigoPartida;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = presupuestoComfasubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = presupuestoComfasubDTO.UsuarioIngresoRegistro;

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

        public PresupuestoComfasubDTO BuscarFormato(int Codigo)
        {
            PresupuestoComfasubDTO presupuestoComfasubDTO = new PresupuestoComfasubDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PresupuestoComfasubEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PresupuestoComfasubId", SqlDbType.Int);
                    cmd.Parameters["@PresupuestoComfasubId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        presupuestoComfasubDTO.PresupuestoComfasubId = Convert.ToInt32(dr["PresupuestoComfasubId"]);
                        presupuestoComfasubDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        presupuestoComfasubDTO.CodigoSistemaPropulsion = dr["CodigoSistemaPropulsion"].ToString();
                        presupuestoComfasubDTO.CodigoSubSistemaPropulsion = dr["CodigoSubSistemaPropulsion"].ToString();
                        presupuestoComfasubDTO.PresupuestoAsignado = Convert.ToDecimal(dr["PresupuestoAsignado"]);
                        presupuestoComfasubDTO.CodigoFuenteFinanciamiento = dr["CodigoFuenteFinanciamiento"].ToString();
                        presupuestoComfasubDTO.CodigoSubUnidadEjecutora = dr["CodigoSubUnidadEjecutora"].ToString();
                        presupuestoComfasubDTO.CodigoCentroGasto = dr["CodigoCentroGasto"].ToString();
                        presupuestoComfasubDTO.CodigoPartida = dr["CodigoPartida"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return presupuestoComfasubDTO;
        }

        public string ActualizaFormato(PresupuestoComfasubDTO presupuestoComfasubDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PresupuestoComfasubActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PresupuestoComfasubId", SqlDbType.Int);
                    cmd.Parameters["@PresupuestoComfasubId"].Value = presupuestoComfasubDTO.PresupuestoComfasubId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = presupuestoComfasubDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoSistemaPropulsion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaPropulsion"].Value = presupuestoComfasubDTO.CodigoSistemaPropulsion;

                    cmd.Parameters.Add("@CodigoSubSistemaPropulsion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubSistemaPropulsion"].Value = presupuestoComfasubDTO.CodigoSubSistemaPropulsion;

                    cmd.Parameters.Add("@PresupuestoAsignado", SqlDbType.Decimal);
                    cmd.Parameters["@PresupuestoAsignado"].Value = presupuestoComfasubDTO.PresupuestoAsignado;

                    cmd.Parameters.Add("@CodigoFuenteFinanciamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFuenteFinanciamiento"].Value = presupuestoComfasubDTO.CodigoFuenteFinanciamiento;

                    cmd.Parameters.Add("@CodigoSubUnidadEjecutora", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubUnidadEjecutora"].Value = presupuestoComfasubDTO.CodigoSubUnidadEjecutora;

                    cmd.Parameters.Add("@CodigoCentroGasto", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCentroGasto"].Value = presupuestoComfasubDTO.CodigoCentroGasto;

                    cmd.Parameters.Add("@CodigoPartida", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPartida"].Value = presupuestoComfasubDTO.CodigoPartida;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = presupuestoComfasubDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(PresupuestoComfasubDTO presupuestoComfasubDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PresupuestoComfasubEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PresupuestoComfasubId", SqlDbType.Int);
                    cmd.Parameters["@PresupuestoComfasubId"].Value = presupuestoComfasubDTO.PresupuestoComfasubId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = presupuestoComfasubDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(PresupuestoComfasubDTO presupuestoComfasubDTO)
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
                    cmd.Parameters["@Formato"].Value = "PresupuestoComfasub";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = presupuestoComfasubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = presupuestoComfasubDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_PresupuestoComfasubRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PresupuestoComfasub", SqlDbType.Structured);
                    cmd.Parameters["@PresupuestoComfasub"].TypeName = "Formato.PresupuestoComfasub";
                    cmd.Parameters["@PresupuestoComfasub"].Value = datos;

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
