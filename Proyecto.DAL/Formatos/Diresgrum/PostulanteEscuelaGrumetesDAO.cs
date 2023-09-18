using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diresgrum;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diresgrum
{
    public class PostulanteEscuelaGrumetesDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PostulanteEscuelaGrumetesDTO> ObtenerLista()
        {
            List<PostulanteEscuelaGrumetesDTO> lista = new List<PostulanteEscuelaGrumetesDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PostulanteEscuelaGrumetesListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PostulanteEscuelaGrumetesDTO()
                        {
                            PostulanteEscuelaGrumeteId = Convert.ToInt32(dr["PostulanteEscuelaGrumeteId"]),
                            DNIPostulanteEscuela = Convert.ToInt32(dr["DNIPostulanteEscuela"]),
                            SexoPostulanteEscuela = dr["SexoPostulanteEscuela"].ToString(),
                            LugarNacimiento = Convert.ToInt32(dr["LugarNacimiento"]),
                            FechaNacimiento = (dr["FechaNacimiento"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            LugarDomicilio = Convert.ToInt32(dr["LugarDomicilio"]),
                            LugarPresentacionPostulante = Convert.ToInt32(dr["LugarPresentacionPostulante"]),
                            ZonaNavalId = Convert.ToInt32(dr["ZonaNavalId"]),
                            GradoEstudioAlcanzadoId = Convert.ToInt32(dr["GradoEstudioAlcanzadoId"]),
                            GradoEstudioEspecifId = Convert.ToInt32(dr["GradoEstudioEspecifId"]),
                            NumeroContingenciaPostulante = Convert.ToInt32(dr["NumeroContingenciaPostulante"]),
                            ResultadoPostulacion = dr["ResultadoPostulacion"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(PostulanteEscuelaGrumetesDTO postulanteEscuelaGrumetesDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PostulanteEscuelaGrumetesRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@DNIPostulanteEscuela", SqlDbType.Int);
                    cmd.Parameters["@DNIPostulanteEscuela"].Value = postulanteEscuelaGrumetesDTO.DNIPostulanteEscuela;

                    cmd.Parameters.Add("@SexoPostulanteEscuela", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoPostulanteEscuela"].Value = postulanteEscuelaGrumetesDTO.SexoPostulanteEscuela;

                    cmd.Parameters.Add("@LugarNacimiento", SqlDbType.Int);
                    cmd.Parameters["@LugarNacimiento"].Value = postulanteEscuelaGrumetesDTO.LugarNacimiento;

                    cmd.Parameters.Add("@FechaNacimiento", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimiento"].Value = postulanteEscuelaGrumetesDTO.FechaNacimiento;

                    cmd.Parameters.Add("@LugarDomicilio", SqlDbType.Int);
                    cmd.Parameters["@LugarDomicilio"].Value = postulanteEscuelaGrumetesDTO.LugarDomicilio;

                    cmd.Parameters.Add("@LugarPresentacionPostulante", SqlDbType.Int);
                    cmd.Parameters["@LugarPresentacionPostulante"].Value = postulanteEscuelaGrumetesDTO.LugarPresentacionPostulante;

                    cmd.Parameters.Add("@ZonaNavalId", SqlDbType.Int);
                    cmd.Parameters["@ZonaNavalId"].Value = postulanteEscuelaGrumetesDTO.ZonaNavalId;

                    cmd.Parameters.Add("@GradoEstudioAlcanzadoId", SqlDbType.Int);
                    cmd.Parameters["@GradoEstudioAlcanzadoId"].Value = postulanteEscuelaGrumetesDTO.GradoEstudioAlcanzadoId;

                    cmd.Parameters.Add("@GradoEstudioEspecifId", SqlDbType.Int);
                    cmd.Parameters["@GradoEstudioEspecifId"].Value = postulanteEscuelaGrumetesDTO.GradoEstudioEspecifId;

                    cmd.Parameters.Add("@NumeroContingenciaPostulante", SqlDbType.Int);
                    cmd.Parameters["@NumeroContingenciaPostulante"].Value = postulanteEscuelaGrumetesDTO.NumeroContingenciaPostulante;

                    cmd.Parameters.Add("@ResultadoPostulacion", SqlDbType.VarChar,50);
                    cmd.Parameters["@ResultadoPostulacion"].Value = postulanteEscuelaGrumetesDTO.ResultadoPostulacion;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = postulanteEscuelaGrumetesDTO.UsuarioIngresoRegistro;

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

        public PostulanteEscuelaGrumetesDTO BuscarFormato(int Codigo)
        {
            PostulanteEscuelaGrumetesDTO postulanteEscuelaGrumetesDTO = new PostulanteEscuelaGrumetesDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PostulanteEscuelaGrumetesEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PostulanteEscuelaGrumeteId", SqlDbType.Int);
                    cmd.Parameters["@PostulanteEscuelaGrumeteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        postulanteEscuelaGrumetesDTO.PostulanteEscuelaGrumeteId = Convert.ToInt32(dr["PostulanteEscuelaGrumeteId"]);
                        postulanteEscuelaGrumetesDTO.DNIPostulanteEscuela = Convert.ToInt32(dr["DNIPostulanteEscuela"]);
                        postulanteEscuelaGrumetesDTO.SexoPostulanteEscuela = dr["SexoPostulanteEscuela"].ToString();
                        postulanteEscuelaGrumetesDTO.LugarNacimiento = Convert.ToInt32(dr["LugarNacimiento"]);
                        postulanteEscuelaGrumetesDTO.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]).ToString("yyy-MM-dd");
                        postulanteEscuelaGrumetesDTO.LugarDomicilio = Convert.ToInt32(dr["LugarDomicilio"]);
                        postulanteEscuelaGrumetesDTO.LugarPresentacionPostulante = Convert.ToInt32(dr["LugarPresentacionPostulante"]);
                        postulanteEscuelaGrumetesDTO.ZonaNavalId = Convert.ToInt32(dr["ZonaNavalId"]);
                        postulanteEscuelaGrumetesDTO.GradoEstudioAlcanzadoId = Convert.ToInt32(dr["GradoEstudioAlcanzadoId"]);
                        postulanteEscuelaGrumetesDTO.GradoEstudioEspecifId = Convert.ToInt32(dr["GradoEstudioEspecifId"]);
                        postulanteEscuelaGrumetesDTO.NumeroContingenciaPostulante = Convert.ToInt32(dr["NumeroContingenciaPostulante"]);
                        postulanteEscuelaGrumetesDTO.ResultadoPostulacion = dr["ResultadoPostulacion"].ToString(); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return postulanteEscuelaGrumetesDTO;
        }

        public string ActualizaFormato(PostulanteEscuelaGrumetesDTO postulanteEscuelaGrumetesDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PostulanteEscuelaGrumetesActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@PostulanteEscuelaGrumeteId", SqlDbType.Int);
                    cmd.Parameters["@PostulanteEscuelaGrumeteId"].Value = postulanteEscuelaGrumetesDTO.PostulanteEscuelaGrumeteId;

                    cmd.Parameters.Add("@DNIPostulanteEscuela", SqlDbType.Int);
                    cmd.Parameters["@DNIPostulanteEscuela"].Value = postulanteEscuelaGrumetesDTO.DNIPostulanteEscuela;

                    cmd.Parameters.Add("@SexoPostulanteEscuela", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoPostulanteEscuela"].Value = postulanteEscuelaGrumetesDTO.SexoPostulanteEscuela;

                    cmd.Parameters.Add("@LugarNacimiento", SqlDbType.Int);
                    cmd.Parameters["@LugarNacimiento"].Value = postulanteEscuelaGrumetesDTO.LugarNacimiento;

                    cmd.Parameters.Add("@FechaNacimiento", SqlDbType.Date);
                    cmd.Parameters["@FechaNacimiento"].Value = postulanteEscuelaGrumetesDTO.FechaNacimiento;

                    cmd.Parameters.Add("@LugarDomicilio", SqlDbType.Int);
                    cmd.Parameters["@LugarDomicilio"].Value = postulanteEscuelaGrumetesDTO.LugarDomicilio;

                    cmd.Parameters.Add("@LugarPresentacionPostulante", SqlDbType.Int);
                    cmd.Parameters["@LugarPresentacionPostulante"].Value = postulanteEscuelaGrumetesDTO.LugarPresentacionPostulante;

                    cmd.Parameters.Add("@ZonaNavalId", SqlDbType.Int);
                    cmd.Parameters["@ZonaNavalId"].Value = postulanteEscuelaGrumetesDTO.ZonaNavalId;

                    cmd.Parameters.Add("@GradoEstudioAlcanzadoId", SqlDbType.Int);
                    cmd.Parameters["@GradoEstudioAlcanzadoId"].Value = postulanteEscuelaGrumetesDTO.GradoEstudioAlcanzadoId;

                    cmd.Parameters.Add("@GradoEstudioEspecifId", SqlDbType.Int);
                    cmd.Parameters["@GradoEstudioEspecifId"].Value = postulanteEscuelaGrumetesDTO.GradoEstudioEspecifId;

                    cmd.Parameters.Add("@NumeroContingenciaPostulante", SqlDbType.Int);
                    cmd.Parameters["@NumeroContingenciaPostulante"].Value = postulanteEscuelaGrumetesDTO.NumeroContingenciaPostulante;

                    cmd.Parameters.Add("@ResultadoPostulacion", SqlDbType.VarChar,50);
                    cmd.Parameters["@ResultadoPostulacion"].Value = postulanteEscuelaGrumetesDTO.ResultadoPostulacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = postulanteEscuelaGrumetesDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(PostulanteEscuelaGrumetesDTO postulanteEscuelaGrumetesDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PostulanteEscuelaGrumetesEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PostulanteEscuelaGrumeteId", SqlDbType.Int);
                    cmd.Parameters["@PostulanteEscuelaGrumeteId"].Value = postulanteEscuelaGrumetesDTO.PostulanteEscuelaGrumeteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = postulanteEscuelaGrumetesDTO.UsuarioIngresoRegistro;

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

        public bool InsercionMasiva(IEnumerable<PostulanteEscuelaGrumetesDTO> postulanteEscuelaGrumetesDTO)
        {
            bool respuesta = false;
            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                using (SqlTransaction transaction = conexion.BeginTransaction())
                {
                    using (var cmd = new SqlCommand())
                    {

                        cmd.Connection = conexion;
                        cmd.Transaction = transaction;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into Formato.EstudiosInvestigacionHistoricaNaval " +
                            " (NombreInvestigacion, TipoEstudioInvestigacionId, FechaInicioInvestigacion, " +
                            "FechaTerminoInvestigacion, ResponsableInvestigacion, SolicitanteInvestigacion, " +
                            "UsuarioIngresoRegistro, FechaIngresoRegistro, NroIpRegistro, NroMacRegistro, " +
                            "UsuarioBaseDatos, CodigoIngreso, Año, Mes, Dia) values (@NombreInvestigacion, " +
                            "@TipoEstudioInvestigacionId, @FechaInicioInvestigacion, @FechaTerminoInvestigacion, " +
                            "@ResponsableInvestigacion, @SolicitanteInvestigacion, @Usuario, GETDATE(), @IP, @MAC, " +
                            "@UsuarioDB, 0, @YEAR, @MES, @DIA)";
                        cmd.Parameters.Add("@NombreInvestigacion", SqlDbType.VarChar, 250);
                        cmd.Parameters.Add("@TipoEstudioInvestigacionId", SqlDbType.Int);
                        cmd.Parameters.Add("@FechaInicioInvestigacion", SqlDbType.Date);
                        cmd.Parameters.Add("@FechaTerminoInvestigacion", SqlDbType.Date);
                        cmd.Parameters.Add("@ResponsableInvestigacion", SqlDbType.VarChar, 250);
                        cmd.Parameters.Add("@SolicitanteInvestigacion", SqlDbType.VarChar, 250);
                        cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@IP", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@MAC", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@UsuarioDB", SqlDbType.VarChar, 50);
                        try
                        {
                            foreach (var item in postulanteEscuelaGrumetesDTO)
                            {
                                //cmd.Parameters["@NombreInvestigacion"].Value = item.NombreTemaEstudioInvestigacion;
                                //cmd.Parameters["@TipoEstudioInvestigacionId"].Value = item.TipoEstudioInvestigacionIds;
                                //cmd.Parameters["@FechaInicioInvestigacion"].Value = Convert.ToDateTime(item.FechaInicio);
                                //cmd.Parameters["@FechaTerminoInvestigacion"].Value = Convert.ToDateTime(item.FechaTermino);
                                //cmd.Parameters["@ResponsableInvestigacion"].Value = item.Responsable;
                                //cmd.Parameters["@SolicitanteInvestigacion"].Value = item.Solicitante;
                                cmd.Parameters["@Usuario"].Value = item.UsuarioIngresoRegistro;
                                cmd.Parameters["@IP"].Value = UtilitariosGlobales.obtenerDireccionIp();
                                cmd.Parameters["@MAC"].Value = UtilitariosGlobales.obtenerDireccionMac();
                                cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                            respuesta = true;
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();                    
                            throw;
                        }
                        finally
                        {
                            conexion.Close();
                        }
                    }
                }
            }
            return respuesta;
        }
    }
}
