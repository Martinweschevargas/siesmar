using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comzocuatro
{
    public class SituacionBuqueAuxiEmbarcMenorComzocuatroDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<SituacionBuqueAuxiEmbarcMenorComzocuatroDTO> ObtenerLista(int? CargaId = null)
        {
            List<SituacionBuqueAuxiEmbarcMenorComzocuatroDTO> lista = new List<SituacionBuqueAuxiEmbarcMenorComzocuatroDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_SituacionBuqueAuxiEmbarcMenorComzocuatroListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SituacionBuqueAuxiEmbarcMenorComzocuatroDTO()
                        {
                            SituacionBuqueAuxiliarEmbarcacionMenorId = Convert.ToInt32(dr["SituacionBuqueAuxiliarEmbarcacionMenorId"]),
                            CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString(),
                            CodigoTipoNave = dr["CodigoTipoNave"].ToString(),
                            DescTipoPlataformaNave = dr["DescTipoPlataformaNave"].ToString(),
                            CodigoDependencia = dr["CodigoDependencia"].ToString(),
                            Ubicacion = dr["Ubicacion"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            DescCapacidadOperativaRequerida = dr["DescCapacidadOperativaRequerida"].ToString(),
                            DescCondicion = dr["DescCondicion"].ToString(),
                            Observacion = dr["Observacion"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(SituacionBuqueAuxiEmbarcMenorComzocuatroDTO situacionBuqueAuxiEmbarcMenorComzocuatroDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionBuqueAuxiEmbarcMenorComzocuatroRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoTipoNave", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoNave"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoTipoNave;

                    cmd.Parameters.Add("@CodigoPlataformaNave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPlataformaNave"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoPlataformaNave;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoDependencia;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Ubicacion"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.Ubicacion;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CodigoCapacidadOperativaRequerida", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativaRequerida"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoCapacidadOperativaRequerida;

                    cmd.Parameters.Add("@CodigoCondicion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicion"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoCondicion;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observacion"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.Observacion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.UsuarioIngresoRegistro;

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

        public SituacionBuqueAuxiEmbarcMenorComzocuatroDTO BuscarFormato(int Codigo)
        {
            SituacionBuqueAuxiEmbarcMenorComzocuatroDTO situacionBuqueAuxiEmbarcMenorComzocuatroDTO = new SituacionBuqueAuxiEmbarcMenorComzocuatroDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionBuqueAuxiEmbarcMenorComzocuatroEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionBuqueAuxiliarEmbarcacionMenorId", SqlDbType.Int);
                    cmd.Parameters["@SituacionBuqueAuxiliarEmbarcacionMenorId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        situacionBuqueAuxiEmbarcMenorComzocuatroDTO.SituacionBuqueAuxiliarEmbarcacionMenorId = Convert.ToInt32(dr["SituacionBuqueAuxiliarEmbarcacionMenorId"]);
                        situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoTipoNave = dr["Ubicacion"].ToString();
                        situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoPlataformaNave = dr["CodigoPlataformaNave"].ToString(); 
                        situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        situacionBuqueAuxiEmbarcMenorComzocuatroDTO.Ubicacion = dr["Ubicacion"].ToString();
                        situacionBuqueAuxiEmbarcMenorComzocuatroDTO.DistritoUbigeo = dr["DistritoUbigeo"].ToString(); 
                        situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoCapacidadOperativaRequerida = dr["CodigoCapacidadOperativaRequerida"].ToString();
                        situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoCondicion = dr["CodigoCondicion"].ToString(); 
                        situacionBuqueAuxiEmbarcMenorComzocuatroDTO.Observacion = dr["Observacion"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return situacionBuqueAuxiEmbarcMenorComzocuatroDTO;
        }

        public string ActualizaFormato(SituacionBuqueAuxiEmbarcMenorComzocuatroDTO situacionBuqueAuxiEmbarcMenorComzocuatroDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_SituacionBuqueAuxiEmbarcMenorComzocuatroActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@SituacionBuqueAuxiliarEmbarcacionMenorId", SqlDbType.Int);
                    cmd.Parameters["@SituacionBuqueAuxiliarEmbarcacionMenorId"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.SituacionBuqueAuxiliarEmbarcacionMenorId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.Int);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoTipoNave", SqlDbType.VarChar);
                    cmd.Parameters["@CodigoTipoNave"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoTipoNave;

                    cmd.Parameters.Add("@CodigoPlataformaNave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPlataformaNave"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoPlataformaNave;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoDependencia;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Ubicacion"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.Ubicacion;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CodigoCapacidadOperativaRequerida", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativaRequerida"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoCapacidadOperativaRequerida;

                    cmd.Parameters.Add("@CodigoCondicion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicion"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoCondicion;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Observacion"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.Observacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(SituacionBuqueAuxiEmbarcMenorComzocuatroDTO situacionBuqueAuxiEmbarcMenorComzocuatroDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionBuqueAuxiEmbarcMenorComzocuatroEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadNaveId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadNaveId"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.SituacionBuqueAuxiliarEmbarcacionMenorId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionBuqueAuxiEmbarcMenorComzocuatroDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_SituacionBuqueAuxiEmbarcMenorComzocuatroRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionBuqueAuxiEmbarcMenorComzocuatro", SqlDbType.Structured);
                    cmd.Parameters["@SituacionBuqueAuxiEmbarcMenorComzocuatro"].TypeName = "Formato.SituacionBuqueAuxiEmbarcMenorComzocuatro";
                    cmd.Parameters["@SituacionBuqueAuxiEmbarcMenorComzocuatro"].Value = datos;

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
