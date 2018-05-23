using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu1 : MonoBehaviour {
    public Button button;
    public Sprite image;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);   
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Exited");
    }
   public void ImageChange()
    {
        button = GetComponent<Button>();
        image = GetComponent<Sprite>();
        button.image.enabled = false;
        Debug.Log("Changed");
    }
}
