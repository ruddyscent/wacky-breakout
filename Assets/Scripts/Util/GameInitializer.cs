using UnityEngine;

/// <summary>
/// Initializes the game
/// </summary>
public class GameInitializer : MonoBehaviour 
{
    /// <summary>
    /// Awake is called before Start
    /// </summary>
	void Awake()
    {
        // initialize screen utils
        ScreenUtils.Initialize();
        ConfigurationUtils.Initialize();

        Vector2[] colliderpoints;
        EdgeCollider2D upperEdge = new GameObject("upperEdge").AddComponent<EdgeCollider2D>();
        colliderpoints = upperEdge.points;
        colliderpoints[0] = new Vector2(ScreenUtils.ScreenLeft, ScreenUtils.ScreenTop);
        colliderpoints[1] = new Vector2(ScreenUtils.ScreenRight, ScreenUtils.ScreenTop);
        upperEdge.points = colliderpoints;

        EdgeCollider2D leftEdge = new GameObject("leftEdge").AddComponent<EdgeCollider2D>();
        colliderpoints = leftEdge.points;
        colliderpoints[0] = new Vector2(ScreenUtils.ScreenLeft, ScreenUtils.ScreenBottom);
        colliderpoints[1] = new Vector2(ScreenUtils.ScreenLeft, ScreenUtils.ScreenTop);
        leftEdge.points = colliderpoints;

        EdgeCollider2D rightEdge = new GameObject("rightEdge").AddComponent<EdgeCollider2D>();

        colliderpoints = rightEdge.points;
        colliderpoints[0] = new Vector2(ScreenUtils.ScreenRight, ScreenUtils.ScreenBottom);
        colliderpoints[1] = new Vector2(ScreenUtils.ScreenRight, ScreenUtils.ScreenTop);
        rightEdge.points = colliderpoints;
    }
}
