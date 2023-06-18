

namespace ClothesMagazine
{
    public class Cloth
    {
        private string color;
        private int size;
        private string type;

        public Cloth(string color, int size, string type)
        {
            Color = color;
            Size = size;
            Type = type;
        }
        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
        public int Size
        {
            get { return this.size; }
            set { this.size = value; }
        }
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public override string ToString()
        {
            return $"Product: {Type} with size {Size}, color {Color}";
        }

    }
}
