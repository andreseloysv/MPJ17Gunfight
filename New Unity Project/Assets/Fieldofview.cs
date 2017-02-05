using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fieldofview : MonoBehaviour
{

    public float viewRadious;
    [Range(0, 360)]
    public float viewAngle;



    public LayerMask targetMask;
    public LayerMask obstacleMask;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();
    



    void Start()   {
        StartCoroutine("FindTargetsWithDelay", .2f);       

    }


    IEnumerator FindTargetsWithDelay(float delay) 
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();

        }
    }


    void FindVisibleTargets()
    {

        visibleTargets.Clear();

        Collider[] targetsInViewRadious = Physics.OverlapSphere(transform.position, viewRadious, targetMask);


        for (int i = 0; i < targetsInViewRadious.Length; i++)
        {
            Transform target = targetsInViewRadious[i].transform;


            Vector3 dirToTarget = (target.position - transform.position).normalized;


            Debug.LogWarning("entra 0");
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                Debug.LogWarning("entra 1");
                float disToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, disToTarget, obstacleMask))
                {
                    Debug.LogWarning("entra 2");
                    visibleTargets.Add(target);

                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {

        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));

    }

}
