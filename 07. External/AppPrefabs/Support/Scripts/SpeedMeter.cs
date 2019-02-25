// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using HoloToolkit.Unity.Controllers;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

#if UNITY_WSA && UNITY_2017_2_OR_NEWER
using UnityEngine.XR.WSA.Input;
#endif

namespace HoloToolkit.Unity.ControllerExamples
{
    public class SpeedMeter : AttachToController, IPointerTarget
    {
        private Vector2 selectorPosition;
        private GameObject player;
        private MoveCtrl player_move_script;
        private float playerSpeed;
        private bool previousGraspedCondition = false;

        private void Update()
        { }

        protected override void OnAttachToController()
        {
#if UNITY_WSA && UNITY_2017_2_OR_NEWER
            // Subscribe to input now that we're parented under the controller
            InteractionManager.InteractionSourceUpdated += InteractionSourceUpdated;
#endif
        }

        protected override void OnDetachFromController()
        {
#if UNITY_WSA && UNITY_2017_2_OR_NEWER
            // Unsubscribe from input now that we've detached from the controller
            InteractionManager.InteractionSourceUpdated -= InteractionSourceUpdated;
#endif
        }

        public void OnPointerTarget(PhysicsPointer source)
        {
            // If we're opening or closing, don't set the color value
        }

#if UNITY_WSA && UNITY_2017_2_OR_NEWER
        private void InteractionSourceUpdated(InteractionSourceUpdatedEventArgs obj)
        {
            if (obj.state.source.handedness == Handedness & obj.state.grasped & !previousGraspedCondition)
            {
                //Debug.Log("grasped:" + obj.state.grasped);
                previousGraspedCondition = true;
            }

            if (obj.state.source.handedness == Handedness & !obj.state.grasped & previousGraspedCondition)
            {
                //Debug.Log("grasped:" + obj.state.grasped);

                player = GameObject.Find("Player - MRCP");
                player_move_script = player.GetComponent<MoveCtrl>();
                
                if (player_move_script.moveSpeed == 0)
                    player_move_script.moveSpeed = 1.0f;
                else
                    player_move_script.moveSpeed = 0.0f;

                previousGraspedCondition = false;
            }
        }
#endif
    }
}
