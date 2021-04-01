using UnityEngine;

public class bluedude : MonoBehaviour
{
    [SerializeField]
    private GameObject _cloudParticlePrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when bird hit bluedude, bluedude disappear
        Greenbird bird = collision.collider.GetComponent<Greenbird>();
        if (bird != null)
        {
            //spawn cloud on bluedude disappear
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        //when bluedude touch each other, do nothing
        bluedude bluedude = collision.collider.GetComponent<bluedude>();
        if (bluedude != null)
        {
            return;
        }

        //first collision contact, bluedude appear when something hit from above
        if (collision.contacts[0].normal.y < -0.5)
        {
            //spawn cloud on bluedude disappear
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
    }
}
