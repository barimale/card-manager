namespace Ordering.Application.Integration
{
    public class IdGeneratorAdapter : IIdGeneratorAdapter
    {
        public string Generate(int length = 32)
        {
            return Guid.NewGuid().ToString();
        }
    }
}
