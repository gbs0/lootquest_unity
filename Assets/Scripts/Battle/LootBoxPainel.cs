using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Battle
{
    public class LootBoxPainel: MonoBehaviour
    {
        public List<GameObject> list;

        public void Add()
        {
            list.Add(new GameObject());
        }

        public void Remove()
        {
            Destroy(list[0]);
            list.RemoveAt(0);
        }
    }
}