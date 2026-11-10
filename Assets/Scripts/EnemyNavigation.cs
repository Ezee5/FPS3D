
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyNavigation : MonoBehaviour
{
    [Header("Navigation")]
    public NavMeshAgent agent;
    public Transform target;

    [Header("Rig & Animation")]
    public Animator animator;

    [Header("Movement Settings")]
    public float updateRate = 0.15f;

    private float updateTimer;

    void Awake()
    {
        // Obtener el agente del objeto principal
        agent = GetComponent<NavMeshAgent>();

        // Buscar el Animator dentro del Rig o sus hijos
        animator = GetComponentInChildren<Animator>();

        // El movimiento será controlado por el NavMeshAgent
        if (animator != null)
        {
            animator.applyRootMotion = false;
        }

        agent.updatePosition = true;
        agent.updateRotation = true;
    }

    void Start()
    {
        // Buscar al jugador
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogError("No se encontró al jugador. Revisá el Tag Player.");
        }

        if (!agent.isOnNavMesh)
        {
            Debug.LogError("El NPC no está colocado sobre el NavMesh.");
            enabled = false;
            return;
        }
    }

    void Update()
    {
        if (target == null || !agent.isOnNavMesh)
            return;

        // Actualizar destino periódicamente
        updateTimer += Time.deltaTime;

        if (updateTimer >= updateRate)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);

            updateTimer = 0f;
        }

        // Actualizar velocidad de animación si existe el parámetro
        if (animator != null &&
            animator.runtimeAnimatorController != null)
        {
            float movementSpeed = agent.velocity.magnitude;

            if (HasParameter("Speed"))
            {
                animator.SetFloat("Speed", movementSpeed);
            }
        }
    }

    bool HasParameter(string parameterName)
    {
        foreach (AnimatorControllerParameter parameter
                 in animator.parameters)
        {
            if (parameter.name == parameterName)
                return true;
        }

        return false;
    }
}
