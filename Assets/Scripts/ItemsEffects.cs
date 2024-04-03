using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{

    public class ItemsEffects
    {
        private Arrow speedometrArrow;

        public ItemsEffects(Arrow speedometrArrow)
        {
            this.speedometrArrow = speedometrArrow;
        }
        public void InvokeMethod(string name)
        {
            var method = GetType().GetMethod(name);
            method?.Invoke(this, null);
        }
        #region Srewdriver
        public void SrewdriverGoodEffectOn()
        {
            // new ShopItem(100, "отвертка", "у соседа отклюился интернет, тебе досталось больше. скорость загрузки увеличена в 1,5 раза. пока сосед не опомнился.", -1),
            //TargetSpeedOfLoading + 20 
            speedometrArrow.IncreaseAngle(speedometrArrow.GetTargetAngle() * 1.5f);
        }
        public void SrewdriverGoodEffectOff()
        {
            // new ShopItem(100, "отвертка", "у соседа отклюился интернет, тебе досталось больше. скорость загрузки увеличена на 15 Mb. пока сосед не опомнился.", -1),
            //ничего не надо

        }
        public void SrewdriverBadEffectOn()
        {
            //не надо ченить чего не знаешь. что-то сломалось. жди минуту.
            speedometrArrow.IncreaseAngle(speedometrArrow.GetTargetAngle() * 1.5f);
        }
        public void SrewdriverBadEffectOff()
        {

        }
        #endregion
        #region Coffe
        public void CoffeGoodEffectOn()
        {
            //new ShopItem(350, "кофе", "тут всё просто, кофе = энергия. эффект от кликов увеличен в 2 раза на 30 секунд.", 30)
            //SpeedUpAngle * 2 на 30 секунд
            speedometrArrow.SpeedUpAngle = speedometrArrow.SpeedUpAngle * 2;
        }
        public void CoffeGoodEffectOff()
        {
            //SpeedUpAngle/2
            speedometrArrow.SpeedUpAngle = speedometrArrow.SpeedUpAngle / 2;
        }
        public void CoffeBadEffectOn()
        {
            //что-то плохое про кофе
            speedometrArrow.SpeedUpAngle = speedometrArrow.SpeedUpAngle * 2;
        }
        public void CoffeBadEffectOff()
        {
            speedometrArrow.SpeedUpAngle = speedometrArrow.SpeedUpAngle / 2;
        }
        #endregion
        #region Bag
        public void BagGoodEffectOn()
        {
            //new ShopItem(120, "чемодан", "все домачадцы уехали в отпуск, никто больше не ворует ваш интернет. скорость загрузки увеличена на 10 Mb и не уменьшается в течение 30 секунд.", 30),
            //CanDecrise = false на 30 секунд and TargetSpeedOfLoading + 15 
            speedometrArrow.IncreaseAngle(30);
            speedometrArrow.CanDecrise = false;
        }
        public void BagGoodEffectOff()
        {
            speedometrArrow.CanDecrise = true;
        }
        public void BagBadEffectOn()
        {
            //что-то плохое про чемодан
            speedometrArrow.IncreaseAngle(30);
            speedometrArrow.CanDecrise = false;
        }
        public void BagBadEffectOff()
        {
            speedometrArrow.CanDecrise = true;
        }
        #endregion
        #region GlassOfVine
        public void GlassOfVineEffectOn()
        {
            //new ShopItem(440, "бокал вина", "время - дело относительное. скорость НЕ поднимется выше 10 Mb/c в течение 30 секунд.", 30),
            //запретить клики 
            speedometrArrow.CanClick = false;
        }
        public void GlassOfVineEffectOff()
        {
            speedometrArrow.CanClick = true;
        }
        #endregion
        #region Nail
        public void NailEffectOn()
        {
            //new ShopItem(110, "гвоздь", "забил и скорость стабилизировалась. скорость не будет падать в течение 30 секунд.", 30)
            //CanDecrise = false на 30 секунд
            speedometrArrow.CanDecrise = false;
        }
        public void NailEffectOff()
        {
            speedometrArrow.CanDecrise = true;
        }
        #endregion
    }
}
