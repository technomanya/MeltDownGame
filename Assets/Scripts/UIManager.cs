using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject GamePanel;

    [SerializeField] Button menuButton;
    [SerializeField] Button playButton;
    [SerializeField] Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(PlayButtonAction);
        menuButton.onClick.AddListener(MenuButtonAction);
        quitButton.onClick.AddListener(QuitButtonAction);
    }

    void PlayButtonAction()
    {
        GameManager.gmInstance.StartGame();
        menuPanel.SetActive(false);
    }

    void MenuButtonAction()
    {
        GameManager.gmInstance.ResetGame();
        menuPanel.SetActive(true);
    }

    void QuitButtonAction()
    {
        Application.Quit();
    }
}
