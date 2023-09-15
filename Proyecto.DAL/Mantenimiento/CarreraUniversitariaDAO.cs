using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CarreraUniversitariaDAO
    {

        SqlCommand cmd = new();

        public List<CarreraUniversitariaDTO> ObtenerCarreraUniversitarias()
        {
            List<CarreraUniversitariaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CarreraUniversitariaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CarreraUniversitariaDTO()
                        {
                            CarreraUniversitariaId = Convert.ToInt32(dr["CarreraUniversitariaId"]),
                            DescCarreraUniversitaria = dr["DescCarreraUniversitaria"].ToString(),
                            CodigoCarreraUniversitaria = dr["CodigoCarreraUniversitaria"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCarreraUniversitaria(CarreraUniversitariaDTO carreraUniversitariaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CarreraUniversitariaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCarreraUniversitaria", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescCarreraUniversitaria"].Value = carreraUniversitariaDTO.DescCarreraUniversitaria;

                    cmd.Parameters.Add("@CodigoCarreraUniversitaria", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCarreraUniversitaria"].Value = carreraUniversitariaDTO.CodigoCarreraUniversitaria;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = carreraUniversitariaDTO.UsuarioIngresoRegistro;

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

        public CarreraUniversitariaDTO BuscarCarreraUniversitariaID(int Codigo)
        {
            CarreraUniversitariaDTO carreraUniversitariaDTO = new CarreraUniversitariaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CarreraUniversitariaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CarreraUniversitariaId", SqlDbType.Int);
                    cmd.Parameters["@CarreraUniversitariaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        carreraUniversitariaDTO.CarreraUniversitariaId = Convert.ToInt32(dr["CarreraUniversitariaId"]);
                        carreraUniversitariaDTO.DescCarreraUniversitaria = dr["DescCarreraUniversitaria"].ToString();
                        carreraUniversitariaDTO.CodigoCarreraUniversitaria = dr["CodigoCarreraUniversitaria"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return carreraUniversitariaDTO;
        }

        public string ActualizarCarreraUniversitaria(CarreraUniversitariaDTO carreraUniversitariaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_CarreraUniversitariaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CarreraUniversitariaId", SqlDbType.Int);
                    cmd.Parameters["@CarreraUniversitariaId"].Value = carreraUniversitariaDTO.CarreraUniversitariaId;

                    cmd.Parameters.Add("@DescCarreraUniversitaria", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescCarreraUniversitaria"].Value = carreraUniversitariaDTO.DescCarreraUniversitaria;

                    cmd.Parameters.Add("@CodigoCarreraUniversitaria", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoCarreraUniversitaria"].Value = carreraUniversitariaDTO.CodigoCarreraUniversitaria;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = carreraUniversitariaDTO.UsuarioIngresoRegistro;

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


        public string EliminarCarreraUniversitaria(CarreraUniversitariaDTO carreraUniversitariaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CarreraUniversitariaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CarreraUniversitariaId", SqlDbType.Int);
                    cmd.Parameters["@CarreraUniversitariaId"].Value = carreraUniversitariaDTO.CarreraUniversitariaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = carreraUniversitariaDTO.UsuarioIngresoRegistro;

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
