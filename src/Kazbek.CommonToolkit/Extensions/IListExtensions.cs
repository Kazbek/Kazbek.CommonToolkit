namespace Kazbek.CommonToolkit.Extensions;

public static class IListExtensions
{
    public static void Shuffle<T>(this IList<T> list, Random? random = null)
    {
        random ??= Random.Shared;
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
