using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    PlayerStrengthen _playerStrengthen;
    [SerializeField]
    Tutorial _tutorial;
    [SerializeField]
    private GameManager _gameManager;
    //ˆÚ“®—p•Ï”
    float x, z;
    public GameObject cam;
    bool cursorLock = true;
    Quaternion cameraRot, characterRot;
    public int exp;
    float minX = -90f, maxX = 90f;
    float Xsensityvity = 3f, Ysensityvity = 3f;

    [SerializeField]
    private GameObject ults;
    public int ultcount = 0;
    // Start is called before the first frame update
    void Start()
    {
        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (_tutorial.tutorialCount >= 2)
        {
            if (_playerStrengthen.shopopen == false)
            {
                float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
                float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

                cameraRot *= Quaternion.Euler(-yRot, 0, 0);
                characterRot *= Quaternion.Euler(0, xRot, 0);

                cameraRot = ClampRotation(cameraRot);

                cam.transform.localRotation = cameraRot;
                transform.localRotation = characterRot;
            }
            if (Input.GetKeyDown(KeyCode.Space) && ultcount >= 1)
            {
                GameObject ult = Instantiate(ults, transform.position, Quaternion.identity);
                Destroy(ult, 2f);
                ultcount--;
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                exp += 1000;
            }
        }
    }
    private void FixedUpdate()
    {
        if (_tutorial.tutorialCount >= 1)
        {
            if (_playerStrengthen.shopopen == false)
            {
                x = 0;
                z = 0;

                x = Input.GetAxisRaw("Horizontal") * speed;
                z = Input.GetAxisRaw("Vertical") * speed;

                Vector3 camForward = cam.transform.forward;
                camForward.y = 0;


                //transform.position += new Vector3(x, 0, z);
                transform.position += camForward * z + cam.transform.right * x;
            }
        }
    }
    public void UpdateCursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        else if (Input.GetMouseButton(0))
        {
            cursorLock = true;

        }
        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;

        }
        else if (!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public Quaternion ClampRotation(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;
        angleX = Mathf.Clamp(angleX, minX, maxX);
        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_playerStrengthen.shopopen == false)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                _gameManager._playerHp--;
            }
            if (other.gameObject.CompareTag("GunEnemy"))
            {
                _gameManager._playerHp--;
            }
            if (other.gameObject.CompareTag("EnemyBullet"))
            {
                _gameManager._playerHp -= 10;
                Destroy(other.gameObject);
            }
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (_playerStrengthen.shopopen == false)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                _gameManager._playerHp--;
            }
            if (other.gameObject.CompareTag("GunEnemy"))
            {
                _gameManager._playerHp--;
            }
            if (other.gameObject.CompareTag("EnemyBullet"))
            {
                _gameManager._playerHp -= 10;
                Destroy(other.gameObject);
            }
        }
    }
}