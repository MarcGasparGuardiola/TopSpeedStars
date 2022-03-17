using UnityEngine;

public class Token: MonoBehaviour
{
    public string token;

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void setToken(string response) { 
        string[] splited = response.Split(',');
        foreach (var item in splited)
        {
            if (item.Contains("access_token")) {
                token = item.Split(':')[1];
                break;
            }
        }
    }
}

