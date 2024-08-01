namespace Roblox
{
    public class LuaTuple<T>
    {
        public void Deconstruct(out T value)
        {
            value = default!;
        }
    }

    public class LuaTuple<T1, T2>
    {
        public void Deconstruct(out T1 first, out T2 second)
        {
            first = default!;
            second = default!;
        }
    }

    public static partial class Globals
    {
        public static float ToNumber(string str)
        {
            return default;
        }

        public static float ToFloat(string str)
        {
            return default;
        }

        public static double ToDouble(string str)
        {
            return default;
        }

        public static int ToInt(string str)
        {
            return default;
        }

        public static uint ToUInt(string str)
        {
            return default;
        }

        public static short ToShort(string str)
        {
            return default;
        }

        public static ushort ToUShort(string str)
        {
            return default;
        }

        public static byte ToByte(string str)
        {
            return default;
        }

        public static sbyte ToSByte(string str)
        {
            return default;
        }
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
        public object[] InvokeClient(Player player, params object[] arguments); // TODO: tuple
        public object[] InvokeServer(params object[] arguments); // TODO: tuple
        public Func<object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?> OnClientInvoke { get; set; }
        public Func<Player, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?> OnServerInvoke { get; set; }
    }

    public interface RemoteEvent : BaseRemoteEvent, ICreatableInstance
    {
        public void FireAllClients(params object[] arguments);
        public void FireClient(Player player, params object[] arguments);
        public void FireServer(params object[] arguments);
        public ScriptSignal OnClientEvent { get; }
        public ScriptSignal<Player, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?> OnServerEvent { get; }
    }

    public interface UnreliableRemoteEvent : BaseRemoteEvent, ICreatableInstance
    {
        public void FireAllClients(params object[] arguments);
        public void FireClient(Player player, params object[] arguments);
        public void FireServer(params object[] arguments);
        public ScriptSignal<object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?> OnClientEvent { get; }
        public ScriptSignal<Player, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?> OnServerEvent { get; }
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
        public float IncrementAsync(string key, float? delta = null, uint[]? userIds = null, DataStoreSetOptions? options = null); // TODO: LuaTuple<float, DataStoreKeyInfo>
        public object RemoveAsync(string key); // TODO: LuaTuple<object, DataStoreKeyInfo>
        public object UpdateAsync(string key, Action transformFunction); // TODO: LuaTuple<object, DataStoreKeyInfo>
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
        public void BulkMoveTo(BasePart[] partList, CFrame[] cframeList, Enum.BulkMoveMode.Type eventMode);
        public bool ArePartsTouchingOthers(BasePart[] partList, float overlapIgnored);
    }

    public partial interface DataModel : ServiceProvider
    {
        public Workspace Workspace { get; }
        public Lighting Lighting { get; }
        public T GetService<T>() where T : IServiceInstance;
    }

    public partial interface ServiceProvider
    {
        public ScriptSignal<IServiceInstance> ServiceAdded { get; }
        public ScriptSignal<IServiceInstance> ServiceRemoving { get; }
    }

    public interface IServiceInstance : Instance
    {
    }

    public interface ICreatableInstance : Instance
    {
    }

    public partial interface Instance
    {
        public static sealed T Create<T>(Instance? parent = null) where T : ICreatableInstance
        {
            return default!;
        }

        public Instance? FindFirstAncestor(string name);
        public Instance? FindFirstChild(string name, bool? recursive = null);
        public Instance? FindFirstDescendant(string name);
        public T? FindFirstAncestor<T>(string name) where T : Instance;
        public T? FindFirstChild<T>(string name, bool? recursive = null) where T : Instance;
        public T? FindFirstDescendant<T>(string name) where T : Instance;
        public bool IsA<T>() where T : Instance;
        public bool IsAncestorOf(Instance descendant);
        public bool IsDescendantOf(Instance ancestor);
        public object? GetAttribute(string attribute);
        public Dictionary<string, object> GetAttributes();
        public Instance[] GetDescendants();
        public T? FindFirstAncestorOfClass<T>() where T : Instance;
        public T? FindFirstAncestorWhichIsA<T>() where T : Instance;
        public T? FindFirstChildOfClass<T>() where T : Instance;
        public T? FindFirstChildWhichIsA<T>(bool? recursive) where T : Instance;
        public string[] GetTags();
        public Instance WaitForChild(string name);
        public Instance? WaitForChild(string name, float timeout);
        public T WaitForChild<T>(string name) where T : Instance;
        public T? WaitForChild<T>(string name, float timeout) where T : Instance;
        public bool isDescendantOf(Instance ancestor);
        public ScriptSignal<Instance, Instance> AncestryChanged { get; }
        public ScriptSignal<string> AttributeChanged { get; }
        public ScriptSignal<string> Changed { get; }
        public ScriptSignal<Instance> ChildAdded { get; }
        public ScriptSignal<Instance> ChildRemoved { get; }
        public ScriptSignal<Instance> DescendantAdded { get; }
        public ScriptSignal<Instance> DescendantRemoving { get; }
        public ScriptSignal Destroying { get; }
    }
}
