using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperama;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperama
{
    public class EfectivoNivelEntrenamientoUnidadDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EfectivoNivelEntrenamientoUnidadDTO> ObtenerLista(int? CargaId = null)
        {
            List<EfectivoNivelEntrenamientoUnidadDTO> lista = new List<EfectivoNivelEntrenamientoUnidadDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EfectivoNivelEntrenamientoUnidadListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EfectivoNivelEntrenamientoUnidadDTO()
                        {
                            EfectivoNivelEntrenamientoUnidadId = Convert.ToInt32(dr["EfectivoNivelEntrenamientoUnidadId"]),
                            DescComandanciaDependencia = dr["DescComandanciaDependencia"].ToString(),
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            DescGradoPersonal = dr["DescGradoPersonal"].ToString(),
                            NivelElemental = Convert.ToDecimal(dr["NivelElemental"]),
                            NivelBasico = Convert.ToDecimal(dr["NivelBasico"]),
                            NivelIntermedio = Convert.ToDecimal(dr["NivelIntermedio"]),
                            NivelAvanzado = Convert.ToDecimal(dr["NivelAvanzado"]),
                            NivelConjunto = Convert.ToDecimal(dr["NivelConjunto"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EfectivoNivelEntrenamientoUnidadDTO efectivoNivelEntrenamientoUnidadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EfectivoNivelEntrenamientoUnidadRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia ", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoComandanciaDependencia "].Value = efectivoNivelEntrenamientoUnidadDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDependencia"].Value = efectivoNivelEntrenamientoUnidadDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoGradoPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonal"].Value = efectivoNivelEntrenamientoUnidadDTO.CodigoGradoPersonal;

                    cmd.Parameters.Add("@NivelElemental", SqlDbType.Decimal);
                    cmd.Parameters["@NivelElemental"].Value = efectivoNivelEntrenamientoUnidadDTO.NivelElemental;

                    cmd.Parameters.Add("@NivelBasico", SqlDbType.Decimal);
                    cmd.Parameters["@NivelBasico"].Value = efectivoNivelEntrenamientoUnidadDTO.NivelBasico;

                    cmd.Parameters.Add("@NivelIntermedio", SqlDbType.Decimal);
                    cmd.Parameters["@NivelIntermedio"].Value = efectivoNivelEntrenamientoUnidadDTO.NivelIntermedio;

                    cmd.Parameters.Add("@NivelAvanzado", SqlDbType.Decimal);
                    cmd.Parameters["@NivelAvanzado"].Value = efectivoNivelEntrenamientoUnidadDTO.NivelAvanzado;

                    cmd.Parameters.Add("@NivelConjunto", SqlDbType.Decimal);
                    cmd.Parameters["@NivelConjunto"].Value = efectivoNivelEntrenamientoUnidadDTO.NivelConjunto;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = efectivoNivelEntrenamientoUnidadDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = efectivoNivelEntrenamientoUnidadDTO.UsuarioIngresoRegistro;

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

        public EfectivoNivelEntrenamientoUnidadDTO BuscarFormato(int Codigo)
        {
            EfectivoNivelEntrenamientoUnidadDTO efectivoNivelEntrenamientoUnidadDTO = new EfectivoNivelEntrenamientoUnidadDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EfectivoNivelEntrenamientoUnidadEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EfectivoNivelEntrenamientoUnidadId", SqlDbType.Int);
                    cmd.Parameters["@EfectivoNivelEntrenamientoUnidadId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        efectivoNivelEntrenamientoUnidadDTO.EfectivoNivelEntrenamientoUnidadId = Convert.ToInt32(dr["EfectivoNivelEntrenamientoUnidadId"]);
                        efectivoNivelEntrenamientoUnidadDTO.CodigoComandanciaDependencia = dr["CodigoComandanciaDependencia"].ToString();
                        efectivoNivelEntrenamientoUnidadDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        efectivoNivelEntrenamientoUnidadDTO.CodigoGradoPersonal = dr["CodigoGradoPersonal"].ToString(); 
                        efectivoNivelEntrenamientoUnidadDTO.NivelElemental = Convert.ToDecimal(dr["NivelElemental"]);
                        efectivoNivelEntrenamientoUnidadDTO.NivelBasico = Convert.ToDecimal(dr["NivelBasico"]);
                        efectivoNivelEntrenamientoUnidadDTO.NivelIntermedio = Convert.ToDecimal(dr["NivelIntermedio"]);
                        efectivoNivelEntrenamientoUnidadDTO.NivelAvanzado = Convert.ToDecimal(dr["NivelAvanzado"]);
                        efectivoNivelEntrenamientoUnidadDTO.NivelConjunto = Convert.ToDecimal(dr["NivelConjunto"]); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return efectivoNivelEntrenamientoUnidadDTO;
        }

        public string ActualizaFormato(EfectivoNivelEntrenamientoUnidadDTO efectivoNivelEntrenamientoUnidadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EfectivoNivelEntrenamientoUnidadActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EfectivoNivelEntrenamientoUnidadId", SqlDbType.Int);
                    cmd.Parameters["@EfectivoNivelEntrenamientoUnidadId"].Value = efectivoNivelEntrenamientoUnidadDTO.EfectivoNivelEntrenamientoUnidadId;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComandanciaDependencia "].Value = efectivoNivelEntrenamientoUnidadDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = efectivoNivelEntrenamientoUnidadDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoGradoPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonal"].Value = efectivoNivelEntrenamientoUnidadDTO.CodigoGradoPersonal;

                    cmd.Parameters.Add("@NivelElemental", SqlDbType.Decimal);
                    cmd.Parameters["@NivelElemental"].Value = efectivoNivelEntrenamientoUnidadDTO.NivelElemental;

                    cmd.Parameters.Add("@NivelBasico", SqlDbType.Decimal);
                    cmd.Parameters["@NivelBasico"].Value = efectivoNivelEntrenamientoUnidadDTO.NivelBasico;

                    cmd.Parameters.Add("@NivelIntermedio", SqlDbType.Decimal);
                    cmd.Parameters["@NivelIntermedio"].Value = efectivoNivelEntrenamientoUnidadDTO.NivelIntermedio;

                    cmd.Parameters.Add("@NivelAvanzado", SqlDbType.Decimal);
                    cmd.Parameters["@NivelAvanzado"].Value = efectivoNivelEntrenamientoUnidadDTO.NivelAvanzado;

                    cmd.Parameters.Add("@NivelConjunto", SqlDbType.Decimal);
                    cmd.Parameters["@NivelConjunto"].Value = efectivoNivelEntrenamientoUnidadDTO.NivelConjunto;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = efectivoNivelEntrenamientoUnidadDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EfectivoNivelEntrenamientoUnidadDTO efectivoNivelEntrenamientoUnidadDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EfectivoNivelEntrenamientoUnidadEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EfectivoNivelEntrenamientoUnidadId", SqlDbType.Int);
                    cmd.Parameters["@EfectivoNivelEntrenamientoUnidadId"].Value = efectivoNivelEntrenamientoUnidadDTO.EfectivoNivelEntrenamientoUnidadId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = efectivoNivelEntrenamientoUnidadDTO.UsuarioIngresoRegistro;

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
        public string InsertarDatos(DataTable datos)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_EfectivoNivelEntrenamientoUnidadRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EfectivoNivelEntrenamientoUnidad", SqlDbType.Structured);
                    cmd.Parameters["@EfectivoNivelEntrenamientoUnidad"].TypeName = "Formato.EfectivoNivelEntrenamientoUnidad";
                    cmd.Parameters["@EfectivoNivelEntrenamientoUnidad"].Value = datos;

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
    }
}
