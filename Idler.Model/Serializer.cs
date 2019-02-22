using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Idler.Model;
using Newtonsoft.Json;

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
                    idleTasks.Add(new IdleTask() { Name = task.Name });
                }

            }
            catch (FileNotFoundException ex)
            {
            }

            return idleTasks;
        }
    }
}
