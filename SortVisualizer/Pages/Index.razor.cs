using Microsoft.AspNetCore.Components;

namespace SortVisualizer.Pages
{
	public enum Algorithms
	{ 
		BubbleSort,
		SelectionSort,
		InsertionSort,
        Quicksort,
        Mergesort,
	}

	public partial class Index : ComponentBase
	{
        private int[]? originalArray;//Do not modify this!

        //Properties for the UI
        private int Seed { get; set; } = 42;
		public int ArraySize { get; set; } = 1000;
        //--------------------------------------------


#pragma warning disable CS8618 //Suppress nullable warning
        //The array to sort
        public int[] Array { get; set; }
#pragma warning restore CS8618 

        //The algorithm to use for sorting
        public Algorithms AlgorithmToUse { get; set; } = Algorithms.BubbleSort;//Default value

        //Gets called when the user clicks the "Go!" button
        private void Sort()
        {
            //TODO
        }

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
                    AlgorithmToUse = Algorithms.BubbleSort;
                    break;
				case "selection":
					AlgorithmToUse = Algorithms.SelectionSort;
                    break;
				case "insertion":
					AlgorithmToUse = Algorithms.InsertionSort;
                    break;
                case "quicksort":
                    AlgorithmToUse = Algorithms.Quicksort;
                    break;
                case "merge":
                    AlgorithmToUse = Algorithms.Mergesort;
                    break;
			}

			Console.WriteLine($"Algorithm to run: {AlgorithmToUse}");
		}

		public void Reset()
		{ 
			Array = originalArray!.ToArray();
		}

		private void Randomize()
		{
            //Populate the array with random numbers using LINQ
            Random rand = new Random(Seed);
            Array = Enumerable.Range(0, ArraySize).Select(x => x = rand.Next(1, ArraySize)).ToArray();
            //Clone Array into originalArray
            originalArray = Array.ToArray();
        }
	}
}
