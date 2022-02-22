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
        DissapearCopyCat();
    }

    public void SetCopyCatPosition(Transform transformPosition)
    {
        meshAgent.enabled = false;
        gameObject.SetActive(true);
        transform.position = transformPosition.position;
        StartCoroutine(WaitUntilDissapear());
    }

    IEnumerator WaitUntilDissapear()
    {
        yield return new WaitForSeconds(appearedTime);
        DissapearCopyCat();
    }

    private void DissapearCopyCat()
    {
        this.gameObject.SetActive(false);
        transform.position = initialPosition;
        meshAgent.enabled = true;
    }
}
