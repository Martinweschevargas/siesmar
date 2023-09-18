using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Combima1;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Combima1
{
    public class SituacionBuqueAuxiEmbarcMenorCombima1DAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<SituacionBuqueAuxiEmbarcMenorCombima1DTO> ObtenerLista()
        {
            List<SituacionBuqueAuxiEmbarcMenorCombima1DTO> lista = new List<SituacionBuqueAuxiEmbarcMenorCombima1DTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_SituacionBuqueAuxiEmbarcMenorCombima1Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SituacionBuqueAuxiEmbarcMenorCombima1DTO()
                        {
                            SituacionBuqueAuxiliarEmbarcacionMenorId = Convert.ToInt32(dr["SituacionBuqueAuxiliarEmbarcacionMenorId"]),
                            CodigoUnidad = Convert.ToInt32(dr["CodigoUnidad"]),
                            Categoria = dr["Categoria"].ToString(),
                            DescTipoPlataformaNave = dr["DescTipoPlataformaNave"].ToString(),
                            DependenciaId = Convert.ToInt32(dr["DependenciaId"]),
                            Ubicacion = dr["Ubicacion"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            DescCapacidadOperativaRequerida = dr["DescCapacidadOperativaRequerida"].ToString(),
                            DescCondicion = dr["DescCondicion"].ToString(),
                            Observacion = dr["Observacion"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(SituacionBuqueAuxiEmbarcMenorCombima1DTO situacionBuqueAuxiEmbarcMenorCombima1DTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionBuqueAuxiEmbarcMenorCombima1Registrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.CodigoUnidad;

                    cmd.Parameters.Add("@CascoNave", SqlDbType.VarChar);
                    cmd.Parameters["@CascoNave"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.Categoria;

                    cmd.Parameters.Add("@TipoPlataformaNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoPlataformaNaveId"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.TipoPlataformaNaveId;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.DependenciaId;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Ubicacion"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.Ubicacion;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@CapacidadOperativaRequeridaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaRequeridaId"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.CapacidadOperativaRequeridaId;

                    cmd.Parameters.Add("@CondicionId", SqlDbType.Int);
                    cmd.Parameters["@CondicionId"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.CondicionId;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observacion"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.Observacion;


                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.UsuarioIngresoRegistro;

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

        public SituacionBuqueAuxiEmbarcMenorCombima1DTO BuscarFormato(int Codigo)
        {
            SituacionBuqueAuxiEmbarcMenorCombima1DTO situacionBuqueAuxiEmbarcMenorCombima1DTO = new SituacionBuqueAuxiEmbarcMenorCombima1DTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionBuqueAuxiEmbarcMenorCombima1Encontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionBuqueAuxiliarEmbarcacionMenorId", SqlDbType.Int);
                    cmd.Parameters["@SituacionBuqueAuxiliarEmbarcacionMenorId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        situacionBuqueAuxiEmbarcMenorCombima1DTO.SituacionBuqueAuxiliarEmbarcacionMenorId = Convert.ToInt32(dr["SituacionBuqueAuxiliarEmbarcacionMenorId"]);
                        situacionBuqueAuxiEmbarcMenorCombima1DTO.CodigoUnidad = Convert.ToInt32(dr["CodigoUnidad"]);
                        situacionBuqueAuxiEmbarcMenorCombima1DTO.Categoria = dr["Ubicacion"].ToString();
                        situacionBuqueAuxiEmbarcMenorCombima1DTO.TipoPlataformaNaveId = Convert.ToInt32(dr["TipoPlataformaNaveId"]);
                        situacionBuqueAuxiEmbarcMenorCombima1DTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]);
                        situacionBuqueAuxiEmbarcMenorCombima1DTO.Ubicacion = dr["Ubicacion"].ToString();
                        situacionBuqueAuxiEmbarcMenorCombima1DTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]);
                        situacionBuqueAuxiEmbarcMenorCombima1DTO.ProvinciaUbigeoId = Convert.ToInt32(dr["ProvinciaUbigeoId"]);
                        situacionBuqueAuxiEmbarcMenorCombima1DTO.DistritoUbigeoId = Convert.ToInt32(dr["DistritoUbigeoId"]);
                        situacionBuqueAuxiEmbarcMenorCombima1DTO.CapacidadOperativaRequeridaId = Convert.ToInt32(dr["CapacidadOperativaRequeridaId"]);
                        situacionBuqueAuxiEmbarcMenorCombima1DTO.CondicionId = Convert.ToInt32(dr["CondicionId"]);
                        situacionBuqueAuxiEmbarcMenorCombima1DTO.Observacion = dr["Observacion"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return situacionBuqueAuxiEmbarcMenorCombima1DTO;
        }

        public string ActualizaFormato(SituacionBuqueAuxiEmbarcMenorCombima1DTO situacionBuqueAuxiEmbarcMenorCombima1DTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_SituacionBuqueAuxiEmbarcMenorCombima1Actualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@SituacionBuqueAuxiliarEmbarcacionMenorId", SqlDbType.Int);
                    cmd.Parameters["@SituacionBuqueAuxiliarEmbarcacionMenorId"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.SituacionBuqueAuxiliarEmbarcacionMenorId;

                    cmd.Parameters.Add("@CodigoUnidad", SqlDbType.Int);
                    cmd.Parameters["@CodigoUnidad"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.CodigoUnidad;

                    cmd.Parameters.Add("@Categoria", SqlDbType.VarChar);
                    cmd.Parameters["@Categoria"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.Categoria;

                    cmd.Parameters.Add("@TipoPlataformaNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoPlataformaNaveId"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.TipoPlataformaNaveId;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.DependenciaId;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Ubicacion"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.Ubicacion;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@CapacidadOperativaRequeridaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaRequeridaId"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.CapacidadOperativaRequeridaId;

                    cmd.Parameters.Add("@CondicionId", SqlDbType.Int);
                    cmd.Parameters["@CondicionId"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.CondicionId;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Observacion"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.Observacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(SituacionBuqueAuxiEmbarcMenorCombima1DTO situacionBuqueAuxiEmbarcMenorCombima1DTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionBuqueAuxiEmbarcMenorCombima1Eliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadNaveId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadNaveId"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.SituacionBuqueAuxiliarEmbarcacionMenorId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionBuqueAuxiEmbarcMenorCombima1DTO.UsuarioIngresoRegistro;

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

        public bool InsercionMasiva(IEnumerable<SituacionBuqueAuxiEmbarcMenorCombima1DTO> situacionBuqueAuxiEmbarcMenorCombima1DTO)
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
                        cmd.CommandText = "insert into FIEstudiosInvestigacionHistoricaNaval " +
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
                            foreach (var item in situacionBuqueAuxiEmbarcMenorCombima1DTO)
                            {
                                //cmd.Parameters["@NombreInvestigacion"].Value = item.NombreActividadCultural;
                                //cmd.Parameters["@TipoEstudioInvestigacionId"].Value = item.TipoActividadCulturalId;
                                //cmd.Parameters["@FechaInicioInvestigacion"].Value = Convert.ToDateTime(item.FechaInicioActCultural);
                                //cmd.Parameters["@FechaTerminoInvestigacion"].Value = Convert.ToDateTime(item.FechaTerminoActCultural);
                                //cmd.Parameters["@ResponsableInvestigacion"].Value = item.LugarActCultural;
                                //cmd.Parameters["@SolicitanteInvestigacion"].Value = item.AuspiciadoresActCultural;
                                //cmd.Parameters["@NParticipantesActCultural"].Value = item.NParticipantesActCultural;
                                //cmd.Parameters["@InversionActCultural"].Value = item.InversionActCultural;
                                //cmd.Parameters["@Usuario"].Value = item.UsuarioIngresoRegistro;
                                //cmd.Parameters["@IP"].Value = UtilitariosGlobales.obtenerDireccionIp();
                                //cmd.Parameters["@MAC"].Value = UtilitariosGlobales.obtenerDireccionMac();
                                //cmd.Parameters["@UsuarioDB"].Value = UtilitariosGlobales.obtenerUsuarioDB();
                                //cmd.Parameters["@Year"].Value = DateTime.Now.Year;
                                //cmd.Parameters["@Mes"].Value = DateTime.Now.Month;
                                //cmd.Parameters["@Dia"].Value = DateTime.Now.Day;
                                //cmd.ExecuteNonQuery();
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
