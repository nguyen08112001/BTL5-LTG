using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public abstract class Tree : MonoBehaviour
    {

        private Node _root = null;

        void Start()
        {
            Debug.Log("start");
            _root = SetupTree();
        }

        private void Update()
        {
            if (_root != null)
                _root.Evaluate();
        }

        protected abstract Node SetupTree();

    }

}
