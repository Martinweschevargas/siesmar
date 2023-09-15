using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comflotflu;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comflotflu
{
    public class SituacionOperativaNaveComflotfluDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<SituacionOperativaNaveComflotfluDTO> ObtenerLista()
        {
            List<SituacionOperativaNaveComflotfluDTO> lista = new List<SituacionOperativaNaveComflotfluDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_SituacionOperativaNaveComflotfluListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SituacionOperativaNaveComflotfluDTO()
                        {
                            SituacionOperativaNaveId = Convert.ToInt32(dr["SituacionOperativaNaveId"]),
                            DescTipoNave = dr["DescTipoNave"].ToString(),
                            DescCascoUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            TipoPlataforma = dr["TipoPlataforma"].ToString(),
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            Ubicacion = dr["Ubicacion"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            DescCapacidadOperativaId = dr["DescCapacidadOperativaId"].ToString(),
                            Condicion = dr["Condicion"].ToString(),
                            Observaciones = dr["Observaciones"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(SituacionOperativaNaveComflotfluDTO situacionOperativaNaveComflotfluDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperativaNaveComflotfluRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;           

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = situacionOperativaNaveComflotfluDTO.TipoNaveId;

                    cmd.Parameters.Add("@CascoUnidadNaval", SqlDbType.Int);
                    cmd.Parameters["@CascoUnidadNaval"].Value = situacionOperativaNaveComflotfluDTO.CascoUnidadNaval;

                    cmd.Parameters.Add("@TipoPlataforma", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoPlataforma"].Value = situacionOperativaNaveComflotfluDTO.TipoPlataforma;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = situacionOperativaNaveComflotfluDTO.DependenciaId;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Ubicacion"].Value = situacionOperativaNaveComflotfluDTO.Ubicacion;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = situacionOperativaNaveComflotfluDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = situacionOperativaNaveComflotfluDTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = situacionOperativaNaveComflotfluDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = situacionOperativaNaveComflotfluDTO.CapacidadOperativaId;

                    cmd.Parameters.Add("@Condicion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Condicion"].Value = situacionOperativaNaveComflotfluDTO.Condicion;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Observaciones"].Value = situacionOperativaNaveComflotfluDTO.Observaciones;
                  
                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperativaNaveComflotfluDTO.UsuarioIngresoRegistro;

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

        public SituacionOperativaNaveComflotfluDTO BuscarFormato(int Codigo)
        {
            SituacionOperativaNaveComflotfluDTO situacionOperativaNaveComflotfluDTO = new SituacionOperativaNaveComflotfluDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperativaNaveComflotfluEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperativaNaveId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperativaNaveId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        situacionOperativaNaveComflotfluDTO.SituacionOperativaNaveId = Convert.ToInt32(dr["SituacionOperativaNaveId"]);
                        situacionOperativaNaveComflotfluDTO.TipoNaveId = Convert.ToInt32(dr["TipoNaveId"]);
                        situacionOperativaNaveComflotfluDTO.CascoUnidadNaval = Convert.ToInt32(dr["CascoUnidadNaval"]);
                        situacionOperativaNaveComflotfluDTO.TipoPlataforma = dr["TipoPlataforma"].ToString();
                        situacionOperativaNaveComflotfluDTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]);
                        situacionOperativaNaveComflotfluDTO.Ubicacion = dr["Ubicacion"].ToString();
                        situacionOperativaNaveComflotfluDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]);
                        situacionOperativaNaveComflotfluDTO.ProvinciaUbigeoId = Convert.ToInt32(dr["ProvinciaUbigeoId"]);
                        situacionOperativaNaveComflotfluDTO.DistritoUbigeoId = Convert.ToInt32(dr["DistritoUbigeoId"]);
                        situacionOperativaNaveComflotfluDTO.CapacidadOperativaId = Convert.ToInt32(dr["CapacidadOperativaId"]);
                        situacionOperativaNaveComflotfluDTO.Condicion = dr["Condicion"].ToString();
                        situacionOperativaNaveComflotfluDTO.Observaciones = dr["Observaciones"].ToString(); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return situacionOperativaNaveComflotfluDTO;
        }

        public string ActualizaFormato(SituacionOperativaNaveComflotfluDTO situacionOperativaNaveComflotfluDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_SituacionOperativaNaveComflotfluActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@SituacionOperativaNaveId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperativaNaveId"].Value = situacionOperativaNaveComflotfluDTO.SituacionOperativaNaveId;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = situacionOperativaNaveComflotfluDTO.TipoNaveId;

                    cmd.Parameters.Add("@CascoUnidadNaval", SqlDbType.Int);
                    cmd.Parameters["@CascoUnidadNaval"].Value = situacionOperativaNaveComflotfluDTO.CascoUnidadNaval;

                    cmd.Parameters.Add("@TipoPlataforma", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoPlataforma"].Value = situacionOperativaNaveComflotfluDTO.TipoPlataforma;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = situacionOperativaNaveComflotfluDTO.DependenciaId;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Ubicacion"].Value = situacionOperativaNaveComflotfluDTO.Ubicacion;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = situacionOperativaNaveComflotfluDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = situacionOperativaNaveComflotfluDTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = situacionOperativaNaveComflotfluDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = situacionOperativaNaveComflotfluDTO.CapacidadOperativaId;

                    cmd.Parameters.Add("@Condicion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Condicion"].Value = situacionOperativaNaveComflotfluDTO.Condicion;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Observaciones"].Value = situacionOperativaNaveComflotfluDTO.Observaciones;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperativaNaveComflotfluDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(SituacionOperativaNaveComflotfluDTO situacionOperativaNaveComflotfluDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperativaNaveComflotfluEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperativaNaveId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperativaNaveId"].Value = situacionOperativaNaveComflotfluDTO.SituacionOperativaNaveId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperativaNaveComflotfluDTO.UsuarioIngresoRegistro;

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

        public bool InsercionMasiva(IEnumerable<SituacionOperativaNaveComflotfluDTO> emisionNotaPrensaDTO)
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
                            foreach (var item in emisionNotaPrensaDTO)
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
