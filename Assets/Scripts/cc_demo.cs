using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace dev.kemomimi.crossController
{
    public class cc_demo : MonoBehaviour
    {
        [SerializeField] private Text _targetText;
        [SerializeField] private CrossController _referenceCC;

        void Update()
        {
            _targetText.text = "Raw : " + _referenceCC.RawValue.ToString() + "\n\nNormalize : " + _referenceCC.NormalizedValue.ToString();
        }
    }
}