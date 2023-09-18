using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CursoProfesionalXCargoDAO
    {

        SqlCommand cmd = new();

        public List<CursoProfesionalXCargoDTO> ObtenerCursoProfesionalXCargos()
        {
            List<CursoProfesionalXCargoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CursoProfesionalXCargoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CursoProfesionalXCargoDTO()
                        {
                            CursoProfesionalXCargoId = Convert.ToInt32(dr["CursoProfesionalXCargoId"]),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescCargo = dr["DescCargo"].ToString(),
                            DescCursoCapacitacion = dr["DescCursoCapacitacion"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCursoProfesionalXCargo(CursoProfesionalXCargoDTO CursoProfesionalXCargoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CursoProfesionalXCargoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@TipoPersonalMilitarId"].Value = CursoProfesionalXCargoDTO.TipoPersonalMilitarId;

                    cmd.Parameters.Add("@CargoId", SqlDbType.Int);
                    cmd.Parameters["@CargoId"].Value = CursoProfesionalXCargoDTO.CargoId;

                    cmd.Parameters.Add("@DescCursoCapacitacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescCursoCapacitacion"].Value = CursoProfesionalXCargoDTO.DescCursoCapacitacion;
      
                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CursoProfesionalXCargoDTO.UsuarioIngresoRegistro;

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

        public CursoProfesionalXCargoDTO BuscarCursoProfesionalXCargoID(int Codigo)
        {
            CursoProfesionalXCargoDTO CursoProfesionalXCargoDTO = new CursoProfesionalXCargoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CursoProfesionalXCargoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CursoProfesionalXCargoId", SqlDbType.Int);
                    cmd.Parameters["@CursoProfesionalXCargoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        CursoProfesionalXCargoDTO.CursoProfesionalXCargoId = Convert.ToInt32(dr["CursoProfesionalXCargoId"]);
                        CursoProfesionalXCargoDTO.TipoPersonalMilitarId = Convert.ToInt32(dr["TipoPersonalMilitarId"]);
                        CursoProfesionalXCargoDTO.CargoId = Convert.ToInt32(dr["CargoId"]);
                        CursoProfesionalXCargoDTO.DescCursoCapacitacion = dr["DescCursoCapacitacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return CursoProfesionalXCargoDTO;
        }

        public string ActualizarCursoProfesionalXCargo(CursoProfesionalXCargoDTO CursoProfesionalXCargoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_CursoProfesionalXCargoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CursoProfesionalXCargoId", SqlDbType.Int);
                    cmd.Parameters["@CursoProfesionalXCargoId"].Value = CursoProfesionalXCargoDTO.CursoProfesionalXCargoId;

                    cmd.Parameters.Add("@TipoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@TipoPersonalMilitarId"].Value = CursoProfesionalXCargoDTO.TipoPersonalMilitarId;

                    cmd.Parameters.Add("@CargoId", SqlDbType.Int);
                    cmd.Parameters["@CargoId"].Value = CursoProfesionalXCargoDTO.CargoId;

                    cmd.Parameters.Add("@DescCursoCapacitacion", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescCursoCapacitacion"].Value = CursoProfesionalXCargoDTO.DescCursoCapacitacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CursoProfesionalXCargoDTO.UsuarioIngresoRegistro;

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

        public string EliminarCursoProfesionalXCargo(CursoProfesionalXCargoDTO CursoProfesionalXCargoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CursoProfesionalXCargoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CursoProfesionalXCargoId", SqlDbType.Int);
                    cmd.Parameters["@CursoProfesionalXCargoId"].Value = CursoProfesionalXCargoDTO.CursoProfesionalXCargoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CursoProfesionalXCargoDTO.UsuarioIngresoRegistro;

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
