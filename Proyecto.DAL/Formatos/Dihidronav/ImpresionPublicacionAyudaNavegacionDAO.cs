using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dihidronav
{
    public class ImpresionPublicacionAyudaNavegacionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ImpresionPublicacionAyudaNavegacionDTO> ObtenerLista(int? CargaId=null)
        {
            List<ImpresionPublicacionAyudaNavegacionDTO> lista = new List<ImpresionPublicacionAyudaNavegacionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ImpresionPublicacionAyudaNavegacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ImpresionPublicacionAyudaNavegacionDTO()
                        {
                            ImpresionPublicacionAyudaNavegacionId = Convert.ToInt32(dr["ImpresionPublicacionAyudaNavegacionId"]),
                            NumeroOrden = Convert.ToInt32(dr["NumeroOrden"]),
                            DescTipoProducto = dr["DescProducto"].ToString(),
                            HidronavNumero = Convert.ToInt32(dr["HidronavNumero"]),
                            FechaEmision = (dr["FechaEmision"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NumeroEdicion = dr["NumeroEdicion"].ToString(),
                            CantidadProducida = Convert.ToInt32(dr["CantidadProducida"]),
                            DescFrecuencia = dr["DescFrecuencia"].ToString(),
                           CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ImpresionPublicacionAyudaNavegacionDTO impresionPublicacionAyudaNavegacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ImpresionPublicacionAyudaNavegacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroOrden", SqlDbType.Int);
                    cmd.Parameters["@NumeroOrden"].Value = impresionPublicacionAyudaNavegacionDTO.NumeroOrden;

                    cmd.Parameters.Add("@CodigoProducto ", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoProducto "].Value = impresionPublicacionAyudaNavegacionDTO.CodigoProducto ;

                    cmd.Parameters.Add("@HidronavNumero", SqlDbType.Int);
                    cmd.Parameters["@HidronavNumero"].Value = impresionPublicacionAyudaNavegacionDTO.HidronavNumero;

                    cmd.Parameters.Add("@FechaEmision", SqlDbType.Date);
                    cmd.Parameters["@FechaEmision"].Value = impresionPublicacionAyudaNavegacionDTO.FechaEmision;

                    cmd.Parameters.Add("@NumeroEdicion", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroEdicion"].Value = impresionPublicacionAyudaNavegacionDTO.NumeroEdicion;

                    cmd.Parameters.Add("@CantidadProducida", SqlDbType.Int);
                    cmd.Parameters["@CantidadProducida"].Value = impresionPublicacionAyudaNavegacionDTO.CantidadProducida;

                    cmd.Parameters.Add("@CodigoFrecuencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoFrecuencia"].Value = impresionPublicacionAyudaNavegacionDTO.CodigoFrecuencia;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = impresionPublicacionAyudaNavegacionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = impresionPublicacionAyudaNavegacionDTO.UsuarioIngresoRegistro;

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

        public ImpresionPublicacionAyudaNavegacionDTO BuscarFormato(int Codigo)
        {
            ImpresionPublicacionAyudaNavegacionDTO impresionPublicacionAyudaNavegacionDTO = new ImpresionPublicacionAyudaNavegacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ImpresionPublicacionAyudaNavegacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ImpresionPublicacionAyudaNavegacionId", SqlDbType.Int);
                    cmd.Parameters["@ImpresionPublicacionAyudaNavegacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        impresionPublicacionAyudaNavegacionDTO.ImpresionPublicacionAyudaNavegacionId = Convert.ToInt32(dr["ImpresionPublicacionAyudaNavegacionId"]);
                        impresionPublicacionAyudaNavegacionDTO.NumeroOrden = Convert.ToInt32(dr["NumeroOrden"]);
                        impresionPublicacionAyudaNavegacionDTO.CodigoProducto  = dr["CodigoProducto "].ToString();
                        impresionPublicacionAyudaNavegacionDTO.HidronavNumero = Convert.ToInt32(dr["HidronavNumero"]);
                        impresionPublicacionAyudaNavegacionDTO.FechaEmision = Convert.ToDateTime(dr["FechaEmision"]).ToString("yyy-MM-dd");
                        impresionPublicacionAyudaNavegacionDTO.NumeroEdicion = dr["NumeroEdicion"].ToString();
                        impresionPublicacionAyudaNavegacionDTO.CantidadProducida = Convert.ToInt32(dr["CantidadProducida"]);
                        impresionPublicacionAyudaNavegacionDTO.CodigoFrecuencia = dr["CodigoFrecuencia"].ToString(); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return impresionPublicacionAyudaNavegacionDTO;
        }

        public string ActualizaFormato(ImpresionPublicacionAyudaNavegacionDTO impresionPublicacionAyudaNavegacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ImpresionPublicacionAyudaNavegacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ImpresionPublicacionAyudaNavegacionId", SqlDbType.Int);
                    cmd.Parameters["@ImpresionPublicacionAyudaNavegacionId"].Value = impresionPublicacionAyudaNavegacionDTO.ImpresionPublicacionAyudaNavegacionId;

                    cmd.Parameters.Add("@NumeroOrden", SqlDbType.Int);
                    cmd.Parameters["@NumeroOrden"].Value = impresionPublicacionAyudaNavegacionDTO.NumeroOrden;

                    cmd.Parameters.Add("@CodigoProducto ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProducto "].Value = impresionPublicacionAyudaNavegacionDTO.CodigoProducto ;

                    cmd.Parameters.Add("@HidronavNumero", SqlDbType.Int);
                    cmd.Parameters["@HidronavNumero"].Value = impresionPublicacionAyudaNavegacionDTO.HidronavNumero;

                    cmd.Parameters.Add("@FechaEmision", SqlDbType.Date);
                    cmd.Parameters["@FechaEmision"].Value = impresionPublicacionAyudaNavegacionDTO.FechaEmision;

                    cmd.Parameters.Add("@NumeroEdicion", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroEdicion"].Value = impresionPublicacionAyudaNavegacionDTO.NumeroEdicion;

                    cmd.Parameters.Add("@CantidadProducida", SqlDbType.Int);
                    cmd.Parameters["@CantidadProducida"].Value = impresionPublicacionAyudaNavegacionDTO.CantidadProducida;

                    cmd.Parameters.Add("@CodigoFrecuencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFrecuencia"].Value = impresionPublicacionAyudaNavegacionDTO.CodigoFrecuencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = impresionPublicacionAyudaNavegacionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ImpresionPublicacionAyudaNavegacionDTO impresionPublicacionAyudaNavegacionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ImpresionPublicacionAyudaNavegacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ImpresionPublicacionAyudaNavegacionId", SqlDbType.Int);
                    cmd.Parameters["@ImpresionPublicacionAyudaNavegacionId"].Value = impresionPublicacionAyudaNavegacionDTO.ImpresionPublicacionAyudaNavegacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = impresionPublicacionAyudaNavegacionDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ImpresionPublicacionAyudaNavegacionRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ImpresionPublicacionAyudaNavegacion", SqlDbType.Structured);
                    cmd.Parameters["@ImpresionPublicacionAyudaNavegacion"].TypeName = "Formato.ImpresionPublicacionAyudaNavegacion";
                    cmd.Parameters["@ImpresionPublicacionAyudaNavegacion"].Value = datos;

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
