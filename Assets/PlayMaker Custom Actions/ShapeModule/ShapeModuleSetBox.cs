﻿// (c) Copyright HutongGames, LLC 2010-2020. All rights reserved.  
// License: Attribution 4.0 International(CC BY 4.0) 
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Shuriken/ShapeModule")]
	[Tooltip("Set the box of a particleSystem's ShapeModule ( Shuriken)")]
	public class ShapeModuleSetBox : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(ParticleSystem))]
		[Tooltip("The GameObject with the particleSystem")]
		public FsmOwnerDefault gameObject;

		[Tooltip("The shape box")]
		public FsmVector3 box;

		[Tooltip("Repeat every frame while the state is active.")]
		public bool everyFrame;

		GameObject _go;
		ParticleSystem _ps;
		ParticleSystem.ShapeModule _sm;

		public override void Reset()
		{
			gameObject = null;
			box = null;
			everyFrame = false;
		}


		public override void OnEnter()
		{
			_go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (_go==null)
			{
				return;
			}
			_ps = _go.GetComponent<ParticleSystem> ();
			if (_ps==null)
			{
				return;
			}
			_sm = _ps.shape;

			DoExecute();

			if (!everyFrame)
			{
				Finish();
			}		
		}

		public override void OnUpdate()
		{
			DoExecute();
		}

		void DoExecute()
		{
			_sm.scale = box.Value;
		}

	}
}