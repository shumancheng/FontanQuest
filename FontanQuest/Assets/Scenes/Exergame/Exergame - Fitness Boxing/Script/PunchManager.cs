using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchManager : MonoBehaviour
{
    [SerializeField] GameObject[] PunchPrefabs;
    public void SpawnPunch1()
    {
        int r = Random.Range(0, PunchPrefabs.Length);
        GameObject Punch = Instantiate(PunchPrefabs[r], transform);
        Punch.transform.localPosition = new Vector3(-149, Random.Range(-240, -358), 0);
        // x = - 149, y = -240 ~ -358
        // Set BoxCollider2D as trigger
        BoxCollider2D punchCollider = Punch.GetComponent<BoxCollider2D>();
        if (punchCollider != null)
        {
            punchCollider.isTrigger = true;
        }
    }

    public void SpawnPunch2()
    {
        int r = Random.Range(0, PunchPrefabs.Length);
        GameObject Punch = Instantiate(PunchPrefabs[r], transform);
        Punch.transform.localPosition = new Vector3(153, Random.Range(-240, -358), 0);
        // x = 153, y = -240 ~ -358
        // Set BoxCollider2D as trigger
        BoxCollider2D punchCollider = Punch.GetComponent<BoxCollider2D>();
        if (punchCollider != null)
        {
            punchCollider.isTrigger = true;
        }
    }
}
