using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace yc
{
	/*
	 * 
	 *	[System.Serializable][StructLayout(LayoutKind.Sequential, Pack = 1)]
	 *	[MarshalAs(UnmanagedType.ByValArray, SizeConst = wchar(C# char) 배열이면 X2...)]
	 * 
	 */

	public struct vec2_t
	{
		public float x;
		public float y;
	}
}