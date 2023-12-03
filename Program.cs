namespace HW_03
{
	internal class Program
	{
		static void Main(string[] args)
		{
			
		}

		static void GetUserData()
		{
			(string Name, string LastName, int age) UserData;

			UserData.Name = GetUserName();

			UserData.LastName = GetUserLastName();


		}

		static string GetUserName()
		{
			while (true)
			{
				Console.WriteLine("Введите ваше имя:");
				var enteredValue = Console.ReadLine();

				if(ValidateNameOrLastName(enteredValue))
					return enteredValue;

				Console.WriteLine("Введены некорректные данные\nИмя может состоять только из букв и должно включать минимум 2 символа");
			}
		}

		static string GetUserLastName()
		{
			while (true)
			{
				Console.WriteLine("Введите вашу фамилию:");
				var enteredValue = Console.ReadLine();

				if (ValidateNameOrLastName(enteredValue))
					return enteredValue;

				Console.WriteLine("Введены некорректные данные\nФамилия может состоять только из букв и должна включать минимум 2 символа");
			}
		}

		static int GetUserAge()
		{
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

		static bool ValidateNameOrLastName(string value)
		{
			if(value == null)
				return false;

			if(value.Length <= 1)
				return false;

			foreach(var item in value)
			{
				if(!Char.IsLetter(item))
					return false;
			}

			return true;
		}
	}
}
