using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SituacionPersonalNavalDAO
    {

        SqlCommand cmd = new();

        public List<SituacionPersonalNavalDTO> ObtenerSituacionPersonalNavals()
        {
            List<SituacionPersonalNavalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SituacionPersonalNavalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SituacionPersonalNavalDTO()
                        {
                            SituacionPersonalNavalId = Convert.ToInt32(dr["SituacionPersonalNavalId"]),
                            DescSituacionPersonalNaval = dr["DescSituacionPersonalNaval"].ToString(),
                            CodigoSituacionPersonalNaval = dr["CodigoSituacionPersonalNaval"].ToString()

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSituacionPersonalNaval(SituacionPersonalNavalDTO situacionPersonalNavalDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SituacionPersonalNavalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescSituacionPersonalNaval", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescSituacionPersonalNaval"].Value = situacionPersonalNavalDTO.DescSituacionPersonalNaval;

                    cmd.Parameters.Add("@CodigoSituacionPersonalNaval", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoSituacionPersonalNaval"].Value = situacionPersonalNavalDTO.CodigoSituacionPersonalNaval;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionPersonalNavalDTO.UsuarioIngresoRegistro;

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


        public SituacionPersonalNavalDTO BuscarSituacionPersonalNavalID(int Codigo)

        {
            SituacionPersonalNavalDTO situacionPersonalNavalDTO = new SituacionPersonalNavalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SituacionPersonalNavalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionPersonalNavalId", SqlDbType.Int);
                    cmd.Parameters["@SituacionPersonalNavalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        situacionPersonalNavalDTO.SituacionPersonalNavalId = Convert.ToInt32(dr["SituacionPersonalNavalId"]);
                        situacionPersonalNavalDTO.DescSituacionPersonalNaval = dr["DescSituacionPersonalNaval"].ToString();
                        situacionPersonalNavalDTO.CodigoSituacionPersonalNaval = dr["CodigoSituacionPersonalNaval"].ToString();

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return situacionPersonalNavalDTO;
        }

        public string ActualizarSituacionPersonalNaval(SituacionPersonalNavalDTO situacionPersonalNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_SituacionPersonalNavalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionPersonalNavalId", SqlDbType.Int);
                    cmd.Parameters["@SituacionPersonalNavalId"].Value = situacionPersonalNavalDTO.SituacionPersonalNavalId;

                    cmd.Parameters.Add("@DescSituacionPersonalNaval", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescSituacionPersonalNaval"].Value = situacionPersonalNavalDTO.DescSituacionPersonalNaval;

                    cmd.Parameters.Add("@CodigoSituacionPersonalNaval", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoSituacionPersonalNaval"].Value = situacionPersonalNavalDTO.CodigoSituacionPersonalNaval;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionPersonalNavalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarSituacionPersonalNaval(SituacionPersonalNavalDTO situacionPersonalNavalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SituacionPersonalNavalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionPersonalNavalId", SqlDbType.Int);
                    cmd.Parameters["@SituacionPersonalNavalId"].Value = situacionPersonalNavalDTO.SituacionPersonalNavalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionPersonalNavalDTO.UsuarioIngresoRegistro;

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
