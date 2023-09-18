using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.AccesoDatos.Formatos.Comescuama;
using Marina.Siesmar.Entidades.Formatos.Combima1;
using Marina.Siesmar.Entidades.Formatos.Comescuama;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Combima1
{
    public class AlistamientoMaterialCombima1DAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistamientoMaterialCombima1DTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<AlistamientoMaterialCombima1DTO> lista = new List<AlistamientoMaterialCombima1DTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistamientoMaterialCombima1Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                cmd.Parameters["@FechaInicio"].Value = fechainicio;

                cmd.Parameters.Add("@FechaFin", SqlDbType.Date);
                cmd.Parameters["@FechaFin"].Value = fechafin;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistamientoMaterialCombima1DTO()
                        {
                            AlistamientoMaterialId = Convert.ToInt32(dr["AlistamientoMaterialId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            CapacidadOperativa = dr["CapacidadOperativa"].ToString(),
                            CodigoAlistamientoMaterialRequerido3N = dr["CodigoAlistamientoMaterialRequerido3N"].ToString(),
                            Requerido = Convert.ToInt32(dr["Requerido"]),
                            Operativo = Convert.ToInt32(dr["Operativo"]),
                            Existencia = Convert.ToInt32(dr["Existencia"]),
                            PorcentajeOperatividad = Convert.ToDecimal(dr["PorcentajeOperatividad"]),
                            PonderadoFuncional = Convert.ToDecimal(dr["PonderadoFuncional"]),
                            NivelAlistamientoParcial = Convert.ToDecimal(dr["NivelAlistamientoParcial"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistamientoMaterialCombima1DTO alistamientoMaterialCombima1DTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialCombima1Registrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = alistamientoMaterialCombima1DTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CapacidadOperativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CapacidadOperativa"].Value = alistamientoMaterialCombima1DTO.CapacidadOperativa;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido3N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido3N"].Value = alistamientoMaterialCombima1DTO.CodigoAlistamientoMaterialRequerido3N;

                    cmd.Parameters.Add("@Requerido", SqlDbType.Int);
                    cmd.Parameters["@Requerido"].Value = alistamientoMaterialCombima1DTO.Requerido;

                    cmd.Parameters.Add("@Operativo", SqlDbType.Int);
                    cmd.Parameters["@Operativo"].Value = alistamientoMaterialCombima1DTO.Operativo;     
                    
                    cmd.Parameters.Add("@Existencia", SqlDbType.Int);
                    cmd.Parameters["@Existencia"].Value = alistamientoMaterialCombima1DTO.Existencia;

                    cmd.Parameters.Add("@PorcentajeOperatividad", SqlDbType.Decimal);
                    cmd.Parameters["@PorcentajeOperatividad"].Value = alistamientoMaterialCombima1DTO.PorcentajeOperatividad;

                    cmd.Parameters.Add("@PonderadoFuncional", SqlDbType.Decimal);
                    cmd.Parameters["@PonderadoFuncional"].Value = alistamientoMaterialCombima1DTO.PonderadoFuncional;

                    cmd.Parameters.Add("@NivelAlistamientoParcial", SqlDbType.Decimal);
                    cmd.Parameters["@NivelAlistamientoParcial"].Value = alistamientoMaterialCombima1DTO.NivelAlistamientoParcial;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistamientoMaterialCombima1DTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialCombima1DTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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

        public AlistamientoMaterialCombima1DTO BuscarFormato(int Codigo)
        {
            AlistamientoMaterialCombima1DTO alistamientoMaterialCombima1DTO = new AlistamientoMaterialCombima1DTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialCombima1Encontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        alistamientoMaterialCombima1DTO.AlistamientoMaterialId = Convert.ToInt32(dr["AlistamientoMaterialId"]);
                        alistamientoMaterialCombima1DTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        alistamientoMaterialCombima1DTO.CapacidadOperativa = dr["CapacidadOperativa"].ToString();
                        alistamientoMaterialCombima1DTO.CodigoAlistamientoMaterialRequerido3N = dr["CodigoAlistamientoMaterialRequerido3N"].ToString();
                        alistamientoMaterialCombima1DTO.Requerido = Convert.ToInt32(dr["Requerido"]);
                        alistamientoMaterialCombima1DTO.Operativo = Convert.ToInt32(dr["Operativo"]);
                        alistamientoMaterialCombima1DTO.Existencia = Convert.ToInt32(dr["Existencia"]);
                        alistamientoMaterialCombima1DTO.PorcentajeOperatividad = Convert.ToDecimal(dr["PorcentajeOperatividad"]);
                        alistamientoMaterialCombima1DTO.PonderadoFuncional = Convert.ToDecimal(dr["PonderadoFuncional"]);
                        alistamientoMaterialCombima1DTO.NivelAlistamientoParcial = Convert.ToDecimal(dr["NivelAlistamientoParcial"]);

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoMaterialCombima1DTO;
        }

        public string ActualizaFormato(AlistamientoMaterialCombima1DTO alistamientoMaterialCombima1DTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialCombima1Actualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialId"].Value = alistamientoMaterialCombima1DTO.AlistamientoMaterialId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = alistamientoMaterialCombima1DTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CapacidadOperativa", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CapacidadOperativa"].Value = alistamientoMaterialCombima1DTO.CapacidadOperativa;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido3N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido3N"].Value = alistamientoMaterialCombima1DTO.CodigoAlistamientoMaterialRequerido3N;

                    cmd.Parameters.Add("@Requerido", SqlDbType.Int);
                    cmd.Parameters["@Requerido"].Value = alistamientoMaterialCombima1DTO.Requerido;

                    cmd.Parameters.Add("@Operativo", SqlDbType.Int);
                    cmd.Parameters["@Operativo"].Value = alistamientoMaterialCombima1DTO.Operativo;

                    cmd.Parameters.Add("@Existencia", SqlDbType.Int);
                    cmd.Parameters["@Existencia"].Value = alistamientoMaterialCombima1DTO.Existencia;

                    cmd.Parameters.Add("@PorcentajeOperatividad", SqlDbType.Decimal);
                    cmd.Parameters["@PorcentajeOperatividad"].Value = alistamientoMaterialCombima1DTO.PorcentajeOperatividad;

                    cmd.Parameters.Add("@PonderadoFuncional", SqlDbType.Decimal);
                    cmd.Parameters["@PonderadoFuncional"].Value = alistamientoMaterialCombima1DTO.PonderadoFuncional;

                    cmd.Parameters.Add("@NivelAlistamientoParcial", SqlDbType.Decimal);
                    cmd.Parameters["@NivelAlistamientoParcial"].Value = alistamientoMaterialCombima1DTO.NivelAlistamientoParcial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialCombima1DTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistamientoMaterialCombima1DTO alistamientoMaterialCombima1DTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialCombima1Eliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialId"].Value = alistamientoMaterialCombima1DTO.AlistamientoMaterialId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialCombima1DTO.UsuarioIngresoRegistro;

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


        public bool EliminarCarga(AlistamientoMaterialCombima1DTO alistamientoMaterialCombima1DTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_CargaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Formato", SqlDbType.NVarChar, 200);
                    cmd.Parameters["@Formato"].Value = "AlistamientoMaterialCombima1";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistamientoMaterialCombima1DTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialCombima1DTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_AlistamientoMaterialCombima1RegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialCombima1", SqlDbType.Structured);
                    cmd.Parameters["@AlistamientoMaterialCombima1"].TypeName = "Formato.AlistamientoMaterialCombima1";
                    cmd.Parameters["@AlistamientoMaterialCombima1"].Value = datos;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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
