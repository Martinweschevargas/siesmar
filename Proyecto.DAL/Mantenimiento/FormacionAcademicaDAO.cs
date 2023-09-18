using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class FormacionAcademicaDAO
    {

        SqlCommand cmd = new();

        public List<FormacionAcademicaDTO> ObtenerFormacionAcademicas()
        {
            List<FormacionAcademicaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_FormacionAcademicaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new FormacionAcademicaDTO()
                        {
                            FormacionAcademicaId = Convert.ToInt32(dr["FormacionAcademicaId"]),
                            DescFormacionAcademica = dr["DescFormacionAcademica"].ToString(),
                            CodigoFormacionAcademica = dr["CodigoFormacionAcademica"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarFormacionAcademica(FormacionAcademicaDTO formacionAcademicaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FormacionAcademicaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescFormacionAcademica", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescFormacionAcademica"].Value = formacionAcademicaDTO.DescFormacionAcademica;

                    cmd.Parameters.Add("@CodigoFormacionAcademica", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoFormacionAcademica"].Value = formacionAcademicaDTO.CodigoFormacionAcademica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = formacionAcademicaDTO.UsuarioIngresoRegistro;

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

        public FormacionAcademicaDTO BuscarFormacionAcademicaID(int Codigo)
        {
            FormacionAcademicaDTO formacionAcademicaDTO = new FormacionAcademicaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FormacionAcademicaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FormacionAcademicaId", SqlDbType.Int);
                    cmd.Parameters["@FormacionAcademicaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        formacionAcademicaDTO.FormacionAcademicaId = Convert.ToInt32(dr["FormacionAcademicaId"]);
                        formacionAcademicaDTO.DescFormacionAcademica = dr["DescFormacionAcademica"].ToString();
                        formacionAcademicaDTO.CodigoFormacionAcademica = dr["CodigoFormacionAcademica"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return formacionAcademicaDTO;
        }

        public string ActualizarFormacionAcademica(FormacionAcademicaDTO formacionAcademicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_FormacionAcademicaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FormacionAcademicaId", SqlDbType.Int);
                    cmd.Parameters["@FormacionAcademicaId"].Value = formacionAcademicaDTO.FormacionAcademicaId;

                    cmd.Parameters.Add("@DescFormacionAcademica", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescFormacionAcademica"].Value = formacionAcademicaDTO.DescFormacionAcademica;

                    cmd.Parameters.Add("@CodigoFormacionAcademica", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoFormacionAcademica"].Value = formacionAcademicaDTO.CodigoFormacionAcademica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = formacionAcademicaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormacionAcademica(FormacionAcademicaDTO formacionAcademicaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FormacionAcademicaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FormacionAcademicaId", SqlDbType.Int);
                    cmd.Parameters["@FormacionAcademicaId"].Value = formacionAcademicaDTO.FormacionAcademicaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = formacionAcademicaDTO.UsuarioIngresoRegistro;

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
