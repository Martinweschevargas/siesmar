using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class PersonalBeneficiadoDAO
    {

        SqlCommand cmd = new();

        public List<PersonalBeneficiadoDTO> ObtenerPersonalBeneficiados()
        {
            List<PersonalBeneficiadoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_PersonalBeneficiadoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PersonalBeneficiadoDTO()
                        {
                            PersonalBeneficiadoId = Convert.ToInt32(dr["PersonalBeneficiadoId"]),
                            DescPersonalBeneficiado = dr["DescPersonalBeneficiado"].ToString(),
                            CodigoPersonalBeneficiado = dr["CodigoPersonalBeneficiado"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarPersonalBeneficiado(PersonalBeneficiadoDTO PersonalBeneficiadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PersonalBeneficiadoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescPersonalBeneficiado", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescPersonalBeneficiado"].Value = PersonalBeneficiadoDTO.DescPersonalBeneficiado;

                    cmd.Parameters.Add("@CodigoPersonalBeneficiado", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoPersonalBeneficiado"].Value = PersonalBeneficiadoDTO.CodigoPersonalBeneficiado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = PersonalBeneficiadoDTO.UsuarioIngresoRegistro;

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

        public PersonalBeneficiadoDTO BuscarPersonalBeneficiadoID(int Codigo)
        {
            PersonalBeneficiadoDTO PersonalBeneficiadoDTO = new PersonalBeneficiadoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PersonalBeneficiadoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalBeneficiadoId", SqlDbType.Int);
                    cmd.Parameters["@PersonalBeneficiadoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        PersonalBeneficiadoDTO.PersonalBeneficiadoId = Convert.ToInt32(dr["PersonalBeneficiadoId"]);
                        PersonalBeneficiadoDTO.DescPersonalBeneficiado = dr["DescPersonalBeneficiado"].ToString();
                        PersonalBeneficiadoDTO.CodigoPersonalBeneficiado = dr["CodigoPersonalBeneficiado"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return PersonalBeneficiadoDTO;
        }

        public string ActualizarPersonalBeneficiado(PersonalBeneficiadoDTO PersonalBeneficiadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PersonalBeneficiadoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalBeneficiadoId", SqlDbType.Int);
                    cmd.Parameters["@PersonalBeneficiadoId"].Value = PersonalBeneficiadoDTO.PersonalBeneficiadoId;

                    cmd.Parameters.Add("@DescPersonalBeneficiado", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescPersonalBeneficiado"].Value = PersonalBeneficiadoDTO.DescPersonalBeneficiado;

                    cmd.Parameters.Add("@CodigoPersonalBeneficiado", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoPersonalBeneficiado"].Value = PersonalBeneficiadoDTO.CodigoPersonalBeneficiado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = PersonalBeneficiadoDTO.UsuarioIngresoRegistro;

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

        public string EliminarPersonalBeneficiado(PersonalBeneficiadoDTO PersonalBeneficiadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PersonalBeneficiadoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PersonalBeneficiadoId", SqlDbType.Int);
                    cmd.Parameters["@PersonalBeneficiadoId"].Value = PersonalBeneficiadoDTO.PersonalBeneficiadoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = PersonalBeneficiadoDTO.UsuarioIngresoRegistro;

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
