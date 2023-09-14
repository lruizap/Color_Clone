using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float verticalForce = 400f;
    [SerializeField] private float restartDelay = 1f;

    [SerializeField] private ParticleSystem playerParticles;

    [SerializeField] private Color orangeColor;
    [SerializeField] private Color violetColor;
    [SerializeField] private Color cyanColor;
    [SerializeField] private Color pinkColor;

    // Variable para asignar el color actual
    private string currentColor;

    Rigidbody2D playerRB;
    SpriteRenderer playerSR;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();

        playerSR = GetComponent<SpriteRenderer>();

        ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.velocity = Vector2.zero;
            playerRB.AddForce(new Vector2(0, verticalForce));
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Colisión con: " + collision.gameObject.name);
    //    collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColorChanger"))
        {
            ChangeColor();

            // Destruimos el objeto de la escena
            Destroy(collision.gameObject);

            return;
        }

        if (collision.gameObject.CompareTag("FinishLine"))
        {
            // Desactivamos el objeto
            gameObject.SetActive(false);
            // Partículas
            Instantiate(playerParticles, transform.position, Quaternion.identity);
            // Cargamos la siguiente escena
            Invoke("LoadNextScene", restartDelay);

            return;
        }

        if (!collision.gameObject.CompareTag(currentColor))
        {
            // Desactivar al jugador
            gameObject.SetActive(false);
            // Partículas
            Instantiate(playerParticles, transform.position, Quaternion.identity);
            // Reiniciar
            Invoke(nameof(RestartScene), restartDelay);
        }
    }

    void LoadNextScene()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Pasar a la siguiente escena
        SceneManager.LoadScene(activeSceneIndex + 1);
    }

    void RestartScene()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Reiniciar la escena activa
        SceneManager.LoadScene(activeSceneIndex);
    }

    void ChangeColor()
    {
        int randomNumber = Random.Range(0, 4);

        switch (randomNumber)
        {
            case 0:
                playerSR.color = orangeColor;
                currentColor = "Orange";
                break;
            case 1:
                playerSR.color = violetColor;
                currentColor = "Violet";
                break;
            case 2:
                playerSR.color = cyanColor;
                currentColor = "Cyan";
                break;
            default:
                playerSR.color = pinkColor;
                currentColor = "Pink";
                break;
        }
    }

}
