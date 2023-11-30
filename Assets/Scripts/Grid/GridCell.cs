using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Grid
{
    public class GridCell : MonoBehaviour
    {
        public enum CellStatus
        {
            CanNotBuild,
            CanBuild,
            HasBuild
        }

        private CellStatus _currentStatus;

        public void SetStatus(CellStatus status)
        {
            _currentStatus = status;
            if(_currentStatus == CellStatus.CanBuild)
            {
                gameObject.AddComponent<BoxCollider>();
                BoxCollider col = gameObject.GetComponent<BoxCollider>();
                col.center = new Vector3(0.5f, 0.5f, 0.5f);
                col.isTrigger = true;
            }
        }

        public CellStatus CurrentStatus()
        {
            return _currentStatus;
        }
    }
}