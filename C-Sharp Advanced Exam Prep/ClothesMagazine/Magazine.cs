using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        //private string type;
        //private int capacity;
        //private List<Cloth> clothes;

        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Clothes = new List<Cloth>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Cloth> Clothes { get; set; }

        public void AddCloth(Cloth cloth)
        {            
            if (Clothes.Count < Capacity)
            {
                Clothes.Add(cloth);
            }        
        }

        public bool RemoveCloth(string color)
        {
            Cloth cloth = Clothes.FirstOrDefault(c => c.Color == color);
            if (cloth != null)
            {
                Clothes.Remove(cloth);
                return true;
            }
            else
                return false;
        }

        public Cloth GetSmallestCloth() 
            => Clothes.MinBy(s => s.Size);
        

        public Cloth GetCloth(string color)
            => Clothes.Find(s => s.Color == color);
        

        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{this.Type} magazine contains:");
            foreach (var cloth in Clothes.OrderBy(s=>s.Size))
            {
                sb.AppendLine(cloth.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public int GetClothCount()        
            => Clothes.Count;
        
    }
}
