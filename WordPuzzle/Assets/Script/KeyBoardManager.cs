using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class KeyBoardManager : MonoBehaviour
{
    // Sound
    public AudioClip audioPass;
    public AudioClip audioFail;
    public AudioClip audioClick;
    public AudioClip audioEndPopup;
    AudioSource audioSource;

    public GameObject O_Effect;
    public GameObject _EndPopoup;

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

    void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        m_gr = _canvas.GetComponent<GraphicRaycaster>();
        m_ped = new PointerEventData(null);
    }

    void Update()
    {
        if (!UIManager.Instance._isReady)
            return;
        // skrr~
        if (Input.GetMouseButtonUp(0))
        {
            if (string.Compare((string)QuestionManager.Instance.Questions[QuestionManager.Instance.CurQuestionIndex].gameObject.name, GameManager.Instance.CombineWord) == 0)
            {
                if (GameObject.FindWithTag("Effect"))
                {
                    Debug.Log("막음");
                    InitBlockColor();
                    return;
                }
                // sound
                audioSource.clip = audioPass;
                audioSource.Play();

                QuestionManager.Instance.Questions[QuestionManager.Instance.CurQuestionIndex].gameObject.tag = "PASS";

                QuestionManager.Instance.AnswerCount += 1;
                UIManager.Instance._startTime = 11;
                QuestionManager.Instance.MoveQuestion();

                GameObject O_EFF = Instantiate(O_Effect, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
                O_EFF.gameObject.tag = "Effect";
                RectTransform O_EFF_rt = O_EFF.GetComponent<RectTransform>();
                O_EFF_rt.localPosition = new Vector3(0, 293, 0);

                Destroy(O_EFF, 1f);

                if (QuestionManager.Instance.CurQuestionIndex >= 9)
                {
                    UIManager.Instance._isGameEnd = true;
                    Invoke("PopUpEnd", 1f);
                }
                InitBlockColor2();
            }
            else
            {
                // sound
                audioSource.clip = audioFail;
                audioSource.Play();

                InitBlockColor();               
            }
        }

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

                for (int i = 0; i < GameManager.Instance.Block.Count; ++i)
                {
                    // sound
                    audioSource.clip = audioClick;
                    audioSource.Play();

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

    void PopUpEnd()
    {
        ////////////////////////////////////
        // sound
        audioSource.clip = audioEndPopup;
        audioSource.Play();

        GameObject EndPopup = Instantiate(_EndPopoup, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        RectTransform EndPopup_rt = EndPopup.GetComponent<RectTransform>();
        EndPopup_rt.localPosition = new Vector3(0, 0, 0);
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
    void InitBlockColor2()
    {
        for (int i = 0; i < GameManager.Instance.Block.Count; ++i)
        {
            GameManager.Instance.Block[i].GetComponent<Image>().color = Color.white;
            GameManager.Instance.CombineWord = "";
            //UIManager.Instance._AnswerViewText.text = "";
        }
    }
}
