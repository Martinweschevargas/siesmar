using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ProgramaCapacitacionPSubalternoDAO
    {

        SqlCommand cmd = new();

        public List<ProgramaCapacitacionPSubalternoDTO> ObtenerProgramaCapacitacionPSubalternos()
        {
            List<ProgramaCapacitacionPSubalternoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ProgramaCapacitacionPSubalternoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ProgramaCapacitacionPSubalternoDTO()
                        {
                            ProgramaCapacitacionPSubalternoId = Convert.ToInt32(dr["ProgramaCapacitacionPSubalternoId"]),
                            DescProgramaCapacitacionPSubalterno = dr["DescProgramaCapacitacionPSubalterno"].ToString(),
                            CodigoProgramaCapacitacionPSubalterno = dr["CodigoProgramaCapacitacionPSubalterno"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarProgramaCapacitacionPSubalterno(ProgramaCapacitacionPSubalternoDTO programaCapacitacionPSubalternoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProgramaCapacitacionPSubalternoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescProgramaCapacitacionPSubalterno", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescProgramaCapacitacionPSubalterno"].Value = programaCapacitacionPSubalternoDTO.DescProgramaCapacitacionPSubalterno;

                    cmd.Parameters.Add("@CodigoProgramaCapacitacionPSubalterno", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoProgramaCapacitacionPSubalterno"].Value = programaCapacitacionPSubalternoDTO.CodigoProgramaCapacitacionPSubalterno;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programaCapacitacionPSubalternoDTO.UsuarioIngresoRegistro;

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

        public ProgramaCapacitacionPSubalternoDTO BuscarProgramaCapacitacionPSubalternoID(int Codigo)
        {
            ProgramaCapacitacionPSubalternoDTO programaCapacitacionPSubalternoDTO = new ProgramaCapacitacionPSubalternoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProgramaCapacitacionPSubalternoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProgramaCapacitacionPSubalternoId", SqlDbType.Int);
                    cmd.Parameters["@ProgramaCapacitacionPSubalternoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        programaCapacitacionPSubalternoDTO.ProgramaCapacitacionPSubalternoId = Convert.ToInt32(dr["ProgramaCapacitacionPSubalternoId"]);
                        programaCapacitacionPSubalternoDTO.DescProgramaCapacitacionPSubalterno = dr["DescProgramaCapacitacionPSubalterno"].ToString();
                        programaCapacitacionPSubalternoDTO.CodigoProgramaCapacitacionPSubalterno = dr["CodigoProgramaCapacitacionPSubalterno"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return programaCapacitacionPSubalternoDTO;
        }

        public string ActualizarProgramaCapacitacionPSubalterno(ProgramaCapacitacionPSubalternoDTO programaCapacitacionPSubalternoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ProgramaCapacitacionPSubalternoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProgramaCapacitacionPSubalternoId", SqlDbType.Int);
                    cmd.Parameters["@ProgramaCapacitacionPSubalternoId"].Value = programaCapacitacionPSubalternoDTO.ProgramaCapacitacionPSubalternoId;

                    cmd.Parameters.Add("@DescProgramaCapacitacionPSubalterno", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescProgramaCapacitacionPSubalterno"].Value = programaCapacitacionPSubalternoDTO.DescProgramaCapacitacionPSubalterno;

                    cmd.Parameters.Add("@CodigoProgramaCapacitacionPSubalterno", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoProgramaCapacitacionPSubalterno"].Value = programaCapacitacionPSubalternoDTO.CodigoProgramaCapacitacionPSubalterno;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programaCapacitacionPSubalternoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarProgramaCapacitacionPSubalterno(ProgramaCapacitacionPSubalternoDTO programaCapacitacionPSubalternoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProgramaCapacitacionPSubalternoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProgramaCapacitacionPSubalternoId", SqlDbType.Int);
                    cmd.Parameters["@ProgramaCapacitacionPSubalternoId"].Value = programaCapacitacionPSubalternoDTO.ProgramaCapacitacionPSubalternoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programaCapacitacionPSubalternoDTO.UsuarioIngresoRegistro;

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
