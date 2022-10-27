namespace OOP_LAB_4 {
    public static class Utils {
        public static string Capitalize(string str) => 
            str.Length switch {
                0 => str,
                1 => char.ToUpper(str[0]).ToString(),
                _ => char.ToUpper(str[0]) + str[1..],
        };
        
        public static CatData FillOutCat() {
            string? input;

            // Name
            while (true) {
                Console.Write("Cat name: ");
                input = Console.ReadLine();
                if (input != null) { break; }
            }
            string catName = Utils.Capitalize(input.Trim());

            // Age
            while (true) {
                Console.Write("Cat age (in years): ");
                input = Console.ReadLine();
                if (Double.TryParse(input, out double tmp) && tmp > 0) { break; }
            }
            double catAge = double.Parse(input);

            // Gender
            while (true) {
                Console.Write("Cat gender (M or F): ");
                input = Console.ReadLine();
                if (input != null) {
                    input = input.Trim().ToLower();
                    if (input == "f" || input == "m") { break; }
                }
            }
            Gender catGender = (input == "m") ? Gender.Male : Gender.Female;

            // Type
            while (true) {
                Console.Write("Cat type (British, Jellie, Persian, Ragdoll, Siamese, Tabby, Tuxedo): ");
                input = Console.ReadLine();
                if (input != null) {
                    // Do not allow typing in numbers
                    if (int.TryParse(input, out _)) { continue; }
                    input = Utils.Capitalize(input.Trim());
                    if (Enum.TryParse(typeof(CatType), input, true, out _)) { break; }
                }
            }
            CatType catType = (CatType)Enum.Parse(typeof(CatType), input);

            return new CatData { Name = catName, Age = catAge, Gender = catGender, Type = catType };
        }

        // At this point I gave up trying to make good names for functions
        // (Or to code this properly lol)
        public static FoodType FoodTypeForCatQuestion() {
            string? input;

            while (true) {
                Console.Write("Food type (Fish, Meat): ");
                input = Console.ReadLine();
                if (input != null) {
                    // Do not allow typing in numbers
                    if (int.TryParse(input, out _)) { continue; }
                    input = Utils.Capitalize(input.Trim());
                    if (Enum.TryParse(typeof(FoodType), input, true, out _)) { break; }
                }
            }
            return (FoodType)Enum.Parse(typeof(FoodType), input);
        }
    }
}