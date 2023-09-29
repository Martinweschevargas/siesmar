
using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EntidadMilitarDAO
    {

        SqlCommand cmd = new();

        public List<EntidadMilitarDTO> ObtenerEntidadMilitars()
        {
            List<EntidadMilitarDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EntidadMilitarListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EntidadMilitarDTO()
                        {
                            EntidadMilitarId = Convert.ToInt32(dr["EntidadMilitarId"]),
                            DescEntidadMilitar = dr["DescEntidadMilitar"].ToString(),
                            CodigoEntidadMilitar = dr["CodigoEntidadMilitar"].ToString(),
                            AbrevEntidadMilitar = dr["AbrevEntidadMilitar"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEntidadMilitar(EntidadMilitarDTO entidadMilitarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EntidadMilitarRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescEntidadMilitar", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@DescEntidadMilitar"].Value = entidadMilitarDTO.DescEntidadMilitar;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = entidadMilitarDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@AbrevEntidadMilitar", SqlDbType.VarChar, 10);
                    cmd.Parameters["@AbrevEntidadMilitar"].Value = entidadMilitarDTO.AbrevEntidadMilitar;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entidadMilitarDTO.UsuarioIngresoRegistro;

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

        public EntidadMilitarDTO BuscarEntidadMilitarID(int Codigo)
        {
            EntidadMilitarDTO entidadMilitarDTO = new EntidadMilitarDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EntidadMilitarEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntidadMilitarId", SqlDbType.Int);
                    cmd.Parameters["@EntidadMilitarId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        entidadMilitarDTO.EntidadMilitarId = Convert.ToInt32(dr["EntidadMilitarId"]);
                        entidadMilitarDTO.DescEntidadMilitar = dr["DescEntidadMilitar"].ToString();
                        entidadMilitarDTO.CodigoEntidadMilitar = dr["CodigoEntidadMilitar"].ToString();
                        entidadMilitarDTO.AbrevEntidadMilitar = dr["AbrevEntidadMilitar"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return entidadMilitarDTO;
        }

        public string ActualizarEntidadMilitar(EntidadMilitarDTO entidadMilitarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_EntidadMilitarActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntidadMilitarId", SqlDbType.Int);
                    cmd.Parameters["@EntidadMilitarId"].Value = entidadMilitarDTO.EntidadMilitarId;

                    cmd.Parameters.Add("@DescEntidadMilitar", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@DescEntidadMilitar"].Value = entidadMilitarDTO.DescEntidadMilitar;

                    cmd.Parameters.Add("@CodigoEntidadMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadMilitar"].Value = entidadMilitarDTO.CodigoEntidadMilitar;

                    cmd.Parameters.Add("@AbrevEntidadMilitar", SqlDbType.VarChar, 10);
                    cmd.Parameters["@AbrevEntidadMilitar"].Value = entidadMilitarDTO.AbrevEntidadMilitar;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entidadMilitarDTO.UsuarioIngresoRegistro;

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

        public string EliminarEntidadMilitar(EntidadMilitarDTO entidadMilitarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EntidadMilitarEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntidadMilitarId", SqlDbType.Int);
                    cmd.Parameters["@EntidadMilitarId"].Value = entidadMilitarDTO.EntidadMilitarId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entidadMilitarDTO.UsuarioIngresoRegistro;

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
