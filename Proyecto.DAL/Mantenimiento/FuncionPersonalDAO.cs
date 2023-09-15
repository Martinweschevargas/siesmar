using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class FuncionPersonalDAO
    {

        SqlCommand cmd = new();

        public List<FuncionPersonalDTO> ObtenerFuncionPersonals()
        {
            List<FuncionPersonalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_FuncionPersonalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new FuncionPersonalDTO()
                        {
                            FuncionPersonalId = Convert.ToInt32(dr["FuncionPersonalId"]),
                            DescFuncionPersonal = dr["DescFuncionPersonal"].ToString(),
                            CodigoFuncionPersonal = dr["CodigoFuncionPersonal"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarFuncionPersonal(FuncionPersonalDTO funcionPersonalDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FuncionPersonalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescFuncionPersonal", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescFuncionPersonal"].Value = funcionPersonalDTO.DescFuncionPersonal;

                    cmd.Parameters.Add("@CodigoFuncionPersonal", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoFuncionPersonal"].Value = funcionPersonalDTO.CodigoFuncionPersonal;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = funcionPersonalDTO.UsuarioIngresoRegistro;

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

        public FuncionPersonalDTO BuscarFuncionPersonalID(int Codigo)
        {
            FuncionPersonalDTO funcionPersonalDTO = new FuncionPersonalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FuncionPersonalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FuncionPersonalId", SqlDbType.Int);
                    cmd.Parameters["@FuncionPersonalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        funcionPersonalDTO.FuncionPersonalId = Convert.ToInt32(dr["FuncionPersonalId"]);
                        funcionPersonalDTO.DescFuncionPersonal = dr["DescFuncionPersonal"].ToString();
                        funcionPersonalDTO.CodigoFuncionPersonal = dr["CodigoFuncionPersonal"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return funcionPersonalDTO;
        }

        public string ActualizarFuncionPersonal(FuncionPersonalDTO funcionPersonalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_FuncionPersonalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FuncionPersonalId", SqlDbType.Int);
                    cmd.Parameters["@FuncionPersonalId"].Value = funcionPersonalDTO.FuncionPersonalId;

                    cmd.Parameters.Add("@DescFuncionPersonal", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescFuncionPersonal"].Value = funcionPersonalDTO.DescFuncionPersonal;

                    cmd.Parameters.Add("@CodigoFuncionPersonal", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoFuncionPersonal"].Value = funcionPersonalDTO.CodigoFuncionPersonal;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = funcionPersonalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFuncionPersonal(FuncionPersonalDTO funcionPersonalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FuncionPersonalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FuncionPersonalId", SqlDbType.Int);
                    cmd.Parameters["@FuncionPersonalId"].Value = funcionPersonalDTO.FuncionPersonalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = funcionPersonalDTO.UsuarioIngresoRegistro;

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
