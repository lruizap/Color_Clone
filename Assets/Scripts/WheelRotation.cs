using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    // Esta velocidad ser� de 100 grados por segundo
    [SerializeField] private float rotationSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        /* 
            Como queremos que la rueda est� girando de forma constante,
            tendremos que ir aplicandole peque�as rotaciones en cada frame
        */

        transform.Rotate(new Vector3(0,0,rotationSpeed * Time.deltaTime));

        /*
            Tendremos que multiplicar por el valor Time.deltaTime 
            (tiempo entre frames) para que se rote siempre a la misma velocidad
            y de esta forma, el juego se ver� igual en todos lados
        */

    }
}
