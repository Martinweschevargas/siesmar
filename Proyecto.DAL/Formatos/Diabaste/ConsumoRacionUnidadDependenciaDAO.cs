using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diabaste;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diabaste
{
    public class ConsumoRacionUnidadDependenciaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ConsumoRacionUnidadDependenciaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ConsumoRacionUnidadDependenciaDTO> lista = new List<ConsumoRacionUnidadDependenciaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ConsumoRacionUnidadDependenciaListar", conexion);
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
                        lista.Add(new ConsumoRacionUnidadDependenciaDTO()
                        {
                            ConsumoRacionUnidadDependenciaId = Convert.ToInt32(dr["ConsumoRacionUnidadDependenciaId"]),
                            Anio = Convert.ToInt32(dr["Anio"]),
                            DescMes = dr["DescMes"].ToString(),
                            DescAreaDiperadmon = dr["DescAreaDiperadmon"].ToString(),
                            DescTipoRacion = dr["DescTipoRacion"].ToString(),
                            NumeroRacionRequerida = Convert.ToInt32(dr["NumeroRacionRequerida"]),
                            NumeroRacionConsumida = Convert.ToInt32(dr["NumeroRacionConsumida"]),
                            NumeroPersonalSuperior = Convert.ToInt32(dr["NumeroPersonalSuperior"]),
                            NumeroPersonaSubalterno = Convert.ToInt32(dr["NumeroPersonaSubalterno"]),
                            NumeroPersonalMineria = Convert.ToInt32(dr["NumeroPersonalMineria"]),
                            NumeroPersonalCadete = Convert.ToInt32(dr["NumeroPersonalCadete"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ConsumoRacionUnidadDependenciaDTO consumoRacionUnidadDependenciaDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConsumoRacionUnidadDependenciaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Anio", SqlDbType.Int);
                    cmd.Parameters["@Anio"].Value = consumoRacionUnidadDependenciaDTO.Anio;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroMes"].Value = consumoRacionUnidadDependenciaDTO.NumeroMes;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = consumoRacionUnidadDependenciaDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@CodigoTipoRacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoRacion"].Value = consumoRacionUnidadDependenciaDTO.CodigoTipoRacion;

                    cmd.Parameters.Add("@NumeroRacionRequerida", SqlDbType.Int);
                    cmd.Parameters["@NumeroRacionRequerida"].Value = consumoRacionUnidadDependenciaDTO.NumeroRacionRequerida;

                    cmd.Parameters.Add("@NumeroRacionConsumida", SqlDbType.Int);
                    cmd.Parameters["@NumeroRacionConsumida"].Value = consumoRacionUnidadDependenciaDTO.NumeroRacionConsumida;

                    cmd.Parameters.Add("@NumeroPersonalSuperior", SqlDbType.Int);
                    cmd.Parameters["@NumeroPersonalSuperior"].Value = consumoRacionUnidadDependenciaDTO.NumeroPersonalSuperior;

                    cmd.Parameters.Add("@NumeroPersonaSubalterno", SqlDbType.Int);
                    cmd.Parameters["@NumeroPersonaSubalterno"].Value = consumoRacionUnidadDependenciaDTO.NumeroPersonaSubalterno;

                    cmd.Parameters.Add("@NumeroPersonalMineria", SqlDbType.Int);
                    cmd.Parameters["@NumeroPersonalMineria"].Value = consumoRacionUnidadDependenciaDTO.NumeroPersonalMineria;

                    cmd.Parameters.Add("@NumeroPersonalCadete", SqlDbType.Int);
                    cmd.Parameters["@NumeroPersonalCadete"].Value = consumoRacionUnidadDependenciaDTO.NumeroPersonalCadete;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = consumoRacionUnidadDependenciaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consumoRacionUnidadDependenciaDTO.UsuarioIngresoRegistro;

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

        public ConsumoRacionUnidadDependenciaDTO BuscarFormato(int Codigo)
        {
            ConsumoRacionUnidadDependenciaDTO consumoRacionUnidadDependenciaDTO = new ConsumoRacionUnidadDependenciaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConsumoRacionUnidadDependenciaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConsumoRacionUnidadDependenciaId", SqlDbType.Int);
                    cmd.Parameters["@ConsumoRacionUnidadDependenciaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        consumoRacionUnidadDependenciaDTO.ConsumoRacionUnidadDependenciaId = Convert.ToInt32(dr["ConsumoRacionUnidadDependenciaId"]);
                        consumoRacionUnidadDependenciaDTO.Anio = Convert.ToInt32(dr["Anio"]);
                        consumoRacionUnidadDependenciaDTO.NumeroMes = dr["NumeroMes"].ToString();
                        consumoRacionUnidadDependenciaDTO.CodigoAreaDiperadmon = dr["CodigoAreaDiperadmon"].ToString();
                        consumoRacionUnidadDependenciaDTO.CodigoTipoRacion = dr["CodigoTipoRacion"].ToString();
                        consumoRacionUnidadDependenciaDTO.NumeroRacionRequerida = Convert.ToInt32(dr["NumeroRacionRequerida"]);
                        consumoRacionUnidadDependenciaDTO.NumeroRacionConsumida = Convert.ToInt32(dr["NumeroRacionConsumida"]);
                        consumoRacionUnidadDependenciaDTO.NumeroPersonalSuperior = Convert.ToInt32(dr["NumeroPersonalSuperior"]);
                        consumoRacionUnidadDependenciaDTO.NumeroPersonaSubalterno = Convert.ToInt32(dr["NumeroPersonaSubalterno"]);
                        consumoRacionUnidadDependenciaDTO.NumeroPersonalMineria = Convert.ToInt32(dr["NumeroPersonalMineria"]);
                        consumoRacionUnidadDependenciaDTO.NumeroPersonalCadete = Convert.ToInt32(dr["NumeroPersonalCadete"]); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return consumoRacionUnidadDependenciaDTO;
        }

        public string ActualizaFormato(ConsumoRacionUnidadDependenciaDTO consumoRacionUnidadDependenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ConsumoRacionUnidadDependenciaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ConsumoRacionUnidadDependenciaId", SqlDbType.Int);
                    cmd.Parameters["@ConsumoRacionUnidadDependenciaId"].Value = consumoRacionUnidadDependenciaDTO.ConsumoRacionUnidadDependenciaId;

                    cmd.Parameters.Add("@Anio", SqlDbType.Int);
                    cmd.Parameters["@Anio"].Value = consumoRacionUnidadDependenciaDTO.Anio;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumeroMes"].Value = consumoRacionUnidadDependenciaDTO.NumeroMes;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = consumoRacionUnidadDependenciaDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@CodigoTipoRacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoRacion"].Value = consumoRacionUnidadDependenciaDTO.CodigoTipoRacion;

                    cmd.Parameters.Add("@NumeroRacionRequerida", SqlDbType.Int);
                    cmd.Parameters["@NumeroRacionRequerida"].Value = consumoRacionUnidadDependenciaDTO.NumeroRacionRequerida;

                    cmd.Parameters.Add("@NumeroRacionConsumida", SqlDbType.Int);
                    cmd.Parameters["@NumeroRacionConsumida"].Value = consumoRacionUnidadDependenciaDTO.NumeroRacionConsumida;

                    cmd.Parameters.Add("@NumeroPersonalSuperior", SqlDbType.Int);
                    cmd.Parameters["@NumeroPersonalSuperior"].Value = consumoRacionUnidadDependenciaDTO.NumeroPersonalSuperior;

                    cmd.Parameters.Add("@NumeroPersonaSubalterno", SqlDbType.Int);
                    cmd.Parameters["@NumeroPersonaSubalterno"].Value = consumoRacionUnidadDependenciaDTO.NumeroPersonaSubalterno;

                    cmd.Parameters.Add("@NumeroPersonalMineria", SqlDbType.Int);
                    cmd.Parameters["@NumeroPersonalMineria"].Value = consumoRacionUnidadDependenciaDTO.NumeroPersonalMineria;

                    cmd.Parameters.Add("@NumeroPersonalCadete", SqlDbType.Int);
                    cmd.Parameters["@NumeroPersonalCadete"].Value = consumoRacionUnidadDependenciaDTO.NumeroPersonalCadete;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consumoRacionUnidadDependenciaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ConsumoRacionUnidadDependenciaDTO consumoRacionUnidadDependenciaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConsumoRacionUnidadDependenciaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConsumoRacionUnidadDependenciaId", SqlDbType.Int);
                    cmd.Parameters["@ConsumoRacionUnidadDependenciaId"].Value = consumoRacionUnidadDependenciaDTO.ConsumoRacionUnidadDependenciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consumoRacionUnidadDependenciaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ConsumoRacionUnidadDependenciaDTO consumoRacionUnidadDependenciaDTO)
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
                    cmd.Parameters["@Formato"].Value = "ConsumoRacionUnidadDependencia";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = consumoRacionUnidadDependenciaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consumoRacionUnidadDependenciaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ConsumoRacionUnidadDependenciaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConsumoRacionUnidadDependencia", SqlDbType.Structured);
                    cmd.Parameters["@ConsumoRacionUnidadDependencia"].TypeName = "Formato.ConsumoRacionUnidadDependencia";
                    cmd.Parameters["@ConsumoRacionUnidadDependencia"].Value = datos;

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
