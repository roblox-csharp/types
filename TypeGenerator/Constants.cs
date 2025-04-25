using TypeGenerator.APITypes;

namespace TypeGenerator;

internal static class Constants
{
    public const string ROOT_CLASS_NAME = "<<<ROOT>>>";
    public static readonly List<string> BAD_NAME_CHARS = [" ", "/", "\""];

    public static readonly HashSet<string> PER_INSTANCE_MEMBERS = ["public new <INSTANCE_TYPE> Clone();"];

    public static readonly Dictionary<string, Dictionary<string, Security>?> SECURITY_OVERRIDES = new()
    {
        ["StarterGui"] = new Dictionary<string, Security>
        {
            ["ShowDevelopmentGui"] = new() { Read = "PluginSecurity", Write = "PluginSecurity" }
        }
    };

    public static readonly HashSet<string> PARTIAL_INTERFACES =
    [
        "AnimationClipProvider",
        "Animator",
        "AssetService",
        "BaseRemoteEvent",
        "KeyframeSequenceProvider",
        "KeyframeSequence",
        "Instance",
        "StarterGui",
        "GameSettings",
        "ClipEvaluator",
        "Terrain",
        "WorldRoot",
        "Workspace",
        "Player",
        "Players",
        "PluginManagerInterface",
        "RunService",
        "ScriptContext",
        "ScriptDocument",
        "ScriptEditorService",
        "ScriptProfilerService",
        "DataModel",
        "SoundService",
        "TerrainRegion",
        "NetworkPeer",
        "NetworkClient",
        "NetworkServer",
        "BasePart",
        "ServiceProvider",
        "ReplicatedStorage",
        "ServerStorage",
        "ServerScriptService",
        "ReplicatedFirst",
        "PlayerGui",
        "PlayerScripts",
        "DataStoreService",
        "GlobalDataStore",
        "OrderedDataStore"
    ];

    public static readonly HashSet<string> CREATABLE_BLACKLIST =
    [
        "UserSettings",
        "DebugSettings",
        "Studio",
        "GameSettings",
        "ParabolaAdornment",
        "LuaSettings",
        "PhysicsSettings",
        "Player",
        "DebuggerWatch",
        "Tween",
        "UserGameSettings"
    ];

    public static readonly HashSet<string> PLUGIN_ONLY_CLASSES =
    [
        "ABTestService",
        "ChangeHistoryService",
        "CoreGui",
        "DataModelSession",
        "DebuggerBreakpoint",
        "DebuggerManager",
        "DebuggerWatch",
        "DebugSettings",
        "File",
        "GameSettings",
        "GlobalSettings",
        "LuaSettings",
        "MemStorageConnection",
        "MultipleDocumentInterfaceInstance",
        "NetworkPeer",
        "NetworkReplicator",
        "NetworkSettings",
        "PackageService",
        "PhysicsSettings",
        "Plugin",
        "PluginAction",
        "PluginDebugService",
        "PluginDragEvent",
        "PluginGui",
        "PluginGuiService",
        "PluginMenu",
        "PluginMouse",
        "PluginToolbar",
        "PluginToolbarButton",
        "RenderingTest",
        "RenderSettings",
        "RobloxPluginGuiService",
        "ScriptDebugger",
        "Selection",
        "StatsItem",
        "Studio",
        "StudioData",
        "StudioService",
        "StudioTheme",
        "TaskScheduler",
        "TestService",
        "VersionControlService"
    ];

    public static readonly HashSet<string> CLASS_BLACKLIST =
    [
        // Classes which Roblox leverages internally/in the CoreScripts but serve no purpose to developers
        "AnalyticsSettings",
        "BinaryStringValue",
        "BrowserService",
        "CacheableContentProvider",
        "ClusterPacketCache",
        "CookiesService",
        "CorePackages",
        "CoreScript",
        "CoreScriptSyncService",
        "DraftsService",
        "FlagStandService",
        "FlyweightService",
        "FriendService",
        "Geometry",
        "GoogleAnalyticsConfiguration",
        "GuidRegistryService",
        "HttpRbxApiService",
        "HttpRequest",
        "KeyboardService",
        "LocalStorageService",
        "LuaWebService",
        "MemStorageService",
        "MouseService",
        "PartOperationAsset",
        "PermissionsService",
        "PhysicsPacketCache",
        "PlayerEmulatorService",
        "ReflectionMetadataItem",
        "RobloxReplicatedStorage",
        "RuntimeScriptService",
        "SpawnerService",
        "StandalonePluginScripts",
        "StopWatchReporter",
        "ThirdPartyUserService",
        "TimerService",
        "TouchInputService",
        "VirtualInputManager",
        "Visit",

        // never implemented
        "AdvancedDragger",
        "LoginService",
        "NotificationService",
        "ScriptService",
        "Status",

        // super deprecated:
        "AdService",
        "FunctionalTest",
        "PluginManager",
        "VirtualUser",

        //"BevelMesh",
        "CustomEvent",
        "CustomEventReceiver",

        //"CylinderMesh",
        //"DoubleConstrainedValue",
        "Flag",
        "FlagStand",

        //"FloorWire",
        //"Glue",
        "GuiMain",

        //"Hat",
        "Hint",

        //"Hole",
        "Hopper",
        "HopperBin",

        //"IntConstrainedValue",
        //"JointsService",
        "Message",

        //"MotorFeature",
        "PointsService",

        //"SelectionPartLasso",
        //"SelectionPointLasso",
        //"SkateboardPlatform",
        "Skin",
        "ReflectionMetadata",
        "ReflectionMetadataCallbacks",
        "ReflectionMetadataClasses",
        "ReflectionMetadataEnums",
        "ReflectionMetadataEvents",
        "ReflectionMetadataFunctions",
        "ReflectionMetadataProperties",
        "ReflectionMetadataYieldFunctions",
        "Studio",

        // unused
        "UGCValidationService",
        "RbxAnalyticsService",

        // custom defined
        "RemoteEvent",
        "UnreliableRemoteEvent",
        "RemoteFunction"
    ];

    public static readonly Dictionary<string, HashSet<string>> ENUM_BLACKLIST = new() { { "Quality", ["Quality"] } };

    public static readonly Dictionary<string, HashSet<string>> MEMBER_BLACKLIST = new()
    {
        { "Workspace", ["FilteringEnabled"] },
        { "Players", ["FilteringEnabled", "LocalPlayer"] }, // defined in Roblox.cs
        { "CollectionService", ["GetCollection"] },
        {
            "Instance", [
                "children",
                "Remove",
                "IsA",
                "FindFirstChild",
                "FindFirstAncestor",
                "FindFirstDescendant",
                "FindFirstChildOfClass",
                "FindFirstChildWhichIsA",
                "FindFirstAncestorOfClass",
                "FindFirstAncestorWhichIsA",
                "Clone",
                "IsAncestorOf",
                "IsDescendantOf",
                "GetAttribute",
                "GetAttributes",
                "GetDescendants",
                "GetTags",
                "WaitForChild",
                "clone",
                "isDescendantOf",
                "AncestryChanged",
                "AttributeChanged",
                "Changed",
                "ChildAdded",
                "ChildRemoved",
                "DescendantAdded",
                "DescendantRemoving",
                "Destroying",
                "childAdded"
            ]
        }, // defined in Roblox.cs
        { "BodyGyro", ["cframe"] },
        { "BodyAngularVelocity", ["FilteringEnabled"] },
        { "BodyPosition", ["FilteringEnabled"] },
        { "DataStoreService", ["FilteringEnabled", "GetDataStore"] }, // defined in Roblox.cs
        { "Debris", ["FilteringEnabled"] },
        { "LayerCollector", ["FilteringEnabled"] },
        { "GuiBase3d", ["FilteringEnabled"] },
        { "Model", ["FilteringEnabled"] },
        {
            "ServiceProvider", ["FilteringEnabled", "GetService", "FindService", "service", "ServiceAdded", "ServiceRemoving"]
        }, // defined in Roblox.cs
        { "DataModel", ["FilteringEnabled", "Workspace", "lighting"] },
        { "WorldRoot", ["ArePartsTouchingOthers", "BulkMoveTo"] },                                      // defined in Roblox.cs
        { "OrderedDataStore", ["GetSortedAsync"] },                                                     // defined in Roblox.cs
        { "GlobalDataStore", ["GetAsync", "IncrementAsync", "SetAsync", "UpdateAsync", "RemoveAsync"] } // defined in Roblox.cs
    };

    public static readonly Dictionary<string, List<string>> EXPECTED_EXTRA_MEMBERS = new()
    {
        { "Player", ["Name"] },
        { "ValueBase", ["Value", "Changed"] },
        { "DataStore", ["GetAsync", "IncrementAsync", "SetAsync", "UpdateAsync", "RemoveAsync"] },
        { "OrderedDataStore", ["GetAsync", "IncrementAsync", "SetAsync", "UpdateAsync", "RemoveAsync"] }
    };

    public static readonly HashSet<string> ABSTRACT_CLASSES =
    [
        "BackpackItem",
        "BasePart",
        "BasePlayerGui",
        "BaseScript",
        "BevelMesh",
        "BodyMover",
        "CharacterAppearance",
        "Clothing",
        "Constraint",
        "Controller",
        "DataModelMesh",
        "DynamicRotate",
        "FaceInstance",
        "Feature",
        "FormFactorPart",
        "GenericSettings",
        "GuiBase",
        "GuiBase2d",
        "GuiBase3d",
        "GuiButton",
        "GuiLabel",
        "GuiObject",
        "HandleAdornment",
        "HandlesBase",
        "Instance",
        "JointInstance",
        "LayerCollector",
        "Light",
        "LuaSourceContainer",
        "ManualSurfaceJointInstance",
        "NetworkPeer",
        "NetworkReplicator",
        "Pages",
        "PartAdornment",
        "PluginGui",
        "PostEffect",
        "PVAdornment",
        "PVInstance",
        "SelectionLasso",
        "ServiceProvider",
        "SlidingBallConstraint",
        "SoundEffect",
        "StatsItem",
        "TriangleMeshPart",
        "TweenBase",
        "UIBase",
        "UIComponent",
        "UIConstraint",
        "UIGridStyleLayout",
        "UILayout",
        "ValueBase",
        "WorldRoot"
    ];

    public static readonly Dictionary<string, string> RENAMABLE_AUTO_TYPES = new()
    {
        { "Part", "BasePart" }, { "Script", "LuaSourceContainer" }, { "Character", "Model" }, { "Input", "InputObject" }
    };

    public static readonly Dictionary<string, string> PROP_TYPE_MAP = new();

    public static readonly Dictionary<string, string> VALUE_TYPE_MAP = new()
    {
        { "Array", "object[]" },
        { "BinaryString", "string" },
        { "SharedString", "string" },
        { "String", "string" },
        { "Connection", "ScriptConnection" },
        { "ContentId", "string" },
        { "CoordinateFrame", "CFrame" },
        { "EventInstance", "ScriptSignal" },
        { "Function", "Action" },
        { "double", "float" },
        { "int", "int" },
        { "int64", "long" },
        { "Dictionary", "object" },
        { "Map", "object" },
        { "RBXScriptSignal", "ScriptSignal" },
        { "RBXScriptConnection", "ScriptConnection" },
        { "Objects", "Object[]" },
        { "Instances", "Instance[]" },
        { "Property", "string" },
        { "OptionalCoordinateFrame", "CFrame?" },
        { "ProtectedString", "string" },
        { "Rect2D", "Rect" },
        { "Tuple", "object" },
        { "Variant", "object" },
        { "Color3uint8", "Color3" },
        { "any", "object" },
        { "Array<any>", "object[]" },
        { "buffer", "Buffer" },
    };

    public static readonly Dictionary<string, string> RETURN_TYPE_MAP = new() { { "null", "void" } };

    public static readonly Dictionary<string, string> PARAM_NAME_MAP = new()
    {
        { "debugger", "debug" },
        { "old", "oldValue" },
        { "new", "newValue" },
        { "virtual", "_virtual" },
        { "params", "parameters" },
        { "override", "_override" },
        { "string", "str" },
        { "object", "obj" }
    };
}