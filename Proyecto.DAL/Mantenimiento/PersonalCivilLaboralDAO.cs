using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class PersonalCivilLaboralDAO
    {

        SqlCommand cmd = new();

        public List<PersonalCivilLaboralDTO> ObtenerPersonalCivilLaborals()
        {
            List<PersonalCivilLaboralDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_PersonalCivilLaboralListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PersonalCivilLaboralDTO()
                        {
                            PersonalCivilLaboralId = Convert.ToInt32(dr["PersonalCivilLaboralId"]),
                            DescPersonalCivilLaboral = dr["DescPersonalCivilLaboral"].ToString(),
                            CodigoPersonalCivilLaboral = dr["CodigoPersonalCivilLaboral"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarPersonalCivilLaboral(PersonalCivilLaboralDTO personalCivilLaboralDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PersonalCivilLaboralRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescPersonalCivilLaboral", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescPersonalCivilLaboral"].Value = personalCivilLaboralDTO.DescPersonalCivilLaboral;

                    cmd.Parameters.Add("@CodigoPersonalCivilLaboral", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoPersonalCivilLaboral"].Value = personalCivilLaboralDTO.CodigoPersonalCivilLaboral;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personalCivilLaboralDTO.UsuarioIngresoRegistro;

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
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public PersonalCivilLaboralDTO BuscarPersonalCivilLaboralID(int Codigo)
        {
            PersonalCivilLaboralDTO personalCivilLaboralDTO = new PersonalCivilLaboralDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PersonalCivilLaboralEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalCivilLaboralId", SqlDbType.Int);
                    cmd.Parameters["@PersonalCivilLaboralId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        personalCivilLaboralDTO.PersonalCivilLaboralId = Convert.ToInt32(dr["PersonalCivilLaboralId"]);
                        personalCivilLaboralDTO.DescPersonalCivilLaboral = dr["DescPersonalCivilLaboral"].ToString();
                        personalCivilLaboralDTO.CodigoPersonalCivilLaboral = dr["CodigoPersonalCivilLaboral"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return personalCivilLaboralDTO;
        }

        public string ActualizarPersonalCivilLaboral(PersonalCivilLaboralDTO personalCivilLaboralDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_PersonalCivilLaboralActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalCivilLaboralId", SqlDbType.Int);
                    cmd.Parameters["@PersonalCivilLaboralId"].Value = personalCivilLaboralDTO.PersonalCivilLaboralId;

                    cmd.Parameters.Add("@DescPersonalCivilLaboral", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescPersonalCivilLaboral"].Value = personalCivilLaboralDTO.DescPersonalCivilLaboral;

                    cmd.Parameters.Add("@CodigoPersonalCivilLaboral", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoPersonalCivilLaboral"].Value = personalCivilLaboralDTO.CodigoPersonalCivilLaboral;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personalCivilLaboralDTO.UsuarioIngresoRegistro;

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

        public bool EliminarPersonalCivilLaboral(int Codigo)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PersonalCivilLaboralEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalCivilLaboralId", SqlDbType.Int);
                    cmd.Parameters["@PersonalCivilLaboralId"].Value = Codigo;
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
