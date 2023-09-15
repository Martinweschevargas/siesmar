using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class PerfilProfesionalDAO
    {

        SqlCommand cmd = new();

        public List<PerfilProfesionalDTO> ObtenerPerfilProfesionals()
        {
            List<PerfilProfesionalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_PerfilesProfesionalesListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PerfilProfesionalDTO()
                        {
                            PerfilProfesionalId = Convert.ToInt32(dr["PerfilProfesionalId"]),
                            DescPerfilProfesional = dr["DescPerfilProfesional"].ToString(),
                            CodigoPerfilProfesional = dr["CodigoPerfilProfesional"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarPerfilProfesional(PerfilProfesionalDTO perfilProfesionalDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PerfilesProfesionalesRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescPerfilProfesional", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescPerfilProfesional"].Value = perfilProfesionalDTO.DescPerfilProfesional;

                    cmd.Parameters.Add("@CodigoPerfilProfesional", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoPerfilProfesional"].Value = perfilProfesionalDTO.CodigoPerfilProfesional;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = perfilProfesionalDTO.UsuarioIngresoRegistro;

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

        public PerfilProfesionalDTO BuscarPerfilProfesionalID(int Codigo)
        {
            PerfilProfesionalDTO perfilProfesionalDTO = new PerfilProfesionalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PerfilesProfesionalesEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PerfilProfesionalId", SqlDbType.Int);
                    cmd.Parameters["@PerfilProfesionalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        perfilProfesionalDTO.PerfilProfesionalId = Convert.ToInt32(dr["PerfilProfesionalId"]);
                        perfilProfesionalDTO.DescPerfilProfesional = dr["DescPerfilProfesional"].ToString();
                        perfilProfesionalDTO.CodigoPerfilProfesional = dr["CodigoPerfilProfesional"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return perfilProfesionalDTO;
        }

        public string ActualizarPerfilProfesional(PerfilProfesionalDTO perfilProfesionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_PerfilesProfesionalesActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PerfilProfesionalId", SqlDbType.Int);
                    cmd.Parameters["@PerfilProfesionalId"].Value = perfilProfesionalDTO.PerfilProfesionalId;

                    cmd.Parameters.Add("@DescPerfilProfesional", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescPerfilProfesional"].Value = perfilProfesionalDTO.DescPerfilProfesional;

                    cmd.Parameters.Add("@CodigoPerfilProfesional", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoPerfilProfesional"].Value = perfilProfesionalDTO.CodigoPerfilProfesional;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = perfilProfesionalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarPerfilProfesional(int Codigo)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PerfilesProfesionalesEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PerfilProfesionalId", SqlDbType.Int);
                    cmd.Parameters["@PerfilProfesionalId"].Value = Codigo;
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
