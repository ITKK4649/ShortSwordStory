using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private PlayerManager _playerManager;
    public List<GameObject> canvas = new List<GameObject>();
    public List<GameObject> objects = new List<GameObject>();
    public List<Text> tutorialtext = new List<Text>();
    public List<int> tutorial = new List<int>();
    public int tutorialCount;
    public int tutorialtextCount;
    // Start is called before the first frame update
    void Start()
    {
        canvas[0].SetActive(false);
        canvas[1].SetActive(false);
        canvas[2].SetActive(false);
        canvas[3].SetActive(false);
        objects[7].SetActive(false);
        objects[8].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch(tutorialtextCount)
        {
            case 0:
                Cursor.visible = true;
                tutorialtext[0].text = "�悤�����`���[�g���A����!";
                tutorialtext[1].text = "";
                tutorialtext[2].text = "";
                tutorialtext[3].text = "";
                tutorialtext[4].text = "";
                tutorialtext[5].text = "";
                tutorialtext[6].text = "";
                break;
            case 1:
                tutorialtext[0].text = "�����ł͊�{�I�ȑ���⃋�[�����w�ׂ��!";
                tutorialtext[1].text = "";
                break;
            case 2:
                tutorialtext[0].text = "�܂��͈ړ����Ă݂悤!";
                break;
            case 3:
                tutorialtext[0].text = "�ڂ̑O�̐��G���A�Ɉړ����Ă݂悤!";
                objects[0].SetActive(false);
                objects[1].SetActive(true);
                tutorialCount = 1;
                tutorialtext[1].text = "W�őO�i�AS�Ō�ށAAD�ō��E�Ɉړ��ł����!";
                break;
            case 4:
                tutorialtext[0].text = "�i�C�X�I���͎��_�𓮂������I";
                tutorialtext[1].text = "";
                break;
            case 5:
                if(tutorialCount == 1)
                {
                    tutorialCount++;
                }
                objects[0].SetActive(false);
                objects[2].SetActive(true);
                tutorialtext[0].text = "";
                tutorialtext[1].text = "���_�̓}�E�X�𓮂����Ες������I";
                break;
            case 6:
                objects[2].SetActive(false);
                tutorialtext[0].text = "�i�C�X�I���͍U�������Ă݂悤�I";
                tutorialtext[1].text = "";
                break;
            case 7:
                if (tutorialCount == 2)
                {
                    Instantiate(objects[3], objects[4].transform.position, objects[4].transform.rotation);
                    tutorialCount++;
                }
                objects[0].SetActive(false);
                tutorialtext[0].text = "�U�����I������シ���N���b�N��2�i�ڂ��o���邼�I";
                tutorialtext[1].text = "���N���b�N�ōU���ł��邼�I�G�ɍU�����悤�I";
                break;
            case 8:
                canvas[2].SetActive(true);
                tutorialtext[0].text = "";
                tutorialtext[1].text = "";
                tutorialtext[4].text = "�Q�b�g�����o���l�ŃX�e�[�^�X�������ł��邼�I";
                tutorialtext[5].text = "�|������(����͑�ʂɁj�o���l����ɓ��邼�I";
                break;
            case 9:
                if (tutorialCount == 3)
                {
                    tutorialCount++;
                }
                objects[0].SetActive(false);
                tutorialtext[4].text = "";
                tutorialtext[5].text = "J�������ċ�����ʂ��J���Ă݂悤�I";
                tutorialtext[1].text = "";
                break;
            case 10:
                tutorialtext[4].text = "";
                tutorialtext[5].text = "��������ƕK�v�o���l�������_���ŏオ���I";
                tutorialtext[2].text = "HP�͌����Ă���ƌo���l�ŉ񕜂ł����";
                break;
            case 11:
                tutorialtext[5].text = "������xJ�������ƕ�����I";
                tutorialtext[2].text = "";
                break;
            case 12:
                objects[0].SetActive(true);
                if (tutorialCount == 4)
                {
                    tutorialCount++;
                }
                tutorialtext[5].text = "���x�͓G���ǂ������Ă����I�C��t���悤�I";
                tutorialtext[4].text = "�J�[�\����ESC�L�[�ŕ\���ł����I";
                break;
            case 13:
                objects[0].SetActive(false);
                if (tutorialCount == 5)
                {
                    Instantiate(objects[3], objects[4].transform.position, objects[4].transform.rotation);
                    tutorialCount = 6;
                }
                tutorialtext[5].text = "";
                tutorialtext[4].text = "";
                break;
            case 14:
                objects[0].SetActive(true);
                tutorialtext[5].text = "���͓G��100�̓|�����ƂɎg����ULT���g���Ă݂悤�I";
                tutorialtext[4].text = "SPACE�{�^���Ŏg�����I";
                break;
            case 15:
                objects[0].SetActive(false);
                if (tutorialCount == 6)
                {
                    _playerManager.ultcount++;
                    Instantiate(objects[5], objects[6].transform.position, objects[6].transform.rotation);
                    tutorialCount = 7;
                }
                tutorialtext[5].text = "";
                tutorialtext[4].text = "";
                break;
            case 23:
                objects[0].SetActive(true);
                tutorialtext[5].text = "�����ˁI����Ń`���[�g���A���͏I������I";
                tutorialtext[4].text = "";
                break;
            case 24:
                objects[0].SetActive(false);
                objects[7].SetActive(true);
                objects[8].SetActive(true);
                tutorialtext[6].text = "�Q�[�����n�߂邩�^�C�g���ɖ߂낤�I";
                tutorialtext[4].text = "";
                break;
        }
    }
    public void countup()
    {
        tutorialtextCount++;
    }
}
