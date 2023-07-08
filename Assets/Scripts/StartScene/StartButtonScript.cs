using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    public Rigidbody2D startButtonBody;
    public Vector2 startingPosition = new Vector2(0, -0.5f);
    
    void Start()
    {
        startButtonBody.position = startingPosition;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(sceneName:"GameScene");
        }
    }
}
