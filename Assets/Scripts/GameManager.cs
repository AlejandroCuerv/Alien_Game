using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject nextLevel;
    [SerializeField] int numAnimals;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }


        }
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void CaptureAnimal()
    {
        numAnimals--;
        if (numAnimals == 0)
        {
            nextLevel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    public void LevelThree()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }


}
