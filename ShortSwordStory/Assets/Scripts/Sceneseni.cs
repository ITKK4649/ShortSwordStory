using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Sceneseni : MonoBehaviour
{
    int SceneNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Title()
    {
        SceneNumber = 0;
        SceneManager.LoadScene(SceneNumber);
    }

    public void Tutorial()
    {
        SceneNumber = 1;
        SceneManager.LoadScene(SceneNumber);
    }

    public void MainGame()
    {
        SceneNumber = 2;
        SceneManager.LoadScene(SceneNumber);
    }
}
