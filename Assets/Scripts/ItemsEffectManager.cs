using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ItemsEffectManager : MonoBehaviour
    {
        private float timer = 0f;
        [SerializeField] private Text timerText;
        [SerializeField] private Arrow speedometrArrow;
        [SerializeField] private Image effectImage;
        [SerializeField] private Text effectDescription;

        public bool IsEffectActive = false;
        private ShopItemEffectData activeEffect;
        private ItemsEffects itemsEffects;
        public void Start()
        {
            itemsEffects = new ItemsEffects(speedometrArrow);
            effectImage.enabled = false;
            effectDescription.enabled = false;
            timerText.enabled = false;
        }
        private void Update()
        {
            if (timerText.enabled)
            {
                timer -= Time.deltaTime;
                timerText.text = $"{timer:F1}";

                if (timer <= 0)
                {
                    effectImage.enabled = false;
                    effectDescription.enabled = false;
                    timerText.enabled = false;
                    IsEffectActive = false;
                    StopEffect(activeEffect);
                    activeEffect = null;
                }

            }
        }
        public void SetEffectInfo(Sprite effectIcon, string description)
        {
            effectImage.enabled = true;
            effectDescription.enabled = true;
            effectImage.sprite = effectIcon;
            effectImage.SetNativeSize();
            effectDescription.text = description;

        }
        public void StartEffect(ShopItemEffectData effect)
        {
            Debug.Log("Start Effect");
            itemsEffects.InvokeMethod(effect.OnBuyItemEffect);
            StartEffectTimer(effect);
        }

        public void StartEffectTimer(ShopItemEffectData activeEffect)
        {
            Debug.Log("StartEffectTimer of Item: " + activeEffect);
            timerText.enabled = true;
            timer = activeEffect.Duration;
            this.activeEffect = activeEffect;
            IsEffectActive = true;
        }

        public void StopEffect(ShopItemEffectData effect)
        {
            Debug.Log("Stop Effect");
            itemsEffects.InvokeMethod(effect.OnEndDurationItemEffect);
        }
    }
}
