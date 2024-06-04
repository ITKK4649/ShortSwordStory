using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
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
        _tutorial = _GameManager.GetComponent<Tutorial>();
        _enemyHp = _gameManager._enemyMaxHp[0];
    }

    // Update is called once per frame
    void Update()
    {
        //現在のプレイヤーの方を常に向く
        transform.LookAt(_player.transform);
        //チュートリアルが5段階目以上進んでたら
        if (_tutorial.tutorialCount >= 5)
        {
            //プレイヤーが強化ショップを開いてなかったら
            if (_playerStrengthen.shopopen == false)
            {
                //現在のプレイヤーの位置に常に移動
                transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z),
                _speed * Time.deltaTime);
            }
        }
        //自身のHPが0になったら
        if (_enemyHp <= 0)
        {
            //自分を削除
            Destroy(this.gameObject);
            //撃破エフェクトを現在の位置に生成
            Instantiate(Death, this.gameObject.transform.position, Quaternion.identity);
            //プレイヤーの経験値をランダムで1～9増やす
            _playerManager.exp += Random.Range(1 * _gameManager._Expboost, 10 * _gameManager._Expboost);
            //倒した数と倒した最大数を増加
            _gameManager._enemyKillCount++;
            _gameManager._enemyKillCountMax++;
        }
        _EnemyHpSlider.value = (float)_enemyHp / (float)_gameManager._enemyMaxHp[0];
        _EnemyHpText.text = _enemyHp + "/" + _gameManager._enemyMaxHp[0];
    }
}
