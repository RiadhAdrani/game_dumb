using UnityEngine;
using System.Collections.Generic;

public class WorldManager : MonoBehaviour
{

    public int currentSegmentNumber = 0;

    public int segmentNumber = 0;

    public List<Segment> segmentList = new List<Segment>();

    public void addSegment(Segment segment)
    {
        segmentList.Add(segment);
    }

    public void incerementCurrentNumber()
    {
        currentSegmentNumber++;
    }

    public bool isAlreadyTaken(Vector3 position)
    {
        if (segmentList.Count == 0)
        {
            return false;
        }
        else
        {
            foreach (Segment s in segmentList)
            {
                if (s.transform.position == position)
                    return true;
            }
        }

        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
