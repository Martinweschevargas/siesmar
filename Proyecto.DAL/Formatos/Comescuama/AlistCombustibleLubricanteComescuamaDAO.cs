using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comescuama;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comescuama
{
    public class AlistCombustibleLubricanteComescuamaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistCombustibleLubricanteComescuamaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<AlistCombustibleLubricanteComescuamaDTO> lista = new List<AlistCombustibleLubricanteComescuamaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComescuamaListar", conexion);
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
                        lista.Add(new AlistCombustibleLubricanteComescuamaDTO()
                        {
                            AlistamientoCombustibleLubricanteId = Convert.ToInt32(dr["AlistamientoCombustibleLubricanteId"]),
                            DescUnidadComescuama = dr["DescUnidadComescuama"].ToString(),
                            Articulo = dr["Articulo"].ToString(),
                            Equipo = dr["Equipo"].ToString(),
                            DescUnidadMedida = dr["DescUnidadMedida"].ToString(),
                            Cargo = dr["Cargo"].ToString(),
                            Aumento = dr["Aumento"].ToString(),
                            Consumo = dr["Consumo"].ToString(),
                            Existencia = dr["Existencia"].ToString(),
                            PromedioPonderado = Convert.ToDecimal(dr["PromedioPonderado"]),
                            SubPromedioParcial = Convert.ToDecimal(dr["SubPromedioParcial"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistCombustibleLubricanteComescuamaDTO alistCombustibleLubricanteComescuamaDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComescuamaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadComescuama", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadComescuama"].Value = alistCombustibleLubricanteComescuamaDTO.CodigoUnidadComescuama;

                    cmd.Parameters.Add("@CodigoAlistamientoCombustibleLubricante2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoCombustibleLubricante2"].Value = alistCombustibleLubricanteComescuamaDTO.CodigoAlistamientoCombustibleLubricante2;

                    cmd.Parameters.Add("@PromedioPonderado", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioPonderado"].Value = alistCombustibleLubricanteComescuamaDTO.PromedioPonderado;

                    cmd.Parameters.Add("@SubPromedioParcial", SqlDbType.Decimal);
                    cmd.Parameters["@SubPromedioParcial"].Value = alistCombustibleLubricanteComescuamaDTO.SubPromedioParcial;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistCombustibleLubricanteComescuamaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistCombustibleLubricanteComescuamaDTO.UsuarioIngresoRegistro;

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

        public AlistCombustibleLubricanteComescuamaDTO BuscarFormato(int Codigo)
        {
            AlistCombustibleLubricanteComescuamaDTO alistCombustibleLubricanteComescuamaDTO = new AlistCombustibleLubricanteComescuamaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComescuamaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        alistCombustibleLubricanteComescuamaDTO.AlistamientoCombustibleLubricanteId = Convert.ToInt32(dr["AlistamientoCombustibleLubricanteId"]);
                        alistCombustibleLubricanteComescuamaDTO.CodigoUnidadComescuama = dr["CodigoUnidadComescuama"].ToString();
                        alistCombustibleLubricanteComescuamaDTO.CodigoAlistamientoCombustibleLubricante2 = dr["CodigoAlistamientoCombustibleLubricante2"].ToString();
                        alistCombustibleLubricanteComescuamaDTO.PromedioPonderado = Convert.ToDecimal(dr["PromedioPonderado"]);
                        alistCombustibleLubricanteComescuamaDTO.SubPromedioParcial = Convert.ToDecimal(dr["SubPromedioParcial"]);


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistCombustibleLubricanteComescuamaDTO;
        }

        public string ActualizaFormato(AlistCombustibleLubricanteComescuamaDTO alistCombustibleLubricanteComescuamaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComescuamaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = alistCombustibleLubricanteComescuamaDTO.AlistamientoCombustibleLubricanteId;

                    cmd.Parameters.Add("@CodigoUnidadComescuama", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadComescuama"].Value = alistCombustibleLubricanteComescuamaDTO.CodigoUnidadComescuama;

                    cmd.Parameters.Add("@CodigoAlistamientoCombustibleLubricante2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoCombustibleLubricante2"].Value = alistCombustibleLubricanteComescuamaDTO.CodigoAlistamientoCombustibleLubricante2;

                    cmd.Parameters.Add("@PromedioPonderado", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioPonderado"].Value = alistCombustibleLubricanteComescuamaDTO.PromedioPonderado;

                    cmd.Parameters.Add("@SubPromedioParcial", SqlDbType.Decimal);
                    cmd.Parameters["@SubPromedioParcial"].Value = alistCombustibleLubricanteComescuamaDTO.SubPromedioParcial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistCombustibleLubricanteComescuamaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistCombustibleLubricanteComescuamaDTO alistCombustibleLubricanteComescuamaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComescuamaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = alistCombustibleLubricanteComescuamaDTO.AlistamientoCombustibleLubricanteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistCombustibleLubricanteComescuamaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(AlistCombustibleLubricanteComescuamaDTO alistCombustibleLubricanteComescuamaDTO)
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
                    cmd.Parameters["@Formato"].Value = "AlistamientoCombustibleLubricanteComescuama";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistCombustibleLubricanteComescuamaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistCombustibleLubricanteComescuamaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteComescuamaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteComescuama", SqlDbType.Structured);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteComescuama"].TypeName = "Formato.AlistamientoCombustibleLubricanteComescuama";
                    cmd.Parameters["@AlistamientoCombustibleLubricanteComescuama"].Value = datos;

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
