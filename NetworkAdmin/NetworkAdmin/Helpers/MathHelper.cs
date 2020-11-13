using System.Linq;

namespace NetworkAdmin.Helpers
{
    public static class MathHelper
    {
        public static int Pow(int bas, int exp)
        {
            return Enumerable.Repeat(bas, exp).Aggregate(1, (a, b) => a * b);
        }
    }
}