using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class InfraccionDisciplinariaGenericaDAO
    {

        SqlCommand cmd = new();

        public List<InfraccionDisciplinariaGenericaDTO> ObtenerInfraccionDisciplinariaGenericas()
        {
            List<InfraccionDisciplinariaGenericaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_InfraccionDisciplinariaGenericaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new InfraccionDisciplinariaGenericaDTO()
                        {
                            InfraccionDisciplinariaGenericaId = Convert.ToInt32(dr["InfraccionDisciplinariaGenericaId"]),
                            DescInfraccionDisciplinariaGenerica = dr["DescInfraccionDisciplinariaGenerica"].ToString(),
                            CodigoInfraccionDisciplinariaGenerica = dr["CodigoInfraccionDisciplinariaGenerica"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarInfraccionDisciplinariaGenerica(InfraccionDisciplinariaGenericaDTO infraccionDisciplinariaGenericaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InfraccionDisciplinariaGenericaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescInfraccionDisciplinariaGenerica", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescInfraccionDisciplinariaGenerica"].Value = infraccionDisciplinariaGenericaDTO.DescInfraccionDisciplinariaGenerica; 
                    
                    cmd.Parameters.Add("@CodigoInfraccionDisciplinariaGenerica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInfraccionDisciplinariaGenerica"].Value = infraccionDisciplinariaGenericaDTO.CodigoInfraccionDisciplinariaGenerica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = infraccionDisciplinariaGenericaDTO.UsuarioIngresoRegistro;

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

        public InfraccionDisciplinariaGenericaDTO BuscarInfraccionDisciplinariaGenericaID(int Codigo)
        {
            InfraccionDisciplinariaGenericaDTO infraccionDisciplinariaGenericaDTO = new InfraccionDisciplinariaGenericaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InfraccionDisciplinariaGenericaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InfraccionDisciplinariaGenericaId", SqlDbType.Int);
                    cmd.Parameters["@InfraccionDisciplinariaGenericaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        infraccionDisciplinariaGenericaDTO.InfraccionDisciplinariaGenericaId = Convert.ToInt32(dr["InfraccionDisciplinariaGenericaId"]);
                        infraccionDisciplinariaGenericaDTO.DescInfraccionDisciplinariaGenerica = dr["DescInfraccionDisciplinariaGenerica"].ToString();
                        infraccionDisciplinariaGenericaDTO.CodigoInfraccionDisciplinariaGenerica = dr["CodigoInfraccionDisciplinariaGenerica"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return infraccionDisciplinariaGenericaDTO;
        }

        public string ActualizarInfraccionDisciplinariaGenerica(InfraccionDisciplinariaGenericaDTO infraccionDisciplinariaGenericaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InfraccionDisciplinariaGenericaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InfraccionDisciplinariaGenericaId", SqlDbType.Int);
                    cmd.Parameters["@InfraccionDisciplinariaGenericaId"].Value = infraccionDisciplinariaGenericaDTO.InfraccionDisciplinariaGenericaId;

                    cmd.Parameters.Add("@DescInfraccionDisciplinariaGenerica", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescInfraccionDisciplinariaGenerica"].Value = infraccionDisciplinariaGenericaDTO.DescInfraccionDisciplinariaGenerica;   
                    
                    cmd.Parameters.Add("@CodigoInfraccionDisciplinariaGenerica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInfraccionDisciplinariaGenerica"].Value = infraccionDisciplinariaGenericaDTO.CodigoInfraccionDisciplinariaGenerica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = infraccionDisciplinariaGenericaDTO.UsuarioIngresoRegistro;

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

        public string EliminarInfraccionDisciplinariaGenerica(InfraccionDisciplinariaGenericaDTO infraccionDisciplinariaGenericaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InfraccionDisciplinariaGenericaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InfraccionDisciplinariaGenericaId", SqlDbType.Int);
                    cmd.Parameters["@InfraccionDisciplinariaGenericaId"].Value = infraccionDisciplinariaGenericaDTO.InfraccionDisciplinariaGenericaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = infraccionDisciplinariaGenericaDTO.UsuarioIngresoRegistro;

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
