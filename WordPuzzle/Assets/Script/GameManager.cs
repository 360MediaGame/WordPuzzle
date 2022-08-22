using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public GameObject KeyBoard;
    public TextMeshProUGUI _text;

    public Vector2 createPoint;
    public Scene scene;

    public List<Dictionary<string, object>> data;

    private List<string> RandomKorean = new List<string>();
    public List<GameObject> Block = new List<GameObject>();

    public string CombineWord = "";

    private int PUZZLE_ROW = 4;                                  
    private int PUZZLE_COL = 10;                                 
    private int START_X = -610;
    private int START_Y = -95;
    private int SPACE = 110;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
        MakeKorean();
        scene = SceneManager.GetActiveScene();
    }

    private void MakeKorean()
    {
        // �ϴ���..
        RandomKorean.Add("ǥ");
        RandomKorean.Add("��");
        RandomKorean.Add("ȫ");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("Ȳ");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("ä");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("��");
        RandomKorean.Add("��");

    }

    void Start()
    {
        MakeKeyBoardData();
        MakeKeyBoard();
    }

    void MakeKeyBoardData()
    {
        int idx = Random.Range(0, 10);

        switch (scene.name)
        {
            case "EAZY_SCENE":
                PUZZLE_ROW = 4;
                PUZZLE_COL = 10;
                START_X = -610;
                START_Y = 0;
                SPACE = 110;

                switch (idx)
                {
                    case 0:
                        Debug.Log("Case 0 Load");
                        data = CSVParser.Read("WordPuzzle00");
                        break;
                    case 1:
                        Debug.Log("Case 1 Load");
                        data = CSVParser.Read("WordPuzzle01");
                        break;
                    case 2:
                        Debug.Log("Case 2 Load");
                        data = CSVParser.Read("WordPuzzle02");
                        break;
                    case 3:
                        Debug.Log("Case 3 Load");
                        data = CSVParser.Read("WordPuzzle03");
                        break;
                    case 4:
                        Debug.Log("Case 4 Load");
                        data = CSVParser.Read("WordPuzzle04");
                        break;
                    case 5:
                        Debug.Log("Case 5 Load");
                        data = CSVParser.Read("WordPuzzle05");
                        break;
                    case 6:
                        Debug.Log("Case 6 Load");
                        data = CSVParser.Read("WordPuzzle06");
                        break;
                    case 7:
                        Debug.Log("Case 7 Load");
                        data = CSVParser.Read("WordPuzzle07");
                        break;
                    case 8:
                        Debug.Log("Case 8 Load");
                        data = CSVParser.Read("WordPuzzle08");
                        break;
                    case 9:
                        Debug.Log("Case 9 Load");
                        data = CSVParser.Read("WordPuzzle09");
                        break;
                }
                break;
            case "NORMAL_SCENE":
                PUZZLE_ROW = 5;
                PUZZLE_COL = 13;
                START_X = -640;
                START_Y = 0;
                SPACE = 90;

                switch (idx)
                {
                    case 0:
                        Debug.Log("Case 0 Load");
                        data = CSVParser.Read("WordPuzzle10");
                        break;
                    case 1:
                        Debug.Log("Case 1 Load");
                        data = CSVParser.Read("WordPuzzle11");
                        break;
                    case 2:
                        Debug.Log("Case 2 Load");
                        data = CSVParser.Read("WordPuzzle12");
                        break;
                    case 3:
                        Debug.Log("Case 3 Load");
                        data = CSVParser.Read("WordPuzzle13");
                        break;
                    case 4:
                        Debug.Log("Case 4 Load");
                        data = CSVParser.Read("WordPuzzle14");
                        break;
                    case 5:
                        Debug.Log("Case 5 Load");
                        data = CSVParser.Read("WordPuzzle15");
                        break;
                    case 6:
                        Debug.Log("Case 6 Load");
                        data = CSVParser.Read("WordPuzzle16");
                        break;
                    case 7:
                        Debug.Log("Case 7 Load");
                        data = CSVParser.Read("WordPuzzle17");
                        break;
                    case 8:
                        Debug.Log("Case 8 Load");
                        data = CSVParser.Read("WordPuzzle18");
                        break;
                    case 9:
                        Debug.Log("Case 9 Load");
                        data = CSVParser.Read("WordPuzzle19");
                        break;
                }
                break;
            case "HARD_SCENE":
                PUZZLE_ROW = 6;
                PUZZLE_COL = 15;
                START_X = -650;
                START_Y = 20;
                SPACE = 80;

                switch (idx)
                {
                    case 0:
                        Debug.Log("Case 0 Load");
                        data = CSVParser.Read("WordPuzzle20");
                        break;
                    case 1:
                        Debug.Log("Case 1 Load");
                        data = CSVParser.Read("WordPuzzle21");
                        break;
                    case 2:
                        Debug.Log("Case 2 Load");
                        data = CSVParser.Read("WordPuzzle22");
                        break;
                    case 3:
                        Debug.Log("Case 3 Load");
                        data = CSVParser.Read("WordPuzzle23");
                        break;
                    case 4:
                        Debug.Log("Case 4 Load");
                        data = CSVParser.Read("WordPuzzle24");
                        break;
                    case 5:
                        Debug.Log("Case 5 Load");
                        data = CSVParser.Read("WordPuzzle25");
                        break;
                    case 6:
                        Debug.Log("Case 6 Load");
                        data = CSVParser.Read("WordPuzzle26");
                        break;
                    case 7:
                        Debug.Log("Case 7 Load");
                        data = CSVParser.Read("WordPuzzle27");
                        break;
                    case 8:
                        Debug.Log("Case 8 Load");
                        data = CSVParser.Read("WordPuzzle28");
                        break;
                    case 9:
                        Debug.Log("Case 9 Load");
                        data = CSVParser.Read("WordPuzzle29");
                        break;
                }
                break;
            default:
                Debug.Log("Scene Load Error");
                break;
        }
    }

    void MakeKeyBoard()
    {
        // ���� ����
        for (int row = 0; row < PUZZLE_ROW; ++row)
        {
            for (int col = 1; col <= PUZZLE_COL; ++col)
            {
                GameObject _key = Instantiate(KeyBoard, createPoint, Quaternion.identity, GameObject.Find("Canvas").transform);
                _key.name = row.ToString() + col.ToString();
                Block.Add(_key);
                RectTransform _key_rt = _key.GetComponent<RectTransform>();
                _key_rt.localPosition = new Vector3(START_X + (col * SPACE), START_Y - (row * SPACE), 0);

                if (scene.name == "NORMAL_SCENE")
                {
                    // �븻 ���� Ű������ ��,�� ������ �������Ƿ� Ű������ �������� �� �۰� ������
                    _key_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 80);
                    _key_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 80);
                }
                if (scene.name == "HARD_SCENE")
                {
                    // �ϵ� ���� �׺��� �� �������Ƿ� �� �۰� ������.
                    _key_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 70);
                    _key_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 70);
                }

                _text = _key.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
                // ���� ���Ͽ��� ?�� �� ĭ�̹Ƿ� �ռ� �����ص� ������ �ѱ۰��� ����־���
                if (data[row][col.ToString()].ToString() == "?")
                {
                    int idx = Random.Range(0, RandomKorean.Count);
                    _text.text = RandomKorean[idx];
                    continue;
                }
                _text.text = data[row][col.ToString()].ToString();
            }
        }
    }

    public void UpdateWord()
    {
        CombineWord = "";
        for (int i = 0; i < Block.Count; ++i)
        {
            if (Block[i].GetComponent<Image>().color == Color.red)
            {
                CombineWord += Block[i].gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;
                UIManager.Instance._AnswerViewText.text = CombineWord;
            }
        }
    }
}
