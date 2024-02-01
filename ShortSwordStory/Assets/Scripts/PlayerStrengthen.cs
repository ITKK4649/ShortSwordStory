using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerStrengthen : MonoBehaviour
{
    public bool shopopen;
    GameObject _player;
    private PlayerManager _playerManager;
    [SerializeField]
    private GameManager _gameManager;
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
            _playerexp.text = "EXPF" + _playerManager.exp;
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
        if(_playerManager.exp >= _playerspeedexp)
        {
            if(_tutorial.tutorialtextCount == 10)
            {
                _tutorial.tutorialtextCount++;
            }
            _playerManager.speed += Random.Range(0.01f, 0.04f);
            _playerManager.exp -= _playerspeedexp;
            _playerspeedexp += Random.Range(5,10);
        }
    }
    public void playerAttackspeed()
    {
        if (_playerManager.exp >= _playerattackspeedexp)
        {
            if (_tutorial.tutorialtextCount == 10)
            {
                _tutorial.tutorialtextCount++;
            }
            _gameManager._attackspeed += Random.Range(0.01f, 0.04f);
            _playerManager.exp -= _playerattackspeedexp;
            _playerattackspeedexp += Random.Range(5, 10);
        }
    }
    public void playerAttackDamage()
    {
        if (_playerManager.exp >= _playerattackdamageexp)
        {
            if (_tutorial.tutorialtextCount == 10)
            {
                _tutorial.tutorialtextCount++;
            }
            _gameManager._attackDamage += Random.Range(1, 4);
            _playerManager.exp -= _playerattackdamageexp;
            _playerattackdamageexp += Random.Range(10, 20);
        }
    }
    public void playerHp()
    {
        if (_playerManager.exp >= _playerHealHpexp)
        {
            if(_gameManager._playerHp != _gameManager._playerMaxHp)
            {
                _gameManager._playerHp = _gameManager._playerMaxHp;
                _playerManager.exp -= _playerHealHpexp;
                _playerHealHpexp += Random.Range(100, 200);
            }
        }
    }
}
