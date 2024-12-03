namespace GymTestDL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new GymTestContext())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Console.WriteLine("Database is opnieuw aangemaakt");
        }
        }
    }
}
