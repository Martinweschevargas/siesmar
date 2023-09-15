using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CalificativoAsignadoOperatividadMaterialDAO
    {

        SqlCommand cmd = new();

        public List<CalificativoAsignadoOperatividadMaterialDTO> ObtenerCalificativoAsignadoOperatividadMaterials()
        {
            List<CalificativoAsignadoOperatividadMaterialDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CalificativoAsignadoOperatividadMaterialListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CalificativoAsignadoOperatividadMaterialDTO()
                        {
                            CalificativoAsignadoOperatividadMaterialId = Convert.ToInt32(dr["CalificativoAsignadoOperatividadMaterialId"]),
                            Descripcion = dr["Descripcion"].ToString(),
                            Calificativo = dr["Calificativo"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCalificativoAsignadoOperatividadMaterial(CalificativoAsignadoOperatividadMaterialDTO capitaniaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CalificativoAsignadoOperatividadMaterialRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Descripcion"].Value = capitaniaDTO.Descripcion;

                    cmd.Parameters.Add("@Calificativo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Calificativo"].Value = capitaniaDTO.Calificativo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capitaniaDTO.UsuarioIngresoRegistro;

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

        public CalificativoAsignadoOperatividadMaterialDTO BuscarCalificativoAsignadoOperatividadMaterialID(int Codigo)
        {
            CalificativoAsignadoOperatividadMaterialDTO capitaniaDTO = new CalificativoAsignadoOperatividadMaterialDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CalificativoAsignadoOperatividadMaterialEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CalificativoAsignadoOperatividadMaterialId", SqlDbType.Int);
                    cmd.Parameters["@CalificativoAsignadoOperatividadMaterialId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        capitaniaDTO.CalificativoAsignadoOperatividadMaterialId = Convert.ToInt32(dr["CalificativoAsignadoOperatividadMaterialId"]);
                        capitaniaDTO.Descripcion = dr["Descripcion"].ToString();
                        capitaniaDTO.Calificativo = dr["Calificativo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return capitaniaDTO;
        }

        public string ActualizarCalificativoAsignadoOperatividadMaterial(CalificativoAsignadoOperatividadMaterialDTO capitaniaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CalificativoAsignadoOperatividadMaterialActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CalificativoAsignadoOperatividadMaterialId", SqlDbType.Int);
                    cmd.Parameters["@CalificativoAsignadoOperatividadMaterialId"].Value = capitaniaDTO.CalificativoAsignadoOperatividadMaterialId;

                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Descripcion"].Value = capitaniaDTO.Descripcion;

                    cmd.Parameters.Add("@Calificativo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Calificativo"].Value = capitaniaDTO.Calificativo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capitaniaDTO.UsuarioIngresoRegistro;

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

        public string EliminarCalificativoAsignadoOperatividadMaterial(CalificativoAsignadoOperatividadMaterialDTO capitaniaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CalificativoAsignadoOperatividadMaterialEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CalificativoAsignadoOperatividadMaterialId", SqlDbType.Int);
                    cmd.Parameters["@CalificativoAsignadoOperatividadMaterialId"].Value = capitaniaDTO.CalificativoAsignadoOperatividadMaterialId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capitaniaDTO.UsuarioIngresoRegistro;

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
