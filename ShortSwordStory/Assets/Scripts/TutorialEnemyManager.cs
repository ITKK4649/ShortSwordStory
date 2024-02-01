using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialEnemyManager : MonoBehaviour
{
    public float _speed;
    private GameObject _player;
    private PlayerStrengthen _playerStrengthen;
    private PlayerManager _playerManager;
    private GameObject _GameManager;
    private GameManager _gameManager;
    private Tutorial _tutorial;
    public int _enemyHp;
    [SerializeField]
    private Slider _EnemyHpSlider;
    [SerializeField]
    private Text _EnemyHpText;
    public bool heal = false;
    // Start is called before the first frame update
    void Start()
    {
        _enemyHp = 4;
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerStrengthen = _player.GetComponent<PlayerStrengthen>();
        _playerManager = _player.GetComponent<PlayerManager>();
        _GameManager = GameObject.Find("GameManager");
        _gameManager = _GameManager.GetComponent<GameManager>();
        _tutorial = _GameManager.GetComponent<Tutorial>();
        _enemyHp = _gameManager._enemyMaxHp;
        _speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_player.transform);
        if (_tutorial.tutorialCount >= 5)
        {
            if (_playerStrengthen.shopopen == false)
            {
                transform.LookAt(_player.transform);
                transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z),
                _speed * Time.deltaTime);
            }
        }
        if (_enemyHp <= 0)
        {
            _playerManager.exp += Random.Range(100, 100);
            _gameManager._enemyKillCount++;
            _gameManager._enemyKillCountMax++;
            _tutorial.tutorialtextCount++;
            _tutorial.objects[0].SetActive(true);
            Destroy(this.gameObject);
        }
        _EnemyHpSlider.value = (float)_enemyHp / (float)_gameManager._enemyMaxHp;
        _EnemyHpText.text = _enemyHp + "/" + _gameManager._enemyMaxHp;
    }
}
