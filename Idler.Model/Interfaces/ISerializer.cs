using Idler.Model;

namespace Idler.Model.Interfces
{
    public interface ISerializer
    {
        IdleTasks GetState();
        void SaveState(IdleTasks tasks);
    }
}