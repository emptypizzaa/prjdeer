using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Vector2 moveTarget;
    [SerializeField] private Vector2 movePosition;
    [SerializeField] private LayerMask moveLayer;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] LayerMask tongueLayer;
    [SerializeField] LayerMask frogBodyLayer;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask waterLayer;

    [SerializeField] float damage = 30;
    [SerializeField] int deltaScore = 20;
    [SerializeField] float debuffDuration = 5;

    public int DeltaScore => deltaScore;
    public float DebuffDuration => debuffDuration;

    private NavMeshAgent _agent;
    void Start()
    {

        /*
        _agent = GetComponent<NavMeshAgent>();
        NewTarget();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        */
    }

    private void NewTarget()
    {
        moveTarget = new Vector2(Random.Range(-20f, 20f), Random.Range(-20f, 20f));
        if (!Physics2D.OverlapCircle(new Vector2(transform.position.x + moveTarget.x, transform.position.y + moveTarget.y), 2, moveLayer)) NewTarget();
        movePosition = new Vector2(transform.position.x + moveTarget.x, transform.position.y + moveTarget.y);
    }

    void Update()
    {

        /*    if (Vector3.Distance(movePosition, transform.position) > 3f)
            {
            //    _agent.SetDestination(movePosition);
            }
           // else
            {
             //   NewTarget();
            }

           // spriteRenderer.flipX = _agent.desiredVelocity.x > 0;

            */
    }

}
 

    /*
    void OnTriggerEnter2D(Collider2D col)
    {
        if ((tongueLayer.value & (1 << col.gameObject.layer)) != 0)
        {
            //    if (Player.Instance.CanCatch && Player.Instance.IsTongueExtended)
            {
                // Player.Instance.AttachItemToTongue(this);
            }
        }
        else if ((frogBodyLayer.value & (1 << col.gameObject.layer)) != 0)
        {
            //   Player.Instance.PlayDamageClip();

            // if (Player.Instance.IsAttachedToTongue(this))
            {
                //     Player.Instance.OnEatEnemy(DeltaScore, DebuffDuration);
                //         Destroy(gameObject);
            }
            // else
            //   {
            //       Player.Instance.Hp -= damage;
            //   }
        }
        else if ((groundLayer.value & (1 << col.gameObject.layer)) != 0)
        {
            // 아무것도 하지 않는다.
        }
        else if ((waterLayer.value & (1 << col.gameObject.layer)) != 0)
        {
            // 아무것도 하지 않는다.
        }
        else
        {
            Debug.LogError("Unknown collision layer");
        }
    }

    */

