using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunEnemyManager : MonoBehaviour
{
    public float _speed;
    private GameObject _player;
    private PlayerStrengthen _playerStrengthen;
    private PlayerManager _playerManager;
    private GameObject _GameManager;
    private GameManager _gameManager;
    public int _gunenemyHp;
    [SerializeField]
    private Slider _EnemyHpSlider;
    [SerializeField]
    private Text _EnemyHpText;
    public bool heal = false;
    [SerializeField] 
    GameObject Enemybullet;
    private float EnemybulletSpeed = 10.0f;
    private float time = 5.0f;
    [SerializeField]
    private GameObject Death;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerStrengthen = _player.GetComponent<PlayerStrengthen>();
        _playerManager = _player.GetComponent<PlayerManager>();
        _GameManager = GameObject.Find("GameManager");
        _gameManager = _GameManager.GetComponent<GameManager>();
        _gunenemyHp = _gameManager._enemyMaxHp[1];
        _speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerStrengthen.shopopen == false)
        {
            transform.LookAt(_player.transform);
            transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z),
            _speed * Time.deltaTime);
            if (_gunenemyHp <= 0)
            {
                Destroy(this.gameObject);
                Instantiate(Death, this.gameObject.transform.position, Quaternion.identity);
                _playerManager.exp += Random.Range(1, 10);
                _gameManager._enemyKillCount++;
                _gameManager._enemyKillCountMax++;
            }
            _EnemyHpSlider.value = (float)_gunenemyHp / (float)_gameManager._enemyMaxHp[1];
            _EnemyHpText.text = _gunenemyHp + "/" + _gameManager._enemyMaxHp[1];
            time -= Time.deltaTime;
            if (time <= 0)
            {
                BallShot();
                time = 5.0f;
            }
        }
    }
    void BallShot()
    {
        GameObject shotObj = Instantiate(Enemybullet, transform.position, Quaternion.identity);
        shotObj.GetComponent<Rigidbody>().velocity = transform.forward * EnemybulletSpeed;
    }
}
