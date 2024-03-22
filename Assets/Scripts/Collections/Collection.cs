using Assets.Scripts.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Collection
    {
        public string name;
        public int id;

        public Collection(string name, int id)
        {
            this.id = id;
            this.name = name;
        }
    }
}
