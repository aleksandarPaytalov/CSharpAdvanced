using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public string name; 
        public int neededRenovators; 
        public string project; 
        public List<Renovator> renovators;
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            this.renovators = new List<Renovator>(); 
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public IReadOnlyCollection<Renovator> Renovators => this.renovators;

        public int Count => this.Renovators.Count;
        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            else if (this.Count == this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            this.renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";        
        }

        public bool RemoveRenovator(string name)
        {
            if (this.Renovators.Any(x => x.Name == name))
            {
                this.renovators.Remove(this.Renovators.FirstOrDefault(x => x.Name == name));
                return true;
            }
            return false;
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            int removedRenovators = 0;
            while (Renovators.FirstOrDefault(r => r.Type == type) != null)
            {
                var currentRenovator = Renovators.FirstOrDefault(r => r.Type == type);
                this.renovators.Remove(currentRenovator);
                removedRenovators++;
            }

            return removedRenovators;
        }

        public Renovator HireRenovator(string name)
        {
            var exist = this.Renovators.FirstOrDefault(r => r.Name == name);
            if (exist != null)
            {
                exist.Hired = true;
                //this.Renovators.FirstOrDefault(x => x.Name == name).Hired = true;
                return exist;
            }
            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> retovatorsToBePaid = new List<Renovator>();
            foreach (var renovator in this.Renovators.Where(r => r.Days >= days))
            {
                retovatorsToBePaid.Add(renovator);
            }
            return retovatorsToBePaid;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {this.Project}:");
            foreach (var renovator in this.Renovators.Where(r => r.Hired == false))
            {
                sb.AppendLine(renovator.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
