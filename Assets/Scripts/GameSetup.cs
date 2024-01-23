using UnityEngine;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private GameObject toppingBinP, toppingBinS, toppingBinG, toppingBinO;
    [SerializeField] private GameEvent startGameLoop;
    
    private void Start()
    {
        GetScreenSize();
        SpawnToppingBins();
        startGameLoop.TriggerEvent();
    }

    // to do: figure out a way to get these values to every object (and how to set positions based on this ratio) 
    private void GetScreenSize()
    {
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
    }

    private void SpawnToppingBins()
    {
        Instantiate(toppingBinP, new Vector3(-0.5f, 3.4f, 0), Quaternion.identity);
        Instantiate(toppingBinS, new Vector3(2.3f, 3.4f, 0), Quaternion.identity);
        Instantiate(toppingBinG, new Vector3(5.1f, 3.4f, 0), Quaternion.identity);
        Instantiate(toppingBinO, new Vector3(-3.3f, 3.4f, 0), Quaternion.identity);
    }
}
