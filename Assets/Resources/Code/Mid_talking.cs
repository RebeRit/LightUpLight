using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class Mid_talking : MonoBehaviour
{
    public Text scriptObj;
    public Text nameObj;
    List<string> scripts = new List<string>();
    List<string> names = new List<string>();
    List<string> portraits = new List<string>();
    int checkScriptLine;
    public GameObject nextStoryBtn;
    public Button nextBtn;
    public GameObject backgroundImg;
    public GameObject characterImg;
    public Image portraitImg;

    // Start is called before the first frame update
    void Start()
    {
        portraitImg = characterImg.GetComponent<Image>();
        // ��ũ��Ʈ �ۼ��ϴ� ��
        names.Add("���ΰ�");
        names.Add("�����̼�");
        names.Add("�����̼�");
        names.Add("[����]");

        portraits.Add("Images/Hero_question");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Portrait_empty");

        scripts.Add("��� �Ʒ� �� ������ ����?");
        scripts.Add("�ٴڿ��� �Ϻΰ� �˰� ������ ������ �߰��ߴ�. �����ӿ��� ȭ���� ������ ����� ����ִ�.");
        scripts.Add("�������� ª�� ������ �����ִ�.");
        scripts.Add("�Ƹ� ���� ������� �� �Ͱ���. ������ ���� �������.. ����� �ϻ��� ��ã�� ���� ���� �̾��ϴ�. �ε� �� ������ ���������� �߰ߵǱ�.. �׸��� �� ���ฦ ������ �� ������ ������ ������ ����� ������ ��ã�桦");

        // �Ϲ� �ڵ�
        nextBtn.onClick.AddListener(nextScript);

        checkScriptLine = 0;
        scriptObj.text = "";
        StartCoroutine(Typing(scripts[checkScriptLine]));
        nameObj.text = names[checkScriptLine];
        portraitImg.GetComponent<Image>().sprite = Resources.Load<Sprite>(portraits[checkScriptLine].ToString());
        nextStoryBtn.SetActive(false);
        Invoke("showNextBtn", 2.5f);
    }

    void nextScript()
    {
        if (checkScriptLine < 3)
        {
            ++checkScriptLine;
            scriptObj.text = "";
            StartCoroutine(Typing(scripts[checkScriptLine]));
            nameObj.text = names[checkScriptLine];
            portraitImg.GetComponent<Image>().sprite = Resources.Load<Sprite>(portraits[checkScriptLine]);

            Debug.Log("Show Next Script");
            nextStoryBtn.SetActive(false);
            if (checkScriptLine == 3)
            {
                Invoke("showNextBtn", 6.0f);
            }
            else
            {
                Invoke("showNextBtn", 2.5f);
            }
        }
        else
        {
            backgroundImg.SetActive(false);
            characterImg.SetActive(false);
            nameObj.gameObject.SetActive(false);
            scriptObj.gameObject.SetActive(false);
            nextStoryBtn.SetActive(false);
            Player_Script.is_script_time = false;
        }
    }

    void showNextBtn()
    {
        nextStoryBtn.SetActive(true);
    }

    IEnumerator Typing(string text)
    {
        foreach (char letter in text.ToCharArray())
        {
            scriptObj.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
}