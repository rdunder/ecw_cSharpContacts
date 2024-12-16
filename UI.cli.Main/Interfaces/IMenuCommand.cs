

namespace UI.cli.Main.Interfaces;

internal interface IMenuCommand
{
    string Description { get; }
    void Execute();
}
