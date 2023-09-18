using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dimar
{
    public class EntregaArregloFloralCeremoniaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EntregaArregloFloralCeremoniaDTO> ObtenerLista(int? CargaId = null)
        {
            List<EntregaArregloFloralCeremoniaDTO> lista = new List<EntregaArregloFloralCeremoniaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EntregaArregloFloralCeremoniaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EntregaArregloFloralCeremoniaDTO()
                        {
                            EntregaArregloFloralCeremoniaId = Convert.ToInt32(dr["EntregaArregloFloralCeremoniaId"]),
                            FechaAdquisicion = (dr["FechaAdquisicion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            TipoArregloFloral = dr["TipoArregloFloral"].ToString(),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            DescUnidadMedida = dr["UnidadMedidaId"].ToString(),
                            CostoUnitario = Convert.ToDecimal(dr["CostoUnitario"]),
                            DescFrecuenciaDifusion = dr["FrecuenciaDifusionId"].ToString(),
                            DescPublicoObjetivo = dr["PublicoObjetivoId"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EntregaArregloFloralCeremoniaDTO entregaArregloFloralCeremoniaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EntregaArregloFloralCeremoniaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaAdquisicion", SqlDbType.Date);
                    cmd.Parameters["@FechaAdquisicion"].Value = entregaArregloFloralCeremoniaDTO.FechaAdquisicion;

                    cmd.Parameters.Add("@TipoArregloFloral", SqlDbType.VarChar, 100);
                    cmd.Parameters["@TipoArregloFloral"].Value = entregaArregloFloralCeremoniaDTO.TipoArregloFloral;

                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int);
                    cmd.Parameters["@Cantidad"].Value = entregaArregloFloralCeremoniaDTO.Cantidad;

                    cmd.Parameters.Add("@CodigoUnidadMedida ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadMedida "].Value = entregaArregloFloralCeremoniaDTO.CodigoUnidadMedida;

                    cmd.Parameters.Add("@CostoUnitario", SqlDbType.Decimal);
                    cmd.Parameters["@CostoUnitario"].Value = entregaArregloFloralCeremoniaDTO.CostoUnitario;

                    cmd.Parameters.Add("@CodigoFrecuenciaDifusion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFrecuenciaDifusion "].Value = entregaArregloFloralCeremoniaDTO.CodigoFrecuenciaDifusion;

                    cmd.Parameters.Add("@CodigoPublicoObjetivo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPublicoObjetivo "].Value = entregaArregloFloralCeremoniaDTO.CodigoPublicoObjetivo;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = entregaArregloFloralCeremoniaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entregaArregloFloralCeremoniaDTO.UsuarioIngresoRegistro;

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

        public EntregaArregloFloralCeremoniaDTO BuscarFormato(int Codigo)
        {
            EntregaArregloFloralCeremoniaDTO entregaArregloFloralCeremoniaDTO = new EntregaArregloFloralCeremoniaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EntregaArregloFloralCeremoniaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntregaArregloFloralCeremoniaId", SqlDbType.Int);
                    cmd.Parameters["@EntregaArregloFloralCeremoniaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        entregaArregloFloralCeremoniaDTO.EntregaArregloFloralCeremoniaId = Convert.ToInt32(dr["EntregaArregloFloralCeremoniaId"]);
                        entregaArregloFloralCeremoniaDTO.FechaAdquisicion = Convert.ToDateTime(dr["FechaAdquisicion"]).ToString("yyy-MM-dd");
                        entregaArregloFloralCeremoniaDTO.TipoArregloFloral = dr["TipoArregloFloral"].ToString();
                        entregaArregloFloralCeremoniaDTO.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                        entregaArregloFloralCeremoniaDTO.CodigoUnidadMedida = dr["CodigoUnidadMedida"].ToString();
                        entregaArregloFloralCeremoniaDTO.CostoUnitario = Convert.ToDecimal(dr["CostoUnitario"]);
                        entregaArregloFloralCeremoniaDTO.CodigoFrecuenciaDifusion = dr["CodigoFrecuenciaDifusion"].ToString();
                        entregaArregloFloralCeremoniaDTO.CodigoPublicoObjetivo = dr["CodigoPublicoObjetivo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return entregaArregloFloralCeremoniaDTO;
        }

        public string ActualizaFormato(EntregaArregloFloralCeremoniaDTO entregaArregloFloralCeremoniaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EntregaArregloFloralCeremoniaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EntregaArregloFloralCeremoniaId", SqlDbType.Int);
                    cmd.Parameters["@EntregaArregloFloralCeremoniaId"].Value = entregaArregloFloralCeremoniaDTO.EntregaArregloFloralCeremoniaId;

                    cmd.Parameters.Add("@FechaAdquisicion", SqlDbType.Date);
                    cmd.Parameters["@FechaAdquisicion"].Value = entregaArregloFloralCeremoniaDTO.FechaAdquisicion;

                    cmd.Parameters.Add("@TipoArregloFloral", SqlDbType.VarChar, 100);
                    cmd.Parameters["@TipoArregloFloral"].Value = entregaArregloFloralCeremoniaDTO.TipoArregloFloral;

                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int);
                    cmd.Parameters["@Cantidad"].Value = entregaArregloFloralCeremoniaDTO.Cantidad;

                    cmd.Parameters.Add("@CodigoUnidadMedida ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadMedida "].Value = entregaArregloFloralCeremoniaDTO.CodigoUnidadMedida;

                    cmd.Parameters.Add("@CostoUnitario", SqlDbType.Decimal);
                    cmd.Parameters["@CostoUnitario"].Value = entregaArregloFloralCeremoniaDTO.CostoUnitario;

                    cmd.Parameters.Add("@CodigoFrecuenciaDifusion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFrecuenciaDifusion "].Value = entregaArregloFloralCeremoniaDTO.CodigoFrecuenciaDifusion;

                    cmd.Parameters.Add("@CodigoPublicoObjetivo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPublicoObjetivo "].Value = entregaArregloFloralCeremoniaDTO.CodigoPublicoObjetivo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entregaArregloFloralCeremoniaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EntregaArregloFloralCeremoniaDTO entregaArregloFloralCeremoniaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EntregaArregloFloralCeremoniaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntregaArregloFloralCeremoniaId", SqlDbType.Int);
                    cmd.Parameters["@EntregaArregloFloralCeremoniaId"].Value = entregaArregloFloralCeremoniaDTO.EntregaArregloFloralCeremoniaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entregaArregloFloralCeremoniaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EntregaArregloFloralCeremoniaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntregaArregloFloralCeremonia", SqlDbType.Structured);
                    cmd.Parameters["@EntregaArregloFloralCeremonia"].TypeName = "Formato.EntregaArregloFloralCeremonia";
                    cmd.Parameters["@EntregaArregloFloralCeremonia"].Value = datos;

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

