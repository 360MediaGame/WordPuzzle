using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class KeyBoardManager : MonoBehaviour
{
    TextMeshProUGUI _text;           
    public Canvas _canvas;           
    GraphicRaycaster m_gr;
    PointerEventData m_ped;

    int AncorX;
    int AncorY;

    int CurX;
    int CurY;

    int Cursormovepos;

    bool BlockInitTrigger = false;

    void Start()
    {
        m_gr = _canvas.GetComponent<GraphicRaycaster>();
        m_ped = new PointerEventData(null);
    }

    void Update()
    {
        // skrr~
        if (Input.GetMouseButtonUp(0))
            InitBlockColor();

        // UI 레이캐스트
        m_ped.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        m_gr.Raycast(m_ped, results);

        if (results.Count > 0)
        {
            if (results[0].gameObject.tag != "KeyBoard")
                return;

            if (Input.GetMouseButtonDown(0))
            {
                AncorX = (int)results[0].gameObject.GetComponent<RectTransform>().position.x;
                AncorY = (int)results[0].gameObject.GetComponent<RectTransform>().position.y;

                // 임시SIBBAL
                for (int i = 0; i < GameManager.Instance.Block.Count; ++i)
                {
                    if (GameManager.Instance.Block[i].gameObject.name == results[0].gameObject.name)
                        GameManager.Instance.Block[i].GetComponent<Image>().color = Color.red;
                }
            }

            if (Input.GetMouseButton(0))
            {
                CurX = (int)results[0].gameObject.GetComponent<RectTransform>().position.x;
                CurY = (int)results[0].gameObject.GetComponent<RectTransform>().position.y;
                
                int XValue = Mathf.Abs(CurX - AncorX);
                int YValue = Mathf.Abs(CurY - AncorY);

                // 가로
                if (XValue > YValue)
                {
                   
                    if (!BlockInitTrigger)
                        InitBlockColor();
                    BlockInitTrigger = true;

                    if (CurX > AncorX)  // 커서가 기준보다 오른쪽
                    {
                        for (int i = 0; i < GameManager.Instance.Block.Count; ++i)
                        {
                            if ((int)GameManager.Instance.Block[i].gameObject.GetComponent<RectTransform>().position.y == AncorY)
                            {
                                if ((int)GameManager.Instance.Block[i].gameObject.GetComponent<RectTransform>().position.x >= AncorX &&
                                    (int)GameManager.Instance.Block[i].gameObject.GetComponent<RectTransform>().position.x <= CurX)
                                {
                                    GameManager.Instance.Block[i].GetComponent<Image>().color = Color.red;

                                    
                                }
                                else
                                {
                                    GameManager.Instance.Block[i].GetComponent<Image>().color = Color.white;
                                }
                            }
                        }
                    }
                    else if (CurX < AncorX)
                    {
                        for (int i = 0; i < GameManager.Instance.Block.Count; ++i)
                        {
                            if ((int)GameManager.Instance.Block[i].gameObject.GetComponent<RectTransform>().position.y == AncorY)
                            {
                                if ((int)GameManager.Instance.Block[i].gameObject.GetComponent<RectTransform>().position.x <= AncorX &&
                                    (int)GameManager.Instance.Block[i].gameObject.GetComponent<RectTransform>().position.x >= CurX)
                                {
                                    GameManager.Instance.Block[i].GetComponent<Image>().color = Color.red;
                                }
                                else
                                {
                                    GameManager.Instance.Block[i].GetComponent<Image>().color = Color.white;
                                }
                            }
                        }
                    }

                    if (Cursormovepos != CurX)
                        GameManager.Instance.UpdateWord();
                    Cursormovepos = CurX;
                }
                // 세로
                else
                {
                    if (BlockInitTrigger)
                        InitBlockColor();
                    BlockInitTrigger = false;

                    if (CurY > AncorY)  // 커서가 기준보다 위쪽
                    {
                        for (int i = 0; i < GameManager.Instance.Block.Count; ++i)
                        {
                            if ((int)GameManager.Instance.Block[i].gameObject.GetComponent<RectTransform>().position.x == AncorX)
                            {
                                if ((int)GameManager.Instance.Block[i].gameObject.GetComponent<RectTransform>().position.y >= AncorY &&
                                    (int)GameManager.Instance.Block[i].gameObject.GetComponent<RectTransform>().position.y <= CurY)
                                {
                                    GameManager.Instance.Block[i].GetComponent<Image>().color = Color.red;
                                }
                                else
                                {
                                    GameManager.Instance.Block[i].GetComponent<Image>().color = Color.white;
                                }
                            }
                        }
                    }
                    else if (CurY < AncorY)
                    {
                        for (int i = 0; i < GameManager.Instance.Block.Count; ++i)
                        {
                            if ((int)GameManager.Instance.Block[i].gameObject.GetComponent<RectTransform>().position.x == AncorX)
                            {
                                if ((int)GameManager.Instance.Block[i].gameObject.GetComponent<RectTransform>().position.y <= AncorY &&
                                    (int)GameManager.Instance.Block[i].gameObject.GetComponent<RectTransform>().position.y >= CurY)
                                {
                                    GameManager.Instance.Block[i].GetComponent<Image>().color = Color.red;
                                }
                                else
                                {
                                    GameManager.Instance.Block[i].GetComponent<Image>().color = Color.white;
                                }
                            }
                        }
                    }

                    if (Cursormovepos != CurY)
                        GameManager.Instance.UpdateWord();
                    Cursormovepos = CurY;
                }
            }
        }
    }

    void InitBlockColor()
    {
        for (int i = 0; i < GameManager.Instance.Block.Count; ++i)
        {
            GameManager.Instance.Block[i].GetComponent<Image>().color = Color.white;
            GameManager.Instance.CombineWord = "";
            UIManager.Instance._AnswerViewText.text = "";
        }
    }
}
