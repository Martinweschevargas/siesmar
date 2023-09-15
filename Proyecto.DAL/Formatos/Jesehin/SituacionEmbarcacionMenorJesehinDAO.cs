using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Jesehin;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Jesehin
{
    public class SituacionEmbarcacionMenorJesehinDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<SituacionEmbarcacionMenorJesehinDTO> ObtenerLista()
        {
            List<SituacionEmbarcacionMenorJesehinDTO> lista = new List<SituacionEmbarcacionMenorJesehinDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_SituacionEmbarcacionMenorJesehinListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SituacionEmbarcacionMenorJesehinDTO()
                        {
                            SituacionEmbarcacionMenorId = Convert.ToInt32(dr["SituacionEmbarcacionMenorId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescTipoNave = dr["DescTipoNave"].ToString(),
                            TipoPlataforma = dr["TipoPlataforma"].ToString(),
                            DescUnidadNavalDestino = dr["DescUnidadNaval"].ToString(),
                            Ubicacion = dr["Ubicacion"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            DescCapacidadOperativaRequerida = dr["DescCapacidadOperativaRequerida"].ToString(),
                            DescCondicion = dr["DescCondicion"].ToString(),
                            Observaciones = dr["Observaciones"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(SituacionEmbarcacionMenorJesehinDTO situacionEmbarcacionMenorJesehinDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionEmbarcacionMenorJesehinRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = situacionEmbarcacionMenorJesehinDTO.UnidadNavalId;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = situacionEmbarcacionMenorJesehinDTO.TipoNaveId;

                    cmd.Parameters.Add("@TipoPlataforma", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoPlataforma"].Value = situacionEmbarcacionMenorJesehinDTO.TipoPlataforma;

                    cmd.Parameters.Add("@UnidadNavalDestino", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalDestino"].Value = situacionEmbarcacionMenorJesehinDTO.UnidadNavalDestino;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Ubicacion"].Value = situacionEmbarcacionMenorJesehinDTO.Ubicacion;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = situacionEmbarcacionMenorJesehinDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = situacionEmbarcacionMenorJesehinDTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = situacionEmbarcacionMenorJesehinDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@CapacidadOperativaRequeridaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaRequeridaId"].Value = situacionEmbarcacionMenorJesehinDTO.CapacidadOperativaRequeridaId;

                    cmd.Parameters.Add("@CondicionId", SqlDbType.Int);
                    cmd.Parameters["@CondicionId"].Value = situacionEmbarcacionMenorJesehinDTO.CondicionId;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Observaciones"].Value = situacionEmbarcacionMenorJesehinDTO.Observaciones;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionEmbarcacionMenorJesehinDTO.UsuarioIngresoRegistro;

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

        public SituacionEmbarcacionMenorJesehinDTO BuscarFormato(int Codigo)
        {
            SituacionEmbarcacionMenorJesehinDTO situacionEmbarcacionMenorJesehinDTO = new SituacionEmbarcacionMenorJesehinDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionEmbarcacionMenorJesehinEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionEmbarcacionMenorId", SqlDbType.Int);
                    cmd.Parameters["@SituacionEmbarcacionMenorId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        situacionEmbarcacionMenorJesehinDTO.SituacionEmbarcacionMenorId = Convert.ToInt32(dr["SituacionEmbarcacionMenorId"]);
                        situacionEmbarcacionMenorJesehinDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        situacionEmbarcacionMenorJesehinDTO.TipoNaveId = Convert.ToInt32(dr["TipoNaveId"]);
                        situacionEmbarcacionMenorJesehinDTO.TipoPlataforma = dr["TipoPlataforma"].ToString();
                        situacionEmbarcacionMenorJesehinDTO.UnidadNavalDestino = Convert.ToInt32(dr["UnidadNavalDestino"]);
                        situacionEmbarcacionMenorJesehinDTO.Ubicacion = dr["Ubicacion"].ToString();
                        situacionEmbarcacionMenorJesehinDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]);
                        situacionEmbarcacionMenorJesehinDTO.ProvinciaUbigeoId = Convert.ToInt32(dr["ProvinciaUbigeoId"]);
                        situacionEmbarcacionMenorJesehinDTO.DistritoUbigeoId = Convert.ToInt32(dr["DistritoUbigeoId"]);
                        situacionEmbarcacionMenorJesehinDTO.CapacidadOperativaRequeridaId = Convert.ToInt32(dr["CapacidadOperativaRequeridaId"]);
                        situacionEmbarcacionMenorJesehinDTO.CondicionId = Convert.ToInt32(dr["CondicionId"]);
                        situacionEmbarcacionMenorJesehinDTO.Observaciones = dr["Observaciones"].ToString(); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return situacionEmbarcacionMenorJesehinDTO;
        }

        public string ActualizaFormato(SituacionEmbarcacionMenorJesehinDTO situacionEmbarcacionMenorJesehinDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_SituacionEmbarcacionMenorJesehinActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@SituacionEmbarcacionMenorId", SqlDbType.Int);
                    cmd.Parameters["@SituacionEmbarcacionMenorId"].Value = situacionEmbarcacionMenorJesehinDTO.SituacionEmbarcacionMenorId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = situacionEmbarcacionMenorJesehinDTO.UnidadNavalId;

                    cmd.Parameters.Add("@TipoNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoNaveId"].Value = situacionEmbarcacionMenorJesehinDTO.TipoNaveId;

                    cmd.Parameters.Add("@TipoPlataforma", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoPlataforma"].Value = situacionEmbarcacionMenorJesehinDTO.TipoPlataforma;

                    cmd.Parameters.Add("@UnidadNavalDestino", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalDestino"].Value = situacionEmbarcacionMenorJesehinDTO.UnidadNavalDestino;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Ubicacion"].Value = situacionEmbarcacionMenorJesehinDTO.Ubicacion;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = situacionEmbarcacionMenorJesehinDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = situacionEmbarcacionMenorJesehinDTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = situacionEmbarcacionMenorJesehinDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@CapacidadOperativaRequeridaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaRequeridaId"].Value = situacionEmbarcacionMenorJesehinDTO.CapacidadOperativaRequeridaId;

                    cmd.Parameters.Add("@CondicionId", SqlDbType.Int);
                    cmd.Parameters["@CondicionId"].Value = situacionEmbarcacionMenorJesehinDTO.CondicionId;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Observaciones"].Value = situacionEmbarcacionMenorJesehinDTO.Observaciones;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionEmbarcacionMenorJesehinDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(SituacionEmbarcacionMenorJesehinDTO situacionEmbarcacionMenorJesehinDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionEmbarcacionMenorJesehinEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionEmbarcacionMenorId", SqlDbType.Int);
                    cmd.Parameters["@SituacionEmbarcacionMenorId"].Value = situacionEmbarcacionMenorJesehinDTO.SituacionEmbarcacionMenorId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionEmbarcacionMenorJesehinDTO.UsuarioIngresoRegistro;

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

        public bool InsercionMasiva(IEnumerable<SituacionEmbarcacionMenorJesehinDTO> emisionNotaPrensaDTO)
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
