using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class InspeccionFinalidadDAO
    {

        SqlCommand cmd = new();

        public List<InspeccionFinalidadDTO> ObtenerInspeccionFinalidads()
        {
            List<InspeccionFinalidadDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_InspeccionFinalidadListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new InspeccionFinalidadDTO()
                        {
                            InspeccionFinalidadId = Convert.ToInt32(dr["InspeccionFinalidadId"]),
                            DescInspeccionFinalidad = dr["DescInspeccionFinalidad"].ToString(),
                            CodigoInspeccionFinalidad = dr["CodigoInspeccionFinalidad"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarInspeccionFinalidad(InspeccionFinalidadDTO inspeccionFinalidadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InspeccionFinalidadRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescInspeccionFinalidad", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescInspeccionFinalidad"].Value = inspeccionFinalidadDTO.DescInspeccionFinalidad;

                    cmd.Parameters.Add("@CodigoInspeccionFinalidad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoInspeccionFinalidad"].Value = inspeccionFinalidadDTO.CodigoInspeccionFinalidad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inspeccionFinalidadDTO.UsuarioIngresoRegistro;

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

        public InspeccionFinalidadDTO BuscarInspeccionFinalidadID(int Codigo)
        {
            InspeccionFinalidadDTO inspeccionFinalidadDTO = new InspeccionFinalidadDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InspeccionFinalidadEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InspeccionFinalidadId", SqlDbType.Int);
                    cmd.Parameters["@InspeccionFinalidadId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        inspeccionFinalidadDTO.InspeccionFinalidadId = Convert.ToInt32(dr["InspeccionFinalidadId"]);
                        inspeccionFinalidadDTO.DescInspeccionFinalidad = dr["DescInspeccionFinalidad"].ToString();
                        inspeccionFinalidadDTO.CodigoInspeccionFinalidad = dr["CodigoInspeccionFinalidad"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return inspeccionFinalidadDTO;
        }

        public string ActualizarInspeccionFinalidad(InspeccionFinalidadDTO inspeccionFinalidadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InspeccionFinalidadActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InspeccionFinalidadId", SqlDbType.Int);
                    cmd.Parameters["@InspeccionFinalidadId"].Value = inspeccionFinalidadDTO.InspeccionFinalidadId;

                    cmd.Parameters.Add("@DescInspeccionFinalidad", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescInspeccionFinalidad"].Value = inspeccionFinalidadDTO.DescInspeccionFinalidad;

                    cmd.Parameters.Add("@CodigoInspeccionFinalidad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoInspeccionFinalidad"].Value = inspeccionFinalidadDTO.CodigoInspeccionFinalidad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inspeccionFinalidadDTO.UsuarioIngresoRegistro;

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

        public string EliminarInspeccionFinalidad(InspeccionFinalidadDTO inspeccionFinalidadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InspeccionFinalidadEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InspeccionFinalidadId", SqlDbType.Int);
                    cmd.Parameters["@InspeccionFinalidadId"].Value = inspeccionFinalidadDTO.InspeccionFinalidadId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inspeccionFinalidadDTO.UsuarioIngresoRegistro;

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
