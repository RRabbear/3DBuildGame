using UnityEngine;
using Assets.Scripts.Grid;
using Assets.Scripts.InputActions;
using UnityEngine.InputSystem;

namespace Assets.Scripts.BuildSystem
{
    public class BuildManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _buildItem;
        [SerializeField]
        private GridManager _gridManager;

        Vector3 _position;
        GridCell _cell;

        private void Update()
        {
            if (InputActionsHandler.Instance.IsMouseLeftDown
                && _cell.CurrentStatus() == GridCell.CellStatus.CanBuild)
            {
                Build(_buildItem, _position, _cell);
                Debug.Log("build finished");
            }
        }

        private void FixedUpdate()
        {
            Ray ray = Camera.main.ScreenPointToRay(InputActionsHandler.Instance.MousePos2D);
            RaycastHit hit;
            Debug.DrawLine(ray.origin, ray.direction * 1000, Color.red);
            if (Physics.Raycast(ray, out hit)
                && hit.collider != null
                && hit.collider.GetComponentInParent<GridCell>() != null)
            {
                _cell = hit.collider.GetComponentInParent<GridCell>();
                _position = hit.collider.transform.position;
            }
        }

        public void Build(GameObject item, Vector3 pos, GridCell cell)
        {
            GameObject currentBuildItem = Instantiate(item, pos, Quaternion.identity);
            currentBuildItem.SetActive(true);
            cell.SetStatus(GridCell.CellStatus.HasBuild);
        }
    }
}