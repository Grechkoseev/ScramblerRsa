namespace Lab_4;

public partial class Form1 : Form
{
    private readonly ScramblerRsa _scramblerRsa;
    private readonly List<RadioButton> _radioButtons;
    public Form1()
    {
        InitializeComponent();
        _scramblerRsa = new ScramblerRsa(137, 271);
        _radioButtons = new List<RadioButton>();
    }

    private void EncryptButton_Click(object sender, EventArgs e)
    {
        var key = 0;
        var value = 0;

        foreach (var radioButton in _radioButtons.Where(radioButton => radioButton.Checked))
        {
            key = int.Parse(radioButton.Text[..radioButton.Text.IndexOf(',')]);
            value = int.Parse(radioButton.Text[(radioButton.Text.IndexOf(',') + 1)..]);
        }

        encryptedRichTextBox.Text = _scramblerRsa.EncryptString(richTextBox.Text, new KeyValuePair<int, int>(key, value));
    }

    private void DecryptButton_Click(object sender, EventArgs e)
    {
        var key = 0;
        var value = 0;

        foreach (var radioButton in _radioButtons.Where(radioButton => radioButton.Checked))
        {
            key = int.Parse(radioButton.Text[..radioButton.Text.IndexOf(',')]);
            value = int.Parse(radioButton.Text[(radioButton.Text.IndexOf(',') + 1)..]);
        }

        decryptedRichTextBox.Text = _scramblerRsa.DecryptString(encryptedRichTextBox.Text, new KeyValuePair<int, int>(key, value));
    }

    private void CountOpenedClosedKeysButton_Click(object sender, EventArgs e)
    {
        var edPairDictionary = _scramblerRsa.EdPairDictionary();
        var i = 0;

        foreach (var edKeyValuePair in edPairDictionary)
        {
            _radioButtons.Add(new RadioButton
            {
                Text = edKeyValuePair.Key + ", " + edKeyValuePair.Value,
                Location = new Point(110, 180 + i * 30)
            });

            i++;
        }

        foreach (var radioButton in _radioButtons)
        {
            Controls.Add(radioButton);
        }
    }
    
}