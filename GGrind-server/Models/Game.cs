using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GGrind_server.Models
{
    public enum GameType { MOBA = 0, FPS, MOBA_FPS, Battle_royal }

    public class Game
    {
        public string Name { get; set; }

        public GameType Type { get; set; }
    }
}
