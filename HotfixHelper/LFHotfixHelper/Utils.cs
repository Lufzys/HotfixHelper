using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFHotfixHelper
{
    public static class Utils
    {
        public static void Write(this RichTextBox cntrl, Color color, string text)
        {
            cntrl.SelectionFont = cntrl.Font;
            cntrl.SelectionColor = color;
            cntrl.SelectedText = text;
        }

        public static void WriteLine(this RichTextBox cntrl, Color color, string text)
        {
            cntrl.SelectionFont = cntrl.Font;
            cntrl.SelectionColor = color;
            cntrl.SelectedText = text + Environment.NewLine;
        }
    }
}
