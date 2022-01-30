using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInstantiator : MonoBehaviour
{
    public Transform parent;
    public Transform originalPosition;
    public GameObject BS;
    public GameObject BM;
    public GameObject BB;

    public GameObject RS;
    public GameObject RM;
    public GameObject RB;

    public void Update()
    {
        GameObject instantiatedObject = null;
        if (Input.GetKeyDown(KeyCode.U))
            instantiatedObject = Instantiate(BS, parent);
        if (Input.GetKeyDown(KeyCode.I))
            instantiatedObject = Instantiate(BM, parent);
        if (Input.GetKeyDown(KeyCode.O))
            instantiatedObject = Instantiate(BB, parent);
        if (Input.GetKeyDown(KeyCode.J))
            instantiatedObject = Instantiate(RS, parent);
        if (Input.GetKeyDown(KeyCode.K))
            instantiatedObject = Instantiate(RM, parent);
        if (Input.GetKeyDown(KeyCode.L))
            instantiatedObject = Instantiate(RB, parent);

        if(instantiatedObject!=null)
            instantiatedObject.transform.position = originalPosition.position;
    }
}
