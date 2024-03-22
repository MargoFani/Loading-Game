using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Collections
{
    public class CollectionElementUi : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public void Init(Sprite image)
        {
            if (image)
                _image.sprite = image;
        }

        public void OnMouseUp()
        {
            //показать мем поближе
        }
    }
}
