using System.Windows.Forms;

namespace OpenGLBloxorz
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageBox.Show("Poruszanie się - klawisze: W, A, S, D", "Info - Keyboard");

            using (var window = new Window())
            {
                window.Run(60, 60);
            }
        }
    }
}
