using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Jesehin;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Jesehin
{
    public class SituacionOperatividadEquipoJesehinDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<SituacionOperatividadEquipoJesehinDTO> ObtenerLista()
        {
            List<SituacionOperatividadEquipoJesehinDTO> lista = new List<SituacionOperatividadEquipoJesehinDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoJesehinListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SituacionOperatividadEquipoJesehinDTO()
                        {
                            SituacionOperatividadEquipoId = Convert.ToInt32(dr["SituacionOperatividadEquipoId"]),
                            Clasificacion = dr["Clasificacion"].ToString(),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            Ubicacion = dr["Ubicacion"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            DescCondicion = dr["DescCondicion"].ToString(),
                            Observaciones = dr["Observaciones"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(SituacionOperatividadEquipoJesehinDTO formatoSituacionOperatividadEquipoJesehinDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoJesehinRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadEquipoId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadEquipoId"].Value = formatoSituacionOperatividadEquipoJesehinDTO.SituacionOperatividadEquipoId;

                    cmd.Parameters.Add("@DescripcionMaterialId", SqlDbType.Int);
                    cmd.Parameters["@DescripcionMaterialId"].Value = formatoSituacionOperatividadEquipoJesehinDTO.DescripcionMaterialId;

                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int);
                    cmd.Parameters["@Cantidad"].Value = formatoSituacionOperatividadEquipoJesehinDTO.Cantidad;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = formatoSituacionOperatividadEquipoJesehinDTO.UnidadNavalId;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Ubicacion"].Value = formatoSituacionOperatividadEquipoJesehinDTO.Ubicacion;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = formatoSituacionOperatividadEquipoJesehinDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = formatoSituacionOperatividadEquipoJesehinDTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = formatoSituacionOperatividadEquipoJesehinDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@Condicion", SqlDbType.Int);
                    cmd.Parameters["@Condicion"].Value = formatoSituacionOperatividadEquipoJesehinDTO.CondicionId;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Observaciones"].Value = formatoSituacionOperatividadEquipoJesehinDTO.Observaciones;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = formatoSituacionOperatividadEquipoJesehinDTO.UsuarioIngresoRegistro;

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

        public SituacionOperatividadEquipoJesehinDTO BuscarFormato(int Codigo)
        {
            SituacionOperatividadEquipoJesehinDTO formatoSituacionOperatividadEquipoJesehinDTO = new SituacionOperatividadEquipoJesehinDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoJesehinEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadEquipoId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadEquipoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        formatoSituacionOperatividadEquipoJesehinDTO.SituacionOperatividadEquipoId = Convert.ToInt32(dr["SituacionOperatividadEquipoId"]);
                        formatoSituacionOperatividadEquipoJesehinDTO.DescripcionMaterialId = Convert.ToInt32(dr["DescripcionMaterialId"]);
                        formatoSituacionOperatividadEquipoJesehinDTO.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                        formatoSituacionOperatividadEquipoJesehinDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        formatoSituacionOperatividadEquipoJesehinDTO.Ubicacion = dr["Ubicacion"].ToString();
                        formatoSituacionOperatividadEquipoJesehinDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]);
                        formatoSituacionOperatividadEquipoJesehinDTO.ProvinciaUbigeoId = Convert.ToInt32(dr["ProvinciaUbigeoId"]);
                        formatoSituacionOperatividadEquipoJesehinDTO.DistritoUbigeoId = Convert.ToInt32(dr["DistritoUbigeoId"]);
                        formatoSituacionOperatividadEquipoJesehinDTO.CondicionId = Convert.ToInt32(dr["CondicionId"]);
                        formatoSituacionOperatividadEquipoJesehinDTO.Observaciones = dr["Observaciones"].ToString(); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return formatoSituacionOperatividadEquipoJesehinDTO;
        }

        public string ActualizaFormato(SituacionOperatividadEquipoJesehinDTO formatoSituacionOperatividadEquipoJesehinDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoJesehinActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@SituacionOperatividadEquipoId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadEquipoId"].Value = formatoSituacionOperatividadEquipoJesehinDTO.SituacionOperatividadEquipoId;

                    cmd.Parameters.Add("@DescripcionMaterialId", SqlDbType.Int);
                    cmd.Parameters["@DescripcionMaterialId"].Value = formatoSituacionOperatividadEquipoJesehinDTO.DescripcionMaterialId;

                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int);
                    cmd.Parameters["@Cantidad"].Value = formatoSituacionOperatividadEquipoJesehinDTO.Cantidad;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = formatoSituacionOperatividadEquipoJesehinDTO.UnidadNavalId;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Ubicacion"].Value = formatoSituacionOperatividadEquipoJesehinDTO.Ubicacion;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = formatoSituacionOperatividadEquipoJesehinDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = formatoSituacionOperatividadEquipoJesehinDTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = formatoSituacionOperatividadEquipoJesehinDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@Condicion", SqlDbType.Int);
                    cmd.Parameters["@Condicion"].Value = formatoSituacionOperatividadEquipoJesehinDTO.CondicionId;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Observaciones"].Value = formatoSituacionOperatividadEquipoJesehinDTO.Observaciones;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = formatoSituacionOperatividadEquipoJesehinDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(SituacionOperatividadEquipoJesehinDTO formatoSituacionOperatividadEquipoJesehinDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoJesehinEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadEquipoId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadEquipoId"].Value = formatoSituacionOperatividadEquipoJesehinDTO.SituacionOperatividadEquipoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = formatoSituacionOperatividadEquipoJesehinDTO.UsuarioIngresoRegistro;

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

        public bool InsercionMasiva(IEnumerable<SituacionOperatividadEquipoJesehinDTO> emisionNotaPrensaDTO)
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
