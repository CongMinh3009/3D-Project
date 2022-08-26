
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Transform _player;
    [SerializeField] int _heathEnemy;

    [Header("---Check Map---")]
    [SerializeField] LayerMask _whatIsGround, _whatIsPlayer;

    [Header("---Patrol---")]
    [SerializeField] Vector3 _walkPoint;
    [SerializeField] float _walkPointRange;
    bool WalkPointSet;

    [Header("---Attack---")]
    [SerializeField] float _timeBetweenAttacks;
    [HideInInspector] bool _readyAttacked;
    [SerializeField] GameObject _projecttile;

    [Header("---States---")]
    [SerializeField] float _sightRange, _attackRange;
    [SerializeField] bool _playerInSightRange, _playerInAttackRange;

    private void Awake()
    {
        _player = GameObject.Find("Player").transform;
        _agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        // check for sight and attack range;
        _playerInSightRange = Physics.CheckSphere(transform.position, _sightRange, _whatIsPlayer);
        _playerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, _whatIsPlayer);

        if (!_playerInSightRange && !_playerInAttackRange) Patroling();
        if (_playerInSightRange && !_playerInAttackRange) ChasePlayer();
        if (_playerInSightRange && _playerInAttackRange) AttackPlayer();
    }
    private void Patroling()
    {
        if (!WalkPointSet) SreachWalkPoint();
        if(WalkPointSet)
        {
            _agent.SetDestination(_walkPoint);
        }
            Vector3 distanceToWalkPoint = transform.position - _walkPoint;
        //Walkpoint reached 
        if (distanceToWalkPoint.magnitude < 1f) WalkPointSet = false;
    }
    void SreachWalkPoint()
    {
        //Caculate random point in range 
        float randomZ = Random.Range(-_walkPointRange, _walkPointRange);
        float randomX = Random.Range(-_walkPointRange, _walkPointRange);
        //target
        _walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
    }
    private void ChasePlayer()
    {
        _agent.SetDestination(_player.position);
    }
    private void AttackPlayer()
    {
        _agent.SetDestination(transform.position);
        transform.LookAt(_player);
        if(!_readyAttacked)
        {
            //attack 
            Rigidbody rb = Instantiate(_projecttile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            Destroy(rb, 1f);
            _readyAttacked = true;
            Invoke(nameof(ResetAttack), _timeBetweenAttacks);
        }
    }
   private void ResetAttack()
    {
        _readyAttacked = false; 
    }
    private void TakeDame(int _dameged)
    {
        _heathEnemy -= _dameged;

        if (_heathEnemy <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _sightRange)  ;

    }

}
