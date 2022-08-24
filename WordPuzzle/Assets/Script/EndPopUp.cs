using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndPopUp : MonoBehaviour
{
    public TextMeshProUGUI _AnswerCNT;
    public GameObject EndScript;

    public GameObject Popup1;
    public GameObject Popup2;
    public GameObject Popup3;
    public GameObject Popup4;
    public GameObject Popup5;
    public GameObject Popup6;
    public GameObject Popup7;
    public GameObject Popup8;
    public GameObject Popup9;
    public GameObject Popup10;

    public TextMeshProUGUI _text;

    GameObject endImage;
    RectTransform endImage_rt;

    GameObject endScript;
    RectTransform endScript_rt;

    void Start()
    {
        _AnswerCNT.text = QuestionManager.Instance.AnswerCount.ToString() + "개";

        endImage = Instantiate(QuestionManager.Instance.Questions[0], gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        endImage_rt = endImage.GetComponent<RectTransform>();
        endImage_rt.localPosition = new Vector3(Popup1.gameObject.GetComponent<RectTransform>().localPosition.x, Popup1.gameObject.GetComponent<RectTransform>().localPosition.y + 20, 0);
        endImage_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 150);
        endImage_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 150);       

        if (QuestionManager.Instance.Questions[0].gameObject.tag == "PASS")
        {
            endScript = Instantiate(EndScript, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            _text = endScript.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            endScript_rt = endScript.GetComponent<RectTransform>();
            endScript_rt.localPosition = new Vector3(Popup1.gameObject.GetComponent<RectTransform>().localPosition.x, Popup1.gameObject.GetComponent<RectTransform>().localPosition.y - 30, 0);
            _text.text = "정답\n" + QuestionManager.Instance.Questions[0].gameObject.name;
        }
        else
        {
            endScript = Instantiate(EndScript, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            _text = endScript.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            endScript_rt = endScript.GetComponent<RectTransform>();
            endScript_rt.localPosition = new Vector3(Popup1.gameObject.GetComponent<RectTransform>().localPosition.x, Popup1.gameObject.GetComponent<RectTransform>().localPosition.y - 30, 0);
            //_text.text = "<color=#ff0000>" + "오답\n" + "</color>" + QuestionManager.Instance.Questions[0].gameObject.name;
            _text.text = /*"오답\n" + */QuestionManager.Instance.Questions[0].gameObject.name;
        }
        //
        endImage = Instantiate(QuestionManager.Instance.Questions[1], gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        endImage_rt = endImage.GetComponent<RectTransform>();
        endImage_rt.localPosition = new Vector3(Popup2.gameObject.GetComponent<RectTransform>().localPosition.x, Popup2.gameObject.GetComponent<RectTransform>().localPosition.y + 20, 0);
        endImage_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 150);
        endImage_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 150);

        if (QuestionManager.Instance.Questions[1].gameObject.tag == "PASS")
        {
            endScript = Instantiate(EndScript, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            _text = endScript.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            endScript_rt = endScript.GetComponent<RectTransform>();
            endScript_rt.localPosition = new Vector3(Popup2.gameObject.GetComponent<RectTransform>().localPosition.x, Popup2.gameObject.GetComponent<RectTransform>().localPosition.y - 30, 0);
            _text.text = "정답\n" + QuestionManager.Instance.Questions[1].gameObject.name;
        }
        else
        {
            endScript = Instantiate(EndScript, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            _text = endScript.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            endScript_rt = endScript.GetComponent<RectTransform>();
            endScript_rt.localPosition = new Vector3(Popup2.gameObject.GetComponent<RectTransform>().localPosition.x, Popup2.gameObject.GetComponent<RectTransform>().localPosition.y - 30, 0);
            _text.text = /*"오답\n" + */QuestionManager.Instance.Questions[1].gameObject.name;
        }
        //
        endImage = Instantiate(QuestionManager.Instance.Questions[2], gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        endImage_rt = endImage.GetComponent<RectTransform>();
        endImage_rt.localPosition = new Vector3(Popup3.gameObject.GetComponent<RectTransform>().localPosition.x, Popup3.gameObject.GetComponent<RectTransform>().localPosition.y + 20, 0);
        endImage_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 150);
        endImage_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 150);

        if (QuestionManager.Instance.Questions[2].gameObject.tag == "PASS")
        {
            endScript = Instantiate(EndScript, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            _text = endScript.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            endScript_rt = endScript.GetComponent<RectTransform>();
            endScript_rt.localPosition = new Vector3(Popup3.gameObject.GetComponent<RectTransform>().localPosition.x, Popup3.gameObject.GetComponent<RectTransform>().localPosition.y - 30, 0);
            _text.text = "정답\n" + QuestionManager.Instance.Questions[2].gameObject.name;
        }
        else
        {
            endScript = Instantiate(EndScript, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            _text = endScript.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            endScript_rt = endScript.GetComponent<RectTransform>();
            endScript_rt.localPosition = new Vector3(Popup3.gameObject.GetComponent<RectTransform>().localPosition.x, Popup3.gameObject.GetComponent<RectTransform>().localPosition.y - 30, 0);
            _text.text = /*"오답\n" + */QuestionManager.Instance.Questions[2].gameObject.name;
        }
        //
        endImage = Instantiate(QuestionManager.Instance.Questions[3], gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        endImage_rt = endImage.GetComponent<RectTransform>();
        endImage_rt.localPosition = new Vector3(Popup4.gameObject.GetComponent<RectTransform>().localPosition.x, Popup4.gameObject.GetComponent<RectTransform>().localPosition.y + 20, 0);
        endImage_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 150);
        endImage_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 150);

        if (QuestionManager.Instance.Questions[3].gameObject.tag == "PASS")
        {
            endScript = Instantiate(EndScript, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            _text = endScript.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            endScript_rt = endScript.GetComponent<RectTransform>();
            endScript_rt.localPosition = new Vector3(Popup4.gameObject.GetComponent<RectTransform>().localPosition.x, Popup4.gameObject.GetComponent<RectTransform>().localPosition.y - 30, 0);
            _text.text = "정답\n" + QuestionManager.Instance.Questions[3].gameObject.name;
        }
        else
        {
            endScript = Instantiate(EndScript, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            _text = endScript.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            endScript_rt = endScript.GetComponent<RectTransform>();
            endScript_rt.localPosition = new Vector3(Popup4.gameObject.GetComponent<RectTransform>().localPosition.x, Popup4.gameObject.GetComponent<RectTransform>().localPosition.y - 30, 0);
            _text.text = /*"오답\n" + */QuestionManager.Instance.Questions[3].gameObject.name;
        }
        //
        endImage = Instantiate(QuestionManager.Instance.Questions[4], gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        endImage_rt = endImage.GetComponent<RectTransform>();
        endImage_rt.localPosition = new Vector3(Popup5.gameObject.GetComponent<RectTransform>().localPosition.x, Popup5.gameObject.GetComponent<RectTransform>().localPosition.y + 20, 0);
        endImage_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 150);
        endImage_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 150);

        if (QuestionManager.Instance.Questions[4].gameObject.tag == "PASS")
        {
            endScript = Instantiate(EndScript, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            _text = endScript.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            endScript_rt = endScript.GetComponent<RectTransform>();
            endScript_rt.localPosition = new Vector3(Popup5.gameObject.GetComponent<RectTransform>().localPosition.x, Popup5.gameObject.GetComponent<RectTransform>().localPosition.y - 30, 0);
            _text.text = "정답\n" + QuestionManager.Instance.Questions[4].gameObject.name;
        }
        else
        {
            endScript = Instantiate(EndScript, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            _text = endScript.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            endScript_rt = endScript.GetComponent<RectTransform>();
            endScript_rt.localPosition = new Vector3(Popup5.gameObject.GetComponent<RectTransform>().localPosition.x, Popup5.gameObject.GetComponent<RectTransform>().localPosition.y - 30, 0);
            _text.text = /*"오답\n" + */QuestionManager.Instance.Questions[4].gameObject.name;
        }
        //
        endImage = Instantiate(QuestionManager.Instance.Questions[5], gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        endImage_rt = endImage.GetComponent<RectTransform>();
        endImage_rt.localPosition = new Vector3(Popup6.gameObject.GetComponent<RectTransform>().localPosition.x, Popup6.gameObject.GetComponent<RectTransform>().localPosition.y + 20, 0);
        endImage_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 150);
        endImage_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 150);

        if (QuestionManager.Instance.Questions[5].gameObject.tag == "PASS")
        {
            endScript = Instantiate(EndScript, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            _text = endScript.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            endScript_rt = endScript.GetComponent<RectTransform>();
            endScript_rt.localPosition = new Vector3(Popup6.gameObject.GetComponent<RectTransform>().localPosition.x, Popup6.gameObject.GetComponent<RectTransform>().localPosition.y - 30, 0);
            _text.text = "정답\n" + QuestionManager.Instance.Questions[5].gameObject.name;
        }
        else
        {
            endScript = Instantiate(EndScript, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            _text = endScript.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            endScript_rt = endScript.GetComponent<RectTransform>();
            endScript_rt.localPosition = new Vector3(Popup6.gameObject.GetComponent<RectTransform>().localPosition.x, Popup6.gameObject.GetComponent<RectTransform>().localPosition.y - 30, 0);
            _text.text = /*"오답\n" + */QuestionManager.Instance.Questions[5].gameObject.name;
        }
        //
        endImage = Instantiate(QuestionManager.Instance.Questions[6], gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        endImage_rt = endImage.GetComponent<RectTransform>();
        endImage_rt.localPosition = new Vector3(Popup7.gameObject.GetComponent<RectTransform>().localPosition.x, Popup7.gameObject.GetComponent<RectTransform>().localPosition.y + 20, 0);
        endImage_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 150);
        endImage_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 150);

        if (QuestionManager.Instance.Questions[6].gameObject.tag == "PASS")
        {
            endScript = Instantiate(EndScript, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            _text = endScript.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            endScript_rt = endScript.GetComponent<RectTransform>();
            endScript_rt.localPosition = new Vector3(Popup7.gameObject.GetComponent<RectTransform>().localPosition.x, Popup7.gameObject.GetComponent<RectTransform>().localPosition.y - 30, 0);
            _text.text = "정답\n" + QuestionManager.Instance.Questions[6].gameObject.name;
        }
        else
        {
            endScript = Instantiate(EndScript, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            _text = endScript.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            endScript_rt = endScript.GetComponent<RectTransform>();
            endScript_rt.localPosition = new Vector3(Popup7.gameObject.GetComponent<RectTransform>().localPosition.x, Popup7.gameObject.GetComponent<RectTransform>().localPosition.y - 30, 0);
            _text.text = /*"오답\n" + */QuestionManager.Instance.Questions[6].gameObject.name;
        }
        //
        endImage = Instantiate(QuestionManager.Instance.Questions[7], gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        endImage_rt = endImage.GetComponent<RectTransform>();
        endImage_rt.localPosition = new Vector3(Popup8.gameObject.GetComponent<RectTransform>().localPosition.x, Popup8.gameObject.GetComponent<RectTransform>().localPosition.y + 20, 0);
        endImage_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 150);
        endImage_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 150);

        if (QuestionManager.Instance.Questions[7].gameObject.tag == "PASS")
        {
            endScript = Instantiate(EndScript, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            _text = endScript.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            endScript_rt = endScript.GetComponent<RectTransform>();
            endScript_rt.localPosition = new Vector3(Popup8.gameObject.GetComponent<RectTransform>().localPosition.x, Popup8.gameObject.GetComponent<RectTransform>().localPosition.y - 30, 0);
            _text.text = "정답\n" + QuestionManager.Instance.Questions[7].gameObject.name;
        }
        else
        {
            endScript = Instantiate(EndScript, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            _text = endScript.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            endScript_rt = endScript.GetComponent<RectTransform>();
            endScript_rt.localPosition = new Vector3(Popup8.gameObject.GetComponent<RectTransform>().localPosition.x, Popup8.gameObject.GetComponent<RectTransform>().localPosition.y - 30, 0);
            _text.text = /*"오답\n" + */QuestionManager.Instance.Questions[7].gameObject.name;
        }
        //
        endImage = Instantiate(QuestionManager.Instance.Questions[8], gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        endImage_rt = endImage.GetComponent<RectTransform>();
        endImage_rt.localPosition = new Vector3(Popup9.gameObject.GetComponent<RectTransform>().localPosition.x, Popup9.gameObject.GetComponent<RectTransform>().localPosition.y + 20, 0);
        endImage_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 150);
        endImage_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 150);

        if (QuestionManager.Instance.Questions[8].gameObject.tag == "PASS")
        {
            endScript = Instantiate(EndScript, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            _text = endScript.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            endScript_rt = endScript.GetComponent<RectTransform>();
            endScript_rt.localPosition = new Vector3(Popup9.gameObject.GetComponent<RectTransform>().localPosition.x, Popup9.gameObject.GetComponent<RectTransform>().localPosition.y - 30, 0);
            _text.text = "정답\n" + QuestionManager.Instance.Questions[8].gameObject.name;
        }
        else
        {
            endScript = Instantiate(EndScript, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            _text = endScript.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            endScript_rt = endScript.GetComponent<RectTransform>();
            endScript_rt.localPosition = new Vector3(Popup9.gameObject.GetComponent<RectTransform>().localPosition.x, Popup9.gameObject.GetComponent<RectTransform>().localPosition.y - 30, 0);
            _text.text = /*"오답\n" + */QuestionManager.Instance.Questions[8].gameObject.name;
        }
        //
        endImage = Instantiate(QuestionManager.Instance.Questions[9], gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        endImage_rt = endImage.GetComponent<RectTransform>();
        endImage_rt.localPosition = new Vector3(Popup10.gameObject.GetComponent<RectTransform>().localPosition.x, Popup10.gameObject.GetComponent<RectTransform>().localPosition.y + 20, 0);
        endImage_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 150);
        endImage_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 150);

        if (QuestionManager.Instance.Questions[9].gameObject.tag == "PASS")
        {
            endScript = Instantiate(EndScript, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            _text = endScript.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            endScript_rt = endScript.GetComponent<RectTransform>();
            endScript_rt.localPosition = new Vector3(Popup10.gameObject.GetComponent<RectTransform>().localPosition.x, Popup10.gameObject.GetComponent<RectTransform>().localPosition.y - 30, 0);
            _text.text = "정답\n" + QuestionManager.Instance.Questions[9].gameObject.name;
        }
        else
        {
            endScript = Instantiate(EndScript, gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            _text = endScript.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            endScript_rt = endScript.GetComponent<RectTransform>();
            endScript_rt.localPosition = new Vector3(Popup10.gameObject.GetComponent<RectTransform>().localPosition.x, Popup10.gameObject.GetComponent<RectTransform>().localPosition.y - 30, 0);
            _text.text = /*"오답\n" + */QuestionManager.Instance.Questions[9].gameObject.name;
        }
    }

    void Update()
    {
        
    }
}
