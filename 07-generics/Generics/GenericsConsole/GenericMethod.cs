using System;

namespace GenericsConsole
{
	public class GenericMethod
	{
		static T[] Insert<T>(T[] arr, int index, T element)
		{
			T[] result = new T[arr.Length + 1];

			Array.Copy(arr, result, index);
			result[index] = element;
			Array.Copy(arr, index, result, index + 1, arr.Length - index);

			return result;
		}

		// задача посложнее - сделать этот метод обощенным
		static void Sort<T>(T[] arr) where T : IComparable<T>
		{
			for (int write = 0; write < arr.Length; write++)
			{
				for (int sort = 0; sort < arr.Length - 1; sort++)
				{
					//if (arr[sort] > arr[sort + 1])
					if (arr[sort].CompareTo(arr[sort + 1]) > 0)
					{
						T temp = arr[sort + 1];
						arr[sort + 1] = arr[sort];
						arr[sort] = temp;
					}
				}
			}
		}

		private static void PrintArray<T>(T[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				Console.Write(arr[i] + "\t");
			}
		}

		public static void Demo(string[] args)
		{
			int[] arr = { 800, 11, 50, 771, 649, 770, 240, 9 };

			Sort(arr);
			//PrintArray<int>(arr);

			double[] arrDouble = { 45.5, 1.51, 89.50, 7.71, 64.9, 7.77, 4.89, 9.47 };
			Sort(arrDouble);
			//PrintArray<double>(arrDouble);

			User[] users = new User[]
			{
				new User(18), new User(44),
				new User(32), new User(47)
			};
			Sort<User>(users);
			PrintArray(users);

			Console.ReadKey();
		}
	}

	public class User : IComparable<User>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		int _age;
		public int Age { get { return _age; } }

		public User(int age)
		{
			_age = age;
		}

		public User()
		{
			_age = 18;
		}

		public int CompareTo(User other)
		{
			return this.Age - other.Age;
		}

		public override string ToString()
		{
			return "Useg age: " + this.Age;
		}
	}
}
