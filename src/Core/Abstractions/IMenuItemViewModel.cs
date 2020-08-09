namespace ChatterBot.Core.Interfaces
{
    public interface IMenuItemViewModel
    {
        object Icon { get; }
        object Label { get; }
        object ToolTip { get; }
        bool IsVisible { get; set; }
        bool IsOption { get; }
        object Content { get; }
    }
}
