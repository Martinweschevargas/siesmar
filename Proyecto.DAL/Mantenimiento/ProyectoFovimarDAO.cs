using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ProyectoFovimarDAO
    {

        SqlCommand cmd = new();

        public List<ProyectoFovimarDTO> ObtenerProyectoFovimars()
        {
            List<ProyectoFovimarDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ProyectoFovimarListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ProyectoFovimarDTO()
                        {
                            ProyectoFovimarId = Convert.ToInt32(dr["ProyectoFovimarId"]),
                            DescProyectoFovimar = dr["DescProyectoFovimar"].ToString(),
                            CodigoProyectoFovimar = dr["CodigoProyectoFovimar"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarProyectoFovimar(ProyectoFovimarDTO proyectoFovimarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProyectoFovimarRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescProyectoFovimar", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescProyectoFovimar"].Value = proyectoFovimarDTO.DescProyectoFovimar;

                    cmd.Parameters.Add("@CodigoProyectoFovimar", SqlDbType.VarChar,20);

                    cmd.Parameters["@CodigoProyectoFovimar"].Value = proyectoFovimarDTO.CodigoProyectoFovimar;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = proyectoFovimarDTO.UsuarioIngresoRegistro;

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

        public ProyectoFovimarDTO BuscarProyectoFovimarID(int Codigo)
        {
            ProyectoFovimarDTO proyectoFovimarDTO = new ProyectoFovimarDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProyectoFovimarEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProyectoFovimarId", SqlDbType.Int);
                    cmd.Parameters["@ProyectoFovimarId"].Value = Codigo;


                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        proyectoFovimarDTO.ProyectoFovimarId = Convert.ToInt32(dr["ProyectoFovimarId"]);
                        proyectoFovimarDTO.DescProyectoFovimar = dr["DescProyectoFovimar"].ToString();
                        proyectoFovimarDTO.CodigoProyectoFovimar = dr["CodigoProyectoFovimar"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return proyectoFovimarDTO;
        }

        public string ActualizarProyectoFovimar(ProyectoFovimarDTO proyectoFovimarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProyectoFovimarActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProyectoFovimarId", SqlDbType.Int);
                    cmd.Parameters["@ProyectoFovimarId"].Value = proyectoFovimarDTO.ProyectoFovimarId;

                    cmd.Parameters.Add("@DescProyectoFovimar", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescProyectoFovimar"].Value = proyectoFovimarDTO.DescProyectoFovimar;

                    cmd.Parameters.Add("@CodigoProyectoFovimar", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoProyectoFovimar"].Value = proyectoFovimarDTO.CodigoProyectoFovimar;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = proyectoFovimarDTO.UsuarioIngresoRegistro;

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

        public string EliminarProyectoFovimar(ProyectoFovimarDTO proyectoFovimarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProyectoFovimarEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProyectoFovimarId", SqlDbType.Int);
                    cmd.Parameters["@ProyectoFovimarId"].Value = proyectoFovimarDTO.ProyectoFovimarId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = proyectoFovimarDTO.UsuarioIngresoRegistro;

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
