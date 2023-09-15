using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comescla;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comescla
{
    public class OperatividadEquipoMaterialAntidisturbioComesclaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<OperatividadEquipoMaterialAntidisturbioComesclaDTO> ObtenerLista()
        {
            List<OperatividadEquipoMaterialAntidisturbioComesclaDTO> lista = new List<OperatividadEquipoMaterialAntidisturbioComesclaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_OperatividadEquipoMaterialAntidisturbioComesclaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new OperatividadEquipoMaterialAntidisturbioComesclaDTO()
                        {
                            OperatividadEquiposMaterialAntidisturbioId = Convert.ToInt32(dr["OperatividadEquiposMaterialAntidisturbioId"]),
                            DescDescripcionMaterial = dr["DescDescripcionMaterial"].ToString(),
                            CantidadMaterial = Convert.ToInt32(dr["CantidadMaterial"]),
                            Ubicacion = dr["Ubicacion"].ToString(),
                            DescDepartamentoUbigeo = dr["DescDepartamentoUbigeo"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            DescCondicion = dr["DescCondicion"].ToString(),
                            Observacion = dr["Observacion"].ToString(),


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(OperatividadEquipoMaterialAntidisturbioComesclaDTO operEquipoMaterialAntidisturbioDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_OperatividadEquipoMaterialAntidisturbioComesclaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OperatividadEquiposMaterialAntidisturbioId", SqlDbType.Int);
                    cmd.Parameters["@OperatividadEquiposMaterialAntidisturbioId"].Value = operEquipoMaterialAntidisturbioDTO.OperatividadEquiposMaterialAntidisturbioId;

                    cmd.Parameters.Add("@DescripcionMaterialId", SqlDbType.Int);
                    cmd.Parameters["@DescripcionMaterialId"].Value = operEquipoMaterialAntidisturbioDTO.DescripcionMaterialId;

                    cmd.Parameters.Add("@CantidadMaterial", SqlDbType.Int);
                    cmd.Parameters["@CantidadMaterial"].Value = operEquipoMaterialAntidisturbioDTO.CantidadMaterial;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Ubicacion"].Value = operEquipoMaterialAntidisturbioDTO.Ubicacion;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = operEquipoMaterialAntidisturbioDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = operEquipoMaterialAntidisturbioDTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = operEquipoMaterialAntidisturbioDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@CondicionId", SqlDbType.Int);
                    cmd.Parameters["@CondicionId"].Value = operEquipoMaterialAntidisturbioDTO.CondicionId;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observacion"].Value = operEquipoMaterialAntidisturbioDTO.Observacion;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = operEquipoMaterialAntidisturbioDTO.UsuarioIngresoRegistro;

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

        public OperatividadEquipoMaterialAntidisturbioComesclaDTO BuscarFormato(int Codigo)
        {
            OperatividadEquipoMaterialAntidisturbioComesclaDTO operEquipoMaterialAntidisturbioDTO = new OperatividadEquipoMaterialAntidisturbioComesclaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_OperatividadEquipoMaterialAntidisturbioComesclaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OperatividadEquiposMaterialAntidisturbioId", SqlDbType.Int);
                    cmd.Parameters["@OperatividadEquiposMaterialAntidisturbioId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        operEquipoMaterialAntidisturbioDTO.OperatividadEquiposMaterialAntidisturbioId = Convert.ToInt32(dr["OperatividadEquiposMaterialAntidisturbioId"]);
                        operEquipoMaterialAntidisturbioDTO.DescripcionMaterialId = Convert.ToInt32(dr["DescripcionMaterialId"]);
                        operEquipoMaterialAntidisturbioDTO.CantidadMaterial = Convert.ToInt32(dr["CantidadMaterial"]);
                        operEquipoMaterialAntidisturbioDTO.Ubicacion = dr["Ubicacion"].ToString();
                        operEquipoMaterialAntidisturbioDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]);
                        operEquipoMaterialAntidisturbioDTO.ProvinciaUbigeoId = Convert.ToInt32(dr["ProvinciaUbigeoId"]);
                        operEquipoMaterialAntidisturbioDTO.DistritoUbigeoId = Convert.ToInt32(dr["DistritoUbigeoId"]);
                        operEquipoMaterialAntidisturbioDTO.CondicionId = Convert.ToInt32(dr["CondicionId"]);
                        operEquipoMaterialAntidisturbioDTO.Observacion = dr["Observacion"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return operEquipoMaterialAntidisturbioDTO;
        }

        public string ActualizaFormato(OperatividadEquipoMaterialAntidisturbioComesclaDTO operEquipoMaterialAntidisturbioDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_OperatividadEquipoMaterialAntidisturbioComesclaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@OperatividadEquiposMaterialAntidisturbioId", SqlDbType.Int);
                    cmd.Parameters["@OperatividadEquiposMaterialAntidisturbioId"].Value = operEquipoMaterialAntidisturbioDTO.OperatividadEquiposMaterialAntidisturbioId;

                    cmd.Parameters.Add("@DescripcionMaterialId", SqlDbType.Int);
                    cmd.Parameters["@DescripcionMaterialId"].Value = operEquipoMaterialAntidisturbioDTO.DescripcionMaterialId;

                    cmd.Parameters.Add("@CantidadMaterial", SqlDbType.Int);
                    cmd.Parameters["@CantidadMaterial"].Value = operEquipoMaterialAntidisturbioDTO.CantidadMaterial;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Ubicacion"].Value = operEquipoMaterialAntidisturbioDTO.Ubicacion;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = operEquipoMaterialAntidisturbioDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = operEquipoMaterialAntidisturbioDTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = operEquipoMaterialAntidisturbioDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@CondicionId", SqlDbType.Int);
                    cmd.Parameters["@CondicionId"].Value = operEquipoMaterialAntidisturbioDTO.CondicionId;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observacion"].Value = operEquipoMaterialAntidisturbioDTO.Observacion;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = operEquipoMaterialAntidisturbioDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(OperatividadEquipoMaterialAntidisturbioComesclaDTO operEquipoMaterialAntidisturbioDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_OperatividadEquipoMaterialAntidisturbioComesclaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OperatividadEquiposMaterialAntidisturbioId", SqlDbType.Int);
                    cmd.Parameters["@OperatividadEquiposMaterialAntidisturbioId"].Value = operEquipoMaterialAntidisturbioDTO.OperatividadEquiposMaterialAntidisturbioId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = operEquipoMaterialAntidisturbioDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<OperatividadEquipoMaterialAntidisturbioComesclaDTO> bandaMusicoComesclaDTO)
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
                            foreach (var item in bandaMusicoComesclaDTO)
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
