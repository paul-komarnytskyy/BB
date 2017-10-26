namespace BB.Core
{
    public class DbInitializer
    {
        public static void Initialize(BBEntities context)
        {
            context.Database.CreateIfNotExists();
        }
    }
}
