using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoPrendaDAO
    {

        SqlCommand cmd = new();

        public List<TipoPrendaDTO> ObtenerTipoPrendas()
        {
            List<TipoPrendaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoPrendaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoPrendaDTO()
                        {
                            TipoPrendaId = Convert.ToInt32(dr["TipoPrendaId"]),
                            DescTipoPrenda = dr["DescTipoPrenda"].ToString(),
                            CodigoTipoPrenda = dr["CodigoTipoPrenda"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoPrenda(TipoPrendaDTO tipoPrendaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPrendaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoPrenda", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoPrenda"].Value = tipoPrendaDTO.DescTipoPrenda;

                    cmd.Parameters.Add("@CodigoTipoPrenda", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoPrenda"].Value = tipoPrendaDTO.CodigoTipoPrenda;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoPrendaDTO.UsuarioIngresoRegistro;

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

        public TipoPrendaDTO BuscarTipoPrendaID(int Codigo)
        {
            TipoPrendaDTO tipoPrendaDTO = new TipoPrendaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPrendaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPrendaId", SqlDbType.Int);
                    cmd.Parameters["@TipoPrendaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoPrendaDTO.TipoPrendaId = Convert.ToInt32(dr["TipoPrendaId"]);
                        tipoPrendaDTO.DescTipoPrenda = dr["DescTipoPrenda"].ToString();
                        tipoPrendaDTO.CodigoTipoPrenda = dr["CodigoTipoPrenda"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoPrendaDTO;
        }

        public string ActualizarTipoPrenda(TipoPrendaDTO tipoPrendaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoPrendaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPrendaId", SqlDbType.Int);
                    cmd.Parameters["@TipoPrendaId"].Value = tipoPrendaDTO.TipoPrendaId;

                    cmd.Parameters.Add("@DescTipoPrenda", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoPrenda"].Value = tipoPrendaDTO.DescTipoPrenda;

                    cmd.Parameters.Add("@CodigoTipoPrenda", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoPrenda"].Value = tipoPrendaDTO.CodigoTipoPrenda;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoPrendaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoPrenda(TipoPrendaDTO tipoPrendaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPrendaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPrendaId", SqlDbType.Int);
                    cmd.Parameters["@TipoPrendaId"].Value = tipoPrendaDTO.TipoPrendaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoPrendaDTO.UsuarioIngresoRegistro;

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
