using UnityEngine;

public class AnimationController : MonoBehaviour 
{
    [SerializeField] private Animator controller;

    private bool isRunning;

    public void SetIsRunning(bool isRunning)
    {
        if (this.isRunning != isRunning)
        {
            this.isRunning = isRunning;
            controller.SetBool("isRunning", isRunning);
        }
    }
}