using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;

    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
        Destroy(this.gameObject, 2);
    }
    
}
