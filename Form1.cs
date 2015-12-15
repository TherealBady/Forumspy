using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Net;
using System.Globalization;

public struct ponted
{
   public string poster;
   public int postid;
    public Int32 point;
}        
 

namespace WindowsFormsApplication1
{

   
    public partial class Forumpointspy : Form
    {
        List<string> momentreader = new List<string>();
        List<string> refmomentreader = new List<string>();
       

      
        List<ponted> posterlist = new List<ponted>();

        string posternamestart = "<span class=\"author vcard\"><a class=\"url fn\" href='http://forum.hunbrony.hu/index.php?/user";
        string postedbetweenstart = "<span class=\"author vcard\"><a class=\"url fn\" href='";
        string postedbetweenend = "'>";
        //string postedbeveenstart = "/'>";
        //string posternameend = "</a>&nbsp;<a href='http://forum.hunbrony.hu/index.php?/user/";
       // string postedtime = "Elküldve: <abbr class=\"published\" title=\"";
        string getpoint = "ipb.global.registerReputation( 'rep_post_";
        string idafter = "', { app: 'forums', type: 'pid', typeid: '";
        string pointbetweenstart = "' }, parseInt('";
        string pointbetweenend = "') );";


        string readerliststart = "<div id='topic_active_users' class='active_users'>";
        string readerlistend = "<!-- Close topic -->";
        string readerstart = "<li><a href='";
        string readerend = "' title='";

        public Forumpointspy()
        {
            InitializeComponent();
            checkinterval.Value = checktimer.Interval/1000;

        }

        private void stratstop_Click(object sender, EventArgs e)
        {




            if (!checktimer.Enabled)
            {
                checktimer.Start();
                linkbar.Enabled = false;
                checkinterval.Enabled = false;
                //logtext.ForeColor = Color.Blue;
                DateTime localDate = DateTime.Now;
                var culture = new CultureInfo("hu-HU");
                string date = localDate.ToString(culture);
                stratstop.Text = "Stop spying!";
                string appendst = date+" - checking started at - " + linkbar.Text + " - with " + Convert.ToString(checktimer.Interval / 1000) + " second interval ";
                logtext.SelectionStart = logtext.TextLength;
                logtext.SelectionLength = appendst.Length;
                logtext.AppendText(appendst);
                //logtext.Find(appendst);
                logtext.SelectionColor = Color.Blue;
                logtext.AppendText(System.Environment.NewLine);
                //logtext.Text = "";
                posterlist.Clear();
                checknews();
            }
            else
            {
                //logtext.ForeColor = Color.Green;
                DateTime localDate = DateTime.Now;
                var culture = new CultureInfo("hu-HU");
                string date = localDate.ToString(culture);
                stratstop.Text = "Start spying!";
               string appendst =date+" - Checking stopped.";
               logtext.SelectionStart = logtext.TextLength;
               logtext.SelectionLength = appendst.Length;
               logtext.AppendText(appendst);
               logtext.SelectionColor = Color.Green;
                logtext.AppendText( System.Environment.NewLine);
                checkinterval.Enabled = true;
                checktimer.Stop();
                linkbar.Enabled = true;
                momentreader.Clear();
                refmomentreader.Clear();
            }
        }

        private void checknews()
        {
            WebClient client = new WebClient();
            string htmlCode="";
            try
            {
              
                htmlCode = client.DownloadString(linkbar.Text);
            }
            catch
            {
                /*
                string appendst = "Error, something terrible happened, checking stopped.";
                logtext.SelectionStart = logtext.TextLength;
                logtext.SelectionLength = appendst.Length;
                logtext.AppendText(appendst);
                //logtext.Find(appendst);
                logtext.SelectionColor = Color.Red;
                checktimer.Stop();
                linkbar.Enabled = true;
                checkinterval.Enabled = true;
                stratstop.Text = "Start spying!";
               logtext.AppendText( System.Environment.NewLine);
                 */
            }

            checknewpoints(htmlCode);

        }

        private bool checknewpoints(string htmlcode)
        {


           
            using (StringReader sr = new StringReader(htmlcode))
            {
                //int usercounter = -1;
                string line;
                string anoneposter = "";
                bool getactplayers= false;
                ponted oneposter = new ponted();
                while ((line = sr.ReadLine()) != null)
                {


                    //if (line.Contains(getpoint)) catchpoint = true;
                    anoneposter += line;
                    if (line.Contains(readerliststart))
                    {
                        getactplayers = true;
                        topicreaders.Clear();
                        refmomentreader.Clear();

                    }
                    if (line.Contains(readerstart) && getactplayers)
                    {
                        //topicreaders.AppendText("megneztem, most mi van?");
                        string postter = getBetween(line, readerstart, readerend);
                        
                        refmomentreader.Add(postter);
                        //logtext.AppendText("a "+postter);
                        //logtext.AppendText(System.Environment.NewLine);
                        topicreaders.AppendText(postter);
                        topicreaders.AppendText(System.Environment.NewLine);

                    }
                    //if (getactplayers) 
                       // logtext.AppendText(line);

                    if (line.Contains(readerlistend))
                    {
                        List<string> savecont = new List<string>();
                        for (int k = 0; k < refmomentreader.Count; k++) savecont.Add(refmomentreader[k]);

                        for (int i = 0; i < refmomentreader.Count; i++)
                        {

                            for (int j = 0; j < momentreader.Count; j++)
                            {
                                if (refmomentreader[i] == momentreader[j])
                                {

                                    i = 0;
                                    j = 0;
                                    refmomentreader.RemoveAt(i);
                                    momentreader.RemoveAt(j);
                                  
                                }
                            }
                        }

                        if (refmomentreader.Count > 0)
                        {
                            DateTime localDate = DateTime.Now;
                            var culture = new CultureInfo("hu-HU");
                            string date = localDate.ToString(culture);
                            logtext.AppendText(date+" - Új vendég:");
                            logtext.AppendText(System.Environment.NewLine);
                            for (int i = 0; i < refmomentreader.Count; i++)
                            {
                                logtext.AppendText(refmomentreader[i]);
                                logtext.AppendText(System.Environment.NewLine);
                            }
                            refmomentreader.Clear();
                        }

                        if (momentreader.Count > 0)
                        {
                            DateTime localDate = DateTime.Now;
                            var culture = new CultureInfo("hu-HU");
                            string date = localDate.ToString(culture);
                            logtext.AppendText(date+" - Kilépett a topikból:");
                            logtext.AppendText(System.Environment.NewLine);
                            for (int i = 0; i < momentreader.Count; i++)
                            {
                                logtext.AppendText(momentreader[i]);
                                logtext.AppendText(System.Environment.NewLine);
                            }
                            momentreader.Clear();
                        }

                        //momentreader.Clear();
                        for (int k = 0; k < savecont.Count; k++) momentreader.Add(savecont[k]);
                           

                        getactplayers = false;
                        if (momentreader.Count == 0)
                        {
                            topicreaders.AppendText("Jelelnleg senki sem olvassa ezt a topikot");
                            topicreaders.AppendText(System.Environment.NewLine);
                        }
                    }
                    
                    
                    if (line.Contains(posternamestart))
                    {
                        string poster = getBetween(anoneposter, postedbetweenstart, postedbetweenend);
                        if (poster != "") oneposter.poster = poster;
    
                    }

                    if (line.Contains(getpoint))
                    {
                        string getposstid = getBetween(line, getpoint, idafter);
                        /*
                        logtext.AppendText(getposstid);
                        logtext.AppendText(System.Environment.NewLine);
                        logtext.AppendText(line);
                        logtext.AppendText(System.Environment.NewLine);
                        */
                        oneposter.postid = Convert.ToInt32(getposstid);

                        string chatchpointstring = getBetween(line, pointbetweenstart, pointbetweenend);
                        oneposter.point = Convert.ToInt32(chatchpointstring);

                        bool foundid = false;
                        for (int i = 0; i < posterlist.Count; i++)
                        {

                            if (oneposter.postid == posterlist[i].postid)
                            {
                                if (oneposter.point != posterlist[i].point)
                                {
                                    //logtext.AppendText(appendst);
                                    int newpoint = oneposter.point - posterlist[i].point;
                                    string plusn = "";
                                    if (newpoint > 0) plusn = "+";
                                    DateTime localDate = DateTime.Now;
                                    var culture = new CultureInfo("hu-HU");
                                    string date = localDate.ToString(culture);
                                    string appendst =date+" - "+ Convert.ToString(i) + ". hozzászólás(id.:" + posterlist[i].postid + ") pontváltozás: " + plusn + Convert.ToString(newpoint);
                                    logtext.SelectionStart = logtext.TextLength;
                                    logtext.SelectionLength = appendst.Length;
                                    logtext.AppendText(appendst);
                                    logtext.AppendText(System.Environment.NewLine);
                                    if (newpoint > 0) logtext.SelectionColor = Color.Green;
                                    if (newpoint < 0) logtext.SelectionColor = Color.Red;
                                    if (momentreader.Count > 0)
                                    {
                                        logtext.AppendText("lehetséges pontozók:");
                                        logtext.AppendText(System.Environment.NewLine);
                                        for (int j = 0; j < momentreader.Count; j++) logtext.AppendText(momentreader[j]);

                                    }
                                    else logtext.AppendText("Hit and run! :/");
                                    logtext.AppendText(System.Environment.NewLine);

                                }
                                posterlist[i] = oneposter;
                                i = posterlist.Count;
                                foundid = true;
                            }
                        }
                        if (!foundid)
                        {
                            //posterlist.Add(oneposter);
                            posterlist.Add(oneposter);
                            DateTime localDate = DateTime.Now;
                            var culture = new CultureInfo("hu-HU");
                            string date = localDate.ToString(culture);
                            logtext.AppendText(date+" - Új poszt hozzáadva! Poszt id.:" + Convert.ToString(oneposter.postid) + " Aktuális pont: " + Convert.ToInt32(oneposter.point));
                            logtext.AppendText(System.Environment.NewLine);
                            logtext.AppendText("Poszt tulaj: " + oneposter.poster);
                            logtext.AppendText(System.Environment.NewLine);
                        }
                        //logtext.AppendText(oneposter.poster+" - "+Convert.ToString(oneposter.point));
                        //logtext.AppendText(System.Environment.NewLine);
                        anoneposter = "";


                    }

                    
                }//while
            }//using




            return false;
        }


        public static string getBetween(string strSource, string strStart, string strEnd)
        {

            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        private string stringfromstring(string str, int maxLength)
        {
            return str.Substring(0, Math.Min(str.Length, maxLength));
        }
        private void checktimer_Tick(object sender, EventArgs e)
        {
            checknews();
            //MessageBox.Show("lefutottam!!!");
        }

        private void clear_Click(object sender, EventArgs e)
        {
            logtext.Text = "";
        }

        private void savelog_Click(object sender, EventArgs e)
        {
             SaveFileDialog saveFileDialog1 = new SaveFileDialog();
             saveFileDialog1.Filter = "Log fájl|*.log|txt fájl|*.txt";
            saveFileDialog1.Title = "Mentés";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string dirName =
                   System.IO.Path.GetDirectoryName(saveFileDialog1.FileName);
                string filename =
                 System.IO.Path.GetFileName(saveFileDialog1.FileName);
                StreamWriter sw = File.CreateText(saveFileDialog1.FileName);
                for (int i = 0; i < logtext.Lines.Length; i++)
                {
                    sw.WriteLine(logtext.Lines[i]);
                }
                sw.Flush();
                sw.Close();
            }
        }

        private void checkinterval_ValueChanged(object sender, EventArgs e)
        {
            checktimer.Interval = Convert.ToInt32(checkinterval.Value) * 1000;
        }
    }
}
