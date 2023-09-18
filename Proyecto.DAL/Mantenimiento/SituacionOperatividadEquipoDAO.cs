using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SituacionOperatividadEquipoDAO
    {

        SqlCommand cmd = new();

        public List<SituacionOperatividadEquipoDTO> ObtenerSituacionOperatividadEquipos()
        {
            List<SituacionOperatividadEquipoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SituacionOperatividadEquiposListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SituacionOperatividadEquipoDTO()
                        {
                            SituacionOperatividadEquipoId = Convert.ToInt32(dr["SituacionOperatividadEquipoId"]),
                            DescripcionMaterial = dr["DescripcionMaterial"].ToString(),
                            Cantidad = dr["Cantidad"].ToString(),
                            CodigoUnidad = dr["CodigoUnidad"].ToString(),
                            Ubicacion = dr["Ubicacion"].ToString(),
                            Distrito = dr["Distrito"].ToString(),
                            Condicion = dr["Condicion"].ToString(),
                            Observacion = dr["Observacion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSituacionOperatividadEquipo(SituacionOperatividadEquipoDTO situacionOperatividadEquipoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SituacionOperatividadEquiposRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescripcionMaterial", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescripcionMaterial"].Value = situacionOperatividadEquipoDTO.DescripcionMaterial;

                    cmd.Parameters.Add("@Cantidad", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Cantidad"].Value = situacionOperatividadEquipoDTO.Cantidad;

                    cmd.Parameters.Add("@CodigoUnidad", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoUnidad"].Value = situacionOperatividadEquipoDTO.CodigoUnidad;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Ubicacion"].Value = situacionOperatividadEquipoDTO.Ubicacion;

                    cmd.Parameters.Add("@Distrito", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Distrito"].Value = situacionOperatividadEquipoDTO.Distrito;

                    cmd.Parameters.Add("@Condicion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Condicion"].Value = situacionOperatividadEquipoDTO.Condicion;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Observacion"].Value = situacionOperatividadEquipoDTO.Observacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperatividadEquipoDTO.UsuarioIngresoRegistro;

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

        public SituacionOperatividadEquipoDTO BuscarSituacionOperatividadEquipoID(int Codigo)
        {
            SituacionOperatividadEquipoDTO situacionOperatividadEquipoDTO = new SituacionOperatividadEquipoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SituacionOperatividadEquiposEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadEquipoId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadEquipoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        situacionOperatividadEquipoDTO.SituacionOperatividadEquipoId = Convert.ToInt32(dr["SituacionOperatividadEquipoId"]);
                        situacionOperatividadEquipoDTO.DescripcionMaterial = dr["DescripcionMaterial"].ToString();
                        situacionOperatividadEquipoDTO.Cantidad = dr["Cantidad"].ToString();
                        situacionOperatividadEquipoDTO.CodigoUnidad = dr["CodigoUnidad"].ToString();
                        situacionOperatividadEquipoDTO.Ubicacion = dr["Ubicacion"].ToString();
                        situacionOperatividadEquipoDTO.Distrito = dr["Distrito"].ToString();
                        situacionOperatividadEquipoDTO.Condicion = dr["Condicion"].ToString();
                        situacionOperatividadEquipoDTO.Observacion = dr["Observacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return situacionOperatividadEquipoDTO;
        }

        public string ActualizarSituacionOperatividadEquipo(SituacionOperatividadEquipoDTO situacionOperatividadEquipoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_SituacionOperatividadEquiposActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadEquipoId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadEquipoId"].Value = situacionOperatividadEquipoDTO.SituacionOperatividadEquipoId;

                    cmd.Parameters.Add("@DescripcionMaterial", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescripcionMaterial"].Value = situacionOperatividadEquipoDTO.DescripcionMaterial;

                    cmd.Parameters.Add("@Cantidad", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Cantidad"].Value = situacionOperatividadEquipoDTO.Cantidad;

                    cmd.Parameters.Add("@CodigoUnidad", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoUnidad"].Value = situacionOperatividadEquipoDTO.CodigoUnidad;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Ubicacion"].Value = situacionOperatividadEquipoDTO.Ubicacion;

                    cmd.Parameters.Add("@Distrito", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Distrito"].Value = situacionOperatividadEquipoDTO.Distrito;

                    cmd.Parameters.Add("@Condicion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Condicion"].Value = situacionOperatividadEquipoDTO.Condicion;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Observacion"].Value = situacionOperatividadEquipoDTO.Observacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperatividadEquipoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarSituacionOperatividadEquipo(SituacionOperatividadEquipoDTO situacionOperatividadEquipoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SituacionOperatividadEquiposEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadEquipoId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadEquipoId"].Value = situacionOperatividadEquipoDTO.SituacionOperatividadEquipoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperatividadEquipoDTO.UsuarioIngresoRegistro;

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
