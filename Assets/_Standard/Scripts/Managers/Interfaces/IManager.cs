namespace Gknzby.Kit.Management
{   
    public interface IManager
    {
        System.Type GetManagerType();
    }

    //public interface IManager<out T> : IManager
    //    where T : IManager
    //{

    //}
}