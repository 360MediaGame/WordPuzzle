using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public TextMeshProUGUI _TimerText;          // 타이머 TMP
    public TextMeshProUGUI _AnswerViewText;     // 현재 조합 중인 단어 TMP
    public TextMeshProUGUI _AnswerCNT;
    public TextMeshProUGUI _CurQuestionIndex;

    
    public GameObject _TimeOverEffect;
    public GameObject _EndPopoup;

    public float _startTime;
    public float _readyTime;
    public float _resetTime;
    public bool _isReady = false;
    public bool _isGameEnd = false;
    private bool _isEndPopup = false;
    public bool _isStopTimer = false;
    
    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _startTime = 11f;
        _readyTime = 2f;
        _resetTime = 20f;

    }

    void Update()
    {
        if (_isGameEnd)
        {
            _resetTime -= Time.deltaTime;
            if (_resetTime < 0)
                SceneManager.LoadScene("LOBBY_SCENE");
        }    

        _readyTime -= Time.deltaTime;

        if (_readyTime < 0)
            _isReady = true;

        if (!_isReady)
            return;

        if (_isStopTimer)
            return;

        if (!_isGameEnd)
            _startTime -= Time.deltaTime;

        _TimerText.text = ((int)_startTime).ToString();

        _AnswerCNT.text = QuestionManager.Instance.AnswerCount.ToString();
        if (QuestionManager.Instance.CurQuestionIndex + 1 <= 10)
            _CurQuestionIndex.text = (QuestionManager.Instance.CurQuestionIndex + 1).ToString() + " / 10";

        if (_startTime < 0)
        {
            Debug.Log("Reset Timer!");
            _startTime = 11f;
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            RectTransform tempRect = QuestionManager.Instance.Questions[QuestionManager.Instance.CurQuestionIndex].GetComponent<RectTransform>();
            GameObject grayObj = Instantiate(QuestionManager.Instance.Questions_Gray[QuestionManager.Instance.CurQuestionIndex], gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            RectTransform grayObj_rt = grayObj.GetComponent<RectTransform>();
            grayObj_rt.localPosition = new Vector3(tempRect.localPosition.x, tempRect.localPosition.y, 0); ;
            grayObj.name = QuestionManager.Instance.Questions[QuestionManager.Instance.CurQuestionIndex].gameObject.name;
            Destroy(QuestionManager.Instance.Questions[QuestionManager.Instance.CurQuestionIndex]);
            grayObj.tag = "FAIL";
            QuestionManager.Instance.Questions[QuestionManager.Instance.CurQuestionIndex] = grayObj;
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            QuestionManager.Instance.MoveQuestion();

            GameObject TimeOver_EFF = Instantiate(_TimeOverEffect, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            TimeOver_EFF.gameObject.tag = "Effect";
            RectTransform TimeOver_EFF_rt = TimeOver_EFF.GetComponent<RectTransform>();
            TimeOver_EFF_rt.localPosition = new Vector3(0, 293, 0);

            Destroy(TimeOver_EFF, 1f);

            _isStopTimer = true;

            for (int i = 0; i < GameManager.Instance.Block.Count; ++i)
                GameManager.Instance.Block[i].GetComponent<Image>().color = Color.white;

            if (QuestionManager.Instance.CurQuestionIndex >= 9)
            {
                _isGameEnd = true;
                Invoke("PopUpEnd", 1f);
            }
        }
    }

    void PopUpEnd()
    {
        ////////////////////////////////////
        _startTime = 10.5f;
        if (!_isEndPopup)
        {
            GameObject EndPopup = Instantiate(_EndPopoup, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            RectTransform EndPopup_rt = EndPopup.GetComponent<RectTransform>();
            EndPopup_rt.localPosition = new Vector3(0, 0, 0);
            _isEndPopup = true;
        }
    }
}
