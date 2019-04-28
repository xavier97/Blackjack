using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public static class ThreadHelperClass
    {
        delegate void ShuffleDeckCallback(BlackjackForm f, RichTextBox richTextBox, PictureBox pictureBox1, PictureBox pictureBox2, PictureBox pictureBox3);
        delegate void DealPlayerCallback(BlackjackForm f, Card topCard, PictureBox deckPictureBox3, PictureBox playerCard1PictureBox);

        internal static void ShuffleDeckAction(BlackjackForm f, RichTextBox richTextBox, PictureBox pictureBox1, PictureBox pictureBox2, PictureBox pictureBox3)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true.
            if (richTextBox.InvokeRequired || pictureBox1.InvokeRequired || pictureBox2.InvokeRequired || pictureBox3.InvokeRequired)
            {
                ShuffleDeckCallback d = new ShuffleDeckCallback(ShuffleDeckAction);
                f.Invoke(d, new object[] { f, richTextBox, pictureBox1, pictureBox2, pictureBox3 });
            }
            else
            {
                f.ShuffleAnimation();
            }
        }

        internal static void DealPlayerAction(BlackjackForm f, Card topCard, PictureBox deckPictureBox3, PictureBox playerCard1PictureBox)
        {
            Console.WriteLine("thread help 1");
            if (deckPictureBox3.InvokeRequired || playerCard1PictureBox.InvokeRequired)
            {
                Console.WriteLine("thread help 2");
                DealPlayerCallback d = new DealPlayerCallback(DealPlayerAction);
                f.Invoke(d, new object[] { f, topCard, deckPictureBox3, playerCard1PictureBox });
            }
            else
            {
                Console.WriteLine("thread help 3");
                f.DealPlayerAnimation(topCard);
            }
        }
    }
}

