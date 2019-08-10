using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace dev.kemomimi.crossController
{
    public class CrossController : MonoBehaviour
    {
        public void OnStartDrag()
        {
            Debug.Log("Start drag");
        }

        public void OnEndDrag()
        {
            Debug.Log("End drag");
        }
    }
}