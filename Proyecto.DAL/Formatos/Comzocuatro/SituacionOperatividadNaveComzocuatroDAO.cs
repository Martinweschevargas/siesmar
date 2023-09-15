using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.AccesoDatos.Formatos.Comescuama;
using Marina.Siesmar.Entidades.Formatos.Comescuama;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comzocuatro
{
    public class SituacionOperatividadNaveComzocuatroDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<SituacionOperatividadNaveComzocuatroDTO> ObtenerLista(int? CargaId = null)
        {
            List<SituacionOperatividadNaveComzocuatroDTO> lista = new List<SituacionOperatividadNaveComzocuatroDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_SituacionOperatividadNaveComzocuatroListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SituacionOperatividadNaveComzocuatroDTO()
                        {
                            SituacionOperativaNaveComzocuatroId = Convert.ToInt32(dr["SituacionOperatividadNaveId"]),
                            DescTipoNave = dr["DescTipoNave"].ToString(),          
                            CascoNave = Convert.ToInt32(dr["CascoNave"]),
                            DescTipoPlataformaNave = dr["DescTipoPlataformaNave"].ToString(),
                            CodigoDependencia = dr["CodigoDependencia"].ToString(),
                            Ubicacion = dr["Ubicacion"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
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

        public string AgregarRegistro(SituacionOperatividadNaveComzocuatroDTO situacionOperativaNaveComzocuatroDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadNaveComzocuatroRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoTipoNave", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoNave"].Value = situacionOperativaNaveComzocuatroDTO.CodigoTipoNave;

                    cmd.Parameters.Add("@CascoNave", SqlDbType.Int);
                    cmd.Parameters["@CascoNave"].Value = situacionOperativaNaveComzocuatroDTO.CascoNave;

                    cmd.Parameters.Add("@CodigoTipoPlataformaNave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPlataformaNave"].Value = situacionOperativaNaveComzocuatroDTO.CodigoTipoPlataformaNave;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = situacionOperativaNaveComzocuatroDTO.CodigoDependencia;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Ubicacion"].Value = situacionOperativaNaveComzocuatroDTO.Ubicacion;;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = situacionOperativaNaveComzocuatroDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CodigoCapacidadOperativaRequerida", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativaRequerida"].Value = situacionOperativaNaveComzocuatroDTO.CodigoCapacidadOperativaRequerida;

                    cmd.Parameters.Add("@CodigoCondicion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicion"].Value = situacionOperativaNaveComzocuatroDTO.CodigoCondicion;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observacion"].Value = situacionOperativaNaveComzocuatroDTO.Observacion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = situacionOperativaNaveComzocuatroDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperativaNaveComzocuatroDTO.UsuarioIngresoRegistro;

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

        public SituacionOperatividadNaveComzocuatroDTO BuscarFormato(int Codigo)
        {
            SituacionOperatividadNaveComzocuatroDTO situacionOperativaNaveComzocuatroDTO = new SituacionOperatividadNaveComzocuatroDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadNaveComzocuatroEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadNaveId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadNaveId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        situacionOperativaNaveComzocuatroDTO.SituacionOperativaNaveComzocuatroId = Convert.ToInt32(dr["SituacionOperatividadNaveId"]);
                        situacionOperativaNaveComzocuatroDTO.CodigoTipoNave = dr["CodigoTipoNave"].ToString();
                        situacionOperativaNaveComzocuatroDTO.CascoNave = Convert.ToInt32(dr["CascoNave"]);
                        situacionOperativaNaveComzocuatroDTO.CodigoTipoPlataformaNave = dr["CodigoTipoPlataformaNave"].ToString();
                        situacionOperativaNaveComzocuatroDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        situacionOperativaNaveComzocuatroDTO.Ubicacion = dr["Ubicacion"].ToString();
                        situacionOperativaNaveComzocuatroDTO.DistritoUbigeo = dr["DistritoUbigeo"].ToString();
                        situacionOperativaNaveComzocuatroDTO.CodigoCapacidadOperativaRequerida = dr["CodigoCapacidadOperativaRequerida"].ToString();
                        situacionOperativaNaveComzocuatroDTO.CodigoCondicion = dr["CodigoCondicion"].ToString();
                        situacionOperativaNaveComzocuatroDTO.Observacion = dr["Observacion"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return situacionOperativaNaveComzocuatroDTO;
        }

        public string ActualizaFormato(SituacionOperatividadNaveComzocuatroDTO situacionOperativaNaveComzocuatroDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadNaveComzocuatroActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@SituacionOperatividadNaveId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadNaveId"].Value = situacionOperativaNaveComzocuatroDTO.SituacionOperativaNaveComzocuatroId;

                    cmd.Parameters.Add("@CodigoTipoNave", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoNave"].Value = situacionOperativaNaveComzocuatroDTO.CodigoTipoNave;

                    cmd.Parameters.Add("@CascoNave", SqlDbType.Int);
                    cmd.Parameters["@CascoNave"].Value = situacionOperativaNaveComzocuatroDTO.CascoNave;

                    cmd.Parameters.Add("@CodigoTipoPlataformaNave", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPlataformaNave"].Value = situacionOperativaNaveComzocuatroDTO.CodigoTipoPlataformaNave;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = situacionOperativaNaveComzocuatroDTO.CodigoDependencia;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Ubicacion"].Value = situacionOperativaNaveComzocuatroDTO.Ubicacion;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = situacionOperativaNaveComzocuatroDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CodigoCapacidadOperativaRequerida", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativaRequerida"].Value = situacionOperativaNaveComzocuatroDTO.CodigoCapacidadOperativaRequerida;

                    cmd.Parameters.Add("@CodigoCondicion", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoCondicion"].Value = situacionOperativaNaveComzocuatroDTO.CodigoCondicion;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Observacion"].Value = situacionOperativaNaveComzocuatroDTO.Observacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperativaNaveComzocuatroDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(SituacionOperatividadNaveComzocuatroDTO situacionOperativaNaveComzocuatroDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadNaveComzocuatroEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadNaveId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadNaveId"].Value = situacionOperativaNaveComzocuatroDTO.SituacionOperativaNaveComzocuatroId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperativaNaveComzocuatroDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_SituacionOperatividadNaveComzocuatroRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadNaveComzocuatro", SqlDbType.Structured);
                    cmd.Parameters["@SituacionOperatividadNaveComzocuatro"].TypeName = "Formato.SituacionOperatividadNaveComzocuatro";
                    cmd.Parameters["@SituacionOperatividadNaveComzocuatro"].Value = datos;

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
