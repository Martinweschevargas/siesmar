using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfuinmar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfuinmar
{
    public class AlistamientoMunicionComfuinmarDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistamientoMunicionComfuinmarDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<AlistamientoMunicionComfuinmarDTO> lista = new List<AlistamientoMunicionComfuinmarDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfuinmarListar", conexion);
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
                        lista.Add(new AlistamientoMunicionComfuinmarDTO()
                        {
                            AlistamientoMunicionConfuinmarId = Convert.ToInt32(dr["AlistamientoMunicionConfuinmarId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            CodigoAlistamientoMunicion = dr["CodigoAlistamientoMunicion"].ToString(),
                            NroMunicionesExistentes = Convert.ToInt32(dr["NroMunicionesExistentes"].ToString()),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistamientoMunicionComfuinmarDTO alistamientoMunicionComfuinmarDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfuinmarRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = alistamientoMunicionComfuinmarDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoAlistamientoMunicion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMunicion"].Value = alistamientoMunicionComfuinmarDTO.CodigoAlistamientoMunicion;

                    cmd.Parameters.Add("@NroMunicionesExistentes", SqlDbType.Int);
                    cmd.Parameters["@NroMunicionesExistentes"].Value = alistamientoMunicionComfuinmarDTO.NroMunicionesExistentes;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistamientoMunicionComfuinmarDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMunicionComfuinmarDTO.UsuarioIngresoRegistro;

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

        public AlistamientoMunicionComfuinmarDTO BuscarFormato(int Codigo)
        {
            AlistamientoMunicionComfuinmarDTO alistamientoMunicionComfuinmarDTO = new AlistamientoMunicionComfuinmarDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfuinmarEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMunicionConfuinmarId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMunicionConfuinmarId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        alistamientoMunicionComfuinmarDTO.AlistamientoMunicionConfuinmarId = Convert.ToInt32(dr["AlistamientoMunicionConfuinmarId"]);
                        alistamientoMunicionComfuinmarDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        alistamientoMunicionComfuinmarDTO.CodigoAlistamientoMunicion = dr["CodigoAlistamientoMunicion"].ToString();
                        alistamientoMunicionComfuinmarDTO.NroMunicionesExistentes = Convert.ToInt32(dr["NroMunicionesExistentes"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoMunicionComfuinmarDTO;
        }

        public string ActualizaFormato(AlistamientoMunicionComfuinmarDTO alistamientoMunicionComfuinmarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfuinmarActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AlistamientoMunicionConfuinmarId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMunicionConfuinmarId"].Value = alistamientoMunicionComfuinmarDTO.AlistamientoMunicionConfuinmarId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = alistamientoMunicionComfuinmarDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoAlistamientoMunicion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMunicion"].Value = alistamientoMunicionComfuinmarDTO.CodigoAlistamientoMunicion;

                    cmd.Parameters.Add("@NroMunicionesExistentes", SqlDbType.Int);
                    cmd.Parameters["@NroMunicionesExistentes"].Value = alistamientoMunicionComfuinmarDTO.NroMunicionesExistentes;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMunicionComfuinmarDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistamientoMunicionComfuinmarDTO alistamientoMunicionComfuinmarDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfuinmarEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMunicionConfuinmarId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMunicionConfuinmarId"].Value = alistamientoMunicionComfuinmarDTO.AlistamientoMunicionConfuinmarId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMunicionComfuinmarDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(AlistamientoMunicionComfuinmarDTO alistamientoMunicionComfuinmarDTO)
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
                    cmd.Parameters["@Formato"].Value = "AlistamientoMunicionComfuinmar";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistamientoMunicionComfuinmarDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMunicionComfuinmarDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfuinmarRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMunicionComfuinmar", SqlDbType.Structured);
                    cmd.Parameters["@AlistamientoMunicionComfuinmar"].TypeName = "Formato.AlistamientoMunicionComfuinmar";
                    cmd.Parameters["@AlistamientoMunicionComfuinmar"].Value = datos;

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
