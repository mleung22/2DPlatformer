using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Player : MonoBehaviour {

    public float speed;
    public float setVelocity;

    public float gravity;
    public bool onGround;
    public bool canDoubleJump;
    bool invincible;

    public int currentHealth;
    public int maxHealth;

    public GameObject spawn;
    public GameObject player;
    public GameObject deathParticles;
    public GameObject gameOverScreen;
    private Rigidbody2D rBody;
    private Animator anim;
    

	// Use this for initialization
	void Start () {
        rBody = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        currentHealth = maxHealth;
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("onGround", onGround);
        anim.SetFloat("velocity", Mathf.Abs(rBody.velocity.x));
        airMovement();
        

    }

    void FixedUpdate()
    {
        friction();
        groundMovement();
        checkDeath();
    }

    private void groundMovement()
    {
        // Grabs Horizontal Key Binding Inputs (A, D, Left, Right)
        float xAxisInput = Input.GetAxis("Horizontal");

        // Sets velocity
        if (rBody.velocity.x > setVelocity)
        {
            rBody.velocity = new Vector2(setVelocity, rBody.velocity.y);
        }
        else if (rBody.velocity.x < -setVelocity)
        {
            rBody.velocity = new Vector2(-setVelocity, rBody.velocity.y);
        }

        // Moves player left or right
        rBody.AddForce((Vector2.right * speed) * xAxisInput);

        // Faces player left or right depending on direction
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector2(1, 1);
        }

    }

    private void airMovement()
    {
        // Player Jump & Fixes infinite jump bug
        if (Timer.timer <= 99.9f)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (onGround)
                {

                    rBody.AddForce((Vector2.up * gravity));
                    canDoubleJump = true;
                }
                else
                {
                    doubleJump();
                }

            }
        }
    }

    // Prevents player from sliding
    private void friction()
    {
        Vector3 slowingVelocity = rBody.velocity;
        slowingVelocity.y = rBody.velocity.y;
        slowingVelocity.z = 0.0f;
        slowingVelocity.x *= 0.75f;

        if (onGround)
        {
            rBody.velocity = slowingVelocity;
        }
    }

    public void knockBack(float knockDuration, float knockBackPower, Vector3 knockbackDirection)
    {
        rBody.velocity = new Vector2(0, 0);
        rBody.AddForce(new Vector2(knockbackDirection.x * -100, knockbackDirection.y * knockBackPower));
    }

    public IEnumerator damage(int dmg)
    {
        
        invincible = false;
        canDoubleJump = true;

            currentHealth -= dmg;
            gameObject.GetComponent<Animation>().Play("fox_dmg");

 
        

        yield return new WaitForSeconds(2f);
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        


    }

    public void checkDeath()
    {
        if (currentHealth <= 0 || transform.position.y < -10)
        {
            if (this != null)
            {
                currentHealth = 0;
                Destroy(gameObject);
                Instantiate(deathParticles, transform.position, Quaternion.identity);
                
                gameOverScreen.SetActive(true);
            }
            
            
        } 
    }

    public void doubleJump()
    {
        if (canDoubleJump)
        {
            canDoubleJump = false;
            rBody.velocity = new Vector2(rBody.velocity.x,0);
            rBody.AddForce(Vector2.up * gravity);
            
        }
    }
}
