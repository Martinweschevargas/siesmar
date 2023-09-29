using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CarreraUniversitariaEspecialidadDAO
    {

        SqlCommand cmd = new();

        public List<CarreraUniversitariaEspecialidadDTO> ObtenerCarreraUniversitariaEspecialidads()
        {
            List<CarreraUniversitariaEspecialidadDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CarreraUniversitariaEspecialidadListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CarreraUniversitariaEspecialidadDTO()
                        {
                            CarreraUniversitariaEspecialidadId = Convert.ToInt32(dr["CarreraUniversitariaEspecialidadId"]),
                            DescCarreraUniversitariaEspecialidad = dr["DescCarreraUniversitariaEspecialidad"].ToString(),
                            CodigoCarreraUniversitariaEspecialidad = dr["CodigoCarreraUniversitariaEspecialidad"].ToString(),
                            DescCarreraUniversitaria = dr["DescCarreraUniversitaria"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCarreraUniversitariaEspecialidad(CarreraUniversitariaEspecialidadDTO carreraUniversitariaEspecialidadDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CarreraUniversitariaEspecialidadRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCarreraUniversitariaEspecialidad", SqlDbType.VarChar, 50);                    
                    cmd.Parameters["@DescCarreraUniversitariaEspecialidad"].Value = carreraUniversitariaEspecialidadDTO.DescCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@CodigoCarreraUniversitariaEspecialidad", SqlDbType.NVarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitariaEspecialidad"].Value = carreraUniversitariaEspecialidadDTO.CodigoCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@CodigoCarreraUniversitaria", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitaria"].Value = carreraUniversitariaEspecialidadDTO.CodigoCarreraUniversitaria;
                    
                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = carreraUniversitariaEspecialidadDTO.UsuarioIngresoRegistro;

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

        public CarreraUniversitariaEspecialidadDTO BuscarCarreraUniversitariaEspecialidadID(int Codigo)
        {
            CarreraUniversitariaEspecialidadDTO carreraUniversitariaEspecialidadDTO = new CarreraUniversitariaEspecialidadDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CarreraUniversitariaEspecialidadEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CarreraUniversitariaEspecialidadId", SqlDbType.Int);
                    cmd.Parameters["@CarreraUniversitariaEspecialidadId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        carreraUniversitariaEspecialidadDTO.CarreraUniversitariaEspecialidadId = Convert.ToInt32(dr["CarreraUniversitariaEspecialidadId"]);
                        carreraUniversitariaEspecialidadDTO.DescCarreraUniversitariaEspecialidad = dr["DescCarreraUniversitariaEspecialidad"].ToString();
                        carreraUniversitariaEspecialidadDTO.CodigoCarreraUniversitariaEspecialidad = dr["CodigoCarreraUniversitariaEspecialidad"].ToString();
                        carreraUniversitariaEspecialidadDTO.CodigoCarreraUniversitaria = dr["CodigoCarreraUniversitaria"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return carreraUniversitariaEspecialidadDTO;
        }

        public string ActualizarCarreraUniversitariaEspecialidad(CarreraUniversitariaEspecialidadDTO carreraUniversitariaEspecialidadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CarreraUniversitariaEspecialidadActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CarreraUniversitariaEspecialidadId", SqlDbType.Int);
                    cmd.Parameters["@CarreraUniversitariaEspecialidadId"].Value = carreraUniversitariaEspecialidadDTO.CarreraUniversitariaEspecialidadId;

                    cmd.Parameters.Add("@DescCarreraUniversitariaEspecialidad", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@DescCarreraUniversitariaEspecialidad"].Value = carreraUniversitariaEspecialidadDTO.DescCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@CodigoCarreraUniversitariaEspecialidad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitariaEspecialidad"].Value = carreraUniversitariaEspecialidadDTO.CodigoCarreraUniversitariaEspecialidad;

                    cmd.Parameters.Add("@CodigoCarreraUniversitaria", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCarreraUniversitaria"].Value = carreraUniversitariaEspecialidadDTO.CodigoCarreraUniversitaria;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = carreraUniversitariaEspecialidadDTO.UsuarioIngresoRegistro;

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

        public string EliminarCarreraUniversitariaEspecialidad(CarreraUniversitariaEspecialidadDTO carreraUniversitariaEspecialidadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CarreraUniversitariaEspecialidadEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CarreraUniversitariaEspecialidadId", SqlDbType.Int);
                    cmd.Parameters["@CarreraUniversitariaEspecialidadId"].Value = carreraUniversitariaEspecialidadDTO.CarreraUniversitariaEspecialidadId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = carreraUniversitariaEspecialidadDTO.UsuarioIngresoRegistro;

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
