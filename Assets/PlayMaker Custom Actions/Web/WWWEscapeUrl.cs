// (c) Copyright HutongGames, LLC 2010-2020. All rights reserved.  
// License: Attribution 4.0 International(CC BY 4.0) 
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
#pragma warning disable 618

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.String)]
	[Tooltip("Escape a Url String to be used. don't escape the whole url, only the portion for the getter values.")]
	public class WWWEscapeUrl : FsmStateAction
	{
		[RequiredField]
		public FsmString stringSource;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmString escapedString;
		
		public bool everyFrame;

		public override void Reset()
		{
			stringSource = null;
			escapedString = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			DoEscape();
			
			if (!everyFrame)
				Finish();
		}

		public override void OnUpdate()
		{
			DoEscape();
		}
		
		void DoEscape()
		{
			if (escapedString.IsNone) return;
			
			escapedString.Value = WWW.EscapeURL(stringSource.Value);
		}
		
	}
}
