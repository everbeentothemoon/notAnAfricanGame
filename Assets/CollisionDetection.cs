using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Player collided with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("AmmitComplete"))
        {
            SceneManager.LoadScene("2D_Ammit");
            //TakeDamage(collision.gameObject.GetComponent<Enemy>().damage);

            //Debug.Log("Player Health: " + health);
        }
        else if (collision.gameObject.CompareTag("NinkiNankaComplete"))
        {
            SceneManager.LoadScene("2D_NinkiNanka");
            //TakeDamage(2);
        }
        else if (collision.gameObject.CompareTag("TokolosheComplete"))
        {
            SceneManager.LoadScene("2D_Tokoloshe");
            // TakeDamage(10);
        }
        else if (collision.gameObject.CompareTag("MokeleMbembeComplete"))
        {
            SceneManager.LoadScene("2D_MokeleMbembe");
            // TakeDamage(6);
        }
        else if (collision.gameObject.CompareTag("JenguComplete"))
        {
            SceneManager.LoadScene("2D_Jengu");
            //Destroy(collision.gameObject);
            // keys++;
        }
    }
}
