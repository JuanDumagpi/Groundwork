using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Melee;
    bool isAttacking = false;
    float atkSpeed = 0.3f;
    float atkTime = 0;
    public AudioSource hitAudio;

    //This is for animation
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {   
        AttackTimer();

        //Makes the player attack when pressing left click
        if (Input.GetButtonDown("Fire1"))
        {
            hitAudio.pitch = UnityEngine.Random.Range(0.6f, .9f);
            hitAudio.Play();
            onAttack();
            animator.SetTrigger("attack");
        }
    }

    void onAttack()
    {   //Activates the melee hitbox
        if(!isAttacking)
        {
            Melee.SetActive(true);
            isAttacking = true;
            //place animation here for later
        }
    }

    void AttackTimer()
    {   //Checks if you're attacking, then after a set amount of time in atkSpeed, disables the melee hitbox
        if(isAttacking)
        {
            atkTime += Time.deltaTime;
            if(atkTime >= atkSpeed )
            {
                atkTime = 0;
                isAttacking=false;
                Melee.SetActive(false);
            }
        }
    }
}
