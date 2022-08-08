namespace SortingFormApp
{
    public partial class Form1 : Form
    {
        static Graphics? g;
        static Brush black = new System.Drawing.SolidBrush(System.Drawing.Color.Yellow);
        static Brush white = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
        static int height;
        static int width;
        static int[]? myArray;
        static int speed = 0;
        static string algorithm = "bubble"; 

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            height = panel1.Height;
            width = panel1.Width;
            myArray = Settings.GenerateArray(width, height);
            g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Yellow), 0, 0, width, height);
            for(int i = 0; i < panel1.Width; i++)
            {
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Blue), i, height - myArray[i], 1, height);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (algorithm)
            {
                case "bubble":
                    Settings.BubbleSort(myArray, speed);
                    //Settings.MergeSortStart(myArray, speed);
                    break;
                case "selection":
                    Settings.SelectionSort(myArray, speed);
                    break;
            }
        }

        public static void SwapElements(int x, int y)
        {
            g.FillRectangle(black, x, 0, 1, height);
            g.FillRectangle(black, y, 0, 1, height);
            g.FillRectangle(white, x, height - myArray[x], 1, height);
            g.FillRectangle(white, y, height - myArray[y], 1, height);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            speed = trackBar1.Value * 5;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Selection Sort":
                    algorithm = "selection";
                    break;
                case "Bubble Sort":
                    algorithm = "bubble";
                    break;
                default:
                    algorithm = "bubble";
                    break;
            }
        }
    }
}