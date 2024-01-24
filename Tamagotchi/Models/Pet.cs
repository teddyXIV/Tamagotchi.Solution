namespace Tamagotchi.Models
{
    public class Pet
    {
        public string Name { get; set; }

        private int _hunger;

        public int Hunger
        {
            get => _hunger;
            set
            {
                if (value < 0)
                {
                    _hunger = 0;
                }
                else if (value > 100)
                {
                    _hunger = 100;
                }
                else
                {
                    _hunger = value;
                }
            }

        }
        public int Attention { get; set; }
        private int _fatigue;
        public int Fatigue
        {
            get => _fatigue;
            set
            {
                if (value < 0)
                {
                    _fatigue = 0;
                }
                else if (value > 100)
                {
                    _fatigue = 100;
                }
                else
                {
                    _fatigue = value;
                }
            }
        }
        public int Happiness
        {
            get => Attention - (Hunger + Fatigue);
        }

        public bool Alive { get; set; }
        public string Cause { get; set; }

        public string Color { get; }
        public DateTime Birthday { get; }
        public DateTime LastChecked { get; set; }
        public int Id { get; }
        private static List<Pet> _instances = new() { };

        public Pet(string name, int hunger, int attention, int fatigue)
        {
            Name = name;
            Hunger = hunger;
            Attention = attention;
            Fatigue = fatigue;
            Birthday = DateTime.Now;
            LastChecked = DateTime.Now;
            Color = GetColor();
            Alive = true;
            Cause = "";
            _instances.Add(this);
            Id = _instances.Count;
        }

        public static List<Pet> GetAll()
        {
            return _instances;
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }
        public static Pet GetPetById(int id)
        {
            return _instances[id - 1];
        }
        public void Feed()
        {
            Hunger -= 10;
            Attention++;
        }
        public void Play(int amount)
        {
            Attention += amount;
        }

        public void Sleep(int amount)
        {
            Fatigue -= amount;
        }


        public static void Delete(int id)
        {
            _instances.RemoveAt(id - 1);
        }

        public void GetNeglect()
        {
            int timePassed = DateTime.Now.Minute - LastChecked.Minute;
            Hunger += timePassed;
            Attention -= timePassed;
            Fatigue += timePassed;
            if (Hunger >= 100)
            {
                Alive = false;
                Cause = $"{Name} died from hunger";
            }
            else if (Fatigue >= 100)
            {
                Alive = false;
                Cause = $"{Name} died from fatigue";
            }
            else if (Attention <= 0)
            {
                Alive = false;
                Cause = $"{Name} died out of loneliness";
            }
        }

        private static string GetColor()
        {
            var random = new Random();
            var color = string.Format("#{0:X6}", random.Next(0x1000000));
            return color;
        }
    }
}