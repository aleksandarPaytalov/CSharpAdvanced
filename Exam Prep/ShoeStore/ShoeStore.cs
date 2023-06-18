using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        private List<Shoe> shoes;
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            this.shoes = new List<Shoe>();
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        private List<Shoe> Shoes => shoes;// IReadOnlyCollection
        //{
        //    get { return this.shoes; }
        //}
        public int Count => this.shoes.Count;

        public string AddShoe(Shoe shoe)
        {
            if (Shoes.Count < StorageCapacity)
            {
                this.shoes.Add(shoe);
                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }
            else
            {
                return "No more space in the storage room.";
            }
        }

        public int RemoveShoes(string material)
        {
            int shoesRemoved = 0;

            for (int i = 0; i < shoes.Count; i++)
            {
                if (shoes[i].Material == material.ToLower()) // за case sensitive
                {
                    this.shoes.RemoveAt(i);
                    i--; // за да може да се върнем и проверим обувката на индек 0, понеже всички ще се шифнат 1 позиция наляво, като премахмен обувката на индекс 0
                    shoesRemoved++;
                }
            }
            return shoesRemoved;
        }
        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> getShoesByType = new();
            foreach (var shoeType in shoes)
            {
                if (shoeType.Type == type.ToLower())
                {
                    getShoesByType.Add(shoeType);
                }
            }
            return getShoesByType;
        }
        public Shoe GetShoeBySize(double size)
        {
            //=> shoes.FirstOrDefault(s => s.Size == size);
            foreach (var item in shoes)
            {
                if (item.Size == size)
                {
                    return item;
                }
            }
            
            return null;
        }

        public string StockList(double size, string type)
        {
            StringBuilder sb = new();

            if (shoes.Any(s => s.Size == size && s.Type == type))
            {
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");
                foreach (var shoeStock in shoes.Where(s => s.Size == size && s.Type == type))
                {
                    sb.AppendLine(shoeStock.ToString());
                }
                return sb.ToString().TrimEnd();
            }

            return "No matches found!";
        }
    }
}
