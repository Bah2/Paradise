using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player_Move : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float turnSpeed = 50f;
    public float gravity = -10;
    private Rigidbody rb;
    bool WalkActive = false;
   // bool RunActive = false;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    public Animator anim;
    public GameObject walkanimcube;
    public GameObject idleanimcube;
    public GameObject idledude;
    // public GameObject runninganimcube;
    // public GameObject runningdude;
    SkinnedMeshRenderer renderwalk;
    SkinnedMeshRenderer renderidle;
    // SkinnedMeshRenderer renderrunning;

    public bool run;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        renderwalk = walkanimcube.GetComponentInChildren<SkinnedMeshRenderer>();
        renderwalk.enabled = false;

        renderidle = idleanimcube.GetComponentInChildren<SkinnedMeshRenderer>();
        renderidle.enabled = true;

     //   renderrunning = runninganimcube.GetComponentInChildren<SkinnedMeshRenderer>();
      //  renderrunning.enabled = false;


    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            WalkActive = true;
            //RunActive = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
            WalkActive = true;
            //RunActive = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            WalkActive = true;
            //RunActive = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            WalkActive = true;
            //RunActive = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
            run = true;
        else
            run = false;

        //  if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        //  {
        //      transform.Translate(Vector3.forward * (moveSpeed + 2) * Time.deltaTime);
        //      RunActive = true;
        //      WalkActive = false;
        //  }

        //  if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S))
        //  {
        //      transform.Translate(-Vector3.forward * (moveSpeed + 2) * Time.deltaTime);
        //      RunActive = true;
        //      WalkActive = false;
        //  }

        if (run)
        {
            moveSpeed = 8f;
            anim.speed = 3;
        }
        else
        {
            moveSpeed = 4f;
            anim.speed = 1;
        }

        if (WalkActive == true)
        {

            renderwalk.enabled = true;
            renderidle.enabled = false;
           // renderrunning.enabled = false;
            this.GetComponent<Animator>().Play("WalkingAnim");

        }

       /* if (RunActive == true)
        {

            renderwalk.enabled = false;
            renderidle.enabled = false;
            renderrunning.enabled = true;
            runningdude.GetComponent<Animator>().Play("RunningAnim");

        }*/

        if (WalkActive == false)
        {
            renderwalk.enabled = false;
            renderidle.enabled = true;
            //renderrunning.enabled = false;
            idledude.GetComponent<Animator>().Play("IdleAnim");
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }


        if (!Input.anyKey)
        {
            rb.velocity = new Vector3(0.0f, gravity, 0.0f);
            WalkActive = false;
        }


    }
}