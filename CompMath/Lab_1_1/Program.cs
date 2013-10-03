using Library.Set;
namespace Lab_1_1
{
	class Program
	{
		static void Main(string[] args)
		{
			Lab_1_1_Set setOne = new Lab_1_1_Set();
			Lab_1_1_Set setTwo = new Lab_1_1_Set();

			setOne.Operation(setTwo);
		}
	}

	public class Lab_1_1_Set : Set<int>
	{
		public override void Operation(Set<int> externalSet)
		{
			base.Operation(externalSet);
		}

		public override void Sort()
		{
			base.Sort();
		}
	}
}