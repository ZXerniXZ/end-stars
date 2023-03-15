using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;

public class SphereTrigger : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    private bool isObjectInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            isObjectInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            isObjectInside = false;
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        if (objectToSpawn != null && spawnPoint != null && !isObjectInside)
        {
            // Clona l'oggetto e disabilita temporaneamente il collider del trigger
            GameObject newObject = Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
            Collider newObjectCollider = newObject.GetComponent<Collider>();
            if (newObjectCollider != null)
            {
                newObjectCollider.enabled = false;
                StartCoroutine(EnableColliderAfterDelay(newObjectCollider, 0.5f)); // Riattiva il collider dopo un breve ritardo
            }
        }
    }

    private IEnumerator EnableColliderAfterDelay(Collider collider, float delay)
    {
        yield return new WaitForSeconds(delay);
        collider.enabled = true;
    }

}