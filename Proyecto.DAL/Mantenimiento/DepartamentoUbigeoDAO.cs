using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class DepartamentoUbigeoDAO
    {

        SqlCommand cmd = new();

        public List<DepartamentoUbigeoDTO> ObtenerDepartamentoUbigeos()
        {
            List<DepartamentoUbigeoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_DepartamentoUbigeoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DepartamentoUbigeoDTO()
                        {
                            DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            Ubigeo = dr["Ubigeo"].ToString(),
                            NombrePais = dr["NombrePais"].ToString(),
                            PaisUbigeoId = Convert.ToInt32(dr["PaisUbigeoId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarDepartamentoUbigeo(DepartamentoUbigeoDTO departamentoUbigeoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DepartamentoUbigeoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescDepartamento", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescDepartamento"].Value = departamentoUbigeoDTO.DescDepartamento;

                    cmd.Parameters.Add("@Ubigeo", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Ubigeo"].Value = departamentoUbigeoDTO.Ubigeo; 
                    
                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = departamentoUbigeoDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = departamentoUbigeoDTO.UsuarioIngresoRegistro;

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

        public DepartamentoUbigeoDTO BuscarDepartamentoUbigeoID(int Codigo)
        {
            DepartamentoUbigeoDTO departamentoUbigeoDTO = new DepartamentoUbigeoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DepartamentoUbigeoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        departamentoUbigeoDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]);
                        departamentoUbigeoDTO.DescDepartamento = dr["DescDepartamento"].ToString();
                        departamentoUbigeoDTO.Ubigeo = dr["Ubigeo"].ToString();
                        departamentoUbigeoDTO.PaisUbigeoId = Convert.ToInt32(dr["PaisUbigeoId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return departamentoUbigeoDTO;
        }

        public string ActualizarDepartamentoUbigeo(DepartamentoUbigeoDTO departamentoUbigeoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_DepartamentoUbigeoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = departamentoUbigeoDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@DescDepartamento", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescDepartamento"].Value = departamentoUbigeoDTO.DescDepartamento;

                    cmd.Parameters.Add("@Ubigeo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@Ubigeo"].Value = departamentoUbigeoDTO.Ubigeo;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = departamentoUbigeoDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = departamentoUbigeoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarDepartamentoUbigeo(DepartamentoUbigeoDTO departamentoUbigeoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DepartamentoUbigeoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = departamentoUbigeoDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = departamentoUbigeoDTO.UsuarioIngresoRegistro;

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
