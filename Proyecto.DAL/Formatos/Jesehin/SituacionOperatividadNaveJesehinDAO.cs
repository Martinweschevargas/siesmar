using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Jesehin;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Jesehin
{
    public class SituacionOperatividadNaveJesehinDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<SituacionOperatividadNaveJesehinDTO> ObtenerLista()
        {
            List<SituacionOperatividadNaveJesehinDTO> lista = new List<SituacionOperatividadNaveJesehinDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_SituacionOperatividadNaveJesehinListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SituacionOperatividadNaveJesehinDTO()
                        {
                            SituacionOperatividadNaveJesehinId = Convert.ToInt32(dr["SituacionOperatividadNaveJesehinId"]),
                            DescTipoNave = dr["DescTipoNave"].ToString(),
                            CascoNaval = Convert.ToInt32(dr["CascoNaval"]),
                            DescTipoPlataformaNave = dr["DescTipoPlataformaNave"].ToString(),
                            DescDependencia = dr["DescDependecia"].ToString(),
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

        public string AgregarRegistro(SituacionOperatividadNaveJesehinDTO situacionOperatividadNaveJesehinDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadNaveJesehinRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = situacionOperatividadNaveJesehinDTO.TipoNaveId;

                    cmd.Parameters.Add("@CascoNaval", SqlDbType.Int);
                    cmd.Parameters["@CascoNaval"].Value = situacionOperatividadNaveJesehinDTO.CascoNaval;

                    cmd.Parameters.Add("@TipoPlataformaNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoPlataformaNaveId"].Value = situacionOperatividadNaveJesehinDTO.TipoPlataformaNaveId;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = situacionOperatividadNaveJesehinDTO.DependenciaId;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Ubicacion"].Value = situacionOperatividadNaveJesehinDTO.Ubicacion;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = situacionOperatividadNaveJesehinDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = situacionOperatividadNaveJesehinDTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = situacionOperatividadNaveJesehinDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@CapacidadOperativaRequeridaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaRequeridaId"].Value = situacionOperatividadNaveJesehinDTO.CapacidadOperativaRequeridaId;

                    cmd.Parameters.Add("@CondicionId", SqlDbType.Int);
                    cmd.Parameters["@CondicionId"].Value = situacionOperatividadNaveJesehinDTO.CondicionId;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observacion"].Value = situacionOperatividadNaveJesehinDTO.Observacion;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperatividadNaveJesehinDTO.UsuarioIngresoRegistro;

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

        public SituacionOperatividadNaveJesehinDTO BuscarFormato(int Codigo)
        {
            SituacionOperatividadNaveJesehinDTO situacionOperatividadNaveJesehinDTO = new SituacionOperatividadNaveJesehinDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadNaveJesehinEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadNaveJesehinId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadNaveJesehinId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        situacionOperatividadNaveJesehinDTO.SituacionOperatividadNaveJesehinId = Convert.ToInt32(dr["SituacionOperatividadNaveJesehinId"]);
                        situacionOperatividadNaveJesehinDTO.TipoNaveId = Convert.ToInt32(dr["TipoNaveId"]);
                        situacionOperatividadNaveJesehinDTO.CascoNaval = Convert.ToInt32(dr["CascoNaval"]);
                        situacionOperatividadNaveJesehinDTO.TipoPlataformaNaveId = Convert.ToInt32(dr["TipoPlataformaNaveId"]);
                        situacionOperatividadNaveJesehinDTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]);
                        situacionOperatividadNaveJesehinDTO.Ubicacion = dr["Ubicacion"].ToString();
                        situacionOperatividadNaveJesehinDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]);
                        situacionOperatividadNaveJesehinDTO.ProvinciaUbigeoId = Convert.ToInt32(dr["ProvinciaUbigeoId"]);
                        situacionOperatividadNaveJesehinDTO.DistritoUbigeoId = Convert.ToInt32(dr["DistritoUbigeoId"]);
                        situacionOperatividadNaveJesehinDTO.CapacidadOperativaRequeridaId = Convert.ToInt32(dr["CapacidadOperativaRequeridaId"]);
                        situacionOperatividadNaveJesehinDTO.CondicionId = Convert.ToInt32(dr["CondicionId"]);
                        situacionOperatividadNaveJesehinDTO.Observacion = dr["Observacion"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return situacionOperatividadNaveJesehinDTO;
        }

        public string ActualizaFormato(SituacionOperatividadNaveJesehinDTO situacionOperatividadNaveJesehinDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadNaveJesehinActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@SituacionOperatividadNaveJesehinId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadNaveJesehinId"].Value = situacionOperatividadNaveJesehinDTO.SituacionOperatividadNaveJesehinId;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = situacionOperatividadNaveJesehinDTO.TipoNaveId;

                    cmd.Parameters.Add("@CascoNaval", SqlDbType.Int);
                    cmd.Parameters["@CascoNaval"].Value = situacionOperatividadNaveJesehinDTO.CascoNaval;

                    cmd.Parameters.Add("@TipoPlataformaNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoPlataformaNaveId"].Value = situacionOperatividadNaveJesehinDTO.TipoPlataformaNaveId;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = situacionOperatividadNaveJesehinDTO.DependenciaId;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Ubicacion"].Value = situacionOperatividadNaveJesehinDTO.Ubicacion;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = situacionOperatividadNaveJesehinDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = situacionOperatividadNaveJesehinDTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = situacionOperatividadNaveJesehinDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@CapacidadOperativaRequeridaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaRequeridaId"].Value = situacionOperatividadNaveJesehinDTO.CapacidadOperativaRequeridaId;

                    cmd.Parameters.Add("@CondicionId", SqlDbType.Int);
                    cmd.Parameters["@CondicionId"].Value = situacionOperatividadNaveJesehinDTO.CondicionId;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Observacion"].Value = situacionOperatividadNaveJesehinDTO.Observacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperatividadNaveJesehinDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(SituacionOperatividadNaveJesehinDTO situacionOperatividadNaveJesehinDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadNaveJesehinEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadNaveJesehinId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadNaveJesehinId"].Value = situacionOperatividadNaveJesehinDTO.SituacionOperatividadNaveJesehinId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperatividadNaveJesehinDTO.UsuarioIngresoRegistro;

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

        public bool InsercionMasiva(IEnumerable<SituacionOperatividadNaveJesehinDTO> situacionOperatividadNaveJesehinDTO)
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
                            foreach (var item in situacionOperatividadNaveJesehinDTO)
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
