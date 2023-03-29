using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNUBclientFinalProject
{
    internal class uploadAndDisplayNoteMethods
    {
        //Method used to retrieve content from the server
        public List<List<string>> retrieveNotes(string classSelection)
        {
            
            List<List<string>> contentList = new List<List<string>>(serverCommunicationMethods.getClassNotes($"/cmds/class_notes?class={classSelection}"));
            return contentList;
        }

        //Method used to upload content to the server.
        public void uploadNotes(string note, string author, string classSelection)
        {
            string path = $"/cmds/publish?author={author}&class={classSelection}&note=\"{note}\"";
            List<List<string>> classNotes = new List<List<string>>(serverCommunicationMethods.getClassNotes(path));
        }
    }
}
