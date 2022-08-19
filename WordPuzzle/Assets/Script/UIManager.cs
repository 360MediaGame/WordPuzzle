using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public TextMeshProUGUI _TimerText;          // 타이머 TMP
    public TextMeshProUGUI _AnswerViewText;     // 현재 조합 중인 단어 TMP

    public float _startTime;

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

        if (_startTime < 0)
        {
            Debug.Log("Reset Timer!");
            _startTime = 11f;
        }
    }
}
