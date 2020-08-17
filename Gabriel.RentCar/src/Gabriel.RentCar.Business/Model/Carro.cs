namespace Gabriel.RentCar.Business.Model
{
    public class Carro : Entity
    {
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public TipoCarro TipoCarro { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }

        // -=-=-=-=-=-=-=- //
        

    }
}
