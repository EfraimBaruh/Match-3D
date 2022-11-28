using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    public MatchControlAxis controlAxis;

    private int _controllerID;
    private int _controllerSize;
    private List<int> AxisData = new List<int>();

    public void SetController(MatchControlAxis axis, LevelConfigurationScriptable config, int id)
    {
        controlAxis = axis;
        _controllerID = id;
        _controllerSize = controlAxis == MatchControlAxis.column ? config.ColumnSize : config.RowSize;
    }

    private void ControlAxis(int dropAxis, int dropPos, SwipeDirection direction)
    {
        // if swiped drops axis not even near the controlleraxis, pass this controller.
        if(Mathf.Abs(dropAxis - _controllerID) > 1)
            return;
        // if swipe direction and match control axis does not match do not bother.
        if(controlAxis == MatchControlAxis.column && (int)direction > 1)
            return;
        else if(controlAxis == MatchControlAxis.row && (int)direction < 2)
            return;
        else if(dropAxis != _controllerID)
            return;
        
        Debug.Log($"There is possible match @ the {_controllerID}. {controlAxis}");
        
        // TODO: if there is any match, call match event.

        
        
    }

    private void UpdateAxis()
    {
        // Update current drop types in the axis.
    }

    private void OnEnable()
    {
        // Subscribe to event that controls for match
        Events.GameEvents.ControlMatch.AddListener(ControlAxis);
        // Subscribe to event that called after table is refreshed with new drops.
        Events.GameEvents.MatchActionCompleted.AddListener(UpdateAxis);
    }
    
    private void OnDisable()
    {
        // UnSubscribe to event that controls for match
        Events.GameEvents.ControlMatch.RemoveListener(ControlAxis);
        // UnSubscribe to event that called after table is refreshed with new drops.
        Events.GameEvents.MatchActionCompleted.RemoveListener(UpdateAxis);


    }
}
