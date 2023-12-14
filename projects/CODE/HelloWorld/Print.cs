namespace HelloWorld
{
    public class Print
    {
        public static void Say()
        {
            int count = 0;
            while (count >= 0)
            {
                count++;
                Console.WriteLine("Hello, World!\t" + count);
            }
        }
    }
}