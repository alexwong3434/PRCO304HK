using UnityEngine;
using UnityEngine.SceneManagement;

public class Greenbird : MonoBehaviour
{
    //bird starting position
    private Vector3 _initialPosition;
    //gravity on/off
    private bool _birdWasLaunched;
    //bird idle time
    private float _timeSittingAround;

    //bird launch power
    [SerializeField]
    private float _launchPower = 250;

    /// <summary>
    /// set bird starting position on GameObject awake
    /// </summary>
    private void Awake()
    {
        _initialPosition = transform.position;
    }

    /// <summary>
    /// if bird go beyond screen position or idle and then scene reset
    /// </summary>
    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(1, transform.position);

        if (_birdWasLaunched &&
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }

        if (transform.position.x > 10 || 
            transform.position.x < -10 || 
            transform.position.y > 6 || 
            transform.position.y < -5 ||
            _timeSittingAround > 3)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    /// <summary>
    /// mouse click on bird
    /// </summary>
    private void OnMouseDown()
    {
        //change bird color to red
        GetComponent<SpriteRenderer>().color = Color.red;

        GetComponent<LineRenderer>().enabled = true;
    }

    /// <summary>
    /// mouse release on bird
    /// </summary>
    private void OnMouseUp()
    {
        //change bird color back to white
        GetComponent<SpriteRenderer>().color = Color.white;

        //throw bird with opposite of initialPosition (distance) and x times faster
        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);

        //set gravity to make bird fly and roll
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunched = true;

        GetComponent<LineRenderer>().enabled = false;
    }

    /// <summary>
    /// move bird on mouse drag
    /// </summary>
    private void OnMouseDrag()
    {
        //set x,y position of mouse position
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //set newposition x ,y to bird transform and set z to 0, make bird on front of wallpaper
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
