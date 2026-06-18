using What_to_Do.Domain;

namespace What_to_Do.Application
{
    public interface ITaskService
    {
        void AddTask(string title);
        List<Taskitem> GetAll();
        void CompleteTask(int id);
    }
}
