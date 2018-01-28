using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITowerNode : MonoBehaviour
{

    public bool Powered = false;
    public int XLocation = 0;
    public int YLocation = 0;
    public R11.NodeType UINodeType = R11.NodeType.Straight;
    public int RotationState = 0;

    internal bool PowerCheck = false;

    // Use this for initialization
    void Start()
    {
        transform.parent.GetComponent<TowerGrid>().AddNode(this, XLocation, YLocation);
    }

    public void NodeClick()
    {
        var temp_image = transform.Find("Image").transform;
        temp_image.rotation = Quaternion.Euler(0, 0, (temp_image.rotation.eulerAngles.z - 90));
        if (RotationState == 3)
            RotationState = 0;
        else
            RotationState = RotationState + 1;
        transform.parent.GetComponent<TowerGrid>().CheckGrid();

        //switch (UINodeType)
        //{
        //    case R11.NodeType.T:
        //        #region T
        //        transform.parent.GetComponent<TowerGrid>().CheckPowered(XLocation + 1, YLocation);
        //        break;
        //        #endregion
        //}
    }

    internal void ChangePowered(bool inc_state)
    {
        if (UINodeType == R11.NodeType.NStart)
            return;
        Powered = inc_state;
    }

    internal void ChangePowerCheck(bool inc_state)
    {
        if (UINodeType == R11.NodeType.NStart)
        {
            PowerCheck = true;
            return;
        }
        PowerCheck = inc_state;
    }

    internal void PowerGrid()
    {
        List<UITowerNode> connected_nodes = new List<UITowerNode>();
        UITowerNode checked_node = null;
        switch (UINodeType)
        {
            case R11.NodeType.NStart:
                checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation, YLocation + 1);
                if (checked_node.RotationState != 3)
                    connected_nodes.Add(checked_node);
                break;

            case R11.NodeType.Corner:
                switch(RotationState)
                {
                    case 0:
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation, YLocation + 1);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 1 || checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                        }
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation + 1, YLocation);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 1 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 0)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 2 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                        }
                        break;
                    case 1:
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation + 1, YLocation);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 1 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 0)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 2 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                        }
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation, YLocation - 1);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 1)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 0)
                                    connected_nodes.Add(checked_node);
                        }
                        break;
                    case 2:
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation, YLocation - 1);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 1)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 0)
                                    connected_nodes.Add(checked_node);
                        }
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation - 1, YLocation);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 1 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 1)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 1)
                                    connected_nodes.Add(checked_node);
                        }
                        break;
                    case 3:
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation, YLocation + 1);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 1 || checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                        }
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation - 1, YLocation);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 1 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 1)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 1)
                                    connected_nodes.Add(checked_node);
                        }
                        break;
                }
                break;
            case R11.NodeType.Straight:
                switch (RotationState)
                {
                    case 0:
                    case 2:
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation, YLocation + 1);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 1 || checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                        }
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation, YLocation - 1);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 1)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 0)
                                    connected_nodes.Add(checked_node);
                        }
                        break;
                    case 1:
                    case 3:
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation + 1, YLocation);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 1 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 0)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 2 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                        }
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation - 1, YLocation);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 1 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 1)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 1)
                                    connected_nodes.Add(checked_node);
                        }
                        break;
                }
                break;
            case R11.NodeType.T:
                switch(RotationState)
                {
                    case 0:
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation, YLocation + 1);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 1 || checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                        }
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation + 1, YLocation);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 1 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 0)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 2 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                        }
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation, YLocation - 1);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 1)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 0)
                                    connected_nodes.Add(checked_node);
                        }
                        break;
                    case 1:
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation + 1, YLocation);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 1 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 0)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 2 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                        }
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation, YLocation - 1);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 1)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 0)
                                    connected_nodes.Add(checked_node);
                        }
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation - 1, YLocation);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 1 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 1)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 1)
                                    connected_nodes.Add(checked_node);
                        }
                        break;
                    case 2:
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation, YLocation - 1);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 1)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 0)
                                    connected_nodes.Add(checked_node);
                        }
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation - 1, YLocation);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 1 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 1)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 1)
                                    connected_nodes.Add(checked_node);
                        }
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation, YLocation + 1);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 1 || checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                        }
                        break;
                    case 3:
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation - 1, YLocation);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 1 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 1)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 1)
                                    connected_nodes.Add(checked_node);
                        }
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation, YLocation + 1);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 0 || checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 1 || checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 2)
                                    connected_nodes.Add(checked_node);
                        }
                        checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation + 1, YLocation);
                        if (!checked_node.PowerCheck)
                        {
                            if (checked_node.UINodeType == R11.NodeType.Straight)
                                if (checked_node.RotationState == 1 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.T)
                                if (checked_node.RotationState != 0)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.Corner)
                                if (checked_node.RotationState == 2 || checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                            if (checked_node.UINodeType == R11.NodeType.NGoal)
                                if (checked_node.RotationState == 3)
                                    connected_nodes.Add(checked_node);
                        }
                        break;

                }
                //checked_node = transform.parent.GetComponent<TowerGrid>().GetNode(XLocation, YLocation + 1);
                //if (checked_node.RotationState != 3)
                //    connected_nodes.Add(checked_node);
                break;
        }
        foreach (var temp_node in connected_nodes)
        {
            temp_node.Powered = true;
            temp_node.PowerCheck = true;
            
            temp_node.PowerGrid();
        }
    }
}
