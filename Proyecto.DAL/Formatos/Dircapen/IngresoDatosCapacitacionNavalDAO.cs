using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dircapen;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dircapen
{
    public class IngresoDatosCapacitacionNavalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<IngresoDatosCapacitacionNavalDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<IngresoDatosCapacitacionNavalDTO> lista = new List<IngresoDatosCapacitacionNavalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_IngresoDatosCapacitacionNavalListar", conexion);
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
                        lista.Add(new IngresoDatosCapacitacionNavalDTO()
                        {
                            IngresoDatoCapacitacionNavalId = Convert.ToInt32(dr["IngresoDatoCapacitacionNavalId"]),
                            CIPPersonal = dr["CIPPersonal"].ToString(),
                            DNIPersonal = dr["DNIPersonal"].ToString(),
                            SexoPersonal = dr["SexoPersonal"].ToString(),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            DescEspecialidad = dr["DescEspecialidad"].ToString(),
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            DescProgramaEspecializacionEspecifico = dr["DescProgramaEspecializacionEspecifico"].ToString(),
                            DescProgramaEspecializacionGrupo = dr["DescProgramaEspecializacionGrupo"].ToString(),
                            FechaInicio = (dr["FechaInicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTemino = (dr["FechaTemino"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescTipoModalidad = dr["DescTipoModalidad"].ToString(),
                            ConcluyoProgramaEstudios = dr["ConcluyoProgramaEstudios"].ToString(),
                            TotalCredito = Convert.ToInt32(dr["TotalCredito"]),
                            MotivosNoConcluir = dr["MotivosNoConcluir"].ToString(),
                            CalificacionFinalObtenida = Convert.ToDecimal(dr["CalificacionFinalObtenida"]),
                            NombreDiploma = dr["NombreDiploma"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(IngresoDatosCapacitacionNavalDTO ingresoDatosCapacitacionNavalDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_IngresoDatosCapacitacionNavalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.VarChar,8);
                    cmd.Parameters["@CIPPersonal"].Value = ingresoDatosCapacitacionNavalDTO.CIPPersonal;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPersonal"].Value = ingresoDatosCapacitacionNavalDTO.DNIPersonal;

                    cmd.Parameters.Add("@SexoPersonal", SqlDbType.VarChar);
                    cmd.Parameters["@SexoPersonal"].Value = ingresoDatosCapacitacionNavalDTO.SexoPersonal;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = ingresoDatosCapacitacionNavalDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = ingresoDatosCapacitacionNavalDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.Int);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = ingresoDatosCapacitacionNavalDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = ingresoDatosCapacitacionNavalDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = ingresoDatosCapacitacionNavalDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoProgramaEspecializacionEspecifico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProgramaEspecializacionEspecifico"].Value = ingresoDatosCapacitacionNavalDTO.CodigoProgramaEspecializacionEspecifico;

                    cmd.Parameters.Add("@CodigoProgramaEspecializacionGrupo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProgramaEspecializacionGrupo"].Value = ingresoDatosCapacitacionNavalDTO.CodigoProgramaEspecializacionGrupo;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = ingresoDatosCapacitacionNavalDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTemino", SqlDbType.Date);
                    cmd.Parameters["@FechaTemino"].Value = ingresoDatosCapacitacionNavalDTO.FechaTemino;

                    cmd.Parameters.Add("@CodigoTipoModalidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoModalidad"].Value = ingresoDatosCapacitacionNavalDTO.CodigoTipoModalidad;

                    cmd.Parameters.Add("@ConcluyoProgramaEstudios", SqlDbType.NChar,1);
                    cmd.Parameters["@ConcluyoProgramaEstudios"].Value = ingresoDatosCapacitacionNavalDTO.ConcluyoProgramaEstudios;

                    cmd.Parameters.Add("@TotalCredito", SqlDbType.Int);
                    cmd.Parameters["@TotalCredito"].Value = ingresoDatosCapacitacionNavalDTO.TotalCredito;

                    cmd.Parameters.Add("@MotivosNoConcluir", SqlDbType.VarChar, 300);
                    cmd.Parameters["@MotivosNoConcluir"].Value = ingresoDatosCapacitacionNavalDTO.MotivosNoConcluir;

                    cmd.Parameters.Add("@CalificacionFinalObtenida", SqlDbType.Decimal);
                    cmd.Parameters["@CalificacionFinalObtenida"].Value = ingresoDatosCapacitacionNavalDTO.CalificacionFinalObtenida;

                    cmd.Parameters.Add("@NombreDiploma", SqlDbType.VarChar, 300);
                    cmd.Parameters["@NombreDiploma"].Value = ingresoDatosCapacitacionNavalDTO.NombreDiploma;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = ingresoDatosCapacitacionNavalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ingresoDatosCapacitacionNavalDTO.UsuarioIngresoRegistro;

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

        public IngresoDatosCapacitacionNavalDTO BuscarFormato(int Codigo)
        {
            IngresoDatosCapacitacionNavalDTO ingresoDatosCapacitacionNavalDTO = new IngresoDatosCapacitacionNavalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_IngresoDatosCapacitacionNavalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngresoDatoCapacitacionNavalId", SqlDbType.Int);
                    cmd.Parameters["@IngresoDatoCapacitacionNavalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        ingresoDatosCapacitacionNavalDTO.IngresoDatoCapacitacionNavalId = Convert.ToInt32(dr["IngresoDatoCapacitacionNavalId"]);
                        ingresoDatosCapacitacionNavalDTO.CIPPersonal = dr["CIPPersonal"].ToString();
                        ingresoDatosCapacitacionNavalDTO.DNIPersonal = dr["DNIPersonal"].ToString();
                        ingresoDatosCapacitacionNavalDTO.SexoPersonal = dr["SexoPersonal"].ToString();
                        ingresoDatosCapacitacionNavalDTO.CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar"].ToString();
                        ingresoDatosCapacitacionNavalDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        ingresoDatosCapacitacionNavalDTO.CodigoEspecialidadGenericaPersonal = dr["CodigoEspecialidadGenericaPersonal"].ToString();
                        ingresoDatosCapacitacionNavalDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        ingresoDatosCapacitacionNavalDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        ingresoDatosCapacitacionNavalDTO.CodigoProgramaEspecializacionEspecifico = dr["CodigoProgramaEspecializacionEspecifico"].ToString();
                        ingresoDatosCapacitacionNavalDTO.CodigoProgramaEspecializacionGrupo = dr["CodigoProgramaEspecializacionGrupo"].ToString();
                        ingresoDatosCapacitacionNavalDTO.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]).ToString("yyy-MM-dd");
                        ingresoDatosCapacitacionNavalDTO.FechaTemino = Convert.ToDateTime(dr["FechaTemino"]).ToString("yyy-MM-dd");
                        ingresoDatosCapacitacionNavalDTO.CodigoTipoModalidad = dr["CodigoTipoModalidad"].ToString();
                        ingresoDatosCapacitacionNavalDTO.ConcluyoProgramaEstudios = dr["ConcluyoProgramaEstudios"].ToString();
                        ingresoDatosCapacitacionNavalDTO.TotalCredito = Convert.ToInt32(dr["TotalCredito"]);
                        ingresoDatosCapacitacionNavalDTO.MotivosNoConcluir = dr["MotivosNoConcluir"].ToString();
                        ingresoDatosCapacitacionNavalDTO.CalificacionFinalObtenida = Convert.ToDecimal(dr["CalificacionFinalObtenida"]);
                        ingresoDatosCapacitacionNavalDTO.NombreDiploma = dr["NombreDiploma"].ToString(); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ingresoDatosCapacitacionNavalDTO;
        }

        public string ActualizaFormato(IngresoDatosCapacitacionNavalDTO ingresoDatosCapacitacionNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_IngresoDatosCapacitacionNavalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@IngresoDatoCapacitacionNavalId", SqlDbType.Int);
                    cmd.Parameters["@IngresoDatoCapacitacionNavalId"].Value = ingresoDatosCapacitacionNavalDTO.IngresoDatoCapacitacionNavalId;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIPPersonal"].Value = ingresoDatosCapacitacionNavalDTO.CIPPersonal;

                    cmd.Parameters.Add("@DNIPersonal", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIPersonal"].Value = ingresoDatosCapacitacionNavalDTO.DNIPersonal;

                    cmd.Parameters.Add("@SexoPersonal", SqlDbType.VarChar);
                    cmd.Parameters["@SexoPersonal"].Value = ingresoDatosCapacitacionNavalDTO.SexoPersonal;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = ingresoDatosCapacitacionNavalDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = ingresoDatosCapacitacionNavalDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.Int);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = ingresoDatosCapacitacionNavalDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = ingresoDatosCapacitacionNavalDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = ingresoDatosCapacitacionNavalDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoProgramaEspecializacionEspecifico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProgramaEspecializacionEspecifico"].Value = ingresoDatosCapacitacionNavalDTO.CodigoProgramaEspecializacionEspecifico;

                    cmd.Parameters.Add("@CodigoProgramaEspecializacionGrupo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProgramaEspecializacionGrupo"].Value = ingresoDatosCapacitacionNavalDTO.CodigoProgramaEspecializacionGrupo;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = ingresoDatosCapacitacionNavalDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTemino", SqlDbType.Date);
                    cmd.Parameters["@FechaTemino"].Value = ingresoDatosCapacitacionNavalDTO.FechaTemino;

                    cmd.Parameters.Add("@CodigoTipoModalidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoModalidad"].Value = ingresoDatosCapacitacionNavalDTO.CodigoTipoModalidad;

                    cmd.Parameters.Add("@ConcluyoProgramaEstudios", SqlDbType.NChar,1);
                    cmd.Parameters["@ConcluyoProgramaEstudios"].Value = ingresoDatosCapacitacionNavalDTO.ConcluyoProgramaEstudios;

                    cmd.Parameters.Add("@TotalCredito", SqlDbType.Int);
                    cmd.Parameters["@TotalCredito"].Value = ingresoDatosCapacitacionNavalDTO.TotalCredito;

                    cmd.Parameters.Add("@MotivosNoConcluir", SqlDbType.VarChar, 300);
                    cmd.Parameters["@MotivosNoConcluir"].Value = ingresoDatosCapacitacionNavalDTO.MotivosNoConcluir;

                    cmd.Parameters.Add("@CalificacionFinalObtenida", SqlDbType.Decimal);
                    cmd.Parameters["@CalificacionFinalObtenida"].Value = ingresoDatosCapacitacionNavalDTO.CalificacionFinalObtenida;

                    cmd.Parameters.Add("@NombreDiploma", SqlDbType.VarChar,300);
                    cmd.Parameters["@NombreDiploma"].Value = ingresoDatosCapacitacionNavalDTO.NombreDiploma;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ingresoDatosCapacitacionNavalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(IngresoDatosCapacitacionNavalDTO ingresoDatosCapacitacionNavalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_IngresoDatosCapacitacionNavalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngresoDatoCapacitacionNavalId", SqlDbType.Int);
                    cmd.Parameters["@IngresoDatoCapacitacionNavalId"].Value = ingresoDatosCapacitacionNavalDTO.IngresoDatoCapacitacionNavalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ingresoDatosCapacitacionNavalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(IngresoDatosCapacitacionNavalDTO ingresoDatosCapacitacionNavalDTO)
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
                    cmd.Parameters["@Formato"].Value = "IngresoDatoCapacitacionNaval";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = ingresoDatosCapacitacionNavalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ingresoDatosCapacitacionNavalDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_IngresoDatosCapacitacionNavalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngresoDatoCapacitacionNaval", SqlDbType.Structured);
                    cmd.Parameters["@IngresoDatoCapacitacionNaval"].TypeName = "Formato.IngresoDatoCapacitacionNaval";
                    cmd.Parameters["@IngresoDatoCapacitacionNaval"].Value = datos;

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
