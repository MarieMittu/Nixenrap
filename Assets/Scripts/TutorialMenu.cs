using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMenu : MonoBehaviour
{
    [SerializeField] GameObject tutorialMenu;

    public void OpenTutorial()
    {
        tutorialMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseTutorial()
    {
        tutorialMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
