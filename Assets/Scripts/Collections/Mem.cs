using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Collections
{
    public class Mem :MonoBehaviour
    {
        public int id;
        public Sprite image;
        public Rarity rarity;
        public int collectionId;
        public bool isSaved;

        public Mem(int id, Rarity rarity, int collectionId)
        {
            this.id = id;
            this.rarity = rarity;
            this.collectionId = collectionId;
            isSaved = false;
        }

        public Mem(int id, Rarity rarity, int collectionId, bool isSaved)
        {
            this.id = id;
            this.rarity = rarity;
            this.collectionId = collectionId;
            this.isSaved = isSaved;
        }

        public void SetSprite(Sprite sprite)
        {
            sprite = image;
        }
    }

    public enum Rarity
    {
        Common,
        Uncommon,
        Rare, 
        Epic,
        Legendary
    }
}
