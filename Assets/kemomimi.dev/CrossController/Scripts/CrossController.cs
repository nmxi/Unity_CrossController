using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace dev.kemomimi.crossController
{
    public class CrossController : MonoBehaviour
    {
        [SerializeField] private GameObject _circleImageObj;    //まるぽつオブジェクト
        [SerializeField] private GameObject _crossControllerBackgroundImageObj; //背景イメージオブジェクト

        [SerializeField, Space(15f)] public Vector2 RawValue;
        [SerializeField] public Vector2 NormalizedValue;

        private Rect rangeOfMovement;    //まるぽつの可動範囲

        private void OnEnable()
        {
            var rt = _crossControllerBackgroundImageObj.GetComponent<RectTransform>();

            rangeOfMovement = new Rect(rt.anchoredPosition.x, rt.anchoredPosition.y, rt.sizeDelta.x, rt.sizeDelta.y);
            //Debug.Log(rangeOfMovement);
        }

        public void OnDrag()
        {
            //Debug.Log("drag");

            var m_pos = Input.mousePosition;

            var circle_rt = _circleImageObj.GetComponent<RectTransform>();

            if (m_pos.x < rangeOfMovement.x && m_pos.y < rangeOfMovement.y)  //左下
            {
                //Debug.Log("左下");

                circle_rt.position = new Vector2(rangeOfMovement.x, rangeOfMovement.y);
            }
            else if(m_pos.x > rangeOfMovement.x + rangeOfMovement.width && m_pos.y > rangeOfMovement.y + rangeOfMovement.height)   //右上
            {
                //Debug.Log("右上");

                circle_rt.position = new Vector2(rangeOfMovement.x + rangeOfMovement.width, rangeOfMovement.y + rangeOfMovement.height);
            }
            else if(m_pos.x < rangeOfMovement.x && m_pos.y > rangeOfMovement.y + rangeOfMovement.height)   //左上
            {
                //Debug.Log("左上");

                circle_rt.position = new Vector2(rangeOfMovement.x, rangeOfMovement.y + rangeOfMovement.height);
            }
            else if(m_pos.x > rangeOfMovement.x + rangeOfMovement.width && m_pos.y < rangeOfMovement.y)    //右下
            {
                //Debug.Log("右下");

                circle_rt.position = new Vector2(rangeOfMovement.x + rangeOfMovement.width, rangeOfMovement.y);
            }
            else if(m_pos.x < rangeOfMovement.x)    //左
            {
                //Debug.Log("左");

                circle_rt.position = new Vector2(rangeOfMovement.x, m_pos.y);
            }
            else if(m_pos.x > rangeOfMovement.x + rangeOfMovement.width)    //右
            {
                //Debug.Log("右");

                circle_rt.position = new Vector2(rangeOfMovement.x + rangeOfMovement.width, m_pos.y);
            }
            else if(m_pos.y < rangeOfMovement.y)   //下
            {
                //Debug.Log("下");

                circle_rt.position = new Vector2(m_pos.x, rangeOfMovement.y);
            }
            else if (m_pos.y > rangeOfMovement.y + rangeOfMovement.height)  //上
            {
                //Debug.Log("上");

                circle_rt.position = new Vector2(m_pos.x, rangeOfMovement.y + rangeOfMovement.height);
            }
            else
            {
                circle_rt.position = m_pos;
            }

            var bg_rt = _crossControllerBackgroundImageObj.GetComponent<RectTransform>();
            var x = circle_rt.anchoredPosition.x / (bg_rt.sizeDelta.x / 2);
            var y = circle_rt.anchoredPosition.y / (bg_rt.sizeDelta.y / 2);

            x = (float)(Math.Truncate(x * 100.0) / 100.0);
            y = (float)(Math.Truncate(y * 100.0) / 100.0);

            var v = new Vector2(x, y);
            RawValue = v;
            NormalizedValue = RawValue / 2 + new Vector2(0.5f, 0.5f);
        }
    }
}