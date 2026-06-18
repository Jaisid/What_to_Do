using What_to_Do.Domain;

namespace What_to_Do.Infrastructure
{
    public class TaskService
    {
        private List<Taskitem> tasks = new();
        private int id = 1;

        public void AddTask(string title)
        {
            tasks.Add(new Taskitem { Id = id++, Title = title, IsDone = false });
        }

        public List<Taskitem> GetAll()
        {
            return tasks;
        }

        public void CompleteTask(int taskId)
        {
            var task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
                task.IsDone = true;
        }
    }
}
