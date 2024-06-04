using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fristAttack : MonoBehaviour
{
    private GameObject _player;
    private attack _attack;
    private GameObject _GameManager;
    private GameManager _gameManager;
    public float destroycount;
    private float destroycountmax;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Playerattack");
        _GameManager = GameObject.Find("GameManager");
        _attack = _player.GetComponent<attack>();
        _gameManager = _GameManager.GetComponent<GameManager>();
        this.transform.localRotation = Quaternion.Euler(316, 70, 13);
        destroycountmax = 150;
    }

    // Update is called once per frame
    void Update()
    {
        //攻撃速度を削除までのカウントにプラス
        destroycount += _gameManager._attackspeed;
        //自身の角度を攻撃速度の値で回転
        this.transform.Rotate(0, -_gameManager._attackspeed, 0);
        //削除までのカウントが削除までのカウントの最大値を超えたら
        if (destroycount >=  destroycountmax)
        {
            //一段階目の攻撃完了をtrueに
            _attack.frist = true;
            //自身を削除
            Destroy(this.gameObject);
        }
    }
}
