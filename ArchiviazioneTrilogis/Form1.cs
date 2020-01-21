using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchiviazioneTrilogis
{
    public partial class Form1 : Form
    {
        protected string UserDb = "";
        protected string PasswordDb = "";
        protected string TipoArch = "";
        protected string UnitaArchiviazione = "";
        protected string PercorsoArchiviazione = "";


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new Task(AvviaArchiviazione).Start();
        }

        private void CaricareLotti(FbConnection connectiondb)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "COPIA TABELLA LOTTI"; });
                
                System.Diagnostics.Process proclotti = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfolotti = new System.Diagnostics.ProcessStartInfo();
                startInfolotti.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfolotti.FileName = "cmd.exe";
                startInfolotti.WorkingDirectory = @"C:\trilogis\PentaUtilities\Firebird";
                startInfolotti.Arguments = @"/C fbexport -S -V LOTTI -D C:\trilogis\trilogis.fb20 -H localhost -P " + PasswordDb + " -Q \"WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL)\" -F - | fbexport -I -V LOTTI -D " + PercorsoArchiviazione + DateTime.Now.Year + "\\trilogis.fb20 -H localhost -P masterkey -F - -R";
                proclotti.StartInfo = startInfolotti;
                proclotti.Start();
                proclotti.WaitForExit();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "COPIA TABELLA LOTTIRIGHE"; });
                
                System.Diagnostics.Process proclottirighe = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfolottirighe = new System.Diagnostics.ProcessStartInfo();
                startInfolottirighe.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfolottirighe.FileName = "cmd.exe";
                startInfolottirighe.WorkingDirectory = @"C:\trilogis\PentaUtilities\Firebird";
                startInfolottirighe.Arguments = @"/C fbexport -S -V LOTTIRIGHE -D C:\trilogis\trilogis.fb20 -H localhost -P " + PasswordDb + " -Q \"WHERE LOTTORIGAID IN (SELECT LOTTORIGAID FROM LOTTIRIGHE WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL))\" -F - | fbexport -I -V LOTTIRIGHE -D " + PercorsoArchiviazione + DateTime.Now.Year + "\\trilogis.fb20 -H localhost -P masterkey -F - -R";
                proclottirighe.StartInfo = startInfolottirighe;
                proclottirighe.Start();
                proclottirighe.WaitForExit();


                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "COPIA TABELLA LOTTIRIGHELAVORAZIONI"; });
                
                System.Diagnostics.Process proclottirighelav = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfolottirighelav = new System.Diagnostics.ProcessStartInfo();
                startInfolottirighelav.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfolottirighelav.FileName = "cmd.exe";
                startInfolottirighelav.WorkingDirectory = @"C:\trilogis\PentaUtilities\Firebird";
                startInfolottirighelav.Arguments = @"/C fbexport -S -V LOTTIRIGHELAVORAZIONI -D C:\trilogis\trilogis.fb20 -H localhost -P " + PasswordDb + " -Q \"WHERE LOTTORIGAID IN (SELECT LOTTORIGAID FROM LOTTIRIGHE WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL))\" -F - | fbexport -I -V LOTTIRIGHELAVORAZIONI -D " + PercorsoArchiviazione + DateTime.Now.Year + "\\trilogis.fb20 -H localhost -P masterkey -F - -R";
                proclottirighelav.StartInfo = startInfolottirighelav;
                proclottirighelav.Start();
                proclottirighelav.WaitForExit();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "COPIA TABELLA MOVIMBOX"; });
                
                System.Diagnostics.Process procmovimbox = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfomovimbox = new System.Diagnostics.ProcessStartInfo();
                startInfomovimbox.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfomovimbox.FileName = "cmd.exe";
                startInfomovimbox.WorkingDirectory = @"C:\trilogis\PentaUtilities\Firebird";
                startInfomovimbox.Arguments = @"/C fbexport -S -V MOVIMBOX -D C:\trilogis\trilogis.fb20 -H localhost -P " + PasswordDb + " -Q \"WHERE LOTTORIGAID IN (SELECT LOTTORIGAID FROM LOTTIRIGHE WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL))\" -F - | fbexport -I -V MOVIMBOX -D " + PercorsoArchiviazione + DateTime.Now.Year + "\\trilogis.fb20 -H localhost -P masterkey -F - -R";
                procmovimbox.StartInfo = startInfomovimbox;
                procmovimbox.Start();
                procmovimbox.WaitForExit();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "COPIA TABELLA DOCUMENTILOTTI"; });
                
                System.Diagnostics.Process procdoclotti = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfodoclotti = new System.Diagnostics.ProcessStartInfo();
                startInfodoclotti.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfodoclotti.FileName = "cmd.exe";
                startInfodoclotti.WorkingDirectory = @"C:\trilogis\PentaUtilities\Firebird";
                startInfodoclotti.Arguments = @"/C fbexport -S -V DOCUMENTILOTTI -D C:\trilogis\trilogis.fb20 -H localhost -P " + PasswordDb + " -Q \"WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL)\" -F - | fbexport -I -V DOCUMENTILOTTI -D " + PercorsoArchiviazione + DateTime.Now.Year + "\\trilogis.fb20 -H localhost -P masterkey -F - -R";
                procdoclotti.StartInfo = startInfodoclotti;
                procdoclotti.Start();
                procdoclotti.WaitForExit();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "COPIA TABELLA DOCUMENTIRIGHE"; });
                
                System.Diagnostics.Process procdocrighe = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfodocrighe = new System.Diagnostics.ProcessStartInfo();
                startInfodocrighe.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfodocrighe.FileName = "cmd.exe";
                startInfodocrighe.WorkingDirectory = @"C:\trilogis\PentaUtilities\Firebird";
                startInfodocrighe.Arguments = @"/C fbexport -S -V DOCUMENTIRIGHE -D C:\trilogis\trilogis.fb20 -H localhost -P " + PasswordDb + " -Q \"WHERE LOTTORIGAID IN (SELECT LOTTORIGAID FROM LOTTIRIGHE WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL))\" -F - | fbexport -I -V DOCUMENTIRIGHE -D " + PercorsoArchiviazione + DateTime.Now.Year + "\\trilogis.fb20 -H localhost -P masterkey -F - -R";
                procdocrighe.StartInfo = startInfodocrighe;
                procdocrighe.Start();
                procdocrighe.WaitForExit();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "COPIA TABELLA PAGAMENTILOTTI"; });
                
                System.Diagnostics.Process procpaglotti = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfopaglotti = new System.Diagnostics.ProcessStartInfo();
                startInfopaglotti.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfopaglotti.FileName = "cmd.exe";
                startInfopaglotti.WorkingDirectory = @"C:\trilogis\PentaUtilities\Firebird";
                startInfopaglotti.Arguments = @"/C fbexport -S -V PAGAMENTILOTTI -D C:\trilogis\trilogis.fb20 -H localhost -P " + PasswordDb + " -Q \"WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL)\" -F - | fbexport -I -V PAGAMENTILOTTI -D " + PercorsoArchiviazione + DateTime.Now.Year + "\\trilogis.fb20 -H localhost -P masterkey -F - -R";
                procpaglotti.StartInfo = startInfopaglotti;
                procpaglotti.Start();
                procpaglotti.WaitForExit();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "COPIA TABELLA PAGAMENTIRIGHE"; });
                
                System.Diagnostics.Process procpagrighe = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfopagrighe = new System.Diagnostics.ProcessStartInfo();
                startInfopagrighe.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfopagrighe.FileName = "cmd.exe";
                startInfopagrighe.WorkingDirectory = @"C:\trilogis\PentaUtilities\Firebird";
                startInfopagrighe.Arguments = @"/C fbexport -S -V PAGAMENTIRIGHE -D C:\trilogis\trilogis.fb20 -H localhost -P " + PasswordDb + " -Q \"WHERE LOTTORIGAID IN (SELECT LOTTORIGAID FROM LOTTIRIGHE WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL))\" -F - | fbexport -I -V PAGAMENTIRIGHE -D " + PercorsoArchiviazione + DateTime.Now.Year + "\\trilogis.fb20 -H localhost -P masterkey -F - -R";
                procpagrighe.StartInfo = startInfopagrighe;
                procpagrighe.Start();
                procpagrighe.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore exportazione lotti. Errore: " + ex.ToString());
                Environment.Exit(1);
            }

            try
            {
                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE STORICO PAGAMENTIRIGHE"; });
                
                FbCommand CancellaPagamentiRighe = new FbCommand("DELETE FROM PAGAMENTIRIGHE WHERE LOTTORIGAID IN (SELECT LOTTORIGAID FROM LOTTIRIGHE WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL))", connectiondb);
                CancellaPagamentiRighe.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE STORICO PAGAMENTILOTTI"; });
                FbCommand CancellaPagamentiLotti = new FbCommand("DELETE FROM PAGAMENTILOTTI WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL)", connectiondb);
                CancellaPagamentiLotti.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE STORICO DOCUMENTIRIGHE"; });
                FbCommand CancellaDocumentiRighe = new FbCommand("DELETE FROM DOCUMENTIRIGHE WHERE LOTTORIGAID IN (SELECT LOTTORIGAID FROM LOTTIRIGHE WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL))", connectiondb);
                CancellaDocumentiRighe.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE STORICO DOCUMENTILOTTI"; });
                FbCommand CancellaDocumentiLotti = new FbCommand("DELETE FROM DOCUMENTILOTTI WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL)", connectiondb);
                CancellaDocumentiLotti.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE STORICO MOVIMBOX"; });
                FbCommand CancellaMovimbox = new FbCommand("DELETE FROM MOVIMBOX WHERE LOTTORIGAID IN (SELECT LOTTORIGAID FROM LOTTIRIGHE WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL))", connectiondb);
                CancellaMovimbox.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE STORICO LOTTIRIGHELAVORAZIONI"; });
                FbCommand CancellaLottiRigheLav = new FbCommand("DELETE FROM LOTTIRIGHELAVORAZIONI WHERE LOTTORIGAID IN (SELECT LOTTORIGAID FROM LOTTIRIGHE WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL))", connectiondb);
                CancellaLottiRigheLav.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE STORICO LOTTIRIGHE"; });
                FbCommand CancellaLottiRighe = new FbCommand("DELETE FROM LOTTIRIGHE WHERE LOTTORIGAID IN (SELECT LOTTORIGAID FROM LOTTIRIGHE WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL))", connectiondb);
                CancellaLottiRighe.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE STORICO LOTTOID"; });
                FbCommand CancellaLotti = new FbCommand("DELETE FROM LOTTI WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL)", connectiondb);
                CancellaLotti.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore cancellazione lotti. Errore: " + ex.ToString());
                Environment.Exit(1);
            }
        }

        private void CancellareLotti(FbConnection connectiondb)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE STORICO PAGAMENTIRIGHE"; });

                FbCommand CancellaPagamentiRighe = new FbCommand("DELETE FROM PAGAMENTIRIGHE WHERE LOTTORIGAID IN (SELECT LOTTORIGAID FROM LOTTIRIGHE WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL))", connectiondb);
                CancellaPagamentiRighe.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE STORICO PAGAMENTILOTTI"; });
                FbCommand CancellaPagamentiLotti = new FbCommand("DELETE FROM PAGAMENTILOTTI WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL)", connectiondb);
                CancellaPagamentiLotti.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE STORICO DOCUMENTIRIGHE"; });
                FbCommand CancellaDocumentiRighe = new FbCommand("DELETE FROM DOCUMENTIRIGHE WHERE LOTTORIGAID IN (SELECT LOTTORIGAID FROM LOTTIRIGHE WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL))", connectiondb);
                CancellaDocumentiRighe.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE STORICO DOCUMENTILOTTI"; });
                FbCommand CancellaDocumentiLotti = new FbCommand("DELETE FROM DOCUMENTILOTTI WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL)", connectiondb);
                CancellaDocumentiLotti.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE STORICO MOVIMBOX"; });
                FbCommand CancellaMovimbox = new FbCommand("DELETE FROM MOVIMBOX WHERE LOTTORIGAID IN (SELECT LOTTORIGAID FROM LOTTIRIGHE WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL))", connectiondb);
                CancellaMovimbox.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE STORICO LOTTIRIGHELAVORAZIONI"; });
                FbCommand CancellaLottiRigheLav = new FbCommand("DELETE FROM LOTTIRIGHELAVORAZIONI WHERE LOTTORIGAID IN (SELECT LOTTORIGAID FROM LOTTIRIGHE WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL))", connectiondb);
                CancellaLottiRigheLav.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE STORICO LOTTIRIGHE"; });
                FbCommand CancellaLottiRighe = new FbCommand("DELETE FROM LOTTIRIGHE WHERE LOTTORIGAID IN (SELECT LOTTORIGAID FROM LOTTIRIGHE WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL))", connectiondb);
                CancellaLottiRighe.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE STORICO LOTTOID"; });
                FbCommand CancellaLotti = new FbCommand("DELETE FROM LOTTI WHERE LOTTOID IN (SELECT LOTTOID FROM LOTTI WHERE LOTTODATACHIUSURA IS NOT NULL)", connectiondb);
                CancellaLotti.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore cancellazione lotti. Errore: " + ex.ToString());
                Environment.Exit(1);
            }
        }

        private void LoadIni()
        {
            if (File.Exists(Application.StartupPath + "/PentaStart.ini"))
            {
                IniFile ini = new IniFile();
                ini.Load(Application.StartupPath + "/PentaStart.ini");
                UserDb = ini.GetKeyValue("DB", "User");
                PasswordDb = ini.GetKeyValue("DB", "Password");
                TipoArch = ini.GetKeyValue("DB", "TipoArchiviazione"); //1 salva e cancella - 2 cancella 
                UnitaArchiviazione = ini.GetKeyValue("DB", "UnitaArchiviazione");
            }else
            {
                MessageBox.Show("PentaStart.ini non trovato. Impossibile continuare", "ArchiviazioneTrilogis");
                Environment.Exit(1);
            }

        }

        private FbConnection OpenDb()
        {
            try
            {
                FbConnection connect = new FbConnection("User=" + UserDb + ";Password=" + PasswordDb + ";Database=C:\\trilogis\\trilogis.fb20;DataSource=localhost;");
                connect.Open();
                return connect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore apertura conessione database. Error: " + Environment.NewLine + ex.ToString());
                Environment.Exit(1);
                return null;
            }
        }

        private FbConnection OpenDbArchiviazione()
        {
            if (!Directory.Exists(PercorsoArchiviazione + DateTime.Now.Year))
            {
                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CREAZIONE CARTELLA ANNO CORRENTE"; });
                
                Directory.CreateDirectory(PercorsoArchiviazione + DateTime.Now.Year);
            }

            bool archdbnuovo = false;
            if (!File.Exists(PercorsoArchiviazione + DateTime.Now.Year + "\\trilogis.fb20"))
            {
                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "COPIA DATABASE TRILOGIS SU UNITA DI ARCHIVIAZIONE"; });
                
                archdbnuovo = true;
                File.Copy("C:\\trilogis\\trilogis.fb20", PercorsoArchiviazione + DateTime.Now.Year + "\\trilogis.fb20", true);
            }

            if (!File.Exists(PercorsoArchiviazione + DateTime.Now.Year + "\\trilogislocalconf.fb20"))
            {
                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "COPIA DATABASE TRILOGISLOCALCONF SU UNITA DI ARCHIVIAZIONE"; });
                
                File.Copy("C:\\trilogis\\PentaUtilities\\DbArchiviazione\\trilogislocalconf.fb20", PercorsoArchiviazione + DateTime.Now.Year + "\\trilogislocalconf.fb20", true);
            }

            if (!File.Exists(PercorsoArchiviazione + DateTime.Now.Year + "\\trilogisremoteconf.fb20"))
            {
                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "COPIA DATABASE TRILOGISREMOTECONF SU UNITA DI ARCHIVIAZIONE"; });
                
                File.Copy("C:\\trilogis\\PentaUtilities\\DbArchiviazione\\trilogisremoteconf.fb20", PercorsoArchiviazione + DateTime.Now.Year + "\\trilogisremoteconf.fb20", true);
            }

            try
            {
                FbConnection connect = new FbConnection("User=" + UserDb + ";Password=" + PasswordDb + ";Database=" + PercorsoArchiviazione + DateTime.Now.Year + "\\trilogis.fb20;DataSource=localhost;");
                connect.Open();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE TRIGGERS DB STORICO"; });

                FbCommand DisableTriggers = new FbCommand("update RDB$TRIGGERS set RDB$TRIGGER_INACTIVE=1 where RDB$TRIGGER_NAME in (select A.RDB$TRIGGER_NAME from RDB$TRIGGERS A left join RDB$CHECK_CONSTRAINTS B ON B.RDB$TRIGGER_NAME = A.RDB$TRIGGER_NAME where((A.RDB$SYSTEM_FLAG = 0) or (A.RDB$SYSTEM_FLAG is null)) and(b.rdb$trigger_name is null) AND(NOT(A.RDB$TRIGGER_NAME LIKE 'RDB$%')))", connect);
                DisableTriggers.ExecuteNonQuery();

                if (archdbnuovo)
                {
                    this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE DATI DB STORICO"; });
                    
                    SvuotareDB(connect);
                }

                return connect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore apertura conessione database. Error: " + Environment.NewLine + ex.ToString());
                Environment.Exit(1);
                return null;
            }
        }

        private void AggiornareClienti(FbConnection connectionarch)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE CLIENTI DB STORICO"; });
                
                FbCommand CancellaClienti = new FbCommand("delete from clienti", connectionarch);
                CancellaClienti.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CARICAMENTO CLIENTI DB STORICO"; });
                
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.WorkingDirectory = @"C:\trilogis\PentaUtilities\Firebird";
                startInfo.Arguments = @"/C fbexport -S -V CLIENTI -D C:\trilogis\trilogis.fb20 -H localhost -P " + PasswordDb + " -F - | fbexport -I -V CLIENTI -D " + PercorsoArchiviazione + DateTime.Now.Year + "\\trilogis.fb20 -H localhost -P masterkey -F - -R";
                process.StartInfo = startInfo;
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Environment.Exit(1);
            }
        }

        private void SvuotareDB(FbConnection connectiondb)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE TABELLA PAGAMENTIRIGHE DB STORICO"; });
                
                FbCommand CancellaPagamentiRighe = new FbCommand("DELETE FROM PAGAMENTIRIGHE", connectiondb);
                CancellaPagamentiRighe.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE TABELLA PAGAMENTILOTTI DB STORICO"; });
                FbCommand CancellaPagamentiLotti = new FbCommand("DELETE FROM PAGAMENTILOTTI", connectiondb);
                CancellaPagamentiLotti.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE TABELLA DOCUMENTIRIGHE DB STORICO"; });
                FbCommand CancellaDocumentiRighe = new FbCommand("DELETE FROM DOCUMENTIRIGHE", connectiondb);
                CancellaDocumentiRighe.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE TABELLA DOCUMENTILOTTI DB STORICO"; });
                FbCommand CancellaDocumentiLotti = new FbCommand("DELETE FROM DOCUMENTILOTTI", connectiondb);
                CancellaDocumentiLotti.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE TABELLA MOVIMBOX DB STORICO"; });
                FbCommand CancellaMovimbox = new FbCommand("DELETE FROM MOVIMBOX", connectiondb);
                CancellaMovimbox.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE TABELLA LOTTIRIGHELAVORAZIONI DB STORICO"; });
                FbCommand CancellaLottiRigheLav = new FbCommand("DELETE FROM LOTTIRIGHELAVORAZIONI", connectiondb);
                CancellaLottiRigheLav.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE TABELLA LOTTIRIGHE DB STORICO"; });
                FbCommand CancellaLottiRighe = new FbCommand("DELETE FROM LOTTIRIGHE", connectiondb);
                CancellaLottiRighe.ExecuteNonQuery();

                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE TABELLA LOTTI DB STORICO"; });
                FbCommand CancellaLotti = new FbCommand("DELETE FROM LOTTI", connectiondb);
                CancellaLotti.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore cancellazione lotti. Errore: " + ex.ToString());
                Environment.Exit(1);
            }
        }

        private void ButtonChiudi_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private async void AvviaArchiviazione()
        {
            this.Invoke((MethodInvoker)delegate{this.buttonChiudi.Visible = false; });

            this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CARICAMENTO PENTASTART.INI"; });
            
            LoadIni();

            this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CERCANDO UNITA DI ARCHIVIAZIONE"; });
            
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                for (int i = 0; i < drives.Count(); i++)
                {
                    try
                    {
                        if (drives[i].VolumeLabel == UnitaArchiviazione)
                            PercorsoArchiviazione = drives[i].Name.Replace("/", "//");
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }
            }
            catch (Exception)
            {

            }


            if (PercorsoArchiviazione == "")
            {
                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "UNITA DI ARCHIVIAZIONE NON TROVATA"; });
                
                buttonChiudi.Visible = true;
                return;
            }

            this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "APERTURA DATABASE TRILOGIS"; });

            if (!File.Exists("C:\\trilogis\\PentaUtilities\\trilogislocalconf.fb20") || !File.Exists("C:\\trilogis\\PentaUtilities\\trilogisremoteconf.fb20"))
            {
                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "LOCALCONF O REMOTECONF STORICO NON TROVATO"; });
                this.Invoke((MethodInvoker)delegate { this.buttonChiudi.Visible = true; });
                return;
            }

            FbConnection con = OpenDb();
            this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "APERTURA DATABASE UNITA DI ARCH."; });
            
            FbConnection conArch = OpenDbArchiviazione();

            if (TipoArch == "2")
            {
                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "AGGIORNAMENTO TABELLA CLIENTI"; });
                AggiornareClienti(conArch);
                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "AGGIORNAMENTO LOTTI"; });
                CaricareLotti(con);
            }
            else if (TipoArch == "1")
            {
                this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Text = "CANCELLAZIONE STORICO IN CORSO"; });
                
                CancellareLotti(con);
            }

            this.Invoke((MethodInvoker)delegate { this.lbAvanzamento.Visible = false; });
            this.Invoke((MethodInvoker)delegate { this.Label2.Text = "ARCHIVIAZIONE"; });
            this.Invoke((MethodInvoker)delegate { this.label3.Text = "ESEGUITA CON SUCCESSO"; });
            this.Invoke((MethodInvoker)delegate { this.buttonChiudi.Visible = true; });
            
        }
    }
}
