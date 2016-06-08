using Cosmos.Hardware;

namespace SolarOS_beta_
{
    public class GUI
    {
        public static VGAScreen Screen = new VGAScreen();
        private static Mouse mouse = null;
        private static uint oldx = 0, oldy = 0;
        public static void StartGUI()
        {
            Screen.SetGraphicsMode(VGAScreen.ScreenSize.Size320x200, VGAScreen.ColorDepth.BitDepth8);
            Screen.Clear(0);
            FontGui.SetupFont();
            FontGui.drawText("solaros gui v0.0.1b", 5, 5, 4, ref Screen);     //mancono le lettere maiuscole
            while (true)    //ciclo eterno per la gui
            {
                //int tic=0;
                DrawTime(240, 190, 0);
                DrawTime(240, 190, 4);
                Utilita.Attendi.AttendiSecondi(1);
                //tic++;
                //if (Cosmos.Hardware.RTC.Second.ToString("00") == "59")
                //{
                    //FontGui.drawText(tic.ToString(),10, 30, 4, ref Screen);
                    //DrawTime(240, 190, 0);
                    //DrawTime(240, 190, 4);      //sovrascrive le sue stesse scritte da vedere la cancellazione
                //}
                //else
                //{
                   
                //}
                // in fase di test
                // Draw mouse
                //uint curX = (uint)mouse.X; uint curY = (uint)mouse.Y;
                //if (oldx != curX || oldy != curY) UndrawMouse();
                //DrawMouse(curX, curY);
            }
           
        }
        public static void DrawTime(uint __x, uint __y, uint __color)
        {
            string hour = RTC.Hour.ToString("00");
            string minute = RTC.Minute.ToString("00");
            string second = RTC.Second.ToString("00");
            for (int i = 0; i != 9; i++)
            {
                string ix = i.ToString("00");
                FontGui.drawText(ix + ix + "h " + ix + ix + "m " + ix + ix + "s", __x, __y, 255, ref Screen);
            }
            FontGui.drawText(hour + "h " + minute + "m " + second + "s", __x, __y, __color, ref Screen);
        }
        public static void vline(uint x, uint y, uint z, uint c)
        {
            VGAScreen Screen = new VGAScreen();
            while (y != z)
            {
                pixel(x, y, c);
                if (z > y)
                    y = y + 1;
                if (z < y)
                    y = y - 1;
            }
        }
        public static void hline(uint x, uint y, uint z, uint c)
        {
            VGAScreen Screen = new VGAScreen();
            while (x != z)
            {
                pixel(x, y, c);
                if (z > x)
                    x = x + 1;
                if (z < x)
                    y = y - 1;
            }
        }

        public static void pixel(uint x, uint y, uint c)
        {
            VGAScreen Screen = new VGAScreen();
            Screen.SetPixel320x200x8(x, y, c);
        }
        public static void UndrawMouse()
        {
            Screen.SetPixel320x200x8(oldx, oldy, 0);

            Screen.SetPixel320x200x8(oldx + 1, oldy, 0);
            Screen.SetPixel320x200x8(oldx + 2, oldy, 0);
            Screen.SetPixel320x200x8(oldx + 3, oldy, 0);
            Screen.SetPixel320x200x8(oldx + 4, oldy, 0);

            Screen.SetPixel320x200x8(oldx, oldy + 1, 0);
            Screen.SetPixel320x200x8(oldx, oldy + 2, 0);
            Screen.SetPixel320x200x8(oldx, oldy + 3, 0);
            Screen.SetPixel320x200x8(oldx, oldy + 4, 0);

            Screen.SetPixel320x200x8(oldx + 1, oldy + 2, 0);
            Screen.SetPixel320x200x8(oldx + 2, oldy + 1, 0);

            Screen.SetPixel320x200x8(oldx + 1, oldy + 1, 0);
            Screen.SetPixel320x200x8(oldx + 2, oldy + 2, 0);
            Screen.SetPixel320x200x8(oldx + 3, oldy + 3, 0);
            Screen.SetPixel320x200x8(oldx + 4, oldy + 4, 0);
            Screen.SetPixel320x200x8(oldx + 5, oldy + 5, 0);
            Screen.SetPixel320x200x8(oldx + 6, oldy + 6, 0);
        }
        public static void DrawMouse(uint __x, uint __y)
        {
            Screen.SetPixel320x200x8(__x, __y, 0 + 4);

            Screen.SetPixel320x200x8(__x + 1, __y, 25 + 4);
            Screen.SetPixel320x200x8(__x + 2, __y, 25 + 4);
            Screen.SetPixel320x200x8(__x + 3, __y, 25 + 4);
            Screen.SetPixel320x200x8(__x + 4, __y, 25 + 4);

            Screen.SetPixel320x200x8(__x, __y + 1, 25 + 4);
            Screen.SetPixel320x200x8(__x, __y + 2, 25 + 4);
            Screen.SetPixel320x200x8(__x, __y + 3, 25 + 4);
            Screen.SetPixel320x200x8(__x, __y + 4, 25 + 4);

            Screen.SetPixel320x200x8(__x + 1, __y + 2, 25 + 4);
            Screen.SetPixel320x200x8(__x + 2, __y + 1, 25 + 4);

            Screen.SetPixel320x200x8(__x + 1, __y + 1, 60 + 4);
            Screen.SetPixel320x200x8(__x + 2, __y + 2, 60 + 4);
            Screen.SetPixel320x200x8(__x + 3, __y + 3, 60 + 4);
            Screen.SetPixel320x200x8(__x + 4, __y + 4, 60 + 4);
            Screen.SetPixel320x200x8(__x + 5, __y + 5, 60 + 4);
            Screen.SetPixel320x200x8(__x + 6, __y + 6, 60 + 4);
        }
    }
    /*
    unsafe static class GUI
    {
        private static Cosmos.Hardware.VGAScreen screen = new VGAScreen();
        private static Cosmos.Hardware.Drivers.PCI.Video.VMWareSVGAII svga;
        private static Cosmos.Hardware.Keyboard keyboard;
        private static Cosmos.Hardware.TextScreen textscreen;
        private static Cosmos.Hardware.Mouse mouse;
        private static uint ram = Cosmos.Core.CPU.GetAmountOfRAM() + 2; //Ram
        private static uint oldx, oldy;
        private static uint mouse_blinkswitch = 0;
        private enum MouseStates { normal, waiting }
        private static MouseStates MouseState = MouseStates.normal;

        //private static bool MenuPopup = false;          //pop up menù ancora in fase di peniero

        public static void Initialize()
        {
            clrVGA();
            /*
            screen = new Cosmos.Hardware.VGAScreen();
            keyboard = new Cosmos.Hardware.Keyboard();
            textscreen = new Cosmos.Hardware.TextScreen();
            mouse = new Cosmos.Hardware.Mouse();
            mouse.Initialize(0,0);
            //enterscreenhandling();
             */
    /*
            entersvgahandling();
        }
        public static void clrVGA()
        {
            screen.SetGraphicsMode(VGAScreen.ScreenSize.Size320x200, VGAScreen.ColorDepth.BitDepth8);
            screen.Clear(255);
        }
        public enum Color : byte { black = 0, white = 255 }

        public static void entersvgahandling()
        {
            FontGui.SetupFont();
            /*
            while (true)
            {
                oldx = (uint)mouse.X;
                oldy = (uint)mouse.Y;
                //screen.Clear(255);
                FontGui.drawText("SolarOS GUI  [ svga mode ]  v0.0.5a", 10, 10, 255, ref screen);
            }
             */
    /*
            }

            public static void enterscreenhandling()
            {

                int redrawings = 0;

                screen.Clear(255);

                mouse.X = 160;
                mouse.Y = 100;

                oldx = (uint)mouse.X;
                oldy = (uint)mouse.Y;

                FontGui.SetupFont();

                drawLine(2, 180, 315, 20, false);
                FontGui.drawText("SolarOS GUI v0.0.5a", 10, 10, 0, ref screen);

                while (true)
                {
                    // Draw mouse
                    uint curX = (uint)mouse.X; uint curY = (uint)mouse.Y;
                    if (oldx != curX || oldy != curY) UndrawMouse();
                    DrawMouse(curX, curY);
                    redrawings++;
                }
            }

            public static void UndrawMouse()
            {
                if (MouseState == MouseStates.normal)
                {
                    screen.SetPixel320x200x8(oldx, oldy, 255);

                    screen.SetPixel320x200x8(oldx + 1, oldy, 255);
                    screen.SetPixel320x200x8(oldx + 2, oldy, 255);
                    screen.SetPixel320x200x8(oldx + 3, oldy, 255);
                    screen.SetPixel320x200x8(oldx + 4, oldy, 255);

                    screen.SetPixel320x200x8(oldx, oldy + 1, 255);
                    screen.SetPixel320x200x8(oldx, oldy + 2, 255);
                    screen.SetPixel320x200x8(oldx, oldy + 3, 255);
                    screen.SetPixel320x200x8(oldx, oldy + 4, 255);

                    screen.SetPixel320x200x8(oldx + 1, oldy + 2, 255);
                    screen.SetPixel320x200x8(oldx + 2, oldy + 1, 255);

                    screen.SetPixel320x200x8(oldx + 1, oldy + 1, 255);
                    screen.SetPixel320x200x8(oldx + 2, oldy + 2, 255);
                    screen.SetPixel320x200x8(oldx + 3, oldy + 3, 255);
                    screen.SetPixel320x200x8(oldx + 4, oldy + 4, 255);
                    screen.SetPixel320x200x8(oldx + 5, oldy + 5, 255);
                    screen.SetPixel320x200x8(oldx + 6, oldy + 6, 255);
                }
                else if (MouseState == MouseStates.waiting)
                {
                    screen.SetPixel320x200x8(oldx, oldy, 20);

                    screen.SetPixel320x200x8(oldx - 1, oldy - 1, 255);
                    screen.SetPixel320x200x8(oldx - 2, oldy - 2, 255);
                    screen.SetPixel320x200x8(oldx - 3, oldy - 3, 255);

                    screen.SetPixel320x200x8(oldx + 1, oldy - 1, 255);
                    screen.SetPixel320x200x8(oldx + 2, oldy - 2, 255);
                    screen.SetPixel320x200x8(oldx + 3, oldy - 3, 255);

                    screen.SetPixel320x200x8(oldx - 1, oldy + 1, 255);
                    screen.SetPixel320x200x8(oldx - 2, oldy + 2, 255);
                    screen.SetPixel320x200x8(oldx - 3, oldy + 3, 255);

                    screen.SetPixel320x200x8(oldx + 1, oldy + 1, 255);
                    screen.SetPixel320x200x8(oldx + 2, oldy + 2, 255);
                    screen.SetPixel320x200x8(oldx + 3, oldy + 3, 255);

                    screen.SetPixel320x200x8(oldx + 1, oldy - 3, 255);
                    screen.SetPixel320x200x8(oldx + 2, oldy - 3, 255);
                    screen.SetPixel320x200x8(oldx + 1, oldy + 3, 255);
                    screen.SetPixel320x200x8(oldx + 2, oldy + 3, 255);
                }
            }

            public static void DrawMouse(uint __x, uint __y)
            {
                if (MouseState == MouseStates.normal)
                {
                    screen.SetPixel320x200x8(__x, __y, 0 + (mouse_blinkswitch * 20));

                    screen.SetPixel320x200x8(__x + 1, __y, 25 + (mouse_blinkswitch * 20));
                    screen.SetPixel320x200x8(__x + 2, __y, 25 + (mouse_blinkswitch * 20));
                    screen.SetPixel320x200x8(__x + 3, __y, 25 + (mouse_blinkswitch * 20));
                    screen.SetPixel320x200x8(__x + 4, __y, 25 + (mouse_blinkswitch * 20));

                    screen.SetPixel320x200x8(__x, __y + 1, 25 + (mouse_blinkswitch * 20));
                    screen.SetPixel320x200x8(__x, __y + 2, 25 + (mouse_blinkswitch * 20));
                    screen.SetPixel320x200x8(__x, __y + 3, 25 + (mouse_blinkswitch * 20));
                    screen.SetPixel320x200x8(__x, __y + 4, 25 + (mouse_blinkswitch * 20));

                    screen.SetPixel320x200x8(__x + 1, __y + 2, 25 + (mouse_blinkswitch * 20));
                    screen.SetPixel320x200x8(__x + 2, __y + 1, 25 + (mouse_blinkswitch * 20));

                    screen.SetPixel320x200x8(__x + 1, __y + 1, 60 + (mouse_blinkswitch * 20));
                    screen.SetPixel320x200x8(__x + 2, __y + 2, 60 + (mouse_blinkswitch * 20));
                    screen.SetPixel320x200x8(__x + 3, __y + 3, 60 + (mouse_blinkswitch * 20));
                    screen.SetPixel320x200x8(__x + 4, __y + 4, 60 + (mouse_blinkswitch * 20));
                    screen.SetPixel320x200x8(__x + 5, __y + 5, 60 + (mouse_blinkswitch * 20));
                    screen.SetPixel320x200x8(__x + 6, __y + 6, 60 + (mouse_blinkswitch * 20));

                    if (mouse_blinkswitch == 0 || mouse_blinkswitch == 1) mouse_blinkswitch++;
                    else mouse_blinkswitch = 0;
                }
                else if (MouseState == MouseStates.waiting)
                {
                    screen.SetPixel320x200x8(__x, __y, 20);

                    screen.SetPixel320x200x8(__x - 1, __y - 1, 20);
                    screen.SetPixel320x200x8(__x - 2, __y - 2, 20);
                    screen.SetPixel320x200x8(__x - 3, __y - 3, 20);

                    screen.SetPixel320x200x8(__x + 1, __y - 1, 20);
                    screen.SetPixel320x200x8(__x + 2, __y - 2, 20);
                    screen.SetPixel320x200x8(__x + 3, __y - 3, 20);

                    screen.SetPixel320x200x8(__x - 1, __y + 1, 20);
                    screen.SetPixel320x200x8(__x - 2, __y + 2, 20);
                    screen.SetPixel320x200x8(__x - 3, __y + 3, 20);

                    screen.SetPixel320x200x8(__x + 1, __y + 1, 20);
                    screen.SetPixel320x200x8(__x + 2, __y + 2, 20);
                    screen.SetPixel320x200x8(__x + 3, __y + 3, 20);

                    screen.SetPixel320x200x8(__x + 1, __y - 3, 20);
                    screen.SetPixel320x200x8(__x + 2, __y - 3, 20);
                    screen.SetPixel320x200x8(__x + 1, __y + 3, 20);
                    screen.SetPixel320x200x8(__x + 2, __y + 3, 20);
                }
                oldx = (uint)__x;
                oldy = (uint)__y;
            }

            // Graphics
            public static void DrawTime(uint __x, uint __y, uint __color)
            {
                string hour = Cosmos.Hardware.RTC.Hour.ToString("00");
                string minute = Cosmos.Hardware.RTC.Minute.ToString("00");
                string second = Cosmos.Hardware.RTC.Second.ToString("00");
                for (int i = 0; i != 9; i++)
                {
                    string ix = i.ToString("00");
                    FontGui.drawText(ix + ix + "h " + ix + ix + "m " + ix + ix + "s", __x, __y, 255, ref screen);
                }
                FontGui.drawText(hour + "h " + minute + "m " + second + "s", __x, __y, __color, ref screen);
            }

            public static void FillRectangle(uint __x, uint __y, uint __width, uint __height, uint __cindex)
            {
                for (uint y = __y; y != __height; y++)
                {
                    for (uint x = __x; x != __width; x++)
                    {
                        screen.SetPixel320x200x8(x, y, __cindex);
                    }
                }
            }
            public static void DrawRectangle(uint __x, uint __y, uint __width, uint __height, uint __cindex)
            {
                for (uint x = __x; x != __width; x++)
                {
                    screen.SetPixel320x200x8(x, __y, __cindex);
                    screen.SetPixel320x200x8(x, __y + __height, __cindex);
                }
                for (uint y = __y; y != __height; y++)
                {
                    screen.SetPixel320x200x8(__x, y, __cindex);
                    screen.SetPixel320x200x8(__x + __width, y, __cindex);
                }
            }
            public static void drawLine(uint x, uint y, uint length, uint color, bool vertical)
            {
                if (vertical)
                {
                    //Is vertical
                    for (uint l = 0; l <= length; l++)
                    {
                        screen.SetPixel320x200x8(x, y + l, color);
                    }
                }
                else
                {
                    //Is NOT vertical
                    for (uint l = 0; l <= length; l++)
                    {
                        screen.SetPixel320x200x8(x + l, y, color);
                    }

                }


            }
            public static void drawCircle(int x0, int y0, int radius, uint color)
            {
                int f = 1 - radius;
                int ddF_x = 1;
                int ddF_y = -2 * radius;
                int x = 0;
                int y = radius;

                screen.SetPixel320x200x8((uint)x0, (uint)(y0 + radius), color);
                screen.SetPixel320x200x8((uint)x0, (uint)(y0 - radius), color);
                screen.SetPixel320x200x8((uint)(x0 + radius), (uint)y0, color);
                screen.SetPixel320x200x8((uint)(x0 - radius), (uint)y0, color);

                while (x < y)
                {
                    if (f >= 0)
                    {
                        y--;
                        ddF_y += 2;
                        f += ddF_y;
                    }
                    x++;
                    ddF_x += 2;
                    f += ddF_x;
                    screen.SetPixel320x200x8((uint)(x0 + x), (uint)(y0 + y), color);
                    screen.SetPixel320x200x8((uint)(x0 - x), (uint)(y0 + y), color);
                    screen.SetPixel320x200x8((uint)(x0 + x), (uint)(y0 - y), color);
                    screen.SetPixel320x200x8((uint)(x0 - x), (uint)(y0 - y), color);
                    screen.SetPixel320x200x8((uint)(x0 + y), (uint)(y0 + x), color);
                    screen.SetPixel320x200x8((uint)(x0 - y), (uint)(y0 + x), color);
                    screen.SetPixel320x200x8((uint)(x0 + y), (uint)(y0 - x), color);
                    screen.SetPixel320x200x8((uint)(x0 - y), (uint)(y0 - x), color);
                }
            }

            public class Rect
            {
                public int X, Y, Width, Height;
                public Rect(int _X, int _Y, int _Width, int _Height)
                {
                    X = _X;
                    Y = _Y;
                    Width = _Width;
                    Height = _Height;
                }
            }
            public static bool IntersectsWith(this Rect r1, Rect r2)
            {
                if ((r1.X >= r2.X && r1.X <= r2.X + r2.Width) && (r1.Y >= r2.Y && r1.Y <= r2.Y + r2.Height)) return true;
                else return false;
            }
        }
     */
}
