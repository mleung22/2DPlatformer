using UnityEngine;
using System.Collections;

public class LeaderBoard : MonoBehaviour {

    // Database Stored Here http://dreamlo.com/lb/WMFDtwf63UGRPZBlpqI12QQQFgI1WdE0KxaEriww22qw

    const string privateCode = "WMFDtwf63UGRPZBlpqI12QQQFgI1WdE0KxaEriww22qw";
    const string publicCode = "5641408b6e51b61b8cb4c6f6";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoresList;
    static LeaderBoard instance;
    Display_LeaderBoard highscoresDisplay;

    void Awake()
    {
        highscoresDisplay = GetComponent<Display_LeaderBoard>();
        instance = this;
    }


    public static void AddNewHighscore(string username, int score)
    {
        instance.StartCoroutine(instance.UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            DownloadHighScores();
        }
        else
        {
            print("Error Uploading" + www.error);
        }
    }

    public void DownloadHighScores()
    {
        StartCoroutine("DownloadNewHighscore");
    }

    IEnumerator DownloadNewHighscore()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighScores(www.text);
            highscoresDisplay.OnHighscoresDownloaded(highscoresList);
        }
        else
        {
            print("Error Downloading" + www.error);
        }
    }

    void FormatHighScores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];

        for ( int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
            
        }
    }
}

public struct Highscore
{
    public string username;
    public int score;

    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}
