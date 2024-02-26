using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;
using System.Collections;

public class GameSelectorScript : MonoBehaviour
{
    string path = "Assets\\GameSelect.txt";
    string gameSelection;
    
    void Start()
    {
        using (FileStream fs = File.OpenRead(path)) 
        {
            byte[] b = new byte[1024];
            UTF8Encoding text = new UTF8Encoding(true);
            gameSelection = text.GetString(b, 0, fs.Read(b, 0, b.Length));
        }

        switch (gameSelection) 
        {
            case "pizza":
                StartCoroutine(LoadAsyncScene("PizzaGame"));
                break;
        }
    }

    /*
        Copied from Unity documentation for asynchronous scene loading. 
    */
    IEnumerator LoadAsyncScene(string game)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(game);
        while (!asyncLoad.isDone) yield return null;
    }
}
