using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public TextMeshProUGUI _TimerText;          // Ÿ�̸� TMP
    public TextMeshProUGUI _AnswerViewText;     // ���� ���� ���� �ܾ� TMP

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
