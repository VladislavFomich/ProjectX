using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;
using System.Threading.Tasks;

namespace ProjectX
{
    class WinPLayerList
    {
       public void PlayerScore()
        {
            Clear();
            string path = @"D:\gitHub\ProjectX\ProjectX\ProjectX\ScoreList.txt";
            using (StreamReader streamReader = new StreamReader(path,Encoding.Default))
            {
                WriteLine(streamReader.ReadToEnd());
            }
            WriteLine("Press any botton tu return...");
            ReadLine();
            SettingMenu.StartSettingsMenu();
        }
    }
}
