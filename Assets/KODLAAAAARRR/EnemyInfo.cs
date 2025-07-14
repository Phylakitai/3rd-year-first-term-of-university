using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class EnemyInfo : abstractClass, IKillable, IDamageable
{
    public Animator anim;
    public string ad; 
    public int levell;
    public int speed;
    public int EnemyHp;
    public int EnemyDamage; 
    public GameObject panel;
    public GameObject yeniSkeleton;
    public TMP_Text textName;
    public TMP_Text textlevel;
    public TMP_Text textspeed;
    public TMP_Text textEnemyHp;
    public TMP_Text textenemyDamage;
    public GameObject smallSkeleton;
    bool isDead = false;

    public virtual void NawMesh() { }
    public virtual int Initalize(int enemyHp)
    {
        EnemyHp = enemyHp;
        return EnemyHp;
    }
    public virtual int Initalize(int enemyHp, int Damage)
    {
        EnemyDamage = Damage;
        return EnemyDamage;
    }
    public virtual void TextMetod() { }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && anim)
        {
            anim.SetTrigger("Attack");

        }
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && anim)
        {
            anim.SetTrigger("Attack");
        }
    }
    public void PanelAc()
    {
        panel.SetActive(true);
    }
    public void PanelKapat()
    {
        panel.SetActive(false);
    }

    public void OnMouseOver()
    {
        PanelAc();
    }

    private void OnMouseExit()
    {
        PanelKapat();
    }

    public void Start()
    {
        PanelAc();
        PanelKapat();
        Initalize(200, 15);
    }

    public void Update()
    {
        NawMesh();       
        TextMetod();
    }

    public void TakeDamage(int damage)
    {
        EnemyHp -= damage;

        if (EnemyHp <= 0)
        {
            Killable();
        }
    }

    public override void DusmanUret()
    {
        if (EnemyHp <= 0 && isDead == true)
        {
            yeniSkeleton.SetActive(true);
           
            for (int i = 0; i < 3; i++)
            {
              
                Vector3 currentPosition = transform.position;   
                
                float offsetX = Random.Range(-2f, 2f);
                float offsetZ = Random.Range(-2f, 2f);

                Vector3 randomOffset = new Vector3(offsetX, 0f, offsetZ);              
                Vector3 newPosition = currentPosition + randomOffset;               
                Instantiate(yeniSkeleton, newPosition, transform.rotation);
            }

      
            Destroy(gameObject);
        }
    }

    public void Death()
    {
        isDead = true;
        DusmanUret(); 
        Destroy(gameObject);
    }

    public void Killable()
    {
        Death();
    }

}
