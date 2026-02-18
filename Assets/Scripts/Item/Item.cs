using UnityEngine;

namespace Item
{
    [CreateAssetMenu(menuName = "FindPair/Item")]
    public sealed class Item : ScriptableObject
    {
        public int Value;
        public Sprite Sprite;
    }
}