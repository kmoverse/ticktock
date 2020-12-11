using osu.Framework.Platform;
using osu.Framework;
using ticktock.Game;

namespace ticktock.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableHost(@"ticktock"))
            using (osu.Framework.Game game = new ticktockGame())
                host.Run(game);
        }
    }
}
