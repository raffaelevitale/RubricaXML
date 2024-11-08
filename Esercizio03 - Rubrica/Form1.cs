using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Esercizio03___Rubrica
{
    public partial class Form1 : Form
    {
        private string GetXmlFilePath()
        {
            return Path.Combine(Application.StartupPath, "contatti.xml");
        }

        public Form1()
        {
            InitializeComponent();
            CaricaContatti();
        }

        private void CaricaContatti()
        {
            try
            {
                string xmlFilePath = GetXmlFilePath();

                if (!File.Exists(xmlFilePath))
                {
                    XDocument nuovoDoc = new XDocument(new XElement("Contatti"));
                    MessageBox.Show("File creato con successo");
                    nuovoDoc.Save(xmlFilePath);
                }

                XDocument doc = XDocument.Load(xmlFilePath);
                var contatti = doc.Descendants("Contatto")
                .Select(x => new
                {
                    NomeCompleto = $"{x.Element("Cognome")?.Value} {x.Element("Nome")?.Value}",
                    Telefono = x.Element("Telefono")?.Value ?? string.Empty,
                    Email = x.Element("Email")?.Value ?? string.Empty
                }).ToList();

                // Popola la ListBox con i contatti
                listBoxContatti.DataSource = contatti;
                listBoxContatti.DisplayMember = "NomeCompleto";
                listBoxContatti.ValueMember = "Email";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento dei contatti: " + ex.Message);
            }
        }

        private bool emailValida(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCreaContatto_Click_1(object sender, EventArgs e)
        {
            try
            {
                string xmlFilePath = GetXmlFilePath();

                if (!emailValida(txtEmail.Text))
                {
                    MessageBox.Show("Inserisci una email valida!");
                    return;
                }

                if (!File.Exists(xmlFilePath))
                {
                    XDocument nuovoDoc = new XDocument(new XElement("Contatti"));
                    nuovoDoc.Save(xmlFilePath);
                }

                XElement nuovoContatto = new XElement("Contatto",
                    new XElement("Cognome", txtCognome.Text),
                    new XElement("Nome", txtNome.Text),
                    new XElement("Indirizzo", txtIndirizzo.Text),
                    new XElement("Email", txtEmail.Text),
                    new XElement("Telefono", txtTelefono.Text));

                XDocument doc = XDocument.Load(xmlFilePath);
                doc.Element("Contatti").Add(nuovoContatto);
                doc.Save(xmlFilePath);
                MessageBox.Show("Contatto aggiunto e file salvato correttamente!");
                CaricaContatti();

                txtCognome.Text = string.Empty;
                txtNome.Text = string.Empty;
                txtIndirizzo.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtTelefono.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nell'aggiunta del contatto: " + ex.Message);
            }
        }

        private void listBoxContatti_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedContact = (dynamic)listBoxContatti.SelectedItem;
            if (selectedContact != null)
                CaricaDatiContattoSelezionato(selectedContact);
        }

        private TextBox txtModificaEmail, txtModificaTelefono;

        private void modificaContattoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var existingGroupBox = this.Controls.OfType<GroupBox>()
                .FirstOrDefault(gb => gb.Left == 12 && gb.Top == 250);

            if (existingGroupBox != null)
                existingGroupBox.Left += existingGroupBox.Width + 80;

            GroupBox groupBoxModifica = new GroupBox
            {
                Text = "Modifica Contatto",
                Left = 12,
                Top = 250,
                Width = 320,
                Height = 150
            };

            Label lblEmail = new Label { Text = "Email", Left = 10, Top = 20, AutoSize = true };
            txtModificaEmail = new TextBox { Left = 100, Top = 20, Width = 200 };

            Label lblTelefono = new Label { Text = "Telefono", Left = 10, Top = 60, AutoSize = true };
            txtModificaTelefono = new TextBox { Left = 100, Top = 60, Width = 200 };

            Button btnSalvaModifiche = new Button { Text = "Salva", Left = 100, Top = 100, Width = 100 };
            btnSalvaModifiche.Click += new EventHandler(SalvaModificheContatto);

            groupBoxModifica.Controls.Add(lblEmail);
            groupBoxModifica.Controls.Add(txtModificaEmail);
            groupBoxModifica.Controls.Add(lblTelefono);
            groupBoxModifica.Controls.Add(txtModificaTelefono);
            groupBoxModifica.Controls.Add(btnSalvaModifiche);

            this.Controls.Add(groupBoxModifica);

            var selectedContact = (dynamic)listBoxContatti.SelectedItem;
            if (selectedContact != null)
                CaricaDatiContattoSelezionato(selectedContact);

            Timer timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += (s, ev) =>
            {
                this.Controls.Remove(groupBoxModifica);
                timer.Stop();
            };
            timer.Start();
        }

        private void CaricaDatiContattoSelezionato(dynamic contatto)
        {
            txtModificaEmail.Text = contatto.Email;
            txtModificaTelefono.Text = contatto.Telefono;
        }

        private void eliminaContattoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var contattoSelezionato = (dynamic)listBoxContatti.SelectedItem;
            if (contattoSelezionato == null)
            {
                MessageBox.Show("Seleziona un contatto da eliminare / Inizia con la creazione di un nuovo contatto.");
                return;
            }

            string messaggio = $"Sei sicuro di voler eliminare il contatto?\n\nNome Completo: {contattoSelezionato.NomeCompleto}";
            DialogResult risultato = MessageBox.Show(messaggio, "Conferma Eliminazione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (risultato == DialogResult.Yes)
            {
                string xmlFilePath = GetXmlFilePath();

                try
                {
                    XDocument doc = XDocument.Load(xmlFilePath);

                    var contattoDaEliminare = doc.Descendants("Contatto")
                        .Where(x => x.Element("Email")?.Value == contattoSelezionato.Email)
                        .FirstOrDefault();

                    if (contattoDaEliminare != null)
                    {
                        contattoDaEliminare.Remove();
                        doc.Save(xmlFilePath);

                        MessageBox.Show("Contatto eliminato con successo!");

                        CaricaContatti();
                    }
                    else
                        MessageBox.Show("Contatto non trovato.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore durante l'eliminazione: " + ex.Message);
                }
            }
        }

        private GroupBox groupBoxRicerca;
        private TextBox txtRicerca;

        private void ricercaContattoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (groupBoxRicerca == null)
            {
                groupBoxRicerca = new GroupBox
                {
                    Text = "Ricerca Contatto",
                    Left = 12,
                    Top = 250,
                    Width = 250,
                    Height = 150
                };

                Label lblRicerca = new Label { Text = "Ricerca", Left = 10, Top = 20, AutoSize = true };
                txtRicerca = new TextBox { Left = 100, Top = 20, Width = 120 };

                Button btnRicerca = new Button { Text = "Cerca", Left = 100, Top = 100, Width = 100 };
                btnRicerca.Click += new EventHandler(CercaContatto);

                groupBoxRicerca.Controls.Add(lblRicerca);
                groupBoxRicerca.Controls.Add(txtRicerca);
                groupBoxRicerca.Controls.Add(btnRicerca);

                this.Controls.Add(groupBoxRicerca);

                Timer timer = new Timer();
                timer.Interval = 3000;
                timer.Tick += (s, ev) =>
                {
                    this.Controls.Remove(groupBoxRicerca);
                    timer.Stop();
                };
                timer.Start();
            }
        }

        private void CercaContatto(object sender, EventArgs e)
        {
            string xmlFilePath = GetXmlFilePath();

            try
            {
                XDocument doc = XDocument.Load(xmlFilePath);

                var contattoDaCercare = doc.Descendants("Contatto")
                    .Where(x => x.Element("Nome")?.Value == txtRicerca.Text ||
                                x.Element("Cognome")?.Value == txtRicerca.Text ||
                                x.Element("Telefono")?.Value == txtRicerca.Text)
                    .FirstOrDefault();

                if (contattoDaCercare != null)
                {
                    string messaggio = $"Contatto trovato:\n\nNome: {contattoDaCercare.Element("Nome")?.Value}\nCognome: {contattoDaCercare.Element("Cognome")?.Value}\nEmail: {contattoDaCercare.Element("Email")?.Value}\nTelefono: {contattoDaCercare.Element("Telefono")?.Value}";
                    MessageBox.Show(messaggio);
                }
                else
                    MessageBox.Show("Contatto non trovato.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore durante la ricerca: " + ex.Message);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Benvenuto nella rubrica!\n\n" +
                "Per aggiungere un contatto, compila tutti i campi e clicca su 'Aggiungi Contatto'.\n\n" +
                "Per modificare un contatto, selezionalo dalla lista e clicca su 'Modifica Contatto'.\n\n" +
                "Per eliminare un contatto, selezionalo dalla lista e clicca su 'Elimina Contatto'.\n\n" +
                "Per cercare un contatto, clicca su 'Cerca Contatto' e inserisci il nome o l'email del contatto da cercare.\n\n" +
                "Per inserire un'immagine per il contatto, premere su Abbonamento.\n\n" +
                "Buon utilizzo!",
                "Istruzioni");
        }

        private void abbonamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var contattoSelezionato = (dynamic)listBoxContatti.SelectedItem;
            if (contattoSelezionato == null)
            {
                MessageBox.Show("Seleziona un contatto a cui inviare l'abbonamento.");
                return;
            }

            string messaggio = $"Vuoi inviare l'abbonamento a {contattoSelezionato.NomeCompleto}?";
            DialogResult risultato = MessageBox.Show(messaggio, "Conferma Abbonamento", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (risultato == DialogResult.Yes)
                MessageBox.Show("Abbonamento inviato con successo!");

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Seleziona un'immagine",
                Filter = "File immagine|*.jpg;*.jpeg;*.png;*.gif"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                MessageBox.Show("Immagine salvata con successo!");

                PictureBox pictureBox = new PictureBox
                {
                    Name = "pictureBox",
                    Size = new Size(150, 150),
                    Location = new Point(13, 250),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Image.FromFile(imagePath)
                };

                this.Controls.Add(pictureBox);

                MessageBox.Show("Immagine salvata e visualizzata con successo!");
            }
        }

        private void SalvaModificheContatto(object sender, EventArgs e)
        {
            string xmlFilePath = GetXmlFilePath();

            try
            {
                XDocument doc = XDocument.Load(xmlFilePath);

                var contattoDaModificare = doc.Descendants("Contatto")
                    .Where(x => x.Element("Email")?.Value == txtModificaEmail.Text)
                    .FirstOrDefault();

                if (contattoDaModificare != null)
                {
                    contattoDaModificare.Element("Email").Value = txtModificaEmail.Text;
                    contattoDaModificare.Element("Telefono").Value = txtModificaTelefono.Text;
                    doc.Save(xmlFilePath);
                    MessageBox.Show("Contatto modificato con successo!");
                    CaricaContatti();
                }
                else
                    MessageBox.Show("Contatto non trovato.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore durante il salvataggio: " + ex.Message);
            }
        }
    }
}