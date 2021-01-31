using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public LayerMask mask;

    public bool isTaken()
    {
        return false;
        // return Physics.CheckSphere(gameObject.transform.position, gameObject.transform.localScale.x/50, mask);
    }

}
