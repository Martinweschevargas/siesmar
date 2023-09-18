using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dimar
{
    public class AtencionProtocolarAeropuertoCallaoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AtencionProtocolarAeropuertoCallaoDTO> ObtenerLista(int? CargaId = null)
        {
            List<AtencionProtocolarAeropuertoCallaoDTO> lista = new List<AtencionProtocolarAeropuertoCallaoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AtencionProtocolarAeropuertoCallaoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AtencionProtocolarAeropuertoCallaoDTO()
                        {
                            AtencionProtocolarAeropuertoCallaoId = Convert.ToInt32(dr["AtencionProtocolarAeropuertoCallaoId"]),
                            FechaAdquisicion = (dr["FechaAdquisicion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescTipoPresenteProtocolar = dr["TipoPresenteProtocolarId"].ToString(),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            DescUnidadMedida = dr["DescUnidadMedida"].ToString(),
                            CostoUnitario = Convert.ToDecimal(dr["CostoUnitario"]),
                            DescFrecuenciaDifusion = dr["DescFrecuenciaDifusion"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AtencionProtocolarAeropuertoCallaoDTO atencionProtocolarAeropuertoCallaoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AtencionProtocolarAeropuertoCallaoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaAdquisicion", SqlDbType.Date);
                    cmd.Parameters["@FechaAdquisicion"].Value = atencionProtocolarAeropuertoCallaoDTO.FechaAdquisicion;

                    cmd.Parameters.Add("@CodigoTipoPresenteProtocolar ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPresenteProtocolar "].Value = atencionProtocolarAeropuertoCallaoDTO.CodigoTipoPresenteProtocolar;

                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int);
                    cmd.Parameters["@Cantidad"].Value = atencionProtocolarAeropuertoCallaoDTO.Cantidad;

                    cmd.Parameters.Add("@CodigoUnidadMedida ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadMedida "].Value = atencionProtocolarAeropuertoCallaoDTO.CodigoUnidadMedida;

                    cmd.Parameters.Add("@CostoUnitario", SqlDbType.Decimal);
                    cmd.Parameters["@CostoUnitario"].Value = atencionProtocolarAeropuertoCallaoDTO.CostoUnitario;

                    cmd.Parameters.Add("@CodigoFrecuenciaDifusion ", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoFrecuenciaDifusion "].Value = atencionProtocolarAeropuertoCallaoDTO.CodigoFrecuenciaDifusion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = atencionProtocolarAeropuertoCallaoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = atencionProtocolarAeropuertoCallaoDTO.UsuarioIngresoRegistro;

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

        public AtencionProtocolarAeropuertoCallaoDTO BuscarFormato(int Codigo)
        {
            AtencionProtocolarAeropuertoCallaoDTO atencionProtocolarAeropuertoCallaoDTO = new AtencionProtocolarAeropuertoCallaoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AtencionProtocolarAeropuertoCallaoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AtencionProtocolarAeropuertoCallaoId", SqlDbType.Int);
                    cmd.Parameters["@AtencionProtocolarAeropuertoCallaoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        atencionProtocolarAeropuertoCallaoDTO.AtencionProtocolarAeropuertoCallaoId = Convert.ToInt32(dr["AtencionProtocolarAeropuertoCallaoId"]);
                        atencionProtocolarAeropuertoCallaoDTO.FechaAdquisicion = Convert.ToDateTime(dr["FechaAdquisicion"]).ToString("yyy-MM-dd");
                        atencionProtocolarAeropuertoCallaoDTO.CodigoTipoPresenteProtocolar = dr["CodigoTipoPresenteProtocolar"].ToString();
                        atencionProtocolarAeropuertoCallaoDTO.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                        atencionProtocolarAeropuertoCallaoDTO.CodigoUnidadMedida = dr["CodigoUnidadMedida"].ToString();
                        atencionProtocolarAeropuertoCallaoDTO.CostoUnitario = Convert.ToDecimal(dr["CostoUnitario"]);
                        atencionProtocolarAeropuertoCallaoDTO.CodigoFrecuenciaDifusion = dr["CodigoFrecuenciaDifusion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return atencionProtocolarAeropuertoCallaoDTO;
        }

        public string ActualizaFormato(AtencionProtocolarAeropuertoCallaoDTO atencionProtocolarAeropuertoCallaoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AtencionProtocolarAeropuertoCallaoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AtencionProtocolarAeropuertoCallaoId", SqlDbType.Int);
                    cmd.Parameters["@AtencionProtocolarAeropuertoCallaoId"].Value = atencionProtocolarAeropuertoCallaoDTO.AtencionProtocolarAeropuertoCallaoId;

                    cmd.Parameters.Add("@FechaAdquisicion", SqlDbType.Date);
                    cmd.Parameters["@FechaAdquisicion"].Value = atencionProtocolarAeropuertoCallaoDTO.FechaAdquisicion;

                    cmd.Parameters.Add("@CodigoTipoPresenteProtocolar ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPresenteProtocolar "].Value = atencionProtocolarAeropuertoCallaoDTO.CodigoTipoPresenteProtocolar;

                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int);
                    cmd.Parameters["@Cantidad"].Value = atencionProtocolarAeropuertoCallaoDTO.Cantidad;

                    cmd.Parameters.Add("@CodigoUnidadMedida ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadMedida "].Value = atencionProtocolarAeropuertoCallaoDTO.CodigoUnidadMedida;

                    cmd.Parameters.Add("@CostoUnitario", SqlDbType.Decimal);
                    cmd.Parameters["@CostoUnitario"].Value = atencionProtocolarAeropuertoCallaoDTO.CostoUnitario;

                    cmd.Parameters.Add("@CodigoFrecuenciaDifusion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFrecuenciaDifusion "].Value = atencionProtocolarAeropuertoCallaoDTO.CodigoFrecuenciaDifusion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = atencionProtocolarAeropuertoCallaoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AtencionProtocolarAeropuertoCallaoDTO atencionProtocolarAeropuertoCallaoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AtencionProtocolarAeropuertoCallaoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AtencionProtocolarAeropuertoCallaoId", SqlDbType.Int);
                    cmd.Parameters["@AtencionProtocolarAeropuertoCallaoId"].Value = atencionProtocolarAeropuertoCallaoDTO.AtencionProtocolarAeropuertoCallaoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = atencionProtocolarAeropuertoCallaoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_AtencionProtocolarAeropuertoCallaoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AtencionProtocolarAeropuertoCallao", SqlDbType.Structured);
                    cmd.Parameters["@AtencionProtocolarAeropuertoCallao"].TypeName = "Formato.AtencionProtocolarAeropuertoCallao";
                    cmd.Parameters["@AtencionProtocolarAeropuertoCallao"].Value = datos;

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
