using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script to control the behaviour of the start button in the <b>StartScene</b>. 
/// </summary>
public class StartButtonScript : MonoBehaviour
{
    public Rigidbody2D startButtonBody;
    public Vector2 startingPosition = new Vector2(0, -0.5f);
    
    /// <summary>
    /// At the start of the scene, move the start button's position to the specified starting position. 
    /// </summary>
    void Start()
    {
        startButtonBody.position = startingPosition;
    }

    /// <summary>
    /// If the start button is left clicked, load <b>GameScene</b>. 
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(sceneName:"GameScene");
        }
    }
}
