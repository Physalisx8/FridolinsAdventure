using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fridolin : MonoBehaviour
{
    bool grounded;
    Rigidbody2D rb;
    public Transform flipper;
    float eingabeFaktor = 10;
    public Animator animator;
    CapsuleCollider2D normalCollider;
    CircleCollider2D slideCollider;
    protected SpriteRenderer sr;
    public float distance;
    float xNeu;
    //zum sterben
    public LayerMask whatIsDeadly;
   

    //zum klettern
    public LayerMask whatIsLadder;
    private bool isClimbing;
    private float inputVertical;
    public float speed;
    
    
    [SerializeField] private float jumpforce;



    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Gefahr") { 
        transform.position = new Vector2(-75.14f, -6.66f);
       }
        
    }



    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        normalCollider = GetComponent<CapsuleCollider2D>();
        slideCollider = GetComponent<CircleCollider2D>();
    }
void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "bumptag")
        {
            FindObjectOfType<AudioManager>().Play("bump");
        }
            grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        float xEingabe = Input.GetAxis("Horizontal");

        //gehört zum klettern
        rb.velocity = new Vector2(xEingabe * speed, rb.velocity.y);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);
        if(hitInfo.collider != null && grounded == false){
            if (Input.GetKeyDown(KeyCode.UpArrow)){
                animator.SetBool("climbing", true);
               isClimbing = true;


            }
          
        }
        else{ 
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) { 
                isClimbing = false;
                animator.SetBool("climbBewegung", false);
                animator.SetBool("climbing", false);
            }
            
        }
        if(isClimbing == true && hitInfo.collider != null) { 
       
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);
            rb.gravityScale = 0;
            if(Input.GetAxisRaw("Vertical") > 0)
            {
                animator.SetBool("climbBewegung", true);
            }
            else
            {
                animator.SetBool("climbBewegung", false);
            }
         
        }
        else
        {
            rb.gravityScale = 5;
            animator.SetBool("climbBewegung", false);
            animator.SetBool("climbing", false);
        }

        //spielt Sound Walking ab wenn sich Fridolin bewegt 
        if (xEingabe == 0)
        {
            FindObjectOfType<AudioManager>().Play("walking");
        }





  












        //animation "gehen" wird aktiviert
        animator.SetFloat("walking", Mathf.Abs(xEingabe));

        

        //xposition öndern
       xNeu = transform.position.x + xEingabe * eingabeFaktor/3 * Time.deltaTime;
        transform.position = new Vector3(xNeu,  transform.position.y, 0);

   
        //gehen nicht zu weit
        if (xNeu > 8.3f)
        {
            xNeu = 8.3f;
        }

        if (transform.position.y > 8.3f || transform.position.y<-8.3f)
        {
            xNeu = 8.3f;
        }






        if (Input.GetKeyDown(KeyCode.LeftArrow)){  //Input.GetKeyDown(KeyCode.RightArrow))
            sr.flipX = true;
      
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {  //Input.GetKeyDown(KeyCode.RightArrow))
            sr.flipX = false;



        }


       



        //springen
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            
            animator.SetBool("jumping", true);
            rb.AddForce(transform.up * jumpforce);
            grounded = false;
            tonskript.PlaySound("jumping");
        }
        else { animator.SetBool("jumping", false);
            }

        //ducken
        if(Input.GetKey (KeyCode.DownArrow)){
            animator.SetBool("Slide", true);
            slideCollider.enabled = true;
            normalCollider.enabled = false;
        }
        else//ducken aufgeben
        {
            animator.SetBool("Slide", false);
            slideCollider.enabled = false;
            normalCollider.enabled = true;
        }
        //nichtb nur von boden springen können
    }
    



}