namespace HW_03
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var UserData = GetUserData();

			ShowResults(UserData);
		}

		static (string Name, string LastName, int Age, string[] PetNames, string[] favoriteColors) GetUserData()
		{			
			var Name = GetUserName();

			var LastName = GetUserLastName();

			var Age = GetUserAge();

			var PetNames = GetPetNames();

			var FavoriteColors = GetFavoriteColors();
			
			return (Name, LastName, Age, PetNames, FavoriteColors);
		}

		static string GetUserName()
		{
			while (true)
			{
				Console.WriteLine("Введите ваше имя:");
				var enteredValue = Console.ReadLine();

				if (ValidateEnteredValue(enteredValue))
					return enteredValue;

				Console.WriteLine($"Введены некорректные данные{Environment.NewLine}Имя может состоять только из букв и должно включать минимум 2 символа");
			}
		}

		static string GetUserLastName()
		{
			Console.Clear();
			
			while (true)
			{
				Console.WriteLine("Введите вашу фамилию:");
				var enteredValue = Console.ReadLine();

				if (ValidateEnteredValue(enteredValue))
					return enteredValue;

				Console.WriteLine($"Введены некорректные данные{Environment.NewLine}Фамилия может состоять только из букв и должна включать минимум 2 символа");
			}
		}

		static int GetUserAge()
		{
			Console.Clear();

			while (true)
			{
				Console.WriteLine("Введите ваш возраст в виде числа:");

				var enteredValue = Console.ReadLine();

				if (int.TryParse(enteredValue, out var age))
				{
					if (age > 0)
					{
						return age;
					}
				}

				Console.WriteLine("Введены некорректные данные");
			}
		}
		
		static string[] GetPetNames()
		{
			Console.Clear();

			Console.WriteLine($"У вас есть питомцы?{Environment.NewLine}1 - у вас есть питомцы{Environment.NewLine}0 - у вас нет питомцев");
			var key = Console.ReadKey();
			Console.WriteLine();

			while (true)
			{
				if (key.KeyChar == '0' || key.KeyChar == '1')
					break;

				Console.WriteLine($"Введены неверные данные{Environment.NewLine}Если у вас есть питомцы, нажмите 1. Если у вас нет питомцев, нажмите 0");
				key = Console.ReadKey();
			}

			if (key.KeyChar == '0')
				return Array.Empty<string>();

			Console.WriteLine($"Сколько у вас питомцев?");
			var petsNumber = 0;

			while (true)
			{
				if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
				{ 
					petsNumber = number;
					break;
				}

				Console.WriteLine($"Введены неверные данные{Environment.NewLine}Введите число не меньше 1");
			}

			var petNames = new string[petsNumber];

			for(var  i = 0; i < petNames.Length; i++)
			{
				while (true)
				{
					Console.WriteLine($"Введите кличку питомца");
					var enteredValue = Console.ReadLine();

					if(enteredValue != null)
					{
						petNames[i] = enteredValue;
						break;
					}
				}				
			}

			return petNames;
		}

		static string[] GetFavoriteColors()
		{
			Console.Clear();

			Console.WriteLine("Сколько у вас любимых цветов?");

			var colorsNumber = 0;

			while (true)
			{
				if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
				{
					colorsNumber = number;
					break;
				}

				Console.WriteLine($"Введены неверные данные{Environment.NewLine}Введите число не меньше 1");
			}

			var FavoriteColors = new string[colorsNumber];

			for (var i = 0;i < FavoriteColors.Length; i++)
			{
				Console.WriteLine("Назовите ваш любимый цвет");

				var enteredValue = Console.ReadLine() ;

				while(true)
				{
					if (ValidateEnteredValue(enteredValue))
						break;

					Console.WriteLine($"Введено неверное значение{Environment.NewLine}Название цвета должно состоять только из букв и включать не менее двух символов");

					enteredValue = Console.ReadLine();
				}

				FavoriteColors[i] = enteredValue;
			}

			return FavoriteColors;
		}

		static void ShowResults((string Name, string LastName, int Age, string[] PetNames, string[] favoriteColors) data)
		{
			Console.Clear();

			Console.WriteLine($"Вас зовут: {data.LastName} {data.Name}");
			Console.WriteLine($"Вам {data.Age} лет(год)");

			if(data.PetNames == null || data.PetNames.Length == 0)
			{
				Console.WriteLine("У вас нет питомцев");
			}
			else
			{
				Console.WriteLine($"У вас есть питомцы:");

				foreach (var petName in data.PetNames)
				{ 
					Console.WriteLine($"{petName}"); 
				}
			}

			Console.WriteLine("Ваши люббимые цвета: ");

			foreach(var favoriteColor in data.favoriteColors)
			{
				Console.WriteLine($"{favoriteColor}");
			}
		}

		static bool ValidateEnteredValue(string value)
		{
			if (value == null)
				return false;

			if (value.Length <= 1)
				return false;

			foreach (var item in value)
			{
				if (!Char.IsLetter(item))
					return false;
			}

			return true;
		}
	}
}
