namespace ProAgil.Domain
{
    public class RedeSocial
    {
        public int RedeSocialId { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
        public int? EventoId { get; set; }
        public int? PalestanteId { get; set; }

        public Evento Evento { get; set; }
        public Palestrante Palestante { get; set; }
    }
}