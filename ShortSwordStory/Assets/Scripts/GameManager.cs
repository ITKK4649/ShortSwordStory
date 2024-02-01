using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private Tutorial _tutorial;
    public float _attackspeed;
    public int _attackDamage = 10;
    public int _playerHp;
    [SerializeField]
    public int _playerMaxHp = 400;
    public int _enemyMaxHp = 10;
    public int _gunenemyMaxHp = 20;
    public int _tpenemyMaxHp = 30;
    public int _enemyKillCount;
    public int _enemyKillCountMax;
    [SerializeField]
    private Slider _playerHpSlider;
    [SerializeField]
    private GameObject _enemy;
    private EnemyManager _enemyManager;
    [SerializeField]
    private GameObject _gunenemy;
    private GunEnemyManager _gunenemyManager;
    [SerializeField]
    private GameObject _tpenemy;
    private TpEnemyManager _tpenemyManager;
    [SerializeField]
    PlayerManager _playerManager;
    bool playercooltimeset = false;
    // Start is called before the first frame update
    void Start()
    {
        _enemyManager = _enemy.GetComponent<EnemyManager>();
        _gunenemyManager = _gunenemy.GetComponent<GunEnemyManager>();
        _tpenemyManager = _tpenemy.GetComponent<TpEnemyManager>();
        _playerHp = _playerMaxHp;
        _enemyManager._speed = 1f;
        _gunenemyManager._speed = 1f;
        _tpenemyManager._speed = 1f;
        playercooltimeset = true; 
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            _tutorial.tutorialCount = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }
        if(_enemyKillCount >= 100)
        {
            _playerManager.ultcount++;
            _enemyMaxHp += 10;
            if(_enemyManager._speed < 10f)
            {
                _enemyManager._speed += 0.5f;
            }
            if( _enemyKillCountMax <= 200 ) 
            {
                _enemyKillCount = 0;
            }
            if (_enemyKillCountMax > 200 && _enemyKillCountMax <= 300)
            {
                _gunenemyMaxHp += 10;
                _gunenemyManager._speed -= 0.1f;
                _enemyKillCount = 0;
            }
            if (_enemyKillCountMax > 300)
            {
                _gunenemyMaxHp += 10;
                _gunenemyManager._speed -= 0.1f;
                _tpenemyMaxHp += 15;
                _tpenemyManager._speed += 0.2f;
                _enemyKillCount = 0;
            }
        }
        _playerHpSlider.value = (float)_playerHp / (float)_playerMaxHp;
        if(_playerHpSlider.value <= 0)
        {
            Destroy(_player);
            SceneManager.LoadScene("GameOver");
        }
    }
}
