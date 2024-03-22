using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Collections
{
    public class AllCollections : MonoBehaviour
    {
        [SerializeField] public List<Mem> mems = new List<Mem>();
        [SerializeField] public List<Collection> collections = new List<Collection>();

        public void Init()
        {
            //здесь инициаия всех коллекций
            collections.Add(new Collection("первая", 0));
            collections.Add(new Collection("вторая", 1));
            collections.Add(new Collection("третья", 2));
            collections.Add(new Collection("четвертая", 3));
            collections.Add(new Collection("пятая", 4));

            //здесь инициаия всех мемов


            mems.Add(new Mem(0, Rarity.Common, 0));
            mems.Add(new Mem(1, Rarity.Uncommon, 0, true));
            mems.Add(new Mem(2, Rarity.Rare, 0));
            mems.Add(new Mem(3, Rarity.Epic, 0));
            mems.Add(new Mem(4, Rarity.Legendary, 0));

            mems.Add(new Mem(5, Rarity.Common, 1, true));
            mems.Add(new Mem(6, Rarity.Uncommon, 1));
            mems.Add(new Mem(7, Rarity.Rare, 1));
            mems.Add(new Mem(8, Rarity.Epic, 1));
            mems.Add(new Mem(9, Rarity.Legendary, 1, true));

            mems.Add(new Mem(10, Rarity.Common, 2));
            mems.Add(new Mem(11, Rarity.Uncommon, 2, true));
            mems.Add(new Mem(12, Rarity.Rare, 2));
            mems.Add(new Mem(13, Rarity.Epic, 2));
            mems.Add(new Mem(14, Rarity.Legendary, 2));

            mems.Add(new Mem(15, Rarity.Common, 3));
            mems.Add(new Mem(16, Rarity.Uncommon, 3));
            mems.Add(new Mem(17, Rarity.Rare,3, true));
            mems.Add(new Mem(18, Rarity.Epic, 3));
            mems.Add(new Mem(19, Rarity.Legendary, 3));

            mems.Add(new Mem(20, Rarity.Common, 4));
            mems.Add(new Mem(21, Rarity.Uncommon, 4));
            mems.Add(new Mem(22, Rarity.Rare, 4, true));
            mems.Add(new Mem(23, Rarity.Epic, 4, true));
            mems.Add(new Mem(24, Rarity.Legendary, 4));

            //скорей всего придется как-то это переделать под что-то более масштабируемое
        }
        
        
    }
}
