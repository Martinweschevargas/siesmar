using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ContactoDAO
    {

        SqlCommand cmd = new();

        public List<ContactoDTO> ObtenerContactos()
        {
            List<ContactoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ContactoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ContactoDTO()
                        {
                            ContactoId = Convert.ToInt32(dr["ContactoId"]),
                            DescContacto = dr["DescContacto"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarContacto(ContactoDTO contactoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ContactoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescContacto", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescContacto"].Value = contactoDTO.DescContacto;

                    cmd.Parameters.Add("@Apellido", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Apellido"].Value = contactoDTO.Apellido;

                    cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Telefono"].Value = contactoDTO.Telefono;

                    cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Correo"].Value = contactoDTO.Correo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = contactoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
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
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public ContactoDTO BuscarContactoID(int Codigo)
        {
            ContactoDTO contactoDTO = new ContactoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ContactoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ContactoId", SqlDbType.Int);
                    cmd.Parameters["@ContactoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        contactoDTO.ContactoId = Convert.ToInt32(dr["ContactoId"]);
                        contactoDTO.DescContacto = dr["DescContacto"].ToString();
                        contactoDTO.Apellido = dr["Apellido"].ToString();
                        contactoDTO.Telefono = dr["Telefono"].ToString();
                        contactoDTO.Correo = dr["Correo"].ToString();

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return contactoDTO;
        }

        public string ActualizarContacto(ContactoDTO contactoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ContactoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ContactoId", SqlDbType.Int);
                    cmd.Parameters["@ContactoId"].Value = contactoDTO.ContactoId;

                    cmd.Parameters.Add("@DescContacto", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescContacto"].Value = contactoDTO.DescContacto;

                    cmd.Parameters.Add("@Apellido", SqlDbType.VarChar, 10);
                    cmd.Parameters["@Apellido"].Value = contactoDTO.Apellido;

                    cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 10);
                    cmd.Parameters["@Telefono"].Value = contactoDTO.Telefono;

                    cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@Correo"].Value = contactoDTO.Correo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = contactoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

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

        public bool EliminarContacto(ContactoDTO contactoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ContactoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ContactoId", SqlDbType.Int);
                    cmd.Parameters["@ContactoId"].Value = contactoDTO.ContactoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = contactoDTO.UsuarioIngresoRegistro;

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
