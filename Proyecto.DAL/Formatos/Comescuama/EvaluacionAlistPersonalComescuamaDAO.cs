using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comescuama;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comescuama
{
    public class EvaluacionAlistPersonalComescuamaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionAlistPersonalComescuamaDTO> ObtenerLista(int? CargaId = null)
        {
            List<EvaluacionAlistPersonalComescuamaDTO> lista = new List<EvaluacionAlistPersonalComescuamaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComescuamaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;


                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        lista.Add(new EvaluacionAlistPersonalComescuamaDTO()
                        {
                            EvaluacionAlistamientoPersonalId = Convert.ToInt32(dr["EvaluacionAlistamientoPersonalId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            FechaEvaluacion = (dr["FechaEvaluacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DNIPersonal = dr["DNIPersonal"].ToString(),
                            CIPPersonal = dr["CIPPersonal"].ToString(),
                            CodigoCargo = dr["CodigoCargo"].ToString(),
                            DescGradoPersonalMilitarEsperado = dr["DescGradoPersonalMilitarEsperado"].ToString(),
                            DescEspecialidadGenericaEsperado = dr["DescEspecialidadGenericaEsperado"].ToString(),
                            DescGradoPersonalMilitarActual = dr["DescGradoPersonalMilitarActual"].ToString(),
                            DescEspecialidadGenericaActual = dr["DescEspecialidadGenericaActual"].ToString(),
                            GradoJerarquico = Convert.ToDecimal(dr["GradoJerarquico"]),
                            ServicioExperiencia = Convert.ToDecimal(dr["ServicioExperiencia"]),
                            EspecializacionProfesional = Convert.ToDecimal(dr["EspecializacionProfesional"]),
                            CursoProfesionalRequerido = Convert.ToDecimal(dr["CursoProfesionalRequerido"]),
                            TotalPuntaje = Convert.ToDecimal(dr["TotalPuntaje"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EvaluacionAlistPersonalComescuamaDTO evaluacionAlistPersonalComescuamaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComescuamaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = evaluacionAlistPersonalComescuamaDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@FechaEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaEvaluacion"].Value = evaluacionAlistPersonalComescuamaDTO.FechaEvaluacion;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPersonal"].Value = evaluacionAlistPersonalComescuamaDTO.DNIPersonal;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIPPersonal"].Value = evaluacionAlistPersonalComescuamaDTO.CIPPersonal;

                    cmd.Parameters.Add("@CodigoCargo ", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoCargo "].Value = evaluacionAlistPersonalComescuamaDTO.CodigoCargo;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarEsperado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarEsperado"].Value = evaluacionAlistPersonalComescuamaDTO.CodigoGradoPersonalMilitarEsperado;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaEsperado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaEsperado"].Value = evaluacionAlistPersonalComescuamaDTO.CodigoEspecialidadGenericaEsperado;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarActual", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarActual"].Value = evaluacionAlistPersonalComescuamaDTO.CodigoGradoPersonalMilitarActual;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaActual", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaActual"].Value = evaluacionAlistPersonalComescuamaDTO.CodigoEspecialidadGenericaActual;

                    cmd.Parameters.Add("@GradoJerarquico", SqlDbType.Decimal);
                    cmd.Parameters["@GradoJerarquico"].Value = evaluacionAlistPersonalComescuamaDTO.GradoJerarquico;

                    cmd.Parameters.Add("@ServicioExperiencia", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioExperiencia"].Value = evaluacionAlistPersonalComescuamaDTO.ServicioExperiencia;

                    cmd.Parameters.Add("@EspecializacionProfesional", SqlDbType.Decimal);
                    cmd.Parameters["@EspecializacionProfesional"].Value = evaluacionAlistPersonalComescuamaDTO.EspecializacionProfesional;

                    cmd.Parameters.Add("@CursoProfesionalRequerido", SqlDbType.Decimal);
                    cmd.Parameters["@CursoProfesionalRequerido"].Value = evaluacionAlistPersonalComescuamaDTO.CursoProfesionalRequerido;

                    cmd.Parameters.Add("@TotalPuntaje", SqlDbType.Decimal);
                    cmd.Parameters["@TotalPuntaje"].Value = evaluacionAlistPersonalComescuamaDTO.TotalPuntaje;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionAlistPersonalComescuamaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistPersonalComescuamaDTO.UsuarioIngresoRegistro;

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

        public EvaluacionAlistPersonalComescuamaDTO BuscarFormato(int Codigo)
        {
            EvaluacionAlistPersonalComescuamaDTO evaluacionAlistPersonalComescuamaDTO = new EvaluacionAlistPersonalComescuamaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComescuamaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        evaluacionAlistPersonalComescuamaDTO.EvaluacionAlistamientoPersonalId = Convert.ToInt32(dr["EvaluacionAlistamientoPersonalId"]);
                        evaluacionAlistPersonalComescuamaDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        evaluacionAlistPersonalComescuamaDTO.FechaEvaluacion = Convert.ToDateTime(dr["FechaEvaluacion"]).ToString("yyy-MM-dd");
                        evaluacionAlistPersonalComescuamaDTO.DNIPersonal = dr["DNIPersonal"].ToString();
                        evaluacionAlistPersonalComescuamaDTO.CIPPersonal = dr["CIPPersonal"].ToString();
                        evaluacionAlistPersonalComescuamaDTO.CodigoCargo = dr["CodigoCargo "].ToString();
                        evaluacionAlistPersonalComescuamaDTO.CodigoGradoPersonalMilitarEsperado = dr["CodigoGradoPersonalMilitarEsperado"].ToString();
                        evaluacionAlistPersonalComescuamaDTO.CodigoEspecialidadGenericaEsperado = dr["CodigoEspecialidadGenericaEsperado"].ToString();
                        evaluacionAlistPersonalComescuamaDTO.CodigoGradoPersonalMilitarActual = dr["CodigoGradoPersonalMilitarActual"].ToString();
                        evaluacionAlistPersonalComescuamaDTO.CodigoEspecialidadGenericaActual = dr["CodigoEspecialidadGenericaActual"].ToString();
                        evaluacionAlistPersonalComescuamaDTO.GradoJerarquico = Convert.ToDecimal(dr["GradoJerarquico"]);
                        evaluacionAlistPersonalComescuamaDTO.ServicioExperiencia = Convert.ToDecimal(dr["ServicioExperiencia"]);
                        evaluacionAlistPersonalComescuamaDTO.EspecializacionProfesional = Convert.ToDecimal(dr["EspecializacionProfesional"]);
                        evaluacionAlistPersonalComescuamaDTO.CursoProfesionalRequerido = Convert.ToDecimal(dr["CursoProfesionalRequerido"]);
                        evaluacionAlistPersonalComescuamaDTO.TotalPuntaje = Convert.ToDecimal(dr["TotalPuntaje"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionAlistPersonalComescuamaDTO;
        }

        public string ActualizaFormato(EvaluacionAlistPersonalComescuamaDTO evaluacionAlistPersonalComescuamaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComescuamaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = evaluacionAlistPersonalComescuamaDTO.EvaluacionAlistamientoPersonalId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = evaluacionAlistPersonalComescuamaDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@FechaEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaEvaluacion"].Value = evaluacionAlistPersonalComescuamaDTO.FechaEvaluacion;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPersonal"].Value = evaluacionAlistPersonalComescuamaDTO.DNIPersonal;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIPPersonal"].Value = evaluacionAlistPersonalComescuamaDTO.CIPPersonal;

                    cmd.Parameters.Add("@CodigoCargo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCargo "].Value = evaluacionAlistPersonalComescuamaDTO.CodigoCargo;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarEsperado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarEsperado"].Value = evaluacionAlistPersonalComescuamaDTO.CodigoGradoPersonalMilitarEsperado;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaEsperado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaEsperado"].Value = evaluacionAlistPersonalComescuamaDTO.CodigoEspecialidadGenericaEsperado;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitarActual", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitarActual"].Value = evaluacionAlistPersonalComescuamaDTO.CodigoGradoPersonalMilitarActual;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaActual", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaActual"].Value = evaluacionAlistPersonalComescuamaDTO.CodigoEspecialidadGenericaActual;

                    cmd.Parameters.Add("@GradoJerarquico", SqlDbType.Decimal);
                    cmd.Parameters["@GradoJerarquico"].Value = evaluacionAlistPersonalComescuamaDTO.GradoJerarquico;

                    cmd.Parameters.Add("@ServicioExperiencia", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioExperiencia"].Value = evaluacionAlistPersonalComescuamaDTO.ServicioExperiencia;

                    cmd.Parameters.Add("@EspecializacionProfesional", SqlDbType.Decimal);
                    cmd.Parameters["@EspecializacionProfesional"].Value = evaluacionAlistPersonalComescuamaDTO.EspecializacionProfesional;

                    cmd.Parameters.Add("@CursoProfesionalRequerido", SqlDbType.Decimal);
                    cmd.Parameters["@CursoProfesionalRequerido"].Value = evaluacionAlistPersonalComescuamaDTO.CursoProfesionalRequerido;

                    cmd.Parameters.Add("@TotalPuntaje", SqlDbType.Decimal);
                    cmd.Parameters["@TotalPuntaje"].Value = evaluacionAlistPersonalComescuamaDTO.TotalPuntaje;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistPersonalComescuamaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvaluacionAlistPersonalComescuamaDTO evaluacionAlistPersonalComescuamaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComescuamaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = evaluacionAlistPersonalComescuamaDTO.EvaluacionAlistamientoPersonalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistPersonalComescuamaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComescuamaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalComescuama", SqlDbType.Structured);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalComescuama"].TypeName = "Formato.EvaluacionAlistamientoPersonalComescuama";
                    cmd.Parameters["@EvaluacionAlistamientoPersonalComescuama"].Value = datos;

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
