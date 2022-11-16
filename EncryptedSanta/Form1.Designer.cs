namespace EncryptedSanta
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCreateAsmKeys = new System.Windows.Forms.Button();
            this.labelKeys = new System.Windows.Forms.Label();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.labelSecretSantaResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCreateAsmKeys
            // 
            this.buttonCreateAsmKeys.Location = new System.Drawing.Point(56, 37);
            this.buttonCreateAsmKeys.Name = "buttonCreateAsmKeys";
            this.buttonCreateAsmKeys.Size = new System.Drawing.Size(205, 40);
            this.buttonCreateAsmKeys.TabIndex = 0;
            this.buttonCreateAsmKeys.Text = "Create keys";
            this.buttonCreateAsmKeys.UseVisualStyleBackColor = true;
            this.buttonCreateAsmKeys.Click += new System.EventHandler(this.buttonCreateAsmKeys_Click);
            // 
            // labelKeys
            // 
            this.labelKeys.AutoSize = true;
            this.labelKeys.Location = new System.Drawing.Point(293, 51);
            this.labelKeys.Name = "labelKeys";
            this.labelKeys.Size = new System.Drawing.Size(0, 13);
            this.labelKeys.TabIndex = 2;
            this.labelKeys.Click += new System.EventHandler(this.labelKeys_Click);
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Location = new System.Drawing.Point(494, 96);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(205, 43);
            this.buttonDecrypt.TabIndex = 3;
            this.buttonDecrypt.Text = "Decrypt result";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(56, 108);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(414, 20);
            this.inputTextBox.TabIndex = 5;
            // 
            // labelSecretSantaResult
            // 
            this.labelSecretSantaResult.AutoSize = true;
            this.labelSecretSantaResult.Location = new System.Drawing.Point(250, 168);
            this.labelSecretSantaResult.Name = "labelSecretSantaResult";
            this.labelSecretSantaResult.Size = new System.Drawing.Size(254, 13);
            this.labelSecretSantaResult.TabIndex = 6;
            this.labelSecretSantaResult.Text = "Decrypt your secret message to discover who to gift.";
            this.labelSecretSantaResult.Click += new System.EventHandler(this.labelSecretSantaResult_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 222);
            this.Controls.Add(this.labelSecretSantaResult);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.buttonDecrypt);
            this.Controls.Add(this.labelKeys);
            this.Controls.Add(this.buttonCreateAsmKeys);
            this.Name = "Form1";
            this.Text = "Encrypted Santa";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateAsmKeys;
        private System.Windows.Forms.Label labelKeys;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Label labelSecretSantaResult;
    }
}

