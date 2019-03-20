using Idler.Model;
using Newtonsoft.Json;
using System.IO;

namespace Idler.ViewModel
{
    public class Serializer
    {
        private IdleTasks tasks;

        public void SaveState(IdleTasks tasks)
        {
            var json = JsonConvert.SerializeObject(tasks);
            File.WriteAllLines("IdlerState.json", new[] { json });
        }

        public IdleTasks GetState()
        {
            IdleTasks idleTasks = new IdleTasks();
            try
            {
                var content = File.ReadAllLines("IdlerState.json");
                var jsonObject = JsonConvert.DeserializeObject<IdleTasks>(content[0]);
                foreach (var task in jsonObject)
                {
                    idleTasks.Add(new IdleTask() {
                        Name = task.Name,
                        EndDay = task.EndDay,
                        EndHour = task.EndHour,
                        EndMinutes = task.EndMinutes,
                        StartDay = task.StartDay,
                        StartHour = task.StartHour,
                        StartMinutes = task.StartMinutes,
                        StartMonth = task.StartMonth,
                        StartYear = task.StartYear });
                }

            }
            catch (FileNotFoundException)
            {
            }

            return idleTasks;
        }
    }
}
