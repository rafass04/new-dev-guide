namespace NewDevGuide.DTO.DTO
{
    public class ResultadoDto<T>
    {
        public bool Ok { get; set; }
        public T Dados { get; set; }
        public ErroDto Erro { get; set; }
    }
}
