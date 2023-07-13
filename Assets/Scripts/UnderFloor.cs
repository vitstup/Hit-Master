using UnityEngine;

public class UnderFloor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IDieble dieble = other.GetComponent<IDieble>();

        if (dieble != null) dieble.Die();
    }
}