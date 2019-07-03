using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;
using GreyMagic;

[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public struct EnmityObj
{
    [FieldOffset(0x40)]
    internal uint ObjectId;

    [FieldOffset(0x44)]
    internal uint Enmity;
}

public class Enmity
{
    internal Enmity(EnmityObj obj)
    {
        Object = obj.ObjectId == Core.Me.ObjectId ? Core.Me : GameObjectManager.GetObjectByObjectId(obj.ObjectId);
        CurrentEnmity = obj.Enmity;
    }

    public GameObject Object { get; }
    public uint CurrentEnmity { get; }
}

public static class EnmityManager
{
    private static IntPtr TargetEnmityBasePtr;
    private static IntPtr EnmityCountPtr;

    private static IntPtr MyEnmityListPtr;
    private static IntPtr MyEnmityCountPtr;

    static EnmityManager()
    {
        var pf = new PatternFinder(Core.Memory);
        TargetEnmityBasePtr = pf.Find("Search 4C 8D 3D ? ? ? ? 66 90 8B 03 48 8D 0D ? ? ? ? 41 89 46 FC 45 33 C0 8B 43 04 Add 3 TraceRelative");
        EnmityCountPtr = pf.Find("Search 89 05 ? ? ? ? 48 8B FA 40 38 32 76 78 Add 2 TraceRelative");

        MyEnmityCountPtr = pf.Find("Search  44 39 3D ? ? ? ? 41 8B EF  Add 3 TraceRelative");
        MyEnmityListPtr = pf.Find("Search 48 8D 0D ? ? ? ? E8 ? ? ? ? 84 C0 74 18 8B 57 74  Add 3 TraceRelative");
    }

    public static int EnmityCount => Core.Memory.Read<short>(EnmityCountPtr);
    public static int AttackersEnmityCount => Core.Memory.Read<short>(MyEnmityCountPtr);

    public static IEnumerable<Enmity> TargetEnmityList => Core.Memory.ReadArray<EnmityObj>(TargetEnmityBasePtr, Math.Min(EnmityCount, 32)).Select(i => new Enmity(i));
    //public static IEnumerable<EnmityObj> RawEnmityList => Core.Memory.ReadArray<EnmityObj>(EnmityCountPtr, Math.Min(EnmityCount, 32));

    public static IEnumerable<Enmity> AttackersEnmityList => Core.Memory.ReadArray<EnmityObj>(MyEnmityListPtr, Math.Min(AttackersEnmityCount, 32)).Select(i => new Enmity(i));
    //public static IEnumerable<EnmityObj> RawEnmityList => Core.Memory.ReadArray<EnmityObj>(MyEnmityCountPtr, Math.Min(EnmityCount, 32));
}