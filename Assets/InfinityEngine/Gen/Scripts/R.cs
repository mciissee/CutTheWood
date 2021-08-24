#pragma warning disable IDE1006 // Naming Styles
using UnityEngine;
using System.Xml;
namespace InfinityEngine.ResourceManagement {
	/// <summary>This class is generated automaticaly by InfinityEngine, it contains constants used by many scripts.  DO NOT EDIT IT !</summary>
	public static class R {
		public static class animationclip {
			public const string Names = "";
		}
		public static class audioclip {
			public const string Names = "background-music,bomb-fuse,explosion,combo,combo-1,combo-2,falldown,golden-wood-hit,MetalGongSound,TempleBellSound,launch-bomb,launch-wood,slice,slice-1,slice-2,slice-3,blade-swipe-1,blade-swipe-2,blade-swipe-3,blade-swipe-4,blade-swipe-5,blade-swipe-6,blade-butterfly-swipe-1,blade-butterfly-swipe-2,blade-butterfly-swipe-3,blade-butterfly-swipe-4,sword-swipe-1,sword-swipe-2,sword-swipe-3,sword-swipe-4,sword-swipe-5,sword-swipe-6,Time-tick";
			public static AudioClip BackgroundMusic => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "background-music");
			public static AudioClip BombFuse => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "bomb-fuse");
			public static AudioClip Explosion => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "explosion");
			public static AudioClip Combo => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "combo");
			public static AudioClip Combo1 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "combo-1");
			public static AudioClip Combo2 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "combo-2");
			public static AudioClip Falldown => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "falldown");
			public static AudioClip GoldenWoodHit => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "golden-wood-hit");
			public static AudioClip MetalGongSound => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "MetalGongSound");
			public static AudioClip TempleBellSound => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "TempleBellSound");
			public static AudioClip LaunchBomb => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "launch-bomb");
			public static AudioClip LaunchWood => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "launch-wood");
			public static AudioClip Slice => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "slice");
			public static AudioClip Slice1 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "slice-1");
			public static AudioClip Slice2 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "slice-2");
			public static AudioClip Slice3 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "slice-3");
			public static AudioClip BladeSwipe1 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "blade-swipe-1");
			public static AudioClip BladeSwipe2 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "blade-swipe-2");
			public static AudioClip BladeSwipe3 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "blade-swipe-3");
			public static AudioClip BladeSwipe4 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "blade-swipe-4");
			public static AudioClip BladeSwipe5 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "blade-swipe-5");
			public static AudioClip BladeSwipe6 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "blade-swipe-6");
			public static AudioClip BladeButterflySwipe1 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "blade-butterfly-swipe-1");
			public static AudioClip BladeButterflySwipe2 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "blade-butterfly-swipe-2");
			public static AudioClip BladeButterflySwipe3 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "blade-butterfly-swipe-3");
			public static AudioClip BladeButterflySwipe4 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "blade-butterfly-swipe-4");
			public static AudioClip SwordSwipe1 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "sword-swipe-1");
			public static AudioClip SwordSwipe2 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "sword-swipe-2");
			public static AudioClip SwordSwipe3 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "sword-swipe-3");
			public static AudioClip SwordSwipe4 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "sword-swipe-4");
			public static AudioClip SwordSwipe5 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "sword-swipe-5");
			public static AudioClip SwordSwipe6 => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "sword-swipe-6");
			public static AudioClip TimeTick => ISIResource.Find<AudioClip>(ResTypes.AudioClip, "Time-tick");
		}
		public static class font {
			public const string Names = "";
		}
		public static class gameobject {
			public const string Names = "GoldenBlade,LeafBlade,OriginalBlade,Bomb,BombParticle,WoodFragments,GoldenWood,WoodA,WoodB,WoodC,WoodD,WoodE,WoodTemplate";
			public static GameObject GoldenBlade => ISIResource.Find<GameObject>(ResTypes.GameObject, "GoldenBlade");
			public static GameObject LeafBlade => ISIResource.Find<GameObject>(ResTypes.GameObject, "LeafBlade");
			public static GameObject OriginalBlade => ISIResource.Find<GameObject>(ResTypes.GameObject, "OriginalBlade");
			public static GameObject Bomb => ISIResource.Find<GameObject>(ResTypes.GameObject, "Bomb");
			public static GameObject BombParticle => ISIResource.Find<GameObject>(ResTypes.GameObject, "BombParticle");
			public static GameObject WoodFragments => ISIResource.Find<GameObject>(ResTypes.GameObject, "WoodFragments");
			public static GameObject GoldenWood => ISIResource.Find<GameObject>(ResTypes.GameObject, "GoldenWood");
			public static GameObject WoodA => ISIResource.Find<GameObject>(ResTypes.GameObject, "WoodA");
			public static GameObject WoodB => ISIResource.Find<GameObject>(ResTypes.GameObject, "WoodB");
			public static GameObject WoodC => ISIResource.Find<GameObject>(ResTypes.GameObject, "WoodC");
			public static GameObject WoodD => ISIResource.Find<GameObject>(ResTypes.GameObject, "WoodD");
			public static GameObject WoodE => ISIResource.Find<GameObject>(ResTypes.GameObject, "WoodE");
			public static GameObject WoodTemplate => ISIResource.Find<GameObject>(ResTypes.GameObject, "WoodTemplate");
		}
		public static class guiskin {
			public const string Names = "";
		}
		public static class material {
			public const string Names = "";
		}
		public static class mesh {
			public const string Names = "";
		}
		public static class physicmaterial {
			public const string Names = "";
		}
		public static class physicsmaterial2d {
			public const string Names = "";
		}
		public static class shader {
			public const string Names = "";
		}
		public static class sprite {
			public const string Names = "background,backgroundB,BackgroundC,BackgroundD,BackgroundE,BGGradient,BlastStar,Bomb,BurstRing,Fire,GlowRing,Smoke,Jelly,leaf,Leaves_0,Leaves_1,Leaves_2,shamrock,Hand01,Hand02,Hand03,life_0,life_1,WoodUI_0,WoodUI_1,WoodUI_2,WoodUI_3,WoodUI_4,WoodUI_5,WoodUI_6,WoodUI_7,WoodUI_8,WoodUI_9,WoodUI_10,WoodUI_11,WoodUI_12,WoodUI_13,VignetteReg,WideStar_Glow,Trace,WoodFragments,Woods_0,Woods_1,Woods_2,Woods_3,Woods_4,Woods_5,Woods_6,Woods_7,Woods_8,Woods_9,Woods_10,Woods_11,Woods_12,Woods_13,Woods_14,Woods_15,Woods_16,Woods_17";
			public static Sprite Background => ISIResource.Find<Sprite>(ResTypes.Sprite, "background");
			public static Sprite BackgroundB => ISIResource.Find<Sprite>(ResTypes.Sprite, "backgroundB");
			public static Sprite BackgroundC => ISIResource.Find<Sprite>(ResTypes.Sprite, "BackgroundC");
			public static Sprite BackgroundD => ISIResource.Find<Sprite>(ResTypes.Sprite, "BackgroundD");
			public static Sprite BackgroundE => ISIResource.Find<Sprite>(ResTypes.Sprite, "BackgroundE");
			public static Sprite BGGradient => ISIResource.Find<Sprite>(ResTypes.Sprite, "BGGradient");
			public static Sprite BlastStar => ISIResource.Find<Sprite>(ResTypes.Sprite, "BlastStar");
			public static Sprite Bomb => ISIResource.Find<Sprite>(ResTypes.Sprite, "Bomb");
			public static Sprite BurstRing => ISIResource.Find<Sprite>(ResTypes.Sprite, "BurstRing");
			public static Sprite Fire => ISIResource.Find<Sprite>(ResTypes.Sprite, "Fire");
			public static Sprite GlowRing => ISIResource.Find<Sprite>(ResTypes.Sprite, "GlowRing");
			public static Sprite Smoke => ISIResource.Find<Sprite>(ResTypes.Sprite, "Smoke");
			public static Sprite Jelly => ISIResource.Find<Sprite>(ResTypes.Sprite, "Jelly");
			public static Sprite Leaf => ISIResource.Find<Sprite>(ResTypes.Sprite, "leaf");
			public static Sprite Leaves0 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Leaves_0");
			public static Sprite Leaves1 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Leaves_1");
			public static Sprite Leaves2 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Leaves_2");
			public static Sprite Shamrock => ISIResource.Find<Sprite>(ResTypes.Sprite, "shamrock");
			public static Sprite Hand01 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Hand01");
			public static Sprite Hand02 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Hand02");
			public static Sprite Hand03 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Hand03");
			public static Sprite Life0 => ISIResource.Find<Sprite>(ResTypes.Sprite, "life_0");
			public static Sprite Life1 => ISIResource.Find<Sprite>(ResTypes.Sprite, "life_1");
			public static Sprite WoodUI0 => ISIResource.Find<Sprite>(ResTypes.Sprite, "WoodUI_0");
			public static Sprite WoodUI1 => ISIResource.Find<Sprite>(ResTypes.Sprite, "WoodUI_1");
			public static Sprite WoodUI2 => ISIResource.Find<Sprite>(ResTypes.Sprite, "WoodUI_2");
			public static Sprite WoodUI3 => ISIResource.Find<Sprite>(ResTypes.Sprite, "WoodUI_3");
			public static Sprite WoodUI4 => ISIResource.Find<Sprite>(ResTypes.Sprite, "WoodUI_4");
			public static Sprite WoodUI5 => ISIResource.Find<Sprite>(ResTypes.Sprite, "WoodUI_5");
			public static Sprite WoodUI6 => ISIResource.Find<Sprite>(ResTypes.Sprite, "WoodUI_6");
			public static Sprite WoodUI7 => ISIResource.Find<Sprite>(ResTypes.Sprite, "WoodUI_7");
			public static Sprite WoodUI8 => ISIResource.Find<Sprite>(ResTypes.Sprite, "WoodUI_8");
			public static Sprite WoodUI9 => ISIResource.Find<Sprite>(ResTypes.Sprite, "WoodUI_9");
			public static Sprite WoodUI10 => ISIResource.Find<Sprite>(ResTypes.Sprite, "WoodUI_10");
			public static Sprite WoodUI11 => ISIResource.Find<Sprite>(ResTypes.Sprite, "WoodUI_11");
			public static Sprite WoodUI12 => ISIResource.Find<Sprite>(ResTypes.Sprite, "WoodUI_12");
			public static Sprite WoodUI13 => ISIResource.Find<Sprite>(ResTypes.Sprite, "WoodUI_13");
			public static Sprite VignetteReg => ISIResource.Find<Sprite>(ResTypes.Sprite, "VignetteReg");
			public static Sprite WideStarGlow => ISIResource.Find<Sprite>(ResTypes.Sprite, "WideStar_Glow");
			public static Sprite Trace => ISIResource.Find<Sprite>(ResTypes.Sprite, "Trace");
			public static Sprite WoodFragments => ISIResource.Find<Sprite>(ResTypes.Sprite, "WoodFragments");
			public static Sprite Woods0 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Woods_0");
			public static Sprite Woods1 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Woods_1");
			public static Sprite Woods2 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Woods_2");
			public static Sprite Woods3 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Woods_3");
			public static Sprite Woods4 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Woods_4");
			public static Sprite Woods5 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Woods_5");
			public static Sprite Woods6 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Woods_6");
			public static Sprite Woods7 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Woods_7");
			public static Sprite Woods8 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Woods_8");
			public static Sprite Woods9 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Woods_9");
			public static Sprite Woods10 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Woods_10");
			public static Sprite Woods11 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Woods_11");
			public static Sprite Woods12 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Woods_12");
			public static Sprite Woods13 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Woods_13");
			public static Sprite Woods14 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Woods_14");
			public static Sprite Woods15 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Woods_15");
			public static Sprite Woods16 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Woods_16");
			public static Sprite Woods17 => ISIResource.Find<Sprite>(ResTypes.Sprite, "Woods_17");
		}
		public static class textasset {
			public const string Names = "";
		}
		public static class texture2d {
			public const string Names = "";
		}
		public static class xmls {
			public const string Names = "";
		}
		public static class strings {
			public const string Names = "";
		}
		public static class int32 {
			public const string Names = "";
		}
		public static class boolean {
			public const string Names = "";
		}
		public static class color {
			public const string Names = "";
		}
		public static class tags {
			public const string Names = "Untagged,Respawn,Finish,EditorOnly,MainCamera,Player,GameController";
			public const string Untagged = "Untagged";
			public const string Respawn = "Respawn";
			public const string Finish = "Finish";
			public const string EditorOnly = "EditorOnly";
			public const string MainCamera = "MainCamera";
			public const string Player = "Player";
			public const string GameController = "GameController";
		}
		public static class layers {
			public const string Names = "Default,TransparentFX,IgnoreRaycast,Water,UI,GameItem";
			public const int Default = 1;
			public const int TransparentFX = 2;
			public const int IgnoreRaycast = 4;
			public const int Water = 16;
			public const int UI = 32;
			public const int GameItem = 256;
		}
	}
}
