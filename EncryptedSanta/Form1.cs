using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace EncryptedSanta
{
    public partial class Form1 : Form
    {
        private readonly CspParameters _cspp = new CspParameters();
        private RSACryptoServiceProvider _rsa = null;

        // Public key file: will be stored in app's folder
        private const string PubKeyFileName = "/PublicKey.txt";
        private const string KeyName = "PersonalKey";


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tryImportPublicKey();
        }

        private void tryImportPublicKey()
        {
            try
            {
                using (var sr = new StreamReader(pubKeyFilePath()))
                {
                    _cspp.KeyContainerName = KeyName;
                    _rsa = new RSACryptoServiceProvider(_cspp);

                    string keytxt = sr.ReadToEnd();
                    _rsa.FromXmlString(keytxt);
                    _rsa.PersistKeyInCsp = true;

                    displayRsaKeysInfoInLabel();
                    manageButtonsToEnable(true);
                }
            }
            catch
            {
                displayNoKeyFoundWarningInLabel();
                manageButtonsToEnable(false);
            }
        }

        private string pubKeyFilePath()
        {
            string destFolderPath = Application.StartupPath; //Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            return destFolderPath + PubKeyFileName;
        }

        private void manageButtonsToEnable(bool isPubKeyFound)
        {
            buttonCreateAsmKeys.Enabled = !isPubKeyFound;
            buttonDecrypt.Enabled = isPubKeyFound;
        }

        private void displayNoKeyFoundWarningInLabel()
        {
            labelKeys.Text = "No keys found. Generate your personal keys to start.";
        }

        private void displayRsaKeysInfoInLabel()
        {
            labelKeys.Text = "Keys info ok: click on this text to copy the key " +
                (_rsa.PublicOnly? "(Public Only)":"(Full Key Pair)");
        }

        private void buttonCreateAsmKeys_Click(object sender, EventArgs e) // Create keys for user
        {
            try
            {
                _cspp.KeyContainerName = KeyName;
                _rsa = new RSACryptoServiceProvider(384, _cspp)
                {
                    PersistKeyInCsp = true
                };

                displayRsaKeysInfoInLabel();
                exportKeysToFile();
                manageButtonsToEnable(true);
            }
            catch(Exception exc)
            {
                MessageBox.Show("Couldn't create keys: " + exc.Message);
                manageButtonsToEnable(false);
            }
        }

        private void exportKeysToFile()
        {
            // Save the public key created by the RSA
            // to a file. Caution, persisting the
            // key to a file is a security risk.
            FileStream fs = new FileStream(pubKeyFilePath(), FileMode.OpenOrCreate, FileAccess.Write);
            using (var sw = new StreamWriter(fs))
            {
                sw.Write(_rsa.ToXmlString(false));
                sw.Flush();
                sw.Close();
            }
        }

        private void buttonDecrypt_Click(object sender, EventArgs e) // Decrypt the current content of the input field, using the public key in PubKeyFile
        {
            try
            {
                getPrivateKey();

                string toDecrypt = inputTextBox.Text;
                if (!string.IsNullOrWhiteSpace(toDecrypt))
                {
                    string decryptedText = DecryptionUtilities.ToDecryptedString(toDecrypt, _rsa);
                    labelSecretSantaResult.Text = "Your gift goes to: " + decryptedText + "!";
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show("Can't decrypt data: " + exc.Message);
            }
        }

        private void getPrivateKey()
        {
            _cspp.KeyContainerName = KeyName;
            _rsa = new RSACryptoServiceProvider(_cspp)
            {
                PersistKeyInCsp = true
            };
        }


        // Labels
        private void labelKeys_Click(object sender, EventArgs e)
        {
            if (_rsa != null)
                Clipboard.SetText(_rsa.ToXmlString(false));
        }

        private void labelSecretSantaResult_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(labelSecretSantaResult.Text);
        }
    }
}
