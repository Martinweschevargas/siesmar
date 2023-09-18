using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comzocuatro
{
    public class AlistamientoMaterialComzocuatroDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistamientoMaterialComzocuatroDTO> ObtenerLista(int? CargaId = null)
        {
            List<AlistamientoMaterialComzocuatroDTO> lista = new List<AlistamientoMaterialComzocuatroDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistamientoMaterialComzocuatroListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistamientoMaterialComzocuatroDTO()
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
                            PorcentajeOperatividad = Convert.ToInt32(dr["PorcentajeOperatividad"]),
                            PorcentajeFuncional = Convert.ToDecimal(dr["PorcentajeFuncional"]),
                            NivelAlistamientoParcial = Convert.ToDecimal(dr["NivelAlistamientoParcial"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistamientoMaterialComzocuatroDTO alistamientoMaterialComzocuatroDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialComzocuatroRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = alistamientoMaterialComzocuatroDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoCapacidadOperativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativa"].Value = alistamientoMaterialComzocuatroDTO.CodigoCapacidadOperativa;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido3N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido3N"].Value = alistamientoMaterialComzocuatroDTO.CodigoAlistamientoMaterialRequerido3N;

                    cmd.Parameters.Add("@Requerido", SqlDbType.Int);
                    cmd.Parameters["@Requerido"].Value = alistamientoMaterialComzocuatroDTO.Requerido;

                    cmd.Parameters.Add("@Operativo", SqlDbType.Int);
                    cmd.Parameters["@Operativo"].Value = alistamientoMaterialComzocuatroDTO.Operativo;

                    cmd.Parameters.Add("@PorcentajeOperatividad", SqlDbType.Int);
                    cmd.Parameters["@PorcentajeOperatividad"].Value = alistamientoMaterialComzocuatroDTO.PorcentajeOperatividad;
                    
                    cmd.Parameters.Add("@PorcentajeFuncional", SqlDbType.Decimal);
                    cmd.Parameters["@PorcentajeFuncional"].Value = alistamientoMaterialComzocuatroDTO.PorcentajeFuncional;

                    cmd.Parameters.Add("@NivelAlistamientoParcial", SqlDbType.Decimal);
                    cmd.Parameters["@NivelAlistamientoParcial"].Value = alistamientoMaterialComzocuatroDTO.NivelAlistamientoParcial;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistamientoMaterialComzocuatroDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialComzocuatroDTO.UsuarioIngresoRegistro;

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

        public AlistamientoMaterialComzocuatroDTO BuscarFormato(int Codigo)
        {
            AlistamientoMaterialComzocuatroDTO alistamientoMaterialComzocuatroDTO = new AlistamientoMaterialComzocuatroDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialComzocuatroEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        alistamientoMaterialComzocuatroDTO.AlistamientoMaterialId = Convert.ToInt32(dr["AlistamientoMaterialId"]);
                        alistamientoMaterialComzocuatroDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        alistamientoMaterialComzocuatroDTO.CodigoCapacidadOperativa = dr["CodigoCapacidadOperativa"].ToString();
                        alistamientoMaterialComzocuatroDTO.CodigoAlistamientoMaterialRequerido3N = dr["CodigoAlistamientoMaterialRequerido3N"].ToString();
                        alistamientoMaterialComzocuatroDTO.Requerido = Convert.ToInt32(dr["Requerido"]);
                        alistamientoMaterialComzocuatroDTO.Operativo = Convert.ToInt32(dr["Operativo"]);
                        alistamientoMaterialComzocuatroDTO.PorcentajeOperatividad = Convert.ToInt32(dr["PorcentajeOperatividad"]);
                        alistamientoMaterialComzocuatroDTO.PorcentajeFuncional = Convert.ToDecimal(dr["PorcentajeFuncional"]);
                        alistamientoMaterialComzocuatroDTO.NivelAlistamientoParcial = Convert.ToDecimal(dr["NivelAlistamientoParcial"]);
                        alistamientoMaterialComzocuatroDTO.CapacidadIntrinseca = dr["CapacidadIntrinseca"].ToString();
                        alistamientoMaterialComzocuatroDTO.Ponderado1N = Convert.ToDecimal(dr["Ponderado1N"]);
                        alistamientoMaterialComzocuatroDTO.Subclasificacion2 = dr["Subclasificacion2"].ToString();
                        alistamientoMaterialComzocuatroDTO.Ponderado2Nivel = Convert.ToDecimal(dr["Ponderado2Nivel"]);
                        alistamientoMaterialComzocuatroDTO.Subclasificacion3 = dr["Subclasificacion3"].ToString();
                        alistamientoMaterialComzocuatroDTO.Ponderado3Nivel = Convert.ToDecimal(dr["Ponderado3Nivel"]);

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoMaterialComzocuatroDTO;
        }

        public string ActualizaFormato(AlistamientoMaterialComzocuatroDTO alistamientoMaterialComzocuatroDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialComzocuatroActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AlistamientoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialId"].Value = alistamientoMaterialComzocuatroDTO.AlistamientoMaterialId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = alistamientoMaterialComzocuatroDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoCapacidadOperativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativa"].Value = alistamientoMaterialComzocuatroDTO.CodigoCapacidadOperativa;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido3N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido3N"].Value = alistamientoMaterialComzocuatroDTO.CodigoAlistamientoMaterialRequerido3N;

                    cmd.Parameters.Add("@Requerido", SqlDbType.Int);
                    cmd.Parameters["@Requerido"].Value = alistamientoMaterialComzocuatroDTO.Requerido;

                    cmd.Parameters.Add("@Operativo", SqlDbType.Int);
                    cmd.Parameters["@Operativo"].Value = alistamientoMaterialComzocuatroDTO.Operativo;

                    cmd.Parameters.Add("@PorcentajeOperatividad", SqlDbType.Int);
                    cmd.Parameters["@PorcentajeOperatividad"].Value = alistamientoMaterialComzocuatroDTO.PorcentajeOperatividad;

                    cmd.Parameters.Add("@PorcentajeFuncional", SqlDbType.Decimal);
                    cmd.Parameters["@PorcentajeFuncional"].Value = alistamientoMaterialComzocuatroDTO.PorcentajeFuncional;

                    cmd.Parameters.Add("@NivelAlistamientoParcial", SqlDbType.Decimal);
                    cmd.Parameters["@NivelAlistamientoParcial"].Value = alistamientoMaterialComzocuatroDTO.NivelAlistamientoParcial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialComzocuatroDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistamientoMaterialComzocuatroDTO alistamientoMaterialComzocuatroDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialComzocuatroEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialId"].Value = alistamientoMaterialComzocuatroDTO.AlistamientoMaterialId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialComzocuatroDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_AlistamientoMaterialComzocuatroRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialComzocuatro", SqlDbType.Structured);
                    cmd.Parameters["@AlistamientoMaterialComzocuatro"].TypeName = "Formato.AlistamientoMaterialComzocuatro";
                    cmd.Parameters["@AlistamientoMaterialComzocuatro"].Value = datos;

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
