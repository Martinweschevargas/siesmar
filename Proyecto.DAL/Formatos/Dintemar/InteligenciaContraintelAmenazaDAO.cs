using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dintemar
{
    public class InteligenciaContraintelAmenazaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<InteligenciaContraintelAmenazaDTO> ObtenerLista(int? CargaId = null)
        {
            List<InteligenciaContraintelAmenazaDTO> lista = new List<InteligenciaContraintelAmenazaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_InteligenciaContrainteligenciaAmenazaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new InteligenciaContraintelAmenazaDTO()
                        {
                            InteligenciaContrainteligenciaAmenazaId = Convert.ToInt32(dr["InteligenciaContrainteligenciaAmenazaId"]),
                            DescAmenazaSeguridadNacional = dr["DescAmenazaSeguridadNacional"].ToString(),
                            NotasInteligentes = Convert.ToInt32(dr["NotasInteligentes"]),
                            EstudiosInteligencia =Convert.ToInt32(dr["EstudiosInteligencia"]),
                            ApreciacionesInteligencia = Convert.ToInt32(dr["ApreciacionesInteligencia"]),
                            NotasInformacion = Convert.ToInt32(dr["NotasInformacion"]),
                            NotasContrainteligencia = Convert.ToInt32(dr["NotasContrainteligencia"]),
                            EstudiosContrainteligencia = Convert.ToInt32(dr["EstudiosContrainteligencia"]),
                            ApreciacionesContrainteligencia = Convert.ToInt32(dr["ApreciacionesContrainteligencia"]),
                            NotasInformacionContrainteligencia = Convert.ToInt32(dr["NotasInformacionContrainteligencia"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(InteligenciaContraintelAmenazaDTO intelContraintelAmenazaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InteligenciaContrainteligenciaAmenazaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoAmenazaSeguridadNacional ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAmenazaSeguridadNacional "].Value = intelContraintelAmenazaDTO.CodigoAmenazaSeguridadNacional;

                    cmd.Parameters.Add("@NotasInteligentes", SqlDbType.Int);
                    cmd.Parameters["@NotasInteligentes"].Value = intelContraintelAmenazaDTO.NotasInteligentes;

                    cmd.Parameters.Add("@EstudiosInteligencia", SqlDbType.Int);
                    cmd.Parameters["@EstudiosInteligencia"].Value = intelContraintelAmenazaDTO.EstudiosInteligencia;

                    cmd.Parameters.Add("@ApreciacionesInteligencia", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionesInteligencia"].Value = intelContraintelAmenazaDTO.ApreciacionesInteligencia;

                    cmd.Parameters.Add("@NotasInformacion", SqlDbType.Int);
                    cmd.Parameters["@NotasInformacion"].Value = intelContraintelAmenazaDTO.NotasInformacion;

                    cmd.Parameters.Add("@NotasContrainteligencia", SqlDbType.Int);
                    cmd.Parameters["@NotasContrainteligencia"].Value = intelContraintelAmenazaDTO.NotasContrainteligencia;

                    cmd.Parameters.Add("@EstudiosContrainteligencia", SqlDbType.Int);
                    cmd.Parameters["@EstudiosContrainteligencia"].Value = intelContraintelAmenazaDTO.EstudiosContrainteligencia;

                    cmd.Parameters.Add("@ApreciacionesContrainteligencia", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionesContrainteligencia"].Value = intelContraintelAmenazaDTO.ApreciacionesContrainteligencia;

                    cmd.Parameters.Add("@NotasInformacionContrainteligencia", SqlDbType.Int);
                    cmd.Parameters["@NotasInformacionContrainteligencia"].Value = intelContraintelAmenazaDTO.NotasInformacionContrainteligencia;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = intelContraintelAmenazaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = intelContraintelAmenazaDTO.UsuarioIngresoRegistro;

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

        public InteligenciaContraintelAmenazaDTO BuscarFormato(int Codigo)
        {
            InteligenciaContraintelAmenazaDTO intelContraintelAmenazaDTO = new InteligenciaContraintelAmenazaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InteligenciaContrainteligenciaAmenazaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InteligenciaContrainteligenciaAmenazaId", SqlDbType.Int);
                    cmd.Parameters["@InteligenciaContrainteligenciaAmenazaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        intelContraintelAmenazaDTO.InteligenciaContrainteligenciaAmenazaId = Convert.ToInt32(dr["InteligenciaContrainteligenciaAmenazaId"]);
                        intelContraintelAmenazaDTO.CodigoAmenazaSeguridadNacional =  dr["CodigoAmenazaSeguridadNacional "].ToString();
                        intelContraintelAmenazaDTO.NotasInteligentes = Convert.ToInt32(dr["NotasInteligentes"]);
                        intelContraintelAmenazaDTO.EstudiosInteligencia = Convert.ToInt32(dr["EstudiosInteligencia"]);
                        intelContraintelAmenazaDTO.ApreciacionesInteligencia = Convert.ToInt32(dr["ApreciacionesInteligencia"]);
                        intelContraintelAmenazaDTO.NotasInformacion = Convert.ToInt32(dr["NotasInformacion"]);
                        intelContraintelAmenazaDTO.NotasContrainteligencia = Convert.ToInt32(dr["NotasContrainteligencia"]);
                        intelContraintelAmenazaDTO.EstudiosContrainteligencia = Convert.ToInt32(dr["EstudiosContrainteligencia"]);
                        intelContraintelAmenazaDTO.ApreciacionesContrainteligencia = Convert.ToInt32(dr["ApreciacionesContrainteligencia"]);
                        intelContraintelAmenazaDTO.NotasInformacionContrainteligencia = Convert.ToInt32(dr["NotasInformacionContrainteligencia"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return intelContraintelAmenazaDTO;
        }

        public string ActualizaFormato(InteligenciaContraintelAmenazaDTO intelContraintelAmenazaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_InteligenciaContrainteligenciaAmenazaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InteligenciaContrainteligenciaAmenazaId", SqlDbType.Int);
                    cmd.Parameters["@InteligenciaContrainteligenciaAmenazaId"].Value = intelContraintelAmenazaDTO.InteligenciaContrainteligenciaAmenazaId;
                    
                    cmd.Parameters.Add("@CodigoAmenazaSeguridadNacional ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAmenazaSeguridadNacional "].Value = intelContraintelAmenazaDTO.CodigoAmenazaSeguridadNacional;

                    cmd.Parameters.Add("@NotasInteligentes", SqlDbType.Int);
                    cmd.Parameters["@NotasInteligentes"].Value = intelContraintelAmenazaDTO.NotasInteligentes;

                    cmd.Parameters.Add("@EstudiosInteligencia", SqlDbType.Int);
                    cmd.Parameters["@EstudiosInteligencia"].Value = intelContraintelAmenazaDTO.EstudiosInteligencia;

                    cmd.Parameters.Add("@ApreciacionesInteligencia", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionesInteligencia"].Value = intelContraintelAmenazaDTO.ApreciacionesInteligencia;

                    cmd.Parameters.Add("@NotasInformacion", SqlDbType.Int);
                    cmd.Parameters["@NotasInformacion"].Value = intelContraintelAmenazaDTO.NotasInformacion;

                    cmd.Parameters.Add("@NotasContrainteligencia", SqlDbType.Int);
                    cmd.Parameters["@NotasContrainteligencia"].Value = intelContraintelAmenazaDTO.NotasContrainteligencia;

                    cmd.Parameters.Add("@EstudiosContrainteligencia", SqlDbType.Int);
                    cmd.Parameters["@EstudiosContrainteligencia"].Value = intelContraintelAmenazaDTO.EstudiosContrainteligencia;

                    cmd.Parameters.Add("@ApreciacionesContrainteligencia", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionesContrainteligencia"].Value = intelContraintelAmenazaDTO.ApreciacionesContrainteligencia;

                    cmd.Parameters.Add("@NotasInformacionContrainteligencia", SqlDbType.Int);
                    cmd.Parameters["@NotasInformacionContrainteligencia"].Value = intelContraintelAmenazaDTO.NotasInformacionContrainteligencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = intelContraintelAmenazaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(InteligenciaContraintelAmenazaDTO intelContraintelAmenazaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InteligenciaContrainteligenciaAmenazaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InteligenciaContrainteligenciaAmenazaId", SqlDbType.Int);
                    cmd.Parameters["@InteligenciaContrainteligenciaAmenazaId"].Value = intelContraintelAmenazaDTO.InteligenciaContrainteligenciaAmenazaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = intelContraintelAmenazaDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_InteligenciaContrainteligenciaAmenazaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InteligenciaContrainteligenciaAmenaza", SqlDbType.Structured);
                    cmd.Parameters["@InteligenciaContrainteligenciaAmenaza"].TypeName = "Formato.InteligenciaContrainteligenciaAmenaza";
                    cmd.Parameters["@InteligenciaContrainteligenciaAmenaza"].Value = datos;

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

