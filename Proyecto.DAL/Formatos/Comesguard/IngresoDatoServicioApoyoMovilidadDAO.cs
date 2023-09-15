using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comesguard;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comesguard
{
    public class IngresoDatoServicioApoyoMovilidadDAO
    {

        SqlCommand cmd = new SqlCommand();


        public List<IngresoDatoServicioApoyoMovilidadDTO> ObtenerLista(int? CargaId = null)
        {
            List<IngresoDatoServicioApoyoMovilidadDTO> lista = new List<IngresoDatoServicioApoyoMovilidadDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_IngresoDatoServicioApoyoMovilidadListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new IngresoDatoServicioApoyoMovilidadDTO()
                        {
                            IngresoDatoServicioApoyoMovilidadId = Convert.ToInt32(dr["IngresoDatoServicioApoyoMovilidadId"]),
                            FechaInicio = (dr["FechaInicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTermino = (dr["FechaTermino"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescDependencia = dr["DescDependencia"].ToString(),
                            Clasificacion = dr["Clasificacion"].ToString(),
                            ClasificacionVehiculo = dr["ClasificacionVehiculo"].ToString(),
                            PlacaVehiculo = dr["PlacaVehiculo"].ToString(),
                            DescEstadoOperativo = dr["DescEstadoOperativo"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(IngresoDatoServicioApoyoMovilidadDTO ingresoDatoServicioApoyoMovilidadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_IngresoDatoServicioApoyoMovilidadRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = ingresoDatoServicioApoyoMovilidadDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = ingresoDatoServicioApoyoMovilidadDTO.FechaTermino;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = ingresoDatoServicioApoyoMovilidadDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoClaseVehiculo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClaseVehiculo "].Value = ingresoDatoServicioApoyoMovilidadDTO.CodigoClaseVehiculo;

                    cmd.Parameters.Add("@CodigoMarcaVehiculo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMarcaVehiculo "].Value = ingresoDatoServicioApoyoMovilidadDTO.CodigoMarcaVehiculo;

                    cmd.Parameters.Add("@PlacaVehiculo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@PlacaVehiculo"].Value = ingresoDatoServicioApoyoMovilidadDTO.PlacaVehiculo;

                    cmd.Parameters.Add("@CodigoEstadoOperativo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstadoOperativo "].Value = ingresoDatoServicioApoyoMovilidadDTO.CodigoEstadoOperativo;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = ingresoDatoServicioApoyoMovilidadDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ingresoDatoServicioApoyoMovilidadDTO.UsuarioIngresoRegistro;

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

        public IngresoDatoServicioApoyoMovilidadDTO BuscarFormato(int Codigo)
        {
            IngresoDatoServicioApoyoMovilidadDTO ingresoDatoServicioApoyoMovilidadDTO = new IngresoDatoServicioApoyoMovilidadDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_IngresoDatoServicioApoyoMovilidadEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngresoDatoServicioApoyoMovilidadId", SqlDbType.Int);
                    cmd.Parameters["@IngresoDatoServicioApoyoMovilidadId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ingresoDatoServicioApoyoMovilidadDTO.IngresoDatoServicioApoyoMovilidadId = Convert.ToInt32(dr["IngresoDatoServicioApoyoMovilidadId"]);
                        ingresoDatoServicioApoyoMovilidadDTO.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]).ToString("yyy-MM-dd");
                        ingresoDatoServicioApoyoMovilidadDTO.FechaTermino = Convert.ToDateTime(dr["FechaTermino"]).ToString("yyy-MM-dd");
                        ingresoDatoServicioApoyoMovilidadDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        ingresoDatoServicioApoyoMovilidadDTO.CodigoClaseVehiculo = dr["CodigoClaseVehiculo"].ToString();
                        ingresoDatoServicioApoyoMovilidadDTO.CodigoMarcaVehiculo = dr["CodigoMarcaVehiculo"].ToString();
                        ingresoDatoServicioApoyoMovilidadDTO.PlacaVehiculo = dr["PlacaVehiculo"].ToString();
                        ingresoDatoServicioApoyoMovilidadDTO.CodigoEstadoOperativo = dr["CodigoEstadoOperativo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ingresoDatoServicioApoyoMovilidadDTO;
        }

        public string ActualizaFormato(IngresoDatoServicioApoyoMovilidadDTO ingresoDatoServicioApoyoMovilidadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_IngresoDatoServicioApoyoMovilidadActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@IngresoDatoServicioApoyoMovilidadId", SqlDbType.Int);
                    cmd.Parameters["@IngresoDatoServicioApoyoMovilidadId"].Value = ingresoDatoServicioApoyoMovilidadDTO.IngresoDatoServicioApoyoMovilidadId;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = ingresoDatoServicioApoyoMovilidadDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = ingresoDatoServicioApoyoMovilidadDTO.FechaTermino;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = ingresoDatoServicioApoyoMovilidadDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoClaseVehiculo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClaseVehiculo "].Value = ingresoDatoServicioApoyoMovilidadDTO.CodigoClaseVehiculo;

                    cmd.Parameters.Add("@CodigoMarcaVehiculo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMarcaVehiculo "].Value = ingresoDatoServicioApoyoMovilidadDTO.CodigoMarcaVehiculo;

                    cmd.Parameters.Add("@PlacaVehiculo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@PlacaVehiculo"].Value = ingresoDatoServicioApoyoMovilidadDTO.PlacaVehiculo;

                    cmd.Parameters.Add("@CodigoEstadoOperativo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstadoOperativo "].Value = ingresoDatoServicioApoyoMovilidadDTO.CodigoEstadoOperativo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ingresoDatoServicioApoyoMovilidadDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(IngresoDatoServicioApoyoMovilidadDTO ingresoDatoServicioApoyoMovilidadDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_IngresoDatoServicioApoyoMovilidadEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngresoDatoServicioApoyoMovilidadId", SqlDbType.Int);
                    cmd.Parameters["@IngresoDatoServicioApoyoMovilidadId"].Value = ingresoDatoServicioApoyoMovilidadDTO.IngresoDatoServicioApoyoMovilidadId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ingresoDatoServicioApoyoMovilidadDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_IngresoDatoServicioApoyoMovilidadRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngresoDatoServicioApoyoMovilidad", SqlDbType.Structured);
                    cmd.Parameters["@IngresoDatoServicioApoyoMovilidad"].TypeName = "Formato.IngresoDatoServicioApoyoMovilidad";
                    cmd.Parameters["@IngresoDatoServicioApoyoMovilidad"].Value = datos;

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
