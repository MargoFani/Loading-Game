using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Collections
{
    public class CollectionUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text collectionName;
        [SerializeField] private HorizontalLayoutGroup memsGroup;
        [SerializeField] private CollectionElementUi elementPrefab;
        [SerializeField] private Sprite basicImage;

        [SerializeField] public Sprite[] memsSprites;

        private List<CollectionElementUi> elements;
        public void Init(string name, List<Mem> mems)
        {
            elements = new List<CollectionElementUi>();
            
            collectionName.text = name;

            for (int i = 0; i < mems.Count; i++)
            {
                var newElement = Instantiate(elementPrefab, transform);
                newElement.transform.parent = memsGroup.transform;
                elements.Add(newElement);
                if (mems[i].isSaved)
                {
                    newElement.Init(memsSprites[mems[i].id]);
                }
                else
                {
                    newElement.Init(basicImage);
                }

            }
        }
    }
}
