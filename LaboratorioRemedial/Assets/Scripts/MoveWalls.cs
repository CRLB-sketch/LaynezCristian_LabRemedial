using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWalls : MonoBehaviour
{
    [SerializeField] private float velocity;
    
    /// <summary>
    /// Update es llamada por cada frame.
    /// </summary>
    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * velocity);

        if(transform.position.x < -20)
        {
            transform.position += new Vector3(30, 0, 0);
            CreateFireWalls();
        }
    }

    /// <summary>
    /// Crear los obstaculos (paredes de fuego) aleatoriamente .
    /// </summary>
    private void CreateFireWalls()
    {
        int numberRandom = UnityEngine.Random.Range(0,3);
        for(int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            bool createChild = numberRandom == i;
            child.gameObject.SetActive(createChild);
        }
    }

    /// <summary>
    /// Esta función es llamada cuando el objeto se habilita.
    /// </summary>
    private void OnEnable()
    {
        CreateFireWalls();
    }
}
