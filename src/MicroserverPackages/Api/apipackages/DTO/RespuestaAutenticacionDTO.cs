namespace apipackages.DTO;

    public class RespuestaAutenticacionDTO
    {
        public string Token { get; set; }
        public DateTime Expiracion { get; set; }
        public int Rol {get; set;}
    }

