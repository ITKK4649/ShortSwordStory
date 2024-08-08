using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerStrengthen : MonoBehaviour
{
    public bool shopopen;
    GameObject _player;
    private PlayerManager _playerManager;
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private Menu _menu;
    [SerializeField]
    Tutorial _tutorial;
    [SerializeField]
    private GameObject _playerCanvas;
    [SerializeField]
    private GameObject _exCanvas;
    [SerializeField]
    private GameObject _HpCanvas;
    private int _menucount;
    private int fristexp = 10;
    private int _playerspeedexp;
    private int _playerattackspeedexp;
    private int _playerattackdamageexp;
    private int _playerHealHpexp;
    [SerializeField]
    Text _playerexp;
    [SerializeField]
    private List<Text> _playerstreng = new List<Text>();
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _playerManager = _player.GetComponent<PlayerManager>();
        _playerspeedexp = fristexp;
        _playerattackspeedexp = fristexp;
        _playerattackdamageexp = fristexp;
        _playerHealHpexp = fristexp * fristexp;
    }

    // Update is called once per frame
    void Update()
    {
        if (_tutorial.tutorialCount >= 4)
        {
            _playerstreng[0].text = "" + _playerspeedexp;
            _playerstreng[1].text = "" + _playerattackspeedexp;
            _playerstreng[2].text = "" + _playerattackdamageexp;
            _playerstreng[3].text = "" + _playerHealHpexp;
            _playerstreng[4].text = "EnemyKillCount:" + _gameManager._enemyKillCountMax;
            _playerexp.text = "EXP：" + _playerManager.exp;
            if (_menu._menuopenset == false)
            {
                if (Input.GetKeyDown(KeyCode.J) && _menucount == 0)
                {
                    if (_tutorial.tutorialtextCount == 9)
                    {
                        _tutorial.tutorialtextCount++;
                    }
                    _playerCanvas.SetActive(true);
                    _HpCanvas.SetActive(false);
                    Cursor.visible = true;
                    shopopen = true;
                    _menucount++;
                }
                else if (Input.GetKeyDown(KeyCode.J) && _menucount == 1)
                {
                    if (_tutorial.tutorialtextCount == 11)
                    {
                        _tutorial.tutorialtextCount++;
                    }
                    _playerCanvas.SetActive(false);
                    _exCanvas.SetActive(false);
                    _HpCanvas.SetActive(true);
                    Cursor.visible = false;
                    shopopen = false;
                    _menucount = 0;
                }
            }
        }
    }

    public void exCanvas()
    {
        if(_exCanvas.activeSelf == false)
        {
            _exCanvas.SetActive(true);
            _playerCanvas.SetActive(false);
            Cursor.visible = true;
            shopopen = true;
        }
        else if(_exCanvas.activeSelf == true)
        {
            _exCanvas.SetActive(false);
            _playerCanvas.SetActive(true);
        }
    }
    public void playerspeed()
    {
        //経験値が必要経験値を上回っているか
        if(_playerManager.exp >= _playerspeedexp)
        {
            //チュートリアルが10段階目以上進んでたら
            if (_tutorial.tutorialtextCount == 10)
            {
                _tutorial.tutorialtextCount++;
            }
            //プレイヤーの速度をランダムで0.01～0.03の値で強化
            _playerManager.speed += Random.Range(0.01f, 0.04f);
            //プレイヤーの経験値を必要経験値分マイナス
            _playerManager.exp -= _playerspeedexp;
            //必要経験値を5～9の間で増加
            _playerspeedexp += Random.Range(5,10);
        }
    }
    public void playerAttackspeed()
    {
        //経験値が必要経験値を上回っているか
        if (_playerManager.exp >= _playerattackspeedexp)
        {
            //チュートリアルが10段階目以上進んでたら
            if (_tutorial.tutorialtextCount == 10)
            {
                _tutorial.tutorialtextCount++;
            }
            //プレイヤーの攻撃速度をランダムで0.01～0.03の値で強化
            _gameManager._attackspeed += Random.Range(0.01f, 0.04f);
            //プレイヤーの経験値を必要経験値分マイナス
            _playerManager.exp -= _playerattackspeedexp;
            //必要経験値を5～9の間で増加
            _playerattackspeedexp += Random.Range(5, 10);
        }
    }
    public void playerAttackDamage()
    {
        //経験値が必要経験値を上回っているか
        if (_playerManager.exp >= _playerattackdamageexp)
        {
            //チュートリアルが10段階目以上進んでたら
            if (_tutorial.tutorialtextCount == 10)
            {
                _tutorial.tutorialtextCount++;
            }
            //プレイヤーの攻撃力をランダムで1～3の値で強化
            _gameManager._attackDamage += Random.Range(1, 4);
            //プレイヤーの経験値を必要経験値分マイナス
            _playerManager.exp -= _playerattackdamageexp;
            //必要経験値を10～19の間で増加
            _playerattackdamageexp += Random.Range(10, 20);
        }
    }
    public void playerHp()
    {
        //経験値が必要経験値を上回っているか
        if (_playerManager.exp >= _playerHealHpexp)
        {
            //チュートリアルが10段階目以上進んでたら
            if (_gameManager._playerHp != _gameManager._playerMaxHp)
            {
                //プレイヤーのHPを最大まで回復
                _gameManager._playerHp = _gameManager._playerMaxHp;
                //プレイヤーの経験値を必要経験値分マイナス
                _playerManager.exp -= _playerHealHpexp;
                //必要経験値を100～199の間で増加
                _playerHealHpexp += Random.Range(100, 200);
            }
        }
    }
}
