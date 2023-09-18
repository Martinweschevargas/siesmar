using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class PersonalSolicitanteDAO
    {

        SqlCommand cmd = new();

        public List<PersonalSolicitanteDTO> ObtenerPersonalSolicitantes()
        {
            List<PersonalSolicitanteDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_PersonalSolicitanteListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PersonalSolicitanteDTO()
                        {
                            PersonalSolicitanteId = Convert.ToInt32(dr["PersonalSolicitanteId"]),
                            DescPersonalSolicitante = dr["DescPersonalSolicitante"].ToString(),
                            CodigoPersonalSolicitante = dr["CodigoPersonalSolicitante"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarPersonalSolicitante(PersonalSolicitanteDTO PersonalSolicitanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PersonalSolicitanteRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescPersonalSolicitante", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescPersonalSolicitante"].Value = PersonalSolicitanteDTO.DescPersonalSolicitante;

                    cmd.Parameters.Add("@CodigoPersonalSolicitante", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoPersonalSolicitante"].Value = PersonalSolicitanteDTO.CodigoPersonalSolicitante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = PersonalSolicitanteDTO.UsuarioIngresoRegistro;

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

        public PersonalSolicitanteDTO BuscarPersonalSolicitanteID(int Codigo)
        {
            PersonalSolicitanteDTO PersonalSolicitanteDTO = new PersonalSolicitanteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PersonalSolicitanteEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalSolicitanteId", SqlDbType.Int);
                    cmd.Parameters["@PersonalSolicitanteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        PersonalSolicitanteDTO.PersonalSolicitanteId = Convert.ToInt32(dr["PersonalSolicitanteId"]);
                        PersonalSolicitanteDTO.DescPersonalSolicitante = dr["DescPersonalSolicitante"].ToString();
                        PersonalSolicitanteDTO.CodigoPersonalSolicitante = dr["CodigoPersonalSolicitante"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return PersonalSolicitanteDTO;
        }

        public string ActualizarPersonalSolicitante(PersonalSolicitanteDTO PersonalSolicitanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PersonalSolicitanteActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalSolicitanteId", SqlDbType.Int);
                    cmd.Parameters["@PersonalSolicitanteId"].Value = PersonalSolicitanteDTO.PersonalSolicitanteId;

                    cmd.Parameters.Add("@DescPersonalSolicitante", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescPersonalSolicitante"].Value = PersonalSolicitanteDTO.DescPersonalSolicitante;

                    cmd.Parameters.Add("@CodigoPersonalSolicitante", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoPersonalSolicitante"].Value = PersonalSolicitanteDTO.CodigoPersonalSolicitante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = PersonalSolicitanteDTO.UsuarioIngresoRegistro;

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

        public string EliminarPersonalSolicitante(PersonalSolicitanteDTO PersonalSolicitanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PersonalSolicitanteEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalSolicitanteId", SqlDbType.Int);
                    cmd.Parameters["@PersonalSolicitanteId"].Value = PersonalSolicitanteDTO.PersonalSolicitanteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = PersonalSolicitanteDTO.UsuarioIngresoRegistro;

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
