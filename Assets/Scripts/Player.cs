using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("점프 힘")]
    public float jumpForce;

    [Header("Reference")]
    [Tooltip("참조할 리지드 바디 적용")]
    public Rigidbody2D playerRigid;
    [Tooltip("충돌감지")]
    public BoxCollider2D col;
    [Tooltip("플레이어 애니메이터")]
    public Animator anim;


    private bool isGrounded = true;
    private bool isInvincible = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigid.AddForceY(jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            anim.SetInteger("state", 1);
        }
    }
    public void KillPlayer()
    {
        col.enabled = false;
        anim.enabled = false;
        playerRigid.AddForceY(jumpForce, ForceMode2D.Impulse);
    }
    void Hit()
    {
        GameManager.Instance.Life -= 1;
    }
    void Heal()
    {
        GameManager.Instance.Life = Mathf.Min(3, GameManager.Instance.Life + 1);
    }
    void StartInvincible()
    {
        isInvincible = true;
        StartCoroutine("UpDown");
        Invoke("StopInvincible", 5f);
    }
    void StopInvincible()
    {
        isInvincible = false;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
    IEnumerator UpDown()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.3f);
        yield return new WaitForSeconds(0.2f);

        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.2f);

        if (isInvincible)
        {
            StartCoroutine("UpDown");
        }
        else
        {
            yield break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Platform")
        {
            if(!isGrounded) anim.SetInteger("state", 2);
            isGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            if(!isInvincible)
            {
                Destroy(collision.gameObject);
                Hit();
            }
            
        }
        else if(collision.gameObject.tag == "food")
        {
            Destroy(collision.gameObject);
            Heal();
        }
        else if (collision.gameObject.tag == "golden")
        {
            Destroy(collision.gameObject);
            StartInvincible();
        }
    }
}
