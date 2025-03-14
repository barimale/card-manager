namespace Card.Application.Integration
{
    public class IdGeneratorAdapter : IIdGeneratorAdapter
    {
        public string Generate(int length)
        {
            return Guid.NewGuid().ToString();
        }
    }
}
