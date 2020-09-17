using UnityEngine;

public class StandardBlock : Block
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        points = ConfigurationUtils.StandardBlockPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
