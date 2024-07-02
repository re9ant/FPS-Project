using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float rayDistance = 5.0f;

    public float multipler = 4;

    public LayerMask moveAble;

    public Transform front, back, left, right;

    public bool canMoveFront, canMoveBack, canMoveLeft, canMoveRight, canMoveUp, canMoveDown;

    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FixedUpdate()
    {
        if(enemy.canMakePath)
        {
            PathFinder();
            PathAssigner();
        }
    }

    private void PathFinder()
    {
        if (!Physics.Raycast(front.position, front.forward, out RaycastHit frontHitInfo, rayDistance, moveAble))
        {
            canMoveFront = true;
        }

        if (!Physics.Raycast(back.position, back.forward, out RaycastHit backHitInfo, rayDistance, moveAble))
        {
            canMoveBack = true;
        }

        if (!Physics.Raycast(left.position, left.forward, out RaycastHit leftHitInfo, rayDistance, moveAble))
        {
            canMoveLeft = true;
        }

        if (!Physics.Raycast(right.position, right.forward, out RaycastHit rightHitInfo, rayDistance, moveAble))
        {
            canMoveRight = true;
        }

        if (!Physics.Raycast(transform.position, Vector3.up, out RaycastHit upHitInfo, rayDistance, moveAble))
        {
            canMoveUp = true;
        }

        if (!Physics.Raycast(transform.position, Vector3.down, out RaycastHit downHitInfo, rayDistance, moveAble))
        {
            canMoveDown = true;
        }

        else if (frontHitInfo.collider != null && !frontHitInfo.collider.gameObject.CompareTag("Player"))
        {
            canMoveFront = false;
        }

        else if (backHitInfo.collider != null)
        {
            canMoveBack = false;
        }

        else if (leftHitInfo.collider != null)
        {
            canMoveLeft = false;
        }

        else if (rightHitInfo.collider != null)
        {
            canMoveRight = false;
        }

        else if (upHitInfo.collider != null)
        {
            Debug.Log(upHitInfo.collider.gameObject);
            canMoveUp = false;
        }

        else if (downHitInfo.collider != null)
        {
            canMoveDown = false;
        }
    }

    private void PathAssigner()
    {
        if (canMoveFront && canMoveBack && canMoveLeft && canMoveRight && canMoveUp && canMoveDown)
        {
            return;
        }

        Vector3 newForce = enemy.force;

        if (!canMoveFront)
        {
            if (canMoveUp)
            {
                Debug.Log("Cant move front and moving up");
                newForce = newForce + new Vector3(0, 150.0f, 0);
            }

            else if (!canMoveUp && canMoveDown)
            {
                Debug.Log("Cant move front and moving down");
                newForce = newForce + new Vector3(0, -150.0f, 0);
            }

            else if (!canMoveDown && !canMoveUp && canMoveLeft)
            {
                Debug.Log("Cant move front and moving left");
                newForce = newForce + new Vector3(-150.0f, 0, 0);
            }

            else if (!canMoveDown && !canMoveLeft && !canMoveUp && canMoveRight)
            {
                Debug.Log("Cant move front and moving right");
                newForce = newForce + new Vector3(150.0f, 0, 0);
            }

            else if (!canMoveRight && !canMoveLeft && !canMoveUp && !canMoveDown && canMoveBack)
            {
                Debug.Log("Cant move front and moving back");
                newForce = newForce + new Vector3(0, 0, -150.0f);
            }

            else
            {
                Debug.Log("Cant move");
                newForce = Vector3.zero;
            }

            enemy.force += newForce;

            return;
        }

        else if (!canMoveBack)
        {
            if (canMoveUp)
            {
                Debug.Log("Cant move back and moving up");
                newForce = newForce + new Vector3(0, 150.0f, 0);
            }

            else if (!canMoveUp && canMoveDown)
            {
                Debug.Log("Cant move back and moving down");
                newForce = newForce + new Vector3(0, -150.0f, 0);
            }

            else if (!canMoveDown && !canMoveUp && canMoveLeft)
            {
                Debug.Log("Cant move back and moving left");
                newForce = newForce + new Vector3(-150.0f, 0, 0);
            }

            else if (!canMoveDown && !canMoveLeft && !canMoveUp && canMoveRight)
            {
                Debug.Log("Cant move back and moving right");
                newForce = newForce + new Vector3(150.0f, 0, 0);
            }

            else if (!canMoveRight && !canMoveLeft && !canMoveUp && !canMoveDown && canMoveFront)
            {
                Debug.Log("Cant move back and moving front");
                newForce = newForce + new Vector3(0, 0, 150.0f);
            }

            else
            {
                Debug.Log("Cant move");
                newForce = Vector3.zero;
            }

            enemy.force += newForce;

            return;
        }

        else if (!canMoveLeft)
        {
            if (canMoveUp)
            {
                Debug.Log("Cant move left and moving up");
                newForce = newForce + new Vector3(0, 150.0f, 0);
            }

            else if (!canMoveUp && canMoveDown)
            {
                Debug.Log("Cant move left and moving down");
                newForce = newForce + new Vector3(0, -150.0f, 0);
            }

            else if (!canMoveDown && !canMoveUp && canMoveFront)
            {
                Debug.Log("Cant move left and moving front");
                newForce = newForce + new Vector3(0, 0, 150.0f);
            }

            else if (!canMoveDown && !canMoveFront && !canMoveUp && canMoveBack)
            {
                Debug.Log("Cant move left and moving back");
                newForce = newForce + new Vector3(0, 0, -150.0f);
            }

            else if (!canMoveFront && !canMoveBack && !canMoveUp && !canMoveDown && canMoveRight)
            {
                Debug.Log("Cant move left and moving right");
                newForce = newForce + new Vector3(150.0f, 0, 0);
            }

            else
            {
                Debug.Log("Cant move");
                newForce = Vector3.zero;
            }

            enemy.force += newForce;

            return;
        }

        else if (!canMoveRight)
        {
            if (canMoveUp)
            {
                Debug.Log("Cant move right and moving up");
                newForce = newForce + new Vector3(0, 150.0f, 0);
            }

            else if (!canMoveUp && canMoveDown)
            {
                Debug.Log("Cant move right and moving down");
                newForce = newForce + new Vector3(0, -150.0f, 0);
            }

            else if (!canMoveDown && !canMoveUp && canMoveFront)
            {
                Debug.Log("Cant move right and moving front");
                newForce = newForce + new Vector3(0, 0, 150.0f);
            }

            else if (!canMoveDown && !canMoveLeft && !canMoveUp && canMoveBack)
            {
                Debug.Log("Cant move right and moving back");
                newForce = newForce + new Vector3(0, 0, -150.0f);
            }

            else if (!canMoveFront && !canMoveBack && !canMoveUp && !canMoveDown && canMoveLeft)
            {
                Debug.Log("Cant move right and moving left");
                newForce = newForce + new Vector3(-150.0f, 0, 0);
            }

            else
            {
                Debug.Log("Cant move");
                newForce = Vector3.zero;
            }

            enemy.force += newForce;

            return;
        }

        else if (!canMoveDown)
        {
            if (canMoveUp)
            {
                Debug.Log("Cant move down and moving up");
                newForce = newForce + new Vector3(0, 150.0f, 0);
            }

            else if (!canMoveUp && canMoveFront)
            {
                Debug.Log("Cant move down and moving front");
                newForce = newForce + new Vector3(0, 0, 150.0f);
            }

            else if (!canMoveUp && !canMoveFront && canMoveBack)
            {
                Debug.Log("Cant move down and moving back");
                newForce = newForce + new Vector3(0, 0, -150.0f);
            }

            else if (!canMoveUp && !canMoveFront && !canMoveBack && canMoveLeft)
            {
                Debug.Log("Cant move down and moving left");
                newForce = newForce + new Vector3(-150.0f, 0, 0);
            }

            else if (!canMoveFront && !canMoveBack && !canMoveLeft && !canMoveUp && canMoveRight)
            {
                Debug.Log("Cant move down and moving right");
                newForce = newForce + new Vector3(150.0f, 0, 0);
            }

            else
            {
                Debug.Log("Cant move");
                newForce = Vector3.zero;
            }

            enemy.force += newForce;

            return;
        }

        else if (!canMoveUp)
        {
            if (canMoveLeft)
            {
                Debug.Log("Cant move up and moving left");
                newForce = newForce + new Vector3(-150.0f, 0, 0);
            }

            else if (!canMoveLeft && canMoveRight)
            {
                Debug.Log("Cant move up and moving right");
                newForce = newForce + new Vector3(150.0f, 0, 0);
            }

            else if (!canMoveLeft && !canMoveRight && canMoveFront)
            {
                Debug.Log("Cant move up and moving front");
                newForce = newForce + new Vector3(0, 0, 150.0f);
            }

            else if (!canMoveLeft && !canMoveRight && !canMoveFront && canMoveBack)
            {
                Debug.Log("Cant move up and moving back");
                newForce = newForce + new Vector3(0, 0, -150.0f);
            }

            else if (!canMoveLeft && !canMoveRight && !canMoveFront && !canMoveBack && canMoveDown)
            {
                Debug.Log("Cant move up and moving down");
                newForce = newForce + new Vector3(0, -150.0f, 0);
            }

            else
            {
                Debug.Log("Cant move");
                newForce = Vector3.zero;
            }

            enemy.force += newForce;

            return;
        }

    }

}
