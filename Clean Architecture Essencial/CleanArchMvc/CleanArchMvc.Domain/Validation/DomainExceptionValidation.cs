namespace CleanArchMvc.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string erro) : base(erro) {}

        public static void VerificaErro(bool possuiErro, string erro)
        {
            if (possuiErro)
                throw new DomainExceptionValidation(erro);
        }
    }
}
