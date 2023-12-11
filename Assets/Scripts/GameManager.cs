using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject showInstructions;
    bool instructionsActive;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowInstructions());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
        if (Input.GetKeyDown(KeyCode.Q) && !instructionsActive)
        {
            StartCoroutine(ShowInstructions());
            instructionsActive = true;
        }

    }
    IEnumerator ShowInstructions()
    {
        showInstructions.SetActive(true);
        yield return new WaitForSeconds(5);
        showInstructions.SetActive(false);
        instructionsActive = false;
    }

    void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
