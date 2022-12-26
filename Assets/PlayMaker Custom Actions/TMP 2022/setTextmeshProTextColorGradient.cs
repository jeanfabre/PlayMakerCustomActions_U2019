// (c) Eric Vander Wal, 2017 All rights reserved.
// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using TMPro;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("TextMesh Pro Basic")]
    [Tooltip("Set Text Mesh Pro text color using a gradient.")]
    public class setTextmeshProTextColorGradient : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(TextMeshPro))]
        [Tooltip("Textmesh Pro component is required.")]
        public FsmOwnerDefault gameObject;

        public FsmColor topLeft;
        public FsmColor topRight;
        public FsmColor bottomLeft;
        public FsmColor bottomRight;

        private Color _bottomRight;

        [Tooltip("Check this box to preform this action every frame.")]
        public FsmBool everyFrame;

        TextMeshPro meshproScript;

        public override void Reset()
        {
            gameObject = null;
            topLeft = null;
            topRight = null;
            bottomRight = null;
            bottomLeft = null;
            everyFrame = false;
        }

        public override void OnEnter()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            meshproScript = go.GetComponent<TextMeshPro>();

            DoMeshChange();

            if (!everyFrame.Value)
            {
                Finish();
            }
        }

        public override void OnUpdate()
        {
            if (everyFrame.Value)
            {
                DoMeshChange();
            }
        }

        void DoMeshChange()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null)
            {
                return;
            }

            if (meshproScript == null)
            {
                Debug.LogError("No textmesh pro component was found on " + go);
                return;
            }

            var cG = meshproScript.colorGradient;
            cG.topLeft = topLeft.Value;
            meshproScript.colorGradient = cG;

            cG.topRight = topRight.Value;
            meshproScript.colorGradient = cG;

            cG.bottomLeft = bottomLeft.Value;
            meshproScript.colorGradient = cG;

            cG.bottomRight = bottomRight.Value;
            meshproScript.colorGradient = cG;
        }
    }
}