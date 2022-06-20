using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIShowing : MonoBehaviour
{
    private Vector3 initialPosition;
    [SerializeField] private float appearedTime = 3f;
    private NavMeshAgent meshAgent;
    private void Awake()
    {
        initialPosition = transform.position;
        meshAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        DisappearCopyCat();
    }

    public void SetCopyCatPosition(Transform transformPosition)
    {
        meshAgent.enabled = false;
        gameObject.SetActive(true);
        transform.position = transformPosition.position;
        StartCoroutine(WaitUntilDisappear());
    }

    IEnumerator WaitUntilDisappear()
    {
        yield return new WaitForSeconds(appearedTime);
        DisappearCopyCat();
    }

    private void DisappearCopyCat()
    {
        this.gameObject.SetActive(false);
        transform.position = initialPosition;
        meshAgent.enabled = true;
    }
}
