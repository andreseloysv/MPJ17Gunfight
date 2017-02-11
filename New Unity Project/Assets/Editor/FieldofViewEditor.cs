using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Fieldofview))]
public class FieldofViewEditor : Editor
{

    void OnSceneGUI()
    {
        //deja que veas el trazado del field of view
        Fieldofview fow = (Fieldofview)target;

        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadious);


        //Crea el cono del verdadero view angle
        Vector3 viewAngleA = fow.DirFromAngle(-fow.viewAngle / 2, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.viewAngle / 2, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadious);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadious);

        Handles.color = Color.red;
        //Debug.Log("crea el handle");
        //Debug.LogWarning("Crea el handle");

        foreach (Transform visibleTarget in fow.visibleTargets)
        {

            Handles.DrawLine(fow.transform.position, visibleTarget.position);
            //Debug.Log("crea el dentro ");
            //Debug.LogWarning("Crea el handle dentro");
        }
    }
}
