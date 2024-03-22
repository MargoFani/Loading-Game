using Assets.Scripts.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class MemCollectionManager : MonoBehaviour
    {
        [SerializeField] private CollectionUI collectionPrefab;
        [SerializeField] private GameObject collectionWindow;

        [SerializeField] private AllCollections allCollections;


        private List<CollectionUI> elements;
        public void Init()
        {
            
            elements = new List<CollectionUI>();

            for (int i = 0; i < allCollections.collections.Count; i++)
            {
                var newElement = Instantiate(collectionPrefab, transform);
                elements.Add(newElement);
                List<Mem> memsFromCollection = allCollections.mems.FindAll(n => n.collectionId == i);
                newElement.Init(allCollections.collections[i].name, memsFromCollection);
            }
        }

        public void OpenCollection()
        {
            Init();
            collectionWindow.SetActive(true);

        }

        public void CloseCollection()
        {            
            collectionWindow.SetActive(false);
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }


    } 
    
}
