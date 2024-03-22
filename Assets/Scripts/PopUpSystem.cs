using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class PopUpSystem : MonoBehaviour
    {
        public GameObject popUpBox;
        //public Animator animator;
        public TMP_Text popUpText;
        public EventHandler OnPopUpClose;
        public EventHandler OnPopUpFileSave;
        public void PopUp(string text)
        {
            popUpBox.SetActive(true);
            popUpText.text = text;
            //animator.SetTrigger("pop");
        }

        public void PopUp()
        {
            popUpBox.SetActive(true);
            //animator.SetTrigger("pop");
        }

        public void SaveLoadedFile()
        {
            OnPopUpFileSave?.Invoke(this, EventArgs.Empty);
            popUpBox.SetActive(false);
        }

        public void ClosePopUp()
        {
            OnPopUpClose?.Invoke(this, EventArgs.Empty);
            popUpBox.SetActive(false);
        }
    }
}
