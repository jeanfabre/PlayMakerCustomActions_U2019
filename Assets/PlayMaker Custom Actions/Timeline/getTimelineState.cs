// (c) Copyright HutongGames, LLC 2010-2017. All rights reserved.
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using UnityEngine.Playables;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Timeline")]
	[Tooltip("Get the current timeline's state as a bool. True for playing, false for paused.")]

	public class  getTimelineState : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(PlayableDirector))]
		[Tooltip("The game object to hold the unity timeline components.")]
		public FsmOwnerDefault gameObject;
		
		[Tooltip("Returns the current timeline state as a bool. True for playing, false for paused")]
		[UIHint(UIHint.Variable)]
		public FsmBool playing;
		
		[Tooltip("Check this box to preform this action every frame.")]
		public FsmBool everyFrame;
		
		private PlayState _playstate;
		enum Playstate { Paused, Playing };
		private PlayableDirector timeline;

		public override void Reset()
		{

			gameObject = null;
			everyFrame = false;
			playing = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			timeline = go.GetComponent<PlayableDirector>();

			if (!everyFrame.Value)
			{
				timelineAction();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				timelineAction();
			}
		}

		void timelineAction()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null || timeline == null)
			{
				return;
			}
		
			if(timeline.state == PlayState.Playing)
			{
				playing.Value = true;
			}else{
				playing.Value = false;
			}
				
		}

	}
}