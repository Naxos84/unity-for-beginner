using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public GameObject score;
    int points = 0;
    public Text pointsDisplay;
    int lifes = 3;
    public Text lifesDisplay;
    float speed = 10.0f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Score")
        {
            points++;
            if (points < 6)
            {
                pointsDisplay.text = "Punkte: " + points;
            } else
            {
                gameObject.SetActive(false);
                score.SetActive(false);
                pointsDisplay.text = "Gewonnen";
            }
            float xNew = Random.Range(-8.0f, 8.0f);
            float yNew = -2.7f;
            score.transform.position = new Vector3(xNew, yNew, 0);
        } else if (collision.gameObject.tag == "Danger")
        {
            lifes--;
            lifesDisplay.text = "Lifes: " + lifes;
            gameObject.SetActive(false);
            if (lifes > 0)
            {
                Invoke("NextLife", 2);
            } else
            {
                score.SetActive(false);
                lifesDisplay.text = "Verloren";
            }
        }
    }

    void NextLife()
    {
        transform.position = new Vector3(0, -4.4f, 0);
        gameObject.SetActive(true);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        if (yInput < 0)
        {
            return;
        }

        float newPositionX = transform.position.x + xInput * speed * Time.deltaTime;

        Mathf.Clamp(newPositionX, -8.3f, 8.3f);

        float newPositionY = transform.position.y + yInput * speed * Time.deltaTime;

        transform.position = new Vector3(newPositionX, newPositionY, 0);
    }
}
