namespace Lab_4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            descriptionLabel = new Label();
            encryptButton = new Button();
            decryptButton = new Button();
            countOpenedClosedKeysButton = new Button();
            richTextBox = new RichTextBox();
            encryptedRichTextBox = new RichTextBox();
            decryptedRichTextBox = new RichTextBox();
            textLabel = new Label();
            encryptedBlocksLabel = new Label();
            decryptedTextLabel = new Label();
            SuspendLayout();
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            descriptionLabel.Location = new Point(171, 48);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(638, 42);
            descriptionLabel.TabIndex = 0;
            descriptionLabel.Text = "Программа шифрует и расшифровывает введенную строку с помощью алгоритма RSA\nДля 10 варианта p = 137, q = 271";
            // 
            // encryptButton
            // 
            encryptButton.Location = new Point(754, 183);
            encryptButton.Name = "encryptButton";
            encryptButton.Size = new Size(144, 41);
            encryptButton.TabIndex = 1;
            encryptButton.Text = "Зашифровать";
            encryptButton.UseVisualStyleBackColor = true;
            encryptButton.Click += EncryptButton_Click;
            // 
            // decryptButton
            // 
            decryptButton.Location = new Point(754, 293);
            decryptButton.Name = "decryptButton";
            decryptButton.Size = new Size(144, 41);
            decryptButton.TabIndex = 2;
            decryptButton.Text = "Расшифровать";
            decryptButton.UseVisualStyleBackColor = true;
            decryptButton.Click += DecryptButton_Click;
            // 
            // countOpenedClosedKeysButton
            // 
            countOpenedClosedKeysButton.Location = new Point(98, 376);
            countOpenedClosedKeysButton.Name = "countOpenedClosedKeysButton";
            countOpenedClosedKeysButton.Size = new Size(144, 71);
            countOpenedClosedKeysButton.TabIndex = 3;
            countOpenedClosedKeysButton.Text = "Вычислить открытые/закрытые ключи";
            countOpenedClosedKeysButton.UseVisualStyleBackColor = true;
            countOpenedClosedKeysButton.Click += CountOpenedClosedKeysButton_Click;
            // 
            // richTextBox
            // 
            richTextBox.Location = new Point(351, 183);
            richTextBox.Name = "richTextBox";
            richTextBox.Size = new Size(349, 41);
            richTextBox.TabIndex = 4;
            richTextBox.Text = "";
            // 
            // encryptedRichTextBox
            // 
            encryptedRichTextBox.Location = new Point(351, 293);
            encryptedRichTextBox.Name = "encryptedRichTextBox";
            encryptedRichTextBox.Size = new Size(349, 41);
            encryptedRichTextBox.TabIndex = 5;
            encryptedRichTextBox.Text = "";
            // 
            // decryptedRichTextBox
            // 
            decryptedRichTextBox.Location = new Point(351, 406);
            decryptedRichTextBox.Name = "decryptedRichTextBox";
            decryptedRichTextBox.Size = new Size(349, 41);
            decryptedRichTextBox.TabIndex = 6;
            decryptedRichTextBox.Text = "";
            // 
            // textLabel
            // 
            textLabel.AutoSize = true;
            textLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textLabel.Location = new Point(351, 150);
            textLabel.Name = "textLabel";
            textLabel.Size = new Size(228, 19);
            textLabel.TabIndex = 7;
            textLabel.Text = "Текст, который будет зашифрован";
            // 
            // encryptedBlocksLabel
            // 
            encryptedBlocksLabel.AutoSize = true;
            encryptedBlocksLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            encryptedBlocksLabel.Location = new Point(351, 264);
            encryptedBlocksLabel.Name = "encryptedBlocksLabel";
            encryptedBlocksLabel.Size = new Size(158, 19);
            encryptedBlocksLabel.TabIndex = 8;
            encryptedBlocksLabel.Text = "Зашифрованные блоки";
            // 
            // decryptedTextLabel
            // 
            decryptedTextLabel.AutoSize = true;
            decryptedTextLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            decryptedTextLabel.Location = new Point(351, 377);
            decryptedTextLabel.Name = "decryptedTextLabel";
            decryptedTextLabel.Size = new Size(159, 19);
            decryptedTextLabel.TabIndex = 9;
            decryptedTextLabel.Text = "Расшифрованный текст";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 577);
            Controls.Add(decryptedTextLabel);
            Controls.Add(encryptedBlocksLabel);
            Controls.Add(textLabel);
            Controls.Add(decryptedRichTextBox);
            Controls.Add(encryptedRichTextBox);
            Controls.Add(richTextBox);
            Controls.Add(countOpenedClosedKeysButton);
            Controls.Add(decryptButton);
            Controls.Add(encryptButton);
            Controls.Add(descriptionLabel);
            Name = "Form1";
            Text = "Lab_4 variant 10";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label descriptionLabel;
        private Button encryptButton;
        private Button decryptButton;
        private Button countOpenedClosedKeysButton;
        private RichTextBox richTextBox;
        private RichTextBox encryptedRichTextBox;
        private RichTextBox decryptedRichTextBox;
        private Label textLabel;
        private Label encryptedBlocksLabel;
        private Label decryptedTextLabel;
    }
}