using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dihidronav
{
    public class MillaNavegadaCombustibleHidrografiaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<MillaNavegadaCombustibleHidrografiaDTO> ObtenerLista(int? CargaId=null)
        {
            List<MillaNavegadaCombustibleHidrografiaDTO> lista = new List<MillaNavegadaCombustibleHidrografiaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_MillaNavegadaCombustibleHidrografiaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MillaNavegadaCombustibleHidrografiaDTO()
                        {
                            MillaNavegadaCombustibleHidrografiaId = Convert.ToInt32(dr["MillaNavegadaCombustibleHidrografiaId"]),
                            NumeroOrden = Convert.ToInt32(dr["NumeroOrden"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            NumeroCascoUnidad = dr["NumeroCascoUnidad"].ToString(),
                            DescMes = dr["DescMes"].ToString(),
                            Milla = Convert.ToDecimal(dr["Milla"]),
                            Hora = Convert.ToDecimal(dr["Hora"]),
                            CombustibleGalon = Convert.ToDecimal(dr["CombustibleGalon"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(MillaNavegadaCombustibleHidrografiaDTO millaNavegadaCombustibleHidrografiaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MillaNavegadaCombustibleHidrografiaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroOrden", SqlDbType.Int);
                    cmd.Parameters["@NumeroOrden"].Value = millaNavegadaCombustibleHidrografiaDTO.NumeroOrden;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = millaNavegadaCombustibleHidrografiaDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@NumeroCascoUnidad", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroCascoUnidad"].Value = millaNavegadaCombustibleHidrografiaDTO.NumeroCascoUnidad;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroMes"].Value = millaNavegadaCombustibleHidrografiaDTO.NumeroMes;

                    cmd.Parameters.Add("@Milla", SqlDbType.Decimal);
                    cmd.Parameters["@Milla"].Value = millaNavegadaCombustibleHidrografiaDTO.Milla;

                    cmd.Parameters.Add("@Hora", SqlDbType.Decimal);
                    cmd.Parameters["@Hora"].Value = millaNavegadaCombustibleHidrografiaDTO.Hora;

                    cmd.Parameters.Add("@CombustibleGalon", SqlDbType.Decimal);
                    cmd.Parameters["@CombustibleGalon"].Value = millaNavegadaCombustibleHidrografiaDTO.CombustibleGalon;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = millaNavegadaCombustibleHidrografiaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = millaNavegadaCombustibleHidrografiaDTO.UsuarioIngresoRegistro;

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

        public MillaNavegadaCombustibleHidrografiaDTO BuscarFormato(int Codigo)
        {
            MillaNavegadaCombustibleHidrografiaDTO millaNavegadaCombustibleHidrografiaDTO = new MillaNavegadaCombustibleHidrografiaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MillaNavegadaCombustibleHidrografiaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MillaNavegadaCombustibleHidrografiaId", SqlDbType.Int);
                    cmd.Parameters["@MillaNavegadaCombustibleHidrografiaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        millaNavegadaCombustibleHidrografiaDTO.MillaNavegadaCombustibleHidrografiaId = Convert.ToInt32(dr["MillaNavegadaCombustibleHidrografiaId"]);
                        millaNavegadaCombustibleHidrografiaDTO.NumeroOrden = Convert.ToInt32(dr["NumeroOrden"]);
                        millaNavegadaCombustibleHidrografiaDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        millaNavegadaCombustibleHidrografiaDTO.NumeroCascoUnidad = dr["NumeroCascoUnidad"].ToString();
                        millaNavegadaCombustibleHidrografiaDTO.NumeroMes = dr["NumeroMes"].ToString();
                        millaNavegadaCombustibleHidrografiaDTO.Milla = Convert.ToDecimal(dr["Milla"]);
                        millaNavegadaCombustibleHidrografiaDTO.Hora = Convert.ToDecimal(dr["Hora"]);
                        millaNavegadaCombustibleHidrografiaDTO.CombustibleGalon = Convert.ToDecimal(dr["CombustibleGalon"]); 
 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return millaNavegadaCombustibleHidrografiaDTO;
        }

        public string ActualizaFormato(MillaNavegadaCombustibleHidrografiaDTO millaNavegadaCombustibleHidrografiaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_MillaNavegadaCombustibleHidrografiaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@MillaNavegadaCombustibleHidrografiaId", SqlDbType.Int);
                    cmd.Parameters["@MillaNavegadaCombustibleHidrografiaId"].Value = millaNavegadaCombustibleHidrografiaDTO.MillaNavegadaCombustibleHidrografiaId;

                    cmd.Parameters.Add("@NumeroOrden", SqlDbType.Int);
                    cmd.Parameters["@NumeroOrden"].Value = millaNavegadaCombustibleHidrografiaDTO.NumeroOrden;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = millaNavegadaCombustibleHidrografiaDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@NumeroCascoUnidad", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroCascoUnidad"].Value = millaNavegadaCombustibleHidrografiaDTO.NumeroCascoUnidad;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroMes"].Value = millaNavegadaCombustibleHidrografiaDTO.NumeroMes;

                    cmd.Parameters.Add("@Milla", SqlDbType.Decimal);
                    cmd.Parameters["@Milla"].Value = millaNavegadaCombustibleHidrografiaDTO.Milla;

                    cmd.Parameters.Add("@Hora", SqlDbType.Decimal);
                    cmd.Parameters["@Hora"].Value = millaNavegadaCombustibleHidrografiaDTO.Hora;

                    cmd.Parameters.Add("@CombustibleGalon", SqlDbType.Decimal);
                    cmd.Parameters["@CombustibleGalon"].Value = millaNavegadaCombustibleHidrografiaDTO.CombustibleGalon;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = millaNavegadaCombustibleHidrografiaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(MillaNavegadaCombustibleHidrografiaDTO millaNavegadaCombustibleHidrografiaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MillaNavegadaCombustibleHidrografiaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MillaNavegadaCombustibleHidrografiaId", SqlDbType.Int);
                    cmd.Parameters["@MillaNavegadaCombustibleHidrografiaId"].Value = millaNavegadaCombustibleHidrografiaDTO.MillaNavegadaCombustibleHidrografiaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = millaNavegadaCombustibleHidrografiaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_MillaNavegadaCombustibleHidrografiaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MillaNavegadaCombustibleHidrografia", SqlDbType.Structured);
                    cmd.Parameters["@MillaNavegadaCombustibleHidrografia"].TypeName = "Formato.MillaNavegadaCombustibleHidrografia";
                    cmd.Parameters["@MillaNavegadaCombustibleHidrografia"].Value = datos;

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
