using System.Collections;
using UnityEngine;

public class CannonBullet : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(DestroyMe());
    }

    private IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
