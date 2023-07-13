using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Shooter shooter;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) Shoot();
    }

    private void Shoot()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 position = hit.point;
            shooter.Shoot(position);
        }
        else
        {
            Vector3 position = ray.GetPoint(10f);
            shooter.Shoot(position);
        }
    }
}