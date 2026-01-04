using System.Collections.Generic;
using UnityEngine;

public class PlankManager : MonoBehaviour
{
    private readonly List<GameObject> placedPlanks = new();

    public IReadOnlyList<GameObject> PlacedPlanks => placedPlanks;

    public void RegisterPlacedPlank(GameObject plank)
    {
        placedPlanks.Add(plank);
    }

    public void UnregisterPlacedPlank(GameObject plank)
    {
        placedPlanks.Remove(plank);
    }
}
