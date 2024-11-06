using System;
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
            // Se desideri impostare un percorso fisso puoi scriverlo qui, ad esempio: 
            // return "C:\\Rubrica\\contatti.xml";
            // Altrimenti si può usare un percorso dinamico come la directory corrente:
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

                // Controlla se il file esiste, altrimenti crea un nuovo file XML vuoto
                if (!File.Exists(xmlFilePath))
                {
                    // Se non esiste, crea un file vuoto con la radice "Contatti"
                    XDocument nuovoDoc = new XDocument(new XElement("Contatti"));
                    MessageBox.Show("File creato con successo");
                    nuovoDoc.Save(xmlFilePath);
                }

                // Carica i contatti esistenti dal file XML
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
                listBoxContatti.DisplayMember = "NomeCompleto";  // Mostra Nome e Cognome
                listBoxContatti.ValueMember = "Email";  // Mantiene l'email come valore selezionato
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

                // Controlla che l'email sia valida
                if (!emailValida(txtEmail.Text))
                {
                    MessageBox.Show("Inserisci una email valida!");
                    return;
                }

                // Se il file non esiste, lo crea (verifica extra)
                if (!File.Exists(xmlFilePath))
                {
                    XDocument nuovoDoc = new XDocument(new XElement("Contatti"));
                    nuovoDoc.Save(xmlFilePath);
                }

                // Crea un nuovo elemento "Contatto" con i dati delle TextBox
                XElement nuovoContatto = new XElement("Contatto",
                    new XElement("Cognome", txtCognome.Text),
                    new XElement("Nome", txtNome.Text),
                    new XElement("Indirizzo", txtIndirizzo.Text),
                    new XElement("Email", txtEmail.Text),
                    new XElement("Telefono", txtTelefono.Text));

                // Carica il documento XML esistente
                XDocument doc = XDocument.Load(xmlFilePath);

                // Aggiunge il nuovo contatto al nodo "Contatti"
                doc.Element("Contatti").Add(nuovoContatto);

                // Salva il file XML con il nuovo contatto
                doc.Save(xmlFilePath);

                MessageBox.Show("Contatto aggiunto e file salvato correttamente!");

                // Ricarica i contatti per aggiornare la visualizzazione
                CaricaContatti();

                // Svuota i campi dopo aver aggiunto un contatto
                txtCognome.Text = "";
                txtNome.Text = "";
                txtIndirizzo.Text = "";
                txtEmail.Text = "";
                txtTelefono.Text = "";
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
            {
                // Carica i dati del contatto selezionato nei campi dinamici (che creeremo sotto)
                CaricaDatiContattoSelezionato(selectedContact);
            }
        }

        private TextBox txtModificaEmail, txtModificaTelefono;

        private void modificaContattoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verifica se ci sono altre GroupBox nella stessa posizione
            var existingGroupBox = this.Controls.OfType<GroupBox>()
                .FirstOrDefault(gb => gb.Left == 12 && gb.Top == 250);

            if (existingGroupBox != null)
            {
                // Sposta la GroupBox a destra
                existingGroupBox.Left += existingGroupBox.Width + 80;
            }

            // Crea il GroupBox per la modifica del contatto
            GroupBox groupBoxModifica = new GroupBox
            {
                Text = "Modifica Contatto",
                Left = 12,
                Top = 250,
                Width = 320,
                Height = 150
            };

            // Crea le label e le TextBox per Email e Telefono
            Label lblEmail = new Label { Text = "Email", Left = 10, Top = 20, AutoSize = true };
            txtModificaEmail = new TextBox { Left = 100, Top = 20, Width = 200 };

            Label lblTelefono = new Label { Text = "Telefono", Left = 10, Top = 60, AutoSize = true };
            txtModificaTelefono = new TextBox { Left = 100, Top = 60, Width = 200 };

            // Aggiungi un pulsante di conferma per salvare le modifiche
            Button btnSalvaModifiche = new Button { Text = "Salva", Left = 100, Top = 100, Width = 100 };
            btnSalvaModifiche.Click += new EventHandler(SalvaModificheContatto);

            // Aggiungi i controlli al GroupBox
            groupBoxModifica.Controls.Add(lblEmail);
            groupBoxModifica.Controls.Add(txtModificaEmail);
            groupBoxModifica.Controls.Add(lblTelefono);
            groupBoxModifica.Controls.Add(txtModificaTelefono);
            groupBoxModifica.Controls.Add(btnSalvaModifiche);

            // Aggiungi il GroupBox al form
            this.Controls.Add(groupBoxModifica);

            // Carica i dati del contatto selezionato
            var selectedContact = (dynamic)listBoxContatti.SelectedItem;
            if (selectedContact != null)
            {
                CaricaDatiContattoSelezionato(selectedContact);
            }
        }

        private void CaricaDatiContattoSelezionato(dynamic contatto)
        {
            // Assegna i valori alle TextBox create dinamicamente
            txtModificaEmail.Text = contatto.Email;
            txtModificaTelefono.Text = contatto.Telefono;
        }

        private void eliminaContattoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verifica se è stato selezionato un contatto nella ListBox
            var contattoSelezionato = (dynamic)listBoxContatti.SelectedItem;
            if (contattoSelezionato == null)
            {
                MessageBox.Show("Seleziona un contatto da eliminare / Inizia con la creazione di un nuovo contatto.");
                return;
            }

            // Mostra un messaggio di conferma con nome completo
            string messaggio = $"Sei sicuro di voler eliminare il contatto?\n\nNome Completo: {contattoSelezionato.NomeCompleto}";
            DialogResult risultato = MessageBox.Show(messaggio, "Conferma Eliminazione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Se l'utente conferma, procedi con l'eliminazione
            if (risultato == DialogResult.Yes)
            {
                string xmlFilePath = GetXmlFilePath(); // Assicurati di avere un metodo per ottenere il percorso del file XML

                try
                {
                    XDocument doc = XDocument.Load(xmlFilePath);

                    // Trova il contatto da eliminare
                    var contattoDaEliminare = doc.Descendants("Contatto")
                        .Where(x => x.Element("Email")?.Value == contattoSelezionato.Email)
                        .FirstOrDefault();

                    if (contattoDaEliminare != null)
                    {
                        // Rimuove il contatto dal documento XML
                        contattoDaEliminare.Remove();
                        doc.Save(xmlFilePath);

                        MessageBox.Show("Contatto eliminato con successo!");

                        // Ricarica i contatti per aggiornare la visualizzazione
                        CaricaContatti();
                    }
                    else
                    {
                        MessageBox.Show("Contatto non trovato.");
                    }
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
            // Verifica se il GroupBox di ricerca esiste già
            if (groupBoxRicerca == null)
            {
                // Crea il GroupBox per la ricerca
                groupBoxRicerca = new GroupBox
                {
                    Text = "Ricerca Contatto",
                    Left = 12,
                    Top = 250,
                    Width = 250,
                    Height = 150
                };

                // Crea le label e le TextBox per la ricerca
                Label lblRicerca = new Label { Text = "Ricerca", Left = 10, Top = 20, AutoSize = true };
                txtRicerca = new TextBox { Left = 100, Top = 20, Width = 120 };

                // Aggiungi un pulsante di conferma per avviare la ricerca
                Button btnRicerca = new Button { Text = "Cerca", Left = 100, Top = 100, Width = 100 };
                btnRicerca.Click += new EventHandler(CercaContatto);

                // Aggiungi i controlli al GroupBox
                groupBoxRicerca.Controls.Add(lblRicerca);
                groupBoxRicerca.Controls.Add(txtRicerca);
                groupBoxRicerca.Controls.Add(btnRicerca);

                // Aggiungi il GroupBox al form
                this.Controls.Add(groupBoxRicerca);
            }
        }

        private void CercaContatto(object sender, EventArgs e)
        {
            string xmlFilePath = GetXmlFilePath();

            try
            {
                XDocument doc = XDocument.Load(xmlFilePath);

                // Trova il contatto da cercare tramite il nome, cognome o telefono
                var contattoDaCercare = doc.Descendants("Contatto")
                    .Where(x => x.Element("Nome")?.Value == txtRicerca.Text ||
                                x.Element("Cognome")?.Value == txtRicerca.Text ||
                                x.Element("Telefono")?.Value == txtRicerca.Text)
                    .FirstOrDefault();

                if (contattoDaCercare != null)
                {
                    // Mostra i dettagli del contatto trovato
                    string messaggio = $"Contatto trovato:\n\nNome: {contattoDaCercare.Element("Nome")?.Value}\nCognome: {contattoDaCercare.Element("Cognome")?.Value}\nEmail: {contattoDaCercare.Element("Email")?.Value}\nTelefono: {contattoDaCercare.Element("Telefono")?.Value}";
                    MessageBox.Show(messaggio);
                }
                else
                {
                    MessageBox.Show("Contatto non trovato.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore durante la ricerca: " + ex.Message);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Apre una nuova finestra dove sono indicate le istruzioni per l'uso del programma
            MessageBox.Show("Benvenuto nella rubrica!\n\nPer aggiungere un contatto, compila tutti i campi e clicca su 'Aggiungi Contatto'.\n\nPer modificare un contatto, selezionalo dalla lista e clicca su 'Modifica Contatto'.\n\nPer eliminare un contatto, selezionalo dalla lista e clicca su 'Elimina Contatto'.\n\nPer cercare un contatto, clicca su 'Cerca Contatto' e inserisci il nome o l'email del contatto da cercare.\n\nBuon utilizzo!", "Istruzioni");
        }

        private void SalvaModificheContatto(object sender, EventArgs e)
        {
            string xmlFilePath = GetXmlFilePath();

            try
            {
                XDocument doc = XDocument.Load(xmlFilePath);

                // Trova il contatto da modificare tramite l'email originale o altro identificatore univoco
                var contattoDaModificare = doc.Descendants("Contatto")
                    .Where(x => x.Element("Email")?.Value == txtModificaEmail.Text)
                    .FirstOrDefault();

                if (contattoDaModificare != null)
                {
                    // Aggiorna solo i valori dell'email e del telefono
                    contattoDaModificare.Element("Email").Value = txtModificaEmail.Text;
                    contattoDaModificare.Element("Telefono").Value = txtModificaTelefono.Text;

                    // Salva il documento XML aggiornato
                    doc.Save(xmlFilePath);

                    MessageBox.Show("Contatto modificato con successo!");

                    // Ricarica i contatti per aggiornare la visualizzazione
                    CaricaContatti();
                }
                else
                {
                    MessageBox.Show("Contatto non trovato.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore durante il salvataggio: " + ex.Message);
            }
        }
    }
}