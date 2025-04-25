namespace Roblox;

// should only be temporary
public interface SecurityCapabilities
{
    public SecurityCapabilities Add(params Enum.SecurityCapability[] capabilities);
    public SecurityCapabilities Remove(params Enum.SecurityCapability[] capabilities);
    public bool Contains(params Enum.SecurityCapability[] capabilities);
}

public sealed class LuaTuple<T> where T : IList<T>
{
    public void Deconstruct(out T first,
                            out T second,
                            out T third,
                            out T fourth,
                            out T fifth,
                            out T sixth,
                            out T seventh,
                            out T eighth,
                            out T ninth,
                            out T tenth)
    {
        first = default!;
        second = default!;
        third = default!;
        fourth = default!;
        fifth = default!;
        sixth = default!;
        seventh = default!;
        eighth = default!;
        ninth = default!;
        tenth = default!;
    }
}

public sealed class LuaTuple<T1, T2>
{
    public void Deconstruct(out T1 first, out T2 second)
    {
        first = default!;
        second = default!;
    }
}

public sealed class LuaTuple<T1, T2, T3>
{
    public void Deconstruct(out T1 first,
                            out T2 second,
                            out T3 third)
    {
        first = default!;
        second = default!;
        third = default!;
    }
}

public sealed class LuaTuple<T1, T2, T3, T4>
{
    public void Deconstruct(out T1 first,
                            out T2 second,
                            out T3 third,
                            out T4 fourth)
    {
        first = default!;
        second = default!;
        third = default!;
        fourth = default!;
    }
}

public sealed class LuaTuple<T1, T2, T3, T4, T5>
{
    public void Deconstruct(out T1 first,
                            out T2 second,
                            out T3 third,
                            out T4 fourth,
                            out T5 fifth)
    {
        first = default!;
        second = default!;
        third = default!;
        fourth = default!;
        fifth = default!;
    }
}

public sealed class LuaTuple<T1, T2, T3, T4, T5, T6>
{
    public void Deconstruct(out T1 first,
                            out T2 second,
                            out T3 third,
                            out T4 fourth,
                            out T5 fifth,
                            out T6 sixth)
    {
        first = default!;
        second = default!;
        third = default!;
        fourth = default!;
        fifth = default!;
        sixth = default!;
    }
}

public sealed class LuaTuple<T1, T2, T3, T4, T5, T6, T7>
{
    public void Deconstruct(out T1 first,
                            out T2 second,
                            out T3 third,
                            out T4 fourth,
                            out T5 fifth,
                            out T6 sixth,
                            out T7 seventh)
    {
        first = default!;
        second = default!;
        third = default!;
        fourth = default!;
        fifth = default!;
        sixth = default!;
        seventh = default!;
    }
}

public sealed class LuaTuple<T1, T2, T3, T4, T5, T6, T7, T8>
{
    public void Deconstruct(out T1 first,
                            out T2 second,
                            out T3 third,
                            out T4 fourth,
                            out T5 fifth,
                            out T6 sixth,
                            out T7 seventh,
                            out T8 eighth)
    {
        first = default!;
        second = default!;
        third = default!;
        fourth = default!;
        fifth = default!;
        sixth = default!;
        seventh = default!;
        eighth = default!;
    }
}

public sealed class LuaTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>
{
    public void Deconstruct(out T1 first,
                            out T2 second,
                            out T3 third,
                            out T4 fourth,
                            out T5 fifth,
                            out T6 sixth,
                            out T7 seventh,
                            out T8 eighth,
                            out T9 ninth)
    {
        first = default!;
        second = default!;
        third = default!;
        fourth = default!;
        fifth = default!;
        sixth = default!;
        seventh = default!;
        eighth = default!;
        ninth = default!;
    }
}

public sealed class LuaTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
{
    public void Deconstruct(out T1 first,
                            out T2 second,
                            out T3 third,
                            out T4 fourth,
                            out T5 fifth,
                            out T6 sixth,
                            out T7 seventh,
                            out T8 eighth,
                            out T9 ninth,
                            out T10 tenth)
    {
        first = default!;
        second = default!;
        third = default!;
        fourth = default!;
        fifth = default!;
        sixth = default!;
        seventh = default!;
        eighth = default!;
        ninth = default!;
        tenth = default!;
    }
}

public static partial class Globals
{
    public static extern float ToNumber(string str);

    public static extern float ToFloat(string str);

    public static extern double ToDouble(string str);

    public static extern int ToInt(string str);

    public static extern uint ToUInt(string str);

    public static extern short ToShort(string str);

    public static extern ushort ToUShort(string str);

    public static extern byte ToByte(string str);

    public static extern sbyte ToSByte(string str);
}

public interface ClipEvaluator : Instance
{
}

public interface SystemAddress : Instance
{
}

public interface OpenCloudModel : Instance
{
}

public interface HSRDataContentProvider : Instance
{
}

public interface MeshContentProvider : Instance
{
}

public interface SolidModelContentProvider : Instance
{
}

public interface CSGDictionaryService : Instance
{
}

public interface NonReplicatedCSGDictionaryService : Instance
{
}

public interface AppStorageService : Instance
{
}

public interface UserStorageService : Instance
{
}

public interface RemoteFunction : ICreatableInstance
{
    public object InvokeClient(Player player, params object[] arguments); // TODO: tuple
    public object InvokeServer(params object[] arguments);                // TODO: tuple

    public delegate void ClientInvoke(params object[] arguments);
    public ClientInvoke OnClientInvoke { get; set; }

    public delegate void ServerInvoke(params object[] arguments);
    public ServerInvoke OnServerInvoke { get; set; }
}

public interface RemoteEvent : BaseRemoteEvent, ICreatableInstance
{
    public void FireAllClients(params object[] arguments);
    public void FireClient(Player player, params object[] arguments);
    public void FireServer(params object[] arguments);

    public delegate void ClientEvent(params object[] arguments);
    public event ClientEvent OnClientEvent;

    public delegate void ServerEvent(Player player, params object[] arguments);
    public event ServerEvent OnServerEvent;
}

public interface UnreliableRemoteEvent : BaseRemoteEvent, ICreatableInstance
{
    public void FireAllClients(params object[] arguments);
    public void FireClient(Player player, params object[] arguments);
    public void FireServer(params object[] arguments);

    public delegate void ClientEvent(params object[] arguments);
    public event ClientEvent OnClientEvent;

    public delegate void ServerEvent(Player player, params object[] arguments);
    public event ServerEvent OnServerEvent;
}

public partial interface NetworkPeer : Instance
{
    public void SetOutgoingKBPSLimit(int limit);
}

public partial interface NetworkClient : NetworkPeer
{
}

public partial interface NetworkServer : NetworkPeer
{
}

public partial interface GlobalDataStore
{
    public T GetAsync<T>(string key, DataStoreGetOptions? options = null);
    public string SetAsync(string key, object value, uint[]? userIds = null, DataStoreSetOptions? options = null);
    public LuaTuple<float, DataStoreKeyInfo> IncrementAsync(string key,
                                                            float? delta = null,
                                                            uint[]? userIds = null,
                                                            DataStoreSetOptions? options = null);

    public LuaTuple<object, DataStoreKeyInfo> RemoveAsync(string key);
    public LuaTuple<object, DataStoreKeyInfo> UpdateAsync(string key, Action transformFunction);
}

public partial interface OrderedDataStore
{
    public DataStorePages GetSortedAsync(bool ascending, uint pageSize, object? minValue = null, object? maxValue = null);
}

public partial interface DataStoreService
{
    public DataStore GetDataStore(string name, string? scope = null, DataStoreOptions? options = null);
}

public partial interface Players
{
    public Player LocalPlayer { get; }
}

public partial interface BasePart
{
    public Vector3 Position { get; set; }
    public Vector3 Orientation { get; set; }
}

public partial interface WorldRoot
{
    public void BulkMoveTo(BasePart[] partList, CFrame[] cframeList, Enum.BulkMoveMode eventMode);
    public bool ArePartsTouchingOthers(BasePart[] partList, float overlapIgnored);
}

public partial interface DataModel : ServiceProvider
{
    public Workspace Workspace { get; }
    public Lighting Lighting { get; }

    public T GetService<T>()
        where T : IServiceInstance;
}

public partial interface ServiceProvider
{
    public delegate void ServiceAddedDelegate(IServiceInstance service);
    public event ServiceAddedDelegate ServiceAdded;

    public delegate void ServiceRemovingDelegate(IServiceInstance service);
    public event ServiceRemovingDelegate ServiceRemoving;
}

public interface IServiceInstance : Instance;
public interface ICreatableInstance : Instance;

public partial interface Instance
{
    public static sealed extern T Create<T>(Instance? parent = null)
        where T : ICreatableInstance;

    public Instance Clone();
    public Instance? FindFirstAncestor(string name);
    public Instance? FindFirstChild(string name, bool? recursive = null);
    public Instance? FindFirstDescendant(string name);

    public T? FindFirstAncestor<T>(string name)
        where T : Instance;

    public T? FindFirstChild<T>(string name, bool? recursive = null)
        where T : Instance;

    public T? FindFirstDescendant<T>(string name)
        where T : Instance;

    public bool IsA<T>()
        where T : Instance;

    public bool IsAncestorOf(Instance descendant);
    public bool IsDescendantOf(Instance ancestor);
    public object? GetAttribute(string attribute);
    public Dictionary<string, object> GetAttributes();
    public Instance[] GetDescendants();

    public T? FindFirstAncestorOfClass<T>()
        where T : Instance;

    public T? FindFirstAncestorWhichIsA<T>()
        where T : Instance;

    public T? FindFirstChildOfClass<T>()
        where T : Instance;

    public T? FindFirstChildWhichIsA<T>(bool? recursive)
        where T : Instance;

    public string[] GetTags();
    public Instance WaitForChild(string name);
    public Instance? WaitForChild(string name, float timeout);

    public T WaitForChild<T>(string name)
        where T : Instance;

    public T? WaitForChild<T>(string name, float timeout)
        where T : Instance;

    public delegate void AncestryChangedDelegate(Instance child, Instance parent);
    public event AncestryChangedDelegate AncestryChanged;

    public delegate void AttributeChangedDelegate(string name);
    public event AttributeChangedDelegate AttributeChanged;

    public new delegate void ChangedDelegate(string name);
    public new event ChangedDelegate Changed;

    public delegate void ChildAddedDelegate(Instance child);
    public event ChildAddedDelegate ChildAdded;

    public delegate void ChildRemovedDelegate(Instance child);
    public event ChildRemovedDelegate ChildRemoved;

    public delegate void DescendantAddedDelegate(Instance descendant);
    public event DescendantAddedDelegate DescendantAdded;

    public delegate void DescendantRemovingDelegate(Instance descendant);
    public event DescendantRemovingDelegate DescendantRemoving;

    public delegate void DestroyingDelegate();
    public event DestroyingDelegate Destroying;
}