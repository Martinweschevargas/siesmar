using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CursoCapacitacionPSubalternoDAO
    {

        SqlCommand cmd = new();

        public List<CursoCapacitacionPSubalternoDTO> ObtenerCursoCapacitacionPSubalternos()
        {
            List<CursoCapacitacionPSubalternoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CursoCapacitacionPSubalternoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CursoCapacitacionPSubalternoDTO()
                        {
                            CursoCapacitacionPSubalternoId = Convert.ToInt32(dr["CursoCapacitacionPSubalternoId"]),
                            DescCursoCapacitacion = dr["DescCursoCapacitacion"].ToString(),
                            CodigoCursoCapacitacion = dr["CodigoCursoCapacitacion"].ToString(),
                            DuracionCursoCapacitacion = dr["DuracionCursoCapacitacion"].ToString(),
                            InicioTerminoCursoCapacitacion = dr["InicioTerminoCursoCapacitacion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCursoCapacitacionPSubalterno(CursoCapacitacionPSubalternoDTO cursoCapacitacionPSubalternoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CursoCapacitacionPSubalternoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCursoCapacitacion", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescCursoCapacitacion"].Value = cursoCapacitacionPSubalternoDTO.DescCursoCapacitacion;

                    cmd.Parameters.Add("@CodigoCursoCapacitacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoCursoCapacitacion"].Value = cursoCapacitacionPSubalternoDTO.CodigoCursoCapacitacion;

                    cmd.Parameters.Add("@DuracionCursoCapacitacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DuracionCursoCapacitacion"].Value = cursoCapacitacionPSubalternoDTO.DuracionCursoCapacitacion;

                    cmd.Parameters.Add("@InicioTerminoCursoCapacitacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@InicioTerminoCursoCapacitacion"].Value = cursoCapacitacionPSubalternoDTO.InicioTerminoCursoCapacitacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cursoCapacitacionPSubalternoDTO.UsuarioIngresoRegistro;

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

        public CursoCapacitacionPSubalternoDTO BuscarCursoCapacitacionPSubalternoID(int Codigo)
        {
            CursoCapacitacionPSubalternoDTO cursoCapacitacionPSubalternoDTO = new CursoCapacitacionPSubalternoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CursoCapacitacionPSubalternoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CursoCapacitacionPSubalternoId", SqlDbType.Int);
                    cmd.Parameters["@CursoCapacitacionPSubalternoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        cursoCapacitacionPSubalternoDTO.CursoCapacitacionPSubalternoId = Convert.ToInt32(dr["CursoCapacitacionPSubalternoId"]);
                        cursoCapacitacionPSubalternoDTO.DescCursoCapacitacion = dr["DescCursoCapacitacion"].ToString();
                        cursoCapacitacionPSubalternoDTO.CodigoCursoCapacitacion = dr["CodigoCursoCapacitacion"].ToString();
                        cursoCapacitacionPSubalternoDTO.DuracionCursoCapacitacion = dr["DuracionCursoCapacitacion"].ToString();
                        cursoCapacitacionPSubalternoDTO.InicioTerminoCursoCapacitacion = dr["InicioTerminoCursoCapacitacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return cursoCapacitacionPSubalternoDTO;
        }

        public string ActualizarCursoCapacitacionPSubalterno(CursoCapacitacionPSubalternoDTO cursoCapacitacionPSubalternoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_CursoCapacitacionPSubalternoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CursoCapacitacionPSubalternoId", SqlDbType.Int);
                    cmd.Parameters["@CursoCapacitacionPSubalternoId"].Value = cursoCapacitacionPSubalternoDTO.CursoCapacitacionPSubalternoId;

                    cmd.Parameters.Add("@DescCursoCapacitacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCursoCapacitacion"].Value = cursoCapacitacionPSubalternoDTO.DescCursoCapacitacion;

                    cmd.Parameters.Add("@CodigoCursoCapacitacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCursoCapacitacion"].Value = cursoCapacitacionPSubalternoDTO.CodigoCursoCapacitacion;

                    cmd.Parameters.Add("@DuracionCursoCapacitacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@DuracionCursoCapacitacion"].Value = cursoCapacitacionPSubalternoDTO.DuracionCursoCapacitacion;

                    cmd.Parameters.Add("@InicioTerminoCursoCapacitacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@InicioTerminoCursoCapacitacion"].Value = cursoCapacitacionPSubalternoDTO.InicioTerminoCursoCapacitacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cursoCapacitacionPSubalternoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCursoCapacitacionPSubalterno(CursoCapacitacionPSubalternoDTO cursoCapacitacionPSubalternoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CursoCapacitacionPSubalternoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CursoCapacitacionPSubalternoId", SqlDbType.Int);
                    cmd.Parameters["@CursoCapacitacionPSubalternoId"].Value = cursoCapacitacionPSubalternoDTO.CursoCapacitacionPSubalternoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cursoCapacitacionPSubalternoDTO.UsuarioIngresoRegistro;

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
