using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comzocuatro
{
    public class EvaluacionAlistPersonalComzocuatroDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionAlistPersonalComzocuatroDTO> ObtenerLista(int? CargaId = null)
        {
            List<EvaluacionAlistPersonalComzocuatroDTO> lista = new List<EvaluacionAlistPersonalComzocuatroDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComzocuatroListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EvaluacionAlistPersonalComzocuatroDTO()
                        {
                            EvaluacionAlistamientoPersonalId = Convert.ToInt32(dr["EvaluacionAlistamientoPersonalId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            FechaEvaluacion = (dr["FechaEvaluacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DNIPersonal = Convert.ToInt32(dr["DNIPersonal"]),
                            CIPPersonal = Convert.ToInt32(dr["CIPPersonal"]),
                            CargoPersonal = dr["CargoPersonal"].ToString(),
                            DescGradoPersonalMilitarEsperado = dr["DescGradoPersonalMilitarEsperado"].ToString(),
                            DescEspecialidadGenericaEsperado = dr["DescEspecialidadGenericaEsperado"].ToString(),
                            DescGradoPersonalMilitarActual = dr["DescGradoPersonalMilitarActual"].ToString(),
                            DescEspecialidadGenericaActual = dr["DescEspecialidadGenericaActual"].ToString(),
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

        public string AgregarRegistro(EvaluacionAlistPersonalComzocuatroDTO evaluacionAlistPersonalComzocuatroDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComzocuatroRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = evaluacionAlistPersonalComzocuatroDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@FechaEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaEvaluacion"].Value = evaluacionAlistPersonalComzocuatroDTO.FechaEvaluacion;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.Int);
                    cmd.Parameters["@DNIPersonal"].Value = evaluacionAlistPersonalComzocuatroDTO.DNIPersonal;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.Int);
                    cmd.Parameters["@CIPPersonal"].Value = evaluacionAlistPersonalComzocuatroDTO.CIPPersonal;

                    cmd.Parameters.Add("@CargoPersonal", SqlDbType.VarChar,20);
                    cmd.Parameters["@CargoPersonal"].Value = evaluacionAlistPersonalComzocuatroDTO.CargoPersonal;

                    cmd.Parameters.Add("@GradoPersonalMilitarEsperado", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarEsperado"].Value = evaluacionAlistPersonalComzocuatroDTO.GradoPersonalMilitarEsperado;

                    cmd.Parameters.Add("@EspecialidadGenericaEsperado", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaEsperado"].Value = evaluacionAlistPersonalComzocuatroDTO.EspecialidadGenericaEsperado;

                    cmd.Parameters.Add("@GradoPersonalMilitarActual", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarActual"].Value = evaluacionAlistPersonalComzocuatroDTO.GradoPersonalMilitarActual;

                    cmd.Parameters.Add("@EspecialidadGenericaActual", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaActual"].Value = evaluacionAlistPersonalComzocuatroDTO.EspecialidadGenericaActual;

                    cmd.Parameters.Add("@GradoJerarquico", SqlDbType.Decimal);
                    cmd.Parameters["@GradoJerarquico"].Value = evaluacionAlistPersonalComzocuatroDTO.GradoJerarquico;

                    cmd.Parameters.Add("@ServicioExperiencia", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioExperiencia"].Value = evaluacionAlistPersonalComzocuatroDTO.ServicioExperiencia;

                    cmd.Parameters.Add("@EspecializacionProfesional", SqlDbType.Decimal);
                    cmd.Parameters["@EspecializacionProfesional"].Value = evaluacionAlistPersonalComzocuatroDTO.EspecializacionProfesional;

                    cmd.Parameters.Add("@CursoProfesionalRequerido", SqlDbType.Decimal);
                    cmd.Parameters["@CursoProfesionalRequerido"].Value = evaluacionAlistPersonalComzocuatroDTO.CursoProfesionalRequerido;

                    cmd.Parameters.Add("@PuntajeTotalPersonal", SqlDbType.Decimal);
                    cmd.Parameters["@PuntajeTotalPersonal"].Value = evaluacionAlistPersonalComzocuatroDTO.PuntajeTotalPersonal;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionAlistPersonalComzocuatroDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistPersonalComzocuatroDTO.UsuarioIngresoRegistro;

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

        public EvaluacionAlistPersonalComzocuatroDTO BuscarFormato(int Codigo)
        {
            EvaluacionAlistPersonalComzocuatroDTO evaluacionAlistPersonalComzocuatroDTO = new EvaluacionAlistPersonalComzocuatroDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComzocuatroEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        evaluacionAlistPersonalComzocuatroDTO.EvaluacionAlistamientoPersonalId = Convert.ToInt32(dr["EvaluacionAlistamientoPersonalId"]);
                        evaluacionAlistPersonalComzocuatroDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        evaluacionAlistPersonalComzocuatroDTO.FechaEvaluacion = Convert.ToDateTime(dr["FechaEvaluacion"]).ToString("yyy-MM-dd");
                        evaluacionAlistPersonalComzocuatroDTO.DNIPersonal = Convert.ToInt32(dr["DNIPersonal"]);
                        evaluacionAlistPersonalComzocuatroDTO.CIPPersonal = Convert.ToInt32(dr["CIPPersonal"]);
                        evaluacionAlistPersonalComzocuatroDTO.CargoPersonal = dr["CargoPersonal"].ToString();
                        evaluacionAlistPersonalComzocuatroDTO.GradoPersonalMilitarEsperado = Convert.ToInt32(dr["GradoPersonalMilitarEsperado"]);
                        evaluacionAlistPersonalComzocuatroDTO.EspecialidadGenericaEsperado = Convert.ToInt32(dr["EspecialidadGenericaEsperado"]);
                        evaluacionAlistPersonalComzocuatroDTO.GradoPersonalMilitarActual = Convert.ToInt32(dr["GradoPersonalMilitarActual"]);
                        evaluacionAlistPersonalComzocuatroDTO.EspecialidadGenericaActual = Convert.ToInt32(dr["EspecialidadGenericaActual"]);
                        evaluacionAlistPersonalComzocuatroDTO.GradoJerarquico = Convert.ToDecimal(dr["GradoJerarquico"]);
                        evaluacionAlistPersonalComzocuatroDTO.ServicioExperiencia = Convert.ToDecimal(dr["ServicioExperiencia"]);
                        evaluacionAlistPersonalComzocuatroDTO.EspecializacionProfesional = Convert.ToDecimal(dr["EspecializacionProfesional"]);
                        evaluacionAlistPersonalComzocuatroDTO.CursoProfesionalRequerido = Convert.ToDecimal(dr["CursoProfesionalRequerido"]);
                        evaluacionAlistPersonalComzocuatroDTO.PuntajeTotalPersonal = Convert.ToDecimal(dr["PuntajeTotalPersonal"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionAlistPersonalComzocuatroDTO;
        }

        public string ActualizaFormato(EvaluacionAlistPersonalComzocuatroDTO evaluacionAlistPersonalComzocuatroDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComzocuatroActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = evaluacionAlistPersonalComzocuatroDTO.EvaluacionAlistamientoPersonalId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = evaluacionAlistPersonalComzocuatroDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@FechaEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaEvaluacion"].Value = evaluacionAlistPersonalComzocuatroDTO.FechaEvaluacion;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.Int);
                    cmd.Parameters["@DNIPersonal"].Value = evaluacionAlistPersonalComzocuatroDTO.DNIPersonal;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.Int);
                    cmd.Parameters["@CIPPersonal"].Value = evaluacionAlistPersonalComzocuatroDTO.CIPPersonal;

                    cmd.Parameters.Add("@CargoPersonal", SqlDbType.VarChar,20);
                    cmd.Parameters["@CargoPersonal"].Value = evaluacionAlistPersonalComzocuatroDTO.CargoPersonal;

                    cmd.Parameters.Add("@GradoPersonalMilitarEsperado", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarEsperado"].Value = evaluacionAlistPersonalComzocuatroDTO.GradoPersonalMilitarEsperado;

                    cmd.Parameters.Add("@EspecialidadGenericaEsperado", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaEsperado"].Value = evaluacionAlistPersonalComzocuatroDTO.EspecialidadGenericaEsperado;

                    cmd.Parameters.Add("@GradoPersonalMilitarActual", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarActual"].Value = evaluacionAlistPersonalComzocuatroDTO.GradoPersonalMilitarActual;

                    cmd.Parameters.Add("@EspecialidadGenericaActual", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaActual"].Value = evaluacionAlistPersonalComzocuatroDTO.EspecialidadGenericaActual;

                    cmd.Parameters.Add("@GradoJerarquico", SqlDbType.Decimal);
                    cmd.Parameters["@GradoJerarquico"].Value = evaluacionAlistPersonalComzocuatroDTO.GradoJerarquico;

                    cmd.Parameters.Add("@ServicioExperiencia", SqlDbType.Decimal);
                    cmd.Parameters["@ServicioExperiencia"].Value = evaluacionAlistPersonalComzocuatroDTO.ServicioExperiencia;

                    cmd.Parameters.Add("@EspecializacionProfesional", SqlDbType.Decimal);
                    cmd.Parameters["@EspecializacionProfesional"].Value = evaluacionAlistPersonalComzocuatroDTO.EspecializacionProfesional;

                    cmd.Parameters.Add("@CursoProfesionalRequerido", SqlDbType.Decimal);
                    cmd.Parameters["@CursoProfesionalRequerido"].Value = evaluacionAlistPersonalComzocuatroDTO.CursoProfesionalRequerido;

                    cmd.Parameters.Add("@PuntajeTotalPersonal", SqlDbType.Decimal);
                    cmd.Parameters["@PuntajeTotalPersonal"].Value = evaluacionAlistPersonalComzocuatroDTO.PuntajeTotalPersonal;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistPersonalComzocuatroDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EvaluacionAlistPersonalComzocuatroDTO evaluacionAlistPersonalComzocuatroDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComzocuatroEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalId"].Value = evaluacionAlistPersonalComzocuatroDTO.EvaluacionAlistamientoPersonalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionAlistPersonalComzocuatroDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EvaluacionAlistamientoPersonalComzocuatroRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionAlistamientoPersonalComzocuatro", SqlDbType.Structured);
                    cmd.Parameters["@EvaluacionAlistamientoPersonalComzocuatro"].TypeName = "Formato.EvaluacionAlistamientoPersonalComzocuatro";
                    cmd.Parameters["@EvaluacionAlistamientoPersonalComzocuatro"].Value = datos;

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
