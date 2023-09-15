using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Bienestar
{
    public class MovilidadEscolarDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<MovilidadEscolarDTO> ObtenerLista(int? CargaId = null, string? fechaInicio = null, string? fechaFin = null)
        {
            List<MovilidadEscolarDTO> lista = new List<MovilidadEscolarDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_MovilidadEscolarListar", conexion);
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
                        lista.Add(new MovilidadEscolarDTO()
                        {
                            MovilidadEscolarId = Convert.ToInt32(dr["MovilidadEscolarId"]),
                            Fecha = (dr["Fecha"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NumeroPlaca = dr["NumeroPlaca"].ToString(),
                            ClasificacionVehiculo = dr["ClasificacionVehiculo"].ToString(),
                            AnioFabricacion = Convert.ToInt32(dr["AnioFabricacion"]),
                            CapacidadTransporte = Convert.ToInt32(dr["CapacidadTransporte"]),
                            DescInstitucionEducativa = dr["DescInstitucionEducativa"].ToString(),
                            CantidadPersonasTransportadas = Convert.ToInt32(dr["CantidadPersonasTransportadas"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });
                    }
                }
            }
            return lista;
        }

        public List<MovilidadEscolarDTO> BienestarVisualizacionMovilidadEscolar(int? CargaId=null, string? fechaInicio=null, string? fechaFin=null)
        {
            List<MovilidadEscolarDTO> lista = new List<MovilidadEscolarDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_BienestarVisualizacionMovilidadEscolar", conexion);
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
                        lista.Add(new MovilidadEscolarDTO()
                        {
                            Fecha = dr["Fecha"].ToString(),
                            NumeroPlaca = dr["NumeroPlaca"].ToString(),
                            ClasificacionVehiculo = dr["ClasificacionVehiculo"].ToString(),
                            AnioFabricacion = Convert.ToInt32(dr["AnioFabricacion"]),
                            CapacidadTransporte = Convert.ToInt32(dr["CapacidadTransporte"]),
                            DescInstitucionEducativa = dr["DescInstitucionEducativa"].ToString(),
                            CantidadPersonasTransportadas = Convert.ToInt32(dr["CantidadPersonasTransportadas"]),

                        });
                    }
                }
            }
            return lista;
        }


        public string AgregarRegistro(MovilidadEscolarDTO movilidadEscolarDTO, string fechaCarga)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MovilidadEscolarRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Fecha", SqlDbType.Date);
                    cmd.Parameters["@Fecha"].Value = movilidadEscolarDTO.Fecha;

                    cmd.Parameters.Add("@NumeroPlaca", SqlDbType.VarChar,10);
                    cmd.Parameters["@NumeroPlaca"].Value = movilidadEscolarDTO.NumeroPlaca;

                    cmd.Parameters.Add("@CodigoMarcaVehiculo", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoMarcaVehiculo"].Value = movilidadEscolarDTO.CodigoMarcaVehiculo;

                    cmd.Parameters.Add("@AnioFabricacion", SqlDbType.Int);
                    cmd.Parameters["@AnioFabricacion"].Value = movilidadEscolarDTO.AnioFabricacion;

                    cmd.Parameters.Add("@CapacidadTransporte", SqlDbType.Int);
                    cmd.Parameters["@CapacidadTransporte"].Value = movilidadEscolarDTO.CapacidadTransporte;

                    cmd.Parameters.Add("@CodigoInstitucionEducativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInstitucionEducativa"].Value = movilidadEscolarDTO.CodigoInstitucionEducativa;

                    cmd.Parameters.Add("@CantidadPersonasTransportadas", SqlDbType.Int);
                    cmd.Parameters["@CantidadPersonasTransportadas"].Value = movilidadEscolarDTO.CantidadPersonasTransportadas;       
                    
                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = movilidadEscolarDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = movilidadEscolarDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fechaCarga;

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

        public MovilidadEscolarDTO BuscarFormato(int Codigo)
        {
            MovilidadEscolarDTO movilidadEscolarDTO = new MovilidadEscolarDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MovilidadEscolarEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MovilidadEscolarId", SqlDbType.Int);
                    cmd.Parameters["@MovilidadEscolarId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        movilidadEscolarDTO.MovilidadEscolarId = Convert.ToInt32(dr["MovilidadEscolarId"]);
                        movilidadEscolarDTO.Fecha = Convert.ToDateTime(dr["Fecha"]).ToString("yyy-MM-dd");
                        movilidadEscolarDTO.NumeroPlaca = dr["NumeroPlaca"].ToString();
                        movilidadEscolarDTO.CodigoMarcaVehiculo = dr["CodigoMarcaVehiculo"].ToString();
                        movilidadEscolarDTO.AnioFabricacion = Convert.ToInt32(dr["AnioFabricacion"]);
                        movilidadEscolarDTO.CapacidadTransporte = Convert.ToInt32(dr["CapacidadTransporte"]);
                        movilidadEscolarDTO.CodigoInstitucionEducativa = dr["CodigoInstitucionEducativa"].ToString();
                        movilidadEscolarDTO.CantidadPersonasTransportadas = Convert.ToInt32(dr["CantidadPersonasTransportadas"]); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return movilidadEscolarDTO;
        }

        public string ActualizaFormato(MovilidadEscolarDTO movilidadEscolarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_MovilidadEscolarActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@MovilidadEscolarId", SqlDbType.Int);
                    cmd.Parameters["@MovilidadEscolarId"].Value = movilidadEscolarDTO.MovilidadEscolarId;

                    cmd.Parameters.Add("@Fecha", SqlDbType.Date);
                    cmd.Parameters["@Fecha"].Value = movilidadEscolarDTO.Fecha;

                    cmd.Parameters.Add("@NumeroPlaca", SqlDbType.VarChar,10);
                    cmd.Parameters["@NumeroPlaca"].Value = movilidadEscolarDTO.NumeroPlaca;


                    cmd.Parameters.Add("@CodigoMarcaVehiculo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMarcaVehiculo"].Value = movilidadEscolarDTO.CodigoMarcaVehiculo;

                    cmd.Parameters.Add("@AnioFabricacion", SqlDbType.Int);
                    cmd.Parameters["@AnioFabricacion"].Value = movilidadEscolarDTO.AnioFabricacion;

                    cmd.Parameters.Add("@CapacidadTransporte", SqlDbType.Int);
                    cmd.Parameters["@CapacidadTransporte"].Value = movilidadEscolarDTO.CapacidadTransporte;

                    cmd.Parameters.Add("@CodigoInstitucionEducativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInstitucionEducativa"].Value = movilidadEscolarDTO.CodigoInstitucionEducativa;

                    cmd.Parameters.Add("@CantidadPersonasTransportadas", SqlDbType.Int);
                    cmd.Parameters["@CantidadPersonasTransportadas"].Value = movilidadEscolarDTO.CantidadPersonasTransportadas;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = movilidadEscolarDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(MovilidadEscolarDTO movilidadEscolarDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MovilidadEscolarEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MovilidadEscolarId", SqlDbType.Int);
                    cmd.Parameters["@MovilidadEscolarId"].Value = movilidadEscolarDTO.MovilidadEscolarId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = movilidadEscolarDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(MovilidadEscolarDTO movilidadEscolarDTO)
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
                    cmd.Parameters["@Formato"].Value = "MovilidadEscolar";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = movilidadEscolarDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = movilidadEscolarDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos, string fechaCarga)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_MovilidadEscolarRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MovilidadEscolar", SqlDbType.Structured);
                    cmd.Parameters["@MovilidadEscolar"].TypeName = "Formato.MovilidadEscolar";
                    cmd.Parameters["@MovilidadEscolar"].Value = datos;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fechaCarga;

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
