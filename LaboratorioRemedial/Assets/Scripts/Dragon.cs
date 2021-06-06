using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dragon : MonoBehaviour
{
    [SerializeField] private Vector2 jumpForce;
    [SerializeField] private GameObject firePrefab;    
    [SerializeField] private Text scoreText;
    private int score;

    [SerializeField] private Manager manager;

    // Update is called once per frame
    private void Update()
    {
        // --> Dar un salto por medio del mouse o la tecla de saltar
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            // Para evitar bug de doble fuerza de salto
            if(!manager.IsPaused)
            {
                AudioManager.Play(AudioClipName.SFX_Jump_48);
                GetComponent<Rigidbody2D>().AddForce(jumpForce);
            } 
        }

        // --> Tirar una bola de fuego
        if(Input.GetMouseButtonDown(1))
        {
            AudioManager.Play(AudioClipName.flame);
            var fire = Instantiate(firePrefab,
                transform.position + new Vector3(1,-0.5f,0),
                firePrefab.transform.rotation);
        }

        // --> Revisar el punteo del juego
        scoreText.text = "Score: " + score;
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        AudioManager.Play(AudioClipName.lava);
        Destroy(this.gameObject);  
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Add"))
        {
            score++;        
            AudioManager.Play(AudioClipName.pow);
        }
    }
}
