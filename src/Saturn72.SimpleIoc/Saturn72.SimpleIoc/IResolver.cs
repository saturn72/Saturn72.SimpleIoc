namespace Saturn72.SimpleIoc
{
    public interface IResolver
    {
        TService Resolve<TService>();
    }
}