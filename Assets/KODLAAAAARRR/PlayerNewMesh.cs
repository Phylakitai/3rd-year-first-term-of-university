using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerNewMesh : EnemyInfo
{
    [SerializeField] private Transform movePosition;
    public NavMeshAgent agent;
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public  override void NawMesh()
    {
        agent.destination = movePosition.position;
        if (agent)
        {
            anim.SetBool("Walking", true);
        }
        
       
    }
}
