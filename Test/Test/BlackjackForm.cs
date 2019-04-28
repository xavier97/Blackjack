using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class BlackjackForm : Form
    {
        private int roundCount = 1;
        private int playerScore = 0;
        private int dealerScore = 0;
        private Card card;
        private CardGroup deck;
        private CardGroup playerHand;
        private CardGroup dealerHand;
        private Dictionary<string, PictureBox> playerCardsUIDict;
        private Dictionary<string, PictureBox> dealerCardsUIDict;
        AutoResetEvent stopWaitHandle = new AutoResetEvent(false);

        public BlackjackForm()
        {
            InitializeComponent();

            dealerLabel.Visible = false;
            playerLabel.Visible = false;
            playerScoreLabel.Visible = false;
            computerScoreLabel.Visible = false;
            scoreLabel1.Visible = false;
            scoreLabel2.Visible = false;
            hitButton.Enabled = false;
            standButton.Enabled = false;

            // Dictionary to access Player's Cards on UI
            playerCardsUIDict = new Dictionary<string, PictureBox>();
            for (int i = 0; i < 10; i++)
            {
                playerCardsUIDict[$"playerCard{i}PictureBox"] = null;
            }
            playerCardsUIDict["playerCard1PictureBox"] = playerCard1PictureBox;
            playerCardsUIDict["playerCard2PictureBox"] = playerCard7PictureBox;
            playerCardsUIDict["playerCard3PictureBox"] = playerCard3PictureBox;
            playerCardsUIDict["playerCard4PictureBox"] = playerCard9PictureBox;
            playerCardsUIDict["playerCard5PictureBox"] = playerCard5PictureBox;
            playerCardsUIDict["playerCard6PictureBox"] = playerCard2PictureBox;
            playerCardsUIDict["playerCard7PictureBox"] = playerCard8PictureBox;
            playerCardsUIDict["playerCard8PictureBox"] = playerCard4PictureBox;
            playerCardsUIDict["playerCard9PictureBox"] = playerCard10PictureBox;
            playerCardsUIDict["playerCard10PictureBox"] = playerCard6PictureBox;

            // Dictionary to access Dealer's Cards on UI
            dealerCardsUIDict = new Dictionary<string, PictureBox>();
            for (int i = 0; i < 10; i++)
            {
                dealerCardsUIDict[$"dealerCard{i}PictureBox"] = null;
            }
            dealerCardsUIDict["dealerCard1PictureBox"] = dealerCard1PictureBox;
            dealerCardsUIDict["dealerCard2PictureBox"] = dealerCard2PictureBox;
            dealerCardsUIDict["dealerCard3PictureBox"] = dealerCard3PictureBox;
            dealerCardsUIDict["dealerCard4PictureBox"] = dealerCard4PictureBox;
            dealerCardsUIDict["dealerCard5PictureBox"] = dealerCard5PictureBox;
            dealerCardsUIDict["dealerCard6PictureBox"] = dealerCard6PictureBox;
            dealerCardsUIDict["dealerCard7PictureBox"] = dealerCard7PictureBox;
            dealerCardsUIDict["dealerCard8PictureBox"] = dealerCard8PictureBox;
            dealerCardsUIDict["dealerCard9PictureBox"] = dealerCard9PictureBox;
            dealerCardsUIDict["dealerCard10PictureBox"] = dealerCard10PictureBox;

            dealerChatRichTextBox.Text = "Dealer: Welcome to the table! Press \"Play Game\" to begin a set of 5 rounds.";

        }

        private void InitGame()
        {
            deckPictureBox1.Image = Image.FromFile(@"..\..\Resources\Back.gif");
            deckPictureBox2.Image = Image.FromFile(@"..\..\Resources\Back.gif");
            deckPictureBox3.Image = Image.FromFile(@"..\..\Resources\Back.gif");

            dealerLabel.Visible = true;
            playerLabel.Visible = true;
            playerScoreLabel.Visible = true;
            computerScoreLabel.Visible = true;
            scoreLabel1.Visible = true;
            scoreLabel2.Visible = true;
            roundLabel.Visible = true;

            playGameButton.Enabled = false;

            roundLabel.Text = $"Round: {roundCount}";
            playerScoreLabel.Text = playerScore.ToString();
            computerScoreLabel.Text = dealerScore.ToString();

            card = new Card();
            deck = new CardGroup();
            playerHand = new CardGroup();
            dealerHand = new CardGroup();

            deck.MakeWholeDeck();

        }

        #region ActionEvents
        private void quitGameButton_Click(object sender, EventArgs e)
        {
            TestForm testForm = new TestForm();
            this.Close();
            testForm.Show();
        }

        private void playGameButton_Click(object sender, EventArgs e)
        {
            PlayGame();
        }

        // Player gets dealer to deal them another card
        private async void hitButton_Click(object sender, EventArgs e)
        {
            // Draw Card
            Card topCard = new Card();
            topCard = deck.DealTopCard();
            await DealPlayerAnimation(topCard, playerHand.NumCards);
            playerHand.AddToDeck(topCard);
            await Task.Delay(400);

            // Calculate Player's hand
            int playerVal = 0;
            for (int count = 0; count < playerHand.NumCards; count++)
            {
                playerVal += playerHand.GetCard(count).GetValue();
            }
            for (int count = 0; count < playerHand.NumCards; count++)
            {
                if (playerHand.GetCard(count).Face == "A")
                {
                    playerVal = CheckAce(playerVal);
                }
            }

            // Check if player busts
            if (playerVal > 21)
            {
                dealerScore++;
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "You Busted - You Lost.";
                string caption = "Better luck next time.";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                await PrepareNextRound();
            }
        }

        // Player doesn't want another card from dealer
        private void StandButton_Click(object sender, EventArgs e)
        {
            FinishRound();
        }
        #endregion

        private async void PlayGame()
        {
            InitGame();

            // Shuffle deck
            Card topCard = new Card();
            deck.Shuffle();
            await ShuffleAnimation();

            await Task.Delay(300);

            //Card testCard1 = new Card("A", "H");
            //Card testCard2 = new Card("Q", "S");
            //deck.SetCard(0, testCard1);
            //deck.SetCard(1, testCard2);

            // Deal 2 Cards to player
            for (int count = 0; count < 2; count++)
            {
                topCard = deck.DealTopCard();
                await DealPlayerAnimation(topCard, playerHand.NumCards);
                playerHand.AddToDeck(topCard);
                await Task.Delay(300);
            }

            //// Check for BLACKJACK
            //if ((playerHand.GetCard(0).Face == "A" && playerHand.GetCard(1).GetValue() == 10) ||
            //    (playerHand.GetCard(1).Face == "A" && playerHand.GetCard(0).GetValue() == 10))
            //{
            //    playerScore++;
            //    string message = "BLACK-JACK!";
            //    string caption = "You Won!! Wow, so lucky!";
            //    MessageBoxButtons buttons = MessageBoxButtons.OK;
            //    DialogResult result;
            //    result = MessageBox.Show(message, caption, buttons);
            //    if (result == DialogResult.OK)
            //    {
            //        dealerChatRichTextBox.Text = "Dealer: ...";
            //        await PrepareNextRound();
            //        PlayGame();
            //    }
            //    return;
            //}

            // Deal himself
            for (int count = 0; count < 2; count++)
            {
                topCard = deck.DealTopCard();
                await DealDealerAnimation(topCard, dealerHand.NumCards);
                dealerHand.AddToDeck(topCard);
                await Task.Delay(300);
            }

            await Task.Delay(1000);

            // Ask player choice
            dealerChatRichTextBox.Text = "Dealer: Hit or Stand?";
            hitButton.Enabled = true;
            standButton.Enabled = true;
        }

        private async void FinishRound()
        {
            // Calculate Player's hand
            int playerVal = 0;
            for (int count = 0; count < playerHand.NumCards; count++)
            {
                playerVal += playerHand.GetCard(count).GetValue();
            }
            for (int count = 0; count < playerHand.NumCards; count++)
            {
                if (playerHand.GetCard(count).Face == "A")
                {
                    playerVal = CheckAce(playerVal);
                }
            }

            // Dealer flips 2nd Card face up
            dealerCard2PictureBox.Visible = true;
            dealerCard2PictureBox.Image = Image.FromFile(dealerHand.GetCard(1).FileName());

            // Dealer continues to draw while val < 16
            int dealerVal = dealerHand.GetCard(0).GetValue() + dealerHand.GetCard(1).GetValue();
            for (int count = 0; count < dealerHand.NumCards; count++)
            {
                if (dealerHand.GetCard(count).Face == "A")
                {
                    dealerVal = CheckAce(dealerVal);
                }
            }
            while (dealerVal < 16)
            {
                Card topCard = new Card();
                topCard = deck.DealTopCard();
                await DealDealerAnimation(topCard, dealerHand.NumCards);
                dealerHand.AddToDeck(topCard);
                dealerVal += topCard.GetValue();
                if (topCard.Face == "A")
                {
                    dealerVal = CheckAce(dealerVal);
                }
                await Task.Delay(500);
            }
            for (int count = 0; count < dealerHand.NumCards; count++)
            {
                if (dealerHand.GetCard(count).Face == "A")
                {
                    dealerVal = CheckAce(dealerVal);
                }
            }

            // Compare Totals & Announce Winner [Note: Dealer Wins Ties]
            if (dealerVal >= playerVal && dealerVal <= 21) // Lose
            {
                dealerScore++;
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "You Lost.";
                string caption = "Better luck next time...";
                if (dealerVal == playerVal)
                {
                    message = "It's a Push. You Lost.";
                    caption = "I always win ties. Better luck next time.";
                }
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);

            }
            else // Win [Dealer busts or player's value is higher]
            {
                playerScore++;
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "You Won!";
                string caption = "Congratulations!";
                if (dealerVal > 21)
                {
                    message = "I Busted. You Won!";
                    caption = "Congrats.";
                }
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
            }

            await PrepareNextRound();
        }

        private async Task PrepareNextRound()
        {
            if (roundCount % 5 == 0)
            {
                string message = "Do you want to play another set of 5 rounds?";
                string title = "Continue Playing";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.No)
                {
                    dealerChatRichTextBox.Text = "Dealer: See you next time!";
                    MessageBox.Show($"Player: {playerScore}\nDealer: {dealerScore}", "Final Score");
                    await Task.Delay(2000);
                    TestForm testForm = new TestForm();
                    this.Close();
                    testForm.Show();
                }
                else
                {
                    dealerChatRichTextBox.Text = "Dealer: Very well.";
                    roundCount++;
                    ClearCards();
                    PlayGame();
                    await Task.Delay(2000);
                }
            }
            else
            {
                roundCount++;
                ClearCards();
                PlayGame();
            }
        }

        private void ClearCards()
        {
            // Clear Dealer
            for (int i = 1; i <= 10; i++)
            {
                dealerCardsUIDict[$"dealerCard{i}PictureBox"].Visible = false;
            }
            // Clear Player
            for (int i = 1; i <= 10; i++)
            {
                playerCardsUIDict[$"playerCard{i}PictureBox"].Visible = false;
            }
        }

        private int CheckAce(int handVal)
        {
            if (handVal + 10 < 21) // Check if adding 10 will bust
            {
                return handVal + 10;
            }
            return handVal;
        }

        #region ShortAnimationStuff
        private async Task DealPlayerAnimation(Card deckCard, int numCards)
        {
            // Simulate Drawing a Card
            deckPictureBox3.BringToFront();
            deckPictureBox3.Visible = true;
            await Task.Delay(200);
            deckPictureBox3.Visible = false;

            await Task.Delay(650);

            // Show Card in front of table
            playerCardsUIDict[$"playerCard{numCards + 1}PictureBox"].Image = Image.FromFile(deckCard.FileName());
            playerCardsUIDict[$"playerCard{numCards + 1}PictureBox"].Visible = true;
        }

        private async Task DealDealerAnimation(Card deckCard, int numCards)
        {
            // Simulate Drawing a Card
            deckPictureBox3.BringToFront();
            deckPictureBox3.Visible = true;
            await Task.Delay(200);
            deckPictureBox3.Visible = false;

            await Task.Delay(650);

            if ((numCards + 1) == 2) // 2nd Card shows face-down
            {
                dealerCard2PictureBox.Visible = true;
                dealerCard2PictureBox.Image = Image.FromFile(@"..\..\Resources\Back.gif"); ;
            }
            else
            {
                // Show Card in front of table
                dealerCardsUIDict[$"dealerCard{numCards + 1}PictureBox"].Image = Image.FromFile(deckCard.FileName());
                dealerCardsUIDict[$"dealerCard{numCards + 1}PictureBox"].Visible = true;
            }
        }

        private async Task ShuffleAnimation()
        {
            deckPictureBox3.SendToBack();
            dealerChatRichTextBox.Text = "Dealer: ** shuffles deck **";
            UseWaitCursor = true;
            for (int x = 0; x < 10; x++)
            {
                deckPictureBox1.Visible = true;
                deckPictureBox2.Visible = true;
                deckPictureBox3.Visible = false;
                await Task.Delay(100);
                deckPictureBox1.Visible = false;
                deckPictureBox2.Visible = true;
                deckPictureBox3.Visible = true;
                await Task.Delay(100);
            }
            deckPictureBox1.Visible = false;
            deckPictureBox2.Visible = true;
            deckPictureBox3.Visible = false;
            UseWaitCursor = false;
            dealerChatRichTextBox.Text = "Dealer: ...";
        }
        #endregion
    }
}
