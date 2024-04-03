using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "New ShopItemEffectData", menuName = "Shop Item Effect Data", order = 10)]
    public class ShopItemEffectData : ScriptableObject
    {
        [SerializeField]
        private string _description;
        public string Description => _description;
        [SerializeField]
        private string _onBuyItemEffect;
        public string OnBuyItemEffect => _onBuyItemEffect;

        [SerializeField]
        private string _onEndDurationItemEffect;
        public string OnEndDurationItemEffect => _onEndDurationItemEffect;
        [SerializeField]
        private int _duration;
        public int Duration => _duration;

        public ShopItemEffectData(string description, string onBuyItemEffect, string onEndDurationItemEffect, int duration)
        {
            _description = description;
            _onBuyItemEffect = onBuyItemEffect;
            _onEndDurationItemEffect = onEndDurationItemEffect;
            _duration = duration;
        }
    }
}
