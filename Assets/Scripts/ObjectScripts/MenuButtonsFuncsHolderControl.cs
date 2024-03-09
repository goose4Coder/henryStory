using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButtonsFuncsHolderControl : MonoBehaviour
{
    // Start is called before the first frame update
    public void QuitGame()
    { 
        Application.Quit();
    }

    public void PlayGame() 
    {
        SceneManager.LoadScene("EntranceScene");
    }

    // Update is called once per frame
}
