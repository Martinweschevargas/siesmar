using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comestre;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comestre
{
    public class SituacionOperatividadEquipoComestreDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<SituacionOperatividadEquipoComestreDTO> ObtenerLista()
        {
            List<SituacionOperatividadEquipoComestreDTO> lista = new List<SituacionOperatividadEquipoComestreDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoComestreListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SituacionOperatividadEquipoComestreDTO()
                        {
                            SituacionOperatividadEquipoId = Convert.ToInt32(dr["SituacionOperatividadEquipoId"]),
                            Clasificacion = dr["Clasificacion"].ToString(),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            CodigoUnidad = dr["CodigoUnidad"].ToString(),
                            Ubicacion = dr["Ubicacion"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            Condicion = dr["Condicion"].ToString(),
                            Observacion = dr["Observacion"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(SituacionOperatividadEquipoComestreDTO situacionOperatividadEquipoComestreDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoComestreRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescripcionMaterialId", SqlDbType.Int);
                    cmd.Parameters["@DescripcionMaterialId"].Value = situacionOperatividadEquipoComestreDTO.DescripcionMaterialId;

                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int);
                    cmd.Parameters["@Cantidad"].Value = situacionOperatividadEquipoComestreDTO.Cantidad;

                    cmd.Parameters.Add("@CodigoUnidad", SqlDbType.VarChar,10);
                    cmd.Parameters["@CodigoUnidad"].Value = situacionOperatividadEquipoComestreDTO.CodigoUnidad;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar,50);
                    cmd.Parameters["@Ubicacion"].Value = situacionOperatividadEquipoComestreDTO.Ubicacion;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = situacionOperatividadEquipoComestreDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = situacionOperatividadEquipoComestreDTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = situacionOperatividadEquipoComestreDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@Condicion", SqlDbType.VarChar,2);
                    cmd.Parameters["@Condicion"].Value = situacionOperatividadEquipoComestreDTO.Condicion;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar,250);
                    cmd.Parameters["@Observacion"].Value = situacionOperatividadEquipoComestreDTO.Observacion;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperatividadEquipoComestreDTO.UsuarioIngresoRegistro;

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

        public SituacionOperatividadEquipoComestreDTO BuscarFormato(int Codigo)
        {
            SituacionOperatividadEquipoComestreDTO situacionOperatividadEquipoComestreDTO = new SituacionOperatividadEquipoComestreDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoComestreEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadEquipoId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadEquipoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        situacionOperatividadEquipoComestreDTO.SituacionOperatividadEquipoId = Convert.ToInt32(dr["SituacionOperatividadEquipoId"]);
                        situacionOperatividadEquipoComestreDTO.DescripcionMaterialId = Convert.ToInt32(dr["DescripcionMaterialId"]);
                        situacionOperatividadEquipoComestreDTO.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                        situacionOperatividadEquipoComestreDTO.CodigoUnidad = dr["CodigoUnidad"].ToString();
                        situacionOperatividadEquipoComestreDTO.Ubicacion = dr["Ubicacion"].ToString();
                        situacionOperatividadEquipoComestreDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]);
                        situacionOperatividadEquipoComestreDTO.ProvinciaUbigeoId = Convert.ToInt32(dr["ProvinciaUbigeoId"]);
                        situacionOperatividadEquipoComestreDTO.DistritoUbigeoId = Convert.ToInt32(dr["DistritoUbigeoId"]);
                        situacionOperatividadEquipoComestreDTO.Condicion = dr["Condicion"].ToString();
                        situacionOperatividadEquipoComestreDTO.Observacion = dr["Observacion"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return situacionOperatividadEquipoComestreDTO;
        }

        public string ActualizaFormato(SituacionOperatividadEquipoComestreDTO situacionOperatividadEquipoComestreDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoComestreActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@SituacionOperatividadEquipoId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadEquipoId"].Value = situacionOperatividadEquipoComestreDTO.SituacionOperatividadEquipoId;

                    cmd.Parameters.Add("@DescripcionMaterialId", SqlDbType.Int);
                    cmd.Parameters["@DescripcionMaterialId"].Value = situacionOperatividadEquipoComestreDTO.DescripcionMaterialId;

                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int);
                    cmd.Parameters["@Cantidad"].Value = situacionOperatividadEquipoComestreDTO.Cantidad;

                    cmd.Parameters.Add("@CodigoUnidad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoUnidad"].Value = situacionOperatividadEquipoComestreDTO.CodigoUnidad;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ubicacion"].Value = situacionOperatividadEquipoComestreDTO.Ubicacion;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = situacionOperatividadEquipoComestreDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = situacionOperatividadEquipoComestreDTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = situacionOperatividadEquipoComestreDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@Condicion", SqlDbType.VarChar, 2);
                    cmd.Parameters["@Condicion"].Value = situacionOperatividadEquipoComestreDTO.Condicion;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar, 250);
                    cmd.Parameters["@Observacion"].Value = situacionOperatividadEquipoComestreDTO.Observacion;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperatividadEquipoComestreDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(SituacionOperatividadEquipoComestreDTO situacionOperatividadEquipoComestreDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoComestreEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadEquipoId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadEquipoId"].Value = situacionOperatividadEquipoComestreDTO.SituacionOperatividadEquipoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperatividadEquipoComestreDTO.UsuarioIngresoRegistro;

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

        public bool InsercionMasiva(IEnumerable<SituacionOperatividadEquipoComestreDTO> situacionOperatividadEquipoComestreDTO)
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
                            foreach (var item in situacionOperatividadEquipoComestreDTO)
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
