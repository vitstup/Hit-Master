using System.Linq;
using UnityEngine;

public class RestartManager : MonoBehaviour
{
    [SerializeField] private Canvas playCanvas;

    private IResatable[] resatables;

    public void Restart()
    {
        playCanvas.gameObject.SetActive(true);

        if (resatables == null) resatables = FindObjectsOfType<MonoBehaviour>(true).OfType<IResatable>().ToArray();

        foreach (var resatable in resatables) resatable.ResetAll();
    }
}