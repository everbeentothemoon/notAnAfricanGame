using UnityEngine;

public class PipeScript : MonoBehaviour
{
    float[] rotations = { 0, 90, 180, 270 };
    public float[] correctRotation;

    [SerializeField]
    bool isPlaced = false;

    int possibleRots = 1;

    NinkiManager manager;


    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<NinkiManager>();
    }

    private void Start()
    {
        possibleRots = correctRotation.Length;

        // Randomize the starting rotation differently
        transform.eulerAngles = new Vector3(0, 0, rotations[Random.Range(0, rotations.Length)]);

        CheckPlacement();
    }

    private void OnMouseDown()
    {
        // Rotate by 90 degrees on each click
        transform.Rotate(new Vector3(0, 0, 90));
        CheckPlacement();
    }

    private void CheckPlacement()
    {
        if (IsCorrectRotation() && !isPlaced)
        {
            isPlaced = true;
            manager.correctMove();
        }
        else if (isPlaced)
        {
            isPlaced = false;
            manager.wrongMove();
        }
    }

    private bool IsCorrectRotation()
    {
        // Check if the current rotation is approximately equal to any correct rotation
        foreach (float rotation in correctRotation)
        {
            if (Mathf.Approximately(NormalizeAngle(transform.eulerAngles.z), NormalizeAngle(rotation)))
            {
                return true;
            }
        }
        return false;
    }

    private float NormalizeAngle(float angle)
    {
        // Normalize angle to be in the range [0, 360)
        angle %= 360f;
        if (angle < 0)
        {
            angle += 360f;
        }
        return angle;
    }
}
