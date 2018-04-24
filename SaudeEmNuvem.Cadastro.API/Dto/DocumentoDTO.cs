namespace SaudeEmNuvem.Cadastro.API.Dto
{
    public class DocumentoDto
    {
        public int TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public byte[] Image { get; set; }
        public string Meta { get; set; }
    }
}
