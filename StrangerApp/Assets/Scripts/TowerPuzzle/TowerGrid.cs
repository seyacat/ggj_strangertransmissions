using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerGrid : MonoBehaviour
{
    public bool solved = false;
    List<List<TowerNodeHolder>> node_grid = new List<List<TowerNodeHolder>>();
    List<UITowerNode> goal_nodes = new List<UITowerNode>();

    public int start_column = 4;
    public int rows = 13;
    public int columns = 9;

    // Use this for initialization
    void Awake()
    {
        for (int i = 0; i < columns; i++)
        {
            //x_layer[i] = new TowerNode[12];
            node_grid.Add(new List<TowerNodeHolder>());

            for (int j = 0; j < rows; j++)
            {
                TowerNodeHolder temp_node = new TowerNodeHolder();
                //temp_node.x_position = i;
                //temp_node.y_position = j;
                node_grid[i].Add(temp_node);
                //Debug.Log("["+i+"]["+j+"]");
            }
        }
        //SetStartingStates();
    }

    void SetStartingStates()
    {
        //node_grid
    }

    internal void AddNode(UITowerNode inc_node, int inc_x, int inc_y)
    {
        //Debug.Log("Adding: [" + inc_x + "][" + inc_y + "]");
        node_grid[inc_x][inc_y].node = inc_node;
        if (inc_node.UINodeType == R11.NodeType.NGoal)
            goal_nodes.Add(inc_node);
    }

    public void CheckPowered(int inc_x, int inc_y)
    {
        //node_grid[inc_x][inc_y].node.Powered;
    }

    public UITowerNode GetNode(int inc_x, int inc_y)
    {
        return node_grid[inc_x][inc_y].node;
    }
    int previous_goals = 0;
    public void CheckGrid()
    {
        ResetGrid();
        node_grid[start_column][0].node.PowerGrid();// Powered = true;
        ColorGrid();
        bool temp_solved = true;
        foreach (var goal in goal_nodes)
            if (goal.Powered == false)
            {
                temp_solved = false;
                break;
            }
        
        solved = temp_solved;
        if (solved)
        {
            transform.parent.Find("Sounds").Find("Solved").GetComponent<AudioSource>().Play();
        }
        else
        {
            int goals_reached = 0;
            foreach (var goal in goal_nodes)
                if (goal.Powered)
                    goals_reached++;
            if (goals_reached > previous_goals)
            {
                transform.parent.Find("Sounds").Find("Reached").GetComponent<AudioSource>().Play();
            }
            else
            {
                transform.parent.Find("Sounds").Find("Clicked").GetComponent<AudioSource>().Play();
            }
            previous_goals = goals_reached;
        }
    }

    void ResetGrid()
    {
        for (int i = 0; i < columns; i++)
            for (int j = 0; j < rows; j++)
            {
                //Debug.Log("Checking: [" + i + "][" + j + "]");
                var temp_node = node_grid[i][j].node;
                if (temp_node != null)
                {
                    temp_node.ChangePowered(false);
                    temp_node.ChangePowerCheck(false);
                }
                else
                    Debug.LogError("Error Reset: [" + i + "][" + j + "]");
            }
    }

    void ColorGrid()
    {
        for (int i = 0; i < columns; i++)
            for (int j = 0; j < rows; j++)
            {
                var temp_node = node_grid[i][j].node;
                if (temp_node != null)
                {
                    if (temp_node.Powered)//ChangePowered(false);
                    {
                        if (temp_node.transform.Find("Image") != null)
                            temp_node.transform.Find("Image").GetComponent<Image>().color = Color.yellow;
                        if (temp_node.transform.Find("Image (1)") != null)
                            temp_node.transform.Find("Image (1)").GetComponent<Image>().color = Color.yellow;
                    }
                    else
                    {
                        if (temp_node.transform.Find("Image (1)") != null)
                            temp_node.transform.Find("Image (1)").GetComponent<Image>().color = Color.white;
                        if (temp_node.UINodeType == R11.NodeType.NGoal)
                        {
                            if (temp_node.transform.Find("Image") != null)
                                temp_node.transform.Find("Image").GetComponent<Image>().color = new Color32(66, 66, 66, 255);
                        }
                        else
                        {
                            if (temp_node.transform.Find("Image") != null)
                                temp_node.transform.Find("Image").GetComponent<Image>().color = Color.white;
                        }
                    }
                }
                else
                {
                    Debug.LogError("Error Color: [" + i + "][" + j + "]");
                }
            }

    }
    
}
