using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class InfraccionDisciplinariaCivilDAO
    {

        SqlCommand cmd = new();

        public List<InfraccionDisciplinariaCivilDTO> ObtenerInfraccionDisciplinariaCivils()
        {
            List<InfraccionDisciplinariaCivilDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_InfraccionDisciplinariaCivilListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new InfraccionDisciplinariaCivilDTO()
                        {
                            InfraccionDisciplinariaCivilId = Convert.ToInt32(dr["InfraccionDisciplinariaCivilId"]),
                            DescInfraccionDisciplinariaCivil = dr["DescInfraccionDisciplinariaCivil"].ToString(),
                            CodigoInfraccionDisciplinariaCivil = dr["CodigoInfraccionDisciplinariaCivil"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarInfraccionDisciplinariaCivil(InfraccionDisciplinariaCivilDTO infraccionDisciplinariaCivilDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InfraccionDisciplinariaCivilRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescInfraccionDisciplinariaCivil", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescInfraccionDisciplinariaCivil"].Value = infraccionDisciplinariaCivilDTO.DescInfraccionDisciplinariaCivil;

                    cmd.Parameters.Add("@CodigoInfraccionDisciplinariaCivil", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoInfraccionDisciplinariaCivil"].Value = infraccionDisciplinariaCivilDTO.CodigoInfraccionDisciplinariaCivil;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = infraccionDisciplinariaCivilDTO.UsuarioIngresoRegistro;

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

        public InfraccionDisciplinariaCivilDTO BuscarInfraccionDisciplinariaCivilID(int Codigo)
        {
            InfraccionDisciplinariaCivilDTO infraccionDisciplinariaCivilDTO = new InfraccionDisciplinariaCivilDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InfraccionDisciplinariaCivilEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InfraccionDisciplinariaCivilId", SqlDbType.Int);
                    cmd.Parameters["@InfraccionDisciplinariaCivilId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        infraccionDisciplinariaCivilDTO.InfraccionDisciplinariaCivilId = Convert.ToInt32(dr["InfraccionDisciplinariaCivilId"]);
                        infraccionDisciplinariaCivilDTO.DescInfraccionDisciplinariaCivil = dr["DescInfraccionDisciplinariaCivil"].ToString();
                        infraccionDisciplinariaCivilDTO.CodigoInfraccionDisciplinariaCivil = dr["CodigoInfraccionDisciplinariaCivil"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return infraccionDisciplinariaCivilDTO;
        }

        public string ActualizarInfraccionDisciplinariaCivil(InfraccionDisciplinariaCivilDTO infraccionDisciplinariaCivilDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_InfraccionDisciplinariaCivilActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InfraccionDisciplinariaCivilId", SqlDbType.Int);
                    cmd.Parameters["@InfraccionDisciplinariaCivilId"].Value = infraccionDisciplinariaCivilDTO.InfraccionDisciplinariaCivilId;

                    cmd.Parameters.Add("@DescInfraccionDisciplinariaCivil", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescInfraccionDisciplinariaCivil"].Value = infraccionDisciplinariaCivilDTO.DescInfraccionDisciplinariaCivil;

                    cmd.Parameters.Add("@CodigoInfraccionDisciplinariaCivil", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoInfraccionDisciplinariaCivil"].Value = infraccionDisciplinariaCivilDTO.CodigoInfraccionDisciplinariaCivil;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = infraccionDisciplinariaCivilDTO.UsuarioIngresoRegistro;

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

        public bool EliminarInfraccionDisciplinariaCivil(InfraccionDisciplinariaCivilDTO infraccionDisciplinariaCivilDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InfraccionDisciplinariaCivilEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InfraccionDisciplinariaCivilId", SqlDbType.Int);
                    cmd.Parameters["@InfraccionDisciplinariaCivilId"].Value = infraccionDisciplinariaCivilDTO.InfraccionDisciplinariaCivilId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = infraccionDisciplinariaCivilDTO.UsuarioIngresoRegistro;

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
