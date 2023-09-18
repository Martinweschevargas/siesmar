using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class PersonaActividadDifucionDAO
    {

        SqlCommand cmd = new();

        public List<PersonaActividadDifucionDTO> ObtenerPersonaActividadDifucions()
        {
            List<PersonaActividadDifucionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_PersonaActividadDifucionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PersonaActividadDifucionDTO()
                        {
                            PersonaActividadDifucionId = Convert.ToInt32(dr["PersonaActividadDifucionId"]),
                            DescPersonaActividadDifucion = dr["DescPersonaActividadDifucion"].ToString(),
                            CodigoPersonaActividadDifucion = dr["CodigoPersonaActividadDifucion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarPersonaActividadDifucion(PersonaActividadDifucionDTO personaActividadDifucionDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PersonaActividadDifucionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescPersonaActividadDifucion", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescPersonaActividadDifucion"].Value = personaActividadDifucionDTO.DescPersonaActividadDifucion;

                    cmd.Parameters.Add("@CodigoPersonaActividadDifucion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoPersonaActividadDifucion"].Value = personaActividadDifucionDTO.CodigoPersonaActividadDifucion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personaActividadDifucionDTO.UsuarioIngresoRegistro;

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

        public PersonaActividadDifucionDTO BuscarPersonaActividadDifucionID(int Codigo)
        {
            PersonaActividadDifucionDTO personaActividadDifucionDTO = new PersonaActividadDifucionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PersonaActividadDifucionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonaActividadDifucionId", SqlDbType.Int);
                    cmd.Parameters["@PersonaActividadDifucionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        personaActividadDifucionDTO.PersonaActividadDifucionId = Convert.ToInt32(dr["PersonaActividadDifucionId"]);
                        personaActividadDifucionDTO.DescPersonaActividadDifucion = dr["DescPersonaActividadDifucion"].ToString();
                        personaActividadDifucionDTO.CodigoPersonaActividadDifucion = dr["CodigoPersonaActividadDifucion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return personaActividadDifucionDTO;
        }

        public string ActualizarPersonaActividadDifucion(PersonaActividadDifucionDTO personaActividadDifucionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_PersonaActividadDifucionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonaActividadDifucionId", SqlDbType.Int);
                    cmd.Parameters["@PersonaActividadDifucionId"].Value = personaActividadDifucionDTO.PersonaActividadDifucionId;

                    cmd.Parameters.Add("@DescPersonaActividadDifucion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescPersonaActividadDifucion"].Value = personaActividadDifucionDTO.DescPersonaActividadDifucion;

                    cmd.Parameters.Add("@CodigoPersonaActividadDifucion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoPersonaActividadDifucion"].Value = personaActividadDifucionDTO.CodigoPersonaActividadDifucion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = personaActividadDifucionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarPersonaActividadDifucion(int Codigo)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PersonaActividadDifucionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonaActividadDifucionId", SqlDbType.Int);
                    cmd.Parameters["@PersonaActividadDifucionId"].Value = Codigo;
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
