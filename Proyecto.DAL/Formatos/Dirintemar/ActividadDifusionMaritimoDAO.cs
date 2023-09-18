using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirintemar
{
    public class ActividadDifusionMaritimoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ActividadDifusionMaritimoDTO> ObtenerLista()
        {
            List<ActividadDifusionMaritimoDTO> lista = new List<ActividadDifusionMaritimoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ActividadDifusionMaritimoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ActividadDifusionMaritimoDTO()
                        {
                            ActividadDifusionMaritimoId = Convert.ToInt32(dr["ActividadDifusionMaritimoId"]),
                            DescTipoActividadDifusion = dr["DescTipoActividadDifusion"].ToString(),
                            NombreActDifusionMar = dr["NombreActDifusionMar"].ToString(),
                            AreaActDifusionMar = dr["AreaActDifusionMar"].ToString(),
                            ResponsableActDifusionMar = dr["ResponsableActDifusionMar"].ToString(),
                            InicioActDifusionMar = (dr["InicioActDifusionMar"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            TerminoActDifusionMar = (dr["TerminoActDifusionMar"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            LugarActDifusionMar = dr["LugarActDifusionMar"].ToString(),
                            QParticipanteActDifusionMar = Convert.ToInt32(dr["QParticipanteActDifusionMar"]),
                            QParticipanteEncuesta = Convert.ToInt32(dr["QParticipanteEncuesta"]),
                            QPreguntaEncuestaOBS = Convert.ToInt32(dr["QPreguntaEncuestaOBS"]),
                            RptaCorrectasEncuenta = Convert.ToInt32(dr["RptaCorrectasEncuenta"]),
                            RptaIncorrectaEncuenta = Convert.ToInt32(dr["RptaIncorrectaEncuenta"]),
                            PorcentRptaCorrectaEncuenta = Convert.ToInt32(dr["PorcentRptaCorrectaEncuenta"]),
                        });

                    }

                }
            }
            return lista;
        }

        public string AgregarRegistro(ActividadDifusionMaritimoDTO actividadDifusionMaritimoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ActividadDifusionMaritimoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoActividadDifusionId", SqlDbType.Int);
                    cmd.Parameters["@TipoActividadDifusionId"].Value = actividadDifusionMaritimoDTO.TipoActividadDifusionId;

                    cmd.Parameters.Add("@NombreActDifusionMar", SqlDbType.VarChar,80);
                    cmd.Parameters["@NombreActDifusionMar"].Value = actividadDifusionMaritimoDTO.NombreActDifusionMar;

                    cmd.Parameters.Add("@AreaActDifusionMar", SqlDbType.VarChar,80);
                    cmd.Parameters["@AreaActDifusionMar"].Value = actividadDifusionMaritimoDTO.AreaActDifusionMar;

                    cmd.Parameters.Add("@ResponsableActDifusionMar", SqlDbType.VarChar, 60);
                    cmd.Parameters["@ResponsableActDifusionMar"].Value = actividadDifusionMaritimoDTO.ResponsableActDifusionMar;

                    cmd.Parameters.Add("@InicioActDifusionMar", SqlDbType.Date);
                    cmd.Parameters["@InicioActDifusionMar"].Value = actividadDifusionMaritimoDTO.InicioActDifusionMar;

                    cmd.Parameters.Add("@TerminoActDifusionMar", SqlDbType.Date);
                    cmd.Parameters["@TerminoActDifusionMar"].Value = actividadDifusionMaritimoDTO.TerminoActDifusionMar;

                    cmd.Parameters.Add("@LugarActDifusionMar", SqlDbType.VarChar, 60);
                    cmd.Parameters["@LugarActDifusionMar"].Value = actividadDifusionMaritimoDTO.LugarActDifusionMar;

                    cmd.Parameters.Add("@QParticipanteActDifusionMar", SqlDbType.Int);
                    cmd.Parameters["@QParticipanteActDifusionMar"].Value = actividadDifusionMaritimoDTO.QParticipanteActDifusionMar;

                    cmd.Parameters.Add("@QParticipanteEncuesta", SqlDbType.Int);
                    cmd.Parameters["@QParticipanteEncuesta"].Value = actividadDifusionMaritimoDTO.QParticipanteEncuesta;

                    cmd.Parameters.Add("@QPreguntaEncuestaOBS", SqlDbType.Int);
                    cmd.Parameters["@QPreguntaEncuestaOBS"].Value = actividadDifusionMaritimoDTO.QPreguntaEncuestaOBS;

                    cmd.Parameters.Add("@RptaCorrectasEncuenta", SqlDbType.Int);
                    cmd.Parameters["@RptaCorrectasEncuenta"].Value = actividadDifusionMaritimoDTO.RptaCorrectasEncuenta;

                    cmd.Parameters.Add("@RptaIncorrectaEncuenta", SqlDbType.Int);
                    cmd.Parameters["@RptaIncorrectaEncuenta"].Value = actividadDifusionMaritimoDTO.RptaIncorrectaEncuenta;

                    cmd.Parameters.Add("@PorcentRptaCorrectaEncuenta", SqlDbType.Int);
                    cmd.Parameters["@PorcentRptaCorrectaEncuenta"].Value = actividadDifusionMaritimoDTO.PorcentRptaCorrectaEncuenta;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actividadDifusionMaritimoDTO.UsuarioIngresoRegistro;

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

        public ActividadDifusionMaritimoDTO BuscarFormato(int Codigo)
        {
            ActividadDifusionMaritimoDTO actividadDifusionMaritimoDTO = new ActividadDifusionMaritimoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ActividadDifusionMaritimoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadDifusionMaritimoId", SqlDbType.Int);
                    cmd.Parameters["@ActividadDifusionMaritimoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        actividadDifusionMaritimoDTO.ActividadDifusionMaritimoId = Convert.ToInt32(dr["ActividadDifusionMaritimoId"]);
                        actividadDifusionMaritimoDTO.TipoActividadDifusionId = Convert.ToInt32(dr["TipoActividadDifusionId"]);
                        actividadDifusionMaritimoDTO.NombreActDifusionMar = dr["NombreActDifusionMar"].ToString();
                        actividadDifusionMaritimoDTO.AreaActDifusionMar = dr["AreaActDifusionMar"].ToString();
                        actividadDifusionMaritimoDTO.ResponsableActDifusionMar = dr["ResponsableActDifusionMar"].ToString();
                        actividadDifusionMaritimoDTO.InicioActDifusionMar = Convert.ToDateTime(dr["InicioActDifusionMar"]).ToString("yyy-MM-dd");
                        actividadDifusionMaritimoDTO.TerminoActDifusionMar = Convert.ToDateTime(dr["TerminoActDifusionMar"]).ToString("yyy-MM-dd");
                        actividadDifusionMaritimoDTO.LugarActDifusionMar = dr["LugarActDifusionMar"].ToString();
                        actividadDifusionMaritimoDTO.QParticipanteActDifusionMar = Convert.ToInt32(dr["QParticipanteActDifusionMar"]);
                        actividadDifusionMaritimoDTO.QParticipanteEncuesta = Convert.ToInt32(dr["QParticipanteEncuesta"]);
                        actividadDifusionMaritimoDTO.QPreguntaEncuestaOBS = Convert.ToInt32(dr["QPreguntaEncuestaOBS"]);
                        actividadDifusionMaritimoDTO.RptaCorrectasEncuenta = Convert.ToInt32(dr["RptaCorrectasEncuenta"]);
                        actividadDifusionMaritimoDTO.RptaIncorrectaEncuenta = Convert.ToInt32(dr["RptaIncorrectaEncuenta"]);
                        actividadDifusionMaritimoDTO.PorcentRptaCorrectaEncuenta = Convert.ToInt32(dr["PorcentRptaCorrectaEncuenta"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return actividadDifusionMaritimoDTO;
        }

        public string ActualizaFormato(ActividadDifusionMaritimoDTO actividadDifusionMaritimoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ActividadDifusionMaritimoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadDifusionMaritimoId", SqlDbType.Int);
                    cmd.Parameters["@ActividadDifusionMaritimoId"].Value = actividadDifusionMaritimoDTO.ActividadDifusionMaritimoId;

                    cmd.Parameters.Add("@TipoActividadDifusionId", SqlDbType.Int);
                    cmd.Parameters["@TipoActividadDifusionId"].Value = actividadDifusionMaritimoDTO.TipoActividadDifusionId;

                    cmd.Parameters.Add("@NombreActDifusionMar", SqlDbType.VarChar, 80);
                    cmd.Parameters["@NombreActDifusionMar"].Value = actividadDifusionMaritimoDTO.NombreActDifusionMar;

                    cmd.Parameters.Add("@AreaActDifusionMar", SqlDbType.VarChar, 80);
                    cmd.Parameters["@AreaActDifusionMar"].Value = actividadDifusionMaritimoDTO.AreaActDifusionMar;

                    cmd.Parameters.Add("@ResponsableActDifusionMar", SqlDbType.VarChar, 60);
                    cmd.Parameters["@ResponsableActDifusionMar"].Value = actividadDifusionMaritimoDTO.ResponsableActDifusionMar;

                    cmd.Parameters.Add("@InicioActDifusionMar", SqlDbType.Date);
                    cmd.Parameters["@InicioActDifusionMar"].Value = actividadDifusionMaritimoDTO.InicioActDifusionMar;

                    cmd.Parameters.Add("@TerminoActDifusionMar", SqlDbType.Date);
                    cmd.Parameters["@TerminoActDifusionMar"].Value = actividadDifusionMaritimoDTO.TerminoActDifusionMar;

                    cmd.Parameters.Add("@LugarActDifusionMar", SqlDbType.VarChar, 60);
                    cmd.Parameters["@LugarActDifusionMar"].Value = actividadDifusionMaritimoDTO.LugarActDifusionMar;

                    cmd.Parameters.Add("@QParticipanteActDifusionMar", SqlDbType.Int);
                    cmd.Parameters["@QParticipanteActDifusionMar"].Value = actividadDifusionMaritimoDTO.QParticipanteActDifusionMar;

                    cmd.Parameters.Add("@QParticipanteEncuesta", SqlDbType.Int);
                    cmd.Parameters["@QParticipanteEncuesta"].Value = actividadDifusionMaritimoDTO.QParticipanteEncuesta;

                    cmd.Parameters.Add("@QPreguntaEncuestaOBS", SqlDbType.Int);
                    cmd.Parameters["@QPreguntaEncuestaOBS"].Value = actividadDifusionMaritimoDTO.QPreguntaEncuestaOBS;

                    cmd.Parameters.Add("@RptaCorrectasEncuenta", SqlDbType.Int);
                    cmd.Parameters["@RptaCorrectasEncuenta"].Value = actividadDifusionMaritimoDTO.RptaCorrectasEncuenta;

                    cmd.Parameters.Add("@RptaIncorrectaEncuenta", SqlDbType.Int);
                    cmd.Parameters["@RptaIncorrectaEncuenta"].Value = actividadDifusionMaritimoDTO.RptaIncorrectaEncuenta;

                    cmd.Parameters.Add("@PorcentRptaCorrectaEncuenta", SqlDbType.Int);
                    cmd.Parameters["@PorcentRptaCorrectaEncuenta"].Value = actividadDifusionMaritimoDTO.PorcentRptaCorrectaEncuenta;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actividadDifusionMaritimoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ActividadDifusionMaritimoDTO actividadDifusionMaritimoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ActividadDifusionMaritimoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadDifusionMaritimoId", SqlDbType.Int);
                    cmd.Parameters["@ActividadDifusionMaritimoId"].Value = actividadDifusionMaritimoDTO.ActividadDifusionMaritimoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actividadDifusionMaritimoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ActividadDifusionMaritimoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadDifusionMaritimo", SqlDbType.Structured);
                    cmd.Parameters["@ActividadDifusionMaritimo"].TypeName = "Formato.ActividadDifusionMaritimo";
                    cmd.Parameters["@ActividadDifusionMaritimo"].Value = datos;

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
