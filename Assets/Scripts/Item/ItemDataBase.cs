using UnityEngine;

namespace Item
{
    public static class ItemDataBase
    {
        public static Item[] Items { get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialise()
            => Items = Resources.LoadAll<Item>("Items/");
    }
}