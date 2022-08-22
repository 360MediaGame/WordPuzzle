using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public TextMeshProUGUI _TimerText;          // Ÿ�̸� TMP
    public TextMeshProUGUI _AnswerViewText;     // ���� ���� ���� �ܾ� TMP
    public TextMeshProUGUI _AnswerCNT;
    public TextMeshProUGUI _CurQuestionIndex;

    public GameObject _TimeOverEffect;
    public GameObject _EndPopoup;

    public float _startTime;

    private bool _isEndPopup = false;

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
    }

    void Update()
    {
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

            ////////////////////////////////////
            if (QuestionManager.Instance.CurQuestionIndex >= 9)
            {
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
    }
}
