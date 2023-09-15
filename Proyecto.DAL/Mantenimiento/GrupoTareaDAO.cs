using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class GrupoTareaDAO
    {

        SqlCommand cmd = new();

        public List<GrupoTareaDTO> ObtenerGrupoTareas()
        {
            List<GrupoTareaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_GrupoTareaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new GrupoTareaDTO()
                        {
                            GrupoTareaId = Convert.ToInt32(dr["GrupoTareaId"]),
                            DescGrupoTarea = dr["DescGrupoTarea"].ToString(),
                            CodigoGrupoTarea = dr["CodigoGrupoTarea"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarGrupoTarea(GrupoTareaDTO grupoTareaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoTareaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescGrupoTarea", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescGrupoTarea"].Value = grupoTareaDTO.DescGrupoTarea;

                    cmd.Parameters.Add("@CodigoGrupoTarea", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoGrupoTarea"].Value = grupoTareaDTO.CodigoGrupoTarea;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = grupoTareaDTO.UsuarioIngresoRegistro;

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

        public GrupoTareaDTO BuscarGrupoTareaID(int Codigo)
        {
            GrupoTareaDTO grupoTareaDTO = new GrupoTareaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoTareaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoTareaId", SqlDbType.Int);
                    cmd.Parameters["@GrupoTareaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        grupoTareaDTO.GrupoTareaId = Convert.ToInt32(dr["GrupoTareaId"]);
                        grupoTareaDTO.DescGrupoTarea = dr["DescGrupoTarea"].ToString();
                        grupoTareaDTO.CodigoGrupoTarea = dr["CodigoGrupoTarea"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return grupoTareaDTO;
        }

        public string ActualizarGrupoTarea(GrupoTareaDTO grupoTareaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_GrupoTareaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoTareaId", SqlDbType.Int);
                    cmd.Parameters["@GrupoTareaId"].Value = grupoTareaDTO.GrupoTareaId;

                    cmd.Parameters.Add("@DescGrupoTarea", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescGrupoTarea"].Value = grupoTareaDTO.DescGrupoTarea;

                    cmd.Parameters.Add("@CodigoGrupoTarea", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoGrupoTarea"].Value = grupoTareaDTO.CodigoGrupoTarea;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = grupoTareaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarGrupoTarea(int Codigo)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoTareaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoTareaId", SqlDbType.Int);
                    cmd.Parameters["@GrupoTareaId"].Value = Codigo;
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
