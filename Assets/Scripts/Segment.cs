using UnityEngine;

public class Segment : MonoBehaviour
{

    public WorldManager manager;

    public Segment original;

    public const int FORWARD = 0;
    public const int RIGHT = 1;
    public const int LEFT = 2;
    public const int BACK = 3;

    public Trigger forward;
    public Trigger right;
    public Trigger left;
    public Trigger back;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<WorldManager>();

        if (manager.currentSegmentNumber > manager.segmentNumber)
            return;

        bool isValid = false;

        while (!isValid)
        {
            int index = Game.Randomize(0, 3);

            switch (index)
            {
                case FORWARD:
                    isValid = createSegment(forward);
                    break;

                case RIGHT:
                    isValid = createSegment(right);
                    break;

                case LEFT:
                    isValid = createSegment(left);
                    break;

                case BACK:
                    isValid = createSegment(back);
                    break;

                default: break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool createSegment(Trigger trigger)
    {
        if (manager.isAlreadyTaken(trigger.transform.position))
        {
            return false;
        }

        else
        {
            var obj = Instantiate(original, trigger.transform.position, Quaternion.Euler(0, 0, 0));
            manager.addSegment(obj);
            manager.incerementCurrentNumber();
            obj.name = manager.currentSegmentNumber.ToString();
            return true;
        }
    }
}
