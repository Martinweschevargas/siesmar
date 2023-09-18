using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class InfraccionDisciplinariaEspecificaDAO
    {

        SqlCommand cmd = new();

        public List<InfraccionDisciplinariaEspecificaDTO> ObtenerInfraccionDisciplinariaEspecificas()
        {
            List<InfraccionDisciplinariaEspecificaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_InfraccionDisciplinariaEspecificaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new InfraccionDisciplinariaEspecificaDTO()
                        {
                            InfraccionDisciplinariaEspecificaId = Convert.ToInt32(dr["InfraccionDisciplinariaEspecificaId"]),
                            DescInfraccionDisciplinariaEspecifica = dr["DescInfraccionDisciplinariaEspecifica"].ToString(),
                            CodigoInfraccionDisciplinariaEspecifica = dr["CodigoInfraccionDisciplinariaEspecifica"].ToString(),
                            DescInfraccionDisciplinariaGenerica = dr["DescInfraccionDisciplinariaGenerica"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarInfraccionDisciplinariaEspecifica(InfraccionDisciplinariaEspecificaDTO puertoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InfraccionDisciplinariaEspecificaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescInfraccionDisciplinariaEspecifica", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescInfraccionDisciplinariaEspecifica"].Value = puertoDTO.DescInfraccionDisciplinariaEspecifica;

                    cmd.Parameters.Add("@CodigoInfraccionDisciplinariaEspecifica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInfraccionDisciplinariaEspecifica"].Value = puertoDTO.CodigoInfraccionDisciplinariaEspecifica;

                    cmd.Parameters.Add("@InfraccionDisciplinariaGenericaId", SqlDbType.Int);
                    cmd.Parameters["@InfraccionDisciplinariaGenericaId"].Value = puertoDTO.InfraccionDisciplinariaGenericaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = puertoDTO.UsuarioIngresoRegistro;

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

        public InfraccionDisciplinariaEspecificaDTO BuscarInfraccionDisciplinariaEspecificaID(int Codigo)
        {
            InfraccionDisciplinariaEspecificaDTO puertoDTO = new InfraccionDisciplinariaEspecificaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InfraccionDisciplinariaEspecificaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InfraccionDisciplinariaEspecificaId", SqlDbType.Int);
                    cmd.Parameters["@InfraccionDisciplinariaEspecificaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        puertoDTO.InfraccionDisciplinariaEspecificaId = Convert.ToInt32(dr["InfraccionDisciplinariaEspecificaId"]);
                        puertoDTO.DescInfraccionDisciplinariaEspecifica = dr["DescInfraccionDisciplinariaEspecifica"].ToString();
                        puertoDTO.CodigoInfraccionDisciplinariaEspecifica = dr["CodigoInfraccionDisciplinariaEspecifica"].ToString();
                        puertoDTO.InfraccionDisciplinariaGenericaId = Convert.ToInt32(dr["InfraccionDisciplinariaGenericaId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return puertoDTO;
        }

        public string ActualizarInfraccionDisciplinariaEspecifica(InfraccionDisciplinariaEspecificaDTO puertoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_InfraccionDisciplinariaEspecificaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InfraccionDisciplinariaEspecificaId", SqlDbType.Int);
                    cmd.Parameters["@InfraccionDisciplinariaEspecificaId"].Value = puertoDTO.InfraccionDisciplinariaEspecificaId;

                    cmd.Parameters.Add("@DescInfraccionDisciplinariaEspecifica", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescInfraccionDisciplinariaEspecifica"].Value = puertoDTO.DescInfraccionDisciplinariaEspecifica;

                    cmd.Parameters.Add("@CodigoInfraccionDisciplinariaEspecifica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInfraccionDisciplinariaEspecifica"].Value = puertoDTO.CodigoInfraccionDisciplinariaEspecifica;

                    cmd.Parameters.Add("@InfraccionDisciplinariaGenericaId", SqlDbType.Int);
                    cmd.Parameters["@InfraccionDisciplinariaGenericaId"].Value = puertoDTO.InfraccionDisciplinariaGenericaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = puertoDTO.UsuarioIngresoRegistro;

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

        public string EliminarInfraccionDisciplinariaEspecifica(InfraccionDisciplinariaEspecificaDTO puertoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InfraccionDisciplinariaEspecificaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InfraccionDisciplinariaEspecificaId", SqlDbType.Int);
                    cmd.Parameters["@InfraccionDisciplinariaEspecificaId"].Value = puertoDTO.InfraccionDisciplinariaEspecificaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = puertoDTO.UsuarioIngresoRegistro;

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
