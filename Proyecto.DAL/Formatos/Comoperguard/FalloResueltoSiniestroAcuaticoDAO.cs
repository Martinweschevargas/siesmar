using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperguard
{
    public class FalloResueltoSiniestroAcuaticoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<FalloResueltoSiniestroAcuaticoDTO> ObtenerLista()
        {
            List<FalloResueltoSiniestroAcuaticoDTO> lista = new List<FalloResueltoSiniestroAcuaticoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_FalloResueltoSiniestroAcuaticoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new FalloResueltoSiniestroAcuaticoDTO()
                        {
                            FalloResueltoSiniestroAcuaticoId = Convert.ToInt32(dr["FalloResueltoSiniestroAcuaticoId"]),
                            DescJefaturaDistritoCapitania = dr["DescJefaturaDistritoCapitania"].ToString(),
                            NombreCapitania = dr["NombreCapitania"].ToString(),
                            HoraCaptura = dr["HoraCaptura"].ToString(),
                            DiaCaptura = Convert.ToInt32(dr["DiaCaptura"]),
                            DescMes = dr["DescMes"].ToString(),
                            AnioSiniestro = Convert.ToInt32(dr["AnioSiniestro"]),
                            DescTipoNave = dr["DescTipoNave"].ToString(),
                            NombreNaveSiniestro = dr["NombreNaveSiniestro"].ToString(),
                            MatriculaNaveSiniestro = dr["MatriculaNaveSiniestro"].ToString(),
                            ABEdad = Convert.ToInt32(dr["ABEdad"]),
                            NombrePaisUbigeo = dr["NombrePaisUbigeo"].ToString(),
                            DescTipoSiniestro = dr["DescTipoSiniestro"].ToString(),
                            PersonasRescatadasVida = Convert.ToInt32(dr["PersonasRescatadasVida"]),
                            PersonasFallecidas = Convert.ToInt32(dr["PersonasFallecidas"]),
                            PersonasDesaparecida = Convert.ToInt32(dr["PersonasDesaparecida"]),
                            PersonasEvacuadas = Convert.ToInt32(dr["PersonasEvacuadas"]),
                            TotalPersonas = Convert.ToInt32(dr["TotalPersonas"]),
                            ReferenciaDocumento = dr["ReferenciaDocumento"].ToString(),
                            FechaDocumento = (dr["FechaDocumento"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            ResumenFallo = dr["ResumenFallo"].ToString(),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(FalloResueltoSiniestroAcuaticoDTO falloResueltoSiniestroAcuaticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_FalloResueltoSiniestroAcuaticoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = falloResueltoSiniestroAcuaticoDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = falloResueltoSiniestroAcuaticoDTO.CapitaniaId;

                    cmd.Parameters.Add("@HoraCaptura", SqlDbType.Time);
                    cmd.Parameters["@HoraCaptura"].Value = falloResueltoSiniestroAcuaticoDTO.HoraCaptura;

                    cmd.Parameters.Add("@DiaCaptura", SqlDbType.Int);
                    cmd.Parameters["@DiaCaptura"].Value = falloResueltoSiniestroAcuaticoDTO.DiaCaptura;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = falloResueltoSiniestroAcuaticoDTO.MesId;

                    cmd.Parameters.Add("@AnioSiniestro", SqlDbType.Int);
                    cmd.Parameters["@AnioSiniestro"].Value = falloResueltoSiniestroAcuaticoDTO.AnioSiniestro;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = falloResueltoSiniestroAcuaticoDTO.TipoNaveId;

                    cmd.Parameters.Add("@NombreNaveSiniestro", SqlDbType.VarChar,150);
                    cmd.Parameters["@NombreNaveSiniestro"].Value = falloResueltoSiniestroAcuaticoDTO.NombreNaveSiniestro;

                    cmd.Parameters.Add("@MatriculaNaveSiniestro", SqlDbType.VarChar,15);
                    cmd.Parameters["@MatriculaNaveSiniestro"].Value = falloResueltoSiniestroAcuaticoDTO.MatriculaNaveSiniestro;

                    cmd.Parameters.Add("@ABEdad", SqlDbType.Int);
                    cmd.Parameters["@ABEdad"].Value = falloResueltoSiniestroAcuaticoDTO.ABEdad;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = falloResueltoSiniestroAcuaticoDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@TipoSiniestroId", SqlDbType.Int);
                    cmd.Parameters["@TipoSiniestroId"].Value = falloResueltoSiniestroAcuaticoDTO.TipoSiniestroId;

                    cmd.Parameters.Add("@PersonasRescatadasVida", SqlDbType.Int);
                    cmd.Parameters["@PersonasRescatadasVida"].Value = falloResueltoSiniestroAcuaticoDTO.PersonasRescatadasVida;

                    cmd.Parameters.Add("@PersonasFallecidas", SqlDbType.Int);
                    cmd.Parameters["@PersonasFallecidas"].Value = falloResueltoSiniestroAcuaticoDTO.PersonasFallecidas;

                    cmd.Parameters.Add("@PersonasDesaparecida", SqlDbType.Int);
                    cmd.Parameters["@PersonasDesaparecida"].Value = falloResueltoSiniestroAcuaticoDTO.PersonasDesaparecida;

                    cmd.Parameters.Add("@PersonasEvacuadas", SqlDbType.Int);
                    cmd.Parameters["@PersonasEvacuadas"].Value = falloResueltoSiniestroAcuaticoDTO.PersonasEvacuadas;

                    cmd.Parameters.Add("@TotalPersonas", SqlDbType.Int);
                    cmd.Parameters["@TotalPersonas"].Value = falloResueltoSiniestroAcuaticoDTO.TotalPersonas;

                    cmd.Parameters.Add("@ReferenciaDocumento", SqlDbType.VarChar,10);
                    cmd.Parameters["@ReferenciaDocumento"].Value = falloResueltoSiniestroAcuaticoDTO.ReferenciaDocumento;

                    cmd.Parameters.Add("@FechaDocumento", SqlDbType.Date);
                    cmd.Parameters["@FechaDocumento"].Value = falloResueltoSiniestroAcuaticoDTO.FechaDocumento;

                    cmd.Parameters.Add("@ResumenFallo", SqlDbType.VarChar,100);
                    cmd.Parameters["@ResumenFallo"].Value = falloResueltoSiniestroAcuaticoDTO.ResumenFallo;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = falloResueltoSiniestroAcuaticoDTO.UsuarioIngresoRegistro;

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

        public FalloResueltoSiniestroAcuaticoDTO BuscarFormato(int Codigo)
        {
            FalloResueltoSiniestroAcuaticoDTO falloResueltoSiniestroAcuaticoDTO = new FalloResueltoSiniestroAcuaticoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_FalloResueltoSiniestroAcuaticoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FalloResueltoSiniestroAcuaticoId", SqlDbType.Int);
                    cmd.Parameters["@FalloResueltoSiniestroAcuaticoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        falloResueltoSiniestroAcuaticoDTO.FalloResueltoSiniestroAcuaticoId = Convert.ToInt32(dr["FalloResueltoSiniestroAcuaticoId"]);
                        falloResueltoSiniestroAcuaticoDTO.JefaturaDistritoCapitaniaId = Convert.ToInt32(dr["JefaturaDistritoCapitaniaId"]);
                        falloResueltoSiniestroAcuaticoDTO.CapitaniaId = Convert.ToInt32(dr["CapitaniaId"]);
                        falloResueltoSiniestroAcuaticoDTO.HoraCaptura = dr["HoraCaptura"].ToString();
                        falloResueltoSiniestroAcuaticoDTO.DiaCaptura = Convert.ToInt32(dr["DiaCaptura"]);
                        falloResueltoSiniestroAcuaticoDTO.MesId = Convert.ToInt32(dr["MesId"]);
                        falloResueltoSiniestroAcuaticoDTO.AnioSiniestro = Convert.ToInt32(dr["AnioSiniestro"]);
                        falloResueltoSiniestroAcuaticoDTO.TipoNaveId = Convert.ToInt32(dr["TipoNaveId"]);
                        falloResueltoSiniestroAcuaticoDTO.NombreNaveSiniestro = dr["NombreNaveSiniestro"].ToString();
                        falloResueltoSiniestroAcuaticoDTO.MatriculaNaveSiniestro = dr["MatriculaNaveSiniestro"].ToString();
                        falloResueltoSiniestroAcuaticoDTO.ABEdad = Convert.ToInt32(dr["ABEdad"]);
                        falloResueltoSiniestroAcuaticoDTO.PaisUbigeoId = Convert.ToInt32(dr["PaisUbigeoId"]);
                        falloResueltoSiniestroAcuaticoDTO.TipoSiniestroId = Convert.ToInt32(dr["TipoSiniestroId"]);
                        falloResueltoSiniestroAcuaticoDTO.PersonasRescatadasVida = Convert.ToInt32(dr["PersonasRescatadasVida"]);
                        falloResueltoSiniestroAcuaticoDTO.PersonasFallecidas = Convert.ToInt32(dr["PersonasFallecidas"]);
                        falloResueltoSiniestroAcuaticoDTO.PersonasDesaparecida = Convert.ToInt32(dr["PersonasDesaparecida"]);
                        falloResueltoSiniestroAcuaticoDTO.PersonasEvacuadas = Convert.ToInt32(dr["PersonasEvacuadas"]);
                        falloResueltoSiniestroAcuaticoDTO.TotalPersonas = Convert.ToInt32(dr["TotalPersonas"]);
                        falloResueltoSiniestroAcuaticoDTO.ReferenciaDocumento = dr["ReferenciaDocumento"].ToString();
                        falloResueltoSiniestroAcuaticoDTO.FechaDocumento = Convert.ToDateTime(dr["FechaDocumento"]).ToString("yyy-MM-dd");
                        falloResueltoSiniestroAcuaticoDTO.ResumenFallo = dr["ResumenFallo"].ToString(); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return falloResueltoSiniestroAcuaticoDTO;
        }

        public string ActualizaFormato(FalloResueltoSiniestroAcuaticoDTO falloResueltoSiniestroAcuaticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_FalloResueltoSiniestroAcuaticoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@FalloResueltoSiniestroAcuaticoId", SqlDbType.Int);
                    cmd.Parameters["@FalloResueltoSiniestroAcuaticoId"].Value = falloResueltoSiniestroAcuaticoDTO.FalloResueltoSiniestroAcuaticoId;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = falloResueltoSiniestroAcuaticoDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = falloResueltoSiniestroAcuaticoDTO.CapitaniaId;

                    cmd.Parameters.Add("@HoraCaptura", SqlDbType.Time);
                    cmd.Parameters["@HoraCaptura"].Value = falloResueltoSiniestroAcuaticoDTO.HoraCaptura;

                    cmd.Parameters.Add("@DiaCaptura", SqlDbType.Int);
                    cmd.Parameters["@DiaCaptura"].Value = falloResueltoSiniestroAcuaticoDTO.DiaCaptura;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = falloResueltoSiniestroAcuaticoDTO.MesId;

                    cmd.Parameters.Add("@AnioSiniestro", SqlDbType.Int);
                    cmd.Parameters["@AnioSiniestro"].Value = falloResueltoSiniestroAcuaticoDTO.AnioSiniestro;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = falloResueltoSiniestroAcuaticoDTO.TipoNaveId;

                    cmd.Parameters.Add("@NombreNaveSiniestro", SqlDbType.VarChar, 150);
                    cmd.Parameters["@NombreNaveSiniestro"].Value = falloResueltoSiniestroAcuaticoDTO.NombreNaveSiniestro;

                    cmd.Parameters.Add("@MatriculaNaveSiniestro", SqlDbType.VarChar, 15);
                    cmd.Parameters["@MatriculaNaveSiniestro"].Value = falloResueltoSiniestroAcuaticoDTO.MatriculaNaveSiniestro;

                    cmd.Parameters.Add("@ABEdad", SqlDbType.Int);
                    cmd.Parameters["@ABEdad"].Value = falloResueltoSiniestroAcuaticoDTO.ABEdad;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = falloResueltoSiniestroAcuaticoDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@TipoSiniestroId", SqlDbType.Int);
                    cmd.Parameters["@TipoSiniestroId"].Value = falloResueltoSiniestroAcuaticoDTO.TipoSiniestroId;

                    cmd.Parameters.Add("@PersonasRescatadasVida", SqlDbType.Int);
                    cmd.Parameters["@PersonasRescatadasVida"].Value = falloResueltoSiniestroAcuaticoDTO.PersonasRescatadasVida;

                    cmd.Parameters.Add("@PersonasFallecidas", SqlDbType.Int);
                    cmd.Parameters["@PersonasFallecidas"].Value = falloResueltoSiniestroAcuaticoDTO.PersonasFallecidas;

                    cmd.Parameters.Add("@PersonasDesaparecida", SqlDbType.Int);
                    cmd.Parameters["@PersonasDesaparecida"].Value = falloResueltoSiniestroAcuaticoDTO.PersonasDesaparecida;

                    cmd.Parameters.Add("@PersonasEvacuadas", SqlDbType.Int);
                    cmd.Parameters["@PersonasEvacuadas"].Value = falloResueltoSiniestroAcuaticoDTO.PersonasEvacuadas;

                    cmd.Parameters.Add("@TotalPersonas", SqlDbType.Int);
                    cmd.Parameters["@TotalPersonas"].Value = falloResueltoSiniestroAcuaticoDTO.TotalPersonas;

                    cmd.Parameters.Add("@ReferenciaDocumento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@ReferenciaDocumento"].Value = falloResueltoSiniestroAcuaticoDTO.ReferenciaDocumento;

                    cmd.Parameters.Add("@FechaDocumento", SqlDbType.Date);
                    cmd.Parameters["@FechaDocumento"].Value = falloResueltoSiniestroAcuaticoDTO.FechaDocumento;

                    cmd.Parameters.Add("@ResumenFallo", SqlDbType.VarChar, 100);
                    cmd.Parameters["@ResumenFallo"].Value = falloResueltoSiniestroAcuaticoDTO.ResumenFallo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = falloResueltoSiniestroAcuaticoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(FalloResueltoSiniestroAcuaticoDTO falloResueltoSiniestroAcuaticoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_FalloResueltoSiniestroAcuaticoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FalloResueltoSiniestroAcuaticoId", SqlDbType.Int);
                    cmd.Parameters["@FalloResueltoSiniestroAcuaticoId"].Value = falloResueltoSiniestroAcuaticoDTO.FalloResueltoSiniestroAcuaticoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = falloResueltoSiniestroAcuaticoDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<FalloResueltoSiniestroAcuaticoDTO> falloResueltoSiniestroAcuaticoDTO)
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
                        cmd.Parameters.Add("@YEAR", SqlDbType.Int);
                        cmd.Parameters.Add("@MES", SqlDbType.Int);
                        cmd.Parameters.Add("@DIA", SqlDbType.Int);
                        try
                        {
                            foreach (var item in falloResueltoSiniestroAcuaticoDTO)
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
