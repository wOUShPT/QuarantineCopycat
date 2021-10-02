using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
public class AIChase : MonoBehaviour
{
    //Agent
    private NavMeshAgent agent;
    [SerializeField] private Transform target;
    //Zoom lens

    [SerializeField]private CinemachineVirtualCamera vcam;
    [SerializeField] private float minDistance = 2f;
    [SerializeField] private float maxDistance = 8f;
    [SerializeField] private float minFOV = 20f;
    [SerializeField] private float maxFOV = 60f;
    private float targetFOV;
    [SerializeField] private float sensibility = 20f;
    private void Awake()
    {
        target = FindObjectOfType<PlayerMovement>().transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        agent.SetDestination(target.position);
    }
    void LateUpdate()
    {
        float distance = Mathf.RoundToInt(Vector3.Distance(transform.position, target.position));
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
        switch (distance)
        {
            case 2:
                targetFOV = maxFOV;
                break;
            case 3:
                targetFOV = maxFOV - 10;
                break;
            case 4:
                targetFOV = maxFOV - 20;
                break;
            case 5:
                targetFOV = minFOV + 10; // 30
                break;
            case 6:
                targetFOV = minFOV; // 20
                break;
        }
        vcam.m_Lens.FieldOfView = Mathf.Lerp(vcam.m_Lens.FieldOfView, targetFOV, sensibility * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Gameover");
        }
    }
}
