using MicroSwarm.FileSystem;
using MicroSwarm.Templates;

namespace CSharpBackend.Files
{
    public class StartupClassFile : CSharpFile
    {
        public const string CLASS_NAME = "Startup";

        public StartupClassFile(string solutionName, string serviceName, SwarmDir dir) : base(CLASS_NAME, dir)
        {
            AppendLine(UsingTemplate.Render("Microsoft.EntityFrameworkCore"));
            AppendLine(UsingTemplate.Render(serviceName + ".Actors"));
            AppendLine(UsingTemplate.Render(solutionName + "Core.Actors"));
            AppendLine();

            AppendLine(StartupTemplate.RenderHeader(serviceName, CLASS_NAME));
            AppendLine();

            Indentation = CLASS_MEMBER_INDENT;
            AppendLine(StartupTemplate.RenderConfigureServices(serviceName));
            AppendLine();

            AppendLine(StartupTemplate.RenderConfigure());
            ClearIndentation();
            AppendLine(StartupTemplate.RenderFooter());
        }
    }
}