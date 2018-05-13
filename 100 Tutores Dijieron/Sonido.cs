using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace _100_Tutores_Dijieron
{
    class Sonido
    {
        public Sonido()
        { }

        public void reproducir(string path)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = path;
            player.Load();
            player.Play();
        }
    }
}
