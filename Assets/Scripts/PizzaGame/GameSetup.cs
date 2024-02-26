using UnityEngine;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private GameObject toppingBinP, toppingBinS, toppingBinG, toppingBinO;
    
    private void OnEnable()
    {
        SpawnToppingBins();
    }

    private void SpawnToppingBins()
    {
        Instantiate(toppingBinP, new Vector3(-0.5f, 3.4f, 0), Quaternion.identity);
        Instantiate(toppingBinS, new Vector3(2.3f, 3.4f, 0), Quaternion.identity);
        Instantiate(toppingBinG, new Vector3(5.1f, 3.4f, 0), Quaternion.identity);
        Instantiate(toppingBinO, new Vector3(-3.3f, 3.4f, 0), Quaternion.identity);
    }
}
