using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes;
using CounterStrikeSharp.API.Core.Attributes.Registration;

namespace BlockJumpThrow;

// [MinimumApiVersion(291)]
public class BlockJumpThrow : BasePlugin
{
    public override string ModuleName => "MyPlugin";
    public override string ModuleDescription => "";
    public override string ModuleAuthor => "AuthorName";
    public override string ModuleVersion => "0.0.1";
    //BaseGrenade.JumpThrow: 2690897052
    const uint Weapons_BaseGrenade_JumpThrow = 2323025056;

    public override void Load(bool hotReload)
    {
        Console.WriteLine($"{ModuleName} loaded successfully!");
        HookUserMessage(208, um =>
        {
            var client = um.Recipients.FirstOrDefault();
            if (client == null || !client.IsValid)
            {
                return HookResult.Continue;
            }
            var soundevent = um.ReadUInt("soundevent_hash");
            var entityIndex = um.ReadInt("source_entity_index");
            var entity = Utilities.GetEntityFromIndex<CBaseEntity>(entityIndex);
            if (entity == null || !entity.IsValid)
            {
                return HookResult.Continue;
            }
            if (soundevent == Weapons_BaseGrenade_JumpThrow)
            {
                um.Recipients.Clear();
                return HookResult.Stop;
            }
            return HookResult.Continue;

        }, HookMode.Pre);
    }

}