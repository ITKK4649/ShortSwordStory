using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    public int _playerHp;
    [SerializeField]
    public int _playerMaxHp = 400;
    [SerializeField]
    private Slider _playerHpSlider;
    [SerializeField]
    PlayerManager _playerManager;

    [SerializeField]
    private Tutorial _tutorial;

    public float _attackspeed;
    public int _attackDamage = 10;

    public List<int> _enemyMaxHp = new List<int>();
    public int _enemyKillCount;
    public int _enemyKillCountMax;
    bool Hpup = false;

    [SerializeField]
    private GameObject _enemy;
    private EnemyManager _enemyManager;
    [SerializeField]
    private GameObject _gunenemy;
    private GunEnemyManager _gunenemyManager;
    [SerializeField]
    private GameObject _tpenemy;
    private TpEnemyManager _tpenemyManager;

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
        if(_enemyKillCountMax == 20 && !Hpup)
        {
            _enemyMaxHp[0] += 5;
            Hpup = true;
        }
        if(_enemyKillCount >= 100)
        {
            _playerManager.ultcount++;
            _enemyMaxHp[0] += 10;
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
                _enemyMaxHp[1] += 10;
                _gunenemyManager._speed -= 0.1f;
                _enemyKillCount = 0;
            }
            if (_enemyKillCountMax > 300)
            {
                _enemyMaxHp[1] += 10;
                _gunenemyManager._speed -= 0.1f;
                _enemyMaxHp[2] += 15;
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
