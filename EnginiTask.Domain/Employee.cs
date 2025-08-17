namespace EnginiTask.Domain
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;    

        public int? ManagerId { get; set; }

        public ICollection<Employee> Subordinates { get; set; }
    }
}
