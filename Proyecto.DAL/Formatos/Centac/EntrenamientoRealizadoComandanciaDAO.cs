using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Centac;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Centac
{
    public class EntrenamientoRealizadoComandanciaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EntrenamientoRealizadoComandanciaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<EntrenamientoRealizadoComandanciaDTO> lista = new List<EntrenamientoRealizadoComandanciaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EntrenamientoRealizadoComandanciaListar", conexion);
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
                        lista.Add(new EntrenamientoRealizadoComandanciaDTO()
                        {
                            EntrenamientoRealizadoComandanciaId = Convert.ToInt32(dr["EntrenamientoRealizadoComandanciaId"]),
                            EventoEntrenamiento = dr["EventoEntrenamiento"].ToString(),
                            FechaEvento = (dr["FechaEvento"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NumeroHoras = Convert.ToInt32(dr["NumeroHoras"]),
                            EventoProgramado = dr["EventoProgramado"].ToString(),
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescTipoOperacion = dr["DescTipoOperacion"].ToString(),
                            NivelEntrenamiento = dr["NivelEntrenamiento"].ToString(),
                            DescTipoEjercicio = dr["DescTipoEjercicio"].ToString(),
                            FcComunicaciones = Convert.ToInt32(dr["FcComunicaciones"]),
                            FcPosicionInicial = Convert.ToInt32(dr["FcPosicionInicial"]),
                            FcFunciones = Convert.ToInt32(dr["FcFunciones"]),
                            FcAcciones = Convert.ToInt32(dr["FcAcciones"]),
                            FcAtaque = Convert.ToInt32(dr["FcAtaque"]),
                            PorcentajeFinalEvaluacion = Convert.ToInt32(dr["PorcentajeFinalEvaluacion"]),
                            DescFormula2CalificativoCentac = dr["DescFormula2CalificativoCentac"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EntrenamientoRealizadoComandanciaDTO entrenamientoRealizadoComandanciaDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EntrenamientoRealizadoComandanciaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EventoEntrenamiento", SqlDbType.VarChar,20);
                    cmd.Parameters["@EventoEntrenamiento"].Value = entrenamientoRealizadoComandanciaDTO.EventoEntrenamiento;

                    cmd.Parameters.Add("@FechaEvento", SqlDbType.Date);
                    cmd.Parameters["@FechaEvento"].Value = entrenamientoRealizadoComandanciaDTO.FechaEvento;

                    cmd.Parameters.Add("@NumeroHoras", SqlDbType.Int);
                    cmd.Parameters["@NumeroHoras"].Value = entrenamientoRealizadoComandanciaDTO.NumeroHoras;

                    cmd.Parameters.Add("@EventoProgramado", SqlDbType.VarChar,10);
                    cmd.Parameters["@EventoProgramado"].Value = entrenamientoRealizadoComandanciaDTO.EventoProgramado;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDependencia"].Value = entrenamientoRealizadoComandanciaDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = entrenamientoRealizadoComandanciaDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoTipoOperacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoOperacion"].Value = entrenamientoRealizadoComandanciaDTO.CodigoTipoOperacion;

                    cmd.Parameters.Add("@NivelEntrenamiento", SqlDbType.VarChar,15);
                    cmd.Parameters["@NivelEntrenamiento"].Value = entrenamientoRealizadoComandanciaDTO.NivelEntrenamiento;

                    cmd.Parameters.Add("@CodigoTipoEjercicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoEjercicio"].Value = entrenamientoRealizadoComandanciaDTO.CodigoTipoEjercicio;

                    cmd.Parameters.Add("@FcComunicaciones", SqlDbType.Int);
                    cmd.Parameters["@FcComunicaciones"].Value = entrenamientoRealizadoComandanciaDTO.FcComunicaciones;

                    cmd.Parameters.Add("@FcPosicionInicial", SqlDbType.Int);
                    cmd.Parameters["@FcPosicionInicial"].Value = entrenamientoRealizadoComandanciaDTO.FcPosicionInicial;

                    cmd.Parameters.Add("@FcFunciones", SqlDbType.Int);
                    cmd.Parameters["@FcFunciones"].Value = entrenamientoRealizadoComandanciaDTO.FcFunciones;

                    cmd.Parameters.Add("@FcAcciones", SqlDbType.Int);
                    cmd.Parameters["@FcAcciones"].Value = entrenamientoRealizadoComandanciaDTO.FcAcciones;

                    cmd.Parameters.Add("@FcAtaque", SqlDbType.Int);
                    cmd.Parameters["@FcAtaque"].Value = entrenamientoRealizadoComandanciaDTO.FcAtaque;

                    cmd.Parameters.Add("@PorcentajeFinalEvaluacion", SqlDbType.Int);
                    cmd.Parameters["@PorcentajeFinalEvaluacion"].Value = entrenamientoRealizadoComandanciaDTO.PorcentajeFinalEvaluacion;

                    cmd.Parameters.Add("@CodigoFormula2CalificativoCentac", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFormula2CalificativoCentac"].Value = entrenamientoRealizadoComandanciaDTO.CodigoFormula2CalificativoCentac;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = entrenamientoRealizadoComandanciaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entrenamientoRealizadoComandanciaDTO.UsuarioIngresoRegistro;

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

        public EntrenamientoRealizadoComandanciaDTO BuscarFormato(int Codigo)
        {
            EntrenamientoRealizadoComandanciaDTO entrenamientoRealizadoComandanciaDTO = new EntrenamientoRealizadoComandanciaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EntrenamientoRealizadoComandanciaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntrenamientoRealizadoComandanciaId", SqlDbType.Int);
                    cmd.Parameters["@EntrenamientoRealizadoComandanciaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        entrenamientoRealizadoComandanciaDTO.EntrenamientoRealizadoComandanciaId = Convert.ToInt32(dr["EntrenamientoRealizadoComandanciaId"]);
                        entrenamientoRealizadoComandanciaDTO.EventoEntrenamiento = dr["EventoEntrenamiento"].ToString();
                        entrenamientoRealizadoComandanciaDTO.FechaEvento = Convert.ToDateTime(dr["FechaEvento"]).ToString("yyy-MM-dd");
                        entrenamientoRealizadoComandanciaDTO.NumeroHoras = Convert.ToInt32(dr["NumeroHoras"]);
                        entrenamientoRealizadoComandanciaDTO.EventoProgramado = dr["EventoProgramado"].ToString();
                        entrenamientoRealizadoComandanciaDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        entrenamientoRealizadoComandanciaDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        entrenamientoRealizadoComandanciaDTO.CodigoTipoOperacion = dr["CodigoTipoOperacion"].ToString();
                        entrenamientoRealizadoComandanciaDTO.NivelEntrenamiento = dr["NivelEntrenamiento"].ToString();
                        entrenamientoRealizadoComandanciaDTO.CodigoTipoEjercicio = dr["CodigoTipoEjercicio"].ToString();
                        entrenamientoRealizadoComandanciaDTO.FcComunicaciones = Convert.ToInt32(dr["FcComunicaciones"]);
                        entrenamientoRealizadoComandanciaDTO.FcPosicionInicial = Convert.ToInt32(dr["FcPosicionInicial"]);
                        entrenamientoRealizadoComandanciaDTO.FcFunciones = Convert.ToInt32(dr["FcFunciones"]);
                        entrenamientoRealizadoComandanciaDTO.FcAcciones = Convert.ToInt32(dr["FcAcciones"]);
                        entrenamientoRealizadoComandanciaDTO.FcAtaque = Convert.ToInt32(dr["FcAtaque"]);
                        entrenamientoRealizadoComandanciaDTO.PorcentajeFinalEvaluacion = Convert.ToInt32(dr["PorcentajeFinalEvaluacion"]);
                        entrenamientoRealizadoComandanciaDTO.CodigoFormula2CalificativoCentac = dr["CodigoFormula2CalificativoCentac"].ToString(); 

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return entrenamientoRealizadoComandanciaDTO;
        }

        public string ActualizaFormato(EntrenamientoRealizadoComandanciaDTO entrenamientoRealizadoComandanciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EntrenamientoRealizadoComandanciaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntrenamientoRealizadoComandanciaId", SqlDbType.Int);
                    cmd.Parameters["@EntrenamientoRealizadoComandanciaId"].Value = entrenamientoRealizadoComandanciaDTO.EntrenamientoRealizadoComandanciaId;

                    cmd.Parameters.Add("@EventoEntrenamiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@EventoEntrenamiento"].Value = entrenamientoRealizadoComandanciaDTO.EventoEntrenamiento;

                    cmd.Parameters.Add("@FechaEvento", SqlDbType.Date);
                    cmd.Parameters["@FechaEvento"].Value = entrenamientoRealizadoComandanciaDTO.FechaEvento;

                    cmd.Parameters.Add("@NumeroHoras", SqlDbType.Int);
                    cmd.Parameters["@NumeroHoras"].Value = entrenamientoRealizadoComandanciaDTO.NumeroHoras;

                    cmd.Parameters.Add("@EventoProgramado", SqlDbType.VarChar, 10);
                    cmd.Parameters["@EventoProgramado"].Value = entrenamientoRealizadoComandanciaDTO.EventoProgramado;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = entrenamientoRealizadoComandanciaDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = entrenamientoRealizadoComandanciaDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoTipoOperacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoOperacion"].Value = entrenamientoRealizadoComandanciaDTO.CodigoTipoOperacion;

                    cmd.Parameters.Add("@NivelEntrenamiento", SqlDbType.VarChar, 15);
                    cmd.Parameters["@NivelEntrenamiento"].Value = entrenamientoRealizadoComandanciaDTO.NivelEntrenamiento;

                    cmd.Parameters.Add("@CodigoTipoEjercicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoEjercicio"].Value = entrenamientoRealizadoComandanciaDTO.CodigoTipoEjercicio;

                    cmd.Parameters.Add("@FcComunicaciones", SqlDbType.Int);
                    cmd.Parameters["@FcComunicaciones"].Value = entrenamientoRealizadoComandanciaDTO.FcComunicaciones;

                    cmd.Parameters.Add("@FcPosicionInicial", SqlDbType.Int);
                    cmd.Parameters["@FcPosicionInicial"].Value = entrenamientoRealizadoComandanciaDTO.FcPosicionInicial;

                    cmd.Parameters.Add("@FcFunciones", SqlDbType.Int);
                    cmd.Parameters["@FcFunciones"].Value = entrenamientoRealizadoComandanciaDTO.FcFunciones;

                    cmd.Parameters.Add("@FcAcciones", SqlDbType.Int);
                    cmd.Parameters["@FcAcciones"].Value = entrenamientoRealizadoComandanciaDTO.FcAcciones;

                    cmd.Parameters.Add("@FcAtaque", SqlDbType.Int);
                    cmd.Parameters["@FcAtaque"].Value = entrenamientoRealizadoComandanciaDTO.FcAtaque;

                    cmd.Parameters.Add("@PorcentajeFinalEvaluacion", SqlDbType.Int);
                    cmd.Parameters["@PorcentajeFinalEvaluacion"].Value = entrenamientoRealizadoComandanciaDTO.PorcentajeFinalEvaluacion;

                    cmd.Parameters.Add("@CodigoFormula2CalificativoCentac", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFormula2CalificativoCentac"].Value = entrenamientoRealizadoComandanciaDTO.CodigoFormula2CalificativoCentac;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entrenamientoRealizadoComandanciaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EntrenamientoRealizadoComandanciaDTO entrenamientoRealizadoComandanciaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EntrenamientoRealizadoComandanciaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntrenamientoRealizadoComandanciaId", SqlDbType.Int);
                    cmd.Parameters["@EntrenamientoRealizadoComandanciaId"].Value = entrenamientoRealizadoComandanciaDTO.EntrenamientoRealizadoComandanciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entrenamientoRealizadoComandanciaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(EntrenamientoRealizadoComandanciaDTO entrenamientoRealizadoComandanciaDTO)
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
                    cmd.Parameters["@Formato"].Value = "EntrenamientoRealizadoComandancia";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = entrenamientoRealizadoComandanciaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entrenamientoRealizadoComandanciaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EntrenamientoRealizadoComandanciaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntrenamientoRealizadoComandancia", SqlDbType.Structured);
                    cmd.Parameters["@EntrenamientoRealizadoComandancia"].TypeName = "Formato.EntrenamientoRealizadoComandancia";
                    cmd.Parameters["@EntrenamientoRealizadoComandancia"].Value = datos;

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