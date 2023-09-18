using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfas;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfas
{
    public class AlistamientoCombustibleLubricanteComfasDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistamientoCombustibleLubricanteComfasDTO> ObtenerLista()
        {
            List<AlistamientoCombustibleLubricanteComfasDTO> lista = new List<AlistamientoCombustibleLubricanteComfasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComfasListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistamientoCombustibleLubricanteComfasDTO()
                        {
                            AlistamientoCombustibleLubricanteId = Convert.ToInt32(dr["AlistamientoCombustibleLubricanteId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescSistemaCombustibleLubricante = dr["DescSistemaCombustibleLubricante"].ToString(),
                            DescSubsistemaCombustibleLubricante = dr["DescSubsistemaCombustibleLubricante"].ToString(),
                            Equipo = Convert.ToInt32(dr["Equipo"]),
                            CombustibleLubricante = Convert.ToInt32(dr["CombustibleLubricante"]),
                            ExistenteGLS = Convert.ToInt32(dr["ExistenteGLS"]),
                            NecesariasGLS = Convert.ToInt32(dr["NecesariasGLS"]),
                            CoeficientePonderacion = Convert.ToInt32(dr["CoeficientePonderacion"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistamientoCombustibleLubricanteComfasDTO alistamientoCombustibleLubricanteComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComfasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = alistamientoCombustibleLubricanteComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@SistemaCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@SistemaCombustibleLubricanteId"].Value = alistamientoCombustibleLubricanteComfasDTO.SistemaCombustibleLubricanteId;

                    cmd.Parameters.Add("@SubsistemaCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@SubsistemaCombustibleLubricanteId"].Value = alistamientoCombustibleLubricanteComfasDTO.SubsistemaCombustibleLubricanteId;

                    cmd.Parameters.Add("@Equipo", SqlDbType.Int);
                    cmd.Parameters["@Equipo"].Value = alistamientoCombustibleLubricanteComfasDTO.Equipo;

                    cmd.Parameters.Add("@CombustibleLubricante", SqlDbType.Int);
                    cmd.Parameters["@CombustibleLubricante"].Value = alistamientoCombustibleLubricanteComfasDTO.CombustibleLubricante;

                    cmd.Parameters.Add("@ExistenteGLS", SqlDbType.Int);
                    cmd.Parameters["@ExistenteGLS"].Value = alistamientoCombustibleLubricanteComfasDTO.ExistenteGLS;

                    cmd.Parameters.Add("@NecesariasGLS", SqlDbType.Int);
                    cmd.Parameters["@NecesariasGLS"].Value = alistamientoCombustibleLubricanteComfasDTO.NecesariasGLS;

                    cmd.Parameters.Add("@CoeficientePonderacion", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderacion"].Value = alistamientoCombustibleLubricanteComfasDTO.CoeficientePonderacion;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoCombustibleLubricanteComfasDTO.UsuarioIngresoRegistro;

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

        public AlistamientoCombustibleLubricanteComfasDTO BuscarFormato(int Codigo)
        {
            AlistamientoCombustibleLubricanteComfasDTO alistamientoCombustibleLubricanteComfasDTO = new AlistamientoCombustibleLubricanteComfasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComfasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        alistamientoCombustibleLubricanteComfasDTO.AlistamientoCombustibleLubricanteId = Convert.ToInt32(dr["AlistamientoCombustibleLubricanteId"]);
                        alistamientoCombustibleLubricanteComfasDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        alistamientoCombustibleLubricanteComfasDTO.SistemaCombustibleLubricanteId = Convert.ToInt32(dr["SistemaCombustibleLubricanteId"]);
                        alistamientoCombustibleLubricanteComfasDTO.SubsistemaCombustibleLubricanteId = Convert.ToInt32(dr["SubsistemaCombustibleLubricanteId"]);
                        alistamientoCombustibleLubricanteComfasDTO.Equipo = Convert.ToInt32(dr["Equipo"]);
                        alistamientoCombustibleLubricanteComfasDTO.CombustibleLubricante = Convert.ToInt32(dr["CombustibleLubricante"]);
                        alistamientoCombustibleLubricanteComfasDTO.ExistenteGLS = Convert.ToInt32(dr["ExistenteGLS"]);
                        alistamientoCombustibleLubricanteComfasDTO.NecesariasGLS = Convert.ToInt32(dr["NecesariasGLS"]);
                        alistamientoCombustibleLubricanteComfasDTO.CoeficientePonderacion = Convert.ToInt32(dr["CoeficientePonderacion"]); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoCombustibleLubricanteComfasDTO;
        }

        public string ActualizaFormato(AlistamientoCombustibleLubricanteComfasDTO alistamientoCombustibleLubricanteComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComfasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = alistamientoCombustibleLubricanteComfasDTO.AlistamientoCombustibleLubricanteId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = alistamientoCombustibleLubricanteComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@SistemaCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@SistemaCombustibleLubricanteId"].Value = alistamientoCombustibleLubricanteComfasDTO.SistemaCombustibleLubricanteId;

                    cmd.Parameters.Add("@SubsistemaCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@SubsistemaCombustibleLubricanteId"].Value = alistamientoCombustibleLubricanteComfasDTO.SubsistemaCombustibleLubricanteId;

                    cmd.Parameters.Add("@Equipo", SqlDbType.Int);
                    cmd.Parameters["@Equipo"].Value = alistamientoCombustibleLubricanteComfasDTO.Equipo;

                    cmd.Parameters.Add("@CombustibleLubricante", SqlDbType.Int);
                    cmd.Parameters["@CombustibleLubricante"].Value = alistamientoCombustibleLubricanteComfasDTO.CombustibleLubricante;

                    cmd.Parameters.Add("@ExistenteGLS", SqlDbType.Int);
                    cmd.Parameters["@ExistenteGLS"].Value = alistamientoCombustibleLubricanteComfasDTO.ExistenteGLS;

                    cmd.Parameters.Add("@NecesariasGLS", SqlDbType.Int);
                    cmd.Parameters["@NecesariasGLS"].Value = alistamientoCombustibleLubricanteComfasDTO.NecesariasGLS;

                    cmd.Parameters.Add("@CoeficientePonderacion", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderacion"].Value = alistamientoCombustibleLubricanteComfasDTO.CoeficientePonderacion;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoCombustibleLubricanteComfasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistamientoCombustibleLubricanteComfasDTO alistamientoCombustibleLubricanteComfasDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComfasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = alistamientoCombustibleLubricanteComfasDTO.AlistamientoCombustibleLubricanteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoCombustibleLubricanteComfasDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<AlistamientoCombustibleLubricanteComfasDTO> alistamientoCombustibleLubricanteComfasDTO)
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
                            foreach (var item in alistamientoCombustibleLubricanteComfasDTO)
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
