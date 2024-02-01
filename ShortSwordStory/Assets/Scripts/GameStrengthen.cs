using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameStrengthen : MonoBehaviour
{
    public bool shopopen;
    GameObject _player;
    private PlayerManager _playerManager;
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private GameObject _exCanvas;
    private int fristexp = 10;
    private int _enemySpTimeExp;
    private int _playerultexp;
    private int _playerattackdamageexp;
    private int _playerHealHpexp;
    [SerializeField]
    private List<int> _level;
    [SerializeField]
    private List<int> _levelMax;
    [SerializeField]
    private EnemySp _enemySp;
    [SerializeField]
    Text _Gameexp;
    [SerializeField]
    private List<Text> _Gamestreng = new List<Text>();
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _playerManager = _player.GetComponent<PlayerManager>();
        _enemySpTimeExp = fristexp;
        _playerultexp = fristexp * 50;
        _playerattackdamageexp = fristexp;
    }

    // Update is called once per frame
    void Update()
    {
        _Gamestreng[0].text = "" + _enemySpTimeExp;
        _Gamestreng[1].text = "EnemySpTimeLv:" + _level[0];
        _Gamestreng[2].text = "EnemySpTimeLvMax:" + _levelMax[0];
        _Gamestreng[3].text = "" + _playerultexp;
        _Gameexp.text = "EXPF" + _playerManager.exp;
    }

    public void enemySpTime()
    {
        if(_playerManager.exp >= _enemySpTimeExp && _level[0] < _levelMax[0])
        {
            _enemySp.timeMax -= Random.Range(0.01f, 0.06f);
            _playerManager.exp -= _enemySpTimeExp;
            _enemySpTimeExp += Random.Range(10,20);
            _level[0]++;
        }
    }
    public void playerUlt()
    {
        if (_playerManager.exp >= _playerultexp)
        {
            _playerManager.ultcount++;
            _playerManager.exp -= _playerultexp;
            _playerultexp += Random.Range(500, 1000);
        }
    }
    public void playerAttackDamage()
    {
        if (_playerManager.exp >= _playerattackdamageexp)
        {
            _gameManager._attackDamage += Random.Range(1, 4);
            _playerManager.exp -= _playerattackdamageexp;
            _playerattackdamageexp += Random.Range(10, 20);
        }
    }
}
