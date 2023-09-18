using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Combima1;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Combima1
{
    public class AlistCombustibleLubricanteCombima1DAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistCombustibleLubricanteCombima1DTO> ObtenerLista()
        {
            List<AlistCombustibleLubricanteCombima1DTO> lista = new List<AlistCombustibleLubricanteCombima1DTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistCombustibleLubricanteCombima1Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistCombustibleLubricanteCombima1DTO()
                        {
                            AlistamientoCombustibleLubricanteId = Convert.ToInt32(dr["AlistamientoCombustibleLubricanteId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            Articulo = dr["DescUnidadNaval"].ToString(),
                            Equipo = dr["DescUnidadNaval"].ToString(),
                            DescUnidadMedidad = dr["DescUnidadNaval"].ToString(),
                            Cargo = Convert.ToInt32(dr["Cargo"]),
                            Aumento = Convert.ToInt32(dr["Aumento"]),
                            Consumo = Convert.ToInt32(dr["Consumo"]),
                            Existencia = Convert.ToInt32(dr["Existencia"]),
                            PromedioPonderado = Convert.ToDecimal(dr["PromedioPonderado"]),
                            SubPromedioParcial = Convert.ToDecimal(dr["SubPromedioParcial"]),


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistCombustibleLubricanteCombima1DTO alistCombustibleLubricanteCombima1DTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistCombustibleLubricanteCombima1Registrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = alistCombustibleLubricanteCombima1DTO.UnidadNavalId;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricante2Id", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricante2Id"].Value = alistCombustibleLubricanteCombima1DTO.AlistamientoCombustibleLubricante2Id;

                    cmd.Parameters.Add("@PromedioPonderado", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioPonderado"].Value = alistCombustibleLubricanteCombima1DTO.PromedioPonderado;

                    cmd.Parameters.Add("@SubPromedioParcial", SqlDbType.Decimal);
                    cmd.Parameters["@UnidadNavSubPromedioParcialalId"].Value = alistCombustibleLubricanteCombima1DTO.SubPromedioParcial;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistCombustibleLubricanteCombima1DTO.UsuarioIngresoRegistro;

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

        public AlistCombustibleLubricanteCombima1DTO BuscarFormato(int Codigo)
        {
            AlistCombustibleLubricanteCombima1DTO alistCombustibleLubricanteCombima1DTO = new AlistCombustibleLubricanteCombima1DTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistCombustibleLubricanteCombima1Encontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        alistCombustibleLubricanteCombima1DTO.AlistamientoCombustibleLubricanteId = Convert.ToInt32(dr["AlistamientoCombustibleLubricanteId"]);
                        alistCombustibleLubricanteCombima1DTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        alistCombustibleLubricanteCombima1DTO.AlistamientoCombustibleLubricante2Id = Convert.ToInt32(dr["AlistamientoCombustibleLubricante2Id"]);
                        alistCombustibleLubricanteCombima1DTO.PromedioPonderado = Convert.ToDecimal(dr["AlistamientoCombustibleLubricante2Id"]);
                        alistCombustibleLubricanteCombima1DTO.SubPromedioParcial = Convert.ToDecimal(dr["AlistamientoCombustibleLubricante2Id"]);


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistCombustibleLubricanteCombima1DTO;
        }

        public string ActualizaFormato(AlistCombustibleLubricanteCombima1DTO alistCombustibleLubricanteCombima1DTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistCombustibleLubricanteCombima1Actualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = alistCombustibleLubricanteCombima1DTO.AlistamientoCombustibleLubricanteId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = alistCombustibleLubricanteCombima1DTO.UnidadNavalId;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricante2Id", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricante2Id"].Value = alistCombustibleLubricanteCombima1DTO.AlistamientoCombustibleLubricante2Id;

                    cmd.Parameters.Add("@PromedioPonderado", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioPonderado"].Value = alistCombustibleLubricanteCombima1DTO.PromedioPonderado;

                    cmd.Parameters.Add("@SubPromedioParcial", SqlDbType.Decimal);
                    cmd.Parameters["@UnidadNavSubPromedioParcialalId"].Value = alistCombustibleLubricanteCombima1DTO.SubPromedioParcial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistCombustibleLubricanteCombima1DTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistCombustibleLubricanteCombima1DTO alistCombustibleLubricanteCombima1DTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistCombustibleLubricanteCombima1Eliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = alistCombustibleLubricanteCombima1DTO.AlistamientoCombustibleLubricanteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistCombustibleLubricanteCombima1DTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<AlistCombustibleLubricanteCombima1DTO> alistCombustibleLubricanteCombima1DTO)
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
                            foreach (var item in alistCombustibleLubricanteCombima1DTO)
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
