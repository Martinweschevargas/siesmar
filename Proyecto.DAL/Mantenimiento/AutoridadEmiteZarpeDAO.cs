using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AutoridadEmiteZarpeDAO
    {

        SqlCommand cmd = new();

        public List<AutoridadEmiteZarpeDTO> ObtenerAutoridadEmiteZarpes()
        {
            List<AutoridadEmiteZarpeDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AutoridadEmiteZarpeListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AutoridadEmiteZarpeDTO()
                        {
                            AutoridadEmiteZarpeId = Convert.ToInt32(dr["AutoridadEmiteZarpeId"]),
                            DescAutoridadEmiteZarpe = dr["DescAutoridadEmiteZarpe"].ToString(),
                            CodigoAutoridadEmiteZarpe = dr["CodigoAutoridadEmiteZarpe"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAutoridadEmiteZarpe(AutoridadEmiteZarpeDTO AutoridadEmiteZarpeDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AutoridadEmiteZarpeRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescAutoridadEmiteZarpe", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescAutoridadEmiteZarpe"].Value = AutoridadEmiteZarpeDTO.DescAutoridadEmiteZarpe;

                    cmd.Parameters.Add("@CodigoAutoridadEmiteZarpe", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoAutoridadEmiteZarpe"].Value = AutoridadEmiteZarpeDTO.CodigoAutoridadEmiteZarpe;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AutoridadEmiteZarpeDTO.UsuarioIngresoRegistro;

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

        public AutoridadEmiteZarpeDTO BuscarAutoridadEmiteZarpeID(int Codigo)
        {
            AutoridadEmiteZarpeDTO AutoridadEmiteZarpeDTO = new AutoridadEmiteZarpeDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AutoridadEmiteZarpeEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AutoridadEmiteZarpeId", SqlDbType.Int);
                    cmd.Parameters["@AutoridadEmiteZarpeId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        AutoridadEmiteZarpeDTO.AutoridadEmiteZarpeId = Convert.ToInt32(dr["AutoridadEmiteZarpeId"]);
                        AutoridadEmiteZarpeDTO.DescAutoridadEmiteZarpe = dr["DescAutoridadEmiteZarpe"].ToString();
                        AutoridadEmiteZarpeDTO.CodigoAutoridadEmiteZarpe = dr["CodigoAutoridadEmiteZarpe"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return AutoridadEmiteZarpeDTO;
        }

        public string ActualizarAutoridadEmiteZarpe(AutoridadEmiteZarpeDTO AutoridadEmiteZarpeDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AutoridadEmiteZarpeActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AutoridadEmiteZarpeId", SqlDbType.Int);
                    cmd.Parameters["@AutoridadEmiteZarpeId"].Value = AutoridadEmiteZarpeDTO.AutoridadEmiteZarpeId;

                    cmd.Parameters.Add("@DescAutoridadEmiteZarpe", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescAutoridadEmiteZarpe"].Value = AutoridadEmiteZarpeDTO.DescAutoridadEmiteZarpe;

                    cmd.Parameters.Add("@CodigoAutoridadEmiteZarpe", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoAutoridadEmiteZarpe"].Value = AutoridadEmiteZarpeDTO.CodigoAutoridadEmiteZarpe;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AutoridadEmiteZarpeDTO.UsuarioIngresoRegistro;

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

        public string EliminarAutoridadEmiteZarpe(AutoridadEmiteZarpeDTO AutoridadEmiteZarpeDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AutoridadEmiteZarpeEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AutoridadEmiteZarpeId", SqlDbType.Int);
                    cmd.Parameters["@AutoridadEmiteZarpeId"].Value = AutoridadEmiteZarpeDTO.AutoridadEmiteZarpeId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AutoridadEmiteZarpeDTO.UsuarioIngresoRegistro;

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
