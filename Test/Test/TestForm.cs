using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Test
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private async void startTestButton_Click(object sender, EventArgs e)
        {
            // Prepare UI
            penultimateCardLabel.Visible = true;
            tenthCardLabel.Visible = true;
            penCardPictureBox.Visible = false;
            tenthCardPictureBox.Visible = false;

            // Instantiate an empty CardGroup object called deck
            executionTextBox.Text = "1.) Instantiating deck...\n\n";
            CardGroup deck = new CardGroup();
            await Task.Delay(1000);

            // Put 52 cards into deck
            executionTextBox.AppendText("2.) Using MakeWholeDeck()\n\n");
            deck.MakeWholeDeck();
            await Task.Delay(1000);

            // Print deck in a control
            executionTextBox.AppendText("3.) Print deck...\n\n");
            deckBox1.Text = deck.ToString();
            await Task.Delay(1000);

            // Shuffle deck
            executionTextBox.AppendText("4.) Using Shuffle()...\n\n");
            deck.Shuffle();
            await Task.Delay(1000);

            // Print deck in a control
            executionTextBox.AppendText("5.) Print deck...\n\n");
            deckBox2.Text = deck.ToString();
            await Task.Delay(1000);

            // Deal top card from deck and put it at the end
            executionTextBox.AppendText("6.) Using DealTopCard() and AddToGroup()...\n\n");
            Card topCard = deck.DealTopCard();
            deck.AddToDeck(topCard);
            await Task.Delay(1000);

            // Print deck in a control
            executionTextBox.AppendText("7.) Print deck...\n\n");
            deckBox3.Text = deck.ToString();
            await Task.Delay(1000);

            // Reveal the images of the tenth and penultimate card in their respective controls
            executionTextBox.AppendText("8.) Reveal cards...\n\n");
            penultimateCardLabel.Visible = false;
            tenthCardLabel.Visible = false;
            penCardPictureBox.Visible = true;
            tenthCardPictureBox.Visible = true;

            tenthCardPictureBox.Image = Image.FromFile(deck.GetCard(9).FileName());
            penCardPictureBox.Image = Image.FromFile(deck.GetCard(50).FileName());

            await Task.Delay(500);

            //  Done
            executionTextBox.AppendText("✔");
            startGameButton.Focus();

        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            BlackjackForm bjForm = new BlackjackForm();
            bjForm.Owner = this;
            bjForm.Show();
            this.Hide();
        }
    }
}
