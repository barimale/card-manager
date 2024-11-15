namespace Ordering.Application.Integration
{
    public interface IIdGeneratorAdapter
    {
        public string Generate(int length = 32);
    }
}
