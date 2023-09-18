using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ValorReferencialDAO
    {

        SqlCommand cmd = new();

        public List<ValorReferencialDTO> ObtenerValorReferencials()
        {
            List<ValorReferencialDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ValorReferencialListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ValorReferencialDTO()
                        {
                            ValorReferencialId = Convert.ToInt32(dr["ValorReferencialId"]),
                            DescValorReferencial = dr["DescValorReferencial"].ToString(),
                            CodigoValorReferencial = dr["CodigoValorReferencial"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarValorReferencial(ValorReferencialDTO valorReferencialDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ValorReferencialRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescValorReferencial", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescValorReferencial"].Value = valorReferencialDTO.DescValorReferencial;

                    cmd.Parameters.Add("@CodigoValorReferencial", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoValorReferencial"].Value = valorReferencialDTO.CodigoValorReferencial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = valorReferencialDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                        }
                    }
                }
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public ValorReferencialDTO BuscarValorReferencialID(int Codigo)
        {
            ValorReferencialDTO valorReferencialDTO = new ValorReferencialDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ValorReferencialEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ValorReferencialId", SqlDbType.Int);
                    cmd.Parameters["@ValorReferencialId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        valorReferencialDTO.ValorReferencialId = Convert.ToInt32(dr["ValorReferencialId"]);
                        valorReferencialDTO.DescValorReferencial = dr["DescValorReferencial"].ToString();
                        valorReferencialDTO.CodigoValorReferencial = dr["CodigoValorReferencial"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return valorReferencialDTO;
        }

        public string ActualizarValorReferencial(ValorReferencialDTO valorReferencialDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ValorReferencialActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ValorReferencialId", SqlDbType.Int);
                    cmd.Parameters["@ValorReferencialId"].Value = valorReferencialDTO.ValorReferencialId;

                    cmd.Parameters.Add("@DescValorReferencial", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescValorReferencial"].Value = valorReferencialDTO.DescValorReferencial;

                    cmd.Parameters.Add("@CodigoValorReferencial", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoValorReferencial"].Value = valorReferencialDTO.CodigoValorReferencial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = valorReferencialDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public bool EliminarValorReferencial(ValorReferencialDTO valorReferencialDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ValorReferencialEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ValorReferencialId", SqlDbType.Int);
                    cmd.Parameters["@ValorReferencialId"].Value = valorReferencialDTO.ValorReferencialId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = valorReferencialDTO.UsuarioIngresoRegistro;

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

    }
}
