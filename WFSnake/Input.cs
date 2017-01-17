using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace WFSnake
{
    class Input
    {
        private static Hashtable keyTable = new Hashtable();

        public static bool KeyPressed(Keys key)
        {
            if (keyTable[key] == null) 
            {
                return false;
            }
            if((bool)keyTable[key] == true)
            {
                lock (keyTable.SyncRoot)
                {
                    keyTable.Remove(key);
                }
                return true;
            }
            return false; 
        }

        public static void ChangeState(Keys key, bool state)
        {
            lock (keyTable.SyncRoot)
            {
                keyTable[key] = state;
            }
        }
    }
}
