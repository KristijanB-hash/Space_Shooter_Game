using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Barier : MonoBehaviour
{
    public float speed;

    private void Awake()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Random.Range(-3.3f, 3.3f);
        transform.position = newPosition;
    }


    private void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.y -= speed * Time.deltaTime;
        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            //Debug.Log("hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
