using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfService1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        UserDTO LoginService(string username, string password);

        [OperationContract]
        PerfilDTO GetPerfil(string Documento);
    }

    [DataContract]
    public class UserDTO : BaseRespuesta
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Documento { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public int CheckPassword { get; set; }
        [DataMember]
        public int Rol { get; set; }
    }

    [DataContract]
    public class PerfilDTO : BaseRespuesta
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Documento { get; set; }
        [DataMember]
        public string Nombre1 { get; set; }
        [DataMember]
        public string Nombre2 { get; set; }
        [DataMember]
        public string Nombre3 { get; set; }
        [DataMember]
        public string NombreCompleto { get; set; }
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        public string ApellidoMaterno { get; set; }
        [DataMember]
        public string CorreoInterno { get; set; }
        [DataMember]
        public string Foto { get; set; }
        [DataMember]
        public int Rol { get; set; }
    }

    [DataContract]
    public class BaseRespuesta
    {
        [DataMember]
        public string MensajeRespuesta { get; set; }
        [DataMember]
        public string Error { get; set; }
    }
}
