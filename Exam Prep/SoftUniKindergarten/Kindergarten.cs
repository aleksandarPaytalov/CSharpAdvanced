
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; set; }

        public int ChildrenCount
        {
            get { return Registry.Count; }        
        } 

        public bool AddChild(Child child)
        {
                   
            if (ChildrenCount < Capacity)
            {
                Registry.Add(child);
                return true;            
            }
            return false;
        }
        public bool RemoveChild(string childFullName)
        => this.Registry.Remove(Registry.FirstOrDefault(x => x.FirstName == childFullName.Split(" ")[0] && x.LastName == childFullName.Split(" ")[1]));

        public Child GetChild(string childFullName)
        => Registry.FirstOrDefault(x => x.FirstName == childFullName.Split(" ")[0] && x.LastName == childFullName.Split(" ")[1]);
        
        public string RegistryReport()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Registered children in {Name}:");
            foreach (var name in Registry.OrderByDescending(a => a.Age).ThenBy(l => l.LastName).ThenBy(f => f.FirstName))
            {
                sb.AppendLine(name.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
