using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ijunior
{
    public static class Program
    {
        private static async Task Main(string[] args)
        {
            var player = new Player(100);
            player.Died += () => Console.Write($"the player died");

            var bots = new List<Bot>
            {
                new Bot(new Weapon(2, 10)),
                new Bot(new Weapon(50, 2))
            };

            bots[0].OnSeePlayer(player);
            await Task.Delay(100);
            bots[1].OnSeePlayer(player);
            await Task.Delay(100);
            bots[0].OnSeePlayer(player);
            await Task.Delay(100);
            bots[1].OnSeePlayer(player);
        }
    }
}