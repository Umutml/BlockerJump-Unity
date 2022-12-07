using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Animator playerAnim;
    private Rigidbody playerRb;
    public Camera maincam;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    private float jumpForce = 1200f;
    //private float gravityModifier = 2f;

    private bool isGrounded = true;
    public bool gameOver;
    private bool candoubleJump = false;
    public bool faster = false;
    

    private ParticleSystem dirtSplatter;
    private ParticleSystem particleExplosion;

    // Start is called before the first frame update
    void Start()
    {
        
        
        //Physics.gravity *= gravityModifier;

        
        
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        particleExplosion = GetComponent<ParticleSystem>();
        dirtSplatter = GameObject.Find("FX_DirtSplatter").GetComponentInChildren<ParticleSystem>();
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtSplatter.Stop();
            playerAudio.PlayOneShot(jumpSound, 0.5f);
            candoubleJump = true;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && candoubleJump)
        {
            candoubleJump = false;
            playerRb.AddForce(Vector3.up * 800, ForceMode.Impulse);
            playerAudio.PlayOneShot(jumpSound, 0.6f);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync("Prototype 3");
            
        }

        Running();


    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            dirtSplatter.Play();

        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerRb.AddForce(new Vector3(-800f, 0f, 0f), ForceMode.Impulse);
            playerAudio.PlayOneShot(crashSound, 1f);
            particleExplosion.Play();
            playerAnim.SetInteger("DeathType_int", 1);
            playerAnim.SetBool("Death_b", true);
            dirtSplatter.Stop();
            Destroy(collision.gameObject);
            Debug.Log("GameOver");
            maincam.transform.position = new Vector3(3, 4, -15);
            
        }
        
    }
    void Running()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            faster = true;
        }
        else if(faster)
        {
            faster = false;
        }
    }

    




}
