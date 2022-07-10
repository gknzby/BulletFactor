namespace Gknzby.Kit.UI
{
    public interface IUIComponent
    {
        UIAction ActionUI { get; set; }
        string ActionUIValue { get; set; }
        void SendActionToUIManager();
    } 
}
