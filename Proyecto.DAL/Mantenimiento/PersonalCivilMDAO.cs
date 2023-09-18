using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class PersonalCivilMDAO
    {

        SqlCommand cmd = new();

        public List<PersonalCivilMDTO> ObtenerPersonalCivils()
        {
            List<PersonalCivilMDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_PersonalCivilListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PersonalCivilMDTO()
                        {
                            PersonalCivilId = Convert.ToInt32(dr["PersonalCivilId"]),
                            DescPersonalCivil = dr["DescPersonalCivil"].ToString(),
                            CodigoPersonalCivil = dr["CodigoPersonalCivil"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarPersonalCivil(PersonalCivilMDTO PersonalCivilMDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PersonalCivilRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescPersonalCivil", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescPersonalCivil"].Value = PersonalCivilMDTO.DescPersonalCivil;

                    cmd.Parameters.Add("@CodigoPersonalCivil", SqlDbType.VarChar, 10);                    
                    cmd.Parameters["@CodigoPersonalCivil"].Value = PersonalCivilMDTO.CodigoPersonalCivil;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = PersonalCivilMDTO.UsuarioIngresoRegistro;

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

        public PersonalCivilMDTO BuscarPersonalCivilID(int Codigo)
        {
            PersonalCivilMDTO PersonalCivilMDTO = new PersonalCivilMDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PersonalCivilEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalCivilId", SqlDbType.Int);
                    cmd.Parameters["@PersonalCivilId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        PersonalCivilMDTO.PersonalCivilId = Convert.ToInt32(dr["PersonalCivilId"]);
                        PersonalCivilMDTO.DescPersonalCivil = dr["DescPersonalCivil"].ToString();
                        PersonalCivilMDTO.CodigoPersonalCivil = dr["CodigoPersonalCivil"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return PersonalCivilMDTO;
        }

        public string ActualizarPersonalCivil(PersonalCivilMDTO PersonalCivilMDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PersonalCivilActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalCivilId", SqlDbType.Int);
                    cmd.Parameters["@PersonalCivilId"].Value = PersonalCivilMDTO.PersonalCivilId;

                    cmd.Parameters.Add("@DescPersonalCivil", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescPersonalCivil"].Value = PersonalCivilMDTO.DescPersonalCivil;

                    cmd.Parameters.Add("@CodigoPersonalCivil", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoPersonalCivil"].Value = PersonalCivilMDTO.CodigoPersonalCivil;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = PersonalCivilMDTO.UsuarioIngresoRegistro;

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

        public string EliminarPersonalCivil(PersonalCivilMDTO PersonalCivilMDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PersonalCivilEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalCivilId", SqlDbType.Int);
                    cmd.Parameters["@PersonalCivilId"].Value = PersonalCivilMDTO.PersonalCivilId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = PersonalCivilMDTO.UsuarioIngresoRegistro;

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
