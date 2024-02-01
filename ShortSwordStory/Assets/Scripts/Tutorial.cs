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
                tutorialtext[0].text = "ようこそチュートリアルへ!";
                tutorialtext[1].text = "";
                tutorialtext[2].text = "";
                tutorialtext[3].text = "";
                tutorialtext[4].text = "";
                tutorialtext[5].text = "";
                tutorialtext[6].text = "";
                break;
            case 1:
                tutorialtext[0].text = "ここでは基本的な操作やルールを学べるよ!";
                tutorialtext[1].text = "";
                break;
            case 2:
                tutorialtext[0].text = "まずは移動してみよう!";
                break;
            case 3:
                tutorialtext[0].text = "目の前の青いエリアに移動してみよう!";
                objects[0].SetActive(false);
                objects[1].SetActive(true);
                tutorialCount = 1;
                tutorialtext[1].text = "Wで前進、Sで後退、ADで左右に移動できるよ!";
                break;
            case 4:
                tutorialtext[0].text = "ナイス！次は視点を動かそう！";
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
                tutorialtext[1].text = "視点はマウスを動かせば変えられるよ！";
                break;
            case 6:
                objects[2].SetActive(false);
                tutorialtext[0].text = "ナイス！次は攻撃をしてみよう！";
                tutorialtext[1].text = "";
                break;
            case 7:
                if (tutorialCount == 2)
                {
                    Instantiate(objects[3], objects[4].transform.position, objects[4].transform.rotation);
                    tutorialCount++;
                }
                objects[0].SetActive(false);
                tutorialtext[0].text = "攻撃が終わった後すぐクリックで2段目が出せるぞ！";
                tutorialtext[1].text = "左クリックで攻撃できるぞ！敵に攻撃しよう！";
                break;
            case 8:
                canvas[2].SetActive(true);
                tutorialtext[0].text = "";
                tutorialtext[1].text = "";
                tutorialtext[4].text = "ゲットした経験値でステータスが強化できるぞ！";
                tutorialtext[5].text = "倒したら(今回は大量に）経験値が手に入るぞ！";
                break;
            case 9:
                if (tutorialCount == 3)
                {
                    tutorialCount++;
                }
                objects[0].SetActive(false);
                tutorialtext[4].text = "";
                tutorialtext[5].text = "Jを押して強化画面を開いてみよう！";
                tutorialtext[1].text = "";
                break;
            case 10:
                tutorialtext[4].text = "";
                tutorialtext[5].text = "強化すると必要経験値がランダムで上がるよ！";
                tutorialtext[2].text = "HPは減っていると経験値で回復できるよ";
                break;
            case 11:
                tutorialtext[5].text = "もう一度Jを押すと閉じれるよ！";
                tutorialtext[2].text = "";
                break;
            case 12:
                objects[0].SetActive(true);
                if (tutorialCount == 4)
                {
                    tutorialCount++;
                }
                tutorialtext[5].text = "今度は敵が追いかけてくるよ！気を付けよう！";
                tutorialtext[4].text = "カーソルはESCキーで表示できるよ！";
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
                tutorialtext[5].text = "次は敵を100体倒すごとに使えるULTを使ってみよう！";
                tutorialtext[4].text = "SPACEボタンで使えるよ！";
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
                tutorialtext[5].text = "いいね！これでチュートリアルは終了だよ！";
                tutorialtext[4].text = "";
                break;
            case 24:
                objects[0].SetActive(false);
                objects[7].SetActive(true);
                objects[8].SetActive(true);
                tutorialtext[6].text = "ゲームを始めるかタイトルに戻ろう！";
                tutorialtext[4].text = "";
                break;
        }
    }
    public void countup()
    {
        tutorialtextCount++;
    }
}
