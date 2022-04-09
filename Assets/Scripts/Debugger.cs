using UnityEngine;

public class Debugger : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Summon();
    }

    private void Summon()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    [SerializeField]
    private Enemy enemyPrefab;
}
