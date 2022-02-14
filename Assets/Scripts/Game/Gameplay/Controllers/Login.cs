using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Gameplay.actors;

public class Login : MonoBehaviour
{
    private string mail;
    private string password;
    private Button loginButton;

    public GameObject mailInput;
    public GameObject passwordInput;

    public GameObject invalidCredencialsMessage;    

    void Start()
    {
        //Subscribe to onClick event
        //loginButton.onClick.AddListener(logIn);
        //DontDestroyOnLoad(GameObject.Find("BBDD_Manager"));
        invalidCredencialsMessage.SetActive(false);
    }

    Dictionary<string, string> userDetails = new Dictionary<string, string>
    {
        {"jordi.G@gmail.com","jg2022" },
        {"marc.G@gmail.com","mg2022" },
        {"jordi.O@gmail.com" ,"jo2022" }
    };

    public void logIn()

    {
        invalidCredencialsMessage.SetActive(false);
        string mail = mailInput.GetComponent<InputField>().text;
        string password = passwordInput.GetComponent<InputField>().text;

        Debug.Log("Hola");

        StartCoroutine(logInRequest("https://topspeedstarsapi.herokuapp.com/api/login", mail, password));
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

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator logInRequest(string uri, string email, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("password", password);

        using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
        {
            yield return www.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (www.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + www.error);
                    invalidCredencialsMessage.SetActive(false);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + www.error);
                    invalidCredencialsMessage.SetActive(false);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + www.downloadHandler.text);
                    Token token = GameObject.Find("Token").GetComponent<Token>();
                    token.setToken(www.downloadHandler.text);
                    break;
            }
        }
    }
}
