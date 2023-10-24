
using UnityEngine;

public class SlimeEnemy : MonoBehaviour
{
    private GameObject Player;
    public int movement_Speed;
    private float distance;
    public float stopDistance;
    public float shooting_Range;

    //Made three simple variables the dummy player is the player movement speed is for the speed of the slime. the distance is the distance between the slime and player//

    [Header("movement detection")]
    public SpriteRenderer sprite;

    [SerializeField]
    private Vector2 lastPos;

    [SerializeField]
    private Vector2 currPos;
    private bool move;
    public Animator anim;

    void Start()
    {
        move = true;
        lastPos = transform.position;

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

        distance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 direction = Player.transform.position - transform.position;

        //This top two lines are telling the slime to identify the player position and go towards it//
        //This will ensure that at every frame the slime will move towards the player since it is being run through the update function//

        if (move)
        {
            anim.Play("SlimeMove");
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, movement_Speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward);
        }
        else
        {
            anim.Play("SlimeIdle");
        }

        //runs the check distance every frame making sure the enemy is moving towards the player unless the distance between them is 0
        Check_Distance(distance);

        //if moving left flip sprite towards the left
        currPos = transform.position;
        if (lastPos.x > currPos.x)
        {
            sprite.flipX = true;
        }
        //if moving right from the current position than flip the sprite to the right
        else if (lastPos.x < currPos.x)
        {
            sprite.flipX = false;
        }
        //this will update the position to that it will flip if it moves to the right
        lastPos = transform.position;

        

    }


    //this function will check the distance between the player and the slime
    //if the green outline is touching the player or if shooting range <= 0 the enemy will stop moving and start to shoot
    void Check_Distance(float dis)
    {
        if (dis <= shooting_Range)
        {
            gameObject.GetComponent<SlimeShooting>().shootNow = true;

        }
        if (dis > shooting_Range)
        {
            gameObject.GetComponent<SlimeShooting>().shootNow = false;
        }


        if (dis < stopDistance)
        {
            move = false;
        }
        else
        {
            move = true;
        }

    }
}

