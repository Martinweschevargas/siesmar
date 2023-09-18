using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CapitaniaDAO
    {

        SqlCommand cmd = new();

        public List<CapitaniaDTO> ObtenerCapitanias()
        {
            List<CapitaniaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CapitaniaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CapitaniaDTO()
                        {
                            CapitaniaId = Convert.ToInt32(dr["CapitaniaId"]),
                            NombreCapitania = dr["NombreCapitania"].ToString(),
                            DescCapitania = dr["DescCapitania"].ToString(),
                            CodigoCapitania = dr["CodigoCapitania"].ToString(),
                            JefaturaDistritoCapitaniaDesc = dr["DescJefaturaDistritoCapitania"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCapitania(CapitaniaDTO capitaniaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CapitaniaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NombreCapitania", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@NombreCapitania"].Value = capitaniaDTO.NombreCapitania;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = capitaniaDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@DescCapitania", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescCapitania"].Value = capitaniaDTO.DescCapitania;

                    cmd.Parameters.Add("@CodigoCapitania", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapitania"].Value = capitaniaDTO.CodigoCapitania;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capitaniaDTO.UsuarioIngresoRegistro;

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

        public CapitaniaDTO BuscarCapitaniaID(int Codigo)
        {
            CapitaniaDTO capitaniaDTO = new CapitaniaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CapitaniaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        capitaniaDTO.CapitaniaId = Convert.ToInt32(dr["CapitaniaId"]);
                        capitaniaDTO.NombreCapitania = dr["NombreCapitania"].ToString();
                        capitaniaDTO.DescCapitania = dr["DescCapitania"].ToString();
                        capitaniaDTO.CodigoCapitania = dr["CodigoCapitania"].ToString();
                        capitaniaDTO.JefaturaDistritoCapitaniaId = Convert.ToInt32(dr["JefaturaDistritoCapitaniaId"]);
                        capitaniaDTO.JefaturaDistritoCapitaniaDesc = dr["DescJefaturaDistritoCapitania"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return capitaniaDTO;
        }

        public string ActualizarCapitania(CapitaniaDTO capitaniaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CapitaniaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = capitaniaDTO.CapitaniaId;

                    cmd.Parameters.Add("@JefaturaDistritoCapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@JefaturaDistritoCapitaniaId"].Value = capitaniaDTO.JefaturaDistritoCapitaniaId;

                    cmd.Parameters.Add("@NombreCapitania", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NombreCapitania"].Value = capitaniaDTO.NombreCapitania;

                    cmd.Parameters.Add("@DescCapitania", SqlDbType.VarChar, 10);
                    cmd.Parameters["@DescCapitania"].Value = capitaniaDTO.DescCapitania;

                    cmd.Parameters.Add("@CodigoCapitania", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapitania"].Value = capitaniaDTO.CodigoCapitania;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capitaniaDTO.UsuarioIngresoRegistro;

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

        public string EliminarCapitania(CapitaniaDTO capitaniaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CapitaniaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapitaniaId", SqlDbType.Int);
                    cmd.Parameters["@CapitaniaId"].Value = capitaniaDTO.CapitaniaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capitaniaDTO.UsuarioIngresoRegistro;

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
