using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject _menuCanvas;
    [SerializeField]
    private GameObject _HpCanvas;
    [SerializeField]
    private PlayerStrengthen _playerStrengthen;
    [SerializeField]
    private PlayerManager _playerManger;
    [SerializeField]
    private GameManager _gameManger;
    [SerializeField]
    private EnemySp _EnemySp;
    [SerializeField]
    private GameObject _statuspanel;
    int SceneNumber;
    public bool _menuopenset;
    [SerializeField]
    private List<Text> _playerstatus = new List<Text>();
    // Start is called before the first frame update
    void Start()
    {
        _menuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerStrengthen.shopopen == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _menuCanvas.SetActive(true);
                _HpCanvas.SetActive(false);
                _statuspanel.SetActive(false);
                _playerStrengthen.shopopen = true;
                Cursor.visible = true;
                _menuopenset = true;
            }
        }
    }
    public void Status()
    {
        _statuspanel.SetActive(true);
        _playerstatus[0].text = "" + _gameManger._attackspeed;
        _playerstatus[1].text = "" + _gameManger._attackDamage;
        _playerstatus[2].text = "" + _playerManger.speed;
        _playerstatus[3].text = "" + _EnemySp.timeMax;
        _playerstatus[4].text = "" + _playerManger.ultcount;
    }
    public void Back_to_Game()
    {
        _menuCanvas.SetActive(false);
        _HpCanvas.SetActive(true);
        _playerStrengthen.shopopen = false;
        Cursor.visible = false;
        _menuopenset = false;
    }
    public void Back_to_Title()
    {
        SceneNumber = 0;
        SceneManager.LoadScene(SceneNumber);
        Cursor.visible = true;
        _menuopenset = false;
    }
    public void GameEnd()
    {
        Application.Quit();
    }
}
