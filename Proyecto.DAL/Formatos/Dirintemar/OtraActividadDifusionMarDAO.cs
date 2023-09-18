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
    public class OtraActividadDifusionMarDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<OtraActividadDifusionMarDTO> ObtenerLista()
        {
            List<OtraActividadDifusionMarDTO> lista = new List<OtraActividadDifusionMarDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_OtraActividadDifusionMarListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new OtraActividadDifusionMarDTO()
                        {
                            OtraActDifusionMarId = Convert.ToInt32(dr["OtraActDifusionMarId"]),
                            DescTipoActividadDifusion = dr["DescTipoActividadDifusion"].ToString(),
                            NombreOtraActDifusionMar = dr["NombreOtraActDifusionMar"].ToString(),
                            AreaOtraActDifusionMar = dr["AreaOtraActDifusionMar"].ToString(),
                            ResponsableOtraActDifusionMar = dr["ResponsableOtraActDifusionMar"].ToString(),
                            InicioOtraActDifusionMar = (dr["InicioOtraActDifusionMar"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            TerminoOtraActDifusionMar = (dr["TerminoOtraActDifusionMar"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            LugarOtraActDifusionMar = dr["LugarOtraActDifusionMar"].ToString(),
                            DescDirigidoA = dr["DescDirigidoA"].ToString(),
                            QParticipanteOtraActDifusionMar = Convert.ToInt32(dr["QParticipanteOtraActDifusionMar"]),
                            QParticipanteEncuestaOtra = Convert.ToInt32(dr["QParticipanteEncuestaOtra"]),
                            QPreguntaEncuestaOtraOBS = Convert.ToInt32(dr["QPreguntaEncuestaOtraOBS"]),
                            RptaCorrectaEncuentaOtra = Convert.ToInt32(dr["RptaCorrectaEncuentaOtra"]),
                            RptaIncorrectaEncuentaOtra = Convert.ToInt32(dr["RptaIncorrectaEncuentaOtra"]),
                            PorcentRptaCorrectaEncuentaOtra = Convert.ToInt32(dr["PorcentRptaCorrectaEncuentaOtra"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(OtraActividadDifusionMarDTO otraActividadDifusionMarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_OtraActividadDifusionMarRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoActividadDifusionId", SqlDbType.Int);
                    cmd.Parameters["@TipoActividadDifusionId"].Value = otraActividadDifusionMarDTO.TipoActividadDifusionId;

                    cmd.Parameters.Add("@NombreOtraActDifusionMar", SqlDbType.VarChar,80);
                    cmd.Parameters["@NombreOtraActDifusionMar"].Value = otraActividadDifusionMarDTO.NombreOtraActDifusionMar;

                    cmd.Parameters.Add("@AreaOtraActDifusionMar", SqlDbType.VarChar,50);
                    cmd.Parameters["@AreaOtraActDifusionMar"].Value = otraActividadDifusionMarDTO.AreaOtraActDifusionMar;

                    cmd.Parameters.Add("@ResponsableOtraActDifusionMar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@ResponsableOtraActDifusionMar"].Value = otraActividadDifusionMarDTO.ResponsableOtraActDifusionMar;

                    cmd.Parameters.Add("@InicioOtraActDifusionMar", SqlDbType.Date);
                    cmd.Parameters["@InicioOtraActDifusionMar"].Value = otraActividadDifusionMarDTO.InicioOtraActDifusionMar;

                    cmd.Parameters.Add("@TerminoOtraActDifusionMar", SqlDbType.Date);
                    cmd.Parameters["@TerminoOtraActDifusionMar"].Value = otraActividadDifusionMarDTO.TerminoOtraActDifusionMar;

                    cmd.Parameters.Add("@LugarOtraActDifusionMar", SqlDbType.VarChar,20);
                    cmd.Parameters["@LugarOtraActDifusionMar"].Value = otraActividadDifusionMarDTO.LugarOtraActDifusionMar;

                    cmd.Parameters.Add("@DirigidoAId", SqlDbType.Int);
                    cmd.Parameters["@DirigidoAId"].Value = otraActividadDifusionMarDTO.DirigidoAId;

                    cmd.Parameters.Add("@QParticipanteOtraActDifusionMar", SqlDbType.Int);
                    cmd.Parameters["@QParticipanteOtraActDifusionMar"].Value = otraActividadDifusionMarDTO.QParticipanteOtraActDifusionMar;

                    cmd.Parameters.Add("@QParticipanteEncuestaOtra", SqlDbType.Int);
                    cmd.Parameters["@QParticipanteEncuestaOtra"].Value = otraActividadDifusionMarDTO.QParticipanteEncuestaOtra;

                    cmd.Parameters.Add("@QPreguntaEncuestaOtraOBS", SqlDbType.Int);
                    cmd.Parameters["@QPreguntaEncuestaOtraOBS"].Value = otraActividadDifusionMarDTO.QPreguntaEncuestaOtraOBS;

                    cmd.Parameters.Add("@RptaCorrectaEncuentaOtra", SqlDbType.Int);
                    cmd.Parameters["@RptaCorrectaEncuentaOtra"].Value = otraActividadDifusionMarDTO.RptaCorrectaEncuentaOtra;

                    cmd.Parameters.Add("@RptaIncorrectaEncuentaOtra", SqlDbType.Int);
                    cmd.Parameters["@RptaIncorrectaEncuentaOtra"].Value = otraActividadDifusionMarDTO.RptaIncorrectaEncuentaOtra;

                    cmd.Parameters.Add("@PorcentRptaCorrectaEncuentaOtra", SqlDbType.Int);
                    cmd.Parameters["@PorcentRptaCorrectaEncuentaOtra"].Value = otraActividadDifusionMarDTO.PorcentRptaCorrectaEncuentaOtra;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = otraActividadDifusionMarDTO.UsuarioIngresoRegistro;

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

        public OtraActividadDifusionMarDTO BuscarFormato(int Codigo)
        {
            OtraActividadDifusionMarDTO otraActividadDifusionMarDTO = new OtraActividadDifusionMarDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_OtraActividadDifusionMarEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OtraActDifusionMarId", SqlDbType.Int);
                    cmd.Parameters["@OtraActDifusionMarId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        otraActividadDifusionMarDTO.OtraActDifusionMarId = Convert.ToInt32(dr["OtraActDifusionMarId"]);
                        otraActividadDifusionMarDTO.TipoActividadDifusionId = Convert.ToInt32(dr["TipoActividadDifusionId"]);
                        otraActividadDifusionMarDTO.NombreOtraActDifusionMar = dr["NombreOtraActDifusionMar"].ToString();
                        otraActividadDifusionMarDTO.AreaOtraActDifusionMar = dr["AreaOtraActDifusionMar"].ToString();
                        otraActividadDifusionMarDTO.ResponsableOtraActDifusionMar = dr["ResponsableOtraActDifusionMar"].ToString();
                        otraActividadDifusionMarDTO.InicioOtraActDifusionMar = Convert.ToDateTime(dr["InicioOtraActDifusionMar"]).ToString("yyy-MM-dd");
                        otraActividadDifusionMarDTO.TerminoOtraActDifusionMar = Convert.ToDateTime(dr["TerminoOtraActDifusionMar"]).ToString("yyy-MM-dd");
                        otraActividadDifusionMarDTO.LugarOtraActDifusionMar = dr["LugarOtraActDifusionMar"].ToString();
                        otraActividadDifusionMarDTO.DirigidoAId = Convert.ToInt32(dr["DirigidoAId"]);
                        otraActividadDifusionMarDTO.QParticipanteOtraActDifusionMar = Convert.ToInt32(dr["QParticipanteOtraActDifusionMar"]);
                        otraActividadDifusionMarDTO.QParticipanteEncuestaOtra = Convert.ToInt32(dr["QParticipanteEncuestaOtra"]);
                        otraActividadDifusionMarDTO.QPreguntaEncuestaOtraOBS = Convert.ToInt32(dr["QPreguntaEncuestaOtraOBS"]);
                        otraActividadDifusionMarDTO.RptaCorrectaEncuentaOtra = Convert.ToInt32(dr["RptaCorrectaEncuentaOtra"]);
                        otraActividadDifusionMarDTO.RptaIncorrectaEncuentaOtra = Convert.ToInt32(dr["RptaIncorrectaEncuentaOtra"]);
                        otraActividadDifusionMarDTO.PorcentRptaCorrectaEncuentaOtra = Convert.ToInt32(dr["PorcentRptaCorrectaEncuentaOtra"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return otraActividadDifusionMarDTO;
        }

        public string ActualizaFormato(OtraActividadDifusionMarDTO otraActividadDifusionMarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_OtraActividadDifusionMarActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OtraActDifusionMarId", SqlDbType.Int);
                    cmd.Parameters["@OtraActDifusionMarId"].Value = otraActividadDifusionMarDTO.OtraActDifusionMarId;

                    cmd.Parameters.Add("@TipoActividadDifusionId", SqlDbType.Int);
                    cmd.Parameters["@TipoActividadDifusionId"].Value = otraActividadDifusionMarDTO.TipoActividadDifusionId;

                    cmd.Parameters.Add("@NombreOtraActDifusionMar", SqlDbType.VarChar, 80);
                    cmd.Parameters["@NombreOtraActDifusionMar"].Value = otraActividadDifusionMarDTO.NombreOtraActDifusionMar;

                    cmd.Parameters.Add("@AreaOtraActDifusionMar", SqlDbType.VarChar, 50);
                    cmd.Parameters["@AreaOtraActDifusionMar"].Value = otraActividadDifusionMarDTO.AreaOtraActDifusionMar;

                    cmd.Parameters.Add("@ResponsableOtraActDifusionMar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@ResponsableOtraActDifusionMar"].Value = otraActividadDifusionMarDTO.ResponsableOtraActDifusionMar;

                    cmd.Parameters.Add("@InicioOtraActDifusionMar", SqlDbType.Date);
                    cmd.Parameters["@InicioOtraActDifusionMar"].Value = otraActividadDifusionMarDTO.InicioOtraActDifusionMar;

                    cmd.Parameters.Add("@TerminoOtraActDifusionMar", SqlDbType.Date);
                    cmd.Parameters["@TerminoOtraActDifusionMar"].Value = otraActividadDifusionMarDTO.TerminoOtraActDifusionMar;

                    cmd.Parameters.Add("@LugarOtraActDifusionMar", SqlDbType.VarChar,60);
                    cmd.Parameters["@LugarOtraActDifusionMar"].Value = otraActividadDifusionMarDTO.LugarOtraActDifusionMar;

                    cmd.Parameters.Add("@DirigidoAId", SqlDbType.Int);
                    cmd.Parameters["@DirigidoAId"].Value = otraActividadDifusionMarDTO.DirigidoAId;

                    cmd.Parameters.Add("@QParticipanteOtraActDifusionMar", SqlDbType.Int);
                    cmd.Parameters["@QParticipanteOtraActDifusionMar"].Value = otraActividadDifusionMarDTO.QParticipanteOtraActDifusionMar;

                    cmd.Parameters.Add("@QParticipanteEncuestaOtra", SqlDbType.Int);
                    cmd.Parameters["@QParticipanteEncuestaOtra"].Value = otraActividadDifusionMarDTO.QParticipanteEncuestaOtra;

                    cmd.Parameters.Add("@QPreguntaEncuestaOtraOBS", SqlDbType.Int);
                    cmd.Parameters["@QPreguntaEncuestaOtraOBS"].Value = otraActividadDifusionMarDTO.QPreguntaEncuestaOtraOBS;

                    cmd.Parameters.Add("@RptaCorrectaEncuentaOtra", SqlDbType.Int);
                    cmd.Parameters["@RptaCorrectaEncuentaOtra"].Value = otraActividadDifusionMarDTO.RptaCorrectaEncuentaOtra;

                    cmd.Parameters.Add("@RptaIncorrectaEncuentaOtra", SqlDbType.Int);
                    cmd.Parameters["@RptaIncorrectaEncuentaOtra"].Value = otraActividadDifusionMarDTO.RptaIncorrectaEncuentaOtra;

                    cmd.Parameters.Add("@PorcentRptaCorrectaEncuentaOtra", SqlDbType.Int);
                    cmd.Parameters["@PorcentRptaCorrectaEncuentaOtra"].Value = otraActividadDifusionMarDTO.PorcentRptaCorrectaEncuentaOtra;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = otraActividadDifusionMarDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(OtraActividadDifusionMarDTO otraActividadDifusionMarDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_OtraActividadDifusionMarEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OtraActDifusionMarId", SqlDbType.Int);
                    cmd.Parameters["@OtraActDifusionMarId"].Value = otraActividadDifusionMarDTO.OtraActDifusionMarId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = otraActividadDifusionMarDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_OtraActividadDifusionMarRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OtraActividadDifusionMar", SqlDbType.Structured);
                    cmd.Parameters["@OtraActividadDifusionMar"].TypeName = "Formato.OtraActividadDifusionMar";
                    cmd.Parameters["@OtraActividadDifusionMar"].Value = datos;

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
