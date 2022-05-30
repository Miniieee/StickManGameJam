using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private CharacterActionControl characterActionControl;

    [SerializeField] GameObject exitCanvas;
    [SerializeField] GameObject wonCanvas;

    void Awake()
    {
        DontDestroyOnLoad(this);
        characterActionControl = new CharacterActionControl();
    }

    private void Start()
    {
        wonCanvas.SetActive(false);
    }

    public void ResetScene()
    {
        StartCoroutine(ResetThis());
    }

    IEnumerator ResetThis()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void WinGame()
    {
        StartCoroutine(WinTheGame());
    }


    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    IEnumerator WinTheGame()
    {
        yield return new WaitForSeconds(1f);

        wonCanvas.SetActive(true);
        Time.timeScale = 0f;

        Debug.Log("you won");
    }



    private void OnEnable()
    {
        characterActionControl.Enable();
    }

    private void OnDisable()
    {
        characterActionControl.Disable();
    }

}
