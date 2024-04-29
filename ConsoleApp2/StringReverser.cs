namespace ConsoleApp2
{
    public class StringReverser
    {
        public static void ReverseString(string[] arr)
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
