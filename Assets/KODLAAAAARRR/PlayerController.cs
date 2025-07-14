using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float _hp = 500;
    public float Hp
    {
        get { return _hp; }
        set
        {
            _hp = Mathf.Clamp(value, 0, 500);
            UpdateHealthSlider();
            if (_hp <= 0) Death();
        }
    }

    private int _damage = 30;
    public int Damage
    {
        get { return _damage; }
        set { _damage = Mathf.Max(value, 0); }
    }
    
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
   
    public Animator animator;
    public Slider slider;
    public Image fillImage;
    public Image skill1fillImage;
    public Image skill2fillImage;
    public Image skill3fillImage;
    public FollowCamera followCamera;

    private SkillBase skill1;
    private SkillBase skill2;
    private SkillBase skill3;

     public float skillCooldown1 = 10;
     public float skillCooldown2 = 8;
     public float skillCooldown3 = 5;

    public bool canUseSkill1 = true;
    public bool canUseSkill2 = true;
    public bool canUseSkill3 = true;

    void Start()
    {
        skill1 = gameObject.AddComponent<Skill1>();
        skill2 = gameObject.AddComponent<Skill2>();
        skill3 = gameObject.AddComponent<Skill3>();
        skill1fillImage.fillAmount = 0;
        skill2fillImage.fillAmount = 0;
        skill3fillImage.fillAmount = 0;
        Hp = 500;
    }

    void Update()
    {
        HandleMovement();
        HandleSkills();
        yetenek();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            Vector3 targetDirection = followCamera.playerCamera.transform.forward * moveDirection.z +
                                       followCamera.playerCamera.transform.right * moveDirection.x;

            targetDirection.y = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * rotationSpeed);

            transform.position += targetDirection * moveSpeed * Time.deltaTime;

            if (animator) animator.SetBool("IsWalking", true);
        }
        else
        {
            if (animator) animator.SetBool("IsWalking", false);
        }
    }
    public void yetenek()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && canUseSkill1 == false)
        {
            canUseSkill1 = true;
            skill1fillImage.fillAmount = 1;
        }
        if (canUseSkill1)
        {
            skill1fillImage.fillAmount -= 1 / skillCooldown1 * Time.deltaTime;
            if (skill1fillImage.fillAmount <= 0)
            {
                skill1fillImage.fillAmount = 0;
                canUseSkill1 = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && canUseSkill1 == false)
        {
            canUseSkill2 = true;
            skill2fillImage.fillAmount = 1;
        }
        if (canUseSkill2)
        {
            skill2fillImage.fillAmount -= 1 / skillCooldown2 * Time.deltaTime;
            if (skill2fillImage.fillAmount <= 0)
            {
                skill2fillImage.fillAmount = 0;
                canUseSkill2 = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && canUseSkill3 == false)
        {
            canUseSkill3 = true;
            skill3fillImage.fillAmount = 1;
        }
        if (canUseSkill3)
        {
            skill3fillImage.fillAmount -= 1 / skillCooldown3 * Time.deltaTime;
            if (skill3fillImage.fillAmount <= 0)
            {
                skill3fillImage.fillAmount = 0;
                canUseSkill3 = false;
            }
        }
    }

    public void HandleSkills()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && canUseSkill1)
        {
            StartCoroutine(SkillCooldown(skill1, 10, () => canUseSkill1 = true));
            canUseSkill1 = false;
            TriggerSkill("Skill1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && canUseSkill2)
        {
            StartCoroutine(SkillCooldown(skill2, 8, () => canUseSkill2 = true));
            canUseSkill2 = false;
            TriggerSkill("Skill2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && canUseSkill3)
        {
            StartCoroutine(SkillCooldown(skill3, 10, () => canUseSkill3 = true));
            canUseSkill3 = false;
            TriggerSkill("Kick");
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            TriggerSkill("NormalAttack");
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            TriggerSkill("LightAttack");
        }
    }
    public void TriggerSkill(string skillName)
    {
        if (animator)
        {
            animator.SetTrigger(skillName);
        }
    }

    private IEnumerator SkillCooldown(SkillBase skill, float cooldown, System.Action onCooldownEnd)
    {
        skill.UseSkill(this);
        yield return new WaitForSeconds(cooldown);
        onCooldownEnd();
        
    }
    public void Damageable(float damage)
    {
        Hp -= damage; 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyWeapon")) 
        {
            Damageable(10); 
        }
    }
    
    public void DamageEnemy(int damage)
    {
        
    }

    private void UpdateHealthSlider()
    {
        slider.value = _hp;
        fillImage.color = _hp < 120 ? Color.red
            : (_hp < 350 ? new Color(1f, 0.5f, 0f)
            : Color.green);
    }

    private void Death()
    {
        
        Destroy(gameObject);
    }
}
