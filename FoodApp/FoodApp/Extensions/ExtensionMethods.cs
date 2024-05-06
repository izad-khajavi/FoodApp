namespace FoodApp.Extensions
{
    public static class ExtensionMethods
    {

        public static T CreateNewObject<T>(this ICollection<T> collection, params object[]  parameters) where T : new()
        {
            return new T();
        }


    }
}
