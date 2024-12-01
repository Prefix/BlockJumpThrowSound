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
    const uint Weapon_BaseGrenade_JumpThrow = 2690897052;
    const uint Player_BaseGrenade_JumpThrowM = 3049902652;
    const uint Player_BaseGrenade_JumpThrowF = 3049902652;

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
            if (soundevent == Weapon_BaseGrenade_JumpThrow || soundevent == Player_BaseGrenade_JumpThrowM || soundevent == Player_BaseGrenade_JumpThrowF)
            {
                //Console.WriteLine("Blocked JumpThrow");
                um.Recipients.Clear();
                return HookResult.Stop;
            }
            /* else {
                Console.WriteLine($"SoundEvent: {soundevent} EntityIndex: {entityIndex}");
            }*/
            return HookResult.Continue;

        }, HookMode.Pre);
    }

}