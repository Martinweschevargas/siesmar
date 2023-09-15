using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class LugarFormacionServicioMilitarDAO
    {

        SqlCommand cmd = new();

        public List<LugarFormacionServicioMilitarDTO> ObtenerLugarFormacionServicioMilitars()
        {
            List<LugarFormacionServicioMilitarDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_LugarFormacionServicioMilitarListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new LugarFormacionServicioMilitarDTO()
                        {
                            LugarFormacionServicioMilitarId = Convert.ToInt32(dr["LugarFormacionServicioMilitarId"]),
                            DescLugarFormacionServicioMilitar = dr["DescLugarFormacionServicioMilitar"].ToString(),
                            CodigoLugarFormacionServicioMilitar = dr["CodigoLugarFormacionServicioMilitar"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarLugarFormacionServicioMilitar(LugarFormacionServicioMilitarDTO lugarFormacionServicioMilitarDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_LugarFormacionServicioMilitarRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescLugarFormacionServicioMilitar", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescLugarFormacionServicioMilitar"].Value = lugarFormacionServicioMilitarDTO.DescLugarFormacionServicioMilitar;

                    cmd.Parameters.Add("@CodigoLugarFormacionServicioMilitar", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoLugarFormacionServicioMilitar"].Value = lugarFormacionServicioMilitarDTO.CodigoLugarFormacionServicioMilitar;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = lugarFormacionServicioMilitarDTO.UsuarioIngresoRegistro;

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

        public LugarFormacionServicioMilitarDTO BuscarLugarFormacionServicioMilitarID(int Codigo)
        {
            LugarFormacionServicioMilitarDTO lugarFormacionServicioMilitarDTO = new LugarFormacionServicioMilitarDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_LugarFormacionServicioMilitarEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@LugarFormacionServicioMilitarId", SqlDbType.Int);
                    cmd.Parameters["@LugarFormacionServicioMilitarId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        lugarFormacionServicioMilitarDTO.LugarFormacionServicioMilitarId = Convert.ToInt32(dr["LugarFormacionServicioMilitarId"]);
                        lugarFormacionServicioMilitarDTO.DescLugarFormacionServicioMilitar = dr["DescLugarFormacionServicioMilitar"].ToString();
                        lugarFormacionServicioMilitarDTO.CodigoLugarFormacionServicioMilitar = dr["CodigoLugarFormacionServicioMilitar"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return lugarFormacionServicioMilitarDTO;
        }

        public string ActualizarLugarFormacionServicioMilitar(LugarFormacionServicioMilitarDTO lugarFormacionServicioMilitarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_LugarFormacionServicioMilitarActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@LugarFormacionServicioMilitarId", SqlDbType.Int);
                    cmd.Parameters["@LugarFormacionServicioMilitarId"].Value = lugarFormacionServicioMilitarDTO.LugarFormacionServicioMilitarId;

                    cmd.Parameters.Add("@DescLugarFormacionServicioMilitar", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescLugarFormacionServicioMilitar"].Value = lugarFormacionServicioMilitarDTO.DescLugarFormacionServicioMilitar;

                    cmd.Parameters.Add("@CodigoLugarFormacionServicioMilitar", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoLugarFormacionServicioMilitar"].Value = lugarFormacionServicioMilitarDTO.CodigoLugarFormacionServicioMilitar;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = lugarFormacionServicioMilitarDTO.UsuarioIngresoRegistro;

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

        public bool EliminarLugarFormacionServicioMilitar(int Codigo)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_LugarFormacionServicioMilitarEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@LugarFormacionServicioMilitarId", SqlDbType.Int);
                    cmd.Parameters["@LugarFormacionServicioMilitarId"].Value = Codigo;
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
