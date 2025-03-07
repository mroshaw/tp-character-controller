using System;
using System.Collections.Generic;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace DaftAppleGames.TpCharacterController.AiController.BehaviourTree.Actions
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "AI Look for Target", story: "[Agent] looks for a [Target] tagged [Tags]", category: "Action", id: "b728d27c0a1f72cf322961b6b939b7a4")]
    public partial class LookForTarget : AiBrainAction
    {
        [SerializeReference] public BlackboardVariable<Transform> Target;
        [SerializeReference] public BlackboardVariable<List<string>> Tags;
        private GameObject _detectedTarget;

        protected override Status OnStart()
        {
            if (!Init())
            {
                return Status.Failure;
            }

            _detectedTarget = AiBrain.DetectorManager.GetClosestTargetWithTags(Tags);

            if (_detectedTarget)
            {
                Target.Value = _detectedTarget.transform;
                return Status.Success;
            }

            return Status.Failure;
        }
    }
}