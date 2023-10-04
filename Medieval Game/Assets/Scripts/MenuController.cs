using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    public Button startButton; 
    public Button panelButton;
    public Button panelExitButton;
    public Button quitButton; 
    public AudioSource ac;
    public AudioClip btnSfx;
    public AudioClip panelSfx;
    public GameObject controlPanel; 
    public AudioSource au;

    public void LoadScene()
    {
        SceneManager.LoadScene(1); 
        au.PlayOneShot(btnSfx);
    }

    public void OpenPanel()
    {

        controlPanel.SetActive(true); 
        au.PlayOneShot(panelSfx);

    }

    public void ClosePanel()
    {
        controlPanel.SetActive(false); 
        au.PlayOneShot(panelSfx);
    }

    public void QuitGame()
    {
        Application.Quit(); 
        au.PlayOneShot(btnSfx);
    }
}
