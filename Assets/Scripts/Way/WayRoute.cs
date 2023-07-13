using UnityEngine;

public class WayRoute : MonoBehaviour, IResatable
{
    [SerializeField] private WayRegion[] route;

    [SerializeField] private CharacterController character;

    [SerializeField] private RestartManager restartManager;

    private int currentPoint;

    [System.Serializable]
    private class WayRegion
    {
        [field: SerializeField] public WayPoint point { get; private set; }
        [field: SerializeField] public Enemy[] enemies { get; private set; }
    }

    private void Start()
    {
        Enemy.EnemyDiedEvent.AddListener(CheckCurrentRegion);
        CharacterController.WayPointReached.AddListener(CheckCurrentRegion);
    }

    public void CheckCurrentRegion()
    {
        if (!CheckRegionForEnemies(route[currentPoint])) MoveNext();
    }

    private bool CheckRegionForEnemies(WayRegion region)
    {
        bool haveEnemies = false;
        for (int i = 0; i < region.enemies.Length; i++)
        {
            if (region.enemies[i] != null && !region.enemies[i].isDead)
            {
                haveEnemies = true;
                break;
            }
        }
        return haveEnemies;
    }

    private void MoveNext()
    {
        currentPoint++;
        if (currentPoint < route.Length) character.MoveTo(route[currentPoint].point.transform.position);
        else restartManager.Restart();
    }

    public void ResetAll()
    {
        currentPoint = 0;
    }
}