using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfas;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfas
{
    public class ParteNumericoPersonalComfasDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ParteNumericoPersonalComfasDTO> ObtenerLista()
        {
            List<ParteNumericoPersonalComfasDTO> lista = new List<ParteNumericoPersonalComfasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ParteNumericoPersonalComfasListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ParteNumericoPersonalComfasDTO()
                        {
                            ParteNumericoPersonalComfasId = Convert.ToInt32(dr["ParteNumericoPersonalComfasId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            FechaParte = (dr["FechaParte"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescGradoPersonalMilitar = dr["DescGradoPersonalMilitar"].ToString(),
                            DescEspecialidadGenericaPersonal = dr["DescEspecialidadGenericaPersonal"].ToString(),
                            PlantaOrganica = Convert.ToInt32(dr["PlantaOrganica"]),
                            PlantaActual = Convert.ToInt32(dr["PlantaActual"]),
                            EfectivoDeficit = Convert.ToInt32(dr["EfectivoDeficit"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ParteNumericoPersonalComfasDTO ParteNumericoPersonalComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ParteNumericoPersonalComfasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = ParteNumericoPersonalComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@FechaParte", SqlDbType.Date);
                    cmd.Parameters["@FechaParte"].Value = ParteNumericoPersonalComfasDTO.FechaParte;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = ParteNumericoPersonalComfasDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@EspecialidadGenericaPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaPersonalId"].Value = ParteNumericoPersonalComfasDTO.EspecialidadGenericaPersonalId;

                    cmd.Parameters.Add("@PlantaOrganica", SqlDbType.Int);
                    cmd.Parameters["@PlantaOrganica"].Value = ParteNumericoPersonalComfasDTO.PlantaOrganica;

                    cmd.Parameters.Add("@PlantaActual", SqlDbType.Int);
                    cmd.Parameters["@PlantaActual"].Value = ParteNumericoPersonalComfasDTO.PlantaActual;

                    cmd.Parameters.Add("@EfectivoDeficit", SqlDbType.Int);
                    cmd.Parameters["@EfectivoDeficit"].Value = ParteNumericoPersonalComfasDTO.EfectivoDeficit;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ParteNumericoPersonalComfasDTO.UsuarioIngresoRegistro;

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

        public ParteNumericoPersonalComfasDTO BuscarFormato(int Codigo)
        {
            ParteNumericoPersonalComfasDTO ParteNumericoPersonalComfasDTO = new ParteNumericoPersonalComfasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ParteNumericoPersonalComfasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ParteNumericoPersonalComfasId", SqlDbType.Int);
                    cmd.Parameters["@ParteNumericoPersonalComfasId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        ParteNumericoPersonalComfasDTO.ParteNumericoPersonalComfasId = Convert.ToInt32(dr["ParteNumericoPersonalComfasId"]);
                        ParteNumericoPersonalComfasDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        ParteNumericoPersonalComfasDTO.FechaParte = Convert.ToDateTime(dr["FechaParte"]).ToString("yyy-MM-dd");
                        ParteNumericoPersonalComfasDTO.GradoPersonalMilitarId = Convert.ToInt32(dr["GradoPersonalMilitarId"]);
                        ParteNumericoPersonalComfasDTO.EspecialidadGenericaPersonalId = Convert.ToInt32(dr["EspecialidadGenericaPersonalId"]);
                        ParteNumericoPersonalComfasDTO.PlantaOrganica = Convert.ToInt32(dr["PlantaOrganica"]);
                        ParteNumericoPersonalComfasDTO.PlantaActual = Convert.ToInt32(dr["PlantaActual"]);
                        ParteNumericoPersonalComfasDTO.EfectivoDeficit = Convert.ToInt32(dr["EfectivoDeficit"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ParteNumericoPersonalComfasDTO;
        }

        public string ActualizaFormato(ParteNumericoPersonalComfasDTO ParteNumericoPersonalComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ParteNumericoPersonalComfasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ParteNumericoPersonalComfasId", SqlDbType.Int);
                    cmd.Parameters["@ParteNumericoPersonalComfasId"].Value = ParteNumericoPersonalComfasDTO.ParteNumericoPersonalComfasId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = ParteNumericoPersonalComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@FechaParte", SqlDbType.Date);
                    cmd.Parameters["@FechaParte"].Value = ParteNumericoPersonalComfasDTO.FechaParte;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = ParteNumericoPersonalComfasDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@EspecialidadGenericaPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaPersonalId"].Value = ParteNumericoPersonalComfasDTO.EspecialidadGenericaPersonalId;

                    cmd.Parameters.Add("@PlantaOrganica", SqlDbType.Int);
                    cmd.Parameters["@PlantaOrganica"].Value = ParteNumericoPersonalComfasDTO.PlantaOrganica;

                    cmd.Parameters.Add("@PlantaActual", SqlDbType.Int);
                    cmd.Parameters["@PlantaActual"].Value = ParteNumericoPersonalComfasDTO.PlantaActual;

                    cmd.Parameters.Add("@EfectivoDeficit", SqlDbType.Int);
                    cmd.Parameters["@EfectivoDeficit"].Value = ParteNumericoPersonalComfasDTO.EfectivoDeficit;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ParteNumericoPersonalComfasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ParteNumericoPersonalComfasDTO ParteNumericoPersonalComfasDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ParteNumericoPersonalComfasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ParteNumericoPersonalComfasId", SqlDbType.Int);
                    cmd.Parameters["@ParteNumericoPersonalComfasId"].Value = ParteNumericoPersonalComfasDTO.ParteNumericoPersonalComfasId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ParteNumericoPersonalComfasDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<ParteNumericoPersonalComfasDTO> ParteNumericoPersonalComfasDTO)
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
                            foreach (var item in ParteNumericoPersonalComfasDTO)
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
