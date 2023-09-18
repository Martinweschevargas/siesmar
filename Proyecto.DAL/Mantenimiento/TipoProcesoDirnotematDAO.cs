using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoProcesoDirnotematDAO
    {

        SqlCommand cmd = new();

        public List<TipoProcesoDirnotematDTO> ObtenerTipoProcesoDirnotemats()
        {
            List<TipoProcesoDirnotematDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoProcesoDirnotematListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoProcesoDirnotematDTO()
                        {
                            TipoProcesoDirnotematId = Convert.ToInt32(dr["TipoProcesoDirnotematId"]),
                            DescTipoProcesoDirnotemat = dr["DescTipoProcesoDirnotemat"].ToString(),
                            CodigoTipoProcesoDirnotemat = dr["CodigoTipoProcesoDirnotemat"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoProcesoDirnotemat(TipoProcesoDirnotematDTO tipoProcesoDirnotematDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoProcesoDirnotematRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoProcesoDirnotemat", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoProcesoDirnotemat"].Value = tipoProcesoDirnotematDTO.DescTipoProcesoDirnotemat;

                    cmd.Parameters.Add("@CodigoTipoProcesoDirnotemat", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoProcesoDirnotemat"].Value = tipoProcesoDirnotematDTO.CodigoTipoProcesoDirnotemat;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoProcesoDirnotematDTO.UsuarioIngresoRegistro;

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

        public TipoProcesoDirnotematDTO BuscarTipoProcesoDirnotematID(int Codigo)
        {
            TipoProcesoDirnotematDTO tipoProcesoDirnotematDTO = new TipoProcesoDirnotematDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoProcesoDirnotematEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoProcesoDirnotematId", SqlDbType.Int);
                    cmd.Parameters["@TipoProcesoDirnotematId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoProcesoDirnotematDTO.TipoProcesoDirnotematId = Convert.ToInt32(dr["TipoProcesoDirnotematId"]);
                        tipoProcesoDirnotematDTO.DescTipoProcesoDirnotemat = dr["DescTipoProcesoDirnotemat"].ToString();
                        tipoProcesoDirnotematDTO.CodigoTipoProcesoDirnotemat = dr["CodigoTipoProcesoDirnotemat"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoProcesoDirnotematDTO;
        }

        public string ActualizarTipoProcesoDirnotemat(TipoProcesoDirnotematDTO tipoProcesoDirnotematDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoProcesoDirnotematActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoProcesoDirnotematId", SqlDbType.Int);
                    cmd.Parameters["@TipoProcesoDirnotematId"].Value = tipoProcesoDirnotematDTO.TipoProcesoDirnotematId;

                    cmd.Parameters.Add("@DescTipoProcesoDirnotemat", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoProcesoDirnotemat"].Value = tipoProcesoDirnotematDTO.DescTipoProcesoDirnotemat;

                    cmd.Parameters.Add("@CodigoTipoProcesoDirnotemat", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoProcesoDirnotemat"].Value = tipoProcesoDirnotematDTO.CodigoTipoProcesoDirnotemat;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoProcesoDirnotematDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTipoProcesoDirnotemat(TipoProcesoDirnotematDTO tipoProcesoDirnotematDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoProcesoDirnotematEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoProcesoDirnotematId", SqlDbType.Int);
                    cmd.Parameters["@TipoProcesoDirnotematId"].Value = tipoProcesoDirnotematDTO.TipoProcesoDirnotematId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoProcesoDirnotematDTO.UsuarioIngresoRegistro;

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
