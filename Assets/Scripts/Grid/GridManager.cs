using System;
using UnityEngine;
using Assets.Scripts.BaseUtils;

namespace Assets.Scripts.Grid
{
    public class GridManager : MonoSingleton<GridManager>
    {
        public int GridX = 10;
        public int GridZ = 10;
        public int GridY = 5;
        public static int CellSize = 1;

        private void Start()
        {
            InitGrid();
        }

        private void InitGrid()
        {
            for (int k = 0; k < GridY; k++)
            {
                GameObject cellLayer = new GameObject();
                cellLayer.name = "CellLayer" + (k + 1).ToString();
                cellLayer.transform.position = gameObject.transform.position + new Vector3(0, k * CellSize, 0);
                cellLayer.transform.parent = gameObject.transform;

                for (int i = 0; i < GridX; i++)
                {
                    for (int j = 0; j < GridZ; j++)
                    {
                        GridCell.CellStatus status;

                        //For develop easily, should change the rule after
                        if (k == 0)
                        {
                            status = GridCell.CellStatus.CanBuild;
                        }
                        else
                        {
                            status = GridCell.CellStatus.CanNotBuild;
                        }

                        Vector3 pos = new Vector3(i * CellSize, k * CellSize, j * CellSize) + gameObject.transform.position;
                        GenerateGridCell(pos, cellLayer, status);                  
                    }
                }
            }
        }

        private void GenerateGridCell(Vector3 pos, GameObject cellLayer, GridCell.CellStatus status)
        {
            GameObject cell = new GameObject();
            cell.name = "Cell_" + "x" + pos.x.ToString() + "y" + pos.y.ToString() + "z" + pos.z.ToString();
            cell.transform.position = pos;
            cell.transform.parent = cellLayer.transform;
            cell.AddComponent<GridCell>();
            cell.GetComponent<GridCell>().SetStatus(status);
        }
    }
}