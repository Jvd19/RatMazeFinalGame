using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Vector2 moveInput;
    public Transform ts;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cheese"))
        {
            Destroy(other.gameObject);
            Win();
        }

        if (other.gameObject.CompareTag("Button"))
        {
            ButtonScript buttonScript = other.gameObject.GetComponent<ButtonScript>();
            {
                buttonScript.GetBumped();
            } 
            
            if (other.gameObject.CompareTag("Boost"))
            {
                Debug.Log("Boost");
                Destroy(other.gameObject);
            }
        }
    }

    void Win()
    {
        SceneManager.LoadScene("You Win!");
    }


// Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();
        rb.velocity = moveInput * moveSpeed;

        switch (moveInput)
        {
            case Vector2 vector when vector.Equals(Vector2.right):
                ts.rotation = Quaternion.Euler(0, 0, -90);
                break;
            case Vector2 vector when vector.Equals(Vector2.left):
                ts.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case Vector2 vector when vector.Equals(Vector2.up):
                ts.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case Vector2 vector when vector.Equals(Vector2.down):
                ts.rotation = Quaternion.Euler(0, 0, -180);
                break;
        }
    }
}
    
