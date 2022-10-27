namespace OOP_LAB_4 {
    public struct CatData {
        public string Name;
        public double Age;
        public Gender Gender;
        public CatType Type;
    }
    public class Cat {
        private string name;
        public string Name { get => name; set {
                if (value == "" || value == null) {
                    throw new ArgumentException("Name cannot be empty string or null");
                }
                name = value;
            }
        }

        private double age;
        public double Age {
            get => age;
            set {
                if (value <= 0) {
                    throw new ArgumentException("Age must be greater than 0");
                }

                age = value;
            }
        }

        private static int _id = 1;
        private readonly int id;
        public int Id { get => id; }

        private Gender gender;
        public Gender Gender { get => gender; set => gender = value; }


        private CatType type;
        public CatType Type { get => type; set => type = value; }
        public Cat() : this(Utils.FillOutCat()) {}
        public Cat(CatData data) : this(data.Name, data.Age, data.Gender, data.Type) {}

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
        public Cat(string name, double age, Gender gender, CatType type) {
            Name = name ?? throw new ArgumentNullException("Name", "Name cannot be null");
            id = _id++;
            Age = age;
            Gender = gender;
            Type = type;
        }
#pragma warning restore CS8618

        public static bool IsACat(string s) {
            if (s.ToLower() == "cat") {
                Console.WriteLine("It's a cat!");
                return true;
            } else {
                Console.WriteLine("It's not a cat!");
                return false;
            }
        }

        public void Purr() {
            Console.WriteLine($"[{name}] Purr...");
        }
        public void Meow() {
            Console.WriteLine($"[{name}] Meow!");
        }
        public void Eat() {
            Eat(Utils.FoodTypeForCatQuestion());
        }

        public void Eat(FoodType foodType) {
            Console.WriteLine($"[{name}] Eating {foodType}...");
        }

        public string Repr() => $"Cat(name: {Name}, age: {Age} year(s), gender: {Gender}, type: {Type})";
        public override string ToString() => $"{Name},{Age},{(Gender.Male == gender ? 'M' : 'F')},{Type}";

        public void Deconstruct(out string name, out double age, out Gender gender, out CatType type) {
            name = this.name;
            age = this.age;
            gender = this.gender;
            type = this.type;
        }

        public static Cat Parse(String s, char sep = ',') {
            // Format: name (string), age (double), gender (M/F), type (string)

            // Split string by separator
            string[] parts = s.Split(sep);
            // Check if there are 4 parts
            if (parts.Length != 4) {
                throw new ArgumentException("String must contain 4 parts");
            }
            // Construct CatData
            CatData data = new CatData();
            data.Name = parts[0];
            data.Age = double.Parse(parts[1]);
            data.Gender = parts[2].ToLower() == "m" ? Gender.Male : Gender.Female;
            // Check if type is valid
            if (int.TryParse(parts[3], out _) || !Enum.TryParse(parts[3], out data.Type)) {
                throw new ArgumentException("Invalid cat type");
            }
            // Construct Cat
            return new Cat(data);
        }

        public static bool TryParse(String s, out Cat? cat, char sep = ',') {
            try {
                cat = Parse(s, sep);
                return true;
            } catch (Exception) {
                cat = null;
                return false;
            }
        }
    }
}