using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Combasnai;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Combasnai
{
    public class AlistamientoMaterialCombasnaiDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistamientoMaterialCombasnaiDTO> ObtenerLista()
        {
            List<AlistamientoMaterialCombasnaiDTO> lista = new List<AlistamientoMaterialCombasnaiDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistamientoMaterialCombasnaiListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistamientoMaterialCombasnaiDTO()
                        {
                            AlistamientoMaterialId = Convert.ToInt32(dr["AlistamientoMaterialId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescCapacidadOperativa = dr["DescCapacidadOperativa"].ToString(),
                            CapacidadIntrinseca = dr["CapacidadIntrinseca"].ToString(),
                            Ponderado1N = Convert.ToDecimal(dr["Ponderado1N"]),
                            Subclasificacion2 = dr["Subclasificacion2"].ToString(),
                            Ponderado2Nivel = Convert.ToDecimal(dr["Ponderado2Nivel"]),
                            Subclasificacion3 = dr["Subclasificacion3"].ToString(),
                            Ponderado3Nivel = Convert.ToDecimal(dr["Ponderado3Nivel"]),
                            Requerido = Convert.ToInt32(dr["Requerido"]),
                            Operativo = Convert.ToInt32(dr["Operativo"]),
                            PorcentajeOperatividad = dr["PorcentajeOperatividad"].ToString(),


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistamientoMaterialCombasnaiDTO alistamientoMaterialCombasnaiDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialCombasnaiRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = alistamientoMaterialCombasnaiDTO.UnidadNavalId;

                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = alistamientoMaterialCombasnaiDTO.CapacidadOperativaId;

                    cmd.Parameters.Add("@AlistamientoMaterialRequerido3NId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialRequerido3NId"].Value = alistamientoMaterialCombasnaiDTO.AlistamientoMaterialRequerido3NId;

                    cmd.Parameters.Add("@Requerido", SqlDbType.Int);
                    cmd.Parameters["@Requerido"].Value = alistamientoMaterialCombasnaiDTO.Requerido;

                    cmd.Parameters.Add("@Operativo", SqlDbType.Int);
                    cmd.Parameters["@Operativo"].Value = alistamientoMaterialCombasnaiDTO.Operativo;

                    cmd.Parameters.Add("@PorcentajeOperatividad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@PorcentajeOperatividad"].Value = alistamientoMaterialCombasnaiDTO.PorcentajeOperatividad;


                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialCombasnaiDTO.UsuarioIngresoRegistro;

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

        public AlistamientoMaterialCombasnaiDTO BuscarFormato(int Codigo)
        {
            AlistamientoMaterialCombasnaiDTO alistamientoMaterialCombasnaiDTO = new AlistamientoMaterialCombasnaiDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialCombasnaiEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        alistamientoMaterialCombasnaiDTO.AlistamientoMaterialId = Convert.ToInt32(dr["AlistamientoMaterialId"]);
                        alistamientoMaterialCombasnaiDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        alistamientoMaterialCombasnaiDTO.CapacidadOperativaId = Convert.ToInt32(dr["CapacidadOperativaId"]);
                        alistamientoMaterialCombasnaiDTO.AlistamientoMaterialRequerido3NId = Convert.ToInt32(dr["AlistamientoMaterialRequerido3NId"]);
                        alistamientoMaterialCombasnaiDTO.Requerido = Convert.ToInt32(dr["Requerido"]);
                        alistamientoMaterialCombasnaiDTO.Operativo = Convert.ToInt32(dr["Operativo"]);
                        alistamientoMaterialCombasnaiDTO.PorcentajeOperatividad = dr["PorcentajeOperatividad"].ToString();
                        alistamientoMaterialCombasnaiDTO.CapacidadIntrinseca = dr["CapacidadIntrinseca"].ToString();
                        alistamientoMaterialCombasnaiDTO.Ponderado1N = Convert.ToDecimal(dr["Ponderado1N"]);
                        alistamientoMaterialCombasnaiDTO.Subclasificacion2 = dr["Subclasificacion2"].ToString();
                        alistamientoMaterialCombasnaiDTO.Ponderado2Nivel = Convert.ToDecimal(dr["Ponderado2Nivel"]);
                        alistamientoMaterialCombasnaiDTO.Subclasificacion3 = dr["Subclasificacion3"].ToString();
                        alistamientoMaterialCombasnaiDTO.Ponderado3Nivel = Convert.ToDecimal(dr["Ponderado3Nivel"]);

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoMaterialCombasnaiDTO;
        }

        public string ActualizaFormato(AlistamientoMaterialCombasnaiDTO alistamientoMaterialCombasnaiDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialCombasnaiActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AlistamientoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialId"].Value = alistamientoMaterialCombasnaiDTO.AlistamientoMaterialId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = alistamientoMaterialCombasnaiDTO.UnidadNavalId;

                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = alistamientoMaterialCombasnaiDTO.CapacidadOperativaId;

                    cmd.Parameters.Add("@AlistamientoMaterialRequerido3NId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialRequerido3NId"].Value = alistamientoMaterialCombasnaiDTO.AlistamientoMaterialRequerido3NId;

                    cmd.Parameters.Add("@Requerido", SqlDbType.Int);
                    cmd.Parameters["@Requerido"].Value = alistamientoMaterialCombasnaiDTO.Requerido;

                    cmd.Parameters.Add("@Operativo", SqlDbType.Int);
                    cmd.Parameters["@Operativo"].Value = alistamientoMaterialCombasnaiDTO.Operativo;

                    cmd.Parameters.Add("@PorcentajeOperatividad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@PorcentajeOperatividad"].Value = alistamientoMaterialCombasnaiDTO.PorcentajeOperatividad;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialCombasnaiDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistamientoMaterialCombasnaiDTO alistamientoMaterialCombasnaiDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialCombasnaiEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialId"].Value = alistamientoMaterialCombasnaiDTO.AlistamientoMaterialId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialCombasnaiDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_AlistamientoMaterialCombasnaiRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialCombasnaiRegistrar", SqlDbType.Structured);
                    cmd.Parameters["@AlistamientoMaterialCombasnaiRegistrar"].TypeName = "Formato.AlistamientoMaterialCombasnaiRegistrar";
                    cmd.Parameters["@AlistamientoMaterialCombasnaiRegistrar"].Value = datos;

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
