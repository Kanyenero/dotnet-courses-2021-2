namespace GenericsConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			User[] arr = Generate<User>(10);
			string[] arr1 = Generate<string>(10);
			//int[] arr1 = Generate<int>(10);
		}

		static T[] Generate<T>(int count) where T : class
		{
			T[] arr = new T[count];

			for (int i = 0; i < count; i++)
			{
				arr[i] = default(T);
			}

			return arr;
		}
	}
}
