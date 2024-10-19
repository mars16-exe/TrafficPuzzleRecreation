using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelMenu;
    private AudioSource selectSFX;

    private void Awake()
    {
        selectSFX = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        selectSFX.Play();
    }

    public void LevelSelect()
    {
        selectSFX.Play();

        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }

    public void EXIT()
    {
        selectSFX.Play();

        Application.Quit();
    }

    public void BackBTN()
    {
        selectSFX.Play();

        levelMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void LoadLevel(int levelNumber)
    {
        selectSFX.Play();

        SceneManager.LoadScene(levelNumber);
    }
}
