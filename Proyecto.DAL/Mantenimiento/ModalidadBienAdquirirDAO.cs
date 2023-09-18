using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ModalidadBienAdquirirDAO
    {

        SqlCommand cmd = new();

        public List<ModalidadBienAdquirirDTO> ObtenerModalidadBienAdquirirs()
        {
            List<ModalidadBienAdquirirDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ModalidadBienAdquirirListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ModalidadBienAdquirirDTO()
                        {
                            ModalidadBienAdquirirId = Convert.ToInt32(dr["ModalidadBienAdquirirId"]),
                            DescModalidadBienAdquirir = dr["DescModalidadBienAdquirir"].ToString(),
                            CodigoModalidadBienAdquirir = dr["CodigoModalidadBienAdquirir"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarModalidadBienAdquirir(ModalidadBienAdquirirDTO modalidadBienAdquirirDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModalidadBienAdquirirRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescModalidadBienAdquirir", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescModalidadBienAdquirir"].Value = modalidadBienAdquirirDTO.DescModalidadBienAdquirir;

                    cmd.Parameters.Add("@CodigoModalidadBienAdquirir", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoModalidadBienAdquirir"].Value = modalidadBienAdquirirDTO.CodigoModalidadBienAdquirir;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modalidadBienAdquirirDTO.UsuarioIngresoRegistro;

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

        public ModalidadBienAdquirirDTO BuscarModalidadBienAdquirirID(int Codigo)
        {
            ModalidadBienAdquirirDTO modalidadBienAdquirirDTO = new ModalidadBienAdquirirDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModalidadBienAdquirirEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModalidadBienAdquirirId", SqlDbType.Int);
                    cmd.Parameters["@ModalidadBienAdquirirId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        modalidadBienAdquirirDTO.ModalidadBienAdquirirId = Convert.ToInt32(dr["ModalidadBienAdquirirId"]);
                        modalidadBienAdquirirDTO.DescModalidadBienAdquirir = dr["DescModalidadBienAdquirir"].ToString();
                        modalidadBienAdquirirDTO.CodigoModalidadBienAdquirir = dr["CodigoModalidadBienAdquirir"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return modalidadBienAdquirirDTO;
        }

        public string ActualizarModalidadBienAdquirir(ModalidadBienAdquirirDTO modalidadBienAdquirirDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ModalidadBienAdquirirActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModalidadBienAdquirirId", SqlDbType.Int);
                    cmd.Parameters["@ModalidadBienAdquirirId"].Value = modalidadBienAdquirirDTO.ModalidadBienAdquirirId;

                    cmd.Parameters.Add("@DescModalidadBienAdquirir", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescModalidadBienAdquirir"].Value = modalidadBienAdquirirDTO.DescModalidadBienAdquirir;

                    cmd.Parameters.Add("@CodigoModalidadBienAdquirir", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoModalidadBienAdquirir"].Value = modalidadBienAdquirirDTO.CodigoModalidadBienAdquirir;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modalidadBienAdquirirDTO.UsuarioIngresoRegistro;

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

        public bool EliminarModalidadBienAdquirir(int Codigo)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModalidadBienAdquirirEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModalidadBienAdquirirId", SqlDbType.Int);
                    cmd.Parameters["@ModalidadBienAdquirirId"].Value = Codigo;
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
