namespace GenericsConsole
{
	public static class InheritanceConstraint
	{
		static TBase[] ConvertToBase<TBase, TChild>(TChild[] childArray) where TChild : TBase
		{
			TBase[] baseArray = new TBase[childArray.Length];

			for (int i = 0; i < childArray.Length; i++)
			{
				baseArray[i] = (TBase) childArray[i];
			}

			return baseArray;
		}


		static Figure[] ConvertToBase<TBase, TChild>(Circle[] childArray) 
		{
			Figure[] baseArray = new Figure[childArray.Length];

			for (int i = 0; i < childArray.Length; i++)
			{
				baseArray[i] = (Figure) childArray[i];
			}

			return baseArray;
		}

		public static void Demo()
		{
			Circle[] circles = {new Circle(), new Circle()}; 
			Figure[] figures = ConvertToBase<Figure, Circle>(circles);

			Ring[] rings = { new Ring(), new Ring() };
			figures = ConvertToBase<Figure, Ring>(rings);
		}
	}



	class Figure
	{

	}

	class Circle : Figure
	{

	}

	class Ring : Circle
	{

	}
}
