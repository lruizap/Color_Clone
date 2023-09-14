using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        // Si la posici�n del jugador en y es mayor a la posici�n de la c�mara en y

        if (playerTransform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x , playerTransform.position.y , transform.position.z);
        }
    }
}
