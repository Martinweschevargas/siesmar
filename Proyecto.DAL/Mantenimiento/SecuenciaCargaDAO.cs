using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SecuenciaCargaDAO
    {

        SqlCommand cmd = new();

        public List<SecuenciaCargaDTO> ObtenerSecuenciaCargas()
        {
            List<SecuenciaCargaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SecuenciaCargaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SecuenciaCargaDTO()
                        {
                            NOM_TABLA = dr["NOM_TABLA"].ToString(),
                            NUM_SECUENCIA = Convert.ToInt32(dr["NUM_SECUENCIA"]),
                            FEC_REGISTRO = Convert.ToDateTime(dr["FEC_REGISTRO"]).ToString("yyyy-MM-dd HH:mm:ss"),
                            USR_REGISTRO = Convert.ToInt32(dr["USR_REGISTRO"]),
                            FEC_ACTUALIZO = Convert.ToDateTime(dr["FEC_ACTUALIZO"]).ToString("yyyy-MM-dd HH:mm:ss"),
                            USR_ACTUALIZO = Convert.ToInt32(dr["USR_ACTUALIZO"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSecuenciaCarga(SecuenciaCargaDTO secuenciaCargaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SecuenciaCargaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NOM_TABLA", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NOM_TABLA"].Value = secuenciaCargaDTO.NOM_TABLA;

                    cmd.Parameters.Add("@NUM_SECUENCIA", SqlDbType.Int);
                    cmd.Parameters["@NUM_SECUENCIA"].Value = secuenciaCargaDTO.NUM_SECUENCIA;

                    cmd.Parameters.Add("@FEC_REGISTRO", SqlDbType.DateTime);
                    cmd.Parameters["@FEC_REGISTRO"].Value = secuenciaCargaDTO.FEC_REGISTRO;

                    cmd.Parameters.Add("@USR_REGISTRO", SqlDbType.Int);
                    cmd.Parameters["@USR_REGISTRO"].Value = secuenciaCargaDTO.USR_REGISTRO;

                    cmd.Parameters.Add("@FEC_ACTUALIZO", SqlDbType.DateTime);
                    cmd.Parameters["@FEC_ACTUALIZO"].Value = secuenciaCargaDTO.FEC_ACTUALIZO;

                    cmd.Parameters.Add("@USR_ACTUALIZO", SqlDbType.Int);
                    cmd.Parameters["@USR_ACTUALIZO"].Value = secuenciaCargaDTO.USR_ACTUALIZO;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = secuenciaCargaDTO.UsuarioIngresoRegistro;

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

        public SecuenciaCargaDTO BuscarSecuenciaCargaID(string NOM_TABLA)
        {
            SecuenciaCargaDTO secuenciaCargaDTO = new SecuenciaCargaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SecuenciaCargaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NOM_TABLA", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NOM_TABLA"].Value = NOM_TABLA;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        secuenciaCargaDTO.NOM_TABLA = dr["NOM_TABLA"].ToString();
                        secuenciaCargaDTO.NUM_SECUENCIA = Convert.ToInt32(dr["NUM_SECUENCIA"]);
                        secuenciaCargaDTO.FEC_REGISTRO = Convert.ToDateTime(dr["FEC_REGISTRO"]).ToString("yyy-MM-dd HH:mm:ss");
                        secuenciaCargaDTO.USR_REGISTRO = Convert.ToInt32(dr["USR_REGISTRO"]);
                        secuenciaCargaDTO.FEC_ACTUALIZO = Convert.ToDateTime(dr["FEC_ACTUALIZO"]).ToString("yyy-MM-dd HH:mm:ss");
                        secuenciaCargaDTO.USR_ACTUALIZO = Convert.ToInt32(dr["USR_ACTUALIZO"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return secuenciaCargaDTO;
        }

        public string ActualizarSecuenciaCarga(SecuenciaCargaDTO secuenciaCargaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SecuenciaCargaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure; 

                    cmd.Parameters.Add("@NOM_TABLA", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NOM_TABLA"].Value = secuenciaCargaDTO.NOM_TABLA;

                    cmd.Parameters.Add("@NUM_SECUENCIA", SqlDbType.Int);
                    cmd.Parameters["@NUM_SECUENCIA"].Value = secuenciaCargaDTO.NUM_SECUENCIA;

                    cmd.Parameters.Add("@FEC_REGISTRO", SqlDbType.DateTime);
                    cmd.Parameters["@FEC_REGISTRO"].Value = secuenciaCargaDTO.FEC_REGISTRO;

                    cmd.Parameters.Add("@USR_REGISTRO", SqlDbType.Int);
                    cmd.Parameters["@USR_REGISTRO"].Value = secuenciaCargaDTO.USR_REGISTRO;

                    cmd.Parameters.Add("@FEC_ACTUALIZO", SqlDbType.DateTime);
                    cmd.Parameters["@FEC_ACTUALIZO"].Value = secuenciaCargaDTO.FEC_ACTUALIZO;

                    cmd.Parameters.Add("@USR_ACTUALIZO", SqlDbType.Int);
                    cmd.Parameters["@USR_ACTUALIZO"].Value = secuenciaCargaDTO.USR_ACTUALIZO;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = secuenciaCargaDTO.UsuarioIngresoRegistro;

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

        public string EliminarSecuenciaCarga(SecuenciaCargaDTO secuenciaCargaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SecuenciaCargaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NOM_TABLA", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NOM_TABLA"].Value = secuenciaCargaDTO.NOM_TABLA;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = secuenciaCargaDTO.UsuarioIngresoRegistro;

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
