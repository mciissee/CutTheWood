using UnityEngine;
using InfinityEngine;
using InfinityEngine.Serialization;

namespace InfinityEngine.Serialization {
	///<summary>
	///	This class is generated automaticaly by InfinityEngine, it contains constants used by many scripts.  DO NOT EDIT IT !
	///</summary>
	public static class R2 {

	public struct PrefGetSet<T>{
		private string mKey;

		///<summary> The key of the encapsulated preference</summary>
		public string Key { get { return mKey; } }

		///<summary> The value of the encapsulated preference</summary>
		public T Value { get { return VP.Get<T>(mKey); } set { VP.Set(mKey, value); } }

		///<summary>Creates new instance of this struct</summary>
		public PrefGetSet(string key)
		 {
			 mKey = key;
		 }
	}

	public static class integers {

		///<summary>
		///All Integer keys separated by ','. You can created an array by using string.split() method
		///</summary>

		public const string Names = "ClassicModeBest,ArcadeModeBest";
		///<summary>
		///Integer preference with the key ClassicModeBest. If you want to access or modify the value of this preference, use R2.Integer.ClassicModeBest.Value else if you want to access the key, use R2.Integer.ClassicModeBest.Key . 
		///</summary>

		public static PrefGetSet<int> ClassicModeBest = new  PrefGetSet<int> ("ClassicModeBest");
		///<summary>
		///Integer preference with the key ArcadeModeBest. If you want to access or modify the value of this preference, use R2.Integer.ArcadeModeBest.Value else if you want to access the key, use R2.Integer.ArcadeModeBest.Key . 
		///</summary>

		public static PrefGetSet<int> ArcadeModeBest = new  PrefGetSet<int> ("ArcadeModeBest");

	 }
	public static class floats {

		///<summary>
		///All Float keys separated by ','. You can created an array by using string.split() method
		///</summary>

		public const string Names = "";

	 }
	public static class doubles {

		///<summary>
		///All Double keys separated by ','. You can created an array by using string.split() method
		///</summary>

		public const string Names = "";

	 }
	public static class longs {

		///<summary>
		///All Long keys separated by ','. You can created an array by using string.split() method
		///</summary>

		public const string Names = "";

	 }
	public static class strings {

		///<summary>
		///All String keys separated by ','. You can created an array by using string.split() method
		///</summary>

		public const string Names = "";

	 }
	public static class bools {

		///<summary>
		///All Bool keys separated by ','. You can created an array by using string.split() method
		///</summary>

		public const string Names = "ENABLE_LOG";
		///<summary>
		///Bool preference with the key ENABLE_LOG. If you want to access or modify the value of this preference, use R2.Bool.ENABLE_LOG.Value else if you want to access the key, use R2.Bool.ENABLE_LOG.Key . 
		///</summary>

		public static PrefGetSet<bool> ENABLE_LOG = new  PrefGetSet<bool> ("ENABLE_LOG");

	 }
	public static class vector2s {

		///<summary>
		///All Vector2 keys separated by ','. You can created an array by using string.split() method
		///</summary>

		public const string Names = "";

	 }
	public static class vector3s {

		///<summary>
		///All Vector3 keys separated by ','. You can created an array by using string.split() method
		///</summary>

		public const string Names = "";

	 }
	public static class vector4s {

		///<summary>
		///All Vector4 keys separated by ','. You can created an array by using string.split() method
		///</summary>

		public const string Names = "";

	 }
	public static class quaternions {

		///<summary>
		///All Quaternion keys separated by ','. You can created an array by using string.split() method
		///</summary>

		public const string Names = "";

	 }
	public static class colors {

		///<summary>
		///All Color keys separated by ','. You can created an array by using string.split() method
		///</summary>

		public const string Names = "";

	 }
	}
}
