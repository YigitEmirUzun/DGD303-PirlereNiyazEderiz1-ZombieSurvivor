using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public bool right, up = true;
    public Animator animator;
    public bool isWalking = false;
    public bool horizontal , vertical;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Direction();
        if (Input.GetKeyDown(KeyCode.D))
        {
            right = true;
            horizontal = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            right = false;
            horizontal = true;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            up = true;
            vertical = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            up = false;
            vertical = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            isWalking = true;
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            horizontal = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            isWalking = true;
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            horizontal = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            isWalking = true;
            transform.Translate(new Vector3(0,speed * Time.deltaTime, 0));
            vertical = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            isWalking = true;
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
            vertical = true;
        }

        if(Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
        {
            isWalking = false;
            vertical = false;
        }
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            isWalking = false;
            horizontal = false;
        }



    }

    public void Direction()
    {
        if (right)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        animator.SetBool("right", right);
        animator.SetBool("up",up);
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("horizontal",horizontal);
        animator.SetBool("vertical", vertical);


    }
}
