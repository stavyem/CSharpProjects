using System.Windows.Forms;

namespace ReversedXMixDrix
{
    internal static class Program
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            new GameSettingsForm().ShowDialog();
        }
    }
}
