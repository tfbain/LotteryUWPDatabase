using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryApp.Models
{
    public class Utilities
    {

        public static Boolean checkAllBalls(int to, int[] arr)
        {
            Boolean bOK = true;
            foreach (int number in arr)  // value is the numbers array being set through the object
            {
                if (!(NumberInRange(number, 1, to))) bOK = false;
            }

            if (bOK) bOK = ArrayNoDuplicates(arr);

            return bOK;
        }
        public static Boolean NumberInRange(int chosenNumber, int from, int to)
        {
            Boolean inRange = false;
            if (chosenNumber >= from && chosenNumber <= to)
                inRange = true;
            return inRange;
        }
        public static Boolean NumberNotDuplicate(int chosenNumber, int[] arr)
        {

            Boolean notDuplicate = true;

            if (arr != null && arr.Length != 0)
            {
                foreach (int number in arr)
                {
                    if (chosenNumber == number)
                    {
                        notDuplicate = false;
                    }
                }
            }
            return notDuplicate;
        }
        public static Boolean ArrayNoDuplicates(int[] arr)
        {
            Boolean notDuplicate = true;

            if (arr != null && arr.Length != 0)
            {
                var groups = arr.GroupBy(v => v);
                foreach (var group in groups)
                    if (group.Count() > 1) notDuplicate = false;
            }
            return notDuplicate;
        }

        public static int[] generateRandomBalls(int to, int[] arr)
        {
            Random rand = new Random();
            int randNo;
            for (int i = 0; i < arr.Length; i++)
            {
                do
                {
                    randNo = rand.Next(1, to) + 1;
                } while (!NumberNotDuplicate(randNo, arr));
                arr[i] = randNo;
            }
            return arr;
        }

    }
}

