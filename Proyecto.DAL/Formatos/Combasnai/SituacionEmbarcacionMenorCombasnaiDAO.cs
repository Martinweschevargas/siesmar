using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Combasnai;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Combasnai
{
    public class SituacionEmbarcacionMenorCombasnaiDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<SituacionEmbarcacionMenorCombasnaiDTO> ObtenerLista()
        {
            List<SituacionEmbarcacionMenorCombasnaiDTO> lista = new List<SituacionEmbarcacionMenorCombasnaiDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_SituacionEmbarcacionMenorCombasnaiListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SituacionEmbarcacionMenorCombasnaiDTO()
                        {
                            SituacionEmbarcacionMenorId = Convert.ToInt32(dr["SituacionEmbarcacionMenorId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            CategoriaEmbarcacion = dr["CategoriaEmbarcacion"].ToString(),
                            DescTipoPlataformaNave = dr["DescTipoPlataformaNave"].ToString(),
                            NombreDependencia = dr["NombreDependencia"].ToString(),
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

        public string AgregarRegistro(SituacionEmbarcacionMenorCombasnaiDTO situacionEmbarcacionMenorCombasnaiDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionEmbarcacionMenorCombasnaiRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionEmbarcacionMenorId", SqlDbType.Int);
                    cmd.Parameters["@SituacionEmbarcacionMenorId"].Value = situacionEmbarcacionMenorCombasnaiDTO.SituacionEmbarcacionMenorId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = situacionEmbarcacionMenorCombasnaiDTO.UnidadNavalId;

                    cmd.Parameters.Add("@CategoriaEmbarcacion", SqlDbType.VarChar,3);
                    cmd.Parameters["@CategoriaEmbarcacion"].Value = situacionEmbarcacionMenorCombasnaiDTO.CategoriaEmbarcacion;

                    cmd.Parameters.Add("@TipoPlataformaNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoPlataformaNaveId"].Value = situacionEmbarcacionMenorCombasnaiDTO.TipoPlataformaNaveId;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = situacionEmbarcacionMenorCombasnaiDTO.DependenciaId;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Ubicacion"].Value = situacionEmbarcacionMenorCombasnaiDTO.Ubicacion;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = situacionEmbarcacionMenorCombasnaiDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = situacionEmbarcacionMenorCombasnaiDTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = situacionEmbarcacionMenorCombasnaiDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@CapacidadOperativaRequeridaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaRequeridaId"].Value = situacionEmbarcacionMenorCombasnaiDTO.CapacidadOperativaRequeridaId;

                    cmd.Parameters.Add("@CondicionId", SqlDbType.Int);
                    cmd.Parameters["@CondicionId"].Value = situacionEmbarcacionMenorCombasnaiDTO.CondicionId;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observacion"].Value = situacionEmbarcacionMenorCombasnaiDTO.Observacion;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionEmbarcacionMenorCombasnaiDTO.UsuarioIngresoRegistro;

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

        public SituacionEmbarcacionMenorCombasnaiDTO BuscarFormato(int Codigo)
        {
            SituacionEmbarcacionMenorCombasnaiDTO situacionEmbarcacionMenorCombasnaiDTO = new SituacionEmbarcacionMenorCombasnaiDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionEmbarcacionMenorCombasnaiEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionEmbarcacionMenorCombasnaiId", SqlDbType.Int);
                    cmd.Parameters["@SituacionEmbarcacionMenorCombasnaiId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        situacionEmbarcacionMenorCombasnaiDTO.SituacionEmbarcacionMenorId = Convert.ToInt32(dr["SituacionEmbarcacionMenorId"]);
                        situacionEmbarcacionMenorCombasnaiDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        situacionEmbarcacionMenorCombasnaiDTO.CategoriaEmbarcacion = dr["CategoriaEmbarcacion"].ToString();
                        situacionEmbarcacionMenorCombasnaiDTO.TipoPlataformaNaveId = Convert.ToInt32(dr["TipoPlataformaNaveId"]);
                        situacionEmbarcacionMenorCombasnaiDTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]);
                        situacionEmbarcacionMenorCombasnaiDTO.Ubicacion = dr["Ubicacion"].ToString();
                        situacionEmbarcacionMenorCombasnaiDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]);
                        situacionEmbarcacionMenorCombasnaiDTO.ProvinciaUbigeoId = Convert.ToInt32(dr["ProvinciaUbigeoId"]);
                        situacionEmbarcacionMenorCombasnaiDTO.DistritoUbigeoId = Convert.ToInt32(dr["DistritoUbigeoId"]);
                        situacionEmbarcacionMenorCombasnaiDTO.CapacidadOperativaRequeridaId = Convert.ToInt32(dr["CapacidadOperativaRequeridaId"]);
                        situacionEmbarcacionMenorCombasnaiDTO.CondicionId = Convert.ToInt32(dr["CondicionId"]);
                        situacionEmbarcacionMenorCombasnaiDTO.Observacion = dr["Observacion"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return situacionEmbarcacionMenorCombasnaiDTO;
        }

        public string ActualizaFormato(SituacionEmbarcacionMenorCombasnaiDTO situacionEmbarcacionMenorCombasnaiDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_SituacionEmbarcacionMenorCombasnaiActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@SituacionEmbarcacionMenorId", SqlDbType.Int);
                    cmd.Parameters["@SituacionEmbarcacionMenorId"].Value = situacionEmbarcacionMenorCombasnaiDTO.SituacionEmbarcacionMenorId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = situacionEmbarcacionMenorCombasnaiDTO.UnidadNavalId;

                    cmd.Parameters.Add("@CategoriaEmbarcacion", SqlDbType.VarChar,3);
                    cmd.Parameters["@CategoriaEmbarcacion"].Value = situacionEmbarcacionMenorCombasnaiDTO.CategoriaEmbarcacion;

                    cmd.Parameters.Add("@TipoPlataformaNaveId", SqlDbType.Int);
                    cmd.Parameters["@TipoPlataformaNaveId"].Value = situacionEmbarcacionMenorCombasnaiDTO.TipoPlataformaNaveId;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = situacionEmbarcacionMenorCombasnaiDTO.DependenciaId;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar,300);
                    cmd.Parameters["@Ubicacion"].Value = situacionEmbarcacionMenorCombasnaiDTO.Ubicacion;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = situacionEmbarcacionMenorCombasnaiDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = situacionEmbarcacionMenorCombasnaiDTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = situacionEmbarcacionMenorCombasnaiDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@CapacidadOperativaRequeridaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaRequeridaId"].Value = situacionEmbarcacionMenorCombasnaiDTO.CapacidadOperativaRequeridaId;

                    cmd.Parameters.Add("@CondicionId", SqlDbType.Int);
                    cmd.Parameters["@CondicionId"].Value = situacionEmbarcacionMenorCombasnaiDTO.CondicionId;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar,300);
                    cmd.Parameters["@Observacion"].Value = situacionEmbarcacionMenorCombasnaiDTO.Observacion;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionEmbarcacionMenorCombasnaiDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(SituacionEmbarcacionMenorCombasnaiDTO situacionEmbarcacionMenorCombasnaiDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionEmbarcacionMenorCombasnaiEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionEmbarcacionMenorId", SqlDbType.Int);
                    cmd.Parameters["@SituacionEmbarcacionMenorId"].Value = situacionEmbarcacionMenorCombasnaiDTO.SituacionEmbarcacionMenorId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionEmbarcacionMenorCombasnaiDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<SituacionEmbarcacionMenorCombasnaiDTO> situacionEmbarcacionMenorCombasnaiDTO)
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
                            foreach (var item in situacionEmbarcacionMenorCombasnaiDTO)
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
