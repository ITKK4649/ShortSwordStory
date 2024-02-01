using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TpEnemyManager : MonoBehaviour
{
    public float _speed;
    private GameObject _player;
    private PlayerStrengthen _playerStrengthen;
    private PlayerManager _playerManager;
    private GameObject _GameManager;
    private GameManager _gameManager;
    public int _tpenemyHp;
    public int _tpCount;
    [SerializeField]
    private Slider _EnemyHpSlider;
    [SerializeField]
    private Text _EnemyHpText;
    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform tpRangeA;
    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform tpRangeB;
    public bool heal = false;
    private float _tpTime;
    public float _tpTimeMax = 1f;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerStrengthen = _player.GetComponent<PlayerStrengthen>();
        _playerManager = _player.GetComponent<PlayerManager>();
        _GameManager = GameObject.Find("GameManager");
        _gameManager = _GameManager.GetComponent<GameManager>();
        _tpenemyHp = _gameManager._tpenemyMaxHp;
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
            // 前フレームからの時間を加算していく
            _tpTime = _tpTime + Time.deltaTime;

            // 約1秒置きにランダムに生成されるようにする。
            if (_tpTime > _tpTimeMax)
            {
                // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
                float x = Random.Range(tpRangeA.position.x, tpRangeB.position.x);
                // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
                float z = Random.Range(tpRangeA.position.z, tpRangeB.position.z);
                // GameObjectを上記で決まったランダムな場所に生成
                this.transform.position = new Vector3(x, this.transform.position.y, z);
                _tpTimeMax = Random.Range(2, 5);
                // 経過時間リセット
                _tpTime = 0f;
            }
        }
        if (_tpenemyHp <= 10 && _tpenemyHp != 0 && _tpCount == 0)
        {
            float x = Random.Range(tpRangeA.position.x, tpRangeB.position.x);
            // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
            float z = Random.Range(tpRangeA.position.z, tpRangeB.position.z);
            // GameObjectを上記で決まったランダムな場所に生成
            this.transform.position = new Vector3(x, this.transform.position.y, z);
            _tpCount++;
        }
        if (_tpenemyHp <= 0)
        {
            Destroy(this.gameObject);
            _playerManager.exp += Random.Range(1, 10);
            _gameManager._enemyKillCount++;
            _gameManager._enemyKillCountMax++;
        }
        _EnemyHpSlider.value = (float)_tpenemyHp / (float)_gameManager._enemyMaxHp;
        _EnemyHpText.text = _tpenemyHp + "/" + _gameManager._enemyMaxHp;
    }

}
