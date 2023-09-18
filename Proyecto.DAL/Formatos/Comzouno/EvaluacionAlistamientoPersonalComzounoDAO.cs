using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comzouno;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comzouno
{
    public class EvaluacionAlistamientoPersonalComzounoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionAlistamientoPersonalComzounoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<EvaluacionAlistamientoPersonalComzounoDTO> lista = new List<EvaluacionAlistamientoPersonalComzounoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComzounoListar", conexion);
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
                        lista.Add(new EvaluacionAlistamientoPersonalComzounoDTO()
                        {
                            EvaluacionAlistamientoPersonalId = Convert.ToInt32(dr["EvaluacionAlistamientoPersonalId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            FechaEvaluacion = (dr["FechaEvaluacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DNIPersonal = dr["DNIPersonal"].ToString(),
                            CIPPersonal = dr["CIPPersonal"].ToString(),
                            DescCargo = dr["DescCargo"].ToString(),
                            DescGrado = dr["GradoEsperado"].ToString(),
                            DescEspecialidad = dr["EspecialidadEsperado"].ToString(),
                            DescGradoPersonalMilitarActual = dr["GradoActual"].ToString(),
                            DescEspecialidadGenericaPersonalActual = dr["EspecialdadActual"].ToString(),
                            GradoJerarquico = Convert.ToDecimal(dr["GradoJerarquico"]),
                            ServicioExperiencia = Convert.ToDecimal(dr["ServicioExperiencia"]),
                            EspecializacionProfesional = Convert.ToDecimal(dr["EspecializacionProfesional"]),
                            CursoProfesionalRequerido = Convert.ToDecimal(dr["CursoProfesionalRequerido"]),
                            PuntajeTotalPersonal = Convert.ToDecimal(dr["PuntajeTotalPersonal"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EvaluacionAlistamientoPersonalComzounoDTO evaluacionAlistamientoPersonalComzounoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComzounoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = evaluacionAlistamientoPersonalComzounoDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@FechaEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaEvaluacion"].Value = evaluacionAlistamientoPersonalComzounoDTO.FechaEvaluacion;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DNIPersonal"].Value = evaluacionAlistamientoPersonalComzounoDTO.DNIPersonal;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CIPPersonal"].Value = evaluacionAlistamientoPersonalComzounoDTO.CIPPersonal;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCargo"].Value = evaluacionAlistamientoPersonalComzounoDTO.CodigoCargo;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarEsperado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarEsperado"].Value = evaluacionAlistamientoPersonalComzounoDTO.CodigoGradoPersonalMilitarEsperado;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaEsperado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaEsperado"].Value = evaluacionAlistamientoPersonalComzounoDTO.CodigoEspecialidadGenericaEsperado;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarActual", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarActual"].Value = evaluacionAlistamientoPersonalComzounoDTO.CodigoGradoPersonalMilitarActual;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaActual", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaActual"].Value = evaluacionAlistamientoPersonalComzounoDTO.CodigoEspecialidadGenericaActual;

                    cmd.Parameters.Add("@GradoJerarquico", SqlDbType.Decimal);
                    cmd.Parameters["@GradoJerarquico"].Value = evaluacionAlistamientoPersonalComzounoDTO.GradoJerarquico;

                    cmd.Parameters.Add("@ServicioExperiencia", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioExperiencia"].Value = evaluacionAlistamientoPersonalComzounoDTO.ServicioExperiencia;

                    cmd.Parameters.Add("@EspecializacionProfesional", SqlDbType.Decimal);
                    cmd.Parameters["@EspecializacionProfesional"].Value = evaluacionAlistamientoPersonalComzounoDTO.EspecializacionProfesional;

                    cmd.Parameters.Add("@CursoProfesionalRequerido", SqlDbType.Decimal);
                    cmd.Parameters["@CursoProfesionalRequerido"].Value = evaluacionAlistamientoPersonalComzounoDTO.CursoProfesionalRequerido;

                    cmd.Parameters.Add("@PuntajeTotalPersonal", SqlDbType.Decimal);
                    cmd.Parameters["@PuntajeTotalPersonal"].Value = evaluacionAlistamientoPersonalComzounoDTO.PuntajeTotalPersonal;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionAlistamientoPersonalComzounoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoPersonalComzounoDTO.UsuarioIngresoRegistro;

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

        public EvaluacionAlistamientoPersonalComzounoDTO BuscarFormato(int Codigo)
        {
            EvaluacionAlistamientoPersonalComzounoDTO evaluacionAlistamientoPersonalComzounoDTO = new EvaluacionAlistamientoPersonalComzounoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComzounoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        evaluacionAlistamientoPersonalComzounoDTO.EvaluacionAlistamientoPersonalId = Convert.ToInt32(dr["EvaluacionAlistamientoPersonalId"]);
                        evaluacionAlistamientoPersonalComzounoDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        evaluacionAlistamientoPersonalComzounoDTO.FechaEvaluacion = Convert.ToDateTime(dr["FechaEvaluacion"]).ToString("yyy-MM-dd");
                        evaluacionAlistamientoPersonalComzounoDTO.DNIPersonal = dr["DNIPersonal"].ToString();
                        evaluacionAlistamientoPersonalComzounoDTO.CIPPersonal = dr["CIPPersonal"].ToString(); 
                        evaluacionAlistamientoPersonalComzounoDTO.CodigoCargo = dr["CodigoCargo"].ToString();
                        evaluacionAlistamientoPersonalComzounoDTO.CodigoGradoPersonalMilitarEsperado = dr["CodigoGradoPersonalMilitarEsperado"].ToString();
                        evaluacionAlistamientoPersonalComzounoDTO.CodigoEspecialidadGenericaEsperado = dr["CodigoEspecialidadGenericaEsperado"].ToString();
                        evaluacionAlistamientoPersonalComzounoDTO.CodigoGradoPersonalMilitarActual = dr["CodigoGradoPersonalMilitarActual"].ToString();
                        evaluacionAlistamientoPersonalComzounoDTO.CodigoEspecialidadGenericaActual = dr["CodigoEspecialidadGenericaActual"].ToString();
                        evaluacionAlistamientoPersonalComzounoDTO.GradoJerarquico = Convert.ToDecimal(dr["GradoJerarquico"]);
                        evaluacionAlistamientoPersonalComzounoDTO.ServicioExperiencia = Convert.ToDecimal(dr["ServicioExperiencia"]);
                        evaluacionAlistamientoPersonalComzounoDTO.EspecializacionProfesional = Convert.ToDecimal(dr["EspecializacionProfesional"]);
                        evaluacionAlistamientoPersonalComzounoDTO.CursoProfesionalRequerido = Convert.ToDecimal(dr["CursoProfesionalRequerido"]);
                        evaluacionAlistamientoPersonalComzounoDTO.PuntajeTotalPersonal = Convert.ToDecimal(dr["PuntajeTotalPersonal"]);

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionAlistamientoPersonalComzounoDTO;
        }

        public string ActualizaFormato(EvaluacionAlistamientoPersonalComzounoDTO evaluacionAlistamientoPersonalComzounoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComzounoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = evaluacionAlistamientoPersonalComzounoDTO.EvaluacionAlistamientoPersonalId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = evaluacionAlistamientoPersonalComzounoDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@FechaEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaEvaluacion"].Value = evaluacionAlistamientoPersonalComzounoDTO.FechaEvaluacion;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DNIPersonal"].Value = evaluacionAlistamientoPersonalComzounoDTO.DNIPersonal;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CIPPersonal"].Value = evaluacionAlistamientoPersonalComzounoDTO.CIPPersonal;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCargo"].Value = evaluacionAlistamientoPersonalComzounoDTO.CodigoCargo;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarEsperado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarEsperado"].Value = evaluacionAlistamientoPersonalComzounoDTO.CodigoGradoPersonalMilitarEsperado;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaEsperado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaEsperado"].Value = evaluacionAlistamientoPersonalComzounoDTO.CodigoEspecialidadGenericaEsperado;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarActual", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarActual"].Value = evaluacionAlistamientoPersonalComzounoDTO.CodigoGradoPersonalMilitarActual;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaActual", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaActual"].Value = evaluacionAlistamientoPersonalComzounoDTO.CodigoEspecialidadGenericaActual;

                    cmd.Parameters.Add("@GradoJerarquico", SqlDbType.Decimal);
                    cmd.Parameters["@GradoJerarquico"].Value = evaluacionAlistamientoPersonalComzounoDTO.GradoJerarquico;

                    cmd.Parameters.Add("@ServicioExperiencia", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioExperiencia"].Value = evaluacionAlistamientoPersonalComzounoDTO.ServicioExperiencia;

                    cmd.Parameters.Add("@EspecializacionProfesional", SqlDbType.Decimal);
                    cmd.Parameters["@EspecializacionProfesional"].Value = evaluacionAlistamientoPersonalComzounoDTO.EspecializacionProfesional;

                    cmd.Parameters.Add("@CursoProfesionalRequerido", SqlDbType.Decimal);
                    cmd.Parameters["@CursoProfesionalRequerido"].Value = evaluacionAlistamientoPersonalComzounoDTO.CursoProfesionalRequerido;
                    
                    cmd.Parameters.Add("@PuntajeTotalPersonal", SqlDbType.Decimal);
                    cmd.Parameters["@PuntajeTotalPersonal"].Value = evaluacionAlistamientoPersonalComzounoDTO.PuntajeTotalPersonal;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoPersonalComzounoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvaluacionAlistamientoPersonalComzounoDTO evaluacionAlistamientoPersonalComzounoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComzounoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = evaluacionAlistamientoPersonalComzounoDTO.EvaluacionAlistamientoPersonalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoPersonalComzounoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(EvaluacionAlistamientoPersonalComzounoDTO evaluacionAlistamientoPersonalComzounoDTO)
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
                    cmd.Parameters["@Formato"].Value = "EvaluacionAlistamientoPersonalComzouno";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionAlistamientoPersonalComzounoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistamientoPersonalComzounoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComzounoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalComzouno", SqlDbType.Structured);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalComzouno"].TypeName = "Formato.EvaluacionAlistamientoPersonalComzouno";
                    cmd.Parameters["@EvaluacionAlistamientoPersonalComzouno"].Value = datos;

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
