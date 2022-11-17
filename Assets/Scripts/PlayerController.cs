using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRb; 
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle; 
    public float jumpForce; 
    public float gravityModifier;
    public  bool isOnGround;
    public  bool gameOver = false; 
    

    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }    
     
    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)

        {
          PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);   
          isOnGround = false;
          playerAnim.SetTrigger("jump_trig"); 
          dirtParticle.Stop();
        }
    }    
        
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b" , true);
            playerAnim.SetInteger("DeathType_int" , 1);
            explosionParticle.Play();
            dirtParticle.Stop();
        }

    }


} 