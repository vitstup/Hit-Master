using UnityEngine;

public class Box : MonoBehaviour , IDieble, IResatable
{
    public void Damage(float damageAmount)
    {
        Die();
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    public void ResetAll()
    {
        gameObject.SetActive(true);
    }
}