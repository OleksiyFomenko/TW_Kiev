using System.Collections;
using UnityEngine;

public class AreaDestruction : MonoBehaviour
{
    [SerializeField] Material trigger_Material;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstical"))
        {
            other.gameObject.GetComponent<Renderer>().material = trigger_Material;

            StartCoroutine(MoveDownAndDestroyAfterDelay(other, 2f));
        }
    }

    private IEnumerator MoveDownAndDestroyAfterDelay(Collider other, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (other != null)
        {
            other.transform.position -= new Vector3(0, 10.0f, 0);
        }
        Destroy(gameObject);
    }
}
