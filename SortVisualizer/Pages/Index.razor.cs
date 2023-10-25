using Microsoft.AspNetCore.Components;

namespace SortVisualizer.Pages
{
	public enum Algorithms
	{ 
		BubbleSort,
		SelectionSort,
		InsertionSort,
        QuickSort,
        MergeSort,
	}

	public partial class Index : ComponentBase
	{
		private int Seed { get; set; } = 42;
		public int ArraySize { get; set; } = 1000;
		public int[] Array { get; set; }
        private int[] originalArray;//Do not modify this!

        public Algorithms AlgorithmToRun { get; set; } = Algorithms.BubbleSort;//Default value

		//Called when the component is initialized
		protected override void OnInitialized()
		{
			Randomize();
		}

		private void ChangeAlgorithmToRun(ChangeEventArgs e)
		{
			switch (e.Value!.ToString()!)
			{
				case "bubble":
                    AlgorithmToRun = Algorithms.BubbleSort;
                    break;
				case "selection":
					AlgorithmToRun = Algorithms.SelectionSort;
                    break;
				case "insertion":
					AlgorithmToRun = Algorithms.InsertionSort;
                    break;
                case "quicksort":
                    AlgorithmToRun = Algorithms.QuickSort;
                    break;
                case "merge":
                    AlgorithmToRun = Algorithms.MergeSort;
                    break;
			}

			Console.WriteLine($"Algorithm to run: {AlgorithmToRun}");
		}

		public void Reset()
		{ 
			Array = originalArray;
		}

		private void Randomize()
		{
            //Populate the array with random numbers using LINQ
            Random rand = new Random(Seed);
            Array = Enumerable.Range(0, ArraySize).Select(x => x = rand.Next(1, ArraySize)).ToArray();
            originalArray = Array;
        }

		private void Sort()
		{ 
			//TODO
		}
	}
}
