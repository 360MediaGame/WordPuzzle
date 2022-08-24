using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    private static QuestionManager instance;

    public List<GameObject> Questions = new List<GameObject>();
    public List<GameObject> Questions_Gray = new List<GameObject>();
    public List<GameObject> tempQuestions = new List<GameObject>();
    public List<GameObject> tempQuestions_Gray = new List<GameObject>();

    List<int> ObjList = new List<int>();
    List<int> ObjIDXList = new List<int>();

    // �ִϸ��̼��� �� GameObject��.
    public GameObject RedEyes;
    public GameObject Sonamoo;
    public GameObject Pretty;
    public GameObject ChungHwang;
    public GameObject Gang;
    public GameObject StarMal;
    public GameObject BeachMal;
    public GameObject Gasi;
    public GameObject Dolgi;
    public GameObject BlackBird;
    public GameObject MoonMeat;
    public GameObject Bok;
    public GameObject SO;
    public GameObject Chung;
    public GameObject BlueDom;
    public GameObject Gangchi;
    public GameObject DDackBird;
    public GameObject Heaguk;
    public GameObject Hwang;
    public GameObject BlackDom;

    // ��� GameObject��
    public GameObject RedEyes_Gray;
    public GameObject Sonamoo_Gray;
    public GameObject Pretty_Gray;
    public GameObject ChungHwang_Gray;
    public GameObject Gang_Gray;
    public GameObject StarMal_Gray;
    public GameObject BeachMal_Gray;
    public GameObject Gasi_Gray;
    public GameObject Dolgi_Gray;
    public GameObject BlackBird_Gray;
    public GameObject MoonMeat_Gray;
    public GameObject Bok_Gray;
    public GameObject SO_Gray;
    public GameObject Chung_Gray;
    public GameObject BlueDom_Gray;
    public GameObject Gangchi_Gray;
    public GameObject DDackBird_Gray;
    public GameObject Heaguk_Gray;
    public GameObject Hwang_Gray;
    public GameObject BlackDom_Gray;

    public GameObject O_Effect;         // ���� ����Ʈ
    public GameObject TimeOver_Effect;  // Ÿ�Ӿƿ� ����Ʈ
    public GameObject EndPopUp;         // ���� �˾� (��� ������ �� Ǯ���� �� ����)

    public int CurQuestionIndex = 0;
    public int AnswerCount = 0;

    private Vector2 NowPos;             // ��� ��ġ�� �����ϴ� ����
    private Vector2 Prev1Pos;           // ����1 ��ġ�� �����ϴ� ����
    private Vector2 Prev2Pos;           // ����2 ��ġ�� �����ϴ� ����
    private Vector2 PrevEnd;            // ���� ȭ�鿡 ������ �ʴ� ������Ʈ���� ��ġ�� �����ϴ� ����(������0 ���� ���� �Ⱥ��̰�)
    private Vector2 Next1Pos;           // ����1 ��ġ�� �����ϴ� ����
    private Vector2 Next2Pos;           // ����2 ��ġ�� �����ϴ� ����
    private Vector2 NextEnd;            // ȭ�鿡�� 5���� ������ ���´�. ���Լ�������� �з��� �������� ����Ǵ� ��ġ ����

    private int ScaleCenter = 300;      // ��� ������Ʈ ũ�� ���� (���� Ǯ��� �ϴ� ����)
    private int Scale1 = 210;           // ����1, ����1 ��ġ ũ�� ����
    private int Scale2 = 120;           // ����2, ����2 ��ġ ũ�� ����
    private int MoveSpeed = 300;        // ������Ʈ�� �̵��ϴ� �ӵ� ����

    private bool isMove = false;
    private bool isCntUp = false;

    RectTransform Question_rt;
    float Xnewpos;
    float newScale;

    public static QuestionManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;

        // ��ġ �ʱ�ȭ
        NowPos.x = 0;
        NowPos.y = 304;
        Prev1Pos.x = -300;
        Prev1Pos.y = 304;
        Prev2Pos.x = -600;
        Prev2Pos.y = 304;
        PrevEnd.x = -630;
        PrevEnd.y = 304;
        Next1Pos.x = 300;
        Next1Pos.y = 304;
        Next2Pos.x = 600;
        Next2Pos.y = 304;
        NextEnd.x = 630;
        NextEnd.y = 304;       
    }

    void Start()
    {
        SetTempQuestion();
        CreateUnDuplicateRandom(0, 10);

        for (int i = 0; i < 10; ++i)
        {
            Questions_Gray.Add(tempQuestions_Gray[ObjList[i]]);

            GameObject QuestionAnimal = Instantiate(tempQuestions[ObjList[i]], gameObject.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            QuestionAnimal.gameObject.name = tempQuestions[ObjList[i]].gameObject.name;
            Questions.Add(QuestionAnimal);
        }

        for (int i = 0; i < 10; ++i)
        {
            if (i == 0)
            {
                Questions[0].tag = "Center";
                RectTransform Questions_rt = Questions[i].GetComponent<RectTransform>();
                Questions_rt.localPosition = new Vector3(NowPos.x, NowPos.y, 0);
            }
            else if (i == 1)
            {
                Questions[1].tag = "Next1";
                RectTransform Questions_rt = Questions[i].GetComponent<RectTransform>();
                Questions_rt.localPosition = new Vector3(Next1Pos.x, Next1Pos.y, 0);
                Questions_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Scale1);
                Questions_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Scale1);
            }
            else if (i == 2)
            {
                Questions[2].tag = "Next2";
                RectTransform Questions_rt = Questions[i].GetComponent<RectTransform>();
                Questions_rt.localPosition = new Vector3(Next2Pos.x, Next2Pos.y, 0);
                Questions_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Scale2);
                Questions_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Scale2);
            }
            else
            {
                Questions[i].tag = "NextEnd";
                RectTransform Questions_rt = Questions[i].GetComponent<RectTransform>();
                Questions_rt.localPosition = new Vector3(NextEnd.x, NextEnd.y, 0);
                Questions_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
                Questions_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);
            }
        }
    }

    // ���� ���� (�ߺ� ����)
    void CreateUnDuplicateRandom(int min, int max)
    {
        int currentNumber = Random.Range(min, max);

        for (int i = 0; i < max;)
        {
            if (ObjList.Contains(currentNumber))
            {
                currentNumber = Random.Range(min, max);
            }
            else
            {
                ObjList.Add(currentNumber);
                i++;
            }
        }
    }

    void SetTempQuestion()
    {
        switch (GameManager.Instance.scene.name)
        {
            case "EAZY_SCENE":
                tempQuestions.Add(Gasi);
                tempQuestions.Add(Dolgi);
                tempQuestions.Add(BlackBird);
                tempQuestions.Add(MoonMeat);
                tempQuestions.Add(Bok);
                tempQuestions.Add(SO);
                tempQuestions.Add(Chung);
                tempQuestions.Add(BlueDom);
                tempQuestions.Add(Gangchi);
                tempQuestions.Add(DDackBird);
                tempQuestions.Add(Heaguk);
                tempQuestions.Add(Hwang);
                tempQuestions.Add(BlackDom);

                tempQuestions_Gray.Add(Gasi_Gray);
                tempQuestions_Gray.Add(Dolgi_Gray);
                tempQuestions_Gray.Add(BlackBird_Gray);
                tempQuestions_Gray.Add(MoonMeat_Gray);
                tempQuestions_Gray.Add(Bok_Gray);
                tempQuestions_Gray.Add(SO_Gray);
                tempQuestions_Gray.Add(Chung_Gray);
                tempQuestions_Gray.Add(BlueDom_Gray);
                tempQuestions_Gray.Add(Gangchi_Gray);
                tempQuestions_Gray.Add(DDackBird_Gray);
                tempQuestions_Gray.Add(Heaguk_Gray);
                tempQuestions_Gray.Add(Hwang_Gray);
                tempQuestions_Gray.Add(BlackDom_Gray);
                break;
            case "NORMAL_SCENE":
                tempQuestions.Add(Gang);
                tempQuestions.Add(StarMal);
                tempQuestions.Add(BeachMal);
                tempQuestions.Add(Gasi);
                tempQuestions.Add(Dolgi);
                tempQuestions.Add(BlackBird);
                tempQuestions.Add(MoonMeat);
                tempQuestions.Add(Bok);
                tempQuestions.Add(SO);
                tempQuestions.Add(Chung);
                tempQuestions.Add(BlueDom);
                tempQuestions.Add(Gangchi);
                tempQuestions.Add(DDackBird);
                tempQuestions.Add(Heaguk);
                tempQuestions.Add(Hwang);

                tempQuestions_Gray.Add(Gang_Gray);
                tempQuestions_Gray.Add(StarMal_Gray);
                tempQuestions_Gray.Add(BeachMal_Gray);
                tempQuestions_Gray.Add(Gasi_Gray);
                tempQuestions_Gray.Add(Dolgi_Gray);
                tempQuestions_Gray.Add(BlackBird_Gray);
                tempQuestions_Gray.Add(MoonMeat_Gray);
                tempQuestions_Gray.Add(Bok_Gray);
                tempQuestions_Gray.Add(SO_Gray);
                tempQuestions_Gray.Add(Chung_Gray);
                tempQuestions_Gray.Add(BlueDom_Gray);
                tempQuestions_Gray.Add(Gangchi_Gray);
                tempQuestions_Gray.Add(DDackBird_Gray);
                tempQuestions_Gray.Add(Heaguk_Gray);
                tempQuestions_Gray.Add(Hwang_Gray);
                break;
            case "HARD_SCENE":
                tempQuestions.Add(RedEyes);
                tempQuestions.Add(Sonamoo);
                tempQuestions.Add(Pretty);
                tempQuestions.Add(ChungHwang);
                tempQuestions.Add(Gang);
                tempQuestions.Add(StarMal);
                tempQuestions.Add(BeachMal);
                tempQuestions.Add(Gasi);
                tempQuestions.Add(Dolgi);
                tempQuestions.Add(MoonMeat);
                tempQuestions.Add(Bok);
                tempQuestions.Add(BlueDom);
                tempQuestions.Add(Gangchi);

                tempQuestions_Gray.Add(RedEyes_Gray);
                tempQuestions_Gray.Add(Sonamoo_Gray);
                tempQuestions_Gray.Add(Pretty_Gray);
                tempQuestions_Gray.Add(ChungHwang_Gray);
                tempQuestions_Gray.Add(Gang_Gray);
                tempQuestions_Gray.Add(StarMal_Gray);
                tempQuestions_Gray.Add(BeachMal_Gray);
                tempQuestions_Gray.Add(Gasi_Gray);
                tempQuestions_Gray.Add(Dolgi_Gray);
                tempQuestions_Gray.Add(MoonMeat_Gray);
                tempQuestions_Gray.Add(Bok_Gray);
                tempQuestions_Gray.Add(BlueDom_Gray);
                tempQuestions_Gray.Add(Gangchi_Gray);
                break;

        }
    }

    public void MoveQuestion()
    {
        isMove = true;
        isCntUp = false;
    }

    void Update()
    {
        if (GameObject.FindWithTag("Effect"))
            return;

        if (CurQuestionIndex >= 9)
            return;

        if (isMove)
        {
            if (CurQuestionIndex >= 2)
            {
                ///////////////////////////// Prev2 �̹��� �̵� /////////////////////////////
                Question_rt = Questions[CurQuestionIndex - 2].GetComponent<RectTransform>();
                Xnewpos = Question_rt.localPosition.x - Time.deltaTime * MoveSpeed;
                Question_rt.localPosition = new Vector3(Xnewpos, NowPos.y, 0);
                // ������ ��ġ�� ���� ��ġ�� ��������
                if (Xnewpos <= PrevEnd.x)
                    Question_rt.localPosition = new Vector3(PrevEnd.x, PrevEnd.y, 0);
                newScale = Question_rt.rect.width - Time.deltaTime * 200;
                Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newScale);
                Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newScale);
                // ������ ũ�⸸ŭ �۾����� ũ�⸦ ��������
                if (newScale <= 0)
                {
                    Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
                    Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);
                }
            }

            if (CurQuestionIndex >= 1)
            {
                ///////////////////////////// Prev1 �̹��� �̵� /////////////////////////////
                Question_rt = Questions[CurQuestionIndex - 1].GetComponent<RectTransform>();
                Xnewpos = Question_rt.localPosition.x - Time.deltaTime * MoveSpeed;
                Question_rt.localPosition = new Vector3(Xnewpos, NowPos.y, 0);
                // ������ ��ġ�� ���� ��ġ�� ��������
                if (Xnewpos <= Prev2Pos.x)
                    Question_rt.localPosition = new Vector3(Prev2Pos.x, Prev2Pos.y, 0);
                newScale = Question_rt.rect.width - Time.deltaTime * 100;
                Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newScale);
                Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newScale);
                // ������ ũ�⸸ŭ �۾����� ũ�⸦ ��������
                if (newScale <= Scale2)
                {
                    Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Scale2);
                    Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Scale2);
                }
            }

            ///////////////////////////// ��� �̹��� �̵� /////////////////////////////
            Question_rt = Questions[CurQuestionIndex].GetComponent<RectTransform>();
            Xnewpos = Question_rt.localPosition.x - Time.deltaTime * MoveSpeed;
            Question_rt.localPosition = new Vector3(Xnewpos, NowPos.y, 0);
            // ������ ��ġ�� ���� ��ġ�� ��������
            if (Xnewpos <= Prev1Pos.x)
            {
                Question_rt.localPosition = new Vector3(Prev1Pos.x, Prev1Pos.y, 0);
                isMove = false;
                if (!isCntUp)
                {
                    CurQuestionIndex++;
                    isCntUp = true;
                }

                // ����â �ʱ�ȭ
                UIManager.Instance._AnswerViewText.text = "";
                UIManager.Instance._isStopTimer = false;
                
            }
            newScale = Question_rt.rect.width - Time.deltaTime * 100;
            Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newScale);
            Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newScale);
            // ������ ũ�⸸ŭ �۾����� ũ�⸦ ��������
            if (newScale <= Scale1)
            {
                Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Scale1);
                Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Scale1);
            }

            if (CurQuestionIndex <= 8)
            {
                ///////////////////////////// Next1 �̹��� �̵� /////////////////////////////
                Question_rt = Questions[CurQuestionIndex + 1].GetComponent<RectTransform>();
                Xnewpos = Question_rt.localPosition.x - Time.deltaTime * MoveSpeed;
                Question_rt.localPosition = new Vector3(Xnewpos, NowPos.y, 0);
                // ������ ��ġ�� ���� ��ġ�� ��������
                if (Xnewpos <= NowPos.x)
                    Question_rt.localPosition = new Vector3(NowPos.x, NowPos.y, 0);
                newScale = Question_rt.rect.width + Time.deltaTime * 100;
                Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newScale);
                Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newScale);
                // ������ ũ�⸸ŭ �۾����� ũ�⸦ ��������
                if (newScale >= ScaleCenter)
                {
                    Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ScaleCenter);
                    Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, ScaleCenter);
                }
            }
            if (CurQuestionIndex <= 7)
            { 
                ///////////////////////////// Next2 �̹��� �̵� /////////////////////////////
                Question_rt = Questions[CurQuestionIndex + 2].GetComponent<RectTransform>();
                Xnewpos = Question_rt.localPosition.x - Time.deltaTime * MoveSpeed;
                Question_rt.localPosition = new Vector3(Xnewpos, NowPos.y, 0);
                // ������ ��ġ�� ���� ��ġ�� ��������
                if (Xnewpos <= Next1Pos.x)
                    Question_rt.localPosition = new Vector3(Next1Pos.x, Next1Pos.y, 0);
                newScale = Question_rt.rect.width + Time.deltaTime * 100;
                Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newScale);
                Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newScale);
                // ������ ũ�⸸ŭ �۾����� ũ�⸦ ��������
                if (newScale >= Scale1)
                {
                    Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Scale1);
                    Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Scale1);
                }
            }

            if (CurQuestionIndex <= 6)
            {
                ///////////////////////////// NextEnd �̹��� �̵� /////////////////////////////
                Question_rt = Questions[CurQuestionIndex + 3].GetComponent<RectTransform>();
                Xnewpos = Question_rt.localPosition.x - Time.deltaTime * MoveSpeed;
                Question_rt.localPosition = new Vector3(Xnewpos, NowPos.y, 0);
                // ������ ��ġ�� ���� ��ġ�� ��������
                if (Xnewpos <= Next2Pos.x)
                    Question_rt.localPosition = new Vector3(Next2Pos.x, Next2Pos.y, 0);
                newScale = Question_rt.rect.width + Time.deltaTime * 100;
                Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newScale);
                Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newScale);
                // ������ ũ�⸸ŭ �۾����� ũ�⸦ ��������
                if (newScale >= Scale2)
                {
                    Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Scale2);
                    Question_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Scale2);
                }
            }
        }
    }
}
