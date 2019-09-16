namespace Idler.ViewModel.Interfaces
{
    public interface ITimer
    {
        TaskVM TaskVM { get; set; }
        void Run(TaskVM taskVM);
        void Stop();
    }
}