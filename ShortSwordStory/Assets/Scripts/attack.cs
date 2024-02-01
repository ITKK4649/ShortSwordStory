using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class attack : MonoBehaviour
{
    [SerializeField]
    PlayerStrengthen _playerStrengthen;
    [SerializeField]
    Tutorial _tutorial;
    GameObject ken;
    [SerializeField]
    private List<GameObject> _sword = new List<GameObject>();
    public int attackcount;
    Vector3 attackpos;
    public bool scAttack = false;
    public bool frist = false;
    public Coroutine _secondaAttack;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_tutorial.tutorialCount >= 3)
        {
            if (_playerStrengthen.shopopen == false)
            {
                attackpos = this.transform.position;
                if (Input.GetMouseButtonDown(0))
                {
                    if (attackcount == 0)
                    {
                        attackcount++;
                        ken = Instantiate(_sword[0], attackpos, Quaternion.identity);
                        ken.transform.parent = this.transform;
                    }
                    else if (attackcount == 1 && scAttack)
                    {
                        attackcount++;
                        StopCoroutine(_secondaAttack);
                        ken = Instantiate(_sword[1], attackpos, Quaternion.identity);
                        ken.transform.parent = this.transform;
                    }
                }
            }
        }
        if (frist && attackcount == 1)
        {
            _secondaAttack = StartCoroutine(SecondAttack());
        }
    }

    public IEnumerator SecondAttack()
    {
        frist = false;
        scAttack = true;
        yield return new WaitForSeconds(1.5f);
        scAttack = false;
        if (attackcount == 1)
        {
            attackcount = 0;
        }
    }
}
