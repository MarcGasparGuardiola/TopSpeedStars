using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogIn : MonoBehaviour
{
    private string mail;
    private string password;
    private Button loginButton;

    public GameObject mailInput;
    public GameObject mailErrorDisplay;

    public GameObject passwordInput;
    public GameObject passwordErrorDisplay;

    

    void Start()
    {
        //Subscribe to onClick event
        loginButton.onClick.AddListener(logIn);
        DontDestroyOnLoad(GameObject.Find("BBDD_Manager"));

        CreateGPXFolder();
    }

    Dictionary<string, string> userDetails = new Dictionary<string, string>
    {
        {"jordi.G@gmail.com","jg2022" },
        {"marc.G@gmail.com","mg2022" },
        {"jordi.O@gmail.com" ,"jo2022" }
    };

    public void logIn()
    {
        string mail = mailInput.GetComponent<InputField>().text;
        string password = passwordInput.GetComponent<InputField>().text;

        string foundPassword;
        if (userDetails.TryGetValue(mail, out foundPassword) && (foundPassword == password))
        {
            Debug.Log("User authenticated");
        }
        else
        {
            Debug.Log("Invalid password");
        }

        //BBDD baseDades = new BBDD();



    }

    public void goToCreateUserScene() 
    {
        SceneManager.LoadScene(sceneName: "CreateUser");
    }

    public void goToMainPage()
    {
        SceneManager.LoadScene(sceneName: "MainPage");
    }

    void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            logIn();
        }
    }

    private void CreateGPXFolder()
    {
        // Specify the directory you want to manipulate.
        string path = Path.Combine(Application.dataPath, "GPX");

        try
        {
            // Determine whether the directory exists.
            if (Directory.Exists(path))
            {
                Debug.Log("That path exists already.");

            }
            else
            {
                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                Debug.Log("Carpeta creada");
            }
        }
        catch (Exception e)
        {

        }
        finally { }

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
