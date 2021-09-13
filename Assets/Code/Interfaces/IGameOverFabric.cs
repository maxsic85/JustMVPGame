
using System;
using UnityEngine;

namespace Code.MVC
{
   public interface IGameOverFabric
    {
        RectTransform CreateGO();
        event Action OntriggerChange;
    }
}
