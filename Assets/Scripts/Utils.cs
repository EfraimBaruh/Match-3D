using UnityEngine;

namespace DefaultNamespace
{
    public static class Utils
    {
        public static int GetRandomDrop()
        {
            return Random.Range(0, System.Enum.GetValues(typeof(DropType)).Length);
        }
    }
}